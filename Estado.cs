using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OLC1_Proyecto1
{
    public class Estado : ICloneable
    {
        private int ID;
        private LinkedList<int> TerminalesID;
        private Boolean EstadoAceptacion;
        private LinkedList<Transicion> ListaTransiciones;
        private LinkedList<Estado> ListaEstados;

        public static int Contador = 0;

        public Estado()
        {
            TerminalesID = new LinkedList<int>();
            ListaTransiciones = new LinkedList<Transicion>();
            ListaEstados = new LinkedList<Estado>();
            EstadoAceptacion = false;
        }

        public int getID()
        {
            return this.ID;
        }
        public void setID(int arg1)
        {
            this.ID = arg1;
        }

        public void setAceptacion()
        {
            this.EstadoAceptacion = true;
        }

        public Boolean getAceptacion()
        {
            return this.EstadoAceptacion;
        }

        public void addTerminal(int arg1)
        {
            if (!this.TerminalesID.Contains(arg1))
            {
                this.TerminalesID.AddLast(arg1);
            }
        }

        public void addTerminal(LinkedList<int> arg1)
        {
            LinkedList<int> TempList = arg1;
            foreach (int num in TempList)
            {
                if (!this.TerminalesID.Contains(num))
                {
                    this.TerminalesID.AddLast(num);
                }
            }

        }

        public void addTransicion(Transicion arg1)
        {
            this.ListaTransiciones.AddLast(arg1);
        }

        public LinkedList<Transicion> getTransiciones()
        {
            return this.ListaTransiciones;
        }

        public void addEstadoAFN(Estado arg1)
        {
            this.ListaEstados.AddLast(arg1);
        }

        public LinkedList<Estado> getEstadosAFN()
        {
            return this.ListaEstados;
        }

        public Boolean compareEstadosAFN(Estado arg1)
        {

            if (this.getEstadosAFN().Count == arg1.getEstadosAFN().Count)
            {
                LinkedList<Estado> TempEstados = this.getEstadosAFN();
                foreach (Estado AuxEstado in TempEstados)
                {
                    if (!arg1.getEstadosAFN().Contains(AuxEstado))
                    {
                        return false;
                    }
                }
                return true;
            }
            else
            {
                return false;
            }
        }


        public LinkedList<int> getTerminales()
        {
            return this.TerminalesID;
        }

        public Boolean compareEstado(Estado arg1)
        {

            if (this.getTerminales().Count == arg1.getTerminales().Count)
            {
                LinkedList<int> TempTerminales = this.getTerminales();
                foreach (int ID in TempTerminales)
                {
                    if (!arg1.getTerminales().Contains(ID))
                    {
                        return false;
                    }
                }
                return true;
            }
            else
            {
                return false;
            }
        }


        //REGRESA -100 SI NO HAY TRANSICION , DE NO SER ASI REGRESA ID DEL ESTADO DESTINO
        public int testChar(String arg1, LinkedList<Nodo> ListaNodos, LinkedList<Estado> Estados)
        {

            Nodo TempNodo;
            Estado TempEstado;
            int EstadoID = 0;
            int Largo;
            int TransicionesSize = this.ListaTransiciones.Count;
            String Lexema;
            Boolean Validacion;
            Transicion TempTransicion;

            //BUSCA SI EXISTE UNA TRANSICION PARA EL LEXEMA
            for (int i = 0; i < TransicionesSize; i++)
            {

                //SE OBTIENE LA TRANSICION i DEL ESTADO ACTUAL
                TempEstado = Estados.ElementAt(EstadoID);
                TempTransicion = TempEstado.getTransiciones().ElementAt(i);
                //OBTIENE NODO TERMINAL DE LA TRANSICION
                TempNodo = TempEstado.getNodoTerminal(ListaNodos, TempTransicion.getIDTerminal());
                //VERIFICAR SI VA VALIDAR UN TERMINAL O CONJUNTO
                if (TempNodo.getConjunto() == null)
                {
                    //SI SE VALIDA UN TERMINAL VALIDAR CUANTOS CARACTERES NECESITA                
                    Largo = TempNodo.getTerminal().Length;
                    if (Largo > 1)
                    {
                        //SE VALIDA QUE HAYA LA CANTIDAD DE CARACTERES REQUERIDOS
                        if (Largo <= arg1.Length)
                        {
                            Lexema = arg1.Substring(0, Largo);
                        }
                        else
                        {
                            //SI NO RETORNAR ESTADOID -1
                            return -1;
                        }
                    }
                    else
                    {
                        Lexema = Char.ToString(arg1[0]);
                    }
                }
                else
                {
                    //SI NO VALIDAR UN SOLO CARACTER
                    Lexema = Char.ToString(arg1[0]);
                }

                //SE VALIDA EN EL NODO TERMINAL DE LA TRANSICION
                Validacion = TempNodo.testChar(Lexema);

                //SI LA TRANSICION LO ACEPTA , ACTUALIZAR NODO,TRANSICIONES Y Lexema
                if (Validacion)
                {
                    i = -1;
                    EstadoID = TempTransicion.getDestino().getID();
                    TransicionesSize = Estados.ElementAt(EstadoID).getTransiciones().Count;

                    //SE VERIFICA SI LA CADENA QUEDARA VACIA
                    if (Lexema.Length == arg1.Length)
                    {
                        return EstadoID;
                    }
                    //SI SE ACEPTO UNA CADENA 
                    else if (Lexema.Length > 1)
                    {
                        arg1 = arg1.Substring(Lexema.Length, arg1.Length);
                    }
                    //SI SE VALIDO UN CARACTER
                    else
                    {
                        arg1 = arg1.Substring(1, arg1.Length);
                    }

                }
                //SI NO SEGUIR ITERANDO EN LA TRANSICIONES            

            }
            //NO EXISTE TRANSICION EN EL ESTADO PARA EL LEXEMA
            if (arg1.Length != 0)
            {
                return -1;
            }
            return EstadoID;
        }

        //REGRESA NODO CON EL ID INDICADO
        public Nodo getNodoTerminal(LinkedList<Nodo> ListaNodos, int ID)
        {
            for (int i = 0; i < ListaNodos.Count; i++)
            {
                if (ListaNodos.ElementAt(i).getID() == ID)
                {
                    return ListaNodos.ElementAt(i);
                }
            }
            return null;
        }

        public object Clone()
        {
            return MemberwiseClone();
        }
    }
}