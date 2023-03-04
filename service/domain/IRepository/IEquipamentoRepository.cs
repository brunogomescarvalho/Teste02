using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using domain.model;

namespace domain.IRepository
{
    public interface IEquipamentoRepository
    {
        bool Cadastrar(Equipamento equipamento);
        Equipamento BuscarEquipamentoPorId(int id);
        List<Equipamento> BuscarTodos();
        bool Editar(Equipamento equipamento);
        bool Excluir(int id);
    }
}