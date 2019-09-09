using tabuleiro;
namespace xadrez
{
    class Peao : Peca // Peao é uma subclasse de Peca
    {
        public Peao(Cor cor, Tabuleiro tab)
           : base(cor, tab) // repassa a cor e o tab para o construtor da superclasse Peca
        {

        }

        public override string ToString()
        {
            return "P";
        }

        //método que verifica se existe um inimigo na posição
        private bool existeInimigo(Posicao pos)
        {
            Peca p = tab.peca(pos);
            return p != null && p.cor != cor; // posição não nula e cor da peça diferente - existe inimigo

        }

        //método que verifica se a posição está livre
        private bool livre(Posicao pos)
        {
            return tab.peca(pos) == null;
        }


        //Implementando a classe abstrata da super classe
        public override bool[,] movimentosPossiveis() // retirar abstract pois a classe agora é concreta e usar override para indicar que está sobreescrevendo o método da super classe
        {
            bool[,] mat = new bool[tab.linhas, tab.colunas]; // é criada uma matriz para indicar os movimentos que são possíveis para esta peça dentro do tabuleiro


            Posicao pos = new Posicao(0, 0); // inicia uma posição

            /*AGORA INICIA A MARCAÇÃO DAS POSSÍVEIS CASAS EM QUE O PEAO PODE SE MOVER DENTRO DA MATRIZ*/

            if (cor == Cor.Branca)
            {
                // DIREÇÃO SUL - acessa a casa que está acima do peão, esta passa a ser a posição pos
                pos.definirValores(posicao.linha - 1, posicao.coluna);

                if (tab.posicaoValida(pos) && livre(pos)) // se a posição for valida e se o caminho estiver livre...
                {
                    mat[pos.linha, pos.coluna] = true; // ...esta posição na matriz de movimentos fica true.
                }


                // DIREÇÃO SUL - acessa 2 casas que está acima do peão, esta passa a ser a posição pos
                pos.definirValores(posicao.linha - 2, posicao.coluna);

                if (tab.posicaoValida(pos) && livre(pos) && qteMovimentos==0) // se a posição for valida e se o caminho estiver livre e se for seu primeiro movimento...
                {
                    mat[pos.linha, pos.coluna] = true; // ...esta posição na matriz de movimentos fica true.
                }


                //  DIREÇÃO NOROESTE - acessa a casa que está na diagonal acima do peão, esta passa a ser a posição pos
                pos.definirValores(posicao.linha - 1, posicao.coluna - 1);

                if (tab.posicaoValida(pos) && existeInimigo(pos)) // se a posição for valida e se existe inimigo para capturar...
                {
                    mat[pos.linha, pos.coluna] = true; // ...esta posição na matriz de movimentos fica true.
                }

                //  DIREÇÃO NORDESTE - acessa a casa que está na outra diagonal acima do peão, esta passa a ser a posição pos
                pos.definirValores(posicao.linha - 1, posicao.coluna + 1);

                if (tab.posicaoValida(pos) && existeInimigo(pos)) // se a posição for valida e se existe inimigo para capturar...
                {
                    mat[pos.linha, pos.coluna] = true; // ...esta posição na matriz de movimentos fica true.
                }


            }
            else // se cor for preta
            {

                // DIREÇÃO SUL - acessa a casa que está acima do peão, esta passa a ser a posição pos
                pos.definirValores(posicao.linha + 1, posicao.coluna);

                if (tab.posicaoValida(pos) && livre(pos)) // se a posição for valida e se o caminho estiver livre...
                {
                    mat[pos.linha, pos.coluna] = true; // ...esta posição na matriz de movimentos fica true.
                }


                // DIREÇÃO SUL - acessa 2 casas que está acima do peão, esta passa a ser a posição pos
                pos.definirValores(posicao.linha + 2, posicao.coluna);

                if (tab.posicaoValida(pos) && livre(pos) && qteMovimentos == 0) // se a posição for valida e se o caminho estiver livre e se for seu primeiro movimento...
                {
                    mat[pos.linha, pos.coluna] = true; // ...esta posição na matriz de movimentos fica true.
                }


                //  DIREÇÃO NOROESTE - acessa a casa que está na diagonal acima do peão, esta passa a ser a posição pos
                pos.definirValores(posicao.linha + 1, posicao.coluna - 1);

                if (tab.posicaoValida(pos) && existeInimigo(pos)) // se a posição for valida e se existe inimigo para capturar...
                {
                    mat[pos.linha, pos.coluna] = true; // ...esta posição na matriz de movimentos fica true.
                }

                //  DIREÇÃO NORDESTE - acessa a casa que está na outra diagonal acima do peão, esta passa a ser a posição pos
                pos.definirValores(posicao.linha + 1, posicao.coluna + 1);

                if (tab.posicaoValida(pos) && existeInimigo(pos)) // se a posição for valida e se existe inimigo para capturar...
                {
                    mat[pos.linha, pos.coluna] = true; // ...esta posição na matriz de movimentos fica true.
                }
            }


            return mat; // no final retorna a matriz com todos os possíveis movimentos do peão.

        }
    }
}
