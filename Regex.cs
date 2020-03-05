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
        private LinkedList<Estado> EstadosAFN = new LinkedList<Estado>();       
        AFN RegexAFN;
        private LinkedList<Estado> EstadosAFD = new LinkedList<Estado>();
        

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
                    TempAFN.createBasicAFN(AuxNodo.getID(), EstadosAFN);
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
                                    NewAFN.createAlternanciaAFN(AuxNodo1.getAFN(),AuxNodo2.getAFN(), EstadosAFN);
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
                                    NewAFN.createConcatenacionAFN(AuxNodo1.getAFN(), AuxNodo2.getAFN(), EstadosAFN);
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
                                    NewAFN.createKleeneAFN(AuxNodo1.getAFN(), EstadosAFN);
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
                                    NewAFN.createPositivaAFN(AuxNodo1.getAFN(), EstadosAFN);
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
                                    NewAFN.createUnaOCeroAFN(AuxNodo1.getAFN(), EstadosAFN);
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
            createSubConjuntos();
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
                MyWriter.WriteLine("digraph G {\n nodesep=0.3;\n ranksep=0.2;\n    margin=0.1;\n   node [shape=circle];\n  edge [arrowsize=0.8];");
                MyWriter.WriteLine("rankdir = LR;");
                
                foreach (Estado TempEstado in EstadosAFN)
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
                MessageBox.Show("AFN Guardado Correctamente", "Grafico", MessageBoxButtons.OK, MessageBoxIcon.Information);

                //SE MANDO COMANDO AL SHELL DEL SISTEMA 
                String RutaImg = Path.GetDirectoryName(saveFile.FileName) + "\\" + Path.GetFileNameWithoutExtension(saveFile.FileName);
                String Command = "dot.exe -Tpng " + saveFile.FileName + " -o " + RutaImg + ".png";
                Program.RutasAFN.AddLast(RutaImg + ".png");
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

        public void cerradura(Estado s, LinkedList<Estado> EstadosRecorridos)
        {
            
            if (!EstadosRecorridos.Contains(s))
            {
                EstadosRecorridos.AddLast(s);
            }

            foreach (Transicion TempTransicion in s.getTransiciones())
            {
                //SI ES UNA TRANSICION CON EPSILON Y ES HACIA UN ESTADO AUN NO VISITADO
                if (TempTransicion.getIDTerminal() == -1 && !EstadosRecorridos.Contains(TempTransicion.getDestino()))
                {
                    EstadosRecorridos.AddLast(TempTransicion.getDestino());
                    cerradura(TempTransicion.getDestino(), EstadosRecorridos);
                }
            }

        }

        public void cerradura(LinkedList<Estado> T, LinkedList<Estado> EstadosRecorridos)
        {
            foreach (Estado s in T)
            {
                if (!EstadosRecorridos.Contains(s))
                {
                    EstadosRecorridos.AddLast(s);
                }
            }

            Estado t;
            int SizeT = T.Count();
            for (int i = 0; i < SizeT; i++)
            {
                t = T.ElementAt(i);
                foreach (Transicion TempTransicion in t.getTransiciones())
                {
                    //SI ES UNA TRANSICION CON EPSILON Y ES HACIA UN ESTADO AUN NO VISITADO
                    if (TempTransicion.getIDTerminal() == -1 && !EstadosRecorridos.Contains(TempTransicion.getDestino()))
                    {
                        EstadosRecorridos.AddLast(TempTransicion.getDestino());
                        cerradura(TempTransicion.getDestino(), EstadosRecorridos);
                    }
                }
                SizeT = T.Count();
            }

        }

        public void mover(LinkedList<Estado> T,String Terminal, LinkedList<Estado> EstadosRecorridos)
        {
            Estado t;
            int SizeT=T.Count();
            for (int i=0;i<SizeT;i++)
            {
                t = T.ElementAt(i);
                foreach (Transicion TempTransicion in t.getTransiciones())
                {
                    //SI ES UNA TRANSICION CON EL TERMINAL Y ES HACIA UN ESTADO AUN NO VISITADO
                    if ( getTerminalString(TempTransicion.getIDTerminal()).Equals(Terminal) && !EstadosRecorridos.Contains(TempTransicion.getDestino()))
                    {
                        EstadosRecorridos.AddLast(TempTransicion.getDestino());
                        mover(EstadosRecorridos, Terminal, EstadosRecorridos);
                    }
                }
                SizeT = T.Count();
            }

        }

        public void createSubConjuntos()
        {
            Estado NewEstadoAFD = new Estado();
            LinkedList<String> Alfabeto = new LinkedList<String>();
            LinkedList<Estado> AuxList;
            cerradura(RegexAFN.getEstadoInicial(), NewEstadoAFD.getEstadosAFN());
            NewEstadoAFD.setID(Estado.Contador++);
            EstadosAFD.AddLast(NewEstadoAFD);

            //SE OBTIENE ALFABETO DE EXPRESION REGULAR
            foreach (Nodo TempNodo in Nodos)
            {
                if (TempNodo.getTipo()==Nodo.TipoNodo.AFN)
                {
                    if (!Alfabeto.Contains(TempNodo.getTerminal()))
                    {
                        Alfabeto.AddLast(TempNodo.getTerminal());
                    }
                }
            }

            Estado TempEstado;
            int SizeEstadoAFD = EstadosAFD.Count();
            for (int i = 0 ; i<SizeEstadoAFD ; i++){
                TempEstado = EstadosAFD.ElementAt(i);
                foreach (String Terminal in Alfabeto)
                {
                    AuxList = new LinkedList<Estado>();
                    NewEstadoAFD = new Estado();
                    Transicion TempTransicion = new Transicion();
                    //SE CREA TRANSICION CON EL TERMINAL
                    TempTransicion.setTerminalAFD(Terminal);
                    
                    //SE HACEN OPERACIONES DE CERRADURA
                    mover(TempEstado.getEstadosAFN(), Terminal, AuxList);
                    cerradura(AuxList,NewEstadoAFD.getEstadosAFN());
                    //SE COMPRUEBA SI SE GENERO UN ESTADO NUEVO
                    Boolean ControlNuevoEstado=false;
                    foreach (Estado AuxEstado in EstadosAFD)
                    {
                        ControlNuevoEstado = AuxEstado.compareEstadosAFN(NewEstadoAFD);
                        //SI ES UN ESTADO VACIO
                        if (NewEstadoAFD.getEstadosAFN().Count==0)
                        {
                            ControlNuevoEstado = true;
                            break;
                        }                     
                        //SI EL ESTADO YA EXISTE SE PONE COMO DESTINO PARA TRANSICION
                        else if (ControlNuevoEstado)
                        {
                            TempTransicion.setDestino(AuxEstado);
                            //SE AGREGA LA TRANSICION A TEMPESTADO
                            TempEstado.addTransicion(TempTransicion);
                            break;
                        }
                    }

                    //SI EL ESTADO NO EXISTE SE AGREGA A LA LISTA Y SE ESTABLECE DESTINO PARA LA TRANSICION
                    if (!ControlNuevoEstado)
                    {
                        NewEstadoAFD.setID(Estado.Contador++);
                        EstadosAFD.AddLast(NewEstadoAFD);
                        TempTransicion.setDestino(NewEstadoAFD);
                        //SE AGREGA LA TRANSICION A TEMPESTADO
                        TempEstado.addTransicion(TempTransicion);
                    }
                    
                }

                SizeEstadoAFD = EstadosAFD.Count();
            }
            
            Console.Write("SALIO");
        }

        public void graphAFD()
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
                MyWriter.WriteLine("digraph G {\n nodesep=0.3;\n ranksep=0.2;\n    margin=0.1;\n   node [shape=circle];\n  edge [arrowsize=0.8];");
                MyWriter.WriteLine("rankdir = LR;");

                foreach (Estado TempEstado in EstadosAFD)
                {
                    foreach (Transicion TempTransicion in TempEstado.getTransiciones())
                    {
                        //FORMA a -> b [label="TerminalString"];
                        MyWriter.WriteLine(TempEstado.getID() + "->" + TempTransicion.getDestino().getID() + " [label=\"" + TempTransicion.getTerminalAFD() + "\"];");
                    }
                }
                MyWriter.WriteLine("}");
                MyWriter.Close();
                MyStream.Close();
                MessageBox.Show("AFD Guardado Correctamente", "Grafico", MessageBoxButtons.OK, MessageBoxIcon.Information);

                //SE MANDO COMANDO AL SHELL DEL SISTEMA 
                String RutaImg = Path.GetDirectoryName(saveFile.FileName) + "\\" + Path.GetFileNameWithoutExtension(saveFile.FileName);
                String Command = "dot.exe -Tpng " + saveFile.FileName + " -o " + RutaImg + ".png";
                Program.RutasAFD.AddLast(RutaImg + ".png");
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
            for (int i = 0; i < this.EstadosAFN.Count; i++)
            {
                Estado AuxEstado = this.EstadosAFN.ElementAt(i);
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
            EstadoID = this.EstadosAFN.ElementAt(EstadoID).testChar(arg1, this.Nodos, this.EstadosAFN);
            if (EstadoID == -1)
            {
                return false;
            }
            else if (this.EstadosAFN.ElementAt(EstadoID).getAceptacion())
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
