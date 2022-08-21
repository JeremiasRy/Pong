using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PongLibrary;

public static class GameState
{
    public static Paddle Human = new (true);

    public static Paddle Computer = new(false);

    static int ballStartPosY;
    static int ballEndPosY;

    static Random random = new Random();

    public static void MovePlayer(bool up)
    {
        if (up)
        {
            Human.Y--;
        } else
        {
            Human.Y++;
        }
    }

    public static void MoveComputer()
    {
        Computer.Y = Ball.Y;
    }
    public static void BallPoints()
    {
        ballStartPosY = Ball.Y;
        ballEndPosY = random.Next(0, 49);
    }

    public static int CalculateBallPositionY()
    {
        int difference = Math.Abs(ballStartPosY - ballEndPosY);
        int xdistance = 196;

        return difference * (Ball.X - (Ball._right ? 2 : 196)) / xdistance + ballStartPosY;
    }
}
