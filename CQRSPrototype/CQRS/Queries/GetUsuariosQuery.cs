public class GetUsuariosQuery
{
    private readonly IUsuarioRepository _repository;

    public GetUsuariosQuery(IUsuarioRepository repository)
    {
        _repository = repository;
    }

    public List<Usuario> Execute()
    {
        return _repository.GetUsuarios();
    }
}