using FluentResults;
using Microsoft.AspNetCore.Identity;
using UsuariosAPI.Models;

namespace UsuariosAPI.Services
{
    public class LogoutService
    {
        private SignInManager<CustomIdentityUser> _signManager;

        public LogoutService(SignInManager<CustomIdentityUser> signManager)
        {
            _signManager = signManager;
        }

        public Result DeslogaUsuario()
        {
            var resultadoIdentity = _signManager.SignOutAsync();
            if (resultadoIdentity.IsCompletedSuccessfully) return Result.Ok();
            return Result.Fail("Logout falhou!");
        }
    }
}
