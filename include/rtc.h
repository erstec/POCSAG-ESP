/*
This file is a part of POCSAG-ESP project.

POCSAG-ESP is a POCSAG decoder for ESP32.
POCSAG-ESP is based on RadioLib and other libraries.

Licensed under GNU General Public License v3.0
Copyright (C) 2023 Ernest LY3PH

https://github.com/erstec/POCSAG-ESP
*/

#include <ESP32Time.h>

String rtcGetTimeStr();
uint32_t rtcGetTimeUnix();
void rtcSetTimeDate(int sec, int min, int hour, int day, int month, int year);
String rtcGetTimeDateStr();
bool rtcCheckTimeDateNeedUpdate(unsigned long time);
