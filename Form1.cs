using System;
using System.Drawing;
using System.Windows.Forms;

namespace CalculadoraCientificaNova
{
    public partial class Form1 : Form
    {
        private double valorAnterior = 0;
        private string operacaoPendente = "";
        private bool novaOperacao = true;

        private TextBox txtVisor;
        private Button btn0, btn1, btn2, btn3, btn4, btn5, btn6, btn7, btn8, btn9;
        private Button btnSoma, btnSubtracao, btnMultiplicacao, btnDivisao;
        private Button btnRaiz, btnPotencia, btnIgual, btnClear;

        public Form1()
        {
            InitializeComponent();
            CriarCalculadora();
        }

        private void CriarCalculadora()
        {
            // Configurar formulário
            this.Text = "Calculadora Científica";
            this.Size = new Size(400, 500);
            this.StartPosition = FormStartPosition.CenterScreen;

            // Menu
            MenuStrip menuStrip = new MenuStrip();
            ToolStripMenuItem sobreMenu = new ToolStripMenuItem("Sobre");
            sobreMenu.Click += (s, e) => {
                FormSobre formSobre = new FormSobre();
                formSobre.ShowDialog();
            };
            menuStrip.Items.Add(sobreMenu);
            this.Controls.Add(menuStrip);
            this.MainMenuStrip = menuStrip;

            // Visor
            txtVisor = new TextBox();
            txtVisor.Text = "0";
            txtVisor.TextAlign = HorizontalAlignment.Right;
            txtVisor.Font = new Font("Microsoft Sans Serif", 14F);
            txtVisor.ReadOnly = true;
            txtVisor.Location = new Point(20, 40);
            txtVisor.Size = new Size(340, 40);
            this.Controls.Add(txtVisor);

            // Criar botões numéricos
            btn1 = CriarBotao("1", 20, 100); btn1.Click += (s, e) => AdicionarNumero("1");
            btn2 = CriarBotao("2", 90, 100); btn2.Click += (s, e) => AdicionarNumero("2");
            btn3 = CriarBotao("3", 160, 100); btn3.Click += (s, e) => AdicionarNumero("3");
            btn4 = CriarBotao("4", 20, 160); btn4.Click += (s, e) => AdicionarNumero("4");
            btn5 = CriarBotao("5", 90, 160); btn5.Click += (s, e) => AdicionarNumero("5");
            btn6 = CriarBotao("6", 160, 160); btn6.Click += (s, e) => AdicionarNumero("6");
            btn7 = CriarBotao("7", 20, 220); btn7.Click += (s, e) => AdicionarNumero("7");
            btn8 = CriarBotao("8", 90, 220); btn8.Click += (s, e) => AdicionarNumero("8");
            btn9 = CriarBotao("9", 160, 220); btn9.Click += (s, e) => AdicionarNumero("9");
            btn0 = CriarBotao("0", 20, 280, 130, 50); btn0.Click += (s, e) => AdicionarNumero("0");

            // Botões de operação
            btnSoma = CriarBotao("+", 230, 100); btnSoma.Click += (s, e) => PrepararOperacao("+");
            btnSubtracao = CriarBotao("-", 230, 160); btnSubtracao.Click += (s, e) => PrepararOperacao("-");
            btnMultiplicacao = CriarBotao("×", 230, 220); btnMultiplicacao.Click += (s, e) => PrepararOperacao("×");
            btnDivisao = CriarBotao("÷", 230, 280); btnDivisao.Click += (s, e) => PrepararOperacao("÷");

            // Botões especiais
            btnRaiz = CriarBotao("√", 300, 100); btnRaiz.Click += (s, e) => CalcularRaiz();
            btnPotencia = CriarBotao("x^y", 300, 160); btnPotencia.Click += (s, e) => PrepararOperacao("^");
            btnIgual = CriarBotao("=", 300, 220); btnIgual.Click += (s, e) => CalcularResultado();
            btnClear = CriarBotao("C", 300, 280); btnClear.Click += (s, e) => Limpar();
        }

        private Button CriarBotao(string texto, int x, int y, int largura = 60, int altura = 50)
        {
            Button btn = new Button();
            btn.Text = texto;
            btn.Location = new Point(x, y);
            btn.Size = new Size(largura, altura);
            btn.Font = new Font("Microsoft Sans Serif", 12F);
            this.Controls.Add(btn);
            return btn;
        }

        private void AdicionarNumero(string numero)
        {
            if (novaOperacao || txtVisor.Text == "0")
            {
                txtVisor.Text = numero;
                novaOperacao = false;
            }
            else
            {
                txtVisor.Text += numero;
            }
        }

        private void PrepararOperacao(string operacao)
        {
            valorAnterior = double.Parse(txtVisor.Text);
            operacaoPendente = operacao;
            novaOperacao = true;
        }

        private void CalcularResultado()
        {
            if (!string.IsNullOrEmpty(operacaoPendente))
            {
                double valorAtual = double.Parse(txtVisor.Text);
                double resultado = 0;

                switch (operacaoPendente)
                {
                    case "+": resultado = valorAnterior + valorAtual; break;
                    case "-": resultado = valorAnterior - valorAtual; break;
                    case "×": resultado = valorAnterior * valorAtual; break;
                    case "÷":
                        if (valorAtual != 0)
                            resultado = valorAnterior / valorAtual;
                        else
                            MessageBox.Show("Erro: Divisão por zero!");
                        break;
                    case "^": resultado = Math.Pow(valorAnterior, valorAtual); break;
                }

                txtVisor.Text = resultado.ToString();
                operacaoPendente = "";
                novaOperacao = true;
            }
        }

        private void CalcularRaiz()
        {
            double valor = double.Parse(txtVisor.Text);
            if (valor >= 0)
            {
                txtVisor.Text = Math.Sqrt(valor).ToString();
            }
            else
            {
                MessageBox.Show("Erro: Não é possível calcular raiz de número negativo!");
            }
            novaOperacao = true;
        }

        private void Limpar()
        {
            txtVisor.Text = "0";
            valorAnterior = 0;
            operacaoPendente = "";
            novaOperacao = true;
        }
    }
}