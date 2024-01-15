using HolidayPlanner.Models;
namespace HolidayPlanner;

public partial class ListOfCountriesPage : ContentPage
{
    public ListOfCountriesPage()
    {
        InitializeComponent();
    }

    async void OnShopListAddedClicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new ListPlanner
        {
            BindingContext = new PlannerList()
        });
    }

    async void OnSaveButtonClicked(object sender, EventArgs e)
    {
        var slist = (PlannerList)BindingContext;
        await App.Databasee.SavePlannerListAsync(slist);
        await Navigation.PopAsync();
    }
}
