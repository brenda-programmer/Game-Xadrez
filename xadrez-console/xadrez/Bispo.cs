using tabuleiro;
namespace xadrez
{
    class Bispo : Peca // Bispo é uma subclasse de Peca
    {
        public Bispo(Cor cor, Tabuleiro tab)
           : base(cor, tab) // repassa a cor e o tab para o construtor da superclasse Peca
        {

        }

        public override string ToString()
        {
            return "B";
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


            /*AGORA INICIA A MARCAÇÃO DE TODAS AS POSSÍVEIS CASAS EM QUE O BISPO PODE SE MOVER DENTRO DA MATRIZ*/


            // DIREÇÃO NOROESTE - acessa a casa que está na diagonal acima do bispo, esta passa a ser a posição pos
            pos.definirValores(posicao.linha - 1, posicao.coluna - 1);
            while (tab.posicaoValida(pos) && podeMover(pos)) // enquanto não bater no final do tabuleiro E enquanto puder mover (casa livre ou peça adversária)
            {
                mat[pos.linha, pos.coluna] = true;

                if (tab.peca(pos) != null && tab.peca(pos).cor != cor)  //forçar a parada se caso bater numa peça adversária
                {
                    break;
                }
                pos.definirValores(pos.linha - 1, pos.coluna - 1); // estando tudo certo, vai para próxima posição acima
            }


            // DIREÇÃO NORDESTE - acessa a casa que está na outra diagonal acima do bispo, esta passa a ser a posição pos
            pos.definirValores(posicao.linha - 1, posicao.coluna + 1);
            while (tab.posicaoValida(pos) && podeMover(pos)) // enquanto não bater no final do tabuleiro E enquanto puder mover (casa livre ou peça adversária)
            {
                mat[pos.linha, pos.coluna] = true;

                if (tab.peca(pos) != null && tab.peca(pos).cor != cor)  //forçar a parada se caso bater numa peça adversária
                {
                    break;
                }
                pos.definirValores(pos.linha - 1, pos.coluna + 1); // estando tudo certo, vai para próxima posição acima
            }


            // DIREÇÃO SUDESTE - acessa a casa que está na diagonal abaixo do bispo, esta passa a ser a posição pos
            pos.definirValores(posicao.linha + 1, posicao.coluna + 1);
            while (tab.posicaoValida(pos) && podeMover(pos)) // enquanto não bater no final do tabuleiro E enquanto puder mover (casa livre ou peça adversária)
            {
                mat[pos.linha, pos.coluna] = true;

                if (tab.peca(pos) != null && tab.peca(pos).cor != cor)  //forçar a parada se caso bater numa peça adversária
                {
                    break;
                }
                pos.definirValores(pos.linha + 1, pos.coluna + 1); // estando tudo certo, vai para próxima posição abaixo
            }


            // DIREÇÃO SUDOESTE - acessa a casa que está na outra diagonal abaixo do bispo, esta passa a ser a posição pos
            pos.definirValores(posicao.linha + 1, posicao.coluna - 1);
            while (tab.posicaoValida(pos) && podeMover(pos)) // enquanto não bater no final do tabuleiro E enquanto puder mover (casa livre ou peça adversária)
            {
                mat[pos.linha, pos.coluna] = true;

                if (tab.peca(pos) != null && tab.peca(pos).cor != cor)  //forçar a parada se caso bater numa peça adversária
                {
                    break;
                }
                pos.definirValores(pos.linha + 1, pos.coluna - 1); // estando tudo certo, vai para próxima posição abaixo
            }


            return mat; // no final retorna a matriz com todos os possíveis movimentos do bispo.

        }
    }
}
