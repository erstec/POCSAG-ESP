/*
This file is a part of POCSAG-ESP project.

POCSAG-ESP is a POCSAG decoder for ESP32.
POCSAG-ESP is based on RadioLib and other libraries.

Licensed under GNU General Public License v3.0
Copyright (C) 2023 Ernest LY3PH

https://github.com/erstec/POCSAG-ESP
*/

#include "serialProtocol.h"
#include "config.h"
#include "settings.h"

void spParseCmd(String str) {
    str.trim();
    str.toUpperCase();
    if (str.startsWith("SET")) {
        Serial.println("Not implemented yet");
    }
    else if (str.startsWith("GET")) {
        // if (str.substring(4) == "ALL") {
            Serial.println(String(config.freq, 6));
            Serial.println(config.baud);
            Serial.println(config.address);
            Serial.println(config.filterAddress);
            Serial.println(config.utcOffset);
        // }
    }
    else if (str.startsWith("SAVE")) {
        // store to SPIFFS
        Serial.println("Not implemented yet");
    }
    else if (str.startsWith("REBOOT")) {
        ESP.restart();
    }
    else if (str.startsWith("VERSION")) {
        Serial.println("POCSAG-ESP v" + String(VERSION) + " by LY3PH");
        Serial.println(BUILD_VER);
    }
    else if (str.startsWith("HELP")) {
        Serial.println("SET FREQ <freq> - set frequency");
        Serial.println("SET BAUD <baud> - set baud rate");
        Serial.println("SET ADDR <address> - set address");
        Serial.println("SET FILTER <0/1> - set address filter");
        Serial.println("SAVE - save settings to Flash");
        // Serial.println("GET ALL - get all settings");
        Serial.println("GET - get all settings");
        Serial.println("REBOOT - reboot device");
        Serial.println("VERSION - get version");
        Serial.println("HELP - get help");
    }
    else {
        Serial.println("Unknown command");
    }
    
    Serial.println();
}
