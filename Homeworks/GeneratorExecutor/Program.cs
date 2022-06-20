using System;

internal class Program
{
    private static void Main(string[] args)
    {
        //JenxWelcome2.SayHello();
        var type = Type.GetType("JenxWelcome2");
        Console.WriteLine(type.ToString());
        Console.ReadLine();
    }
}
