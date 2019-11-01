using System;
using System.Collections.Generic;

namespace Padaria
{
    public class Program
    {
        public static void Main(string[] args)
        {

            List<Funcionario> funcionarios = new List<Funcionario>();
            List<Produto> produtos = new List<Produto>();
            Gerenciamento gerenciamento = new Gerenciamento();
            List<Venda> vendas = new List<Venda>();
            int opcao = 0;
            do
            {
                Console.Clear();
                Console.WriteLine("Escolha uma opção");
                Console.WriteLine("1 - Cadastrar Funcionário");
                Console.WriteLine("2 - Mostrar Funcionários");
                Console.WriteLine("3 - Cadastrar Produto");
                Console.WriteLine("4 - Mostrar Produtos");
                Console.WriteLine("5 - Venda");
                Console.WriteLine("6 - Mostar Venda");
                Console.WriteLine("\n\n9 - Para sair");
                int.TryParse(Console.ReadLine(), out opcao);
                switch (opcao)
                {
                    case 1:
                        funcionarios.Add(gerenciamento.CadastrarFuncionario());
                        break;
                    case 2:
                        gerenciamento.MostrarFuncionario(funcionarios);
                        break;
                    case 3:
                        produtos.Add(gerenciamento.CadastrarProduto());
                        break;
                    case 4:
                        gerenciamento.MostrarProduto(produtos);
                        break;
                    case 5:
                        vendas.Add(gerenciamento.Vender(produtos, funcionarios));
                        break;
                    case 6:
                        gerenciamento.MostrarVenda(vendas);
                        break;                    

                    case 9:
                        Console.Clear();
                        Console.WriteLine("Muito obrigado por usar o nosso sistema.");
                        Console.ReadKey();
                        Environment.Exit(0);
                        break;
                    default:
                        opcao = 99999; //Como o tryParse vai jogar 0 para qualquer coisa que não for um int, ex um caracter por exemplo ai jogo um numero que não vai ter no menu só para poder voltar
                        Console.WriteLine("Opção inválida aperte qualquer tecla para voltar para o menu");
                        Console.ReadKey();
                        break;
                }
            } while (opcao != 0);


        }
    }
}
