/*
This file is a part of POCSAG-ESP project.

POCSAG-ESP is a POCSAG decoder for ESP32.
POCSAG-ESP is based on RadioLib and other libraries.

Licensed under GNU General Public License v3.0
Copyright (C) 2023 Ernest LY3PH

https://github.com/erstec/POCSAG-ESP
*/

#include <Arduino.h>
#include <ESP32Time.h>

typedef struct {
    String message;
    uint32_t address;
    uint32_t timestamp;
    bool newMessage;
} message_ts;

String messageFormatID(uint32_t addr);
bool messageParse(String str, uint32_t addr);
uint16_t messageGetAllCount();
uint16_t messageGetNewCount();
void messageLastDisplay();
uint32_t messageGetTotalParsed();
