using Formula1API.DTO;
using Formula1API.Model;
using Formula1API.Repository;
using Formula1API.Service;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Formula1API.Controller;

[Route("api/[controller]")]
[ApiController]

public class AutenticacaoController : ControllerBase
{
    private readonly UserManager<Usuario> _userManager;
    private readonly ITokenService _tokenService;
    private readonly SignInManager<Usuario> _signInManager;
    
    public AutenticacaoController(UserManager<Usuario> userManager, ITokenService tokenService, SignInManager<Usuario> signInManager)
    {
        _userManager = userManager;
        _tokenService = tokenService;
        _signInManager = signInManager;
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login(LoginDTO loginDTO)
    {
        if(!ModelState.IsValid)
            return BadRequest(ModelState);
        
        var usuario = await _userManager.Users.FirstOrDefaultAsync(user => user.UserName == loginDTO.Username);
        
        if(usuario == null)
            return Unauthorized("Usuario invalido");
        
        var result = await _signInManager.CheckPasswordSignInAsync(usuario, loginDTO.Password, false);
        
        if(!result.Succeeded)
            return Unauthorized("Usuario ou senha incorretos");

        return Ok(
            new NovoUsuarioDTO
            {
                Usuario = usuario.UserName,
                Email = usuario.Email,
                Token = _tokenService.CriarToken(usuario)
            }
        );

    }

    [HttpPost("cadastro")]
    public async Task<IActionResult> Cadastro([FromBody] RegistroDTO registro)
    {
        try
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var appUser = new Usuario
            {
                UserName = registro.Usuario,
                Email = registro.Email,
            };
            
            var createdUser = await _userManager.CreateAsync(appUser, registro.Senha);

            if (createdUser.Succeeded)
            {
                var roles = await _userManager.AddToRoleAsync(appUser, "User");
                if (roles.Succeeded)
                {
                    return Ok(
                        new NovoUsuarioDTO
                        {
                            Usuario = registro.Usuario,
                            Email = registro.Email,
                        }
                        );
                    
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