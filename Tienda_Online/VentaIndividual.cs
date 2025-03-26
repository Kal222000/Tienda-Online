using System;

public class VentaIndividual
{
	private Factura factura;
	private Usuario cliente;

	public VentaIndividual(Factura factura, Usuario cliente)
	{
		this.factura = factura;
		this.cliente = cliente;
	}

	public int ganancia_venta()
	{
		return this.factura.total_factura();
	}
}
