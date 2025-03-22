using EL;
namespace DAL;
public class DAL_Cliente
{
    //Tabla BD
    private List<Cliente> Clientes { get; set; } = new();
    //Read
    public List<Cliente> Get()
    {
        using Context bd = new();
        return bd.Cliente.ToList();
    }
    //Create
    public int Insertar(Cliente Entidad)
    {
        using Context bd = new();
        bd.Cliente.Add(Entidad);
        bd.SaveChanges();
        return Entidad.IdCliente;
    }
    //Update
    public bool Update(Cliente Entidad)
    {
        var Registro = Clientes.Where(a => a.IdCliente == Entidad.IdCliente).SingleOrDefault();
        Registro.Nombre = Entidad.Nombre;
        Registro.Telefono = Entidad.Telefono;
        return true;
    }

    public bool Delete(Cliente Entidad)
    {

        var Registro = Clientes.Where(a => a.IdCliente == Entidad.IdCliente).SingleOrDefault();
        Clientes.Remove(Registro);
        return true;
    }


}