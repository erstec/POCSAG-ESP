/*
This file is a part of POCSAG-ESP project.

POCSAG-ESP is a POCSAG decoder for ESP32.
POCSAG-ESP is based on RadioLib and other libraries.

Licensed under GNU General Public License v3.0
Copyright (C) 2023 Ernest LY3PH

https://github.com/erstec/POCSAG-ESP
*/

#include "config.h"

#include <ArduinoJson.h>
#include <SPIFFS.h>

#include "settings.h"

Config_ts config;

bool configInit() {
    if (!SPIFFS.begin(true)) {
        Serial.println(F("[CFG] SPIFFS mount failed"));
        return false;
    }

    return true;
}

void configLoad() {
    bool configLoaded = false;
    if (SPIFFS.exists("/config.json")) {
        File configFile = SPIFFS.open("/config.json", "r");
        if (configFile) {
            size_t size = configFile.size();
            std::unique_ptr<char[]> buf(new char[size]);
            configFile.readBytes(buf.get(), size);
            // DynamicJsonDocument json(1024);
            StaticJsonDocument<512> json;
            DeserializationError error = deserializeJson(json, buf.get());
            if (!error) {
                Serial.println("[CFG] Config loaded from file");

                config.freq = json["freq"];
                config.baud = json["baud"];
                config.address = json["address"];
                config.filterAddress = json["filterAddress"];
                config.utcOffset = json["utcOffset"];

                configLoaded = true;
            } else {
                Serial.println("[CFG] Failed to load config.json");
            }
            configFile.close();
        }
    }

    if (!configLoaded) {
        Serial.println("[CFG] Using default config");

        config.freq = SX1278_FREQ / 1000000.0;
        config.baud = SX1278_BPS;
        config.address = SX1278_ADDR;
#ifdef RX_ONLY_ADDRESSED
        config.filterAddress = true;
#else
        config.filterAddress = false;
#endif
        config.utcOffset = UTC_OFFSET;

        // Create default config file
        configSave();
    }
}

void configSave() {
    Serial.println("[CFG] Saving config");

    StaticJsonDocument<512> json;
    json["freq"] = config.freq;
    json["baud"] = config.baud;
    json["address"] = config.address;
    json["filterAddress"] = config.filterAddress;
    json["utcOffset"] = config.utcOffset;

    File configFile = SPIFFS.open("/config.json", "w");
    if (!configFile) {
        Serial.println("[CFG] Failed to open config file for writing");
    }

    serializeJson(json, configFile);
    configFile.close();
}
