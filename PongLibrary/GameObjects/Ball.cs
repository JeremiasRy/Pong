using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PongLibrary.GameObjects;

public class Ball : IGameObject
{
    public int X { get; set; } = 2;
    public int Y { get; set; } = Console.WindowHeight / 2;

    public void Draw()
    {
        ScreenBuffer.Draw('\u2588', Y, X);
    }
}
