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

        //O método é abstrato pois ele é genérico, seu conteúdo vai depender do tipo de peça a ser utilizada. Portanto é um método que não vai ser utilizado nesta classe.
        public abstract bool[,] movimentosPossiveis(); // como é um método abstrato, toda classe que herdar desta, será obrigada a implementar este método
       
    }
}
