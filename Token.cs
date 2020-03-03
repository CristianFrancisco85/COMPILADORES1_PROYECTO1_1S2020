using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OLC1_Proyecto1
{

    
    public class Token
    {
        public enum TipoToken
        {
            ABRE_LLAVE,
            CIERRA_LLAVE,
            PORCENTAJE,
            GUION_CURVO,
            GUION,
            PUNTO,
            SIGNO_MAYOR,
            SIGNO_ASTERISCO,
            SIGNO_MAS,
            SIGNO_ALTERNANCIA,
            SIGNO_INTERROGACION,
            PUNTO_COMA,
            COMA,
            DOS_PUNTOS,
            ID,
            CADENA,
            COMENTARIO,
            ERROR
        }

        String Lexema;
        int ID;
        TipoToken Tipo;

        //Constructor
        public Token()
        {
            
        }

        public Token(String Lexema , int ID , TipoToken tipoToken)
        {

        }

        public void setID(int arg1)
        {
            this.ID = arg1;
        }

        public void setTipo(TipoToken tipo)
        {
            this.Tipo = tipo;
        }

        public TipoToken getTipo()
        {
            return this.Tipo;
        }

        public void setLexema(String lexema)
        {
            this.Lexema = lexema;
        }

        public String getLexema()
        {
            return this.Lexema;
        }


        

    }

   
}
