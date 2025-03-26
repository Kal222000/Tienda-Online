using System;

public class Categoria
{
	private string nombre;
	private string descripcion;
	private Producto[] lista_productos;
	private int cantidad_productos;

	public Categoria(string nombre, string descripcion)
	{
		this.nombre = nombre;
		this.descripcion = descripcion;
		this.lista_productos = new Producto[50];
		this.cantidad_productos = -1;
    }

	public void asociar_producto(Producto producto)
	{
		this.cantidad_productos++;
		this.lista_productos[this.cantidad_productos] = producto;
	}

	public string get_nombre()
	{
		return this.nombre;
	}

	public string get_descripcion()
	{
		return this.descripcion;
	}

	public Producto[] get_productos()
	{
		return this.lista_productos;
	}

	public int get_cantidad_de_productos()
	{
		return this.cantidad_productos;
	}
}
