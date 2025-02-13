using CQRSPrototype.IUserCommandRepository;

public class CreateUsuarioCommand
{
    private readonly IUsuarioCommandRepository _repository;

    public CreateUsuarioCommand(IUsuarioCommandRepository repository)
    {
        _repository = repository;
    }

    public void Execute(UsuarioCommandModel usuario)
    {
        _repository.CreateUsuario(usuario);
    }
}