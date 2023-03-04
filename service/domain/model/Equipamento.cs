using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace domain.model
{
    public class Equipamento
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public double Preco { get; set; }
        public string NrSerie { get; set; }
        public DateTime DataFabricacao { get; set; }
        public string Fabricante { get; set; }

        public Equipamento(int id, string nome, double preco, string nrSerie, DateTime dataFabricacao, string fabricante)
        {
            this.Id = id;
            this.Nome = nome;
            this.Preco = preco;
            this.NrSerie = nrSerie;
            this.DataFabricacao = dataFabricacao;
            this.Fabricante = fabricante;

        }


        public static void ValidarCampos(Equipamento equipamento)
        {
            if (equipamento.Nome.Length < 6 || String.IsNullOrWhiteSpace(equipamento.Nome))
            {
                throw new Exception("O nome é obrigatório e precisa ter mais que 6 caracteres");
            }
            else if (String.IsNullOrWhiteSpace(equipamento.NrSerie))
            {
                throw new Exception("O nome é obrigatório e precisa ter mais que 6 caracteres");
            }
            else if (String.IsNullOrWhiteSpace(equipamento.Fabricante))
            {
                throw new Exception("O fabricante é campo obrigatório");
            }
            else if (equipamento.Preco <= 0)
            {
                throw new Exception("O preço é campo obrigatório");
            }
            else if (equipamento.DataFabricacao > DateTime.Now || equipamento.DataFabricacao == default)
            {
                throw new Exception("Data inválida");
            }
        }
    }

}