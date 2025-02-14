using CQRSPrototype.IUserQueryRepository;


public class GetUsuarioByIdQueryHandler
{
    private readonly IUsuarioQueryRepository _repository;

    public GetUsuarioByIdQueryHandler(IUsuarioQueryRepository repository)
    {
        _repository = repository;
    }

    public UsuarioQueryModel Handle(GetUsuarioByIdQueryModel query)
    {
        return _repository.GetUsuarioById(query.Id);
    }
}