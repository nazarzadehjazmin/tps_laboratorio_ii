using Entidades;
using System;
using System.Text;
using System.Windows.Forms;

namespace MiCalculadora
{
    public partial class FormCalculadora : Form
    {
        /// <summary>
        /// Inicializa el Windows Forms de Calculadora y sus componentes
        /// </summary>
        public FormCalculadora()
        {
            InitializeComponent();
        }

        #region Metodos

        /// <summary>
        /// Reestablecera los datos de los TextBox, ComboBox y Label de la pantalla a su valor inicial 
        /// (TextBox y ComboBox a string vacio y label a 0).
        /// </summary>
        private void Limpiar()
        {
            txtNumero1.Clear();
            txtNumero2.Clear();
            cmbOperador.SelectedIndex = 0;
            lblResultado.Text = "0";
        }

        /// <summary>
        /// Realiza la operacion entre 2 numeros segun el operador recibido
        /// </summary>
        /// <param name="operador1"></param>
        /// <param name="operador2"></param>
        /// <param name="operador"></param>
        /// <returns> Retorna en caso de exito, el resultado de la operacion. </returns>
        private static double Operar(string numero1, string numero2, string operador)
        {
            double retorno = 0;
            if (!string.IsNullOrEmpty(numero1) && !string.IsNullOrEmpty(numero2))
            {
                Operando num1 = new Operando(numero1);
                Operando num2 = new Operando(numero2);
                char.TryParse(operador, out char charOperador);
                retorno = Calculadora.Operar(num1, num2, charOperador);
            }

            return retorno;
        }

        /// <summary>
        /// Activa los botones "Convertir a Binario" y "Convertir a Decimal"
        /// </summary>
        private void ActivarBotonesConversores()
        {
            btnConvertirABinario.Enabled = true;
            btnConvertirADecimal.Enabled = true;
        }

        #endregion

        #region Eventos

        /// <summary>
        /// Carga el Windows Forms de Calculadora con los valores por defecto.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FormCalculadora_Load(object sender, EventArgs e)
        {
            Limpiar();
        }

        /// <summary>
        /// Evento para reestrablecer los valores por defecto del Forms de Calculadora.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            Limpiar();
        }

        /// <summary>
        /// Evento que realiza la operacion entre los numeros ingresados segun el operando seleccionado.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnOperar_Click(object sender, EventArgs e)
        {
            StringBuilder stringCalculo = new StringBuilder();

            if (!string.IsNullOrEmpty(txtNumero1.Text) && !string.IsNullOrEmpty(txtNumero2.Text) && double.TryParse(txtNumero1.Text, out double numero1) && double.TryParse(txtNumero2.Text, out double numero2))
            {
                lblResultado.Text = FormCalculadora.Operar(txtNumero1.Text, txtNumero2.Text, cmbOperador.Text).ToString();

                if (cmbOperador.Text == "")
                {
                    cmbOperador.SelectedIndex = 1;
                }

                stringCalculo.AppendLine($"{numero1} {cmbOperador.Text} {numero2} = {lblResultado.Text}");
                lstOperaciones.Items.Add(stringCalculo);
                ActivarBotonesConversores();

                if (txtNumero2.Text == "0" && cmbOperador.SelectedIndex == 3)
                {
                    MessageBox.Show("No se puede dividir por cero, reingrese los datos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("No se puede realizar la operacion, reingrese los datos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Evento que devuelve el numero que se encuentra actualmente en el label del resultado en binario, (en caso de que sea decimal). Tambien lo muestra en en la lista.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnConvertirABinario_Click(object sender, EventArgs e)
        {
            if (lblResultado.Text != "Valor inválido")
            {
                Operando decimalBinario = new Operando();
                StringBuilder sb = new StringBuilder();

                string resultado = decimalBinario.DecimalBinario(lblResultado.Text);
                lblResultado.Text = resultado;
                sb.AppendLine($"Decimal a binario = {resultado}");
                lstOperaciones.Items.Add(sb.ToString());

                btnConvertirABinario.Enabled = false;
            }
        }

        /// <summary>
        /// Evento que devuelve el numero que se encuentra actualmente en el label del resultado en binario, (en caso de que sea binario). Tambien lo muestra en en la lista.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnConvertirADecimal_Click(object sender, EventArgs e)
        {
            if (lblResultado.Text != "Valor inválido")
            {
                Operando binarioDecimal = new Operando();
                StringBuilder sb = new StringBuilder();

                string resultado = binarioDecimal.BinarioDecimal(lblResultado.Text);
                lblResultado.Text = resultado;
                sb.AppendLine($"Binario a decimal = {resultado}");
                lstOperaciones.Items.Add(sb.ToString());

                btnConvertirADecimal.Enabled = false;
            }
        }

        /// <summary>
        /// Evento que cierra el Windows Forms de Calculadora.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// Asegura si el usuario desea cerrar el Windows Forms de Calculadora, pidiendole su confirmacion.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FormCalculadora_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("¿Seguro de querer salir?", "Salir", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
            {
                e.Cancel = true;
            }
        }

        #endregion
    }
}
