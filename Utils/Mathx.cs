using System;

namespace GraphAlgorithmVisualizer.Utils
{
    internal class Mathx
    {
        public static double ToRadians(double degrees) => degrees * (Math.PI / 180d);
        public static double ToDegrees(double radians) => radians * (180d / Math.PI);
    }
}
