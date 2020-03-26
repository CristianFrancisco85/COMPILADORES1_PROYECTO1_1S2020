# PROYECTO 1 - COMPILADORES 1
_Generador de Analizadores Lexicos a partir de Expresiones Regulares - C#_ 
- Funciones Principales
   - Analisis de Expresiones Regulares
   - Generacion de AFN mediante metodo de Thompson
   - Generacion de AFD mediante metodo de Subconjuntos
   - Analisis de Lexemas
## Requisitos 📋
- .NET Framework 4.7.2
- [Graphviz](https://www.graphviz.org/).
## Conceptos ❔ :

- **Expresion Regular:** Las expresiones regulares establecen el patrón que representa al token. Para el análisis y
evaluación de cada una de las expresiones regulares se presentarán en notación prefija o
[polaca](https://es.wikipedia.org/wiki/Notaci%C3%B3n_polaca).

- **Conjunto:** Un conjunto, son agrupaciones de caracteres del mismo tipo, permitidos en el 
lenguaje, como agrupaciones de letras, números, etc. La palabra reservada a utilizar será “CONJ”. 
El rango válido será desde el ASCII 33 hasta el 125 
  - Un conjunto puede utilizarse dentro de una expresión regular.
  - Un conjunto no puede utilizarse en la definición de otro conjunto.
  
- **Conjunto [:TODO:] :** Conjunto utilizado en la definicion de expresiones regulares para poder aceptar caracteres ASCII de control
los cuales son \n (Nueva Linea), \t (Tabulacion), y escapear los caracteres \\' (Comilla Simple), \\" (Comilla Doble).

- **Analizador Lexico:** Este tiene como finalidad analizar un archivo de entrada que contendra cadenas (lexema)
que deberá evaluar mediante los patrones (expresiones regulares) detectados durante el
análisis de expresiones regulares y siempre que se generarán los autómatas finitos
deterministas correspondientes a cada expresión regular.
Al terminar el análisis léxico de la cadena de entrada se generara una lista de Tokens 
encontrados o en su defecto una lista de errores ambos en formato XML.

## Archivo de Entrada 📄 : 
_Todas las definiciones en conjunto deben encontrarse dentro de llaves { }._
_Extension del archivo: **.er**_

### Errores Lexicos en Archivo de Entrada:
Los errores lexicos en los archivos de entrada son todos aquellos caracteres el cual su representacion en ASCII sea mayor que 126.
En ese caso se generara un reporte PDF de los errores lexicos encontrados.

- **Comentarios de una linea**
```
// Este es un comentario
```
- **Comentarios de multi-linea** 
```
<!
Este es un comentario
multilínea
!>
```
- **Definicion de Conjuntos** 
```
CONJ: mayusculas -> A~Z;
CONJ: vocales_min -> a,e,i,o,u;
CONJ: simbolos -> !~&;
```

- **Definicion de Expresiones Regulares**
```
EXP2 -> * | . . . {simbolos} {minusculas} " " "TEXTO" ? . {relacionales} | {digitos} * {operadores};
EXP3 -> . +{abecedario}  . {conjnum} ? . ":" +{abecedario};
EXP4 -> . . . . . . . * | {abecedario} "_" + {conjnum} ">" + {conjnum} " " | "TRUE" "FALSE" "." [:\t:] ;
```
- **Definicion de Lexemas**
```
EXP3 : "numero5:cinco";
EXP2 : "!a TEXTO<++--%^";
EXP4 : "la_expresion5>4 TRUE.   "; 
```
- **Archivo de Muestra**
```
{

<!
//========================ARCHIVO DE ENTRADA=========================//
//=============================AVANZADO==============================//
!>

//--------------------DEFINICION DE CONJUNTOS------------------------\\
CONJ: mayusculas -> A~Z;
CONJ: minusculas -> a~z;
CONJ: digitos -> 0~9;
CONJ: vocales_min -> a,e,i,o,u;
CONJ: VOCALES_may -> A,E,I,O,U;
CONJ: simbolos -> !~&;
CONJ: otros -> @~};
CONJ: relacionales -> <~>;
CONJ: logicos -> &,!,|;
CONJ: operadores ->+,-,*,\,^,%;
CONJ: abecedario -> a~z;
CONJ: conjnum -> 2~6;

//------------------------DEFINICION DE ER--------------------------\\

EXP2 -> * | . . . {simbolos} {minusculas} " " "TEXTO" ? . {relacionales} | {digitos} * {operadores};
EXP3 -> . +{abecedario}  . {conjnum} ? . ":" +{abecedario};
EXP4 -> . . . . . . . * | {abecedario} "_" + {conjnum} ">" + {conjnum} " " | "TRUE" "FALSE" "." [:\t:] ;

<!
	Definicion de lexemas
!>

EXP2 : "A | B & C ! c > G ";
EXP3 : "numero5:cinco";
EXP2 : "!a TEXTO<++--%^";
EXP4 : "la_expresion5>4 TRUE.	"; 
EXP4 : "95>4 es FALSE.";

<!
	Fin del archivo
!>
}

```
## Salida de Tokens 💬 :
_Al momento de terminar el análisis se generara una cadena de salida en formato XML
el cual contiene los tokens reconocidos._
```
<ListaTokens>

  <Token>
    <Nombre>nombre_token1</Nombre>
    <Valor>valor_token1</Valor>
    <Fila>fila_token1</Fila>
    <Columna>columna_token1</Columna>
  </Token>
  
  <Token>
   <Nombre>nombre_token2</Nombre>
    <Valor>valor_token2</Valor>
    <Fila>fila_token2</Fila>
    <Columna>columna_token2</Columna>
  </Token>
  
</ListaTokens>
```
## Salida de Errores ⚠️ :
_En caso de existir errores durante el análisis léxico de los lexemas se generara una cadena de salida en formato XML
el cual contiene los tokens reconocidos._
```
<ListaTokens>

  <Error>
    <Valor>valor_error1</Valor>
    <Fila>fila_error1</Fila>
    <Columna>columna_error1</Columna>
  </Error>
  
</ListaTokens>
```

## Construido con 🛠️
* [Visual Studio 2019](https://visualstudio.microsoft.com/es/vs/) - IDE
* [Graphviz](https://www.graphviz.org/) - Libreria utilizada para graficar AFN's y AFD's
* [Git](https://git-scm.com/) - Control de Versiones
* [iTextSharp](https://github.com/itext/itextsharp) - Libreria utilizada para generar reportes PDF
