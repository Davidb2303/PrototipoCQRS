namespace CQRSPrototype.IUserCommandRepository
{
    public interface IUsuarioCommandRepository
    { 
        void CreateUsuario(UsuarioCommandModel usuario);
        void DeleteUsuario(int id);
    }          
}
