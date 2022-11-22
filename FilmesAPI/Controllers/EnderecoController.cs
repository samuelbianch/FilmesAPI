using AutoMapper;
using Castle.DynamicProxy.Generators.Emitters.SimpleAST;
using FilmesApi.Data;
using FilmesApi.Data.Dtos.Endereco;
using FilmesApi.Models;
using FilmesApi.Services;
using FluentResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace FilmesAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EnderecoController : ControllerBase
    {
        private EnderecoService _enderecoService;

        public EnderecoController(EnderecoService enderecoService)
        {
            _enderecoService = enderecoService;
        }

        [HttpPost]
        public IActionResult AdicionaEndereco([FromBody] CreateEnderecoDto enderecoDto)
        {
            ReadEnderecoDto readDto = _enderecoService.AdicionaEndereco(enderecoDto);

            return CreatedAtAction(nameof(RecuperaEnderecosPorId), new { Id = readDto.Id }, readDto);
        }

        [HttpGet]
        public IActionResult RecuperaEnderecos()
        {
            List<ReadEnderecoDto> readDto = _enderecoService.RecuperaEnderecos();
            if (readDto == null) return NotFound();
            return Ok(readDto);
        }

        [HttpGet("{id}")]
        public IActionResult RecuperaEnderecosPorId(int id)
        {
            ReadEnderecoDto enderecoDto = _enderecoService.RecuperaEnderecosPorId(id);
            if (enderecoDto != null) return Ok(enderecoDto);
            return NotFound();
        }

        [HttpPut("{id}")]
        public IActionResult AtualizaEndereco(int id, [FromBody] UpdateEnderecoDto enderecoDto)
        {
            Result resultado = _enderecoService.AtualizaEndereco(id, enderecoDto);
            if(resultado.IsFailed) return NotFound();
            return NoContent();
        }


        [HttpDelete("{id}")]
        public IActionResult DeletaEndereco(int id)
        {
            Result resultado = _enderecoService.DeletaEndereco(id);
            if (resultado.IsFailed) return NotFound();
            return NoContent();
        }

    }
}