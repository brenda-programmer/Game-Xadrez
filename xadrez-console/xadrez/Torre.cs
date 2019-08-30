using tabuleiro;
namespace xadrez
{
    class Torre : Peca // Torre é uma subclasse de Peca
    {
        public Torre(Cor cor, Tabuleiro tab)
            : base(cor, tab) // repassa a cor e o tab para o construtor da superclasse Peca
        {

        }

        public override string ToString()
        {
            return "T";
        }
    }
}
