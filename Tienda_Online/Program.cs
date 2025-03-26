Inventario inventario = new Inventario();
inventario.producto1();
inventario.producto2();
inventario.producto3();
inventario.producto4();
VentaGeneral general = new VentaGeneral();
Reporte reporte = new Reporte(DateTime.Now);
string comando = "";
while (true)
{
    Console.WriteLine("Bienvenido a la Tienda Online");
    Console.WriteLine("Si desea ingresar escriba 1, escriba 0 si desea salir del programa");
    Console.Write("Ingrese comando:");
    comando = Console.ReadLine();
    Console.WriteLine();
    if (comando == "")
    {
        continue;
    }
    else if (comando[0] == '1')
    {
        Console.WriteLine("1 Iniciar Sesión || 2 Crear Cuenta");
        Console.Write("Ingrese comando:");
        comando = Console.ReadLine();
        Console.WriteLine();
        if (comando == "")
        {
            Console.WriteLine("No se reconocio el comando, vuelva a ingresar");
            Console.WriteLine();
            continue;
        }
        else if (comando[0] == '1')
        {
            Console.WriteLine("Iniciando Sesion");
            Usuario usuario = general.iniciar_secion();
            Console.WriteLine();
            if(usuario == null)
            {
                continue;
            }
            else
            {
                if(usuario.get_nivel() == true)
                {
                    while (true)
                    {
                        Console.WriteLine("1 Crear Producto || 2 Crear Categoria || 3 Stock || 4 Cambiar Categoria || 5 Agregar Producto || 6 Cerrar sesion || 7 Mostrar Productos Vendidos");
                        Console.Write("Ingrese comando:");
                        comando = Console.ReadLine();
                        Console.WriteLine();
                        if (comando == "")
                        {
                            continue;
                        }
                        if (comando[0] == '1')
                        {
                            Console.WriteLine("Creando Nuevo Producto");
                            inventario.crear_nuevo_producto();
                            Console.WriteLine();
                        }
                        else if (comando[0] == '2')
                        {
                            Console.WriteLine("Creando Nueva Categoria");
                            inventario.crear_nueva_categoria();
                            Console.WriteLine();
                        }
                        else if (comando[0] == '3')
                        {
                            Console.WriteLine("Productos Disponibles");
                            inventario.Stock();
                            Console.WriteLine();
                        }
                        else if (comando[0] == '5')
                        {
                            Console.WriteLine("Agregar Producto");
                            inventario.agregar_producto();
                            Console.WriteLine();
                        }
                        else if (comando[0] == '4')
                        {
                            Console.WriteLine("Asignando Categoria");
                            inventario.cambiar_categoria();
                            Console.WriteLine();
                        }
                        else if (comando[0] == '6')
                        {
                            Console.WriteLine("Cerrando Sesion");
                            Console.WriteLine();
                            usuario = null;
                            break;
                        }
                        else if (comando[0] == '7')
                        {
                            Console.WriteLine("Mostrando Productos Vendidos");
                            general.mostrar_productos_vendidos();
                            Console.WriteLine();
                        }
                        else
                        {
                            Console.WriteLine("No se reconocio el comando, vuelva a ingresar");
                            Console.WriteLine();
                            continue;
                        }
                    }
                }
                else
                {
                    Carrito carrito = new Carrito(inventario,general);
                    while (true)
                    {
                        Console.WriteLine("1 Ver Productos || 2 Agregar Producto || 3 Eliminar Producto || 4 Comprar || 5 Mostrar Carrito || 6 Cerrar sesion");
                        Console.Write("Ingrese comando:");
                        comando = Console.ReadLine();
                        Console.WriteLine();
                        if (comando == "")
                        {
                            continue;
                        }
                        else if (comando[0] == '1')
                        {
                            Console.WriteLine("Lista de Productos");
                            inventario.Stock();
                            Console.WriteLine();
                        }
                        else if (comando[0] == '2')
                        {
                            Console.WriteLine("Agregar Producto");
                            carrito.agregar_producto();
                            Console.WriteLine();
                        }
                        else if (comando[0] == '3')
                        {
                            Console.WriteLine("Eliminar Producto");
                            carrito.eliminar_producto();
                            Console.WriteLine();
                        }
                        else if (comando[0] == '4')
                        {
                            Console.WriteLine("Comprar");
                            Factura aux = carrito.finalizar_compra(usuario);
                            if (aux == null)
                            {
                                Console.WriteLine();
                                continue;
                            }
                            else
                            {
                                VentaIndividual venta = new VentaIndividual(aux, usuario);
                                reporte.agregar_venta(venta);
                                general.agregar_reporte(reporte);
                                Console.WriteLine("Compra Exitosa");
                                Console.WriteLine();
                                break;
                            }
                        }
                        else if (comando[0] == '5')
                        {
                            carrito.mostrar();
                            Console.WriteLine();
                        }
                        else if (comando[0] == '6')
                        {
                            Console.WriteLine("Cerrando Sesion");
                            Console.WriteLine();
                            carrito.eliminar_automaticamente();
                            usuario = null;
                            Console.WriteLine();
                            break;
                        }
                        else
                        {
                            Console.WriteLine("Valor Invalido");
                            Console.WriteLine();
                            continue;
                        }
                    }
                }
            }
        }
        else if (comando[0] == '2')
        {
            Console.WriteLine("Creando Cuenta");
            general.crear_usuario();
            Console.WriteLine();
            continue;
        }
        else if (comando[0] == '0')
        {
            Console.WriteLine("Saliendo del programa");
            break;
        }
        else
        {
            Console.WriteLine("No se reconocio el comando, vuelva a ingresar");
            Console.WriteLine();
            continue;
        }
    }
    else if (comando[0] == '0')
    {
        Console.WriteLine("Saliendo del programa");
        break;
    }
    else
    {
        Console.WriteLine("No se reconocio el comando, vuelva a ingresar");
        Console.WriteLine();
        continue;
    }
}