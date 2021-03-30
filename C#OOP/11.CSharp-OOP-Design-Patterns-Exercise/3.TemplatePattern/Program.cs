using System;

namespace _3.TemplatePattern
{
    class Program
    {
        static void Main(string[] args)
        {
            Sourdough sourdoght = new Sourdough();
            sourdoght.Make();

            TwelveGrain twelveGrain = new TwelveGrain();
            twelveGrain.Make();

            WholeWheat wholeWheat = new WholeWheat();
            wholeWheat.Make();
        }
    }
}
