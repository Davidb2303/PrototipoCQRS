using MySql.Data.MySqlClient;
using CQRSPrototype.IUserCommandRepository;

public class UsuarioCommandRepository : IUsuarioCommandRepository
{
    private readonly DatabaseHelper _dbHelper;

    public UsuarioCommandRepository(DatabaseHelper dbHelper)
    {
        _dbHelper = dbHelper;
    }

    public void CreateUsuario(UsuarioCommandModel usuario)
    {
        _dbHelper.EjecutarComando("INSERT INTO Usuarios (Nombre, Email) VALUES (@Nombre, @Email)",
            new MySqlParameter[]
            {
                new MySqlParameter("@Nombre", usuario.Nombre),
                new MySqlParameter("@Email", usuario.Email)
            });
    }

    public void DeleteUsuario(int id)
    {
        _dbHelper.EjecutarComando("DELETE FROM Usuarios WHERE Id = @Id",
            new MySqlParameter[] { new MySqlParameter("@Id", id) });
    }
}


