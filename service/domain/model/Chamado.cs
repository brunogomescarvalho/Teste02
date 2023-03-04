using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace domain.model
{
    public class Chamado
    {
        public int Id { get; set; }
        public string Titulo { get; set; }
        public string Descricao { get; set; }
        public DateTime DataAbertura { get; set; }
        public int DiasEmAberto { get => this.CalcularDiasEmAberto(); }
        public Equipamento Equipamento { get; set; }


        public Chamado(int id, string titulo, string descricao, Equipamento equipamento, DateTime dataAbertura)
        {

            this.Id = id;
            this.Titulo = titulo;
            this.Descricao = descricao;
            this.Equipamento = equipamento;
            this.DataAbertura = dataAbertura;

        }

        public int CalcularDiasEmAberto()
        {
            return Convert.ToInt16(DateTime.Now.Subtract(this.DataAbertura).TotalDays);
        }

        public static void ValidarCampos(Chamado chamado)
        {
            if (String.IsNullOrWhiteSpace(chamado.Titulo))
            {
                throw new Exception("Título do chamado é campo obrigatório");
            }
            else if (String.IsNullOrWhiteSpace(chamado.Descricao))
            {
                throw new Exception("Descrição do chamado é campo obrigatório");
            }
            else if (chamado.Descricao.Length >= 400)
            {
                throw new Exception("Descrição com números de caracteres acima do limite de 400");
            }
            else if (chamado.Equipamento == null)
            {
                throw new Exception("É necessário um equipamento para cadastrar um chamado");
            }
            else if (chamado.DataAbertura > DateTime.Now || chamado.DataAbertura == default)
            {
                throw new Exception("Data inválida");
            }

        }
    }

}