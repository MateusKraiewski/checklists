using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TransporteChecklistAPI.Application.Common;
public class Resultado
{
    public bool Sucesso { get; private set; }
    public string Mensagem { get; private set; }
    public object? Data { get; private set; }

    private Resultado(bool sucesso, string mensagem, object? data = null)
    {
        Sucesso = sucesso;
        Mensagem = mensagem;
        Data = data;
    }

    public static Resultado Ok(string mensagem, object? data = null)
    {
        return new Resultado(true, mensagem, data);
    }

    public static Resultado Falha(string mensagem)
    {
        return new Resultado(false, mensagem);
    }
}