using tabuleiro;
namespace xadrez
{
    class Peao : Peca // Peao é uma subclasse de Peca
    {
        private PartidaDeXadrez partida;
        public Peao(Cor cor, Tabuleiro tab, PartidaDeXadrez partida)
           : base(cor, tab) // repassa a cor e o tab para o construtor da superclasse Peca
        {
            this.partida = partida;
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


                //#jogadaespecial en passant para as peças brancas

                // se a posição desse peão for a linha igual a 3, há possibilidade de ocorrer o en passant
                if (posicao.linha == 3)
                {
                    Posicao esquerda = new Posicao(posicao.linha, posicao.coluna - 1); // só terá En passant se ao lado tiver alguma peça vulnerável, nesse caso está considerando o lado esquerdo                   
                    if (tab.posicaoValida(esquerda) && existeInimigo(esquerda) && tab.peca(esquerda) == partida.vulneravelEnPassant) // se esse lado for válido E se existe um inimigo lá E se a peça contida lá está vulnerável
                    {
                        mat[esquerda.linha -1, esquerda.coluna] = true; // se as condições forem atendidas, a matriz de movimentos possíveis do peão recebe uma nova posição possível 
                    }


                    Posicao direita = new Posicao(posicao.linha, posicao.coluna + 1); // só terá En passant se ao lado tiver alguma peça vulnerável, nesse caso está considerando o lado direito
                    if (tab.posicaoValida(direita) && existeInimigo(direita) && tab.peca(direita) == partida.vulneravelEnPassant) // se esse lado for válido E se existe um inimigo lá E se a peça contida lá está vulnerável
                    {
                        mat[direita.linha -1, direita.coluna] = true; // se as condições forem atendidas, a matriz de movimentos possíveis do peão recebe uma nova posição possível 
                    }
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

                //#jogadaespecial en passant para as peças pretas

                // se a posição desse peão for a linha igual a 4, há possibilidade de ocorrer o en passant
                if (posicao.linha == 4)
                {
                    Posicao esquerda = new Posicao(posicao.linha, posicao.coluna - 1); // só terá En passant se ao lado tiver alguma peça vulnerável, nesse caso está considerando o lado esquerdo                   
                    if (tab.posicaoValida(esquerda) && existeInimigo(esquerda) && tab.peca(esquerda) == partida.vulneravelEnPassant) // se esse lado for válido E se existe um inimigo lá E se a peça contida lá está vulnerável
                    {
                        mat[esquerda.linha +1, esquerda.coluna] = true; // se as condições forem atendidas, a matriz de movimentos possíveis do peão recebe uma nova posição possível 
                    }


                    Posicao direita = new Posicao(posicao.linha, posicao.coluna + 1); // só terá En passant se ao lado tiver alguma peça vulnerável, nesse caso está considerando o lado direito
                    if (tab.posicaoValida(direita) && existeInimigo(direita) && tab.peca(direita) == partida.vulneravelEnPassant) // se esse lado for válido E se existe um inimigo lá E se a peça contida lá está vulnerável
                    {
                        mat[direita.linha +1, direita.coluna] = true; // se as condições forem atendidas, a matriz de movimentos possíveis do peão recebe uma nova posição possível 
                    }
                }
            }


            return mat; // no final retorna a matriz com todos os possíveis movimentos do peão.

        }
    }
}
