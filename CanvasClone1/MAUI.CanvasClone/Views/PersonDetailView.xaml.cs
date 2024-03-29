using Library.CanvasClone1.Services;
using MAUI.CanvasClone.ViewModels;
using Library.CanvasClone1.Models;

namespace MAUI.CanvasClone.Views;

public partial class PersonDetailView : ContentPage
{
	public PersonDetailView()
	{
        InitializeComponent();
	}

    private void OkClick(object sender, EventArgs e)
	{
		(BindingContext as PersonDetailViewModel).AddPerson();
    }

    private void OnLeaving(object sender, NavigatedFromEventArgs e)
    {
        BindingContext = null;
    }

    private void OnArriving(object sender, NavigatedToEventArgs e)
    {
        BindingContext = new PersonDetailViewModel();
    }
}