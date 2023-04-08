/*
This file is a part of POCSAG-ESP project.

POCSAG-ESP is a POCSAG decoder for ESP32.
POCSAG-ESP is based on RadioLib and other libraries.

Licensed under GNU General Public License v3.0
Copyright (C) 2023 Ernest LY3PH

https://github.com/erstec/POCSAG-ESP
*/

#include "config.h"
#include "settings.h"

Config_ts config;

void configLoad() {
    config.freq = SX1278_FREQ / 1000000.0;
    config.baud = SX1278_BPS;
    config.address = SX1278_ADDR;
#ifdef RX_ONLY_ADDRESSED
    config.filterAddress = true;
#else
    config.filterAddress = false;
#endif

    // if (SPIFFS.begin()) {
    //     if (SPIFFS.exists("/config.json")) {
    //         File configFile = SPIFFS.open("/config.json", "r");
    //         if (configFile) {
    //             size_t size = configFile.size();
    //             std::unique_ptr<char[]> buf(new char[size]);
    //             configFile.readBytes(buf.get(), size);
    //             DynamicJsonDocument json(1024);
    //             DeserializationError error = deserializeJson(json, buf.get());
    //             if (!error) {
    //                 config.freq = json["freq"];
    //                 config.baud = json["baud"];
    //                 config.address = json["address"];
    //                 config.filterAddress = json["filterAddress"];
    //             }
    //             else {
    //                 Serial.println("Failed to load config.json");
    //             }
    //         }
    //     }
    // }
    // else {
    //     Serial.println("Failed to mount file system");
    // }
}
