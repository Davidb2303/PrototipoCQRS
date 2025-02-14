namespace CQRSPrototype.CQRS.Commands;

public class CreateUsuarioCommandModel
{
    public string Nombre { get; set; }
    public string Email { get; set; }

    public CreateUsuarioCommandModel(string nombre, string email)
    {
        Nombre = nombre;
        Email = email;
    }
}