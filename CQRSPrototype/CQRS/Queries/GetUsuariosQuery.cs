using CQRSPrototype.IUserQueryRepository;
public class GetUsuariosQuery
{
    private readonly IUsuarioQueryRepository _repository;

    public GetUsuariosQuery(IUsuarioQueryRepository repository)
    {
        _repository = repository;
    }

    public List<UsuarioQueryModel> Execute()
    {
        return _repository.GetUsuarios();
    }
}