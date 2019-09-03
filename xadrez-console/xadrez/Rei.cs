using tabuleiro;
namespace xadrez
{
    class Rei : Peca // Rei é uma subclasse de Peca
    {
        public Rei(Cor cor, Tabuleiro tab)
            : base(cor, tab) // repassa a cor e o tab para o construtor da superclasse Peca
        {

        }

        public override string ToString()
        {
            return "R";
        }

        // método que diz se oa peça pode mover para determinada posição ou não
        private bool podeMover(Posicao pos)
        {
            Peca p = tab.peca(pos);
            return p == null || p.cor != cor; // se a peça for null significa que a posição está livre OU se a peça desta posição possuir uma cor diferente desta peça (se a peça é adversária)
        }


        //Implementando a classe abstrata da super classe
        public override bool[,] movimentosPossiveis() // retirar abstract pois a classe agora é concreta e usar override para indicar que está sobreescrevendo o método da super classe
        {
            bool[,] mat = new bool[tab.linhas,tab.colunas]; // é criada uma matriz para indicar os movimentos que são possíveis para esta peça dentro do tabuleiro


            Posicao pos = new Posicao(0, 0); // inicia uma posição

            /*AGORA INICIA A MARCAÇÃO DAS 8 POSSÍVEIS CASAS EM QUE O REI PODE SE MOVER DENTRO DA MATRIZ*/


            // DIREÇÃO SUL - acessa a casa que está acima do rei, esta passa a ser a posição pos
            pos.definirValores(posicao.linha - 1, posicao.coluna); 

            if(tab.posicaoValida(pos) && podeMover(pos)) // se a posição for valida e se a peça pode ser movida...
            {
                mat[pos.linha, pos.coluna] = true; // ...esta posição na matriz de movimentos fica true.
            }


            // DIREÇÃO NORDESTE - acessa a casa que está na diagonal acima do rei, esta passa a ser a posição pos
            pos.definirValores(posicao.linha - 1, posicao.coluna + 1);

            if (tab.posicaoValida(pos) && podeMover(pos)) 
            {
                mat[pos.linha, pos.coluna] = true; 
            }


            // DIREÇÃO LESTE - acessa a casa que está à direita do rei, esta passa a ser a posição pos
            pos.definirValores(posicao.linha, posicao.coluna + 1);

            if (tab.posicaoValida(pos) && podeMover(pos))
            {
                mat[pos.linha, pos.coluna] = true;
            }


            // DIREÇÃO SUDESTE - acessa a casa que está na diagonal abaixo do rei, esta passa a ser a posição pos
            pos.definirValores(posicao.linha + 1, posicao.coluna + 1);

            if (tab.posicaoValida(pos) && podeMover(pos))
            {
                mat[pos.linha, pos.coluna] = true;
            }


            // DIREÇÃO NORTE - acessa a casa que está abaixo do rei, esta passa a ser a posição pos
            pos.definirValores(posicao.linha + 1, posicao.coluna);

            if (tab.posicaoValida(pos) && podeMover(pos))
            {
                mat[pos.linha, pos.coluna] = true;
            }


            // DIREÇÃO SUDOESTE - acessa a casa que está na outra diagonal abaixo do rei, esta passa a ser a posição pos
            pos.definirValores(posicao.linha + 1, posicao.coluna - 1);

            if (tab.posicaoValida(pos) && podeMover(pos))
            {
                mat[pos.linha, pos.coluna] = true;
            }


            // DIREÇÃO OESTE - acessa a casa que está esquerda do rei, esta passa a ser a posição pos
            pos.definirValores(posicao.linha, posicao.coluna - 1);

            if (tab.posicaoValida(pos) && podeMover(pos))
            {
                mat[pos.linha, pos.coluna] = true;
            }


            // DIREÇÃO NOROESTE - acessa a casa que está na outra diagonal acima do rei, esta passa a ser a posição pos
            pos.definirValores(posicao.linha - 1, posicao.coluna - 1);

            if (tab.posicaoValida(pos) && podeMover(pos))
            {
                mat[pos.linha, pos.coluna] = true;
            }

            return mat; // no final retorna a matriz com todos os possíveis movimentos do rei.

        }
    }
}
