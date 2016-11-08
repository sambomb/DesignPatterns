﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DesignPatterns
{
    public partial class FormPrincipal : Form
    {
        public CalculadorDeImposto calculadora = new CalculadorDeImposto();
        public RealizadorDeInvestimentos calculadorInvestimento = new RealizadorDeInvestimentos();

        public FormPrincipal()
        {
            InitializeComponent();
        }

        private void buttonICMS_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Imposto ICMS: " + calculadora.Calcula( new Orcamento(Convert.ToDouble(textValor.Text)),
                                                                    new ICMS() ) );
        }

        private void buttonISS_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Imposto ISS: " + calculadora.Calcula(  new Orcamento(Convert.ToDouble(textValor.Text)),
                                                                    new ISS() ) );
        }

        private void buttonICCC_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Imposto ICCC: " + calculadora.Calcula( new Orcamento(Convert.ToDouble(textValor.Text)),    
                                                                    new ICCC() ) );
        }

        private void buttonSair_Click(object sender, EventArgs e)
        {
            FormPrincipal.ActiveForm.Close();
        }

        private void buttonConservador_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Após investimento conservador: " + 
                            calculadorInvestimento.Calculo(Convert.ToDouble(textValor.Text),
                            new Conservador()));         
        }

        private void buttonModerado_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Após investimento moderado: " +
                            calculadorInvestimento.Calculo(Convert.ToDouble(textValor.Text),
                            new Moderado()));
        }

        private void buttonArrojado_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Após investimento arrojado: " +
                            calculadorInvestimento.Calculo(Convert.ToDouble(textValor.Text),
                            new Arrojado()));
        }
    }
}