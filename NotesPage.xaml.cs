using HolidayPlanner.Models;

namespace HolidayPlanner;

public partial class NotesPage : ContentPage
{
    public NotesPage()
    {
        InitializeComponent();
    }
    protected override async void OnAppearing()
    {
        base.OnAppearing();
        listView.ItemsSource = await App.Database.GetNotesAsync();
    }
    async void OnNoteAddedClicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new NotePage
        {
            BindingContext = new Notes()
        });
    }
    async void OnListViewItemSelected(object sender, SelectedItemChangedEventArgs e)
    {
        if (e.SelectedItem != null)
        {
            await Navigation.PushAsync(new NotePage
            {
                BindingContext = e.SelectedItem as Notes
            });
        }


    }
}