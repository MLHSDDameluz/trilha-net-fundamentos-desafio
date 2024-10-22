using System.Runtime.InteropServices;

namespace DesafioFundamentos.Models
{
    public class Estacionamento
    {
        private decimal precoInicial = 0;
        private decimal precoPorHora = 0;
        private List<string> veiculos = new List<string>();

        public Estacionamento(decimal precoInicial, decimal precoPorHora)
        {
            this.precoInicial = precoInicial;
            this.precoPorHora = precoPorHora;
        }

        public void AdicionarVeiculo()
        {
            /*Usuário digita uma placa. Sistema verifica se placa tem 7 caracteres. 
            Se a placa for válida inclui na lista de veículos estacionados.*/
            bool placaValida = false;
            while (placaValida == false)
            {
                Console.WriteLine("Digite a placa do veículo para estacionar:");
                string placaVeiculo = Console.ReadLine();
                if (placaVeiculo.Length != 7)
                {
                    System.Console.WriteLine("Placa inválida. Digite novamente.");
                }
                else
                {
                    veiculos.Add(placaVeiculo);
                    System.Console.WriteLine("Veículo adicionado com sucesso!");
                    placaValida = true;
                }
            }
        }

        public void RemoverVeiculo()
        {
            /*Usuário digita uma placa. Sistema verifica se a placa consta na lista de veículos estacionados.
            Usuário digita quantidade de horas veículo permaneceu estacionado e faz cálculo para pagamento.*/
            Console.WriteLine("Digite a placa do veículo para remover:");

            string placa = Console.ReadLine();

            if (veiculos.Any(x => x.ToUpper() == placa.ToUpper()))
            {
                Console.WriteLine("Digite a quantidade de horas que o veículo permaneceu estacionado:");
                int horas = int.Parse(Console.ReadLine());
                decimal valorTotal = ((horas-1)*precoPorHora) + precoInicial; 
                veiculos.Remove(placa);
                
                Console.WriteLine($"O veículo {placa.ToUpper()} foi removido e o preço total foi de: R$ {valorTotal}");
            }
            else
            {
                Console.WriteLine("Desculpe, esse veículo não está estacionado aqui. Confira se digitou a placa corretamente");
            }
        }

        public void ListarVeiculos()
        {
            // Verifica se há veículos no estacionamento e lista as placas dos veículos.
            if (veiculos.Any())
            {
                Console.WriteLine("Os veículos estacionados são:");
                foreach(string x in veiculos)
                {
                    System.Console.WriteLine($"Veículo placa: {x.ToUpper()}");
                }
            }
            else
            {
                Console.WriteLine("Não há veículos estacionados.");
            }
        }
    }
}
