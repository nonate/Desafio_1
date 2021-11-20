using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Desafio_1
{
    public partial class frmPrincipal : Form
    {
        public frmPrincipal()
        {
            InitializeComponent();
        }

        private void btnValidar_Click(object sender, EventArgs e)
        {
            String valor = txtIngresoTexto.Text;

            if (valor == "") {
                lblCantidad.Text = "0";
                MessageBox.Show("La cadena de texto no debe estar vacía", "Error");
            }
            else if (!validarCampos(valor))
            {
                lblCantidad.Text = "0";
                MessageBox.Show("La cadena de texto contiene caracteres no válidos (Se aceptan caracteres en mayúscula del alfabeto inglés)", "Error");
            }
            else
            {
                List<int> listaCantidad = new List<int>();
                String letrasUsadas = "";
                int suma = 0;
                foreach (char x in valor)
                {
                    if (!letrasUsadas.Contains(x))
                    {
                        listaCantidad.Add(contarCaracteres(valor, x));
                        letrasUsadas += x;
                    }
                }
                listaCantidad.Sort();
                listaCantidad.Reverse();
                int contadorInicial = 26;

                foreach (int y in listaCantidad)
                {
                    suma += y * contadorInicial;
                    contadorInicial--;
                }

                lblCantidad.Text = suma.ToString();

            }

        }


        private static bool validarCampos(String texto) {
            char[] alfabeto = { 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M', 'N', 'O', 'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'W', 'X', 'Y', 'Z' };
            foreach (char x in texto) 
                if (!alfabeto.Contains(x)) return false;
            return true;
        }

        public static int contarCaracteres(String texto, char letra) {
            int salida = 0;
            foreach (char x in texto) {
                if (x == letra) salida++;
            }
            return salida;
        }
    }
}
