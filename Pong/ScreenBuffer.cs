using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pong;

public class ScreenBuffer
{
    readonly int _roomWidth;
    readonly int _roomHeight;
    //initiate important variables
    public static char[,] screenBufferArray; //main buffer array
    public static string screenBuffer; //buffer as string (used when drawing)
    readonly char whiteSpace = char.Parse(" ");

    public static void Draw(char block, int x, int y)
    {
            screenBufferArray[x, y] = block;
    }

    public void DrawScreen()
    {
        screenBuffer = "";
        //iterate through buffer, adding each value to screenBuffer
        for (int iy = 0; iy < _roomHeight; iy++)
        {
            for (int ix = 0; ix < _roomWidth; ix++)
            {
                screenBuffer += screenBufferArray[ix, iy];
            }
        }
        //set cursor position to top left and draw the string
        Console.SetCursorPosition(0, 0);   
        Console.Write(screenBuffer);
        ClearArray();
        //note that the screen is NOT cleared at any point as this will simply overwrite the existing values on screen. Clearing will cause flickering again.
    }

    public void ClearArray()
    {
        for (int iy = 0; iy < _roomHeight; iy++)
        {
            for (int ix = 0; ix < _roomWidth; ix++)
            {
                screenBufferArray[ix, iy] = whiteSpace;
            }
        }
    }

    public ScreenBuffer(int screenWidth, int screenHeight)
    {
        _roomWidth = screenWidth;
        _roomHeight = screenHeight;

        screenBufferArray = new char[screenWidth, screenHeight];
        screenBuffer = "";

        for (int iy = 0; iy < _roomHeight; iy++)
        {
            for (int ix = 0; ix < _roomWidth; ix++)
            {
                screenBufferArray[ix, iy] = whiteSpace;
            }
        }
    }


}


