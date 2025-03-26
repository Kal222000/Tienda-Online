using System;

public class Factura
{
	private int nit;
	private string nombre;
	private Producto[] productos_comprados;
	private MetodoPago metodo_pago;
	private int total;
	private int cantidad_productos;

	public Factura(int nit, string nombre, Producto[] productos, MetodoPago pago, int total, int k)
	{
		this.nit = nit;
		this.nombre = nombre;
		this.productos_comprados = productos;
		this.metodo_pago = pago;
		this.total = total;
		this.cantidad_productos = k;
	}

	public int total_factura()
	{
		return this.total;
	}
}
