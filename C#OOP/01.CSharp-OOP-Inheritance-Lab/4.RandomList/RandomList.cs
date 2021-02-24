using System;
using System.Collections.Generic;
using System.Text;

namespace CustomRandomList
{
    public class RandomList : List<string>
    {
        public string RandomString()
        {
            Random random = new Random();
            if (this.Count == 0)
            {
                return default;
            }

            return this[random.Next(0, this.Count)];
        }
    }
}
