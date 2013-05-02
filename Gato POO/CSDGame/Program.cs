using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace CSDGame
{
    static class Program
    {
        /// <summary>
        /// El punto de entrada principal de la aplicacion.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    }
}
