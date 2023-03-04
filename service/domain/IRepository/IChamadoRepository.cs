using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using domain.model;

namespace domain.IRepository
{
    public interface IChamadoRepository
    {
        bool Cadastrar(Chamado chamado);
        Chamado BuscarChamadoPorId(int id);
        List<Chamado> BuscarTodos();
        bool Editar(Chamado chamado);
        bool Excluir(int id);
        void ExcluiPorEquipamento(int id);
    }
}