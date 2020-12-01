using System;

namespace PadawanEquipment
{
    class PadawanEquipment
    {
        static void Main(string[] args)
        {
            double budget = double.Parse(Console.ReadLine());
            int students = int.Parse(Console.ReadLine());
            double lightsabersPrice = double.Parse(Console.ReadLine());
            double robesPrice = double.Parse(Console.ReadLine());
            double belts = double.Parse(Console.ReadLine());

            int bonusLightsabers = (int)Math.Ceiling(students * 0.1);
            int freeBelts = students / 6;
            double totalPrice = students * lightsabersPrice + lightsabersPrice * bonusLightsabers + students * robesPrice + students * belts - freeBelts * belts;

            if (budget >= totalPrice)
            {    
                Console.WriteLine($"The money is enough - it would cost {totalPrice:f}lv.");
            }
            else
            {
                Console.WriteLine($"Ivan Cho will need {totalPrice - budget:f}lv more.");
            }
        }
    }
}
