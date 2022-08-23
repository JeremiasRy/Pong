using PongLibrary.GameObjects;

namespace PongLibrary;

public static class GameState
{
    public static readonly Paddle Human = new(true);
    public static readonly Paddle Computer = new(false);
    static readonly Ball _ball = new();
    static readonly Net _net = new();
    static readonly BallTrail _ballTrail = new();
    static readonly Random _random = new();
    static readonly ScoreBoard _scoreBoard = new();

    static int _ballLeftY;
    static int _ballRightY;

    public readonly static Dictionary<int, int> AllThePos = new();

    public static bool BallInPlay = false;
    public static int Speed = 3;
    public static bool Right = true;
    public static void CallDraws()
    {
        _net.Draw();
        _scoreBoard.Draw();
        Human.Draw();
        Computer.Draw();
        if (BallInPlay)
        {
            _ballTrail.Draw();
        }
        if (!BallInPlay)
        {
            ScreenBuffer.DrawText(Computer.Score < 9 ? "Computer scores!! Press space to serve or ESC to exit." : "Computer was too good, Press ESC to exit", 10, Console.WindowWidth / 3);
        }
        _ball.Draw();
    }

    public static void MovePlayer(bool up)
    {
        if (up)
        {
            Human.Y -= 2;
            if (!BallInPlay)
            {
                _ball.Y = Human.Y - 1;
            }
        }
        else
        {
            Human.Y += 2;
            if (!BallInPlay)
            {
                _ball.Y = Human.Y - 1;
            }

        }
    }

    public static void MoveComputer()
    {
        Computer.Y = _ball.Y;
    }
    public static void BallPoints()
    {
        if (Right)
        {
            _ballLeftY = _ball.Y;
            _ballRightY = _random.Next(0,49);
            Speed = _random.Next(2, 5);
        } else
        {
            _ballRightY = _ball.Y;
            _ballLeftY = _random.Next(0, 49);
            Speed = _random.Next(2, 5);
        }
    }

    public static void CalculateBallPositions()
    {
        bool lower = _ballLeftY - _ballRightY < 0;
        int difference = lower ? _ballRightY - _ballLeftY : _ballLeftY - _ballRightY;
        for (int x = 2; x <= 196; x++)
        {
            int y = difference * (x - 2) / 194 + _ballLeftY;
            if (!lower)
            {
                int yDif = y - _ballLeftY;
                y = _ballLeftY - yDif;
            }
            AllThePos[x] = y;
        }
    }

    public static void MoveBall()
    {
        if (Right)
        {
            if (_ball.X + Speed >= 196)
            {
                _ball.X = 196;
                _ball.Y = AllThePos[_ball.X];
                Right = false;
                BallPoints();
                CalculateBallPositions();
            } else
            {
                _ball.X += Speed;
                _ball.Y = AllThePos[_ball.X];
                _ballTrail.X = _ball.X -  Speed;
                _ballTrail.Y = AllThePos[_ballTrail.X];
            }
        }
        else
        {
            if(_ball.X - Speed <= 2)
            {
                if (!CheckForHit())
                {
                    Computer.Score++;
                    BallInPlay = false;
                    _ball.X = 2;
                    _ball.Y = Human.Y - 1;
                    Right = true;
                    return;
                }
                _ball.X = 2;
                _ball.Y = AllThePos[_ball.X];
                Right = true;
                BallPoints();
                CalculateBallPositions();
            } else
            {
                _ball.X -= Speed;
                _ball.Y = AllThePos[_ball.X];
                _ballTrail.X = _ball.X + Speed;
                _ballTrail.Y = AllThePos[_ballTrail.X];
            }
        }
    }

    static bool CheckForHit()
    {
        return Human.Positions.Contains(_ball.Y);
    }
}
