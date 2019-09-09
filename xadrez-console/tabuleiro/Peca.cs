namespace tabuleiro
{
    abstract class Peca // se a classe tiver um método abstrato ela também deve ser abstrata.
    {
        public Posicao posicao { get; set; }
        public Cor cor { get; protected set; }
        public int qteMovimentos { get; protected set; }
        public Tabuleiro tab { get; protected set; }

        public Peca(Cor cor, Tabuleiro tab)
        {
            this.posicao = null; // a peça no inicio do jogo não tem posição
            this.cor = cor;
            this.tab = tab;
            this.qteMovimentos = 0; // a peça no inicio do jogo tem 0 movimentos
        }

        public void incrementarQteMovimentos()
        {
            qteMovimentos++;
        }
        public void derementarQteMovimentos()
        {
            qteMovimentos--;
        }
        // esse método vai ver se na matriz movimentosPossiveis existe pelo menos algum valor verdadeiro, para ver se a peça não está bloqueada de movimentos
        public bool existeMovimentosPossiveis()
        {
            bool[,] mat = movimentosPossiveis();
            for(int i = 0; i < tab.linhas; i++)
            {
                for(int j=0; j < tab.colunas; j++)
                {
                    if (mat[i, j]==true)
                    {
                        return true; // se na matriz movimentosPossíveis, mat, tiver alguma casa true, significa que existe pelo menos um movimento possível por isso retorna true
                    }
                }
            }

            return false; // se percorrer a matriz inteira e não encontrar true, significa que não existe movimento possível por isso retorna false
        }

        // método que testa se a peça pode se mover para determinada posição
        public bool podeMoverPara(Posicao pos)
        {
            return movimentosPossiveis()[pos.linha, pos.coluna];// verifica se na matriz movimentosPossiveis, na linha e na coluna da posição dada, é true 
        }

        //O método é abstrato pois ele é genérico, seu conteúdo vai depender do tipo de peça a ser utilizada. Portanto é um método que não vai ser utilizado nesta classe.
        public abstract bool[,] movimentosPossiveis(); // como é um método abstrato, toda classe que herdar desta, será obrigada a implementar este método
       
    }
}
