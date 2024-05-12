using PasseioCavalo.Classes;
using System.Security.Cryptography.X509Certificates;

namespace PasseioCavalo
{
    internal class Program
    {


        public static int menu()
        {

           Console.WriteLine("\nSelecione uma opção: \n");
          Console.WriteLine("1 - Mostrar a solução completa do tabuleiro");
          Console.WriteLine("2 - Mostrar apenas a solução final");
          Console.WriteLine("0 - Fechar\n\n");
          int resposta = int.Parse(Console.ReadLine());
          return resposta;
        }

        static void Main(string[] args)
        {
            Tabuleiro xadrez = new Tabuleiro(5,5); // Tamanho do tabuleiro
            Cavalo cavalo = new Cavalo(xadrez);
            CavaloExibicaoTotal cavaloTotal = new CavaloExibicaoTotal(xadrez);

            int variavel;

            Console.WriteLine("\nUMA BREVE EXPLICAÇÃO:\nA execução de todo o passo a passo de um tabuleiro 8x8 é mais demorada que as demais. \nDiante disso, optei por manter" +
               " um tabuleiro 5x5 para uma \nexecução mais rápida caso a opção escolhida seja a 1.");

            Console.WriteLine("\nA execução levará menos de 1 minuto\n");

            do
            {
                variavel = menu();
                switch (variavel)
                {
                    case 1:
                       // Console.WriteLine("");
                        cavaloTotal.ResolverPasseioCavaloTotal();
                        break;

                    case 2:
                        cavalo.ResolverPasseioCavalo();
                        break;

                    case 0:
                        Console.WriteLine("\nEncerrando....");
                    break;

                    default:
                        Console.WriteLine("\nOpção inválida");
                        break;

                }

            } while (variavel != 0) ;

           


        }
    }
}
