/*
This file is a part of POCSAG-ESP project.

POCSAG-ESP is a POCSAG decoder for ESP32.
POCSAG-ESP is based on RadioLib and other libraries.

Licensed under GNU General Public License v3.0
Copyright (C) 2023 Ernest LY3PH

https://github.com/erstec/POCSAG-ESP
*/

#include "main.h"
#include <RadioLib.h>
#include <elapsedMillis.h>

#include "screen.h"
#include "messages.h"
#include "rtc.h"

#include "settings.h"

// SX1278 module instance
SX1278 radio = new Module(SX1278_NSS, SX1278_DIO0, SX1278_RESET, SX1278_DIO1);

// Data Read Pin (DIO2 on SX1278)
const int pin = SX1278_DIO2;

// create Pager client instance using the FSK module
PagerClient pager(&radio);

// or using RadioShield
// https://github.com/jgromes/RadioShield
// SX1278 radio = RadioShield.ModuleA;

elapsedMillis everySecond;
elapsedMillis every5Seconds;

void blinkError() {
    while (true) {
        digitalWrite(LED_BUILTIN, HIGH);
        delay(50);
        digitalWrite(LED_BUILTIN, LOW);
        delay(50);

        displayError();
    }
}

void setup() {
    // initialize built-in LED
    pinMode(LED_BUILTIN, OUTPUT);
    digitalWrite(LED_BUILTIN, HIGH);

    // initialize serial port
    Serial.begin(115200);
    Serial.println("\r\n\r\nStarting POCSAG-ESP v" VERSION " by LY3PH...");

    if (!screenInit()) {
        Serial.println(F("Failed to initialize screen!"));
        blinkError();
    }

    // initialize SX1278 with default settings
    Serial.print(F("[SX1278] Initializing... "));
    int state = radio.beginFSK();

    // when using one of the non-LoRa modules
    // (RF69, CC1101, Si4432 etc.), use the basic begin() method
    // int state = radio.begin();

    if (state == RADIOLIB_ERR_NONE) {
        Serial.println(F("success!"));
        displayStatus(STATUS_SX);
    } else {
        Serial.print(F("failed, code "));
        Serial.print(state);
        Serial.println(". Halting.");
        blinkError();
    }

    // initialize Pager client
    Serial.print(F("[Pager] Initializing... "));
    state = pager.begin(SX1278_FREQ, SX1278_BPS);
    if (state == RADIOLIB_ERR_NONE) {
        Serial.println(F("success!"));
        displayStatus(STATUS_PAGER);
    } else {
        Serial.print(F("failed, code "));
        Serial.print(state);
        Serial.println(". Halting.");
        blinkError();
    }

    // start receiving POCSAG messages
    Serial.print(F("[Pager] Starting to listen... "));
    state = pager.startReceive(pin, SX1278_ADDR, 0U); // no address filtering default 0xFFFFF - filtered to exact address only)
    if (state == RADIOLIB_ERR_NONE) {
        Serial.println(F("success!"));
        displayStatus(STATUS_LISTENING);
    } else {
        Serial.print(F("failed, code "));
        Serial.print(state);
        Serial.println(F(". Halting."));
        blinkError();
    }

    displayStatus(STATUS_READY);
}

void printTime() {
    Serial.println(rtcGetTimeStr());
}

void loop() {
    // blink status LED
    if (everySecond > 1000) {
        digitalWrite(LED_BUILTIN, !digitalRead(LED_BUILTIN));
        everySecond = 0;

        displayTimeDate();
    }

    if (every5Seconds > 5000) {
        every5Seconds = 0;
        //Serial.println(rtc.getTime("%A, %B %d %Y %H:%M:%S"));   // (String) returns time with specified format
        printTime();
    }

    // the number of batches to wait for
    // 2 batches will usually be enough to fit short and medium messages
    if (pager.available() >= 2) {
    // if (pager.available() >= 1) {
        Serial.println();
        printTime();
        Serial.print(F("[Pager] Received pager data, decoding... "));

        // you can read the data as an Arduino String
        String str;
        size_t len = 0U;
        uint32_t addr = 0U;
        int state = pager.readData(str, len, &addr);

        // you can also receive data as byte array
        /*
          byte byteArr[8];
          size_t numBytes = 0;
          int state = radio.receive(byteArr, &numBytes);
        */

        if (state == RADIOLIB_ERR_NONE) {
            Serial.println(F("success!"));

            // print the received data
            Serial.print(F("Data:\t"));
            Serial.println(str);
            Serial.print(F("Len:\t"));
            Serial.println(str.length());
            Serial.print(F("Addr:\t"));
            Serial.println(addr);

            messageParse(str, addr);
        } else {
            // some error occurred
            Serial.print(F("failed, code "));
            Serial.print(state);
            if (state == RADIOLIB_ERR_ADDRESS_NOT_FOUND) {
                Serial.print(F(". Address not found"));
            }
            Serial.println();
        }
    }
}
