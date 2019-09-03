using System;
using tabuleiro;

namespace xadrez
{
    class PartidaDeXadrez
    {
        public Tabuleiro tab { get; private set; } // não permite o programador modificar o tabuleiro fora dessa classe
        private int turno;
        private Cor jogadorAtual;
        public bool terminada { get; private set; }// diz se uma partida já foi terminada

        public PartidaDeXadrez()
        {
            tab = new Tabuleiro(8, 8);
            turno = 1; // ni inicio de uma partida o turno vale 1
            jogadorAtual = Cor.Branca; // no inicio de uma partida quem começa são sempre as brancas
            terminada = false; // no inicio de uma partida ela não está terminada
            colocarPecas();
        }

        public void executaMovimento(Posicao origem, Posicao destino)
        {
            Peca p = tab.retirarPeca(origem); // para movimentar a peça tem que rtirar ela da origem
            p.incrementarQteMovimentos(); // incrementa 1 na quantidade de movimentos da peça
            Peca pecaCapturada = tab.retirarPeca(destino); // retirar a peça que estiver ocupando a posição de destino para que a peça desejada possa ocupar
            tab.colocarPeca(p, destino); // a peça é inserida no destino
        }

        private void colocarPecas()
        {
            tab.colocarPeca(new Torre(Cor.Branca, tab), new PosicaoXadrez('c',1).toPosicao()); // peça desejada na posição desejada no tabuleiro
            tab.colocarPeca(new Torre(Cor.Branca, tab), new PosicaoXadrez('c', 2).toPosicao());
            tab.colocarPeca(new Torre(Cor.Branca, tab), new PosicaoXadrez('d', 2).toPosicao());
            tab.colocarPeca(new Torre(Cor.Branca, tab), new PosicaoXadrez('e', 2).toPosicao());
            tab.colocarPeca(new Torre(Cor.Branca, tab), new PosicaoXadrez('e', 1).toPosicao());
            tab.colocarPeca(new Rei(Cor.Branca, tab), new PosicaoXadrez('d', 1).toPosicao());

            tab.colocarPeca(new Torre(Cor.Preta, tab), new PosicaoXadrez('c', 7).toPosicao()); 
            tab.colocarPeca(new Torre(Cor.Preta, tab), new PosicaoXadrez('c', 8).toPosicao());
            tab.colocarPeca(new Torre(Cor.Preta, tab), new PosicaoXadrez('d', 7).toPosicao());
            tab.colocarPeca(new Torre(Cor.Preta, tab), new PosicaoXadrez('e', 7).toPosicao());
            tab.colocarPeca(new Torre(Cor.Preta, tab), new PosicaoXadrez('e', 8).toPosicao());
            tab.colocarPeca(new Rei(Cor.Preta, tab), new PosicaoXadrez('d', 8).toPosicao());

        }
    }
}
