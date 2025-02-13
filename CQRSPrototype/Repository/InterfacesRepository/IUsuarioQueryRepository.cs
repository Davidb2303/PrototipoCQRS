namespace CQRSPrototype.IUserQueryRepository
{
    public interface IUsuarioQueryRepository
    {
        List<UsuarioQueryModel> GetUsuarios();
        UsuarioQueryModel GetUsuarioById(int id);
    }   
}