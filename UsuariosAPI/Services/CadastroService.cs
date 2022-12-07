using AutoMapper;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;
using UsuariosAPI.Data.Dtos;
using UsuariosAPI.Models;
using FluentResults;
using UsuariosAPI.Data.Request;
using System;
using System.Linq;
using System.Web;

namespace UsuariosAPI.Services
{
    public class CadastroService
    {
        private IMapper _mapper;
        private UserManager<CustomIdentityUser> _userManager;
        private EmailService _emailService;

        public CadastroService(IMapper mapper, UserManager<CustomIdentityUser> userManager, EmailService emailService, RoleManager<IdentityRole<int>> roleManager)
        {
            _mapper = mapper;
            _userManager = userManager;
            _emailService = emailService;
        }

        public Result CadastraUsuario(CreateUsuarioDto createDto)
        {
            Usuario usuario = _mapper.Map<Usuario>(createDto);
            CustomIdentityUser usuarioIdentity = _mapper.Map<CustomIdentityUser>(usuario);
            Task<IdentityResult> resultadoIdentity = _userManager.CreateAsync(usuarioIdentity, createDto.Password);
            _userManager.AddToRoleAsync(usuarioIdentity, "regular");
            if (resultadoIdentity.Result.Succeeded) 
            {
                
                string code = _userManager.GenerateEmailConfirmationTokenAsync(usuarioIdentity).Result;
                string endedCode = HttpUtility.UrlEncode(code);
                //_emailService.EnviarEmail(new[] { usuarioIdentity.Email }, "Link de Ativação", usuarioIdentity.Id, endedCode);
                return Result.Ok().WithSuccess(code).WithSuccess(code);
            } 
            return Result.Fail("Falha ao cadastrar usuário");
        }

        public Result AtivaContaRequest(AtivaContaRequest request)
        {
            var identityUser = _userManager.Users.FirstOrDefault(u => u.Id == request.usuarioId);
            var identityResult = _userManager.ConfirmEmailAsync(identityUser, request.CodigoDeAtivacao).Result;
            if (identityResult.Succeeded)
            {
                return Result.Ok().WithSuccess("Conta ativada!");
            }
            return Result.Fail("Falha ao ativar conta de usuário");
        }
    }
}
