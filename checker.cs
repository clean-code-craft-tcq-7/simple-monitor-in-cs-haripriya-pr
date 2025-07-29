using System;
using System.Diagnostics;

class Checker
{
    private static void DisplayVitals(string message)
    {
        Console.WriteLine(message);
        for (int i = 0; i < 6; i++)
        {
            Console.Write("\r* ");
            Thread.Sleep(1000);
            Console.Write("\r *");
            Thread.Sleep(1000);
        }
    }

    private static bool IsGreaterThan(float a, float? b, float toleranceValue = 0.00001f)
    {
        if (b.HasValue)
            return (a - b.Value) > toleranceValue;
        return false;

    }

    private static bool IsLesserThan(float a, float? b, float toleranceValue = 0.00001f)
    {
        if (b.HasValue)
            return (b.Value - a) > toleranceValue;
        return false;
    }

    private static bool CheckVitals(string vital,float reading, float? lowerLimit, float? upperLimit)
    {
        if (IsGreaterThan(reading, upperLimit) || IsLesserThan(reading, lowerLimit))
        {
            DisplayVitals($"{vital} is out of range");
            return false;
        }
        DisplayVitals($"{vital} received within normal range");
        return true;
    }

    public static bool VitalsOk(float temperature, int pulseRate, int spo2)
    {
        return CheckVitals("Temperature", temperature, 95,102) && CheckVitals("Pulse Rate", pulseRate, 60, 100) && CheckVitals("Oxygen Saturation", spo2, 90, null);
    }
}
