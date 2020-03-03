using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OLC1_Proyecto1
{
    public class AFN
    {
        Estado EstadoInicial;
        Estado EstadoFinal;

        public AFN()
        {
            EstadoInicial= new Estado();
            EstadoFinal = new Estado();
        }

        public void setEstadoInicial(Estado arg1)
        {
            this.EstadoInicial = arg1;
        }

        public Estado getEstadoInicial()
        {
            return this.EstadoInicial;
        }

        public void setEstadoFinal(Estado arg1)
        {
            this.EstadoFinal = arg1;
        }

        public Estado getEstadoFinal()
        {
            return this.EstadoFinal;
        }

        public void createBasicAFN(int arg1)
        {
            Transicion TempTransicion = new Transicion();
            EstadoInicial.setID(Estado.Contador++);
            EstadoFinal.setID(Estado.Contador++);
            TempTransicion.setIDTerminal(arg1);
            TempTransicion.setDestino(EstadoFinal);
            EstadoInicial.addTransicion(TempTransicion);
        }

        public void createConcatenacionAFN(AFN AFN1, AFN AFN2)
        {
            EstadoInicial = AFN1.getEstadoInicial();
            EstadoFinal = AFN2.getEstadoFinal();

            //SE COMBINAN ESTADO FINAL DE AFN1 CON ESTADO INICIAL DE AFN2   
            Estado TempEstado = new Estado();
            TempEstado.setID(Nodo.Contador++);
            foreach (Transicion TempTransicion in AFN1.getEstadoFinal().getTransiciones())
            {
                TempEstado.addTransicion(TempTransicion);
            }
            foreach (Transicion TempTransicion in AFN2.getEstadoInicial().getTransiciones())
            {
                TempEstado.addTransicion(TempTransicion);
            }
            AFN1.setEstadoFinal(TempEstado);
            AFN2.setEstadoInicial(TempEstado);

        }

        public void createKleeneAFN(AFN AFN1)
        {
            Transicion TempTransicion;
            EstadoInicial.setID(Estado.Contador++);
            EstadoFinal.setID(Estado.Contador++);
            //TRANSICION CON EPSILON DESDE ESTADO INICIAL HACIA ESTADO FINAL
            TempTransicion = new Transicion();
            TempTransicion.setIDTerminal(-1);
            TempTransicion.setDestino(EstadoFinal);
            EstadoInicial.addTransicion(TempTransicion);
            //TRANSICION CON EPSILON DESDE ESTADO INICIAL HACIA ESTADO INICIAL DE AFN1 
            TempTransicion = new Transicion();
            TempTransicion.setIDTerminal(-1);
            TempTransicion.setDestino(AFN1.getEstadoInicial());
            EstadoInicial.addTransicion(TempTransicion);
            //TRANSICION CON EPSILON DESDE ESTADO FINAL DE AFN1 HACIA ESTADO INICIAL DE AFN1
            TempTransicion = new Transicion();
            TempTransicion.setIDTerminal(-1);
            TempTransicion.setDestino(AFN1.getEstadoInicial());
            AFN1.getEstadoFinal().addTransicion(TempTransicion);
            //TRANSICION CON EPSILON DESDE ESTADO FINAL DE AFN1 HACIA ESTADO FINAL
            TempTransicion = new Transicion();
            TempTransicion.setIDTerminal(-1);
            TempTransicion.setDestino(EstadoFinal);
            AFN1.getEstadoFinal().addTransicion(TempTransicion);
        }
        public void createAlternanciaAFN(AFN AFN1, AFN AFN2)
        {
            Transicion TempTransicion;
            EstadoInicial.setID(Estado.Contador++);
            EstadoFinal.setID(Estado.Contador++);
            //TRANSICION CON EPSILON DESDE ESTADO INICIAL HACIA ESTADO INICIAL DE AFN1
            TempTransicion = new Transicion();
            TempTransicion.setIDTerminal(-1);
            TempTransicion.setDestino(AFN1.getEstadoInicial());
            EstadoInicial.addTransicion(TempTransicion);
            //TRANSICION CON EPSILON DESDE ESTADO INICIAL HACIA ESTADO INICIAL DE AFN2
            TempTransicion = new Transicion();
            TempTransicion.setIDTerminal(-1);
            TempTransicion.setDestino(AFN2.getEstadoInicial());
            EstadoInicial.addTransicion(TempTransicion);
            //TRANSICION CON EPSILON DESDE ESTADO FINAL DE AFN1 HACIA ESTADO FINAL
            TempTransicion = new Transicion();
            TempTransicion.setIDTerminal(-1);
            TempTransicion.setDestino(EstadoFinal);
            AFN1.getEstadoFinal().addTransicion(TempTransicion);
            //TRANSICION CON EPSILON DESDE ESTADO FINAL DE AFN2 HACIA ESTADO FINAL
            TempTransicion = new Transicion();
            TempTransicion.setIDTerminal(-1);
            TempTransicion.setDestino(EstadoFinal);
            AFN2.getEstadoFinal().addTransicion(TempTransicion);
        }

    }
}
