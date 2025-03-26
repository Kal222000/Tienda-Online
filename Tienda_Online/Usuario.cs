using System;

public class Usuario
{
	private string nombre;
	private bool administrador;
	private string gmail;
	private string direccion;
	private int idetificador;
	private string contraseña;
	private MetodoPago pago;

	public Usuario(string nombre, string gmail, string direccion, int identificador, string contraseña)
	{
		this.administrador = false;
		this.nombre = nombre;
		this.gmail = gmail;
		this.direccion = direccion;
		this.idetificador = idetificador;
		this.contraseña = contraseña;
		Console.WriteLine("Ingrese el banco al cual pertenece su tarjeta");
		Console.Write("Nombre del Banco:");
		string banco = Console.ReadLine();
		this.pago = new MetodoPago(banco);
	}

	public Usuario()
	{
		this.nombre = "admin";
		this.idetificador = 0;
		this.administrador = true;
		this.gmail = " ";
		this.direccion = " ";
		this.contraseña = "123";
	}

	public string get_contraseña()
	{
		return this.contraseña;
	}

	public string get_nombre()
	{
		return this.nombre;
	}

	public bool get_nivel()
	{
		return this.administrador;
	}

	public MetodoPago get_pago()
	{
		return this.pago;
	}
}
