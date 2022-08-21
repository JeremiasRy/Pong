using Pong;
using PongLibrary;

if (!OperatingSystem.IsWindows())
{
    return;
}
System.Timers.Timer _timer = new System.Timers.Timer();


Console.CursorVisible = false;
Console.WindowHeight = 50;
Console.WindowWidth = 200;
ScreenBuffer sb = new ScreenBuffer(Console.WindowWidth, Console.WindowHeight);

StartGame();
PlayerInput();

Task PlayerInput()
{
    do
    {
        switch (Console.ReadKey().Key)
        {
            case ConsoleKey.UpArrow:
                GameState.MovePlayer(true);
                break;
            case ConsoleKey.DownArrow:
                GameState.MovePlayer(false);
                break;
        }
        Drawings.DrawPaddle(GameState.Human.X, GameState.Human.TopY);

    } while (!Console.ReadKey().Key.Equals(ConsoleKey.Escape));

    return Task.CompletedTask;
}

Task RefreshScreen()
{
    Drawings.DrawPaddle(GameState.Human.X, GameState.Human.TopY);
    Drawings.DrawPaddle(GameState.Computer.X, GameState.Computer.TopY);
    Drawings.DrawNet();
    Drawings.DrawBall(Ball.X, Ball.Y);
    sb.DrawScreen();
    return Task.CompletedTask;
}

async void OnTimedEvent(Object? source, System.Timers.ElapsedEventArgs e)
{
    await RefreshScreen();
    Ball.MoveBall();
}

void StartGame()
{
    GameState.BallPoints();

    _timer.Interval = 60;
    _timer.Elapsed += OnTimedEvent;
    _timer.AutoReset = true;
    _timer.Enabled = true;  
}



Console.ReadKey();
