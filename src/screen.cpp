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
#include "config.h"

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
    delay(250);
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
    bool noMsgTag = msg.isEmpty() && addr == 0U && timestamp == 0U && !newMessage;
    display.clearDisplay();
    display.setTextSize(1);
    display.setTextColor(WHITE);
    display.setCursor(0, 8);
    display.println();
    if (noMsgTag) {
        display.setTextSize(1, 2);
        display.setCursor(5, display.getCursorY() + 10);
        display.println("No messages!");
        display.setTextSize(1);
    } else {
        display.println(msg);
    }
    display.println();
    if (addr != 0 && !noMsgTag) {
        display.print("Address: ");
        display.println(messageFormatID(addr));
        display.println();
    }

    display.display();

    // display.dim(false);
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

static struct {
    bool needRefresh = true;
    uint16_t msgsCnt;
    uint16_t newMsgsCnt;
} lastMainData;

void displayMainPage() {
    uint16_t msgsCnt = messageGetAllCount();
    uint16_t newMsgsCnt = messageGetNewCount();

    if (lastMainData.msgsCnt == msgsCnt && lastMainData.newMsgsCnt == newMsgsCnt && !lastMainData.needRefresh) {
        displayTimeDate(true);
        return;
    } else {
        lastMainData.msgsCnt = msgsCnt;
        lastMainData.newMsgsCnt = newMsgsCnt;
        lastMainData.needRefresh = false;
    }

    display.clearDisplay();

    displayTimeDate(false);

    display.setTextSize(1);
    display.setTextColor(WHITE);
    display.setCursor(0, 12);

    display.println("Listening...");
    display.setCursor(0, display.getCursorY() + 4);
    display.println("Freq: " + String(config.freq, 6) + " MHz");
    display.println("  ID: " + messageFormatID(config.address));
    // display.printf("RSSI: %s dBm\r\n", "---");
    display.setCursor(0, display.getCursorY() + 5);
    display.printf("Msgs: %d/%d ", newMsgsCnt, msgsCnt);
    if (newMsgsCnt > 0) {
        display.setTextColor(BLACK, WHITE);
        display.print(" New msg! ");
        display.setTextColor(WHITE);
    }

    display.display();
    
    // display.dim(true);
}

void displayMainPageRefresh() {
    lastMainData.needRefresh = true;
}
