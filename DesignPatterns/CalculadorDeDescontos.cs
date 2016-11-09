﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns
{
    public class CalculadorDeDescontos
    {

        public IList<Desconto> Descontos { get; private set; }

        public double Calcula(Orcamento orcamento)
        {
            //-- Adicionar os tipos de descontos existentes a lista para serem encadeados
            this.Descontos.Add(new DescontoPorCincoItens() );
            this.Descontos.Add(new DescontoPorMaisDeQuinhentosReais() );

            this.Descontos.Add(new SemDesconto() ); //-- Importante! Deve ser o último!

            //-- Definir a cadeia de execução dos descontos.
            for ( int contador = 0; contador < Descontos.Count; contador++)
            {
                //-- Verificar se não é último desconto ( Sem desconto )
                if ( contador + 1 < Descontos.Count) 
                {
                    //-- Definir que o próximo item da lista é o desconto a ser executado
                    Descontos[contador].Proximo = Descontos[contador + 1];
                }
            }

            //-- Executar o primeiro desconto e os demais serão executados em cadeia
            return Descontos[0].Desconta(orcamento);
        }
    }
}
