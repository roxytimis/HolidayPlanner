using HolidayPlanner.Models;
namespace HolidayPlanner;

public partial class ListPlanner : ContentPage
{
	public ListPlanner()
	{
		InitializeComponent();
	}
    async void OnSaveButtonClicked(object sender, EventArgs e)
    {
        var slist = (PlannerList)BindingContext;
        await App.Databasee.SavePlannerListAsync(slist);
        await Navigation.PopAsync();
    }
    async void OnDeleteButtonClicked(object sender, EventArgs e)
    {
        var slist = (PlannerList)BindingContext;
        await App.Databasee.DeletePlannerListAsync(slist);
        await Navigation.PopAsync();
    }

}