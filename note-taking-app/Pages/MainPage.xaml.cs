using note_taking_app.Models;
using System.Collections.Generic;

namespace note_taking_app;

public partial class MainPage : ContentPage
{

	public MainPage()
	{
        InitializeComponent();
        GetNotes();

        RefreshNotesIcon.Clicked += RefreshNotes;
        AddNoteIcon.Clicked += AddNote;
    }

    public async void GetNotes()
    {
        StatusMessage.Text = "";

        List<Note> notes = await App.NoteRepo.GetAllNotes();

        AllNotes.Children.Clear();

        foreach (var note in notes)
        {

            int ThisNoteID = note.Id;

            Button NoteButton = new Button
            {
                Text = note.NoteTitle,
                Command = new Command(async (ID) =>
                {
                    await Navigation.PushAsync(new DisplayNote(ThisNoteID));
                }),
                Margin = 5
            };

            AllNotes.Children.Add(NoteButton);
        }
    }

    public void RefreshNotes(object sender, EventArgs e)
    {
        GetNotes();
    }

    public void AddNote(object sender, EventArgs e)
    {
        Navigation.PushAsync(new NewNote());
    }
}