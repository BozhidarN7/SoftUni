using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04_ShopKeeper
{
    class ShopKeeper
    {
        private static Dictionary<int, int> byOccurrences = new Dictionary<int, int>();
        //private static HashSet<int> deltedItems = new HashSet<int>();

        private static int swaps = 0;

        static void Main(string[] args)
        {
            List<int> stock = Console.ReadLine().Split(' ').Select(int.Parse).ToList();
            List<int> orders = Console.ReadLine().Split(' ').Select(int.Parse).ToList();

            InitializeDictionary(orders);
            //CheckForNeedlessItems(stock, orders);

            if (!stock.Contains(orders.First()))
            {
                Console.WriteLine("impossible");
                return;
            }

            FindNeededSwaps(stock, orders);

            Console.WriteLine(swaps);
        }

        private static void FindNeededSwaps(List<int> stock, List<int> orders)
        {
            for (int i = 0; i < orders.Count - 1; i++)
            {
                int currentItem = orders[i];

                byOccurrences[currentItem]--;
                if (byOccurrences[currentItem] == 0)
                {
                    byOccurrences.Remove(currentItem);
                    orders.Remove(currentItem);
                    i--;
                    //CheckForNeedlessItems(stock,currentItem);
                }

                if (!stock.Contains(orders[i + 1]))
                {
                    // Need swap
                    bool hasNeedless = CheckForNeedlessItems(stock, orders, orders[i + 1]);

                    if (!hasNeedless)
                    {
                        int lessMeeted = byOccurrences.Values.OrderBy(x => x).First();
                        int order = byOccurrences.Where(x => x.Value == lessMeeted).Where(x => stock.Contains(x.Key)).First().Key;

                        int indexInStock = stock.IndexOf(order);
                        stock[indexInStock] = orders[i + 1];
                        swaps++;
                    }

                }
            }
        }

        private static bool CheckForNeedlessItems(List<int> stock, List<int> orders, int next)
        {
            for (int i = 0; i < stock.Count; i++)
            {
                if (!orders.Contains(stock[i]))
                {
                    // Replace 
                    stock[i] = next;
                    swaps++;
                    return true;
                }
            }

            return false;
        }

        private static void InitializeDictionary(List<int> orders)
        {
            foreach (var order in orders)
            {
                if (!byOccurrences.ContainsKey(order))
                {
                    byOccurrences[order] = 1;
                }
                else
                {
                    byOccurrences[order]++;
                }
            }
        }
    }
}
