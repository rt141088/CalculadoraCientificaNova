using System;
using System.Drawing;
using System.Windows.Forms;

namespace CalculadoraCientificaNova
{
    public partial class FormSobre : Form
    {
        public FormSobre()
        {
            InitializeComponent();
            CriarFormSobre();
        }

        private void CriarFormSobre()
        {
            // Configurar o formulário Sobre
            this.Text = "Sobre a Calculadora";
            this.Size = new Size(450, 400);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.BackColor = Color.LightGray;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;

            // Título
            Label lblTitulo = new Label();
            lblTitulo.Text = "Calculadora Científica FIAP";
            lblTitulo.Font = new Font("Arial", 18F, FontStyle.Bold);
            lblTitulo.ForeColor = Color.DarkBlue;
            lblTitulo.Location = new Point(50, 30);
            lblTitulo.Size = new Size(350, 40);
            lblTitulo.TextAlign = ContentAlignment.MiddleCenter;
            this.Controls.Add(lblTitulo);

            // Descrição
            Label lblDescricao = new Label();
            lblDescricao.Text = "Calculadora científica desenvolvida para o Checkpoint 1\n" +
                               "da disciplina de Programação em C# e .NET.\n\n" +
                               "Este projeto inclui operações básicas e funções\n" +
                               "científicas como raiz quadrada e potenciação.";
            lblDescricao.Font = new Font("Arial", 11F);
            lblDescricao.Location = new Point(50, 90);
            lblDescricao.Size = new Size(350, 120);
            lblDescricao.TextAlign = ContentAlignment.MiddleCenter;
            lblDescricao.BackColor = Color.White;
            lblDescricao.BorderStyle = BorderStyle.FixedSingle;
            this.Controls.Add(lblDescricao);

            // Desenvolvedores - COM OS DADOS REAIS
            Label lblDevs = new Label();
            lblDevs.Text = "DESENVOLVIDO POR:\n\n" +
                          "• Rafael Terra Teodoro - RM:560955\n" +
                          "• Enzo Elia Tarraga - RM:560901\n" +
                          "• Otoniel Arantes Barbado - RM:560112";
            lblDevs.Font = new Font("Arial", 12F, FontStyle.Bold);
            lblDevs.ForeColor = Color.DarkGreen;
            lblDevs.Location = new Point(50, 230);
            lblDevs.Size = new Size(350, 120);
            lblDevs.TextAlign = ContentAlignment.MiddleCenter;
            lblDevs.BackColor = Color.LightYellow;
            lblDevs.BorderStyle = BorderStyle.FixedSingle;
            this.Controls.Add(lblDevs);

            // Botão Fechar
            Button btnFechar = new Button();
            btnFechar.Text = "FECHAR";
            btnFechar.Font = new Font("Arial", 10F, FontStyle.Bold);
            btnFechar.Location = new Point(175, 360);
            btnFechar.Size = new Size(100, 35);
            btnFechar.BackColor = Color.LightBlue;
            btnFechar.ForeColor = Color.DarkBlue;
            btnFechar.Click += (s, e) => this.Close();
            this.Controls.Add(btnFechar);
        }
    }
}
