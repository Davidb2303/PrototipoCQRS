using CQRSPrototype.IUserCommandRepository;
namespace CQRSPrototype.CQRS.Commands;

public class DeleteUsuarioCommandHandler
{
    private readonly IUsuarioCommandRepository _repository;

    public DeleteUsuarioCommandHandler(IUsuarioCommandRepository repository)
    {
        _repository = repository;
    }

    public void Handle(DeleteUsuarioCommandModel command)
    {
        _repository.DeleteUsuario(command.Id);
    }
}