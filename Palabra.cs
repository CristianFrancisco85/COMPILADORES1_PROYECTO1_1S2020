using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OLC1_Proyecto1
{
    class Palabra
    {
        private String ID;
        private String Lexema;

        public void setLexema(String arg1)
        {
            this.Lexema = arg1;
        }

        public void setID(String arg1)
        {
            this.ID = arg1;
        }

        public String getID()
        {
            return this.ID;
        }

        public String getLexema()
        {
            return this.Lexema;
        }
    }
}
