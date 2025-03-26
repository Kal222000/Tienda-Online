using System;

public class Reporte
{
	private VentaIndividual[] ventas;
	private int ganancia;
	private DateTime fecha;
	private int cantidad_ventas;

	public Reporte(DateTime fecha)
	{
		this.ventas = new VentaIndividual[50];
		this.ganancia = 0;
		this.cantidad_ventas = -1;
		this.fecha = fecha;
	}

	public void agregar_venta(VentaIndividual venta)
	{
		this.cantidad_ventas++;
		this.ventas[this.cantidad_ventas] = venta;
		this.ganancia += venta.ganancia_venta();
	}
}
