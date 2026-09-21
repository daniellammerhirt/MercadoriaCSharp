using System.Collections.Generic;
using MercadoriaCSharp.Models;

namespace MercadoriaCSharp.Db;

public class DbMercadoria
{
    public void Insere(Mercadoria mercadoria)
    {
        var context = new MyDbContext();
        context.mercadoria.Add(mercadoria);
        context.SaveChanges();
    }

    public void Atualiza(Mercadoria mercadoria)
    {
        var context = new MyDbContext();
        context.mercadoria.Update(mercadoria);
        context.SaveChanges();
    }

    public void Exclui(Mercadoria mercadoria)
    {
        var context = new MyDbContext();
        context.mercadoria.Remove(mercadoria);
        context.SaveChanges();
    }

    public List<Mercadoria> Pesquisa()
    {
        var context = new MyDbContext();
        return [.. context.mercadoria];
    }
}