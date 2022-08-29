using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Numeros_en_Palabras
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        int nro;
        private void ingreso(object sender, EventArgs e)
        {
            nro =(int) numero.Value;
            palabra_sal.Text=funcion3(nro);
        }
        
        private string funcion3(int nro)
	{   	int millonecima,nrores;
		string conc,millones=(" millones "),millon=("un millon ");
		millonecima=nro/1000000;
        conc="";
		if(millonecima>0){if(millonecima==1){conc=millon;if(nro==1000000){return conc;}}else{conc+=funcion(millonecima);conc+=millones;}}
		nrores=nro-(millonecima*1000000);
		conc+=funcion2(nrores);
		return conc;
		}

        private string funcion2(int nro)
	{	int milena,nrores;
	    string conc,mil=(" mil ");
        conc = "";
		milena=nro/1000;
		if(milena>0){if(milena==1){conc=mil;if(nro==1000){return conc;}}else{conc+=funcion(milena);conc+=mil;}} 
		nrores=nro-(milena*1000);
		conc+=funcion(nrores);
		return conc;
		}
        /// <summary>
        /// toma un número como parametro que es menor a 100
        /// y devuelve el nro en forma coloquial
        /// </summary>
        /// <param name="nro"></param>
        /// <returns></returns>
        private string funcion(int nro)
           {int unidad,decena,centena;   
            string[] unidades={"uno","dos" ,"tres","cuatro","cinco","seis","siete","ocho","nueve"};
            string[] decenas1={"diez","once","doce","trece","catorce","quince"};
            string[] centenas={"cien","ciento ","doscietos ","trescientos ","cuatrocientos ","quinientos ","seiscientos ","setecientos ","ochocientos ","novecientos "};
            string[] decenas2={"diez","veinte","treinta","cuarenta","cincuenta","sesenta","setenta","ochenta","noventa"};        
            string  y=(" y "),veinti=("veinti");
            string conc;
            conc="";
            centena=nro/100;
            decena=(nro-(centena*100))/10;//primero separo el nro en unidades, decenas y centenas
            unidad=nro-(centena*100+decena*10);           
            if(centena>0){if(nro==100){conc=centenas[0];return conc;}else {conc+=centenas[centena];}}
            switch(decena){
                   case 0: if(unidad==0){return conc;} else{
						  conc+=unidades[unidad-1];return conc ;}
						  break; //  si no hay decenas muestro unidades solas   
                   case 2: if(unidad==0){   
									  conc+=decenas2[decena-1];
                                      return  conc;}
                        	 else{         // si no concateno 
                                      conc+=veinti;
                                      conc+=unidades[unidad-1];
                                      return conc; }
						break;
				   case 3: case 4: case 5: case 6: case 7: case 8: case 9:
                        if(unidad==0){
									  conc+=decenas2[decena-1];
                                      return  conc;}// si las decenas no tienen unidad  tambien las muestro solas
                        else{         // si no concateno 
                                      conc+=decenas2[decena-1];
                                      conc+=y;
                                      conc+=unidades[unidad-1];
                                      return conc;        }
                   break;
                   default: if(unidad<6) {
								conc+=decenas1[unidad];
								return conc;}
                            else { conc+=decenas2[decena-1];
								conc+=y;
								conc+=unidades[unidad-1];
								return conc;
							break;     
                                 }
            } 
			                   
           }

        private void answer_Enter(object sender, EventArgs e)
        {
            // Select the whole answer in the NumericUpDown control.
            NumericUpDown answerBox = sender as NumericUpDown;

            if (answerBox != null)
            {
                int lengthOfAnswer = answerBox.Value.ToString().Length;
                answerBox.Select(0, lengthOfAnswer);
            }

        }

      

        
      
    }
}
