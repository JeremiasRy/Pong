using PongLibrary.GameObjects;

namespace PongLibrary;

public static class GameState
{
    static readonly Paddle _human = new(true);
    static readonly Paddle _computer = new(false);
    static readonly Ball _ball = new();
    static readonly Net _net = new();

    static int _ballStartY = _ball.Y;
    static int _ballEndY;

    static bool Right = true;

    static Random random = new Random();

    public static void CallDraws()
    {
        _net.Draw();
        _human.Draw();
        _computer.Draw();
        _ball.Draw();
    }

    public static void MovePlayer(bool up)
    {
        if (up)
        {
            _human.Y--;
        }
        else
        {
            _human.Y++;
        }
    }

    public static void MoveComputer()
    {
        _computer.Y = _ball.Y;
    }
    public static void BallPoints()
    {
        _ballStartY = _ball.Y;
        _ballEndY = random.Next(0, 49);
    }

    public static int CalculateBallPositionY()
    {
        bool lower = _ballStartY - _ballEndY < 0;
        int difference = lower ? _ballEndY - _ballStartY : _ballStartY - _ballEndY; 
        int xdistance = 194;

        return difference * (_ball.X - (Right ? 2 : 196)) / xdistance + _ballStartY;
    }

    public static void MoveBall()
    {
        if (Right)
        {
            if (_ball.X + 2 >= 196)
            {
                _ball.X = 196;
                BallPoints();
                Right = false;
            }
            else
            {
                if (CalculateBallPositionY() < 0 || CalculateBallPositionY() >= 49)
                {
                    BallPoints();
                    _ball.X += 2;
                    _ball.Y = CalculateBallPositionY();
                } else
                {
                    _ball.X += 2;
                    _ball.Y = CalculateBallPositionY();
                }
            }
        }
        else
        {
            if (_ball.X - 2 <= 2)
            {
                _ball.X = 2;
                BallPoints();
                Right = true;
            }
            else
            {
                if (CalculateBallPositionY() < 0 || CalculateBallPositionY() >= 49)
                {
                    BallPoints();
                    _ball.X -= 2;
                    _ball.Y = CalculateBallPositionY();
                } else
                {
                    _ball.X -= 2;
                    _ball.Y = CalculateBallPositionY();
                }
            }
        }
    }
}
