﻿using System;
using System.Windows.Forms;
using GraphAlgorithmVisualizer.Algorithms;

namespace GraphAlgorithmVisualizer
{
    internal static class Program
    {
        /// <summary>
        /// Główny punkt wejścia dla aplikacji.
        /// </summary>
        [STAThread]
        static void Main()
        {
            //Application.EnableVisualStyles();
            //Application.SetCompatibleTextRenderingDefault(false);
            //Application.Run(new Form1());
            //AlgorithmTests.DFSTest();
            AlgorithmTests.DjikstraTest();
        }
    }
}
