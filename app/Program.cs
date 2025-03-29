using DAL;
using EL;
//Variables Utilizadas
int Menu = 0;
int ID = 0;
//Objetos Utilizados
DAL_Cliente DAL = new();
Cliente Registro = new();

do
{


    Console.WriteLine("Ingrese la operación que desee realizar");
    Console.WriteLine("Salir: 5");
    Console.WriteLine("Agregar: 1");
    Console.WriteLine("Actualizar: 2");
    Console.WriteLine("Ver: 3");
    Console.WriteLine("Eliminar: 4");
    _ = int.TryParse(Console.ReadLine() ?? "", out Menu);
    switch (Menu)
    {
        case 0:
            Console.WriteLine("Ingrese un valor válido");
            Console.ReadKey();
            break;
        case 1://Insertar
            Console.Clear();
            Registro = new();
            // Registro.IdCliente = DAL.Get().Count() + 1;

            Console.WriteLine("Ingrese el Nombre del Cliente.");
            Registro.Nombre = Console.ReadLine() ?? "";

            Console.WriteLine("Ingrese el Correo del Cliente.");
            Registro.Correo = Console.ReadLine() ?? "";

            Console.WriteLine("Ingrese el telefono del Cliente.");
            Registro.Telefono = Console.ReadLine() ?? "";

            if (validar(Registro))
            {
                DAL.Insertar(Registro);
            }
            Console.ReadKey();
            break;
        case 2://Actualizar
            Console.Clear();
            Registro = new();
            Console.WriteLine("Ingrese el ID del Cliente");
            _ = int.TryParse(Console.ReadLine() ?? string.Empty, out ID);

            Registro = DAL.GetOnlyOne(ID);

            if (Registro.IdCliente > 0)
            {
                Console.WriteLine($"Ingrese el Nuevo Nombre del Cliente. ({Registro.Nombre})");
                string ConsolaNombre = Console.ReadLine() ?? "";
                Registro.Nombre = string.IsNullOrEmpty(ConsolaNombre) ? Registro.Nombre : ConsolaNombre;
               

                Console.WriteLine($"Ingrese el Nuevo Correo del Cliente. ({Registro.Correo})");
                string ConsolaCorreo = Console.ReadLine() ?? "";
                Registro.Correo = string.IsNullOrEmpty(ConsolaCorreo) ? Registro.Correo : ConsolaCorreo;

                Console.WriteLine($"Ingrese el Nuevo Teléfono del Cliente. ({Registro.Telefono})");
                string ConsolaTelefono = Console.ReadLine() ?? "";
                Registro.Telefono = string.IsNullOrEmpty(ConsolaTelefono) ? Registro.Telefono : ConsolaTelefono;

                if (DAL.Update(Registro))
                {
                    Console.WriteLine("Registro Actualizado");
                    Console.ReadKey();
                }
            }
            else
            {
                Console.WriteLine("No existe registro con ese ID");
                Console.ReadKey();
            }
            break;
        case 3://Ver
            Console.Clear();
            foreach (var item in DAL.Get())
            {
                Console.WriteLine($" ID: {item.IdCliente} \n Nombre: {item.Nombre} \n Telefono: {item.Telefono} \n Correo: {item.Correo} \n \n");
            }
            Console.ReadKey();
            break;
        case 4://Eliminar
            Console.Clear();
            Registro = new();
            Console.WriteLine("Ingrese el ID del Cliente");
            _ = int.TryParse(Console.ReadLine() ?? string.Empty, out ID);
            Registro.IdCliente = ID;

            if (DAL.Delete(Registro))
            {
                Console.WriteLine("Registro eliminado");
            }
            Console.ReadKey();
            break;
    }
}
while (Menu != 5);


bool validar(Cliente Entidad)
{
    if (string.IsNullOrEmpty(Entidad.Nombre) || string.IsNullOrWhiteSpace(Entidad.Nombre))
    {
        Console.WriteLine("Debe Ingresar el nombre del cliente");
        return false;
    }
    // if (!(Entidad.Correo > 0 && Entidad.corr < 150))
    // {
    //     Console.WriteLine("Debe Ingresar una Edad Válida");
    //     return false;
    // }
    return true;
}