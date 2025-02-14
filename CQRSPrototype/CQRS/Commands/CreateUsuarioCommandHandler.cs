using CQRSPrototype.IUserCommandRepository;

namespace CQRSPrototype.CQRS.Commands;

public class CreateUsuarioCommandHandler
{
    private readonly IUsuarioCommandRepository _repository;

    public CreateUsuarioCommandHandler(IUsuarioCommandRepository repository)
    {
        _repository = repository;
    }

    public void Handle(CreateUsuarioCommandModel usuario)
    {
        var usuarioModel = new UsuarioCommandModel
        {
            Nombre = usuario.Nombre,
            Email = usuario.Email
        };
        _repository.CreateUsuario(usuarioModel);
    }
}