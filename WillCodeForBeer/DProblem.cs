namespace WillCodeForBeer;

public class DProblem
{
    public static void Foo()
    {
        var n = int.Parse(Console.ReadLine());

        var p = 1;
        var s = 0;

        var d = 0;

        while (s < n)
        {
            if (p < n / 2)
            {
                p *= 2;
            }
            else
            {
                s += p;
            }

            d++;
        }
                
        Console.WriteLine(d);
                
        /*  n=5       
         *  1t         1t         1t
         *  2t         2t         2t
         *  2t 2s      4t         3t 1s
         *  2t 4s      4t 4s      3t 4s
         *  2t 6s      4t 8s      3t 7s
         *
         *  n=1
         *  1t
         *  1t 1s
         */
    }
}