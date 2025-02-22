using EL;
namespace DAL;
public class DAL_Cliente
{
    //Tabla BD
    private List<Cliente> Clientes { get; set; } = new();
    //Read
    public List<Cliente> Get()
    {
        return Clientes;
    }
    //Create
    public int Insertar(Cliente Entidad)
    {
        Clientes.Add(Entidad);
        return Entidad.Id;
    }
    //Update
    public bool Update(Cliente Entidad)
    {
        var Registro = Clientes.Where(a => a.Id == Entidad.Id).SingleOrDefault();
        Registro.Nombre = Entidad.Nombre;
        Registro.Edad = Entidad.Edad;
        return true;
    }

     public bool Delete(Cliente Entidad)
    {

        var Registro = Clientes.Where(a => a.Id == Entidad.Id).SingleOrDefault();
        Clientes.Remove(Registro);
        return true;
    }
    

}