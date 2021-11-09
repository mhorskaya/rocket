using System;
using System.Linq;
using Xunit;

namespace Rocket.Tests
{
    public class PlatformTests
    {
        [Theory]
        [InlineData(10, 0, -1, 0)]
        [InlineData(0, 10, 0, -1)]
        [InlineData(0, 10, 5, 5)]
        [InlineData(10, 0, 5, 5)]
        public void Platform_Creates_Correctly(int x, int y, int top, int left)
        {
            Assert.Throws<Exception>(() => new Platform(x, y, top, left));
        }

        [Theory]
        [InlineData(10, 10, 5, 5, new[] { "5,5,0", "16,15,1" })]
        [InlineData(10, 10, 5, 5, new[] { "7,7,0", "8,8,2" })]
        [InlineData(10, 10, 5, 5, new[] { "7,7,0", "8,8,2", "1,1,1" })]
        [InlineData(10, 10, 5, 5, new[] { "7,7,0", "10,10,0", "7,7,0", "8,8,2" })]
        public void Platform_Results_Correctly(int x, int y, int top, int left, string[] checks)
        {
            var platform = new Platform(x, y, top, left);
            foreach (var check in checks)
            {
                var parts = check.Split(",").Select(int.Parse).ToArray();
                var result = platform.Check(parts[0], parts[1]);
                Assert.Equal((int)result, parts[2]); // enum Result { OkForLanding = 0, OutOfPlatform = 1, Clash = 2 }
            }
        }
    }
}