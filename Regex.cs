using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OLC1_Proyecto1
{
    class Regex
    {
        private String ID;
        private LinkedList<Nodo> Nodos = new LinkedList<Nodo>();
        private LinkedList<Estado> Estados = new LinkedList<Estado>();
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
            LinkedList<Nodo> TempNodos = this.Nodos;
            // SE CREAN LOS AFN's BASICOS PARA TERMINALES
            foreach (Nodo AuxNodo in TempNodos)
            {
                if (AuxNodo.getTipo()==Nodo.TipoNodo.TERMINAL)
                {
                    AFN TempAFN = new AFN();
                    TempAFN.createBasicAFN(AuxNodo.getID());
                    AuxNodo.setAFN(TempAFN);
                }
            }
           
            Nodo TempNodo;
            Nodo AuxNodo1;
            Nodo AuxNodo2;
            Nodo NewNodo;
            AFN NewAFN;
            //SE BUSCA EL PATRON OB-AFN-AFN o OU-AFN Y SE OPERAN LOS AFN's
            Console.Write("Entro CON SIZE DE ");
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
                                    NewAFN.createAlternanciaAFN(AuxNodo1.getAFN(),AuxNodo2.getAFN());
                                    NewNodo.setAFN(NewAFN);
                                    TempNodos.Remove(AuxNodo1);
                                    TempNodos.Remove(AuxNodo2);
                                    TempNodos.Find(TempNodo).Value = NewNodo;
                                }
                                break;
                            case Nodo.TipoNodo.CONCATENACION:
                                AuxNodo1 = TempNodos.ElementAt(i + 1);
                                AuxNodo2 = TempNodos.ElementAt(i + 2);
                                if (AuxNodo1.getTipo() == Nodo.TipoNodo.AFN && AuxNodo2.getTipo() == Nodo.TipoNodo.AFN)
                                {
                                    NewAFN.createConcatenacionAFN(AuxNodo1.getAFN(), AuxNodo2.getAFN());
                                    NewNodo.setAFN(NewAFN);
                                    TempNodos.Remove(AuxNodo1);
                                    TempNodos.Remove(AuxNodo2);
                                    TempNodos.Find(TempNodo).Value = NewNodo;
                                }
                                break;
                            case Nodo.TipoNodo.KLEENE:
                                AuxNodo1 = TempNodos.ElementAt(i + 1);
                                if (AuxNodo1.getTipo() == Nodo.TipoNodo.AFN)
                                {
                                    NewAFN.createKleeneAFN(AuxNodo1.getAFN());
                                    NewNodo.setAFN(NewAFN);
                                    TempNodos.Remove(AuxNodo1);
                                    TempNodos.Find(TempNodo).Value = NewNodo;
                                }
                                break;
                            case Nodo.TipoNodo.POSITIVA:
                                AuxNodo1 = TempNodos.ElementAt(i + 1);
                                if (AuxNodo1.getTipo() == Nodo.TipoNodo.AFN)
                                {
                                    AFN AuxAFN = new AFN();
                                    NewAFN.createKleeneAFN(AuxNodo1.getAFN());
                                    AuxAFN.createConcatenacionAFN(AuxNodo1.getAFN(), NewAFN);
                                    NewNodo.setAFN(AuxAFN);
                                    TempNodos.Remove(AuxNodo1);
                                    TempNodos.Find(TempNodo).Value = NewNodo;
                                }
                                break;
                            case Nodo.TipoNodo.UNAOCERO:
                                AuxNodo1 = TempNodos.ElementAt(i + 1);
                                if (AuxNodo1.getTipo() == Nodo.TipoNodo.AFN)
                                {
                                    AFN AuxAFN = new AFN();
                                    NewAFN.createBasicAFN(-1);
                                    AuxAFN.createAlternanciaAFN(AuxNodo1.getAFN(), NewAFN);
                                    NewNodo.setAFN(AuxAFN);
                                    TempNodos.Remove(AuxNodo1);
                                    TempNodos.Find(TempNodo).Value = NewNodo;
                                }
                                break;
                        }
                        
                    }
                }
            }
            Console.Write("SALIO CON SIZE DE ");
            Console.WriteLine(TempNodos.Count);
            RegexAFN = TempNodos.ElementAt(0).getAFN();
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
