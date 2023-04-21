namespace note_taking_app;

public partial class NewNote : ContentPage
{
	public NewNote()
	{
		InitializeComponent();
        SubmitNoteBtn.Clicked += SubmitNote;

    }

    async void SubmitNote(object sender, EventArgs e)
    {
        if (await this.DisplayAlert(
            "Save Note",
            "Would you like to save this note?",
            "Yes",
            "No"))
        {
            App.NoteRepo.AddNewNote(NoteTitle.Text, editor.Text);
            editor.Text = null;
            await DisplayAlert("Note Saved",
                App.NoteRepo.StatusMessage,
                "OK");
        }
    }
}