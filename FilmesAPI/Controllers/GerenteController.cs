using AutoMapper;
using FilmesApi.Data;
using FilmesApi.Data.Dtos.Gerente;
using FilmesApi.Models;
using FilmesApi.Services;
using FilmesAPI.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

namespace FilmesApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class GerenteController : ControllerBase
    {
        private GerenteService _gerenteService;

        public GerenteController(GerenteService gerenteService)
        {
            _gerenteService = gerenteService;
        }

        [HttpPost]
        public IActionResult AdicionaGerente(CreateGerenteDto gerenteDto)
        {
            ReadGerenteDto readDto = _gerenteService.AdicionaGerente(gerenteDto);

            return CreatedAtAction(nameof(RecuperaGerentePorId), new { Id = readDto.Id }, readDto);
        }

        [HttpGet]
        public IActionResult RecuperaGerente()
        {
            List<ReadGerenteDto> gerente = _gerenteService.RecuperaGerente();
            if (gerente == null) return NotFound();
            return Ok(gerente);
        }

        [HttpGet("{id}")]
        public IActionResult RecuperaGerentePorId(int id)
        {
            ReadGerenteDto gerente = _gerenteService.RecuperaGerentePorId(id);
            if (gerente != null) return Ok(gerente);
            return NotFound();
        }
    }
}
