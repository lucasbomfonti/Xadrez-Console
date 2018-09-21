using System;
using Xadrez_Console.tabuleiro;
using Xadrez_Console.Xadrez;

namespace Xadrez_Console
{
    class Program
    {
        static void Main()
        {
            try
            {
                PartidaDeXadez partida = new PartidaDeXadez();

                while (!partida.Terminada)
                {
                    try
                    {
                        Console.Clear();
                        Tela.ImprimirParida(partida);
                        Console.WriteLine();
                        Console.Write("Origem: ");
                        Posicao origem = Tela.lerPosicaoXadrez().ToPosicao();
                        partida.ValidarPosicaoOrigem(origem);
                        bool[,] posicoesPossiveis = partida.Tab.Peca(origem).MovimentosPossiveis();

                        Console.Clear();
                        Tela.ImprimirTabuleiro(partida.Tab, posicoesPossiveis);
                        Console.WriteLine();
                        Console.Write("Destino: ");
                        Posicao destino = Tela.lerPosicaoXadrez().ToPosicao();
                        partida.ValidarPosicaoDestino(origem, destino);                  
                        partida.RealizarJogada(origem, destino);
                    }
                    catch(TabuleiroException e)
                    {
                        Console.WriteLine(e.Message);
                        Console.ReadLine();
                    }
                }
                Console.Clear();
                Tela.ImprimirParida(partida);
                               
            }
            catch (TabuleiroException e)
            {
                Console.WriteLine(e.Message);
            }

            Console.ReadLine();
        } 
    }
}
