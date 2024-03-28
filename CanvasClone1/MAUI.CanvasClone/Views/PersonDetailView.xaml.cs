using Library.CanvasClone1.Services;
using MAUI.CanvasClone.ViewModels;
using Library.CanvasClone1.Models;

namespace MAUI.CanvasClone.Views;

public partial class PersonDetailView : ContentPage
{
	public PersonDetailView()
	{
        InitializeComponent();

		BindingContext = new PersonDetailViewModel();
	}

    private void OkClick(object sender, EventArgs e)
	{
		var context = BindingContext as PersonDetailViewModel;
		StudentClass classification;
		switch (context.ClassificationString)
		{
			case "S":
				classification = StudentClass.Senior;
				break;
            case "J":
                classification = StudentClass.Junior;
                break;
            case "O":
                classification = StudentClass.Sophomore;
                break;
            case "F":
			default:
                classification = StudentClass.Freshman;
                break;
        }
		StudentService.Current.Add(new Student { Name = context.Name, Classification = classification });
		Shell.Current.GoToAsync("//MainPage");
	}
}