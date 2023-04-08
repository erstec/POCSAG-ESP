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

elapsedMillis mainScreenTMO;

void blinkError() {
    while (true) {
        digitalWrite(LED_BUILTIN, HIGH);
        delay(50);
        digitalWrite(LED_BUILTIN, LOW);
        delay(50);

        displayError();
    }
}

static int _buttonState = HIGH;

void IRAM_ATTR buttonISR() {
    //_buttonState = digitalRead(BUTTON_PIN);
    _buttonState = LOW;
}

void setup() {
    // initialize built-in LED
    pinMode(LED_BUILTIN, OUTPUT);
    digitalWrite(LED_BUILTIN, HIGH);

    // initialize built-in button
    pinMode(BUTTON_PIN, INPUT_PULLUP);
    attachInterrupt(BUTTON_PIN, buttonISR, FALLING);

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

static bool _mainPageActive = false;

#ifdef DELAYED_PARSE
#define DELAYED_PARSE_DELAY (100000 * 5)
#define MESSAGES_MAX_COUNT 10
static message_ts _messages[MESSAGES_MAX_COUNT];
static int msgIdx = 0;
static int delayedParse = 0;
#endif

void loop() {
    // Temporary button press interrupt reader
    if (_buttonState == LOW) {
        Serial.println(F("Button pressed!"));
        messageLastDisplay();
        mainScreenTMO = 0;
        displayMainPageRefresh();
        _buttonState = HIGH;
    } 
    
    _mainPageActive = (mainScreenTMO > MAIN_PAGE_TMO) ? true : false;

#ifdef DELAYED_PARSE
    if (delayedParse == 0) {
#endif
        // blink status LED
        if (everySecond > 1000) {
            digitalWrite(LED_BUILTIN, !digitalRead(LED_BUILTIN));
            everySecond = 0;

            // if not in main screen, show time and date
            // otherwise it is routine of main screen refresh function
            if (!_mainPageActive) {
                displayTimeDate();
            } else {
                // mainScreenTMO = 0; // reset after arrived Message shown on OLED
                displayMainPage();
            }
        }

        if (every5Seconds > 5000) {
            every5Seconds = 0;
            //Serial.println(rtc.getTime("%A, %B %d %Y %H:%M:%S"));   // (String) returns time with specified format
            printTime();
            // Serial.print(F("RSSI: "));
            // Serial.print(radio.getRSSI(true));
            // Serial.print(F(" dBm, AFC: "));
            // Serial.print(radio.getAFCError());
            // Serial.println(F(" Hz"));
        }
#ifdef DELAYED_PARSE
    }
#endif
#ifdef DELAYED_PARSE
    // Read all messages from the buffer
    while (pager.available() > 0) {
        String str;
        size_t len = 0U;
        uint32_t addr = 0U;
        int state = pager.readData(str, len, &addr);

        if (state == RADIOLIB_ERR_NONE) {
            _messages[msgIdx].message = str;
            _messages[msgIdx].address = addr;
            
            msgIdx++;

            if (msgIdx >= MESSAGES_MAX_COUNT) {
                msgIdx = 0;
                Serial.println(F("Message buffer overflow!"));
            }
        }

        delayedParse = DELAYED_PARSE_DELAY;
    }

    if (delayedParse > 0) {
        delayedParse--;
    }

    if (delayedParse == 0) {
        if (msgIdx > 0) Serial.printf("Got %d messages\r\n", msgIdx);

        // Parse all messages
        while (msgIdx > 0) {
            msgIdx--;

            Serial.printf("Showing message %d\r\n", msgIdx + 1);
            Serial.println("Data: " + _messages[msgIdx].message);
            Serial.println("Address: " + String(_messages[msgIdx].address));

            if (messageParse(_messages[msgIdx].message, _messages[msgIdx].address)) {
                mainScreenTMO = 0;
                displayMainPageRefresh();
            }
        }
    }
#else
    // while (pager.available() > 0) {
    // while (pager.available() >= MSG_BATCH_SIZE) {
    if (pager.available() >= MSG_BATCH_SIZE) {
        Serial.println();
        printTime();
        Serial.print(F("[Pager] Received pager data, decoding... "));

        // you can read the data as an Arduino String
        String str;
        size_t len = 0U;
        uint32_t addr = 79U;
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
            Serial.println(messageFormatID(addr));

            if (messageParse(str, addr)) {
                mainScreenTMO = 0;
                displayMainPageRefresh();
            }
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
#endif
}
