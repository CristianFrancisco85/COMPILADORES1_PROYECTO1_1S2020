using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.IO;
using System.Drawing;

namespace OLC1_Proyecto1
{
    class Scanner
    {

        LinkedList<Token> ListaTokens = new LinkedList<Token>();
        public LinkedList<Token> ListaErrores = new LinkedList<Token>();
        public LinkedList<Conjunto> Conjuntos = new LinkedList<Conjunto>();
        LinkedList<Palabra> Palabras = new LinkedList<Palabra>();
        public LinkedList<Regex> Expresiones = new LinkedList<Regex>();
        int TokenID = 0; //Para Simbolos
        int ErrorID = 0; //Para Errores
        public bool Errores;

        //Realiza Analisis Lexico y Agrupa Lexemas validos en Tokens
        public void ScanText(RichTextBox Entrada)
        {
            //Guarda valor ASCII
            char MyChar;
            //Cantidad de Caracteres
            int NCaracteres = Entrada.Text.Length;

            for (int i = 0; i < NCaracteres; i++)
            {
                MyChar = Entrada.Text[i];

                Token TempToken = new Token();
                String TempLexema = "";
                Boolean Control = true;

                //PARA SIMBOLOS INDIVIDUALES

                switch (MyChar)
                {
                    case '{':
                        TempToken.setTipo(Token.TipoToken.ABRE_LLAVE);
                        TempToken.setLexema("{");
                        TempToken.setID(TokenID++);
                        TempToken.Fila = Entrada.GetLineFromCharIndex(i) + 1;
                        TempToken.Columna = i - Entrada.GetFirstCharIndexFromLine(TempToken.Fila - 1);
                        ListaTokens.AddLast(TempToken);
                        Control = false;
                        break;
                    case '}':
                        TempToken.setTipo(Token.TipoToken.CIERRA_LLAVE);
                        TempToken.setLexema("}");
                        TempToken.setID(TokenID++);
                        TempToken.Fila = Entrada.GetLineFromCharIndex(i) + 1;
                        TempToken.Columna = i - Entrada.GetFirstCharIndexFromLine(TempToken.Fila - 1);
                        ListaTokens.AddLast(TempToken);
                        Control = false;
                        break;
                    case '%':
                        TempToken.setTipo(Token.TipoToken.PORCENTAJE);
                        TempToken.setLexema("%");
                        TempToken.setID(TokenID++);
                        TempToken.Fila = Entrada.GetLineFromCharIndex(i) + 1;
                        TempToken.Columna = i - Entrada.GetFirstCharIndexFromLine(TempToken.Fila - 1);
                        ListaTokens.AddLast(TempToken);
                        Control = false;
                        break;
                    case '~':
                        TempToken.setTipo(Token.TipoToken.GUION_CURVO);
                        TempToken.setLexema("~");
                        TempToken.setID(TokenID++);
                        TempToken.Fila = Entrada.GetLineFromCharIndex(i) + 1;
                        TempToken.Columna = i - Entrada.GetFirstCharIndexFromLine(TempToken.Fila - 1);
                        ListaTokens.AddLast(TempToken);
                        Control = false;
                        break;
                    case '-':
                        TempToken.setTipo(Token.TipoToken.GUION);
                        TempToken.setLexema("-");
                        TempToken.setID(TokenID++);
                        TempToken.Fila = Entrada.GetLineFromCharIndex(i) + 1;
                        TempToken.Columna = i - Entrada.GetFirstCharIndexFromLine(TempToken.Fila - 1);
                        ListaTokens.AddLast(TempToken);
                        Control = false;
                        break;
                    case '>':
                        TempToken.setTipo(Token.TipoToken.SIGNO_MAYOR);
                        TempToken.setLexema(">");
                        TempToken.setID(TokenID++);
                        TempToken.Fila = Entrada.GetLineFromCharIndex(i) + 1;
                        TempToken.Columna = i - Entrada.GetFirstCharIndexFromLine(TempToken.Fila - 1);
                        ListaTokens.AddLast(TempToken);
                        Control = false;
                        break;
                    case '.':
                        TempToken.setTipo(Token.TipoToken.PUNTO);
                        TempToken.setLexema(".");
                        TempToken.setID(TokenID++);
                        TempToken.Fila = Entrada.GetLineFromCharIndex(i) + 1;
                        TempToken.Columna = i - Entrada.GetFirstCharIndexFromLine(TempToken.Fila - 1);
                        ListaTokens.AddLast(TempToken);
                        Control = false;
                        break;
                    case '*':
                        TempToken.setTipo(Token.TipoToken.SIGNO_ASTERISCO);
                        TempToken.setLexema("*");
                        TempToken.setID(TokenID++);
                        TempToken.Fila = Entrada.GetLineFromCharIndex(i) + 1;
                        TempToken.Columna = i - Entrada.GetFirstCharIndexFromLine(TempToken.Fila - 1);
                        ListaTokens.AddLast(TempToken);
                        Control = false;
                        break;
                    case '+':
                        TempToken.setTipo(Token.TipoToken.SIGNO_MAS);
                        TempToken.setLexema("+");
                        TempToken.setID(TokenID++);
                        TempToken.Fila = Entrada.GetLineFromCharIndex(i) + 1;
                        TempToken.Columna = i - Entrada.GetFirstCharIndexFromLine(TempToken.Fila - 1);
                        ListaTokens.AddLast(TempToken);
                        Control = false;
                        break;
                    case ';':
                        TempToken.setTipo(Token.TipoToken.PUNTO_COMA);
                        TempToken.setLexema(";");
                        TempToken.setID(TokenID++);
                        TempToken.Fila = Entrada.GetLineFromCharIndex(i) + 1;
                        TempToken.Columna = i - Entrada.GetFirstCharIndexFromLine(TempToken.Fila - 1);
                        ListaTokens.AddLast(TempToken);
                        Control = false;
                        break;
                    case ':':
                        TempToken.setTipo(Token.TipoToken.DOS_PUNTOS);
                        TempToken.setLexema(":");
                        TempToken.setID(TokenID++);
                        TempToken.Fila = Entrada.GetLineFromCharIndex(i) + 1;
                        TempToken.Columna = i - Entrada.GetFirstCharIndexFromLine(TempToken.Fila - 1);
                        ListaTokens.AddLast(TempToken);
                        Control = false;
                        break;
                    case '|':
                        TempToken.setTipo(Token.TipoToken.SIGNO_ALTERNANCIA);
                        TempToken.setLexema("|");
                        TempToken.setID(TokenID++);
                        TempToken.Fila = Entrada.GetLineFromCharIndex(i) + 1;
                        TempToken.Columna = i - Entrada.GetFirstCharIndexFromLine(TempToken.Fila - 1);
                        ListaTokens.AddLast(TempToken);
                        Control = false;
                        break;
                    case '?':
                        TempToken.setTipo(Token.TipoToken.SIGNO_INTERROGACION);
                        TempToken.setLexema("?");
                        TempToken.setID(TokenID++);
                        TempToken.Fila = Entrada.GetLineFromCharIndex(i) + 1;
                        TempToken.Columna = i - Entrada.GetFirstCharIndexFromLine(TempToken.Fila - 1);
                        ListaTokens.AddLast(TempToken);
                        Control = false;
                        break;
                    case ',':
                        TempToken.setTipo(Token.TipoToken.COMA);
                        TempToken.setLexema(",");
                        TempToken.setID(TokenID++);
                        TempToken.Fila = Entrada.GetLineFromCharIndex(i) + 1;
                        TempToken.Columna = i - Entrada.GetFirstCharIndexFromLine(TempToken.Fila - 1);
                        ListaTokens.AddLast(TempToken);
                        Control = false;
                        break;
                }


                if (Control)
                {
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
                        TempToken.Fila = Entrada.GetLineFromCharIndex(i) + 1;
                        TempToken.Columna = i - Entrada.GetFirstCharIndexFromLine(TempToken.Fila - 1);
                        ListaTokens.AddLast(TempToken);
                    }

                    //PARA CADENAS

                    else if ((int)MyChar == 34)
                    {
                        i++;
                        MyChar = Entrada.Text[i];
                        for (int j = i; j < NCaracteres; j++)
                        {
                            MyChar = Entrada.Text[j];
                            if ((int)MyChar == 34)
                            {
                                i = j;
                                TempToken.setTipo(Token.TipoToken.CADENA);
                                TempToken.setLexema(TempLexema);
                                TempToken.setID(TokenID++);
                                TempToken.Fila = Entrada.GetLineFromCharIndex(i) + 1;
                                TempToken.Columna = i - Entrada.GetFirstCharIndexFromLine(TempToken.Fila - 1);
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
                            for (int j = i; j < NCaracteres; j++)
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
                                        TempToken.Fila = Entrada.GetLineFromCharIndex(i) + 1;
                                        TempToken.Columna = i - Entrada.GetFirstCharIndexFromLine(TempToken.Fila - 1);
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
                                    TempLexema = TempLexema + Entrada.Text[j];
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
                            for (int j = i; j < NCaracteres; j++)
                            {
                                MyChar = Entrada.Text[j];

                                if ((int)MyChar == 10)
                                {
                                    i = j;
                                    TempToken.setTipo(Token.TipoToken.COMENTARIO);
                                    TempToken.setLexema(TempLexema);
                                    TempToken.setID(TokenID++);
                                    TempToken.Fila = Entrada.GetLineFromCharIndex(i) + 1;
                                    TempToken.Columna = i - Entrada.GetFirstCharIndexFromLine(TempToken.Fila - 1);
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

                    else if (MyChar >= 125)
                    {
                        Errores = true;

                        TempToken.setID(ErrorID++);
                        TempToken.setLexema(MyChar.ToString());
                        TempToken.Fila = Entrada.GetLineFromCharIndex(i) + 1;
                        TempToken.Columna = i - Entrada.GetFirstCharIndexFromLine(TempToken.Fila - 1);
                        ListaErrores.AddLast(TempToken);
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
                            TempPalabra.Fila = ListaTokens.ElementAt(i).Fila;
                            TempPalabra.Columna = ListaTokens.ElementAt(i).Columna;
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
                TempRegex.graphAFN();
                TempRegex.graphAFD();
            }
            Console.WriteLine("dsad");
        }

        public void reporteErrores()
        {
            SaveFileDialog saveFile = new SaveFileDialog();
            saveFile.Filter = "Archivo PDF (*.pdf)|*.pdf";
            saveFile.DefaultExt = "pdf";
            saveFile.AddExtension = true;

            saveFile.Title = "Guardar Reporte Analisis Lexico";
            if (saveFile.ShowDialog() == DialogResult.OK)
            {
                String path = saveFile.FileName;
                path = (path.EndsWith(".pdf")) ? path : path + ".pdf";
                Document Report = new Document();
                PdfWriter.GetInstance(Report, new FileStream(path, FileMode.Create));
                Report.Open();
                Report.Add(new Paragraph("REPORTE ANALISIS LEXICO", FontFactory.GetFont(FontFactory.HELVETICA, 20, BaseColor.BLUE)));
                Report.Add(new Paragraph("\n \n "));

                PdfPTable Tabla1 = new PdfPTable(4);
                Tabla1.WidthPercentage = 100;
                PdfPCell titleCell = new PdfPCell(new Paragraph("ERRORES"));
                titleCell.Colspan=8;
                titleCell.HorizontalAlignment=Element.ALIGN_CENTER;
                titleCell.BackgroundColor=BaseColor.LIGHT_GRAY;
                Tabla1.AddCell(titleCell);
                // COLUMNS NAMES
                Paragraph column1 = new Paragraph("ID", FontFactory.GetFont(FontFactory.HELVETICA, 12));
                Paragraph column2 = new Paragraph("Lexema", FontFactory.GetFont(FontFactory.HELVETICA, 12));
                Paragraph column3 = new Paragraph("Fila", FontFactory.GetFont(FontFactory.HELVETICA, 12));
                Paragraph column4 = new Paragraph("Columna", FontFactory.GetFont(FontFactory.HELVETICA, 12));

                Tabla1.AddCell(column1);
                Tabla1.AddCell(column2);
                Tabla1.AddCell(column3);
                Tabla1.AddCell(column4);

                foreach(Token TempToken in ListaErrores){
                    Tabla1.AddCell(TempToken.getID().ToString());
                    Tabla1.AddCell(TempToken.getLexema());
                    Tabla1.AddCell(TempToken.Fila.ToString());
                    Tabla1.AddCell(TempToken.Columna.ToString());
                }

                Report.Add(Tabla1);
                Report.Close();
                MessageBox.Show("Reporte de Errores Guardado Correctamente", "PDF", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }


        }

        public void validarLexemas(RichTextBox TokensTxt, RichTextBox ErroresTxt)
        {
            TokensTxt.AppendText("<ListaTokens>\n",Color.BlueViolet);
            ErroresTxt.AppendText("<ListaErrores>\n", Color.BlueViolet);
            foreach (Regex auxRegex in Expresiones)
            {
                foreach (Palabra auxPalabra in Palabras)
                {
                    if (auxRegex.TestLexema(auxPalabra.getLexema(), Conjuntos))
                    {
                        //GENERAR XML
                        TokensTxt.AppendText("\t<Token>\n", Color.LimeGreen);

                        TokensTxt.AppendText("\t\t<Nombre> ", Color.DarkOrange);
                        TokensTxt.AppendText(auxRegex.getID(), Color.Gainsboro);
                        TokensTxt.AppendText(" </Nombre>\n", Color.DarkOrange);

                        TokensTxt.AppendText("\t\t<Valor> ", Color.DeepPink);
                        TokensTxt.AppendText(auxPalabra.getLexema(),Color.Gainsboro);
                        TokensTxt.AppendText(" </Valor>\n", Color.DeepPink);

                        TokensTxt.AppendText("\t\t<Fila> ", Color.Crimson);
                        TokensTxt.AppendText(auxPalabra.Fila.ToString(), Color.Gainsboro);
                        TokensTxt.AppendText(" </Fila>\n", Color.Crimson);

                        TokensTxt.AppendText("\t\t<Columa> ", Color.DodgerBlue);
                        TokensTxt.AppendText(auxPalabra.Columna.ToString(), Color.Gainsboro);
                        TokensTxt.AppendText(" </Columa>\n", Color.DodgerBlue);

                        TokensTxt.AppendText("\t</Token>\n\n", Color.LimeGreen);

                        
                    }
                    else
                    {
                        //GENERAR XML
                        ErroresTxt.AppendText("\t<Error>\n", Color.LimeGreen);

                        ErroresTxt.AppendText("\t\t<Valor> ", Color.DeepPink);
                        ErroresTxt.AppendText(auxPalabra.getLexema(), Color.Gainsboro);
                        ErroresTxt.AppendText(" </Valor>\n", Color.DeepPink);

                        ErroresTxt.AppendText("\t\t<Fila> ", Color.Crimson);
                        ErroresTxt.AppendText(auxPalabra.Fila.ToString(), Color.Gainsboro);
                        ErroresTxt.AppendText(" </Fila>\n", Color.Crimson);

                        ErroresTxt.AppendText("\t\t<Columa> ", Color.DodgerBlue);
                        ErroresTxt.AppendText(auxPalabra.Columna.ToString(), Color.Gainsboro);
                        ErroresTxt.AppendText(" </Columa>\n", Color.DodgerBlue);

                        ErroresTxt.AppendText("\t</Error>\n\n", Color.LimeGreen);

                    }
                }
            }
            TokensTxt.AppendText("</ListaTokens>", Color.BlueViolet);
            ErroresTxt.AppendText("</ListaErrores>", Color.BlueViolet);

        }


    }

    public static class RichTextBoxExtensions
    {
        //SE SOBRECARGAR EL METODO APPENDTEXT PARA PODER PINTAR EL TEXTO
        public static void AppendText(this RichTextBox box, string text, Color color)
        {
            box.SelectionStart = box.TextLength;
            box.SelectionLength = 0;
            box.SelectionColor = color;
            box.AppendText(text);
            box.SelectionColor = box.ForeColor;
        }
    }


}
