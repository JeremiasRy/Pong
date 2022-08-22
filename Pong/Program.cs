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
Initialize();
BallPoints();
CallDraws();

SetTimer();
PlayerInput();

void PlayerInput()
{
    do
    {
        switch (Console.ReadKey().Key)
        {
            case ConsoleKey.UpArrow:
                MovePlayer(true);
                break;
            case ConsoleKey.DownArrow:
                MovePlayer(false);
                break;
        }
    } while (!Console.ReadKey().Key.Equals(ConsoleKey.Escape));
}

void OnTimedEvent(Object? source, System.Timers.ElapsedEventArgs e)
{
    MoveBall();
    CallDraws();
    DrawScreen();
}

void SetTimer()
{
    _timer.Interval = 50;
    _timer.Elapsed += OnTimedEvent;
    _timer.Enabled = true;  
    _timer.AutoReset = true;    
}

Console.ReadKey();
