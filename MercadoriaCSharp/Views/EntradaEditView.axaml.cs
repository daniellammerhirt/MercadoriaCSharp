using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using MercadoriaCSharp.Models;

namespace MercadoriaCSharp.Views;

public partial class EntradaEditView : Window
{
    public EntradaEditView(Mercadoria mercadoria, MainWindow main)
    {
        InitializeComponent();
        DataContext = new EntradaEditView(mercadoria, main);
    }
}