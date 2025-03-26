using System;
using static System.Runtime.InteropServices.JavaScript.JSType;

public class Inventario
{
    private Producto[] productos;
    private Categoria[] lista_categorias;
    private int cantidad_productos;
    private int cantidad_categorias;

    public Inventario()
    {
        this.productos = new Producto[10000];
        this.lista_categorias = new Categoria[100];
        this.cantidad_productos = -1;
        this.cantidad_categorias = -1;
        Categoria categoria = new Categoria("Base", "Almacena productos sin categoria");
        this.cantidad_categorias++;
        this.lista_categorias[this.cantidad_categorias] = categoria;
    }

    public void crear_nuevo_producto()
    {
        string nombre, descripcion, categoria;
        Console.Write("Ingrese el nombre del producto:");
        nombre = Console.ReadLine();
        Console.Write("Ingrese la descripcion del producto:");
        descripcion = Console.ReadLine();
        Console.Write("Ingrese el precio del producto:");
        int precio = int.Parse(Console.ReadLine());
        categoria = "Base";
        Producto producto = new Producto(nombre, descripcion, categoria,precio);
        this.cantidad_productos++;
        this.productos[this.cantidad_productos] = producto;
        this.lista_categorias[0].asociar_producto(producto);
    }

    public void Stock()
    {
        int contador = 0;
        Console.WriteLine("Cantidad de productos disponibles en total: ");
        for(int i = 0; i <= this.cantidad_productos; i++)
        {
            if(this.productos[i].get_vendido() == false)
            {
                contador++;
            }
        }
        Console.WriteLine("Total: " + contador);
        Console.WriteLine();

        Console.WriteLine("Cantidad de productos disponibles por productos en categorias: ");
        for(int i = 0; i <= this.cantidad_categorias; i++)
        {
            Console.WriteLine("Categoria: " + this.lista_categorias[i].get_nombre());
            Producto[] aux = this.lista_categorias[i].get_productos();
            int aux2 = this.lista_categorias[i].get_cantidad_de_productos();
            for (int j = 0; j <= aux2; j++)
            {
                contador = 0;
                Producto aux1 = aux[j];
                if(aux1 == null)
                {
                    continue;
                }
                else
                {
                    Console.Write(aux1.get_nombre() + ": ");
                    for (int l = 0; l <= this.cantidad_productos; l++)
                    {
                        if ((this.productos[l].get_vendido() == false) && (aux[j].get_nombre() == this.productos[l].get_nombre()))
                        {
                            contador++;
                        }
                    }
                    Console.Write(contador);
                    Console.Write(" Precio Unitario: " + aux1.get_precio());
                    Console.WriteLine();
                }
            }
            Console.WriteLine();
        }
    }

    public void crear_nueva_categoria()
    {
        string nombre, descripcion;
        Console.Write("Ingrese el nombre de la categoria:");
        nombre = Console.ReadLine();
        Console.Write("Ingrese la descripcion de la categoria:");
        descripcion = Console.ReadLine();
        Categoria categoria = new Categoria(nombre, descripcion);
        this.cantidad_categorias++;
        this.lista_categorias[this.cantidad_categorias] = categoria;
    }

    public void agregar_producto()
    {
        if (this.cantidad_productos == -1)
        {
            Console.WriteLine("No existen productos");
            return;
        }
        else
        {
            Console.WriteLine("Si encuentra el producto que desea agregar escriba el nombre tal cual lo ve, escriba next si desea ver la siguiente categoría, caso contrario 0");
            for(int i = 0; i <= this.cantidad_categorias; i++)
            {
                Console.WriteLine("Categoria " + i + ": " + this.lista_categorias[i].get_nombre());
                Producto[] productos = this.lista_categorias[i].get_productos();
                int cantidad = this.lista_categorias[i].get_cantidad_de_productos();
                for (int j = 0; j <= cantidad; j++)
                {
                    Console.WriteLine("Producto " + j + ": " + productos[j].get_nombre());
                }
                Console.Write("Ingrese el nombre del producto o next:");
                string nombre_producto = Console.ReadLine();
                if(nombre_producto == "next")
                {
                    continue;
                }
                else if(nombre_producto[0] == '0')
                {
                    return;
                }
                else
                {
                    bool estado = false;
                    Producto aux = null;
                    for (int j = 0; j <= cantidad; j++)
                    {
                        if(nombre_producto == productos[j].get_nombre())
                        {
                            aux = productos[j];
                            estado = true;
                        }
                    }
                    if(estado == true)
                    {
                        Producto producto = new Producto(aux);
                        this.cantidad_productos++;
                        this.productos[this.cantidad_productos] = producto;
                    }
                    else
                    {
                        return;
                    }
                }
            }
        }
    }

