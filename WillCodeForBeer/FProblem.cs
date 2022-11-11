namespace WillCodeForBeer;

public class Person
{
    public int Time { get; set; }
    public int Money { get; set; }
}

public class FProblem
{
    public static void Foo(string[] args)
    {
        var input = Console.ReadLine().Split(' ');
        
        var n = int.Parse(input[0]);
        var t = int.Parse(input[1]);

        var ordered = new List<Person>();
        
        // i - person
        for (var i = 0; i < n; i++)
        {
            var line = Console.ReadLine().Split(' ');
            
            var ci = int.Parse(line[0]); // cash
            var ti = int.Parse(line[1]); // minutes (leaves if no served)

            var p = new Person
            {
                Time = Math.Min(ti, t),
                Money = ci
            };
            
            ordered.Add(p);
        }

        ordered = ordered
            .OrderByDescending(x => x.Money)
            .ToList();

        var result = new Person[t];

        foreach (var person in ordered)
        {
            if (t == 0) break;
            
            for (var i = person.Time; i >= 0; i--)
            {
                if (result[i] == null)
                {
                    result[i] = person;
                    t--;
                    break;
                }
            }
        }

        Console.WriteLine(result.Where(x => x != null).Sum(x => x.Money));
    }
}