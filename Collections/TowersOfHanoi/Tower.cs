using System;
using Coding.Collections;

namespace Coding.TowersOfHanoi
{
    public class Tower : Coding.Collections.Stack 
    {
        private string Name {get; }
        public Tower(string name)
        {
            this.Name = name;
        }
        public void MoveTo(Tower other)
        {
            other.Push(this.Pop());
        }

        public override int Pop()
        {            
            var value = base.Pop();
            Console.WriteLine($"Tower: {this.Name} - Remove Disk: {value}");
            return value;
        }

        public override void Push(int value)
        {
            if(this.Length > 0 && this.Peek() < value)
                throw new Exception($"Tower: {this.Name} - Cannot place disk: {value} on top of disk: {this.Peek()}");

            Console.WriteLine($"Tower: {this.Name} - Add Disk: {value}");
            base.Push(value);            
        }

    }
}
