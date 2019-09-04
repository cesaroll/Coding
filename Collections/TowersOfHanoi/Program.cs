using System;


namespace Coding.TowersOfHanoi
{
    class Program
    {
        static void Main(string[] args)
        {
            var diskManager = new DiskManager(3);
            diskManager.MoveDisks();
        }
    }
}
