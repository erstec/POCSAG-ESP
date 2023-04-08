/*
This file is a part of POCSAG-ESP project.

POCSAG-ESP is a POCSAG decoder for ESP32.
POCSAG-ESP is based on RadioLib and other libraries.

Licensed under GNU General Public License v3.0
Copyright (C) 2023 Ernest LY3PH

https://github.com/erstec/POCSAG-ESP
*/

#define VERSION "0.1.1"

#define UTC_OFFSET 3    // offset from GMT (+3 h)

// the number of batches to wait for
// 2 batches will usually be enough to fit short and medium messages
#define MSG_BATCH_SIZE  2
// #define MSG_BATCH_SIZE  1

#define MAIN_PAGE_TMO   10000   // 10 seconds

// #define RX_ONLY_ADDRESSED

// #define DELAYED_PARSE

// Work configuration definitions
// base (center) frequency:     439.987.500 MHz
// speed:                       1200 bps
// address of this "pager":     1234567
#define SX1278_FREQ   439.987500
#define SX1278_BPS    1200
#define SX1278_ADDR   1234567

#if defined(ESP32DOIT_DEVKIT_V1)
// DevKit-V1 specific definitions
// Board specific definitions
// Button and LED (built-in)
#define BUTTON_PIN    0
// #define LED_PIN       2
// I2C BUS
// #define SDA_PIN       21
// #define SCL_PIN       22
// SPI BUS
// #define MISO_PIN      19
// #define MOSI_PIN      23
// #define SCK_PIN       18
// #define SS_PIN        5

// OLED Power Pin
#define OLED_POWER_PIN  4

// SX1278 definitions
#define SX1278_NSS    13
#define SX1278_DIO0   12
#define SX1278_RESET  14
#define SX1278_DIO1   27
#define SX1278_DIO2   26
#endif

#if defined(TTGO_LORA32_V21)
// // TTGO Board specific definitions
// #define HPDIO1 33
// #define HPDIO2 32

// // SX1278 definitions
// #define SX1278_NSS    18
// #define SX1278_DIO0   26
// #define SX1278_RESET  23
// #define SX1278_DIO1   HPDIO1
// #define SX1278_DIO2   HPDIO2
#endif
