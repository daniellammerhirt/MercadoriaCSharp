using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using MercadoriaCSharp.Db;
using MercadoriaCSharp.Models;
using MercadoriaCSharp.Views;
using MsBox.Avalonia;

namespace MercadoriaCSharp.ViewModels;

public partial class MainWindowViewModel : INotifyPropertyChanged
{
    ObservableCollection<Mercadoria> mercadorias = [];
    private Mercadoria mercadoriaAtual = new();
    public MercadoriaEditView? MercadoriaEditView { get; set; }

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

    public ObservableCollection<Mercadoria> Mercadorias
    {
        get
        {
            return mercadorias;
        }
        set
        {
            mercadorias = value;
            OnPropertyChanged();
        }
    }

    public MainWindowViewModel()
    {
        AtualizaGrid();
    }
    public event  PropertyChangedEventHandler? PropertyChanged;

    protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }

    public void AtualizaGrid()
    {
        DbMercadoria dbMercadoria = new();
        List<Mercadoria> lista = dbMercadoria.Pesquisa();
        Mercadorias.Clear();
        foreach (Mercadoria m in lista)
        {
            Mercadorias.Add(m);
        }
    }

    public void Novo()
    {
        MercadoriaEditView = new(new(), this);
        MercadoriaEditView.Show();
        AtualizaGrid();
    }

    public void Altera()
    {
        if (MercadoriaAtual != null && MercadoriaAtual.CodBarras != "")
        {
            MercadoriaEditView = new(MercadoriaAtual, this);
            MercadoriaEditView.Show();
        }
        else
        {
            var box = MessageBoxManager.GetMessageBoxStandard("Erro", "Nenhuma linha selecionada",
                MsBox.Avalonia.Enums.ButtonEnum.Ok);
            var result = box.ShowAsync();
        }
    }

    public void Exclui()
    {
        if (MercadoriaAtual != null && MercadoriaAtual.CodBarras != "")
        {
            DbMercadoria dbMercadoria = new();
            dbMercadoria.Exclui(MercadoriaAtual);
            AtualizaGrid();
        }
        else
        {
            var box = MessageBoxManager.GetMessageBoxStandard("Erro", "Nenhuma linha selecionada",
                MsBox.Avalonia.Enums.ButtonEnum.Ok);
            var result = box.ShowAsync();
        }
    }

    public void Sair()
    {
        Environment.Exit(0);
    }
}
