using tabuleiro;
namespace xadrez
{
    class PosicaoXadrez
    {
        public char coluna { get; set; }
        public int linha { get; set; }

        public PosicaoXadrez(char coluna, int linha)
        {
            this.coluna = coluna;
            this.linha = linha;
        }

        // transforma a posição letra-numero, de um tabuleiro padrão de xadrez, na posição correspondente dentro da matriz
        public Posicao toPosicao() 
        {
            return new Posicao(8 - linha, coluna - 'a');// (coluna -'a') é char menos char - retornará um número inteiro: a distância entre a letra desejada até a letra 'a'
        }
        public override string ToString()
        {
            return "" + coluna + linha;
        }
    }
}
