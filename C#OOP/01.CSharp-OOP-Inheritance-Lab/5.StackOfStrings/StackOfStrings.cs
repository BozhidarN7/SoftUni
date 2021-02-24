using System;
using System.Collections.Generic;
using System.Text;

namespace CustomStack
{
    public class StackOfStrings : Stack<string>
    {
        public bool IsEmpty()
        {
            return Count == 0 ? true : false;
        }
        public Stack<string> AddRange(IEnumerable<string> data)
        {
            foreach (string item in data)
            {
                this.Push(item);
            }
            return this;
        }
    }
}
