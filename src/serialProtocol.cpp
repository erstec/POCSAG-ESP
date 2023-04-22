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
        if (str.startsWith("SET FREQ")) {
            double freq = str.substring(9).toDouble();
            if (freq < 400.0 || freq > 470.0) {
                Serial.println("Invalid frequency");
            } else {
                config.freq = freq;
            }
        }
        else if (str.startsWith("SET BAUD")) {
            uint16_t baud = str.substring(9).toInt();
            if (baud == 1200) {
                config.baud = baud;
            } else {
                Serial.println("Invalid baud rate");
            }
        }
        else if (str.startsWith("SET ADDR")) {
            uint32_t addr = str.substring(9).toInt();
            if (addr > 2000000) {
                Serial.println("Invalid address");
            } else {
                config.address = addr;
            }
            config.address = str.substring(9).toInt();
        }
        else if (str.startsWith("SET FILTER")) {
            bool filter = str.substring(11).toInt();
            if (filter == 0 || filter == 1) {
                config.filterAddress = filter;
            } else {
                Serial.println("Invalid filter value");
            }
        }
        else if (str.startsWith("SET UTC")) {
            uint8_t utc = str.substring(8).toInt();
            if (utc > 12) {
                Serial.println("Invalid UTC offset");
            } else {
                config.utcOffset = utc;
            }
        }
        else {
            Serial.println("Unknown subcommand");
        }
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
        configSave();
    }
    else if (str.startsWith("REBOOT")) {
        ESP.restart();
    }
    else if (str.startsWith("VERSION")) {
        Serial.println("POCSAG-ESP v" + String(VERSION) + " by LY3PH");
        Serial.println(BUILD_VER);
    }
    else if (str.startsWith("HELP")) {
        Serial.println("SET FREQ <freq.freq in MHz> - set frequency");
        Serial.println("SET BAUD <baud> - set baud rate");
        Serial.println("SET ADDR <address> - set address");
        Serial.println("SET FILTER <0/1> - set address filter");
        Serial.println("SET UTC <offset> - set UTC offset");
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
