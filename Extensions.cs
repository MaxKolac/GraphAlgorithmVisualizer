using System;

namespace GraphAlgorithmVisualizer
{
    internal class Extensions
    {
        public static double ToRadians(double degrees) => degrees * (Math.PI / 180d);
        public static double ToDegrees(double radians) => radians * (180d / Math.PI);
    }
}
