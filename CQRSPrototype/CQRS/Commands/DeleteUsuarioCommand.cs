using CQRSPrototype.IUserCommandRepository;

public class DeleteUsuarioCommand
{
    private readonly IUsuarioCommandRepository _repository;

    public DeleteUsuarioCommand(IUsuarioCommandRepository repository)
    {
        _repository = repository;
    }

    public void Execute(int id)
    {
        _repository.DeleteUsuario(id);
    }
}