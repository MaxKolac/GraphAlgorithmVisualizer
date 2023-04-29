using System;
using System.Windows.Forms;
using GraphAlgorithmVisualizer.Forms;

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
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainForm());
            //Application.Run(new TestForm());
        }
    }
}
