
namespace tabuleiro
{
    public abstract class Peca
    {
        public Posicao posicao { get; set; }
        public Cor cor { get; protected set; }
        public int qteMovimetos { get; protected set; }
        public Tabuleiro tab { get; protected set; }

        public Peca(Tabuleiro tab, Cor cor)
        {
            this.posicao = null;
            this.tab = tab;
            this.cor = cor;
            this.qteMovimetos = 0;
        } 
        public void IncrementarQteMovimentos()
        {
            qteMovimetos++;
        }

        public bool ExisteMovimentosPossiveis()
        {
            bool[,] mat = MovimentosPossiveis();
            for (int i=0; i < tab.linhas; i++)
            {
                for (int j=0; j<tab.colunas; j++)
                {
                    if(mat[i, j] == true)
                    {
                        return true;
                    }
                }
            }
            return false;
        }


        public bool PodeMoverPara(Posicao pos)
        {
            return MovimentosPossiveis()[pos.linha, pos.coluna];
        }
        public abstract bool[,] MovimentosPossiveis();
    }
}
