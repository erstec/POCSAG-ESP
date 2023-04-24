/*
This file is a part of POCSAG-ESP project.

POCSAG-ESP is a POCSAG decoder for ESP32.
POCSAG-ESP is based on RadioLib and other libraries.

Licensed under GNU General Public License v3.0
Copyright (C) 2023 Ernest LY3PH

https://github.com/erstec/POCSAG-ESP
*/

#include "led.h"
#include "settings.h"

static uint16_t step = 0;
static LedState_te lastPattern = LED_OFF;

void ledSetPattern(LedState_te state) {
    // if (lastPattern == state) return; // do not override current pattern
    if (lastPattern != LED_OFF && state == LED_BLINK_TWICE) return; // do not override 10sec blink
    step = 0;
    lastPattern = state;
}

static const uint16_t howMuchStepsIn10Sec = 10000 / 50;

void ledNotifyRun() {
    switch (lastPattern) {
        case LED_OFF:
            digitalWrite(LED_PIN, LOW);
            break;
        case LED_ON:
            digitalWrite(LED_PIN, HIGH);
            break;
        case LED_BLINK_10SEC:
            if (step % 2 == 0) {
                digitalWrite(LED_PIN, LOW);
            } else {
                digitalWrite(LED_PIN, HIGH);
            }
            if (step >= howMuchStepsIn10Sec) {
                step = 0;
                lastPattern = LED_OFF;
            }
            step++;
            break;
        case LED_BLINK_TWICE:
            if (step == 0) {
                digitalWrite(LED_PIN, HIGH);
                step++;
            } else if (step == 1) {
                digitalWrite(LED_PIN, LOW);
                step++;
            } else if (step == 2) {
                digitalWrite(LED_PIN, HIGH);
                step++;
            } else if (step == 3) {
                digitalWrite(LED_PIN, LOW);
                step = 0;
                lastPattern = LED_OFF;
            }
            break;
        case LED_BLINK_ERROR:
            while (true) {
                digitalWrite(LED_PIN, HIGH);
                delay(50);
                digitalWrite(LED_PIN, LOW);
                delay(50);
            }
            break;

        default:
            break;
    }
}
