using Practica1LF_AnalizadorLexico;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
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
            Program.RutasAFD.Clear();
            Program.RutasAFN.Clear();
            MainScanner.ScanText(ActualTxtCodigo);
            if (MainScanner.Errores)
            {
                MessageBox.Show("Se encontraron Errores Lexicos", "Grafico", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                MainScanner.reporteErrores();
            }
            else
            {
                MainScanner.analizeTokens();
                MainScanner.analizeExpresiones();
                NumImagen = Program.RutasAFN.Count;
                NumImagen = NumImagen + Program.RutasAFD.Count;
                ApuntadorImagen = 0;
                automataPictureBox.Image = Image.FromFile(Program.RutasAFN.ElementAt(0));
                ActualizarTablaTransiciones(ApuntadorImagen, true);
            }
            
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
                    ActualizarTablaTransiciones(ApuntadorImagen,true);
                }
                else
                {
                    automataPictureBox.Image = Image.FromFile(Program.RutasAFD.ElementAt(ApuntadorImagen - Program.RutasAFN.Count));
                    ActualizarTablaTransiciones(ApuntadorImagen, false);
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
                    ActualizarTablaTransiciones(ApuntadorImagen, true);
                }
                else
                {
                    automataPictureBox.Image = Image.FromFile(Program.RutasAFD.ElementAt(ApuntadorImagen - Program.RutasAFN.Count));
                    ActualizarTablaTransiciones(ApuntadorImagen, false);
                }
            }
        }
        //FUENTE TRUE SI ES AFN
        private void ActualizarTablaTransiciones(int Apuntador,bool Fuente)
        {
            dataGridView1.Rows.Clear();
            dataGridView1.Columns.Clear();
            dataGridView1.ForeColor = Color.Black;
            if (Fuente)
            {
                Regex TempRegex = MainScanner.Expresiones.ElementAt(Apuntador);
                dataGridView1.Columns.Add("Estado", "Estado");
                foreach (String auxString in TempRegex.Alfabeto){
                    dataGridView1.Columns.Add(auxString,auxString);
                }
                dataGridView1.Columns.Add("Epsilon", "Epsilon");
                foreach (Estado auxEstado in TempRegex.EstadosAFN )
                {
                    int rowIndex = this.dataGridView1.Rows.Add();
                    var row = this.dataGridView1.Rows[rowIndex];
                    row.Cells["Estado"].Value = auxEstado.getID().ToString();
                    foreach (Transicion auxTransicion in auxEstado.getTransiciones())
                    {
                        if (auxTransicion.getIDTerminal()==-1)
                        {
                            row.Cells["Epsilon"].Value = auxTransicion.getDestino().getID();
                        }
                        else
                        {
                            row.Cells[auxTransicion.getIDTerminal()].Value = auxTransicion.getDestino().getID().ToString();
                        }
                        
                    }
                }
            }
            else
            {
                Regex TempRegex =  MainScanner.Expresiones.ElementAt(Apuntador-Program.RutasAFN.Count);
                dataGridView1.Columns.Add("Estado", "Estado");
                foreach (String auxString in TempRegex.Alfabeto)
                {
                    dataGridView1.Columns.Add(auxString, auxString);
                }
                foreach (Estado auxEstado in TempRegex.EstadosAFD)
                {
                    int rowIndex = this.dataGridView1.Rows.Add();
                    var row = this.dataGridView1.Rows[rowIndex];
                    row.Cells["Estado"].Value = auxEstado.getID().ToString();
                    foreach (Transicion auxTransicion in auxEstado.getTransiciones())
                    {
                        row.Cells[auxTransicion.getTerminalAFD()].Value = auxTransicion.getDestino().getID().ToString();

                    }
                }
            }
        }

        private void AbrirBtn_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            { 
                tabControl1.SelectedTab.Text = openFileDialog1.SafeFileName;
                ActualTxtCodigo.Text = File.ReadAllText(openFileDialog1.FileName);
            }
        }

        private void GuardarBtn_Click(object sender, EventArgs e)
        {
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                FileStream MyStream = new FileStream(saveFileDialog1.FileName, FileMode.Create, FileAccess.Write, FileShare.None);
                StreamWriter MyWriter = new StreamWriter(MyStream);
                MyWriter.Write(ActualTxtCodigo.Text);
                MyWriter.Close();
                MyStream.Close();
                MessageBox.Show("Guardado Correctamente", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            
        }
    }
}
