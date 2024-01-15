using HolidayPlanner.Models;
namespace HolidayPlanner;

public partial class PlannerEntryPage : ContentPage
{
	public PlannerEntryPage()
	{
		InitializeComponent();
	}

    protected override async void OnAppearing()
    {
        base.OnAppearing();
        listView.ItemsSource = await App.Databasee.GetPlannerListAsync();
    }
    async void OnShopListAddedClicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new ListPlanner
        {
            BindingContext = new PlannerList()
        });
    }
    async void OnListViewItemSelected(object sender, SelectedItemChangedEventArgs e)
    {
        if (e.SelectedItem != null)
        {
            await Navigation.PushAsync(new ListPlanner
            {
                BindingContext = e.SelectedItem as PlannerList
            });
        }
    }
}