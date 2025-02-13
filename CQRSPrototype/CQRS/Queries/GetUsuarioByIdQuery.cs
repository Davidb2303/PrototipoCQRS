using CQRSPrototype.IUserQueryRepository;

public class GetUsuarioByIdQuery
{
    private readonly IUsuarioQueryRepository _repository;

    public GetUsuarioByIdQuery(IUsuarioQueryRepository repository)
    {
        _repository = repository;
    }

    public UsuarioQueryModel Execute(int id)
    {
        return _repository.GetUsuarioById(id);
    }
}