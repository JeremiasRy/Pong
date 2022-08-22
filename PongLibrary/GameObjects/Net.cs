using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PongLibrary.GameObjects
{
    public class Net : IGameObject
    {
        public int Y { get; set; } = 0;
        public int X { get; set; } = Console.WindowWidth / 2;

        public void Draw()
        {
            for (int y = 0; y < 50; y++)
            {
                ScreenBuffer.Draw('\u2591', y, X);
            }
        }
    }
}
