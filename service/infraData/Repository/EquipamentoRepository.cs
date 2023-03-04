using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using domain.IRepository;
using domain.model;
using infraData.DAO;

namespace infraData.Repository
{
    public class EquipamentoRepository : IEquipamentoRepository
    {
        private readonly EquipamentoDAO _equipamentoDAO;

        public EquipamentoRepository()
        {
            this._equipamentoDAO = new EquipamentoDAO();
        }

        public Equipamento BuscarEquipamentoPorId(int id)
        {
            var equipamento = _equipamentoDAO.BuscarPorId(id);
            if (equipamento == null)
            {
                throw new Exception("Equipamento não encontrado");
            }

            return equipamento;
        }

        public List<Equipamento> BuscarTodos()
        {
            return _equipamentoDAO.BuscarTodos();
        }

        public bool Cadastrar(Equipamento equipamento)
        {
            var sucesso = _equipamentoDAO.Cadastrar(equipamento);
            if (!sucesso)
            {
                throw new Exception("Algo deu errado ao tentar efetuar o cadastro.");
            }
            return sucesso;
        }

        public bool Editar(Equipamento equipamento)
        {
            var sucesso = _equipamentoDAO.Editar(equipamento);
            if (!sucesso)
            {
                throw new Exception("Algo deu errado ao tentar editar o cadastro.");
            }
            return sucesso;
        }

        public bool Excluir(int id)
        {
            var sucesso = _equipamentoDAO.Excluir(id);
            if (!sucesso)
            {
                throw new Exception("Algo deu errado ao tentar excluir o cadastro.");
            }
            return sucesso;
        }
    }
}