using System;
using System.Threading;

class TrafficRobot
{
    static void Main()
    {
        while (true)
        {
            GreenLight();
            YellowLight();
            RedLight();
        }
    }

    static void GreenLight()
    {
        Console.Clear();
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("🚦 TRAFFIC LIGHT");
        Console.WriteLine("GREEN LIGHT - GO");
        Countdown(10);
    }

    static void YellowLight()
    {
        Console.Clear();
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine("🚦 TRAFFIC LIGHT");
        Console.WriteLine("YELLOW LIGHT - SLOW DOWN");
        Countdown(3);
    }

    static void RedLight()
    {
        Console.Clear();
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("🚦 TRAFFIC LIGHT");
        Console.WriteLine("RED LIGHT - STOP");
        Countdown(7);
    }

    static void Countdown(int seconds)
    {
        for (int i = seconds; i > 0; i--)
        {
            Console.WriteLine("Time remaining: " + i + " seconds");
            Thread.Sleep(1000);
        }
    }
}