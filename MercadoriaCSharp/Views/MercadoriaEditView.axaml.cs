using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using MercadoriaCSharp.Models;
using MercadoriaCSharp.ViewModels;

namespace MercadoriaCSharp.Views;

public partial class MercadoriaEditView : Window
{
    public MercadoriaEditView(Mercadoria mercadoria, MainWindowViewModel main)
    {
        InitializeComponent();
        DataContext = new MercadoriaEditViewModel(mercadoria, main);
    }
}