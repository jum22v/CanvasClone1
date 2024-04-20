using MAUI.CanvasClone.ViewModels;

namespace MAUI.CanvasClone.Views;

[QueryProperty(nameof(CourseId), "courseId")]
public partial class CourseDetailView : ContentPage
{
	public CourseDetailView()
	{
		InitializeComponent();
        BindingContext = new CourseDetailViewModel();
    }

    public int CourseId { get; set; }

    private void CancelClicked(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync("//Instructor");
    }

    private void OkClicked(object sender, EventArgs e)
    {
        (BindingContext as CourseDetailViewModel).AddCourse();
    }
}