using System;
using System.Threading;

enum TrafficState
{
    MainGreen,
    LeftTurnGreen,
    Yellow,
    AllRed,
    PedestrianWalk
}

class TrafficController
{
    private static TrafficState currentState;
    private static bool pedestrianRequested = false;

    static void Main()
    {
        currentState = TrafficState.MainGreen;

        while (true)
        {
            CheckPedestrianInput();

            switch (currentState)
            {
                case TrafficState.MainGreen:
                    RunMainGreen();
                    currentState = TrafficState.LeftTurnGreen;
                    break;

                case TrafficState.LeftTurnGreen:
                    RunLeftTurn();
                    currentState = TrafficState.Yellow;
                    break;

                case TrafficState.Yellow:
                    RunYellow();
                    currentState = TrafficState.AllRed;
                    break;

                case TrafficState.AllRed:
                    RunAllRed();
                    currentState = pedestrianRequested ?
                                   TrafficState.PedestrianWalk :
                                   TrafficState.MainGreen;
                    break;

                case TrafficState.PedestrianWalk:
                    RunPedestrianWalk();
                    pedestrianRequested = false;
                    currentState = TrafficState.MainGreen;
                    break;
            }
        }
    }

    static void RunMainGreen()
    {
        DisplayState("MAIN GREEN - Straight & Right Turns Allowed",
                     ConsoleColor.Green, 7);
    }

    static void RunLeftTurn()
    {
        DisplayState("LEFT TURN GREEN - Protected Left Only",
                     ConsoleColor.Cyan, 5);
    }

    static void RunYellow()
    {
        DisplayState("YELLOW - Prepare to Stop",
                     ConsoleColor.Yellow, 3);
    }

    static void RunAllRed()
    {
        DisplayState("ALL RED - Intersection Clearing",
                     ConsoleColor.Red, 5);
    }

    static void RunPedestrianWalk()
    {
        DisplayState("PEDESTRIAN WALK - All Vehicles STOP",
                     ConsoleColor.Magenta, 7);
    }

    static void DisplayState(string message, ConsoleColor color, int duration)
    {
        Console.Clear();
        Console.ForegroundColor = color;
        Console.WriteLine("🚦 SMART TRAFFIC CONTROLLER");
        Console.WriteLine("--------------------------------");
        Console.WriteLine(message);
        Console.WriteLine("--------------------------------");

        for (int i = duration; i > 0; i--)
        {
            Console.WriteLine($"Time Remaining: {i} sec");
            Thread.Sleep(1000);
        }

        Console.ResetColor();
    }

    static void CheckPedestrianInput()
    {
        if (Console.KeyAvailable)
        {
            var key = Console.ReadKey(true);
            if (key.Key == ConsoleKey.P)
            {
                pedestrianRequested = true;
            }
        }
    }
}