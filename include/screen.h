/*
This file is a part of POCSAG-ESP project.

POCSAG-ESP is a POCSAG decoder for ESP32.
POCSAG-ESP is based on RadioLib and other libraries.

Licensed under GNU General Public License v3.0
Copyright (C) 2023 Ernest LY3PH

https://github.com/erstec/POCSAG-ESP
*/

#include <Adafruit_GFX.h>
#include <Adafruit_SSD1306.h>

typedef enum {
    STATUS_SX,
    STATUS_PAGER,
    STATUS_LISTENING,
    STATUS_READY,
} periph_status_t;

bool screenInit();
void displayStatus(periph_status_t status);
void displayMessage(String msg, uint32_t addr, uint32_t timestamp, bool newMessage = false);
void displayTimeDate(bool run = true);
void displayError();
void displayMainPage();
