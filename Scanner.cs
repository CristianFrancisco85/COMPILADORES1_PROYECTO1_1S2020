using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OLC1_Proyecto1
{
    class Scanner
    {

        LinkedList<Token> ListaTokens = new LinkedList<Token>();
        LinkedList<Token> ListaErrores = new LinkedList<Token>();
        LinkedList<Conjunto> Conjuntos = new LinkedList<Conjunto>();
        LinkedList<Palabra> Palabras = new LinkedList<Palabra>();
        LinkedList<Regex> Expresiones = new LinkedList<Regex>();
        int TokenID = 0; //Para Simbolos
        int ErrorID = 0; //Para Errores

        //Realiza Analisis Lexico y Agrupa Lexemas validos en Tokens
        public void ScanText(RichTextBox Entrada)
        {
            //Guarda valor ASCII
            int MyChar;
            //Cantidad de Caracteres
            int NCaracteres = Entrada.Text.Length;

            for (int i =0; i<NCaracteres; i++)
            {
                MyChar = Entrada.Text[i];

                Token TempToken = new Token();
                String TempLexema = "";

                //PARA SIMBOLOS INDIVIDUALES

                switch (MyChar)
                {
                    case '{':
                        TempToken.setTipo(Token.TipoToken.ABRE_LLAVE);
                        TempToken.setLexema("{");
                        TempToken.setID(TokenID++);
                        ListaTokens.AddLast(TempToken);
                        break;
                    case '}':
                        TempToken.setTipo(Token.TipoToken.CIERRA_LLAVE);
                        TempToken.setLexema("}");
                        TempToken.setID(TokenID++);
                        ListaTokens.AddLast(TempToken);
                        break;
                    case '%':
                        TempToken.setTipo(Token.TipoToken.PORCENTAJE);
                        TempToken.setLexema("%");
                        TempToken.setID(TokenID++);
                        ListaTokens.AddLast(TempToken);
                        break;
                    case '~':
                        TempToken.setTipo(Token.TipoToken.GUION_CURVO);
                        TempToken.setLexema("~");
                        TempToken.setID(TokenID++);
                        ListaTokens.AddLast(TempToken);
                        break;
                    case '-':
                        TempToken.setTipo(Token.TipoToken.GUION);
                        TempToken.setLexema("-");
                        TempToken.setID(TokenID++);
                        ListaTokens.AddLast(TempToken);
                        break;
                    case '>':
                        TempToken.setTipo(Token.TipoToken.SIGNO_MAYOR);
                        TempToken.setLexema(">");
                        TempToken.setID(TokenID++);
                        ListaTokens.AddLast(TempToken);
                        break;
                    case '.':
                        TempToken.setTipo(Token.TipoToken.PUNTO);
                        TempToken.setLexema(".");
                        TempToken.setID(TokenID++);
                        ListaTokens.AddLast(TempToken);
                        break;
                    case '*':
                        TempToken.setTipo(Token.TipoToken.SIGNO_ASTERISCO);
                        TempToken.setLexema("*");
                        TempToken.setID(TokenID++);
                        ListaTokens.AddLast(TempToken);
                        break;
                    case '+':
                        TempToken.setTipo(Token.TipoToken.SIGNO_MAS);
                        TempToken.setLexema("+");
                        TempToken.setID(TokenID++);
                        ListaTokens.AddLast(TempToken);
                        break;
                    case ';':
                        TempToken.setTipo(Token.TipoToken.PUNTO_COMA);
                        TempToken.setLexema(";");
                        TempToken.setID(TokenID++);
                        ListaTokens.AddLast(TempToken);
                        break;
                    case ':':
                        TempToken.setTipo(Token.TipoToken.DOS_PUNTOS);
                        TempToken.setLexema(":");
                        TempToken.setID(TokenID++);
                        ListaTokens.AddLast(TempToken);
                        break;
                    case '|':
                        TempToken.setTipo(Token.TipoToken.SIGNO_ALTERNANCIA);
                        TempToken.setLexema("|");
                        TempToken.setID(TokenID++);
                        ListaTokens.AddLast(TempToken);
                        break;
                    case '?':
                        TempToken.setTipo(Token.TipoToken.SIGNO_INTERROGACION);
                        TempToken.setLexema("?");
                        TempToken.setID(TokenID++);
                        ListaTokens.AddLast(TempToken);
                        break;
                    case ',':
                        TempToken.setTipo(Token.TipoToken.COMA);
                        TempToken.setLexema(",");
                        TempToken.setID(TokenID++);
                        ListaTokens.AddLast(TempToken);
                        break;
                }

                //PARA IDENTIFICADORES 
                //if (testAlfabeto(MyChar) && MyChar>90)
                if (testAlfabeto(MyChar))
                {
                    for (int j = i; j < NCaracteres; j++)
                    {
                        MyChar = Entrada.Text[j];
                        if (testAlfabeto(MyChar))
                        {
                            TempLexema = TempLexema + Entrada.Text[j];
                        }
                        else
                        {
                            i = j - 1;
                            break;
                        }
                    }
                    //HACER IDENTIFICACION DE PALABRAS RESERVADAS SI FUERA NECESARIO
                    TempToken.setTipo(Token.TipoToken.ID);
                    TempToken.setLexema(TempLexema);
                    TempToken.setID(TokenID++);
                    ListaTokens.AddLast(TempToken);
                }

                //PARA CADENAS

                else if ((int)MyChar == 34)
                {
                    i++;
                    MyChar = Entrada.Text[i];
                    for (int j = i; j < NCaracteres ; j++)
                    {
                        MyChar = Entrada.Text[j];
                        if ((int)MyChar == 34)
                        {
                            i = j;
                            TempToken.setTipo(Token.TipoToken.CADENA);
                            TempToken.setLexema(TempLexema);
                            TempToken.setID(TokenID++);
                            ListaTokens.AddLast(TempToken);
                            break;
                        }
                        else
                        {
                            TempLexema = TempLexema + Entrada.Text[j];
                        }
                    }
                }

                //PARA COMENTARIOS MULTILINEA

                else if (MyChar == '<')
                {
                    i++;
                    MyChar = Entrada.Text[i];
                    if (MyChar == '!')
                    {
                        i++;
                        MyChar = Entrada.Text[i];
                        for (int j = i; j <NCaracteres; j++)
                        {
                            MyChar = Entrada.Text[j];
                            if (MyChar == '!')
                            {
                                j++;
                                MyChar = Entrada.Text[j];
                                if (MyChar == '>')
                                {
                                    i = j;
                                    TempToken.setTipo(Token.TipoToken.COMENTARIO);
                                    TempToken.setLexema(TempLexema);
                                    TempToken.setID(TokenID++);
                                    ListaTokens.AddLast(TempToken);
                                    break;
                                }
                                else
                                {
                                    //CONTROLAR EXCEPCION DE MAL FINAL DE COMENTARIO 
                                }
                            }
                            else
                            {
                                TempLexema = TempLexema + Entrada.Text[j] ;
                            }
                        }
                    }
                    else
                    {
                        //CONTROLAR EXCEPCION DE MAL INICIO DE COMENTARIO
                    }
                }

                //PARA COMENTARIOS DE UNA LINEA
                else if (MyChar == '/')
                {
                    i++;
                    MyChar = Entrada.Text[i];
                    if (MyChar == '/')
                    {
                        i++;
                        MyChar = Entrada.Text[i];
                        for (int j = i; j <NCaracteres; j++)
                        {
                            MyChar = Entrada.Text[j];

                            if ((int)MyChar == 10)
                            {
                                i = j;
                                TempToken.setTipo(Token.TipoToken.COMENTARIO);
                                TempToken.setLexema(TempLexema);
                                TempToken.setID(TokenID++);
                                ListaTokens.AddLast(TempToken);
                                break;
                            }
                            else
                            {
                                TempLexema = TempLexema + Entrada.Text[j];
                            }
                        }
                    }
                    else
                    {
                        //CONTROLAR EXCEPCION DE MA INICIO DE COMENTARIO
                    }
                }

            }

        }

        //Verifica si un caracter esta en A-Z , a-z , 0-9 o es "_"
        private Boolean testAlfabeto(int Caracter)
        {

            if ((Caracter >= 65 && Caracter <= 90) || (Caracter >= 97 && Caracter <= 122) || (Caracter >= 48 && Caracter <= 57) || (Caracter == '_'))
            {
                return true;
            }
            else
            {
                return false;
            }

        }

        public void analizeTokens()
        {
            for (int i = 0; i < ListaTokens.Count; i++)
            {

                //DETERMINA CONJUNTOS, EXPRESIONES REGULARES Y PALABRAS A EVALUAR
                if (ListaTokens.ElementAt(i).getTipo()==Token.TipoToken.ID)
                {

                    i++;

                    //PARA CONJUNTOS Y PALABRAS A EVALUAR
                    if (ListaTokens.ElementAt(i).getTipo() == Token.TipoToken.DOS_PUNTOS)
                    {

                        i++;

                        // PARA PALABRAS A EVALUAR 
                        if (ListaTokens.ElementAt(i).getTipo() == Token.TipoToken.CADENA)
                        {
                            Palabra TempPalabra = new Palabra();
                            TempPalabra.setID(ListaTokens.ElementAt(i - 2).getLexema());
                            TempPalabra.setLexema(ListaTokens.ElementAt(i).getLexema());
                            Palabras.AddLast(TempPalabra);
                        }

                        // PARA CONJUNTOS TIPO RANGO
                        else if (ListaTokens.ElementAt(i + 4).getTipo() == Token.TipoToken.GUION_CURVO)
                        {
                            Conjunto TempConjunto = new Conjunto();
                            TempConjunto.setID(ListaTokens.ElementAt(i).getLexema());
                            i += 3;
                            TempConjunto.setBeginInterval(ListaTokens.ElementAt(i).getLexema());
                            TempConjunto.setEndInterval(ListaTokens.ElementAt(i + 2).getLexema());
                            Conjuntos.AddLast(TempConjunto);
                        }

                        //PARA CONJUNTOS TIPO LISTA
                        else if (ListaTokens.ElementAt(i + 4).getTipo() == Token.TipoToken.COMA)
                        {
                            Conjunto TempConjunto = new Conjunto();
                            TempConjunto.setID(ListaTokens.ElementAt(i).getLexema());
                            i += 3;
                            // ADVERTENCIA -- CICLO CON NECESIDAD DE BREAK
                            for (int j = i; j > 0; j += 2)
                            {
                                TempConjunto.addCharToList(ListaTokens.ElementAt(j).getLexema()[0]);
                                if (ListaTokens.ElementAt(j + 1).getTipo() == Token.TipoToken.PUNTO_COMA)
                                {
                                    i = j + 1;
                                    break;
                                }
                            }
                            Conjuntos.AddLast(TempConjunto);
                        }
                    }

                    //PARA EXPRESIONES REGULARES
                    else if (ListaTokens.ElementAt(i).getTipo() == Token.TipoToken.GUION)
                    {
                        Regex TempRegex = new Regex();
                        Nodo TempNodo = new Nodo();
                        TempRegex.setID(ListaTokens.ElementAt(i - 1).getLexema());
                        //ADELANTA POSICION
                        i += 2;
                        for (int j = i; j > 0; j++)
                        {
                            TempNodo = new Nodo();

                            if (ListaTokens.ElementAt(j).getTipo() == Token.TipoToken.PUNTO)
                            {
                                TempNodo.setTipo(Nodo.TipoNodo.CONCATENACION);
                                TempNodo.setID2(Nodo.Contador2);
                                TempRegex.addNodo(TempNodo);
                            }

                            else if (ListaTokens.ElementAt(j).getTipo() == Token.TipoToken.CADENA)
                            {
                                TempNodo.setTipo(Nodo.TipoNodo.TERMINAL);
                                TempNodo.setID(Nodo.Contador);
                                TempNodo.setTerminal(ListaTokens.ElementAt(j).getLexema());
                                TempNodo.setID2(Nodo.Contador2);
                                TempRegex.addNodo(TempNodo);
                            }

                            else if (ListaTokens.ElementAt(j).getTipo() == Token.TipoToken.SIGNO_ASTERISCO)
                            {
                                TempNodo.setTipo(Nodo.TipoNodo.KLEENE);
                                TempNodo.setID2(Nodo.Contador2);
                                TempRegex.addNodo(TempNodo);
                            }

                            else if (ListaTokens.ElementAt(j).getTipo() == Token.TipoToken.SIGNO_MAS)
                            {
                                TempNodo.setTipo(Nodo.TipoNodo.POSITIVA);
                                TempNodo.setID2(Nodo.Contador2);
                                TempRegex.addNodo(TempNodo);
                            }

                            else if (ListaTokens.ElementAt(j).getTipo() == Token.TipoToken.SIGNO_ALTERNANCIA)
                            {
                                TempNodo.setTipo(Nodo.TipoNodo.ALTERNANCIA);
                                TempNodo.setID2(Nodo.Contador2);
                                TempRegex.addNodo(TempNodo);
                            }

                            else if (ListaTokens.ElementAt(j).getTipo() == Token.TipoToken.SIGNO_INTERROGACION)
                            {
                                TempNodo.setTipo(Nodo.TipoNodo.UNAOCERO);
                                TempNodo.setID2(Nodo.Contador2);
                                TempRegex.addNodo(TempNodo);
                            }

                            else if (ListaTokens.ElementAt(j).getTipo() == Token.TipoToken.ABRE_LLAVE)
                            {
                                j++;
                                TempNodo.setTipo(Nodo.TipoNodo.TERMINAL);
                                TempNodo.setID(Nodo.Contador);
                                TempNodo.setTerminal(ListaTokens.ElementAt(j).getLexema());
                                TempNodo.setConjunto(ListaTokens.ElementAt(j).getLexema(), Conjuntos);
                                j++;
                                TempNodo.setID2(Nodo.Contador2);
                                TempRegex.addNodo(TempNodo);
                            }

                            else if (ListaTokens.ElementAt(j).getTipo() == Token.TipoToken.PUNTO_COMA)
                            {
                                Expresiones.AddLast(TempRegex);
                                i = j;
                                break;
                            }
                        }
                        Nodo.Contador = 1;
                        Nodo.Contador2 = 1;
                    }
                }
            }
        }

        public void analizeExpresiones()
        {
            foreach (Regex TempRegex in Expresiones)
            {
                TempRegex.createRegexAFN();
            }
            Console.WriteLine("dsad");
        }

    }
}
