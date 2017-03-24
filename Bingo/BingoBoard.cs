﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bingo
{
    public class BingoBoard
    {
        private readonly string[] _bingo = { "B", "I", "N", "G", "O" };

        public const int BoardNumberWidth = 120;
        public const int BoardNumberHeight = 110;
        
        public List<int> Numbers { get; } = new List<int>();
        public Random Rng { get; } = new Random();

        public string LetterForNumber(int num)
        {
            return _bingo[GetRowForNumber(num)];
        }

        public int GetRowForNumber(int num)
        {
            return (int)Math.Floor((num - 1) / 15f);
        }

        public int GetColumnForNumber(int num)
        {
            return (num - 1) % 15;
        }

        public Point GetPositionForNumber(int num)
        {
            var col = GetColumnForNumber(num);
            var row = GetRowForNumber(num);

            var pt = new Point(134 + col * BoardNumberWidth, 24 + row * BoardNumberHeight);

            if (col >= 7)
                pt.X += 14;

            return pt;
        }

        public int PickNumber()
        {
            if (Numbers.Count == 75)
                return 0;

            int num;
            do
            {
                num = Rng.Next(75) + 1;
            } while (Numbers.Contains(num));

            Numbers.Add(num);

            return num;
        }

        public void ResetBoard()
        {
            Numbers.Clear();
        }
    }
}
