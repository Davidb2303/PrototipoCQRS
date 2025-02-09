using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/usuarios")]
public class UsuarioController : ControllerBase
{
    private readonly GetUsuariosQuery _getUsuariosQuery;
    private readonly CreateUsuarioCommand _createUsuarioCommand;

    public UsuarioController(GetUsuariosQuery getUsuariosQuery, CreateUsuarioCommand createUsuarioCommand)
    {
        _getUsuariosQuery = getUsuariosQuery;
        _createUsuarioCommand = createUsuarioCommand;
    }

    [HttpGet]
    public IActionResult GetUsuarios() => Ok(_getUsuariosQuery.Execute());

    [HttpPost]
    public IActionResult CreateUsuario([FromBody] Usuario usuario)
    {
        _createUsuarioCommand.Execute(usuario);
        return StatusCode(201);
    }
}