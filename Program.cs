using System;

class Program
{
    struct Llamada
    {
        public int Clave;
        public string Zona;
        public double PrecioMinuto;
    }

    struct Libro
    {
        public int Codigo;
        public string Titulo;
        public string ISBN;
        public int Edicion;
        public string Autor;
    }

    static void Main(string[] args)
    {
        Llamada[] llamadas = {
            new Llamada { Clave = 12, Zona = "América del Norte", PrecioMinuto = 2 },
            new Llamada { Clave = 15, Zona = "América Central", PrecioMinuto = 2.2 },
            new Llamada { Clave = 18, Zona = "América del Sur", PrecioMinuto = 4.5 },
            new Llamada { Clave = 19, Zona = "Europa", PrecioMinuto = 3.5 },
            new Llamada { Clave = 23, Zona = "Asia", PrecioMinuto = 6 }
        };

        Libro[] biblioteca = new Libro[100]; // Capacidad para 100 libros
        int numLibros = 0;

        bool continuar = true;
        while (continuar)
        {
            Console.WriteLine("Seleccione una opción:");
            Console.WriteLine("1. Calcular costo de llamada internacional");
            Console.WriteLine("2. Agregar un libro");
            Console.WriteLine("3. Mostrar listado de libros");
            Console.WriteLine("4. Buscar libro por código");
            Console.WriteLine("5. Editar información de un libro por código");
            Console.WriteLine("6. Salir");
            int opcion = int.Parse(Console.ReadLine());

            switch (opcion)
            {
                case 1:
                    CalcularCostoLlamada(llamadas);
                    break;
                case 2:
                    AgregarLibro(ref numLibros, biblioteca);
                    break;
                case 3:
                    MostrarListadoLibros(numLibros, biblioteca);
                    break;
                case 4:
                    BuscarLibroPorCodigo(numLibros, biblioteca);
                    break;
                case 5:
                    EditarLibroPorCodigo(numLibros, biblioteca);
                    break;
                case 6:
                    continuar = false;
                    break;
                default:
                    Console.WriteLine("Opción no válida. Intente de nuevo.");
                    break;
            }
        }
    }

    static void CalcularCostoLlamada(Llamada[] llamadas)
    {
        Console.WriteLine("Ingrese la clave de la zona geográfica (12, 15, 18, 19, 23):");
        int clave = int.Parse(Console.ReadLine());

        Llamada llamadaSeleccionada = new Llamada();

        foreach (var llamada in llamadas)
        {
            if (llamada.Clave == clave)
            {
                llamadaSeleccionada = llamada;
                break;
            }
        }

        if (llamadaSeleccionada.Clave != 0)
        {
            Console.WriteLine("Ingrese la cantidad de minutos hablados:");
            double minutos = double.Parse(Console.ReadLine());

            double costoTotal = minutos * llamadaSeleccionada.PrecioMinuto;
            Console.WriteLine($"El costo de la llamada a {llamadaSeleccionada.Zona} es: {costoTotal:C}");
        }
        else
        {
            Console.WriteLine("Clave no válida.");
        }
    }

    static void AgregarLibro(ref int numLibros, Libro[] biblioteca)
    {
        if (numLibros < biblioteca.Length)
        {
            Console.WriteLine("Ingrese el código del libro:");
            int codigo = int.Parse(Console.ReadLine());

            Console.WriteLine("Ingrese el título del libro:");
            string titulo = Console.ReadLine();

            Console.WriteLine("Ingrese el ISBN del libro:");
            string isbn = Console.ReadLine();

            Console.WriteLine("Ingrese la edición del libro:");
            int edicion = int.Parse(Console.ReadLine());

            Console.WriteLine("Ingrese el autor del libro:");
            string autor = Console.ReadLine();

            biblioteca[numLibros] = new Libro
            {
                Codigo = codigo,
                Titulo = titulo,
                ISBN = isbn,
                Edicion = edicion,
                Autor = autor
            };

            numLibros++;
            Console.WriteLine("Libro agregado con éxito.");
        }
        else
        {
            Console.WriteLine("La biblioteca está llena, no es posible agregar más libros.");
        }
    }

    static void MostrarListadoLibros(int numLibros, Libro[] biblioteca)
    {
        Console.WriteLine("Listado de libros:");
        Console.WriteLine("--------------------------------------------------------------");
        Console.WriteLine("| Código |        Título        |    ISBN    | Edición |   Autor   |");
        Console.WriteLine("--------------------------------------------------------------");

        for (int i = 0; i < numLibros; i++)
        {
            Console.WriteLine($"| {biblioteca[i].Codigo,7} | {biblioteca[i].Titulo,-20} | {biblioteca[i].ISBN,-10} | {biblioteca[i].Edicion,7} | {biblioteca[i].Autor,-10} |");
        }

        Console.WriteLine("--------------------------------------------------------------");
    }

    static void BuscarLibroPorCodigo(int numLibros, Libro[] biblioteca)
    {
        Console.WriteLine("Ingrese el código del libro a buscar:");
        int codigoBuscado = int.Parse(Console.ReadLine());

        bool encontrado = false;

        for (int i = 0; i < numLibros; i++)
        {
            if (biblioteca[i].Codigo == codigoBuscado)
            {
                Console.WriteLine("Libro encontrado:");
                Console.WriteLine($"Código: {biblioteca[i].Codigo}");
                Console.WriteLine($"Título: {biblioteca[i].Titulo}");
                Console.WriteLine($"ISBN: {biblioteca[i].ISBN}");
                Console.WriteLine($"Edición: {biblioteca[i].Edicion}");
                Console.WriteLine($"Autor: {biblioteca[i].Autor}");
                encontrado = true;
                break;
            }
        }

        if (!encontrado)
        {
            Console.WriteLine("Libro no encontrado.");
        }
    }

    static void EditarLibroPorCodigo(int numLibros, Libro[] biblioteca)
    {
        Console.WriteLine("Ingrese el código del libro a editar:");
        int codigoEditar = int.Parse(Console.ReadLine());

        bool encontrado = false;

        for (int i = 0; i < numLibros; i++)
        {
            if (biblioteca[i].Codigo == codigoEditar)
            {
                Console.WriteLine("Ingrese el nuevo título del libro:");
                string nuevoTitulo = Console.ReadLine();

                Console.WriteLine("Ingrese el nuevo ISBN del libro:");
                string nuevoISBN = Console.ReadLine();

                Console.WriteLine("Ingrese la nueva edición del libro:");
                int nuevaEdicion = int.Parse(Console.ReadLine());

                Console.WriteLine("Ingrese el nuevo autor del libro:");
                string nuevoAutor = Console.ReadLine();

                biblioteca[i].Titulo = nuevoTitulo;
                biblioteca[i].ISBN = nuevoISBN;
                biblioteca[i].Edicion = nuevaEdicion;
                biblioteca[i].Autor = nuevoAutor;

                Console.WriteLine("Libro editado con éxito.");
                encontrado = true;
                break;
            }
        }

        if (!encontrado)
        {
            Console.WriteLine("Libro no encontrado.");
        }
    }
}
