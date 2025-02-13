using System.Data;
using MySql.Data.MySqlClient;
using CQRSPrototype.IUserQueryRepository;

public class UsuarioQueryRepository : IUsuarioQueryRepository
{
    private readonly DatabaseHelper _dbHelper;

    public UsuarioQueryRepository(DatabaseHelper dbHelper)
    {
        _dbHelper = dbHelper;
    }

    public List<UsuarioQueryModel> GetUsuarios()
    {
        var usuarios = new List<UsuarioQueryModel>();
        var dt = _dbHelper.EjecutarConsulta("SELECT Id, Nombre, Email FROM Usuarios");

        foreach (DataRow row in dt.Rows)
        {
            usuarios.Add(new UsuarioQueryModel
            {
                Id = Convert.ToInt32(row["Id"]),
                Nombre = row["Nombre"].ToString()!,
                Email = row["Email"].ToString()!
            });
        }
        return usuarios;
    }

    public UsuarioQueryModel GetUsuarioById(int id)
    {
        var dt = _dbHelper.EjecutarConsulta("SELECT Id, Nombre, Email FROM Usuarios WHERE Id = @Id",
            new MySqlParameter[] { new MySqlParameter("@Id", id) });

        if (dt.Rows.Count == 0) return null!;

        var row = dt.Rows[0];
        return new UsuarioQueryModel
        {
            Id = Convert.ToInt32(row["Id"]),
            Nombre = row["Nombre"].ToString()!,
            Email = row["Email"].ToString()!
        };
    }
}