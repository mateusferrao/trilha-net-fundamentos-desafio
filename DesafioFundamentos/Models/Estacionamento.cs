using System.Text.RegularExpressions;

namespace DesafioFundamentos.Models
{
    public class Estacionamento
    {
        private readonly decimal precoInicial = 0;
        private readonly decimal precoPorHora = 0;
        private readonly List<string> veiculos = new();

        public Estacionamento(decimal precoInicial, decimal precoPorHora)
        {
            this.precoInicial = precoInicial;
            this.precoPorHora = precoPorHora;
        }

        public void AdicionarVeiculo()
        {
            Console.WriteLine("Digite a placa do veículo (ABC-1234) para estacionar:");
            string placa = Console.ReadLine().ToUpper();
            bool placaEhValida = ValidarFormatoPlaca(placa);
            if (placaEhValida)
            {
                this.veiculos.Add(placa);
                Console.WriteLine($"Veículo de placa {placa} adicionado com sucesso!");
            }
            else
            {
                Console.WriteLine($"A placa {placa} não está no formato correto (ABC-1234).");
            }
        }

        private static bool ValidarFormatoPlaca(string placa)
        {
            return new Regex(@"^[A-Z]{3}-\d{4}$").IsMatch(placa);
        }

        public void RemoverVeiculo()
        {
            Console.WriteLine("Digite a placa do veículo para remover:");
            string placa = Console.ReadLine();

            if (veiculos.Any(x => x.ToUpper() == placa.ToUpper()))
            {
                Console.WriteLine("Digite a quantidade de horas que o veículo permaneceu estacionado:");

                int horas = 0;
                while (!int.TryParse(Console.ReadLine(), out horas))
                {
                    Console.WriteLine("Valor incorreto: digite um valor válido.");
                }

                decimal valorTotal = this.precoInicial + (this.precoPorHora * horas);
                this.veiculos.Remove(placa.ToUpper());
                Console.WriteLine($"O veículo de placa {placa} foi removido e o preço total foi de: R$ {valorTotal}");
            }
            else
            {
                Console.WriteLine("Desculpe, esse veículo não está estacionado aqui. Confira se digitou a placa corretamente");
            }
        }

        public void ListarVeiculos()
        {
            if (veiculos.Any())
            {
                Console.WriteLine("Os veículos estacionados são:");
                foreach(string veiculo in this.veiculos) 
                {
                    Console.WriteLine(veiculo);
                }
            }
            else
            {
                Console.WriteLine("Não há veículos estacionados.");
            }
        }
    }
}
