using PongLibrary.GameObjects;

namespace PongLibrary;

public static class GameState
{
    static readonly Paddle _human = new(true);
    static readonly Paddle _computer = new(false);
    static readonly Ball _ball = new();
    static readonly Net _net = new();
    static readonly BallTrail _ballTrail = new();
    static readonly Random _random = new();

    static int _ballLeftY;
    static int _ballRightY;

    public readonly static Dictionary<int, int> AllThePos = new();

    public static bool Running = false;
    public static int Speed = 2;
    public static bool Right = true;
    public static void CallDraws()
    {
        _net.Draw();
        _human.Draw();
        _computer.Draw();
        _ball.Draw();
        _ballTrail.Draw();
    }

    public static void MovePlayer(bool up)
    {
        if (up)
        {
            _human.Y -= 2;
        }
        else
        {
            _human.Y += 2;
        }
    }

    public static void MoveComputer()
    {
        _computer.Y = _ball.Y;
    }
    public static void BallPoints()
    {
        if (Right)
        {
            _ballLeftY = _ball.Y;
            _ballRightY = _random.Next(0,49);
            Speed = _random.Next(1, 4);
        } else
        {
            _ballRightY = _ball.Y;
            _ballLeftY = _random.Next(0, 49);
            Speed = _random.Next(1, 4);
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
}
