using FluentResults;
using Microsoft.AspNetCore.Identity;
using System;
using System.Linq;
using UsuariosAPI.Data.Request;
using UsuariosAPI.Models;

namespace UsuariosAPI.Services
{
    public class LoginService
    {
        private SignInManager<CustomIdentityUser> _siginInManager;
        private TokenService _tokenService;

        public LoginService(SignInManager<CustomIdentityUser> siginInManager, 
            TokenService tokenService)
        {
            _siginInManager = siginInManager;
            _tokenService = tokenService;
        }

        public Result LogaUsuario(LoginRequest request)
        {
            var resultadoIdentity = _siginInManager.PasswordSignInAsync(request.UserName, 
                request.Password, false, false);
            if (resultadoIdentity.Result.Succeeded)
            {
                var identityUser = _siginInManager.UserManager.Users
                    .FirstOrDefault(usuario => usuario.NormalizedUserName == 
                    request.UserName.ToUpper());

                Token token = _tokenService.CreateToken(identityUser, _siginInManager.UserManager.GetRolesAsync(identityUser).Result.FirstOrDefault());
                return Result.Ok().WithSuccess(token.Value);
            }
            return Result.Fail("Falha ao fazer login!");
        }

        public Result SolicitaResetSenhaUsuario(SolicitaResetRequest request)
        {
            CustomIdentityUser identityUser = RecuperaEmail(request.Email);
            if (identityUser != null)
            {
                string codigoDeRecuperacao = _siginInManager.UserManager.GeneratePasswordResetTokenAsync(identityUser).Result;
                return Result.Ok().WithSuccess(codigoDeRecuperacao);
            }

            return Result.Fail("Falha ao solicitar redefinição");
        }

        public Result ResetaSenhaUsuario(EfetuaResetRequest request)
        {
            CustomIdentityUser identityUser = RecuperaEmail(request.Email);
            IdentityResult resultadoIdentity = _siginInManager.UserManager.ResetPasswordAsync(identityUser, request.Token, request.Password).Result;
            if (resultadoIdentity.Succeeded) return Result.Ok().WithSuccess("Senha redefinida com sucesso!");
            return Result.Fail("Houve um erro interno");
        }

        private CustomIdentityUser RecuperaEmail(string email)
        {
            return _siginInManager.UserManager.Users.FirstOrDefault(u => u.NormalizedEmail == email.ToUpper());
        }
    }
}
