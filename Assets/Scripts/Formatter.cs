using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Formatter
{
    public string GetFormattedTime(float totalTime)
    {
        int min = 0;
        int sec = 0;
        int millisec = 0;

        if (totalTime > 0)
        {
            if (totalTime > 60)
            {
                min = (int)totalTime / 60;
                sec = (int)totalTime - 60 * min;
            }
            else
            {
                min = 0;
                sec = (int)totalTime;
            }

            if (totalTime > 1)
            {
                millisec = (int)(totalTime % (int)totalTime * 100);
            }
            else
            {
                millisec = (int)(totalTime * 100);
            }    
        }

        return GetFormattedTimeUnit(min) + ":" + GetFormattedTimeUnit(sec) + ":" + GetFormattedTimeUnit(millisec);
    }

    public string GetFormattedTimeUnit(int value)
    {
        string formatValue;
        if (value < 10)
        {
            formatValue = "0" + Convert.ToString(value);
        }
        else
        {
            formatValue = Convert.ToString(value);
        }
        return formatValue;
    }
}
