namespace Task1;

public class Program
{
    public static void Main()
    {
        var planet1 = new Planet(){X = 4, Y = 5, Z = 64, Mass = 6400.44, Radius = 23};
        Console.WriteLine($"Planet1:\nCoords: {planet1.X}, {planet1.Y}, {planet1.Z}. Mass: {planet1.Mass}. Radius: {planet1.Radius}");
        var planet2 = new Planet() { X = 0, Y = 0, Z = 0, Mass = -976, Radius = -54 };
        Console.WriteLine($"Planet1:\nCoords: {planet2.X}, {planet2.Y}, {planet2.Z}. Mass: {planet2.Mass}. Radius: {planet2.Radius}");
        Console.WriteLine($"Planet1 IsZero Result: {planet1.IsZero()}. \n Planet2 IsZero Result: {planet2.IsZero()}");
        Console.WriteLine($"Distance between Planet 1 and Planet 2: {planet1.EvaluateDistance(planet2)}");
        var planet3 = new Planet() { X = 4, Y = 5, Z = 64, Mass = 5600, Radius = 23 };
        Console.WriteLine($"Is there any collisions? \n Result: {Planet.DetectCollisions(planet1, planet2, planet3)}");
    }
}