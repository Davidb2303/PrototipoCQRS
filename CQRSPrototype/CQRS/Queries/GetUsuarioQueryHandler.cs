using CQRSPrototype.IUserQueryRepository;


public class GetUsuariosQueryHandler
{
    private readonly IUsuarioQueryRepository _repository;

    public GetUsuariosQueryHandler(IUsuarioQueryRepository repository)
    {
        _repository = repository;
    }

    public List<UsuarioQueryModel> Handle(GetUsuariosQueryModel query)
    {
        return _repository.GetUsuarios();
    }
}