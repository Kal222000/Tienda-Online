using System;

public class VentaGeneral
{
	private Producto[] productos_vendidos;
	private Reporte[] reportes;
    private Usuario[] usuarios;
    private int cantidad_productos;
	private int cantidad_reportes;
    private int cantidad_usuarios;
	private int identificador;

	public VentaGeneral()
	{
		this.productos_vendidos = new Producto[10000];
		this.reportes = new Reporte[100];
		this.usuarios = new Usuario[30];
		this.cantidad_productos = -1;
		this.cantidad_reportes = -1;
		this.cantidad_usuarios = -1;
		this.identificador = 0;
		Usuario admin = new Usuario();
		this.cantidad_usuarios++;
		this.usuarios[this.cantidad_usuarios] = admin;
	}

	public Usuario iniciar_secion()
	{
		Console.WriteLine("Ingrese su nombre y contraseña");
        Console.Write("Ingrese su nombre: ");
        string nombre = Console.ReadLine();
        Console.Write("Ingrese su contaseña: ");
        string contraseña = Console.ReadLine();
		for(int i = 0; i <= this.cantidad_usuarios; i++)
		{
			if ((this.usuarios[i].get_contraseña() == contraseña) && (this.usuarios[i].get_nombre() == nombre)){
				return this.usuarios[i];
            }
		}
		Console.WriteLine("No existe el Usuario");
		return null;
    }

	public void crear_usuario()
	{
		Console.Write("Ingrese su nombre: ");
		string nombre = Console.ReadLine();
		Console.Write("Ingrese su gmail: ");
        string gmail = Console.ReadLine();
        Console.Write("Ingrese su direccion: ");
        string direccion = Console.ReadLine();
        Console.Write("Ingrese su contaseña: ");
        string contraseña = Console.ReadLine();
		this.cantidad_usuarios++;
		this.identificador++;
		Usuario aux = new Usuario(nombre, gmail, direccion, this.identificador, contraseña);
		this.usuarios[this.cantidad_usuarios] = aux;
    }	

	public void agregar_reporte(Reporte reporte)
	{
		this.cantidad_reportes++;
		this.reportes[this.cantidad_reportes] = reporte;
	}

	public void agregar_producto_vendido(Producto producto)
	{
		this.cantidad_productos++;
		this.productos_vendidos[this.cantidad_productos] = producto;
	}

	public void mostrar_productos_vendidos()
	{
		if(this.cantidad_productos == -1)
		{
			Console.WriteLine("No se ha vendido ningún producto");
		}
		else
		{
			for(int i = 0; i <= this.cantidad_productos; i++)
			{
				Console.Write("Producto " + i + ": " + this.productos_vendidos[i].get_nombre());
			}
		}
	}
}
