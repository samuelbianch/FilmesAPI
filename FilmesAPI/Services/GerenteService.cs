using AutoMapper;
using FilmesApi.Data;
using FilmesApi.Data.Dtos.Gerente;
using FilmesApi.Models;
using FilmesAPI.Data.Dtos;
using FilmesAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace FilmesApi.Services
{
    public class GerenteService
    {
        private AppDbContext _context;
        private IMapper _mapper;

        public GerenteService(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public ReadGerenteDto AdicionaGerente(CreateGerenteDto gerenteDto)
        {
            Gerente gerente = _mapper.Map<Gerente>(gerenteDto);
            _context.Gerentes.Add(gerente);
            _context.SaveChanges();

            return _mapper.Map<ReadGerenteDto>(gerente);
        }

        public List<ReadGerenteDto> RecuperaGerente()
        {
            List<Gerente> gerente = _context.Gerentes.ToList();
            if(gerente == null) return null;
            return _mapper.Map<List<ReadGerenteDto>>(gerente);
        }

        public ReadGerenteDto RecuperaGerentePorId(int id)
        {
            Gerente gerente = _context.Gerentes.FirstOrDefault(gerente => gerente.Id == id);
            if (gerente != null)
            {
                ReadGerenteDto gerenteDto = _mapper.Map<ReadGerenteDto>(gerente);

                return gerenteDto;
            }
            return null;
        }
    }
}
