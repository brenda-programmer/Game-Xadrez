using tabuleiro;
namespace xadrez
{
    class Cavalo : Peca // Cavalo é uma subclasse de Peca
    {
        public Cavalo(Cor cor, Tabuleiro tab)
            : base(cor, tab) // repassa a cor e o tab para o construtor da superclasse Peca
        {

        }

        public override string ToString()
        {
            return "C";
        }

        // método que diz se a peça pode mover para determinada posição ou não
        private bool podeMover(Posicao pos)
        {
            Peca p = tab.peca(pos);
            return p == null || p.cor != cor; // se a peça for null significa que a posição está livre OU se a peça desta posição possuir uma cor diferente desta peça (se a peça é adversária)
        }


        //Implementando a classe abstrata da super classe
        public override bool[,] movimentosPossiveis() // retirar abstract pois a classe agora é concreta e usar override para indicar que está sobreescrevendo o método da super classe
        {
            bool[,] mat = new bool[tab.linhas, tab.colunas]; // é criada uma matriz para indicar os movimentos que são possíveis para esta peça dentro do tabuleiro


            Posicao pos = new Posicao(0, 0); //inicia uma posição


            /*AGORA INICIA A MARCAÇÃO DE TODAS AS POSSÍVEIS CASAS EM QUE O CAVALO PODE SE MOVER DENTRO DA MATRIZ*/


            // DIREÇÃO SUL/OESTE - acessa 1 casa que está acima do cavalo e 2 casas à esquerda, esta passa a ser a posição pos
            pos.definirValores(posicao.linha - 1, posicao.coluna - 2);

            if (tab.posicaoValida(pos) && podeMover(pos)) // se a posição for valida e se a peça pode ser movida...
            {
                mat[pos.linha, pos.coluna] = true; // ...esta posição na matriz de movimentos fica true.
            }


            // DIREÇÃO SUL/OESTE - acessa 2 casas que está acima do cavalo e 1 casa à esquerda, esta passa a ser a posição pos
            pos.definirValores(posicao.linha - 2, posicao.coluna -1 );

            if (tab.posicaoValida(pos) && podeMover(pos))
            {
                mat[pos.linha, pos.coluna] = true;
            }


            // DIREÇÃO SUL/LESTE - acessa 2 casas que está acima do cavalo  e 1 casa à direita, esta passa a ser a posição pos
            pos.definirValores(posicao.linha - 2, posicao.coluna + 1);

            if (tab.posicaoValida(pos) && podeMover(pos))
            {
                mat[pos.linha, pos.coluna] = true;
            }


            // DIREÇÃO SUL/LESTE - acessa 1 casa que está acima do cavalo e 2 casas à direita, esta passa a ser a posição pos
            pos.definirValores(posicao.linha - 1, posicao.coluna + 2);

            if (tab.posicaoValida(pos) && podeMover(pos))
            {
                mat[pos.linha, pos.coluna] = true;
            }


            // DIREÇÃO NORTE/LESTE - acessa 1 casa que está abaixo do cavalo e 2 casas à direita, esta passa a ser a posição pos
            pos.definirValores(posicao.linha + 1, posicao.coluna + 2);

            if (tab.posicaoValida(pos) && podeMover(pos)) // se a posição for valida e se a peça pode ser movida...
            {
                mat[pos.linha, pos.coluna] = true; // ...esta posição na matriz de movimentos fica true.
            }


            // DIREÇÃO NORTE/LESTE - acessa 2 casas que está abaixo do cavalo e 1 casa à direita, esta passa a ser a posição pos
            pos.definirValores(posicao.linha + 2, posicao.coluna + 1);

            if (tab.posicaoValida(pos) && podeMover(pos)) // se a posição for valida e se a peça pode ser movida...
            {
                mat[pos.linha, pos.coluna] = true; // ...esta posição na matriz de movimentos fica true.
            }


            // DIREÇÃO NORTE/OESTE - acessa 2 casas que está abaixo do cavalo e 1 casa à esquerda, esta passa a ser a posição pos
            pos.definirValores(posicao.linha + 2, posicao.coluna - 1);

            if (tab.posicaoValida(pos) && podeMover(pos)) // se a posição for valida e se a peça pode ser movida...
            {
                mat[pos.linha, pos.coluna] = true; // ...esta posição na matriz de movimentos fica true.
            }


            // DIREÇÃO NORTE/OESTE - acessa 1 casa que está abaixo do cavalo e 2 casas à esquerda, esta passa a ser a posição pos
            pos.definirValores(posicao.linha + 1, posicao.coluna - 2);

            if (tab.posicaoValida(pos) && podeMover(pos)) // se a posição for valida e se a peça pode ser movida...
            {
                mat[pos.linha, pos.coluna] = true; // ...esta posição na matriz de movimentos fica true.
            }


            return mat; // no final retorna a matriz com todos os possíveis movimentos do cavalo.

        }
    }
}
