using MauiApp6.VeiwModels;

namespace MauiApp6.Views;

public partial class SignUpPage2 : ContentPage
{
    public SignUpPage2()
    {
        InitializeComponent();
        BindingContext = new SignUpViewModel();
    }
}
