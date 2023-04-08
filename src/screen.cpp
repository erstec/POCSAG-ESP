/*
This file is a part of POCSAG-ESP project.

POCSAG-ESP is a POCSAG decoder for ESP32.
POCSAG-ESP is based on RadioLib and other libraries.

Licensed under GNU General Public License v3.0
Copyright (C) 2023 Ernest LY3PH

https://github.com/erstec/POCSAG-ESP
*/

#include "screen.h"
#include "rtc.h"
#include "settings.h"
#include "messages.h"

// OLED display definitions
#define SCREEN_WIDTH 128 // OLED display width, in pixels
#define SCREEN_HEIGHT 64 // OLED display height, in pixels

#define OLED_RESET -1 // Reset pin # (or -1 if sharing Arduino reset pin)
Adafruit_SSD1306 display(SCREEN_WIDTH, SCREEN_HEIGHT, &Wire, OLED_RESET);

bool screenInit() {
#if defined(ESP32DOIT_DEVKIT_V1)
    // OLED +3V3
    pinMode(OLED_POWER_PIN, OUTPUT);
    digitalWrite(OLED_POWER_PIN, HIGH);
#endif

    // initialize I2C
    if (!display.begin(SSD1306_SWITCHCAPVCC, 0x3C)) {
        Serial.println(F("SSD1306 allocation failed"));
        return false;
    }

    //display.display();
    //delay(500);
    display.clearDisplay();
    display.setTextSize(1);
    display.setTextColor(WHITE);
    display.setCursor(0, 12);
    display.println("POCSAG-ESP v" VERSION);
    display.println("by LY3PH");
    display.println("Initializing...");
    display.display();

    return true;
}

void displayStatus(periph_status_t status) {
    switch (status) {
        case STATUS_SX:
            display.println("SX1278 OK!");
            break;
        case STATUS_PAGER:
            display.println("Pager OK!");
            break;
        case STATUS_LISTENING:
            display.print("Listening... ");
            break;
        case STATUS_READY:
            display.println("Ready!");
            break;
        default:
            break;
    }
    display.display();
}

void displayMessage(String msg, uint32_t addr, uint32_t timestamp, bool newMessage) {
    if (msg.equals("<tone>")) return;
    // ignore pager error messages
    if (addr == 2007672) return;
    if (msg.length() > 80) return;

    display.clearDisplay();
    display.setTextSize(1);
    display.setTextColor(WHITE);
    display.setCursor(0, 8);
    display.println();
    display.println(msg);
    display.println();
    display.print("Address: ");
    display.println(addr);
    display.println();

    display.display();
}

void displayTimeDate(bool run) {
    display.setCursor(1, 1);
    //display.drawRect(0, 0, display.width(), 8, WHITE);
    display.fillRect(0, 0, display.width(), 9, WHITE);
    display.setTextColor(BLACK, WHITE);
    display.println(rtcGetTimeDateStr());
    if (run) display.display();
}

void displayError() {
    display.println("Error!");
    display.display();
}

void displayMainPage() {
    display.clearDisplay();

    displayTimeDate(false);

    display.setTextSize(1);
    display.setTextColor(WHITE);
    display.setCursor(0, 12);

    display.println("Listening...");
    display.setCursor(0, display.getCursorY() + 4);
    display.println("Freq: " + String(SX1278_FREQ, 6) + " MHz");
    display.println("  ID: " + String(SX1278_ADDR));
    display.printf("RSSI: %s dBm\r\n", "---");
    display.setCursor(0, display.getCursorY() + 5);
    display.printf("Msgs: %d/%d", messageGetNewCount(), messageGetAllCount());

    display.display();
}
