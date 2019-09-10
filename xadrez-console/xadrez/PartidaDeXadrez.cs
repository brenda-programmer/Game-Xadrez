using System.Collections.Generic;
using tabuleiro;

namespace xadrez
{
    class PartidaDeXadrez
    {
        public Tabuleiro tab { get; private set; } // não permite o programador modificar o tabuleiro fora dessa classe
        public int turno { get; private set; }
        public Cor jogadorAtual { get; private set; }
        public bool terminada { get; private set; } // diz se uma partida já foi terminada

        private HashSet<Peca> pecas; // esse conjunto vai guardar todas as peças da partida

        private HashSet<Peca> capturadas; // esse conjunto vai guardar as peças capturadas
        public bool xeque { get; private set; } // indica se a partida está em xeque

        public PartidaDeXadrez()
        {
            tab = new Tabuleiro(8, 8);
            turno = 1; // no inicio de uma partida o turno vale 1
            jogadorAtual = Cor.Branca; // no inicio de uma partida quem começa são sempre as brancas
            terminada = false; // no inicio de uma partida ela não está terminada
            xeque = false;
            pecas = new HashSet<Peca>();
            capturadas = new HashSet<Peca>();
            colocarPecas();
        }

        public Peca executaMovimento(Posicao origem, Posicao destino)
        {
            Peca p = tab.retirarPeca(origem); // para movimentar a peça tem que rtirar ela da origem
            p.incrementarQteMovimentos(); // incrementa 1 na quantidade de movimentos da peça
            Peca pecaCapturada = tab.retirarPeca(destino); // retirar a peça que estiver ocupando a posição de destino para que a peça desejada possa ocupar
            tab.colocarPeca(p, destino); // a peça é inserida no destino

            if (pecaCapturada != null) // se a peça capturada não for um null, o conteúdo é guardado no conjunto de peças capturadas
            {
                capturadas.Add(pecaCapturada);
            }

            // #jogadaespecial roque pequeno
            if(p is Rei && destino.coluna == origem.coluna + 2)  // Verifica se está ocorrendo um roque pequeno: se a peça for um rei E se ele foi movido duas casas para a direita
            {
                Posicao origemT = new Posicao(origem.linha, origem.coluna + 3); // define a posição origem da torre: como se trata de um roque pequeno, a posição da torre é exatamente 3 casas a direita da posição do rei em sua origem
                Posicao destinoT = new Posicao(origem.linha, origem.coluna + 1); // define a posição destino da torre: a torre passa ocupar uma casa a direita do rei em sua origem
                Peca T = tab.retirarPeca(origemT); // define a retirada da torre de sua origem

                T.incrementarQteMovimentos(); // incrementa a quantidade de movimentos dessa torre
                tab.colocarPeca(T, destinoT); //coloca a torre na posição de destino definida
            }

            // #jogadaespecial roque grande
            if (p is Rei && destino.coluna == origem.coluna - 2)  // Verifica se está ocorrendo um roque grande: se a peça for um rei E se ele foi movido duas casas para a esquerda
            {
                Posicao origemT = new Posicao(origem.linha, origem.coluna - 4); // define a posição origem da torre: como se trata de um roque grande, a posição da torre é exatamente 4 casas a esquerda da posição do rei em sua origem
                Posicao destinoT = new Posicao(origem.linha, origem.coluna - 1); // define a posição destino da torre: a torre passa ocupar uma casa a esquerda do rei em sua origem
                Peca T = tab.retirarPeca(origemT); // define a retirada da torre de sua origem

                T.incrementarQteMovimentos(); // incrementa a quantidade de movimentos dessa torre
                tab.colocarPeca(T, destinoT); //coloca a torre na posição de destino definida
            }

            return pecaCapturada;
        }

