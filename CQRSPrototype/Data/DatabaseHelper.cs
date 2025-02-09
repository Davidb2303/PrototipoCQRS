using MySql.Data.MySqlClient;
using System.Data;

public class DatabaseHelper
{
    private readonly string _connectionString;

    public DatabaseHelper(string connectionString)
    {
        _connectionString = connectionString;
    }

    public DataTable EjecutarConsulta(string query, MySqlParameter[]? parametros = null)
    {
        DataTable dataTable = new DataTable();

        using (var connection = new MySqlConnection(_connectionString))
        {
            connection.Open();
            using (var command = new MySqlCommand(query, connection))
            {
                if (parametros != null)
                    command.Parameters.AddRange(parametros);

                using (var adapter = new MySqlDataAdapter(command))
                {
                    adapter.Fill(dataTable);
                }
            }
        }

        return dataTable;
    }

    public int EjecutarComando(string query, MySqlParameter[]? parametros = null)
    {
        using (var connection = new MySqlConnection(_connectionString))
        {
            connection.Open();
            using (var command = new MySqlCommand(query, connection))
            {
                if (parametros != null)
                    command.Parameters.AddRange(parametros);

                return command.ExecuteNonQuery();
            }
        }
    }
}