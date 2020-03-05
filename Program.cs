using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OLC1_Proyecto1
{
    static class Program
    {
        public static LinkedList<String> RutasAFN = new LinkedList<String>();
        public static LinkedList<String> RutasAFD = new LinkedList<String>();
        /// <summary>
        /// Punto de entrada principal para la aplicación.
        /// </summary>
        /// 

        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MenuPrincipal());
        }
    }
}
