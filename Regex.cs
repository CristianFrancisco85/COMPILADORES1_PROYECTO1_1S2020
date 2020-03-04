using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OLC1_Proyecto1
{
    class Regex
    {
        private String ID;
        private LinkedList<Nodo> Nodos = new LinkedList<Nodo>();
        private LinkedList<Estado> Estados = new LinkedList<Estado>();
        private LinkedList<String> RutasAFN = new LinkedList<String>();
        AFN RegexAFN;

        public void setID(String arg1)
        {
            this.ID = arg1;
        }

        public String getID()
        {
            return this.ID;
        }

        public void addNodo(Nodo arg1)
        {
            this.Nodos.AddLast(arg1);
        }

        public LinkedList<Nodo> getNodos()
        {
            return this.Nodos;
        }

        public void createRegexAFN()
        {
            LinkedList<Nodo> TempNodos = new LinkedList<Nodo>(Nodos);
            // SE CREAN LOS AFN's BASICOS PARA TERMINALES
            foreach (Nodo AuxNodo in TempNodos)
            {
                if (AuxNodo.getTipo()==Nodo.TipoNodo.TERMINAL)
                {
                    AFN TempAFN = new AFN();
                    TempAFN.createBasicAFN(AuxNodo.getID(), Estados);
                    AuxNodo.setAFN(TempAFN);                   
                }
            }
           
            Nodo TempNodo;
            Nodo AuxNodo1;
            Nodo AuxNodo2;
            Nodo NewNodo;
            AFN NewAFN;
            //SE BUSCA EL PATRON OB-AFN-AFN o OU-AFN Y SE OPERAN LOS AFN's
            Console.Write("ENTRO CON SIZE DE ");
            Console.WriteLine(TempNodos.Count);
            while (TempNodos.Count > 1)
            {              
                for (int i = 0 ; i < TempNodos.Count;i++)
                {
                    NewNodo = new Nodo();
                    NewNodo.setTipo(Nodo.TipoNodo.AFN);
                    NewAFN = new AFN();
                    TempNodo = TempNodos.ElementAt(i);

                    if (TempNodo.getTipo() != Nodo.TipoNodo.AFN)
                    {
                        switch (TempNodo.getTipo()) {

                            case Nodo.TipoNodo.ALTERNANCIA:
                                AuxNodo1 = TempNodos.ElementAt(i + 1);
                                AuxNodo2 = TempNodos.ElementAt(i + 2);
                                if (AuxNodo1.getTipo()==Nodo.TipoNodo.AFN && AuxNodo2.getTipo() == Nodo.TipoNodo.AFN)
                                {
                                    NewAFN.createAlternanciaAFN(AuxNodo1.getAFN(),AuxNodo2.getAFN(), Estados);
                                    NewNodo.setAFN(NewAFN);
                                    TempNodos.Remove(AuxNodo1);
                                    TempNodos.Remove(AuxNodo2);
                                    TempNodos.Find(TempNodo).Value = NewNodo;
                                    i = TempNodos.Count;
                                }
                                break;
                            case Nodo.TipoNodo.CONCATENACION:
                                AuxNodo1 = TempNodos.ElementAt(i + 1);
                                AuxNodo2 = TempNodos.ElementAt(i + 2);
                                if (AuxNodo1.getTipo() == Nodo.TipoNodo.AFN && AuxNodo2.getTipo() == Nodo.TipoNodo.AFN)
                                {
                                    NewAFN.createConcatenacionAFN(AuxNodo1.getAFN(), AuxNodo2.getAFN(), Estados);
                                    NewNodo.setAFN(NewAFN);
                                    TempNodos.Remove(AuxNodo1);
                                    TempNodos.Remove(AuxNodo2);
                                    TempNodos.Find(TempNodo).Value = NewNodo;
                                    i = TempNodos.Count;
                                }
                                break;
                            case Nodo.TipoNodo.KLEENE:
                                AuxNodo1 = TempNodos.ElementAt(i + 1);
                                if (AuxNodo1.getTipo() == Nodo.TipoNodo.AFN)
                                {
                                    NewAFN.createKleeneAFN(AuxNodo1.getAFN(), Estados);
                                    NewNodo.setAFN(NewAFN);
                                    TempNodos.Remove(AuxNodo1);
                                    TempNodos.Find(TempNodo).Value = NewNodo;
                                    i = TempNodos.Count;
                                }
                                break;
                            case Nodo.TipoNodo.POSITIVA:
                                AuxNodo1 = TempNodos.ElementAt(i + 1);
                                if (AuxNodo1.getTipo() == Nodo.TipoNodo.AFN)
                                {
                                    NewAFN.createPositivaAFN(AuxNodo1.getAFN(), Estados);
                                    NewNodo.setAFN(NewAFN);
                                    TempNodos.Remove(AuxNodo1);
                                    TempNodos.Find(TempNodo).Value = NewNodo;
                                    i = TempNodos.Count;
                                }
                                break;
                            case Nodo.TipoNodo.UNAOCERO:
                                AuxNodo1 = TempNodos.ElementAt(i + 1);
                                if (AuxNodo1.getTipo() == Nodo.TipoNodo.AFN)
                                {
                                    NewAFN.createUnaOCeroAFN(AuxNodo1.getAFN(), Estados);
                                    NewNodo.setAFN(NewAFN);
                                    TempNodos.Remove(AuxNodo1);
                                    TempNodos.Find(TempNodo).Value = NewNodo;
                                    i = TempNodos.Count;
                                }
                                break;
                        }
                        
                    }
                }
            }
            Console.Write("SALIO CON SIZE DE ");
            Console.WriteLine(TempNodos.Count);
            RegexAFN = TempNodos.ElementAt(0).getAFN();
            Estado.Contador = 0;
        }

        public void graphAFN()
        {
            SaveFileDialog saveFile = new SaveFileDialog();
            saveFile.Filter = "Archivo DOT (*.dot)|*.dot";
            saveFile.DefaultExt = "dot";
            saveFile.AddExtension = true;

            saveFile.Title = "Guardar Grafico";
            if (saveFile.ShowDialog() == DialogResult.OK)
            {
                FileStream MyStream = new FileStream(saveFile.FileName, FileMode.Create, FileAccess.Write, FileShare.None);
                StreamWriter MyWriter = new StreamWriter(MyStream);
                MyWriter.WriteLine("digraph G {");
                MyWriter.WriteLine("rankdir = LR;");
                
                foreach (Estado TempEstado in Estados)
                {
                    foreach (Transicion TempTransicion in TempEstado.getTransiciones())
                    {
                        //FORMA a -> b [label="TerminalString"];
                        MyWriter.WriteLine(TempEstado.getID()+"->"+ TempTransicion.getDestino().getID() + " [label=\"" + getTerminalString(TempTransicion.getIDTerminal()) + "\"];");
                    }
                }
                MyWriter.WriteLine("}");
                MyWriter.Close();
                MyStream.Close();
                MessageBox.Show("Guardado Correctamente", "Grafico", MessageBoxButtons.OK, MessageBoxIcon.Information);

                //SE MANDO COMANDO AL SHELL DEL SISTEMA 
                String RutaImg = Path.GetDirectoryName(saveFile.FileName) + "\\" + Path.GetFileNameWithoutExtension(saveFile.FileName);
                String Command = "dot.exe -Tpng " + saveFile.FileName + " -o " + RutaImg + ".png";
                Process cmd = new Process();
                cmd.StartInfo.FileName = "cmd.exe";
                cmd.StartInfo.RedirectStandardInput = true;
                cmd.StartInfo.RedirectStandardOutput = true;
                cmd.StartInfo.CreateNoWindow = false;
                cmd.StartInfo.UseShellExecute = false;
                cmd.Start();
                cmd.StandardInput.WriteLine(Command);
                cmd.StandardInput.Flush();
                cmd.StandardInput.Close();
                cmd.WaitForExit();
                Console.WriteLine(cmd.StandardOutput.ReadToEnd());
                Console.Read();

            }
        }


        public String getTerminalString(int arg1)
        {
            foreach (Nodo TempNodo in Nodos)
            {
                if (TempNodo.getTipo() == Nodo.TipoNodo.AFN)
                {
                    if (TempNodo.getID() == arg1)
                    {
                        return TempNodo.getTerminal();
                    }
                }
            }
            return "Eps.";
        }

        public int existeEstado(Estado TempEstado)
        {
            for (int i = 0; i < this.Estados.Count; i++)
            {
                Estado AuxEstado = this.Estados.ElementAt(i);
                if (AuxEstado.compareEstado(TempEstado))
                {
                    return i;
                }
            }
            return -1;
        }

        public Boolean TestLexema(String arg1)
        {
            int EstadoID = 0;
            EstadoID = this.Estados.ElementAt(EstadoID).testChar(arg1, this.Nodos, this.Estados);
            if (EstadoID == -1)
            {
                return false;
            }
            else if (this.Estados.ElementAt(EstadoID).getAceptacion())
            {
                return true;
            }
            else
            {
                return false;
            }

        }

    }
}
