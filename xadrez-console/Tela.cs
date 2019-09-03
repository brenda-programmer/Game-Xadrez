using tabuleiro;
using System;
using xadrez;

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
                   imprimirPeca(tab.peca(i, j));
                }
                System.Console.Write("║");
                System.Console.WriteLine();
            }
            System.Console.WriteLine("  ╚═════════════════╝");
            System.Console.WriteLine("    a b c d e f g h");
        }

        //Sobrecarga do método imprimirTabuleiro
        public static void imprimirTabuleiro(Tabuleiro tab, bool[,] posicoesPossiveis)
        {
            ConsoleColor fundoOriginal = Console.BackgroundColor; // guarda a cor de fundo atual
            ConsoleColor fundoAlterado = ConsoleColor.DarkGray; // guarda a cor cinza escuro

            System.Console.WriteLine("  ╔═════════════════╗");
            for (int i = 0; i < tab.linhas; i++)
            {
                System.Console.Write(8 - i + " ║ ");
                
                for (int j = 0; j < tab.colunas; j++)
                {
                    if (posicoesPossiveis[i, j]) // se a posição na matriz posicoesPossiveis for true
                    {
                        Console.BackgroundColor = fundoAlterado; // o fundo recebe cinza escuro
                    }
                    else
                    {
                        Console.BackgroundColor = fundoOriginal;// caso seja uma posição false na matriz, ela recebe a cor de fundo original
                    }

                    imprimirPeca(tab.peca(i, j));
                    Console.BackgroundColor = fundoOriginal; // depois que imprimir a peça tem que colocar o fundo original denovo
                }
                System.Console.Write("║");
                System.Console.WriteLine();
            }
            System.Console.WriteLine("  ╚═════════════════╝");
            System.Console.WriteLine("    a b c d e f g h");
            Console.BackgroundColor = fundoOriginal; // garante que a cor de fundo volte para original
        }


        //Vai ler a posição que o usuário digitar
        public static PosicaoXadrez lerPosicaoXadrez()
        {
            string s = Console.ReadLine();
            char coluna = s[0];//pega somente o que estiver na string na posição zero
            int linha = int.Parse(s[1] + ""); // pega somente o que tem na string na posição 1 e transforma para inteiro (concatena com o espaço para forçar que é string)
            return new PosicaoXadrez(coluna, linha);
        }

        public static void imprimirPeca(Peca peca)
        {
            if(peca == null)
            {
                System.Console.Write("- ");
            }
            else
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

                Console.Write(" ");
            }

            
        }
    }
}
