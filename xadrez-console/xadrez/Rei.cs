using tabuleiro;
namespace xadrez
{
    class Rei : Peca // Rei é uma subclasse de Peca
    {
        private PartidaDeXadrez partida; // para que o rei tenha acesso a partida

        public Rei(Cor cor, Tabuleiro tab, PartidaDeXadrez partida)
            : base(cor, tab) // repassa a cor e o tab para o construtor da superclasse Peca
        {
            this.partida = partida;
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

        // Testar se uma peça em determinada posição é uma torre para roque pequeno
        private bool testeTorreParaRoque(Posicao pos)
        {
            Peca p = tab.peca(pos);
            return p != null && p is Torre && p.cor == cor && p.qteMovimentos == 0; // uma torre pode participar de um roque se: uma peça não for nula E essa peça é uma instância de torre E a cor dessa peça tem que ser da mesma cor do rei E a quantidade de movimentos dessa torre tem que ser igual a zero
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


            // #jogadaespecial ROQUE
            if(qteMovimentos==0 && !partida.xeque) // se o rei ainda não se moveu e se não tiver em xeque
            {
                // #jogadaespecial roque pequeno
                Posicao posT1 = new Posicao(posicao.linha, posicao.coluna + 3); // esta é a posição esperada da torre para que possa fazer um roque pequeno: na mesma linha que a do rei há 3 colunas de distância dele à direita

                if (testeTorreParaRoque(posT1)) // se esta torre estiver elegível para roque
                {
                    Posicao p1 = new Posicao(posicao.linha, posicao.coluna + 1);
                    Posicao p2 = new Posicao(posicao.linha, posicao.coluna + 2);

                    if(tab.peca(p1)==null && tab.peca(p2) == null) //verifica se as duas casas entre o rei e a torre estão vagas
                    {
                        mat[posicao.linha, posicao.coluna + 2] = true; // a matriz de movimentos possíveis do rei recebe uma nova posição válida : duas casas a direita para realizar o roque pequeno
                    }
                }

                // #jogadaespecial roque grande
                Posicao posT2 = new Posicao(posicao.linha, posicao.coluna - 4); // esta é a posição esperada da torre para que possa fazer um roque grande: na mesma linha que a do rei há 4 colunas de distância dele à esquerda

                if (testeTorreParaRoque(posT2)) // se esta torre estiver elegível para roque
                {
                    Posicao p1 = new Posicao(posicao.linha, posicao.coluna - 1);
                    Posicao p2 = new Posicao(posicao.linha, posicao.coluna - 2);
                    Posicao p3 = new Posicao(posicao.linha, posicao.coluna - 3);

                    if (tab.peca(p1) == null && tab.peca(p2) == null && tab.peca(p3) == null) //verifica se as tres casas entre o rei e a torre estão vagas
                    {
                        mat[posicao.linha, posicao.coluna - 2] = true; // a matriz de movimentos possíveis do rei recebe uma nova posição válida : duas casas a esquerda para realizar o roque grande
                    }
                }

            }


            return mat; // no final retorna a matriz com todos os possíveis movimentos do rei.

        }
    }
}