        public void desfazMovimento(Posicao origem, Posicao destino, Peca pecaCapturada)
        {
            Peca p = tab.retirarPeca(destino);
            p.derementarQteMovimentos();
            if (pecaCapturada != null) // se teve peça capturada, ela é colocada de volta
            {
                tab.colocarPeca(pecaCapturada, destino);
                capturadas.Remove(pecaCapturada); // essa peça não faz mais parte do conjunto de peças capturadas
            }
            tab.colocarPeca(p, origem);

            // #jogadaespecial roque pequeno
            if (p is Rei && destino.coluna == origem.coluna + 2)  // Verifica se está ocorrendo um roque pequeno: se a peça for um rei E se ele foi movido duas casas para a direita
            {
                Posicao origemT = new Posicao(origem.linha, origem.coluna + 3); // define a posição origem da torre: como se trata de um roque pequeno, a posição da torre é exatamente 3 casas a direita da posição do rei em sua origem
                Posicao destinoT = new Posicao(origem.linha, origem.coluna + 1); // define a posição destino da torre: a torre passa ocupar uma casa a direita do rei em sua origem
                Peca T = tab.retirarPeca(destinoT); // define a retirada da torre do seu destino

                T.derementarQteMovimentos(); // decrementa a quantidade de movimentos dessa torre
                tab.colocarPeca(T, origemT); //recoloca a torre na posição de origem definida
            }

            // #jogadaespecial roque grande
            if (p is Rei && destino.coluna == origem.coluna - 2)  // Verifica se está ocorrendo um roque grande: se a peça for um rei E se ele foi movido duas casas para a esquerda
            {
                Posicao origemT = new Posicao(origem.linha, origem.coluna - 4); // define a posição origem da torre: como se trata de um roque grande, a posição da torre é exatamente 4 casas a esquerda da posição do rei em sua origem
                Posicao destinoT = new Posicao(origem.linha, origem.coluna - 1); // define a posição destino da torre: a torre passa ocupar uma casa a esquerda do rei em sua origem
                Peca T = tab.retirarPeca(destinoT); //  define a retirada da torre do seu destino

                T.derementarQteMovimentos(); //decrementa a quantidade de movimentos dessa torre
                tab.colocarPeca(T, origemT); //recoloca a torre na posição de origem definida
            }
        }

        public void realizaJogada(Posicao origem, Posicao destino)
        {
            Peca pecaCapturada = executaMovimento(origem, destino); // ao executar um movimento uma peça é capturada

            if (estaEmXeque(jogadorAtual)) // se o jogador atual estiver em xeque, deve-se desfazer a jogada
            {
                desfazMovimento(origem, destino, pecaCapturada);
                throw new TabuleiroException("Você não pode se colocar em xeque!");
            }

            if (estaEmXeque(adversária(jogadorAtual))) // se o jogador adversário estiver em xeque
            {
                xeque = true;
            }
            else
            {
                xeque = false;
            }

            if (testeXequeMate(adversária(jogadorAtual))) // Se o jogador adversário estiver em xeque-mate
            {
                terminada = true;
            }
            else
            {
                turno++; // passa para o próximo turno
                mudaJogador(); // troca o jogador
            }
            
        }

        //método que testa se a posição de origem digitada é válida
        public void validarPosicaoDeOrigem(Posicao pos)
        {
            if (tab.peca(pos) == null)  //testa se existe ou não peça na posição digitada
            {
                throw new TabuleiroException("Não existe peça na posição de origem escolhida!");
            }
            
            if(jogadorAtual != tab.peca(pos).cor) //testa se a peça é da mesma cor do jogador atual
            {
                throw new TabuleiroException("A peça de origem escolhida não é sua!");
            }
            
            if (!tab.peca(pos).existeMovimentosPossiveis()) //testa se a peça está bloqueada, sem movimentos possíveis
            {
                throw new TabuleiroException("Não há movimentos possíveis para a peça de origem escolhida!");
            }
        }


