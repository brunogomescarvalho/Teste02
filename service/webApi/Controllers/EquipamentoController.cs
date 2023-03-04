using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using domain.IRepository;
using domain.model;
using infraData.Repository;
using Microsoft.AspNetCore.Mvc;

namespace webApi.Controllers
{
    [ApiController]
    [Route("api/equipamento")]
    public class EquipamentoController : ControllerBase
    {
        private readonly IChamadoRepository _chamadoRepository;
        private readonly IEquipamentoRepository _equipamentoRepository;

        public EquipamentoController()
        {
            _equipamentoRepository = new EquipamentoRepository();
            _chamadoRepository = new ChamadoRepository();
        }

        [HttpPost]
        public IActionResult Cadastrar([FromBody] Equipamento equipamento)
        {
            try
            {
                Equipamento.ValidarCampos(equipamento);
                _equipamentoRepository.Cadastrar(equipamento);
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message);
            }
            return Ok(true);
        }

        [HttpGet("id/{id}")]
        public IActionResult BuscarPorId(int id)
        {
            Equipamento equipamento = null!;
            try
            {
                equipamento = _equipamentoRepository.BuscarEquipamentoPorId(id);
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message);
            }
            return Ok(equipamento);
        }

        [HttpGet]
        public IActionResult BuscarTodos()
        {
            List<Equipamento> equipamentos = _equipamentoRepository.BuscarTodos();

            if (equipamentos.Count == 0)
            {
                return BadRequest("Nenhum equipamento cadastrado");
            }

            return Ok(equipamentos);
        }

        [HttpPut]
        public IActionResult Editar([FromBody] Equipamento equipamento)
        {
            try
            {
                Equipamento.ValidarCampos(equipamento);

                var itemEditar = _equipamentoRepository.BuscarEquipamentoPorId(equipamento.Id);

                itemEditar = equipamento;

                _equipamentoRepository.Editar(itemEditar);
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message);
            }
            return Ok(true);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                _chamadoRepository.ExcluiPorEquipamento(id);
                _equipamentoRepository.Excluir(id);
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message);
            }
            return Ok(true);

        }


    }
}