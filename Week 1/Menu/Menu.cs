using System;

namespace Gab
{
    namespace Menu
    {
        public class Menu
        {
            //------------------------------------------------------------------------
            private readonly int _itemSize;
            private readonly String[] _itemArray;

            private int _posX;

            private int _posY;

            //---------------------------------------------------------------------
            public ConsoleColor UseColor { get; set; } = ConsoleColor.Blue;

            public ConsoleColor DefColor { get; set; } = ConsoleColor.White;

            //---------------------------------------------------------------------
            private void PrintItem(int numLine)
            {
                Console.WriteLine(" #" + (numLine + 1 < 10 ? $"0{numLine + 1} " : $"{numLine + 1} ") +
                                  _itemArray[numLine]);
            }

            private void ReColor(int numLine, ConsoleColor color)
            {
                Console.ForegroundColor = color;
                Console.CursorLeft = _posX;
                Console.CursorTop = _posY + numLine;
                PrintItem(numLine);
            }

            private int Handler()
            {
                int numLine = 0;
                ReColor(numLine, UseColor);

                while (true)
                {
                    ConsoleKeyInfo key = Console.ReadKey(true);

                    if (key.Key == ConsoleKey.DownArrow)
                    {
                        if (numLine + 1 == _itemSize) continue;
                        else
                        {
                            ReColor(numLine, DefColor);
                            numLine++;
                            ReColor(numLine, UseColor);
                        }
                    }
                    else if (key.Key == ConsoleKey.UpArrow)
                    {
                        if (numLine == 0) continue;
                        else
                        {
                            ReColor(numLine, DefColor);
                            numLine--;
                            ReColor(numLine, UseColor);
                        }
                    }
                    else if (key.Key == ConsoleKey.Enter) break;
                }

                return ++numLine;
            }

            //---------------------------------------------------------------------
            public Menu(params String[] itemArray)
            {
                _itemSize = itemArray.Length;
                _itemArray = new String[_itemSize];
                for (var i = 0; i < _itemSize; i++) _itemArray[i] = itemArray[i];
            }

            public int Run()
            {
                Console.Clear();
                Console.CursorVisible = false;

                _posX = Console.CursorLeft;
                _posY = Console.CursorTop;

                for (int i = 0; i < _itemSize; i++)
                {
                    if (i == 0) Console.WriteLine();
                    else PrintItem(i);
                }

                int choice = Handler();

                Console.ForegroundColor = DefColor;
                Console.CursorVisible = true;
                Console.Clear();

                return choice;
            }
        } //------------------------------------------------------------------------
    }
}
