namespace WillCodeForBeer;

public class IProblem
{
    public void Foo()
    {
        var input = Console.ReadLine().Split(' ');
            
        var x = int.Parse(input[0]);
        var y = int.Parse(input[1]);
            
        Console.WriteLine(x+y);
    }
}