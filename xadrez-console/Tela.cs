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
