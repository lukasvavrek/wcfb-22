namespace WillCodeForBeer;

public class JProblem
{
    public static void Run()
    {
        // 1 < n < 1000
        var n = int.Parse(Console.ReadLine());

        // n - space separated words
        // either Ai or mumble

        var count = 0;

        var input = Console.ReadLine().Split(' ');

        for (var i = 0; i < n; i++)
        {
            if (input[i] == "mumble")
            {
                count++;
            }
            else if (int.Parse(input[i]) == count + 1)
            {
                count++;
            }
            else
            { 
                Console.WriteLine("something is fishy");
                return;
            }
        }

        Console.WriteLine("makes sense");
    }
}