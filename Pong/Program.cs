using static PongLibrary.GameState;
using static PongLibrary.ScreenBuffer;

if (!OperatingSystem.IsWindows())
{
    return;
}
System.Timers.Timer _timer = new System.Timers.Timer();

Console.CursorVisible = false;
Console.WindowHeight = 50;
Console.WindowWidth = 200;

Console.Write("Press any key to start!!!!");
Console.ReadKey();
Running = true;

Initialize();
BallPoints();
CalculateBallPositions();
CallDraws();

var playerInput = new Task(PlayerInput);
var runGame = new Task(RunGame);

runGame.Start();
playerInput.Start();

var tasks = new[] { playerInput, runGame };

Task.WaitAll(tasks);

void PlayerInput()
{
    ConsoleKeyInfo key = new();
    while (!Console.KeyAvailable && key.Key != ConsoleKey.Escape)
    {
        key = Console.ReadKey(true);
        switch (key.Key)
        {
            case ConsoleKey.UpArrow:
                MovePlayer(true);
                break;
            case ConsoleKey.DownArrow:
                MovePlayer(false);
                break;
            case ConsoleKey.Escape:
                Running = false;
                break;
        }
    }
}

void RunGame()
{
    while (Running)
    {
        Thread.Sleep(20);
        MoveBall();
        CallDraws();
        DrawScreen();
    }
}

