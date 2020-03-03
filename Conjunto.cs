using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OLC1_Proyecto1
{
    public class Conjunto
    {

        private String ID;
        private int BeginInterval;
        private int EndInterval;
        private LinkedList<int> CharList;

        public Conjunto()
        {
            this.BeginInterval = -1;
            this.EndInterval = -1;
            this.CharList = new LinkedList<int>();
        }

        public void setID(String arg1)
        {
            this.ID = arg1;
        }

        public String getID()
        {
            return this.ID;
        }

        public void setBeginInterval(String arg1)
        {
            this.BeginInterval = (int)arg1[0];
        }

        public int getBeginInterval()
        {
            return this.BeginInterval;
        }

        public void setEndInterval(String arg1)
        {
            this.EndInterval = (int)arg1[0];
        }

        public int getEndInterval()
        {
            return this.EndInterval;
        }

        public void addCharToList(char arg1)
        {
            this.CharList.AddLast((int)arg1);
        }

        public LinkedList<int> getCharList()
        {
            return this.CharList;
        }

        public Boolean testChar(char arg1)
        {
            //PROBAR EN INTERVALO
            if (this.BeginInterval != -1)
            {
                if ((int)arg1 >= this.BeginInterval && (int)arg1 <= this.EndInterval)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            //PROBAR EN LISTA DE CARACTERES
            else
            {
                if (this.CharList.Contains((int)arg1))
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