        //método que testa se a posição de destino digitada é válida em relação a origem
        public void validarPosicaoDeDestino(Posicao origem, Posicao destino)
        {
            if (!tab.peca(origem).movimentoPossivel(destino)) // testa se caso a peça de origem não pode se mover para posição de destino
            {
                throw new TabuleiroException("Posição de destino inválida!");
            }
        }

        private void mudaJogador() // troca de jogador
        {
            if (jogadorAtual == Cor.Branca)
            {
                jogadorAtual = Cor.Preta;
            }
            else
            {
                jogadorAtual = Cor.Branca;
            }
        }

        //metodo para ver as peças capturadas de uma cor específica
        public HashSet<Peca> pecasCapturadas(Cor cor)
        {
            HashSet<Peca> aux = new HashSet<Peca>();
            foreach(Peca x in capturadas) // percorre todo o conjunto capturadas
            {
                if(x.cor == cor)
                {
                    aux.Add(x); // se a peça do conjunto tiver a mesma cor solicitada no parâmetro, ela é adicionada ao conjunto auxiliar
                }
            }

            return aux;
        }

        //método que vai retornar só as peças que estão em jogo de uma determinada cor
        public HashSet<Peca> pecasEmJogo(Cor cor)
        {
            HashSet<Peca> aux = new HashSet<Peca>();
            foreach (Peca x in pecas) // percorre todo o conjunto pecas
            {
                if (x.cor == cor)
                {
                    aux.Add(x); // se a peça do conjunto tiver a mesma cor solicitada no parâmetro, ela é adicionada ao conjunto auxiliar
                }
            }

            aux.ExceptWith(pecasCapturadas(cor)); // vai retirar do conjunto todas as peças capturadas da mesma cor
            return aux;
        }

        //Esse método vai retornar a cor adversária a cor colocada
        private Cor adversária(Cor cor)
        {
            if(cor== Cor.Branca)
            {
                return Cor.Preta;
            }
            else
            {
                return Cor.Branca;
            }
        }

        //Esse método vai retornar um rei de uma dada cor
        private Peca rei(Cor cor)
        {
            foreach(Peca x in pecasEmJogo(cor))
            {
                if(x is Rei) // "is" verifica se uma variável do tipo da superclasse é uma instância de uma subclasse
                {
                    return x;
                }
            }

            return null;
        }

        //Esse método retorna se o rei de uma dada cor está em xeque
        public bool estaEmXeque(Cor cor)
        {
            Peca R = rei(cor);
            if (R == null)
            {
                throw new TabuleiroException("Não tem rei da cor " + cor + " no tabuleiro!");
            }

            foreach(Peca x in pecasEmJogo(adversária(cor))) //verifica os movimentos possíveis de todas as peças adversárias para ver se algum deles bate com o rei
            {
                bool[,] mat = x.movimentosPossiveis(); // movimentos possíveis de uma determinada peça adversária

                if (mat[R.posicao.linha, R.posicao.coluna]) // se na posição onde está rei em questão estiver true, significa que esta peça adversária pode atacá-lo, ou seja está em xeque
                {
                    return true;
                }

            }

            return false; //se após a varredura de todas as peças adversárias, nenhuma delas tem movimento até o rei, significa que o rei não está em xeque
        }

        //metodo que verifica movimentos possíveis de todas as peças da cor do rei para tirá-lo do xeque, se não tiver é xeque-mate
        public bool testeXequeMate(Cor cor)
        {
            if (!estaEmXeque(cor))
            {
                return false;
            }
            foreach(Peca x in pecasEmJogo(cor))
            {
                bool[,] mat = x.movimentosPossiveis(); // pega a matriz de movimentos possíveis dessa peça x
                for(int i=0; i < tab.linhas; i++) // verificando cada movimento possível dessa matriz
                {
                    for(int j = 0; j < tab.colunas; j++)
                    {
                        if (mat[i, j]) // sendo true, mostra que esta é uma posição possível para esta peça
                        {
                            Posicao origem = x.posicao;
                            Posicao destino = new Posicao(i, j);
                            Peca pecaCapturada = executaMovimento(origem, destino); // executa um movimento teste da posição em que a peça x está para esta posição possível
                            bool testeXeque = estaEmXeque(cor); // após executar o movimento, verifica se o rei desta cor ainda está em xeque
                            desfazMovimento(origem, destino, pecaCapturada); // desfaz movimento executado pelo teste

                            if (!testeXeque) // se o rei não tiver mais em xeque, significa que o movimento feito tira do xeque, então não é xeque-mate
                            {
                                return false;
                            }

                        }
                    }
                }
            }
            return true; // se nenhuma das peças em quaisquer das suas posições possíveis, retirar o rei do xeque significa que é xeque-mate

        }

