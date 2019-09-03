using tabuleiro;
using System;
namespace xadrez_console
{
    class Tela
    {
        public static void imprimirTabuleiro(Tabuleiro tab)
        {
            System.Console.WriteLine("  ╔═════════════════╗");
            for(int i=0; i < tab.linhas; i++)
            {
                System.Console.Write(8 - i + " ║ ");
                for (int j=0; j < tab.colunas; j++)
                {
                    if(tab.peca(i,j) == null)
                    {
                        System.Console.Write("- ");
                    }
                    else
                    {
                        //System.Console.Write(tab.peca(i, j) + " ");
                        imprimirPeca(tab.peca(i, j));
                        Console.Write(" ");
                    }
                    
                }
                System.Console.Write("║");
                System.Console.WriteLine();
            }
            System.Console.WriteLine("  ╚═════════════════╝");
            System.Console.WriteLine("    a b c d e f g h");
        }

        public static void imprimirPeca(Peca peca)
        {
            if (peca.cor == Cor.Branca)
            {
                System.Console.Write(peca);
            }
            else
            {
                ConsoleColor aux = Console.ForegroundColor;
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write(peca);
                Console.ForegroundColor = aux;
            }
        }
    }
}
