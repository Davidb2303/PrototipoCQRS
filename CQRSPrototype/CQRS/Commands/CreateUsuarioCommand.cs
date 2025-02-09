public class CreateUsuarioCommand
{
    private readonly IUsuarioRepository _repository;

    public CreateUsuarioCommand(IUsuarioRepository repository)
    {
        _repository = repository;
    }

    public void Execute(Usuario usuario)
    {
        _repository.CreateUsuario(usuario);
    }
}