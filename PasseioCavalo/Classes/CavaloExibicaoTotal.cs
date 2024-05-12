using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PasseioCavalo.Classes
{
    internal class CavaloExibicaoTotal
    {

        //8 movimentos possiveis em cada posição
        private int[,] movimentosPossiveis = { { -2, 1 }, { -1, 2 }, { 1, 2 }, { 2, 1 }, { 2, -1 }, { 1, -2 }, { -1, -2 }, { -2, -1 } };
        private Tabuleiro tab;
        private int[,] posicoes;

        public CavaloExibicaoTotal(Tabuleiro tabuleiro)
        {
            tab = tabuleiro;
            posicoes = new int[tab.Linhas, tab.Colunas];
        }


        public void ResolverPasseioCavaloTotal()
        {
            // Inicia o cavalo no meio do tabuleiro
            int linhaInicial = tab.Linhas / 2;
            int colunaInicial = tab.Colunas / 2;
            posicoes[linhaInicial, colunaInicial] = 1; //primeiro valor

            Imprimir.imprimirTabuleiro(tab, posicoes); //imprime o tabuleiro inicial

            if (ResolverRecursivoTotal(linhaInicial, colunaInicial, 2)) //começa com o segundo valor (proximoMovimento)
            {
                //caso encontre a solução do problema, imprime
                Console.WriteLine("\nSolução encontrada:\n");
                Imprimir.imprimirTabuleiro(tab, posicoes);
            }
            else
            {
                Console.WriteLine("\nNão foi possível encontrar uma solução.");
            }
        }




        private bool ResolverRecursivoTotal(int linhaAtual, int colunaAtual, int proximoMovimento)
        {
            if (proximoMovimento > tab.Linhas * tab.Colunas)
            {
                return true; // Todas as casas foram visitadas
            }

            for (int i = 0; i < movimentosPossiveis.GetLength(0); i++)
            {
                //verifica por onde o cavalo pode se mover atualmente
                int proximaLinha = linhaAtual + movimentosPossiveis[i, 0];
                int proximaColuna = colunaAtual + movimentosPossiveis[i, 1];

                // Verifica se o próximo movimento está dentro dos limites do tabuleiro e se a posição ainda não foi visitada
                if (proximaLinha >= 0 && proximaLinha < tab.Linhas &&
                    proximaColuna >= 0 && proximaColuna < tab.Colunas &&
                    posicoes[proximaLinha, proximaColuna] == 0)
                {
                    // Marca a próxima posição como visitada
                    posicoes[proximaLinha, proximaColuna] = proximoMovimento;

                    // Imprime o tabuleiro após cada movimento
                    Imprimir.imprimirTabuleiro(tab, posicoes);
                    Console.WriteLine();

                    // Tenta resolver recursivamente a partir da próxima posição. Adiona mais um na contagem do próximo movimento
                    if (ResolverRecursivoTotal(proximaLinha, proximaColuna, proximoMovimento + 1))
                    {
                        return true;
                    }

                    // Se não foi possível encontrar uma solução a partir desta posição, desfaz a marcação
                    posicoes[proximaLinha, proximaColuna] = 0;
                }
            }

            return false; // Não foi possível encontrar uma solução a partir desta posição
        }


    }
}
