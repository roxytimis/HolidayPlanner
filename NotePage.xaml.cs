using HolidayPlanner.Models;
namespace HolidayPlanner;

public partial class NotePage : ContentPage
{
	public NotePage()
	{
		InitializeComponent();
	}

    async void OnSaveButtonClicked(object sender, EventArgs e)
    {
        var slist = (Notes)BindingContext;
        slist.Date = DateTime.UtcNow;
        await App.Database.SaveNotesAsync(slist);
        await Navigation.PopAsync();
    }

    async void OnDeleteButtonClicked(object sender, EventArgs e)
    {
        var slist = (Notes)BindingContext;
        await App.Database.DeleteNotesAsync(slist);
        await Navigation.PopAsync();
    }
}