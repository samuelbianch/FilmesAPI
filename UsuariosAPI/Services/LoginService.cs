using FluentResults;
using Microsoft.AspNetCore.Identity;
using UsuariosAPI.Data.Request;

namespace UsuariosAPI.Services
{
    public class LoginService
    {
        private SignInManager<IdentityUser<int>> _siginInManager;

        public LoginService(SignInManager<IdentityUser<int>> siginInManager)
        {
            _siginInManager = siginInManager;
        }

        public Result LogaUsuario(LoginRequest request)
        {
            var resultadoIdentity = _siginInManager.PasswordSignInAsync(request.UserName, request.Password, false, false);
            if (resultadoIdentity.Result.Succeeded) return Result.Ok();
            return Result.Fail("Falha ao fazer login!");
        }
    }
}
