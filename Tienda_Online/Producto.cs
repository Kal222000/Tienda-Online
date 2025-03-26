using System;

public class Producto
{
	private string nombre;
	private string descripcion;
	private string categoria;
	private bool vendido;
	private int identificador;
	private int precio;

	public Producto(string nombre, string descripcion, string categoria, int precio)
	{
		this.nombre = nombre;
		this.descripcion = descripcion;
		this.categoria = categoria;
		this.vendido = false;
		this.identificador = 1;
		this.precio = precio;
	}

	public Producto(Producto producto)
	{
		this.descripcion = producto.get_descripcion();
        this.nombre = producto.get_nombre();
		this.categoria = producto.get_categoria();
        this.vendido = false;
		this.precio = producto.get_precio();
		this.identificador = get_identificador() + 1;
	}

	public string get_nombre()
	{
		return this.nombre;
	}

	public bool get_vendido()
	{
		return this.vendido;
	}

	public void set_vendido(bool estado)
	{
		this.vendido = estado;
	}

	public string get_descripcion()
	{
		return this.descripcion;
	}

	public string get_categoria()
	{
		return this.categoria;
	}

	public int get_identificador()
	{
		return this.identificador;
	}

	public void set_categoria(string categoria)
	{
		this.categoria = categoria;
	}

	public int get_precio()
	{
		return this.precio;
	}
}
