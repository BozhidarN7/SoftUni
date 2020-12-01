using System;
using System.Text;
using System.Linq;
namespace _5.MultiplyBigNumber
{
    class Program
    {
        static void Main(string[] args)
        {
            string bigNumber = Console.ReadLine();
            int smallNumber = int.Parse(Console.ReadLine());

            if (smallNumber == 0 || bigNumber == string.Empty)
            {
                Console.WriteLine(0);
                return;
            }

            StringBuilder sb = new StringBuilder();
            int addition = 0;
            for (int i = bigNumber.Length - 1; i >= 0; i--)
            {
                int result = smallNumber * (bigNumber[i] - '0') + addition;
                addition = result / 10 % 10;
                sb.Append(result % 10);
            }
            if (addition != 0)
            {
                sb.Append(addition);
            }
            string answer = new string(sb.ToString().Reverse().ToArray());
            while (answer[0] == '0')
            {
                answer =answer.Remove(0, 1);
            }
            Console.WriteLine(answer);
        }
    }
}
