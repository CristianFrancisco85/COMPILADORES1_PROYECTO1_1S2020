using Practica1LF_AnalizadorLexico;
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
        Scanner MainScanner;
        int NumImagen;
        int ApuntadorImagen;

        public MenuPrincipal()
        {
            InitializeComponent();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            MainScanner = new Scanner();
            MainScanner.ScanText(ActualTxtCodigo);
            MainScanner.analizeTokens();
            MainScanner.analizeExpresiones();
            NumImagen = Program.RutasAFN.Count;
            NumImagen = NumImagen + Program.RutasAFD.Count;
            ApuntadorImagen = 0;
            automataPictureBox.Image = Image.FromFile(Program.RutasAFN.ElementAt(0));
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            TabPage NewTab = new TabPage();
            TextEditorTabPage TETP = new TextEditorTabPage();
            NewTab.Controls.Add(TETP);
            NewTab.Text = "Pestaña " + (tabControl1.TabCount + 1);
            tabControl1.TabPages.Add(NewTab);
        }

        private RichTextBox ActualTxtCodigo
        {
            get
            {
                RichTextBox aux = new RichTextBox();

                if (tabControl1.SelectedIndex == 0)
                {
                    aux = textEditorTabPage1.TextCodigo;
                }
                else
                {
                    foreach (TextEditorTabPage C in tabControl1.SelectedTab.Controls)
                    {
                        aux = C.TextCodigo;
                    }
                }
                return aux;
            }
        }

        private void AnteriorBtn_Click(object sender, EventArgs e)
        {
            if (ApuntadorImagen > 0)
            {
                ApuntadorImagen--;
                if (ApuntadorImagen == 0 || ApuntadorImagen < Program.RutasAFN.Count)
                {
                    automataPictureBox.Image = Image.FromFile(Program.RutasAFN.ElementAt(ApuntadorImagen));
                }
                else
                {
                    automataPictureBox.Image = Image.FromFile(Program.RutasAFD.ElementAt(ApuntadorImagen - Program.RutasAFN.Count));
                }
            }
        }

        private void SiguienteBtn_Click(object sender, EventArgs e)
        {
            if (ApuntadorImagen < NumImagen-1)
            {
                ApuntadorImagen++;
                if (ApuntadorImagen < Program.RutasAFN.Count)
                {
                    automataPictureBox.Image = Image.FromFile(Program.RutasAFN.ElementAt(ApuntadorImagen));
                }
                else
                {
                    automataPictureBox.Image = Image.FromFile(Program.RutasAFD.ElementAt(ApuntadorImagen - Program.RutasAFN.Count));
                }
            }
        }

        private void ActulizarTablaTransiciones(int Apuntador,bool Fuente)
        {

        }
    }
}
