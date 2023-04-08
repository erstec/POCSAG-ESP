/*
This file is a part of POCSAG-ESP project.

POCSAG-ESP is a POCSAG decoder for ESP32.
POCSAG-ESP is based on RadioLib and other libraries.

Licensed under GNU General Public License v3.0
Copyright (C) 2023 Ernest LY3PH

https://github.com/erstec/POCSAG-ESP
*/

#include "messages.h"
#include "rtc.h"
#include "screen.h"
#include "settings.h"

String year, month, day, hour, minute, second;
String _time, _date;

static uint16_t _allMessages = 0;
static uint16_t _newMessages = 0;

//static message_ts _messages[MESSAGES_MAX_COUNT];
static message_ts _lastMessage;

bool messageParse(String str, uint32_t addr) {
    if (addr == 216) { // 0000216 - Time announcement in UTC
        if (str.startsWith("YYYYMMDDHHMMSS")) {
            // parse the message
            // YYYYMMDDHHMMSS230407140800
            year = str.substring(14, 16);
            month = str.substring(16, 18);
            day = str.substring(18, 20);
            hour = str.substring(20, 22);
            minute = str.substring(22, 24);
            second = str.substring(24, 26);

            _date = day + "." + month + "." + year;
            _time = hour + ":" + minute + ":" + second;

            Serial.println("Time received [" + _date + " " + _time + "]");
            rtcSetTimeDate(second.toInt(), minute.toInt(), hour.toInt(), day.toInt(), month.toInt(), year.toInt() + 2000);
        }
    }
    else if (addr == 4520) {
        Serial.println("Skyper message");
    }
    else if (addr == 8) {
        Serial.println("Repeater callsign");
    }
    else if (addr == 2504) {
        Serial.println("Skyper OTA Time");
    }
    else if (addr == 208 || addr == 224) {
        Serial.println("German time announcement");
    }
    else if (addr == 200) {
        if (str.startsWith("XTIME=")) {
            // XTIME=1610070423XTIME=1610070423
            hour = str.substring(6, 8);
            minute = str.substring(8, 10);
            second = "00";
            day = str.substring(10, 12);
            month = str.substring(12, 14);
            year = str.substring(14, 16);
            _time = hour + ":" + minute + ":" + second;
            _date = day + "." + month + "." + year;

            Serial.println("Time received [" + _date + " " + _time + "]");
            rtcSetTimeDate(second.toInt(), minute.toInt(), hour.toInt(), day.toInt(), month.toInt(), year.toInt() + 2000);
        }
    } else {
        Serial.println("Unknown address: " + String(addr));

#ifdef RX_ONLY_ADDRESSED
        if (addr == SX1278_ADDR) {
            _allMessages++;
            _newMessages++;

            _lastMessage.message = str;
            _lastMessage.address = addr;
            _lastMessage.timestamp = rtcGetTimeUnix();
            _lastMessage.newMessage = true;

            displayMessage(_lastMessage.message, _lastMessage.address, _lastMessage.timestamp, _lastMessage.newMessage);
        }
#else
        _allMessages++;
        _newMessages++;

        _lastMessage.message = str;
        _lastMessage.address = addr;
        _lastMessage.timestamp = rtcGetTimeUnix();
        _lastMessage.newMessage = true;

        displayMessage(_lastMessage.message, _lastMessage.address, _lastMessage.timestamp, _lastMessage.newMessage);
#endif

        return true;
    }

    return false;
}

void messageLastDisplay() {
    if (_allMessages > 0) {
        displayMessage(_lastMessage.message, _lastMessage.address, _lastMessage.timestamp, _lastMessage.newMessage);
        _newMessages = 0;
    } else {
        displayMessage("No messages", 0, 0, false);
    }
}

uint16_t messageGetAllCount() {
    return _allMessages;
}

uint16_t messageGetNewCount() {
    return _newMessages;
}
