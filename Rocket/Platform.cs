using System;

namespace Rocket
{
    public enum Result { OkForLanding = 0, OutOfPlatform = 1, Clash = 2 }

    public class Platform
    {
        public int X { get; set; }
        public int Y { get; set; }
        public int Top { get; set; }
        public int Left { get; set; }
        public (int X, int Y)? Previous { get; set; }

        public Platform(int x, int y, int top, int left)
        {
            if (x < 1 || y < 1)
                throw new Exception("Platform must have at least (1, 1) size.");

            if (top < 0 || left < 0)
                throw new Exception("Platform must be inside landing area.");

            (X, Y, Top, Left) = (x, y, top, left);
        }

        public Result Check(int x, int y)
        {
            if (x < Top || x > Top + X || y < Left || y > Left + Y)
            {
                Previous = (x, y);
                return Result.OutOfPlatform;
            }

            if (Previous != null && Previous?.X - 1 <= x && x <= Previous?.X + 1 && Previous?.Y - 1 <= y && y <= Previous?.Y + 1)
            {
                Previous = (x, y);
                return Result.Clash;
            }

            Previous = (x, y);
            return Result.OkForLanding;
        }
    }
}