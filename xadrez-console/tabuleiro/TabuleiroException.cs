using System;
namespace tabuleiro
{
    class TabuleiroException : Exception
    {
        public TabuleiroException(string msg) : base(msg) // repassa msg para o contrutor da classe Exception do C#
        {

        }
    }
}
