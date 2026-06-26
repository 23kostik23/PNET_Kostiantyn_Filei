using System;

namespace Utils
{
    public class PhysicsCalc
    {
        public static double CalculateDistance(double velocity, double angleDegrees)
        {
            double g = 9.81;
            double angleRadians = angleDegrees * Math.PI / 180.0;

            // Формула: L = (v^2 * sin(2*alpha)) / g
            double distance = (Math.Pow(velocity, 2) * Math.Sin(2 * angleRadians)) / g;

            return Math.Round(distance, 2);
        }
    }
}