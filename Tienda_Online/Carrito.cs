using System;
using static System.Runtime.InteropServices.JavaScript.JSType;

public class Carrito
{
	private Producto[] lista;
	private int cantidad;
	private Inventario inventario;
	private VentaGeneral ventas;

	public Carrito(Inventario inventario, VentaGeneral ventas)
	{
		this.lista = new Producto[30];
		this.cantidad = -1;
		this.inventario = inventario;
		this.ventas = ventas;
	}

	public void agregar_producto()
	{
        Console.Write("Ingresa el nombre del producto:");
		string nombre = Console.ReadLine();
		int cantidad = inventario.get_cantidad_productos();
		Producto[] aux = inventario.get_producstos();
		for(int i = 0; i <= cantidad; i++)
		{
			if ((aux[i].get_nombre() == nombre) && (aux[i].get_vendido() == false))
			{
				this.cantidad++;
				this.lista[this.cantidad] = aux[i];
				aux[i].set_vendido(true);
				Console.WriteLine("Producto Agregado");
				return;
			}
		}
		Console.WriteLine("Producto Agotado");
	}

    public void eliminar_producto()
    {
        Console.Write("Ingresa el nombre del producto: ");
        string nombre = Console.ReadLine();
        int cantidad = inventario.get_cantidad_productos();
        Producto[] aux = inventario.get_producstos();
		int barra = -1;
		bool encontardo = false;
		for(int i = 0; i <= this.cantidad; i++)
		{
			if (this.lista[i] == null)
			{
				continue;
			}
			else if (this.lista[i].get_nombre() == nombre)
			{
				encontardo = true;
				barra = this.lista[i].get_identificador();
				this.lista[i] = null;
				break;

            }
		}
        if(encontardo == false)
		{
			Console.WriteLine("No tiene el producto en el carrito");
			return;
		}
		else
		{
            for (int i = 0; i <= cantidad; i++)
            {
                if ((aux[i].get_nombre() == nombre) && (aux[i].get_vendido() == true) && (aux[i].get_identificador() == barra))
                {
                    aux[i].set_vendido(false);
                    Console.WriteLine("Producto Eliminado");
                    return;
                }
            }
        }
    }

	public void mostrar()
	{
		Console.WriteLine("Productos Almacenados");
		if(this.cantidad == -1)
		{
			Console.WriteLine("No hay productos");
		}
		else
		{
			int total = 0;
			for(int i = 0; i <= this.cantidad; i++)
			{
				if (this.lista[i] == null)
				{
					continue;
				}
				else
				{
                    Console.Write("Producto " + i + ": ");
                    Console.Write(this.lista[i].get_nombre() + ": ");
                    Console.Write(this.lista[i].get_precio());
                    Console.WriteLine();
                    total += this.lista[i].get_precio();
                }
            }
			Console.WriteLine("Total a pagar: " + total);
		}
	}

	public Factura finalizar_compra(Usuario usuario)
	{
		if(this.cantidad == -1)
		{
			Console.WriteLine("No existen Productos en el carrito");
			return null;
		}
		else
		{
			mostrar();
			Console.WriteLine("Confirme la compra");
			Console.WriteLine("1.Si || 2.No");
			string compra = Console.ReadLine();
			if (compra[0] == '2')
			{
				return null;
			}
			else if((compra[0] == '1'))
			{
                Console.WriteLine("Desea Facturar su compra");
				Console.WriteLine("1.Si || 2.No");
                compra = Console.ReadLine();
				if (compra[0] == '1')
				{
                    Console.WriteLine("Ingrese NIT");
					int nit = int.Parse(Console.ReadLine());
                    Console.WriteLine("Ingrese nombre del interesado");
                    string nombre = Console.ReadLine();
					int total = 0;
					for(int i = 0; i <= this.cantidad; i++)
					{
						total += this.lista[i].get_precio();
						this.ventas.agregar_producto_vendido(this.lista[i]);
					}
					Factura factura = new Factura(nit, nombre, this.lista, usuario.get_pago(), total, this.cantidad);
                    return factura;
                }
                else
				{
                    int total = 0;
                    for (int i = 0; i <= this.cantidad; i++)
                    {
                        total += this.lista[i].get_precio();
                        this.ventas.agregar_producto_vendido(this.lista[i]);
                    }
                    Factura factura = new Factura(0, "Sin nombre", this.lista, usuario.get_pago(), total, this.cantidad);
					return factura;
                }

            }
			else
			{
				return null;
			}
		}
	}

	public void eliminar_automaticamente()
	{
		if(this.cantidad == -1)
		{
			return;
		}
		else
		{
			for(int j = 0; j <= this.cantidad; j++)
			{
				if (this.lista[j] == null)
				{
					continue;
				}
				else
				{
                    eliminar_producto(this.lista[j].get_nombre());
                }
			}
		}
	}
    public void eliminar_producto(string nombre_producto)
    {
		string nombre = nombre_producto;
        int cantidad = inventario.get_cantidad_productos();
        Producto[] aux = inventario.get_producstos();
        int barra = -1;
        bool encontardo = false;
        for (int i = 0; i <= this.cantidad; i++)
        {
            if (this.lista[i] == null)
            {
                continue;
            }
            else if (this.lista[i].get_nombre() == nombre)
            {
                encontardo = true;
                barra = this.lista[i].get_identificador();
                this.lista[i] = null;
                break;

            }
        }
        if (encontardo == false)
        {;
            return;
        }
        else
        {
            for (int i = 0; i <= cantidad; i++)
            {
                if ((aux[i].get_nombre() == nombre) && (aux[i].get_vendido() == true) && (aux[i].get_identificador() == barra))
                {
                    aux[i].set_vendido(false);
                    return;
                }
            }
        }
    }
}
