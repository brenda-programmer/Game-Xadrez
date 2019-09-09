namespace tabuleiro
{
    class Tabuleiro
    {
        public int linhas { get; set; }
        public int colunas { get; set; }

        private Peca[,] pecas;

        public Tabuleiro(int linhas, int colunas)
        {
            this.linhas = linhas;
            this.colunas = colunas;
            pecas = new Peca[linhas, colunas];
        }

        public Peca peca(int linha, int coluna)
        {
            return pecas[linha, coluna];
        }

        // sobrecarga do método peca
        public Peca peca(Posicao pos)
        {
            return pecas[pos.linha, pos.coluna];
        }

        // método para verificar se existe peça em uma dada posição
        public bool existePeca(Posicao pos) 
        {
            validarPosicao(pos);// validar se a posição é válida, caso for executa a próxima linha, caso não lança uma exceção
            return peca(pos) != null; // se for true significa que existe uma peça naquela posição
        }
        public void colocarPeca(Peca p, Posicao pos)
        {
            if (existePeca(pos)) // só posso colocar uma peça onde não tenha nenhuma peça
            {
                throw new TabuleiroException("Já existe uma peça nessa posição!");
            }
            pecas[pos.linha, pos.coluna] = p; // a matriz de peças do tabuleiro recebe a peça que você declarar na posição desejada
            p.posicao = pos; // essa peça declarada terá sua posição igual a posição desejada na matriz do tabuleiro
        }

        public Peca retirarPeca(Posicao pos)
        {
            if (peca(pos) == null) // se a posição desejada já não tiver peça, retorna null
            {
                return null;
            }
            Peca aux = peca(pos); // se tiver peça na posição desejada, a peça é guardada na variavel aux
            aux.posicao = null; // a posição dessa peça passa a valer null
            pecas[pos.linha, pos.coluna] = null; // essa mesma posição na matriz de peças passa a valer null
            return aux;
        }

        // método para testar se uma dada posição é valida ou não
        public bool posicaoValida(Posicao pos) 
        {
            if(pos.linha<0 || pos.linha>=linhas || pos.coluna<0 || pos.coluna >= colunas)
            {
                return false;
            }
            return true;
        }

        // método que recebe uma posição e, caso a posição não passe pelo método posicaoValida, lança uma excessão personalizada
        public void validarPosicao(Posicao pos) 
        {
            if (!posicaoValida(pos))
            {
                throw new TabuleiroException("Posição inválida!");
            }
        }
    }
}
