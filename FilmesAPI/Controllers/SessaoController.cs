using AutoMapper;
using FilmesApi.Data;
using FilmesApi.Data.Dtos.Sessao;
using FilmesApi.Models;
using FilmesApi.Services;
using FilmesAPI.Data.Dtos;
using FilmesAPI.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace FilmesApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SessaoController : ControllerBase
    {
        private SessaoService _sessaoService;

        public SessaoController(SessaoService sessaoService)
        {
            _sessaoService = sessaoService;
        }

        [HttpPost]
        public IActionResult AdicionaSessao([FromBody] CreateSessaoDto sessaoDto)
        {
            ReadCinemaDto readDto = _sessaoService.AdicionaSessao(sessaoDto);
            return CreatedAtAction(nameof(RecuperaSessoesPorId), new { Id = readDto.Id }, readDto);
        }

        [HttpGet]
        public IEnumerable<Sessao> RecuperaSessoes()
        {
            return _context.Sessoes;
        }

        [HttpGet("{id}")]
        public IActionResult RecuperaSessoesPorId(int id)
        {
            ReadSessaoDto sessaoDto = _sessaoService.RecuperaSessoesPorId(id);
            if (sessaoDto != null) return Ok(sessaoDto);
            return NotFound();
        }


    }
}
