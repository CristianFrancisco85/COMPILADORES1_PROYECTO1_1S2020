using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OLC1_Proyecto1
{
    public partial class MenuPrincipal : Form
    {
        Scanner MainScanner = new Scanner();
        public MenuPrincipal()
        {
            InitializeComponent();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            MainScanner.ScanText(codeTxt);
            MainScanner.analizeTokens();
            MainScanner.analizeExpresiones();
        }
    }
}
