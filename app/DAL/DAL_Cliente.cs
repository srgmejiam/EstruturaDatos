using EL;
namespace DAL;
public class DAL_Cliente
{
    //Read
    public List<Cliente> Get()
    {
        using Context bd = new();
        return bd.Cliente.ToList();
    }
    public Cliente GetOnlyOne(int ID)
    {
        using Context bd = new();
        return bd.Cliente.Where(a => a.IdCliente == ID).SingleOrDefault()??new();
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
        using Context bd = new();
        var Registro = bd.Cliente.Where(a => a.IdCliente == Entidad.IdCliente).SingleOrDefault();
        Registro.Nombre = Entidad.Nombre;
        Registro.Telefono = Entidad.Telefono;
        Registro.Correo = Entidad.Correo;
        return bd.SaveChanges()>0 ;
    }

    public bool Delete(Cliente Entidad)
    {
        //using Context bd = new();
        //var Registro =bd.Cliente.Where(a => a.IdCliente == Entidad.IdCliente).SingleOrDefault();
        //Cliente.Remove(Registro);
        return true;
    }


}