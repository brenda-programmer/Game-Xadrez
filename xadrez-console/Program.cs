using System;
using tabuleiro;
using xadrez;

namespace xadrez_console
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                PartidaDeXadrez partida = new PartidaDeXadrez();

                while (!partida.terminada) // enquanto uma partida não estiver terminada
                {
                    try
                    {
                        Console.Clear();
                        Tela.imprimirPartida(partida);

                        Console.WriteLine();
                        Console.Write("Origem: ");
                        Posicao origem = Tela.lerPosicaoXadrez().toPosicao();// esse método vai ler do teclado uma posição que o usuário digitar e vai transformar para posição de matriz
                                                                             //lerPosicaoXadrez vai retornar uma instância de PosicaoXadrez a qual possui o método toPosicao

                        partida.validarPosicaoDeOrigem(origem); // valida se a posição de origem digitada é válida

                        // a partir da posição de origem que o usuário digitou, vou acessar a peça de origem que está no tabuleiro, pegar quais os movimentos possíveis dela e guardar na matriz PosicoesPossiveis
                        bool[,] posicoesPossiveis = partida.tab.peca(origem).movimentosPossiveis();

                        //Antes de perguntar o destino, limpa a tela e imprime o tabuleiro com as posições possíveis marcadas
                        Console.Clear();
                        Tela.imprimirTabuleiro(partida.tab, posicoesPossiveis);// na hora de imprimir o tabuleiro passo a matriz posicoesPossiveis como argumento

                        Console.WriteLine();
                        Console.Write("Destino:");
                        Posicao destino = Tela.lerPosicaoXadrez().toPosicao();
                        partida.validarPosicaoDeDestino(origem, destino);

                        partida.realizaJogada(origem, destino);
                    }
                    catch(TabuleiroException e) // captura qualquer exceção que ocorrer no bloco Try e faz o tratamento
                    {
                        Console.WriteLine(e.Message);// mostra a mensagem
                        Console.ReadLine(); // espera o usuário apertar a tecla Enter para voltar e repetir a jogada
                    }
                   
                }
                Console.Clear();
                Tela.imprimirPartida(partida);

            }
            catch (TabuleiroException e)
            {
                Console.WriteLine(e.Message);
            }
            
        }
    }
}
