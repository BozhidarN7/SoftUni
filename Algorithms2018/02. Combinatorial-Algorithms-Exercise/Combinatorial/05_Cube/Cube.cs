using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _05_Cube
{
    class Cube
    {
        private static int count = 0;
        private static HashSet<string> allPossibleCubes = new HashSet<string>();

        static void Main(string[] args)
        {
            char[] cube = Console.ReadLine().Split(' ').Select(x => x[0]).ToArray();

            GenerateAllCubes(cube, 0);

            Console.WriteLine(count);
        }

        private static void GenerateAllCubes(char[] cube, int index)
        {
            if (index >= cube.Length)
            {
                if (!allPossibleCubes.Contains(new string(cube)))
                {
                    AddCube(cube);
                    count++;
                }
            }
            else
            {
                GenerateAllCubes(cube, index + 1);
                HashSet<char> used = new HashSet<char>();
                used.Add(cube[index]);

                for (int i = index + 1; i < cube.Length; i++)
                {
                    if (!used.Contains(cube[i]))
                    {
                        Swap(cube, index, i);
                        GenerateAllCubes(cube, index + 1);
                        Swap(cube, index, i);

                        used.Add(cube[i]);
                    }
                }
            }
        }

        private static void AddCube(char[] cube)
        {
            for (int x = 0; x < 4; x++)
            {
                for (int y = 0; y < 4; y++)
                {
                    for (int z = 0; z < 4; z++)
                    {
                        allPossibleCubes.Add(new string(cube));
                        cube = RotateZ(cube);
                    }
                    cube = RotateY(cube);
                }
                cube = RotateX(cube);
            }
        }

        private static char[] RotateX(char[] cube)
        {
            var newCube = new char[cube.Length];

            newCube[0] = cube[9];
            newCube[1] = cube[5];
            newCube[2] = cube[10];
            newCube[3] = cube[1];

            newCube[4] = cube[8];
            newCube[5] = cube[7];
            newCube[6] = cube[11];
            newCube[7] = cube[3];

            newCube[8] = cube[0];
            newCube[9] = cube[4];
            newCube[10] = cube[6];
            newCube[11] = cube[2];

            return newCube;
        }

        private static char[] RotateY(char[] cube)
        {
            var newCube = new char[cube.Length];

            newCube[0] = cube[2];
            newCube[1] = cube[10];
            newCube[2] = cube[6];
            newCube[3] = cube[11];

            newCube[4] = cube[0];
            newCube[5] = cube[9];
            newCube[6] = cube[4];
            newCube[7] = cube[8];

            newCube[8] = cube[3];
            newCube[9] = cube[1];
            newCube[10] = cube[5];
            newCube[11] = cube[7];


            return newCube;
        }

        private static char[] RotateZ(char[] cube)
        {
            var newCube = new char[cube.Length];

            newCube[0] = cube[1];
            newCube[1] = cube[2];
            newCube[2] = cube[3];
            newCube[3] = cube[0];

            newCube[4] = cube[5];
            newCube[5] = cube[6];
            newCube[6] = cube[7];
            newCube[7] = cube[4];

            newCube[8] = cube[9];
            newCube[9] = cube[10];
            newCube[10] = cube[11];
            newCube[11] = cube[8];

            return newCube;
        }

        private static void Swap(char[] cube, int first, int second)
        {
            var temp = cube[first];
            cube[first] = cube[second];
            cube[second] = temp;
        }
    }
}
