/*
This file is a part of POCSAG-ESP project.

POCSAG-ESP is a POCSAG decoder for ESP32.
POCSAG-ESP is based on RadioLib and other libraries.

Licensed under GNU General Public License v3.0
Copyright (C) 2023 Ernest LY3PH

https://github.com/erstec/POCSAG-ESP
*/

#include "main.h"
#include "rtc.h"
#include "settings.h"

static bool rtcSet = false;

ESP32Time rtc(3600 * UTC_OFFSET);

String rtcGetTimeStr() {
    return rtc.getTime("%Y-%m-%d %H:%M:%S");
}

uint32_t rtcGetTimeUnix() {
    return rtc.getEpoch();
}

void rtcSetTimeDate(int sec, int min, int hour, int day, int month, int year) {
    rtc.setTime(sec, min, hour, day, month, year);
    rtcSet = true;
}

String rtcGetTimeDateStr() {
    return rtcSet ? rtc.getTime("%Y-%m-%d %H:%M:%S") : "RTC not set! Wait!";
}
