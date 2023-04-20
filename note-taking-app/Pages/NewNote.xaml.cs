namespace note_taking_app;

public partial class NewNote : ContentPage
{
	public NewNote()
	{
		InitializeComponent();
        SubmitNoteBtn.Clicked += SubmitNote;
        NewNoteBtn.Clicked += AddNote;
        EditNoteBtn.Clicked += EditNote;

    }

    private void SubmitNote(object sender, EventArgs e)
    {
        editor.IsEnabled = false;
        SubmitNoteBtn.IsEnabled = false;
        SubmitNoteBtn.Text = "Submitted!";
        EditNoteBtn.IsEnabled = true;
    }

    private void AddNote(object sender, EventArgs e)
    {
        editor.Text = null;
        SubmitNoteBtn.IsEnabled = true;
        SubmitNoteBtn.Text = "Submit Note";
        EditNoteBtn.IsEnabled = false;
    }

    private void EditNote(object sender, EventArgs e)
    {
        editor.IsEnabled = true;
        SubmitNoteBtn.IsEnabled = true;
        SubmitNoteBtn.Text = "Submit Note";
    }

}
