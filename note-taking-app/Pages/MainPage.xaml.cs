using note_taking_app.Models;
using System.Collections.Generic;

namespace note_taking_app;

public partial class MainPage : ContentPage
{

	public MainPage()
	{
		InitializeComponent();
        GetNotes();
	}

    public void GetNotes()
    {
        StatusMessage.Text = "";

        List<Note> notes = App.NoteRepo.GetAllNotes();
        AllNotes.ItemsSource = notes;
    }
}