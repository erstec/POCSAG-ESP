/*
This file is a part of POCSAG-ESP project.

POCSAG-ESP is a POCSAG decoder for ESP32.
POCSAG-ESP is based on RadioLib and other libraries.

Licensed under GNU General Public License v3.0
Copyright (C) 2023 Ernest LY3PH

https://github.com/erstec/POCSAG-ESP
*/

#include <Arduino.h>

typedef struct {
    double freq;
    uint16_t baud;
    uint32_t address;
    bool filterAddress;
    uint8_t utcOffset;
} Config_ts;

extern Config_ts config;

void configLoad();
