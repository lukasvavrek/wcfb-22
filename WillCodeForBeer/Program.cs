using System;
using System.Collections.Generic;
using System.Linq;

namespace WillCodeForBeer
{
    public class Program
    {
        // b - wip
        public static void Main(string[] args)
        {
            var input = Console.ReadLine().Split(' ');
            var n = int.Parse(input[0]); // num of ints
            var m = int.Parse(input[1]);

            var unions = new Dictionary<int, List<int>>();

            for (var i = 0; i < n; i++)
            {
                unions[i+1] = new List<int> { i + 1 };
            }

            // commands
            for (var i = 0; i < m; i++)
            {
                var cmd = Console.ReadLine().Split(' ');
                var t = int.Parse(cmd[0]);
                var p = int.Parse(cmd[1]);
                var q = 0;

                if (t == 1 || t == 2)
                {
                    q = int.Parse(cmd[2]);
                }

                switch (t)
                {
                    case 1: // union sets containing p and q
                        UnionOp(unions, p, q);
                        break;
                    case 2: // move p to the set containing q
                        MoveOp(unions, p, q);
                        break;
                    case 3:
                        PrintOp(unions, p);
                        break;
                }
            }
        }

        private static void PrintOp(Dictionary<int, List<int>> unions, int p)
        {
            var pu = GetUnionFor(unions, p);
            Console.WriteLine($"{pu.Count} {pu.Sum()}");
        }

        private static void MoveOp(Dictionary<int, List<int>> unions, int p, int q)
        {
            var pu = GetUnionFor(unions, p);
            if (pu.Contains(q)) return;

            var qu = GetUnionFor(unions, q);

            var npu = new List<int>(pu);
            npu.Remove(p);
            foreach (var item in npu)
            {
                unions[item] = npu;
            }

            var nqu = new List<int>(qu);
            nqu.Add(p);
            foreach (var item in nqu)
            {
                unions[item] = nqu;
            }
        }

        private static void UnionOp(Dictionary<int, List<int>> unions, int p, int q)
        {
            var pu = GetUnionFor(unions, p);
            if (pu.Contains(q)) return;

            var qu = GetUnionFor(unions, q);
            var join = pu.Concat(qu).ToList();

            foreach (var item in join)
            {
                unions[item] = join;
            }
        }

        public static List<int> GetUnionFor(Dictionary<int, List<int>> unions, int key)
        {
            if (unions.ContainsKey(key))
            {
                return unions[key];
            }

            return new List<int> { key }; 
        }
    }
}
