using MauiApp6.Helper;
using MauiApp6.Service;
using MauiApp6.VeiwModels;

namespace MauiApp6.Views;

public partial class SignInPage : ContentPage
{
    public SignInPage()
    {
        InitializeComponent();
        BindingContext = new SignInVeiwModel();
    }
}