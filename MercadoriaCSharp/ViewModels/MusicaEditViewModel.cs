using System.ComponentModel;
using System.Runtime.CompilerServices;
using MercadoriaCSharp.Db;
using MercadoriaCSharp.Models;

namespace MercadoriaCSharp.ViewModels;

public class MercadoriaEditViewModel : INotifyPropertyChanged
{
    private Mercadoria mercadoriaAtual = new();
    MainWindowViewModel main;

    public Mercadoria MercadoriaAtual
    {
        get
        {
            return mercadoriaAtual;
        }
        set
        {
            mercadoriaAtual = value;
            OnPropertyChanged();
        }
    }

    public MercadoriaEditViewModel(Mercadoria mercadoria, MainWindowViewModel main)
    {
        MercadoriaAtual = mercadoria;
        this.main = main;
    }
    public event PropertyChangedEventHandler? PropertyChanged;

    protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }

    public void Salva()
    {
        DbMercadoria dbMercadoria = new();
        if (MercadoriaAtual.CodBarras == "")
        {
            dbMercadoria.Insere(MercadoriaAtual);
        }
        else
        {
            dbMercadoria.Atualiza(MercadoriaAtual);
        }
        main.AtualizaGrid();
        main.MercadoriaEditView?.Close();
    }
}