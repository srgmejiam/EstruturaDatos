using EL;
using Microsoft.EntityFrameworkCore;

public class Context:DbContext
{
    public virtual DbSet<Cliente> Cliente {get;set;}
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(@"Server=services.alldevsolutions.net,1460\DEV2022;Database=Facturacion;User Id=univalle;Password=#Univalle#123;TrustServerCertificate=True;");
    }
}