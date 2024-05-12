using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PasseioCavalo.Classes
{
    internal class Imprimir
    {
        public static void imprimirTabuleiro(Tabuleiro tab, int[,] posicoes)
        {
            
            for (int i = 0; i < tab.Linhas; i++)
            {
                ConsoleColor aux1 = Console.ForegroundColor;
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.Write(5 - i + " ");
                Console.ForegroundColor = aux1;

                for (int j = 0; j < tab.Colunas; j++)
                {
                    Console.Write(posicoes[i, j]+ " ");
                }
                Console.WriteLine();
            }
            ConsoleColor aux = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("  A  B  C  D  E");
            Console.ForegroundColor = aux;
        }
    }
}
