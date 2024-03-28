using MAUI.CanvasClone.ViewModels;

namespace MAUI.CanvasClone.Views;

public partial class InstructorView : ContentPage
{
	public InstructorView()
	{
		InitializeComponent();
		BindingContext = new InstructorViewViewModel();
	}

	private void AddEnrollmentClick(object sender, EventArgs e)
	{
		Shell.Current.GoToAsync("//PersonDetail");
	}

	private void CancelClicked(object sender, EventArgs e)
	{
		Shell.Current.GoToAsync("//MainPage");
	}
}