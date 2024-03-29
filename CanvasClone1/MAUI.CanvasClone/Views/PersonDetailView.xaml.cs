using Library.CanvasClone1.Services;
using MAUI.CanvasClone.ViewModels;
using Library.CanvasClone1.Models;

namespace MAUI.CanvasClone.Views;

[QueryProperty(nameof(PersonId), "personId")]
public partial class PersonDetailView : ContentPage
{
	public PersonDetailView()
	{
        InitializeComponent();
	}

    public int PersonId { get; set; }

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
        BindingContext = new PersonDetailViewModel(PersonId);
    }
}