    public void cambiar_categoria()
    {
        string estado = mostrar_productos_categoria_base();
        if(estado == "No hay ningun producto")
        {
            return;
        }
        else
        {
            Console.WriteLine("Ingrese tal como se ve el nombre del producto y de la categoria, sino se tomara como invalido, caso que desee cancelar la asignacion escriba 0");
            Console.Write("Ingrese el nombre del producto que desea asignar categoria: ");
            string nombre = Console.ReadLine();
            if (nombre[0] == '0')
            {
                return;
            }
            Producto[] productos = this.lista_categorias[0].get_productos();
            int cantidad = this.lista_categorias[0].get_cantidad_de_productos();
            bool estado1 = false;
            Producto aux2 = null;

            for (int i = 0; i <= cantidad; i++)
            {
                if (productos[i] == null)
                {
                    continue;
                }
                else
                {
                    if(nombre == productos[i].get_nombre())
                    {
                        estado1 = true;
                        aux2 = productos[i];
                        break;
                    }
                }
            }

            if(estado1 == true)
            {
                if(this.cantidad_categorias <= 0)
                {
                    Console.WriteLine("No existen Categorias");
                    return;
                }
                else
                {
                    for(int i = 1; i <= this.cantidad_categorias; i++)
                    {
                        Console.WriteLine("Categoria " + i + ": " + this.lista_categorias[i].get_nombre());
                    }

                    Console.Write("Ingrese nombre de la categoria: ");
                    string nombre_categoria = Console.ReadLine();

                    if (nombre_categoria[0] == '0')
                    {
                        return;
                    }

                    Categoria aux = null;
                    estado1 = false;
                    for (int i = 1; i <= this.cantidad_categorias; i++)
                    {
                        if(nombre_categoria == this.lista_categorias[i].get_nombre())
                        {
                            estado1 = true;
                            aux = this.lista_categorias[i];
                            break;
                        }
                    }

                    if(estado1 == true)
                    {
                        aux.asociar_producto(aux2);
                        for(int i = 0; i <= this.cantidad_productos; i++)
                        {
                            if (this.productos[i].get_nombre() == aux2.get_nombre())
                            {
                                this.productos[i].set_categoria(aux.get_nombre());
                            }
                        }
                        Console.WriteLine("Cambio Exitoso de Categoria");
                        Producto[] aux3 = this.lista_categorias[0].get_productos();
                        for (int i = 0; i <= this.lista_categorias[0].get_cantidad_de_productos(); i++)
                        {
                            if (aux3[i] == null || aux2 == null)
                            {
                                continue;
                            }
                            else
                            {
                                if (aux3[i].get_nombre() == aux2.get_nombre())
                                {
                                    aux3[i] = null;
                                }
                            }
                        }
                    }
                    else
                    {
                        Console.WriteLine("No existe la Categoría");
                        return;
                    }
                }
            }
            else
            {
                Console.WriteLine("No existe el producto");
                return;
            }

        }
    }

    public string mostrar_productos_categoria_base()
    {
        Console.Write("Categoria: " + this.lista_categorias[0].get_nombre());
        Console.WriteLine();
        Console.Write("Descripcion: " + this.lista_categorias[0].get_descripcion());
        Console.WriteLine();
        Producto[] productos = this.lista_categorias[0].get_productos();
        int cantidad = this.lista_categorias[0].get_cantidad_de_productos();
        if(cantidad == -1)
        {
            Console.WriteLine("No hay ningun producto");
            return "No hay ningun producto";
        }
        else
        {
            for (int i = 0; i <= cantidad; i++)
            {
                if (productos[i] == null)
                {
                    continue;
                }
                else
                {
                    Console.WriteLine("Producto " + i + ": " + productos[i].get_nombre());
                }
            }
            return "Existen productos";
        }
        return "No hay ningun producto";
    }

    public int get_cantidad_productos()
    {
        return this.cantidad_productos;
    }

    public Producto[] get_producstos()
    {
        return this.productos;
    }
    public void producto1()
    {
        string categoria = "Base";
        Producto producto = new Producto("Samsung 1", "Telefono mobil hecho por Samsung modelo 1", categoria, 100);
        this.cantidad_productos++;
        this.productos[this.cantidad_productos] = producto;
        this.lista_categorias[0].asociar_producto(producto);
    }

    public void producto2()
    {
        string categoria = "Base";
        Producto producto = new Producto("Samsung 2", "Telefono mobil hecho por Samsung modelo 2", categoria, 200);
        this.cantidad_productos++;
        this.productos[this.cantidad_productos] = producto;
        this.lista_categorias[0].asociar_producto(producto);
    }

    public void producto3()
    {
        string categoria = "Base";
        Producto producto = new Producto("Laptop HP 1", "Laptop HP modelo 1", categoria, 1000);
        this.cantidad_productos++;
        this.productos[this.cantidad_productos] = producto;
        this.lista_categorias[0].asociar_producto(producto);
    }

    public void producto4()
    {
        string categoria = "Base";
        Producto producto = new Producto("Laptop HP 2", "Laptop HP modelo 2", categoria, 2000);
        this.cantidad_productos++;
        this.productos[this.cantidad_productos] = producto;
        this.lista_categorias[0].asociar_producto(producto);
    }


}
