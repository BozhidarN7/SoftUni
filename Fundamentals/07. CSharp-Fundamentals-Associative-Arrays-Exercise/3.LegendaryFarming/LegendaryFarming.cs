using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;

namespace _3.LegendaryFarming
{
    class LegendaryFarming
    {
        static void Main(string[] args)
        {
            List<string> input = Console.ReadLine().Split().ToList();
            Dictionary<string, int> materials = new Dictionary<string, int>();

            Dictionary<string, int> keyMaterials = new Dictionary<string, int>();
            keyMaterials.Add("motes", 0);
            keyMaterials.Add("fragments", 0);
            keyMaterials.Add("shards", 0);

            bool isObtained = false;
            while (true)
            {
                for (int i = 0; i < input.Count; i += 2)
                {
                    int quantity = int.Parse(input[i]);
                    string material = input[i + 1].ToLower();

                    if (material == "motes" || material == "fragments" || material == "shards")
                    {
                        keyMaterials[material] += quantity;
                        if (keyMaterials[material] >= 250)
                        {
                            isObtained = true;
                            if (material == "motes")
                            {
                                Console.WriteLine("Dragonwrath obtained!");
                            }
                            else if (material == "shards")
                            {
                                Console.WriteLine("Shadowmourne obtained!");
                            }
                            else
                            {

                                Console.WriteLine("Valanyr obtained!");
                            }
                            keyMaterials[material] -= 250;
                        }
                    }
                    else
                    {
                        if (!materials.ContainsKey(material))
                        {
                            materials.Add(material, 0);
                        }
                        materials[material] += quantity;
                    }
                    if (isObtained)
                    {
                        break;
                    }

                }
                if (isObtained)
                {
                    break;
                }
                input = Console.ReadLine().Split().ToList();
            }

            foreach (var item in keyMaterials.OrderByDescending(x => x.Value).ThenBy(x => x.Key))
            {
                Console.WriteLine($"{item.Key}: {item.Value}");
            }

            foreach (var item in materials.OrderBy(x => x.Key))
            {
                Console.WriteLine($"{item.Key}: {item.Value}");
            }

        }
    }
}
