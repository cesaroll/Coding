using System;
using Coding.Collections;

namespace Coding.TowersOfHanoi
{
    public class DiskManager
    {
        public Tower Origin {get; set;}
        private Tower Buffer {get; set;}
        public Tower Destination {get; set;}

        public DiskManager(int diskCount)
        {
            Origin = new Tower("Origin");
            Buffer = new Tower("Buffer");
            Destination = new Tower("Destination");

            //Add Disks in Origin Stack from bigger to lower
            for(int i=diskCount; i>0; i--)
            {
                Origin.Push(i);
            }
        }

        public void MoveDisks()
        {
            MoveDisks(Origin.Length, Origin, Destination, Buffer);
        }

        private void MoveDisks(long n, Tower origin, Tower destination, Tower buffer)
        {
            if( n > 0)
            {
                MoveDisks(n-1, origin, buffer, destination);
                origin.MoveTo(destination);
                MoveDisks(n-1, buffer, destination, origin);
            }
        }
    }
}