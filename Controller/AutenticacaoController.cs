using Formula1API.DTO;
using Formula1API.Model;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Formula1API.Controller;

[Route("api/[controller]")]
[ApiController]

public class AutenticacaoController : ControllerBase
{
    private readonly UserManager<AppUser> _userManager;
    
    public AutenticacaoController(UserManager<AppUser> userManager)
    {
        _userManager = userManager;
    }

    [HttpPost("cadastro")]
    public async Task<IActionResult> Cadastro([FromBody] UserDTO user)
    {
        try
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var appUser = new AppUser
            {
                UserName = user.Usuario,
                Email = user.Email,
            };
            
            var createdUser = await _userManager.CreateAsync(appUser, user.Senha);

            if (createdUser.Succeeded)
            {
                var roles = await _userManager.AddToRoleAsync(appUser, "User");
                if (roles.Succeeded)
                {
                    return Ok("Usuario criado");
                }
                else
                {
                    return StatusCode(500, roles.Errors);
                }
            }
            else
            {
                return StatusCode(500, createdUser.Errors);
            }

        }
        catch (Exception e)
        {
            return StatusCode(500, e.Message);
        }
        
    }
    
}