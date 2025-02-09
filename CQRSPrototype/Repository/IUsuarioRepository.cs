public interface IUsuarioRepository
{
    List<Usuario> GetUsuarios();
    Usuario GetUsuarioById(int id);
    void CreateUsuario(Usuario usuario);
    void DeleteUsuario(int id);
}