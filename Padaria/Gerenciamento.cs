using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace Padaria
{
    public class Gerenciamento
    {
        public Funcionario CadastrarFuncionario()
        {
            Console.Clear();
            Console.WriteLine("==================  Cadastro Funcionário ================");
            Console.WriteLine("Digite o Nome:");
            var nome = Console.ReadLine();
            return new Funcionario { Nome = nome };
        }
        public void MostrarFuncionario(List<Funcionario> funcionarios, bool apenasdados = true)
        {
            if (apenasdados)
                Console.Clear();

            Console.WriteLine("=============== Lista de Funcionarios ====================");
            if (funcionarios.Count == 0) Console.WriteLine("Nenhum Funcionário cadastrado");
            
            funcionarios.ForEach(f =>
            {
                Console.WriteLine($"Código:{f.Codigo} | Cadastro:{f.Cadastro.ToString("dd/MM/yyyy")} | Nome:{f.Nome} ");
            });

            if (apenasdados)
            {
                Console.WriteLine("\n Aperte qualquer tecla para voltar ao menu");
                Console.ReadKey();
            }
        }

        public Produto CadastrarProduto()
        {
            Console.Clear();
            Console.WriteLine("==================  Cadastro Produto ================");
            Console.WriteLine("Digite o Nome:");
            var nome = Console.ReadLine();
            Console.WriteLine("Digite o Preço:");
            decimal preco = decimal.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
            Console.WriteLine("Digite a Quantidade:");
            int.TryParse(Console.ReadLine(), out int quantidade);
            return new Produto { Nome = nome, Preco = preco, Estoque = quantidade };
        }
        public void MostrarProduto(List<Produto> produtos, bool apenasDados = true)
        {
            if (apenasDados)
                Console.Clear();

            Console.WriteLine("=============== Lista de Produtos ====================");

            if (produtos.Count == 0) Console.WriteLine("Nenhum Produto cadastrado");

            produtos.ForEach(p =>
            {
                Console.WriteLine($"Código:{p.Codigo} | Cadastro:{p.Cadastro.ToString("dd/MM/yyyy")} | Estoque:{p.Estoque} | Nome:{p.Nome} | Preço:{p.Preco.ToString("F2")} ");
            });
            if (apenasDados)
            {
                Console.WriteLine("\n Aperte qualquer tecla para voltar ao menu");
                Console.ReadKey();
            }
        }

        public Venda Vender(List<Produto> produtos, List<Funcionario> funcionarios)
        {
            Console.Clear();
            Venda venda = new Venda();
            Console.WriteLine("================ Venda ==================");
            Console.WriteLine();
            MostrarFuncionario(funcionarios, false);

            Console.WriteLine("Digite o codigo do funcionario");
            int codigoFuncionario = int.Parse(Console.ReadLine());
            venda.Funcionario = funcionarios.Find(f => f.Codigo == codigoFuncionario);

            int CodigoProduto = 0;
            do
            {
                Console.Clear();
                MostrarProduto(produtos, false);
                ItemVenda item = new ItemVenda();
                Console.WriteLine("Digite a quantidade do produto");
                item.Quantidade = int.Parse(Console.ReadLine());

                Console.WriteLine("Digite o codigo do Produto:");
                int.TryParse(Console.ReadLine(), out CodigoProduto);
                Produto produto = produtos.Find(p => p.Codigo == CodigoProduto);
                if (produto == null)
                {
                    Console.WriteLine("Produto não encontrado pressione enter para procurar um novo produto");
                    Console.ReadKey();
                    continue;
                }

                item.produto = produto;
                venda.Produtos.Add(item);
                venda.Total += (item.Quantidade * produto.Preco);
                Console.WriteLine("Digite sair ou precione enter para continuar com a venda.");
                var conteudo = Console.ReadLine().ToUpper();
                if (conteudo.Equals("SAIR")) break;

            } while (true);

            BaixaEstoque(venda, produtos);

            return venda;

        }

        public void MostrarVenda(List<Venda> vendas)
        {
            Console.Clear();
            Console.WriteLine("=============== Lista de Vendas ====================");

            if (vendas.Count == 0) Console.WriteLine("Nenhum Venda cadastrado");

            vendas.ForEach(v =>
            {
                Console.WriteLine("================================================");
                Console.WriteLine($"Funcioná que efetuou a venda: {v.Funcionario.Nome}");
                Console.WriteLine($"Itens da venda:");
                v.Produtos.ForEach(p =>
                {
                    Console.WriteLine($"Nome:{p.produto.Nome} | Qtd:{p.Quantidade} Preço:{p.produto.Preco}");
                });
                Console.WriteLine($"Total:{v.Total.ToString("F2")} ");
                Console.WriteLine("\n=================================================");
            });
            Console.WriteLine("\n Aperte qualquer tecla para voltar ao menu");
            Console.ReadKey();
        }

        public void BaixaEstoque(Venda venda, List<Produto> produtos)
        {
            venda.Produtos.ForEach(item =>
            {
                produtos.Find(p => p.Codigo == item.produto.Codigo).Estoque -= item.Quantidade;
            });
        }

    }
}
