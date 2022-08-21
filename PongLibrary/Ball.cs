using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PongLibrary;

public static class Ball
{
    public static bool _right = true;
    public static int X { get; set; } = 2;
    public static int Y { get; set; } = Console.WindowHeight / 2;

    public static void MoveBall()
    {
        if (_right)
        {
            if (X++ == 196)
            {
                X++;
                GameState.BallPoints();
                Y = GameState.CalculateBallPositionY();
                _right = false;
            } else
            {
                X++;
                Y = GameState.CalculateBallPositionY();
            }
        } else
        {
            if (X-- == 4)
            {
                X--;
                GameState.BallPoints();
                Y = GameState.CalculateBallPositionY();
                _right = true;
            } else
            {
                X--;
                Y = GameState.CalculateBallPositionY();
            }
        }
    }


}
