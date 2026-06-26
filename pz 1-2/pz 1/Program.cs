using System;
using Utils;

class Program
{
    static void Main()
    {
        double v = 20.0;
        double angle = 45.0;

        double distance = PhysicsCalc.CalculateDistance(v, angle);

        Console.WriteLine($"Початкова швидкість: {v} м/с");
        Console.WriteLine($"Кут кидка: {angle} градусів");
        Console.WriteLine($"Дальність польоту: {distance} м");
        Console.ReadLine();
    }
}