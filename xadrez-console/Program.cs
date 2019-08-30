using System;
using tabuleiro;
using xadrez;

namespace xadrez_console
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Tabuleiro tab = new Tabuleiro(8, 8);

                tab.colocarPeca(new Torre(Cor.Preta, tab), new Posicao(0, 0)); // peça desejada na posição desejada no tabuleiro
                tab.colocarPeca(new Torre(Cor.Preta, tab), new Posicao(1, 9));
                tab.colocarPeca(new Rei(Cor.Preta, tab), new Posicao(0, 2));

                Tela.imprimirTabuleiro(tab);
            }
            catch (TabuleiroException e)
            {
                Console.WriteLine(e.Message);
            }
            
        }
    }
}
