using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OLC1_Proyecto1
{
    public class Nodo
    {
        public enum TipoNodo
        {
            TERMINAL,
            KLEENE,
            POSITIVA,
            ALTERNANCIA,
            CONCATENACION,
            UNAOCERO,
            AFN
        }

        private int ID;
        private int ID2;
        private String Terminal;
        private Conjunto Conjunto;
        private TipoNodo Tipo;
        private AFN Automata;

        public static int Contador = 1;
        public static int Contador2 = 1;



        public Nodo()
        {

        }

        public void setConjunto(String ID, LinkedList<Conjunto> arg2)
        {

            for (int i = 0; i <= arg2.Count - 1; i++)
            {

                if (arg2.ElementAt(i).getID().Equals(ID))
                {
                    this.Conjunto = arg2.ElementAt(i);
                    break;
                }
            }

        }

        public Conjunto getConjunto()
        {
            return this.Conjunto;
        }

        public void setTipo(TipoNodo arg1)
        {
            Tipo = arg1;
        }
  

        public TipoNodo getTipo()
        {
            return this.Tipo;
        }

        public void setAFN(AFN arg1)
        {
            this.Automata = arg1;
            this.Tipo = TipoNodo.AFN;
        }

        public AFN getAFN()
        {
            return this.Automata;
        }


        public void setID(int arg1)
        {
            this.ID = arg1;
            Nodo.Contador++;
        }

        public int getID()
        {
            return this.ID;
        }

        public void setID2(int arg1)
        {
            this.ID2 = arg1;
            Nodo.Contador2++;
        }

        public int getID2()
        {
            return this.ID2;
        }

        public void setTerminal(String arg1)
        {
            this.Terminal = arg1;
        }

        public String getTerminal()
        {
            return this.Terminal;
        }

        public void printNodo()
        {
            if (this.Tipo == TipoNodo.TERMINAL)
            {
                Console.Out.Write("Tipo : Terminal - ID : [" + this.ID + "--" + this.Terminal + "]");

            }
            else if (this.Tipo == TipoNodo.KLEENE)
            {
                Console.Out.Write("Tipo : KLEENE ");

            }
            else if (this.Tipo == TipoNodo.POSITIVA)
            {
                Console.Out.Write("Tipo : POSITIVA ");
            }
            else if (this.Tipo == TipoNodo.ALTERNANCIA)
            {
                Console.Out.Write("Tipo : ALTERNANCIA ");
            }
            else if (this.Tipo == TipoNodo.CONCATENACION)
            {
                Console.Out.Write("Tipo : CONCATENACION ");
            }
            else if (this.Tipo == TipoNodo.UNAOCERO)
            {
                Console.Out.Write("Tipo : UNAOCERO ");
            }

        }


        //Testea el caracter en el Nodo
        public Boolean testChar(String arg1)
        {


            //SI ES UN TERMINAL NORMAL
            if (this.getConjunto() == null)
            {
                //VALIDAR UN STRING
                if (this.Terminal.Length > 1)
                {
                    if (this.Terminal.Equals(arg1))
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }

                //SI NO VALIDAR UN CARACTER
                else if (this.Terminal[0] == arg1[0])
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            //PROBAR EN CONJUNTO
            else
            {
                if (this.getConjunto().testChar(arg1[0]))
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
}
