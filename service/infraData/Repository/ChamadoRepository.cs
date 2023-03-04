using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using domain.IRepository;
using domain.model;
using infraData.DAO;

namespace infraData.Repository
{
    public class ChamadoRepository : IChamadoRepository
    {
        private readonly ChamadoDAO _chamadoDAO;
        public ChamadoRepository()
        {
            this._chamadoDAO = new ChamadoDAO();
        }
        public Chamado BuscarChamadoPorId(int id)
        {
            var chamado = _chamadoDAO.BuscarPorId(id);
            if (chamado == null)
            {
                throw new Exception("Chamado não encontrado");
            }

            return chamado;
        }

        public List<Chamado> BuscarTodos()
        {
            return _chamadoDAO.BuscarTodos();
        }

        public bool Cadastrar(Chamado chamado)
        {
            var sucesso = _chamadoDAO.Cadastrar(chamado);
            if (!sucesso)
            {
                throw new Exception("Algo deu errado ao tentar efetuar o chamado.");
            }
            return sucesso;
        }



        public bool Editar(Chamado chamado)
        {
            var sucesso = _chamadoDAO.Editar(chamado);
            if (!sucesso)
            {
                throw new Exception("Algo deu errado ao tentar editar o cadastro.");
            }
            return sucesso;
        }

        public void ExcluiPorEquipamento(int id)
        {
            _chamadoDAO.ExcluirChamadoPorEquipamento(id);
        }

        public bool Excluir(int id)
        {
            var sucesso = _chamadoDAO.Excluir(id);
            if (!sucesso)
            {
                throw new Exception("Algo deu errado ao tentar excluir o cadastro.");
            }
            return sucesso;
        }
    }
}