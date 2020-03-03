﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OLC1_Proyecto1
{
    public class Transicion
    {
        private int IDTerminal;
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
    }
}