        //Esse método vai colocar no tabuleiro a peça desejada na posição desejada
        public void colocarNovaPeca(char coluna, int linha, Peca peca) 
        {
            tab.colocarPeca(peca, new PosicaoXadrez(coluna, linha).toPosicao()); // método toPosicao, que está na classe PosicaoXadrez, retorna uma posicao que é o tipo solicitado pelo método colocarPeca
            pecas.Add(peca); //esta nova peça é adicionada ao conjunto de peças da pertida
        }
        private void colocarPecas()
        {
 
            colocarNovaPeca('a', 1, new Torre(Cor.Branca, tab));
            colocarNovaPeca('b', 1, new Cavalo(Cor.Branca, tab));
            colocarNovaPeca('c', 1, new Bispo(Cor.Branca, tab));
            colocarNovaPeca('d', 1, new Dama(Cor.Branca, tab));
            colocarNovaPeca('e', 1, new Rei(Cor.Branca, tab, this));
            colocarNovaPeca('f', 1, new Bispo(Cor.Branca, tab));
            colocarNovaPeca('g', 1, new Cavalo(Cor.Branca, tab));
            colocarNovaPeca('h', 1, new Torre(Cor.Branca, tab));
            colocarNovaPeca('a', 2, new Peao(Cor.Branca, tab));
            colocarNovaPeca('b', 2, new Peao(Cor.Branca, tab));
            colocarNovaPeca('c', 2, new Peao(Cor.Branca, tab));
            colocarNovaPeca('d', 2, new Peao(Cor.Branca, tab));
            colocarNovaPeca('e', 2, new Peao(Cor.Branca, tab));
            colocarNovaPeca('f', 2, new Peao(Cor.Branca, tab));
            colocarNovaPeca('g', 2, new Peao(Cor.Branca, tab));
            colocarNovaPeca('h', 2, new Peao(Cor.Branca, tab));


            colocarNovaPeca('a', 8, new Torre(Cor.Preta, tab));
            colocarNovaPeca('b', 8, new Cavalo(Cor.Preta, tab));
            colocarNovaPeca('c', 8, new Bispo(Cor.Preta, tab));
            colocarNovaPeca('d', 8, new Dama(Cor.Preta, tab));
            colocarNovaPeca('e', 8, new Rei(Cor.Preta, tab, this));
            colocarNovaPeca('f', 8, new Bispo(Cor.Preta, tab));
            colocarNovaPeca('g', 8, new Cavalo(Cor.Preta, tab));
            colocarNovaPeca('h', 8, new Torre(Cor.Preta, tab));
            colocarNovaPeca('a', 7, new Peao(Cor.Preta, tab));
            colocarNovaPeca('b', 7, new Peao(Cor.Preta, tab));
            colocarNovaPeca('c', 7, new Peao(Cor.Preta, tab));
            colocarNovaPeca('d', 7, new Peao(Cor.Preta, tab));
            colocarNovaPeca('e', 7, new Peao(Cor.Preta, tab));
            colocarNovaPeca('f', 7, new Peao(Cor.Preta, tab));
            colocarNovaPeca('g', 7, new Peao(Cor.Preta, tab));
            colocarNovaPeca('h', 7, new Peao(Cor.Preta, tab));


        }
    }
}
