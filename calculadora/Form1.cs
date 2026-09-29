using System.Globalization;

namespace calculadora
{
public partial class Form1 : Form
{
        decimal valor1 = 0, valor2 = 0;
        string operacao = "";

        // cultura brasileira: usa virgula como separador decimal
        CultureInfo ptBR = new CultureInfo("pt-BR");

        // Indica se o ultimo comando foi o botao =
        bool novoCalculo = false;

        public Form1()
        {
            InitializeComponent();
        }

        private void btnZero_Click(object sender, EventArgs e)
        {
            AdicionarNumero("0");
        }

        private void txtResultado_TextChanged(object sender, EventArgs e)
        {

        }

        // numeros 
        private void AdicionarNumero(string numero)
        {

            // se acabou de calcular, comeca um novo numero
            if (novoCalculo)
            {
                txtResultado.Text = "";
                novoCalculo = false;
            }
            txtResultado.Text += numero;
        }

        private void btnUm_Click(object sender, EventArgs e)
        {
            AdicionarNumero("1");
        }

        private void btnDois_Click(object sender, EventArgs e)
        {
            AdicionarNumero("2");
        }

        private void btnTres_Click(object sender, EventArgs e)
        {
            AdicionarNumero("3");
        }

        private void btnQuatro_Click(object sender, EventArgs e)
        {
            AdicionarNumero("4");
        }

        private void btnCinco_Click(object sender, EventArgs e)
        {
            AdicionarNumero("5");
        }

        private void btnSeis_Click(object sender, EventArgs e)
        {
            AdicionarNumero("6");
        }

        private void btnSete_Click(object sender, EventArgs e)
        {
            AdicionarNumero("7");
        }

        private void btnOito_Click(object sender, EventArgs e)
        {
            AdicionarNumero("8");
        }

        private void btnNove_Click(object sender, EventArgs e)
        {
            AdicionarNumero("9");
        }
    

 // VÍRGULA
private void btnVirgula_Click(object sender, EventArgs e)
        {
            // Se acabou de calcular, começa um novo número
            if (novoCalculo)
            {
                txtResultado.Text = "";
                novoCalculo = false;
            }

            // Não permite duas vírgulas
            if (!txtResultado.Text.Contains(","))
            {

                // Se clicar na vírgula sem nenhum número,
                // começa com 0,

                if (txtResultado.Text == "")
                {
                    txtResultado.Text = "0,";
                }

                else
                {
                    txtResultado.Text += ",";
                }

            }
        }


        // RETROCEDER
        private void btnRetroceder_Click(object sender, EventArgs e)
        {
            if (txtResultado.Text.Length > 0)
            {
                txtResultado.Text =
                   txtResultado.Text.Remove(txtResultado.Text.Length - 1);
            }
        }

        // OPERAÇÕES
        private void btnAdicao_Click(object sender, EventArgs e)
        {
            if (txtResultado.Text != "")
            {
                valor1 = decimal.Parse(txtResultado.Text, ptBR);

                txtResultado.Text = "";

                operacao = "SOMA";

                lblOperacao.Text = "+";

                novoCalculo = false;
            }
        }

        private void btnSubtracao_Click(object sender, EventArgs e)
        {
            if (txtResultado.Text != "")
            {
                valor1 = decimal.Parse(txtResultado.Text, ptBR);

                txtResultado.Text = "";

                operacao = "SUB";

                lblOperacao.Text = "-";

                novoCalculo = false;
            }
        }

        private void btnMultiplicacao_Click(object sender, EventArgs e)
        {
            if (txtResultado.Text != "")
            {
                valor1 = decimal.Parse(txtResultado.Text, ptBR);

                txtResultado.Text = "";

                operacao = "MULT";

                lblOperacao.Text = "*";

                novoCalculo = false;
            }
        }


        private void btnDivisao_Click(object sender, EventArgs e)
        {
            if (txtResultado.Text != "")
            {
                valor1 = decimal.Parse(txtResultado.Text, ptBR);

                txtResultado.Text = "";

                operacao = "DIV";

                lblOperacao.Text = "/";

                novoCalculo = false;
            }
        }

        // IGUAL
        private void btnIgual_Click(object sender, EventArgs e)
        {
            if (txtResultado.Text != "" && operacao != "")
            {
                valor2 = decimal.Parse(txtResultado.Text, ptBR);

                decimal resultado = 0;

                if (operacao == "SOMA")
                {
                    resultado = valor1 + valor2;
                }
                else if (operacao == "SUB")
                {
                    resultado = valor1 - valor2;
                }
                else if (operacao == "MULT")
                {
                    resultado = valor1 * valor2;
                }
                else if (operacao == "DIV")
                {
                    // Impede divisão por zero
                    if (valor2 == 0)
                    {
                        MessageBox.Show(
                        "Não é possível dividir por zero.",
                        "Erro",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error
                       );
                        return;
                    }

                    resultado = valor1 / valor2;
                }

                // Mostra o resultado usando a cultura brasileira
                txtResultado.Text = resultado.ToString(ptBR);

                // Limpa a operação exibida
                lblOperacao.Text = "";

                // Indica que acabamos de calcular
                novoCalculo = true;
            }
        }

        // LIMPAR TUDO - C
        private void btnLimpar_Click(object sender, EventArgs e)
        {
            txtResultado.Text = "";

            valor1 = 0;
            valor2 = 0;

            operacao = "";

            lblOperacao.Text = "";

            novoCalculo = false;
        }

        // LIMPAR ENTRADA - CE
        private void btnCE_Click(object sender, EventArgs e)
        {
            txtResultado.Text = "";
            novoCalculo = false;
        }  
    }
}

