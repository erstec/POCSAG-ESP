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
    struct tm timeinfo = {0};
    timeinfo.tm_sec = sec;
    timeinfo.tm_min = min;
    timeinfo.tm_hour = hour;
    timeinfo.tm_mday = day;
    timeinfo.tm_mon = month - 1;
    timeinfo.tm_year = year - 1900;
    time_t t = mktime(&timeinfo);
    t += 3600 * UTC_OFFSET;
    if (rtcCheckTimeDateNeedUpdate(t)) {     
        rtc.setTime(sec, min, hour, day, month, year);
        rtcSet = true;
        Serial.println("[RTC] set");
    }
}

String rtcGetTimeDateStr() {
    return rtcSet ? rtc.getTime("%Y-%m-%d %H:%M:%S") : "RTC not set! Wait!";
}

bool rtcCheckTimeDateNeedUpdate(unsigned long time) {
    bool result = false;
    unsigned long currentTime = rtc.getEpoch();
    int timeDrifted = currentTime - time;
    Serial.println("[RTC] time drift: " + String(timeDrifted) + " seconds");
    if (timeDrifted > 0) {
        if (timeDrifted > 60) {
            result = true;
        }
    } else {
        if (timeDrifted < -60) {
            result = true;
        }
    }

    return (!rtcSet || result);
}
