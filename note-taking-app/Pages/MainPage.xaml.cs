using note_taking_app.Models;
using System.Collections.Generic;

namespace note_taking_app;

public partial class MainPage : ContentPage
{

	public MainPage()
	{
		InitializeComponent();
        OnGetButtonClicked();
	}

    public void OnGetButtonClicked()
    {
        List<Note> notes = App.NoteRepo.GetAllNotes();
        AllNotes.ItemsSource = notes;
    }
}