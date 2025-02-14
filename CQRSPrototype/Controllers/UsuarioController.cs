using CQRSPrototype.CQRS.Commands;
using Microsoft.AspNetCore.Mvc;

namespace CQRSPrototype.Controllers;

[ApiController]
[Route("api/usuarios")]
public class UsuarioController : ControllerBase
{
    private readonly GetUsuariosQueryHandler _getUsuariosQueryHandler;
    private readonly GetUsuarioByIdQueryHandler _getUsuariosByIdQueryHandler;
    private readonly CreateUsuarioCommandHandler _createUsuarioCommandHandler;
    private readonly DeleteUsuarioCommandHandler _deleteUsuarioCommandHandler;

    public UsuarioController(GetUsuariosQueryHandler getUsuariosQueryHandler, CreateUsuarioCommandHandler createUsuarioCommandHandler, DeleteUsuarioCommandHandler deleteUsuarioCommandHandler, GetUsuarioByIdQueryHandler getUsuariosByIdQueryHandler)
    {
        _getUsuariosQueryHandler = getUsuariosQueryHandler;
        _getUsuariosByIdQueryHandler = getUsuariosByIdQueryHandler;
        _createUsuarioCommandHandler = createUsuarioCommandHandler;
        _deleteUsuarioCommandHandler = deleteUsuarioCommandHandler;


    }
    [HttpGet]
    public IActionResult GetUsuarios()
    {
        var query = new GetUsuariosQueryModel();
        var usuarios = _getUsuariosQueryHandler.Handle(query);

        if (usuarios == null || usuarios.Count == 0)
        {
            return NotFound(new { message = "No se encontraron usuarios" });
        }

        return Ok(usuarios);
    }
    
    [HttpGet("{id}")]
    public IActionResult GetUsuarioById(int id)
    {
        var query = new GetUsuarioByIdQueryModel(id);
        var usuario = _getUsuariosByIdQueryHandler.Handle(query);
        if (usuario == null)
            return NotFound(new { message = "Usuario no encontrado" });

        return Ok(usuario);
    }
    
    [HttpPost]
    public IActionResult CreateUsuario([FromBody] UsuarioCommandModel usuario)
    {
        if (usuario == null || string.IsNullOrWhiteSpace(usuario.Nombre) || string.IsNullOrWhiteSpace(usuario.Email))
            return BadRequest(new { message = "Nombre y Email son obligatorios" });
        
        var usuarioCommand = new CreateUsuarioCommandModel(usuario.Nombre, usuario.Email);

        _createUsuarioCommandHandler.Handle(usuarioCommand);
        return StatusCode(201, new { message = "Usuario creado exitosamente" });
    }

    [HttpDelete("{id}")]
    public IActionResult DeleteUsuario(int id)
    {
        if (id <= 0)
        {
            return BadRequest(new { message = "ID de usuario inválido" });
        }

        var command = new DeleteUsuarioCommandModel(id);
        _deleteUsuarioCommandHandler.Handle(command);
        return Ok(new { message = "El usuario ha sido eliminado" });
    }
}