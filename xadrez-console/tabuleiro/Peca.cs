namespace tabuleiro
{
    class Peca
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
    }
}
