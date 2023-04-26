namespace note_taking_app;

public partial class DisplayNote : ContentPage
{
	public DisplayNote(int NoteID)
	{
		InitializeComponent();

        // get note from database by ID and display data
        GetNote(NoteID);
    }

    public async void GetNote(int NoteID)
    {
        StatusMessage.Text = "";

        var ThisNote = await App.NoteRepo.GetNote(NoteID);
        ThisNoteTitle.Text = ThisNote.NoteTitle;
        ThisNoteContent.Text = ThisNote.NoteContent;

    }
}