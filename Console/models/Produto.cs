using System;
using System.Collections.Generic;
using System.Globalization;


namespace Console
{
    public class RelacaoProduto : List<Produto>
    {
        public static RelacaoProduto Obter_10_Produtos()
        {
            RelacaoProduto rp = new RelacaoProduto();

            rp.Add(new Produto(01, "Lapis", 1.70f));
            rp.Add(new Produto(02, "Caneta", 2.12f));
            rp.Add(new Produto(03, "Borracha", 2.00f));
            rp.Add(new Produto(04, "Caderno", 13.23f));
            rp.Add(new Produto(05, "Lapiseira", 6.26f));
            rp.Add(new Produto(06, "Mochila", 122.84f));
            rp.Add(new Produto(07, "Fichario", 26.16f));
            rp.Add(new Produto(08, "Adesivo", 0.45f));
            rp.Add(new Produto(09, "Apagador", 5.00f));
            rp.Add(new Produto(10, "Giz", 10.00f));

            return rp;
        }
    }

    public class Produto
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public float Preco { get; set; }

        public Produto() { }
        public Produto(int id, string nome, float preco)
        {
            Id = id;
            Nome = nome;
            Preco = preco;
        }

        public override bool Equals(object obj)
        {
            var item = obj as Produto;

            if (item == null)
            {
                return false;
            }

            return this.Id.Equals(item.Id);
        }

        public override int GetHashCode()
        {
            return this.Id.GetHashCode();
        }

        public override string ToString()
        {
            return string.Format("ID: {0,2} / NOME: {1, -15} / PREÇO: {2,10}", this.Id.ToString(), this.Nome, this.Preco.ToString("F2", CultureInfo.InvariantCulture));
        }
    }
}
