using tabuleiro;
namespace xadrez
{
    class Rei : Peca // Rei é uma subclasse de Peca
    {
        public Rei(Cor cor, Tabuleiro tab) 
            : base(cor, tab) // repassa a cor e o tab para o construtor da superclasse Peca
        {

        }

        public override string ToString()
        {
            return "R";
        }
    }
}
