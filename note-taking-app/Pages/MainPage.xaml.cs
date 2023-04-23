using note_taking_app.Models;
using System.Collections.Generic;

namespace note_taking_app;

public partial class MainPage : ContentPage
{

	public MainPage()
	{
        InitializeComponent();
        GetNotes();
        RefreshNotesBtn.Clicked += RefreshNotes;
    }

    public async void GetNotes()
    {
        StatusMessage.Text = "";

        List<Note> notes = await App.NoteRepo.GetAllNotes();
        AllNotes.ItemsSource = notes;
    }

    public void RefreshNotes(object sender, EventArgs e)
    {
        GetNotes();
    }
}