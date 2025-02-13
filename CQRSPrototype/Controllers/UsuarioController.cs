using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/usuarios")]
public class UsuarioController : ControllerBase
{
    private readonly GetUsuariosQuery _getUsuariosQuery;
    private readonly GetUsuarioByIdQuery _getUsuarioByIdQuery;
    private readonly CreateUsuarioCommand _createUsuarioCommand;
    private readonly DeleteUsuarioCommand _deleteUsuarioCommand;

    public UsuarioController(GetUsuariosQuery getUsuariosQuery, CreateUsuarioCommand createUsuarioCommand, DeleteUsuarioCommand deleteUsuarioCommand, GetUsuarioByIdQuery getUsuariosByIdQuery)
    {
        _getUsuariosQuery = getUsuariosQuery;
        _getUsuarioByIdQuery = getUsuariosByIdQuery;
        _createUsuarioCommand = createUsuarioCommand;
        _deleteUsuarioCommand = deleteUsuarioCommand;


    }
    [HttpGet]
    public IActionResult GetUsuarios()
    {
        var usuarios = _getUsuariosQuery.Execute();
        return Ok(usuarios);
    }

    [HttpGet("{id}")]
    public IActionResult GetUsuarioById(int id)
    {
        var usuario = _getUsuarioByIdQuery.Execute(id);
        if (usuario == null)
            return NotFound(new { message = "Usuario no encontrado" });

        return Ok(usuario);
    }
    
    [HttpPost]
    public IActionResult CreateUsuario([FromBody] UsuarioCommandModel usuario)
    {
        if (usuario == null || string.IsNullOrWhiteSpace(usuario.Nombre) || string.IsNullOrWhiteSpace(usuario.Email))
            return BadRequest(new { message = "Nombre y Email son obligatorios" });

        _createUsuarioCommand.Execute(usuario);
        return StatusCode(201, new { message = "Usuario creado exitosamente" });
    }

    [HttpDelete("{id}")]
    public IActionResult DeleteUsuario(int id)
    {
        var usuario = _getUsuarioByIdQuery.Execute(id);
        if (usuario == null)
            return NotFound(new { message = "Usuario no encontrado" });

        _deleteUsuarioCommand.Execute(id);
        return Ok(new { message = "Usuario eliminado correctamente" });
    }
}