namespace Shoppilar.DTOs.Ext;

public class SmsInput(string celular, string mensagem)
{
    public string Celular { get; set; } = celular;
    public string Mensagem { get; set; } = mensagem;
}