using System;
using Xunit;

namespace Coding.TowersOfHanoi.Test
{
    public class TowersOfHanoiTest
    {
        [Theory]
        [InlineData(3)]
        [InlineData(4)]
        [InlineData(10)]
        public void MoveDisksTest(int count)
        {
            var diskManager = new DiskManager(count);

            diskManager.MoveDisks();

            var tower = diskManager.Destination;

            // Verify Destination tower has all the disks
            int disk = 1;
            while(disk == count)
            {
                Assert.Equal(disk++, tower.Pop());
            }
        }
    }
}
