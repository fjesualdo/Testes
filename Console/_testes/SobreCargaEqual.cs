using System.Linq;

namespace Console
{
    public class SobreCargaEqual
    {
        public SobreCargaEqual()
        {
            RelacaoProduto produtos = RelacaoProduto.Obter_10_Produtos();
            produtos.Add(new Produto(01, "Lapis", 1.70f));
            produtos.Add(new Produto(02, "Lapis", 1.70f));
            produtos.Add(new Produto(03, "Lapis", 1.70f));

            HelpConsole.WriteLineBar("Lista completa");
            produtos.ForEach(x => System.Console.WriteLine(x.ToString()));

            HelpConsole.WriteLineBar("produtos.Distinct");

            RelacaoProduto produtosSemRepeticao = new RelacaoProduto();
            produtosSemRepeticao.AddRange(produtos.Distinct().ToList());
        }
    }
}
