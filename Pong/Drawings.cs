using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pong;

public class Drawings
{
    static char FullBlock { get; } = Char.Parse("\u2588"); 
    static char ShadeBlock { get; set; } = Char.Parse("\u2591");

    public static void DrawPaddle(int x, int y)
    {
        int[] _positions = new int[5];
        for (int i = 0; i < 5; i++)
        {
            _positions[i] = y + i;
        }
        foreach (int yPos in _positions)
            ScreenBuffer.Draw(FullBlock, x, yPos);
    }

    public static void DrawNet()
    {
        int x = Console.WindowWidth / 2;
        for (int i = 0; i < Console.WindowHeight; i++)
        {
            ScreenBuffer.Draw(ShadeBlock, x, i);
        }
    }

    public static void DrawBall(int x, int y)
    {
        ScreenBuffer.Draw(FullBlock, x, y);
    }

}
