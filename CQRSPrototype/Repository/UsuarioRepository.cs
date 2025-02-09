using System.Data;
using MySql.Data.MySqlClient;
public class UsuarioRepository : IUsuarioRepository
{
    private readonly DatabaseHelper _dbHelper;

    public UsuarioRepository(DatabaseHelper dbHelper)
    {
        _dbHelper = dbHelper;
    }

    public List<Usuario> GetUsuarios()
    {
        var usuarios = new List<Usuario>();
        var dt = _dbHelper.EjecutarConsulta("SELECT Id, Nombre, Email FROM Usuarios");

        foreach (DataRow row in dt.Rows)
        {
            usuarios.Add(new Usuario
            {
                Id = Convert.ToInt32(row["Id"]),
                Nombre = row["Nombre"].ToString(),
                Email = row["Email"].ToString()
            });
        }
        return usuarios;
    }

    public Usuario GetUsuarioById(int id)
    {
        var dt = _dbHelper.EjecutarConsulta("SELECT Id, Nombre, Email FROM Usuarios WHERE Id = @Id",
            new MySqlParameter[] { new MySqlParameter("@Id", id) });

        if (dt.Rows.Count == 0) return null!;

        var row = dt.Rows[0];
        return new Usuario
        {
            Id = Convert.ToInt32(row["Id"]),
            Nombre = row["Nombre"].ToString()!,
            Email = row["Email"].ToString()!
        };
    }

    public void CreateUsuario(Usuario usuario)
    {
        _dbHelper.EjecutarComando("INSERT INTO Usuarios (Nombre, Email) VALUES (@Nombre, @Email)",
            new MySqlParameter[] {
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