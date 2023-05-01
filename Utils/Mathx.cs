using System;

namespace GraphAlgorithmVisualizer.Utils
{
    internal class Mathx
    {
        public static double ToDegrees(double radians) => radians * (180d / Math.PI);
        public static double ToRadians(double degrees) => degrees * (Math.PI / 180d);
        public static double Clamp(double value, double min, double max)
        {
            if (value < min)
                return min;
            if (value > max) 
                return max;
            return value;
        }
        public static int Clamp(int value, int min, int max)
        {
            if (value < min)
                return min;
            if (value > max) 
                return max;
            return value;
        }
    }
}
