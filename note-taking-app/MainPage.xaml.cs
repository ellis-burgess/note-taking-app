namespace note_taking_app;

public partial class MainPage : ContentPage
{

	public MainPage()
	{
		InitializeComponent();
		SubmitNoteBtn.Clicked += SubmitNote;
		NewNoteBtn.Clicked += NewNote;
		EditNoteBtn.Clicked += EditNote;
	}

	private void SubmitNote(object sender, EventArgs e)
	{
		SubmitNoteBtn.IsEnabled = false;
		SubmitNoteBtn.Text = "Submitted!";
		EditNoteBtn.IsEnabled = true;
	}

	private void NewNote(object sender, EventArgs e)
	{
		editor.Text = null;
		SubmitNoteBtn.IsEnabled = true;
		SubmitNoteBtn.Text = "Submit Note";
		EditNoteBtn.IsEnabled = false;
    }

	private void EditNote(object sender, EventArgs e)
	{
        SubmitNoteBtn.IsEnabled = true;
        SubmitNoteBtn.Text = "Submit Note";
    }
}