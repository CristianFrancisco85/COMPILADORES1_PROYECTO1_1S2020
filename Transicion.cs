using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OLC1_Proyecto1
{
    public class Transicion : ICloneable
    {
        private int IDTerminal;
        private String TerminalAFD;
        private Estado Destino;

        public Transicion()
        {

        }
        Transicion(int ID)
        {
            this.IDTerminal = ID;
        }
        Transicion(int ID, Estado Dest)
        {
            this.IDTerminal = ID;
            this.Destino = Dest;
        }

        public void setDestino(Estado arg1)
        {
            this.Destino = arg1;
        }

        public Estado getDestino()
        {
            return this.Destino;
        }

        public void setIDTerminal(int arg1)
        {
            this.IDTerminal = arg1;
        }

        public int getIDTerminal()
        {
            return this.IDTerminal;
        }

        public void setTerminalAFD(String arg1)
        {
            this.TerminalAFD = arg1;
        }

        public String getTerminalAFD()
        {
            return this.TerminalAFD;
        }

        public object Clone()
        {
            return MemberwiseClone();
        }
    }
}
