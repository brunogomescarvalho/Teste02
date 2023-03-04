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
    [Route("api/chamado")]
    public class ChamadoController : ControllerBase
    {
        private readonly IChamadoRepository _chamadoRepository;
        private readonly IEquipamentoRepository _equipamentoRepository;

        public ChamadoController()
        {
            _chamadoRepository = new ChamadoRepository();
            _equipamentoRepository = new EquipamentoRepository();
        }

        [HttpPost]
        public IActionResult Cadastrar([FromBody] Chamado chamado)
        {
            try
            {
                Chamado.ValidarCampos(chamado);
                var equipamento = _equipamentoRepository.BuscarEquipamentoPorId(chamado.Equipamento.Id);
                chamado.Equipamento = equipamento;
                _chamadoRepository.Cadastrar(chamado);
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
            Chamado chamado = null!;
            try
            {
                chamado = _chamadoRepository.BuscarChamadoPorId(id);
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message);
            }
            return Ok(chamado);
        }

        [HttpGet]
        public IActionResult BuscarTodos()
        {
            List<Chamado> chamados = _chamadoRepository.BuscarTodos();

            if (chamados.Count == 0)
            {
                return BadRequest("Nenhum chamado cadastrado");
            }

            return Ok(chamados);
        }

        [HttpPut]
        public IActionResult Editar([FromBody] Chamado chamado)
        {
            try
            {
                Chamado.ValidarCampos(chamado);

                var itemEditar = _chamadoRepository.BuscarChamadoPorId(chamado.Id);
                var equipamento = _equipamentoRepository.BuscarEquipamentoPorId(itemEditar.Equipamento.Id);
                itemEditar.Equipamento = equipamento;

                itemEditar = chamado;

                _chamadoRepository.Editar(itemEditar);
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
                _chamadoRepository.Excluir(id);
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message);
            }
            return Ok(true);

        }


    }
}
