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

        public void createBasicAFN(int arg1, LinkedList<Estado> Estados)
        {
            Transicion TempTransicion = new Transicion();
            EstadoInicial.setID(Estado.Contador++);
            EstadoFinal.setID(Estado.Contador++);
            TempTransicion.setIDTerminal(arg1);
            TempTransicion.setDestino(EstadoFinal);
            EstadoInicial.addTransicion(TempTransicion);
            Estados.AddLast(EstadoInicial);
            Estados.AddLast(EstadoFinal);
        }

        public void createConcatenacionAFN(AFN AFN1, AFN AFN2, LinkedList<Estado> Estados)
        {
            EstadoInicial = AFN1.getEstadoInicial();
            EstadoFinal = AFN2.getEstadoFinal();

            //SE COMBINAN ESTADO FINAL DE AFN1 CON ESTADO INICIAL DE AFN2   
            Estado TempEstado = new Estado();
            TempEstado.setID(Nodo.Contador++);
            //TRANSICIONES ENTRANTES
            foreach (Estado AuxEstado in Estados)
            {
                foreach (Transicion TempTransicion in AuxEstado.getTransiciones())
                {
                    if (TempTransicion.getDestino() == AFN1.getEstadoFinal() || TempTransicion.getDestino() == AFN2.getEstadoInicial() )
                    {
                        TempTransicion.setDestino(TempEstado);

                    }
                }
            }
            //TRANSICIONES SALIENTES
            foreach (Transicion TempTransicion in AFN1.getEstadoFinal().getTransiciones())
            {
                TempEstado.addTransicion((Transicion)TempTransicion.Clone());
            }
            foreach (Transicion TempTransicion in AFN2.getEstadoInicial().getTransiciones())
            {
                TempEstado.addTransicion((Transicion)TempTransicion.Clone());
            }

            //SE AÑADE NUEVO ESTADO Y SE ELIMINAN LOS DOS USADOS PARA EL NUEVO ESTADO   
            Estados.Remove(AFN1.getEstadoFinal());
            Estados.Remove(AFN2.getEstadoInicial());
            Estados.AddLast(TempEstado);
            AFN1.setEstadoFinal(TempEstado);
            AFN2.setEstadoInicial(TempEstado);
        }

        public void createKleeneAFN(AFN AFN1, LinkedList<Estado> Estados)
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
            //SE AGREGAN ESTADOS NUEVOS
            Estados.AddLast(EstadoInicial);
            Estados.AddLast(EstadoFinal);
        }

        public void createAlternanciaAFN(AFN AFN1, AFN AFN2, LinkedList<Estado> Estados)
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
            //SE AGREGAN ESTADOS NUEVOS
            Estados.AddLast(EstadoInicial);
            Estados.AddLast(EstadoFinal);
        }

        public void createPositivaAFN(AFN AFN1, LinkedList<Estado> Estados)
        {

            Transicion TempTransicion;
            EstadoInicial.setID(Estado.Contador++);
            EstadoFinal.setID(Estado.Contador++);
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
            //SE AGREGAN ESTADOS NUEVOS
            Estados.AddLast(EstadoInicial);
            Estados.AddLast(EstadoFinal);
        }

        public void createUnaOCeroAFN (AFN AFN1, LinkedList<Estado> Estados)
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
            //TRANSICION CON EPSILON DESDE ESTADO FINAL DE AFN1 HACIA ESTADO FINAL
            TempTransicion = new Transicion();
            TempTransicion.setIDTerminal(-1);
            TempTransicion.setDestino(EstadoFinal);
            AFN1.getEstadoFinal().addTransicion(TempTransicion);
            //SE AGREGAN ESTADOS NUEVOS
            Estados.AddLast(EstadoInicial);
            Estados.AddLast(EstadoFinal);
        }
    }
}
