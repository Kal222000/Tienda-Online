using System;

public class MetodoPago
{
    private bool qr;
    private bool tarjeta;
    private string banco;

    public MetodoPago(string banco)
    {
        this.banco = banco;
        this.qr = true;
        this.tarjeta = true;
    }
}
