using Microsoft.Extensions.Logging;

namespace note_taking_app;

public static class MauiProgram
{
	public static MauiApp CreateMauiApp()
	{
		var builder = MauiApp.CreateBuilder();
		builder
			.UseMauiApp<App>()
			.ConfigureFonts(fonts =>
			{
				fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
				fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
			});

		string mainDir = System.IO.Path
			.Combine(FileSystem.Current.AppDataDirectory, "NoteTakingApp");
		System.IO.Directory.CreateDirectory(mainDir);

		string dbPath = mainDir;
		dbPath = Path.Combine(mainDir, "notes.db3");
		FileInfo fl = new FileInfo(dbPath);
		Console.WriteLine(fl);

		builder
			.Services
			.AddSingleton<NoteRepository>
			(s => ActivatorUtilities
			.CreateInstance
				<NoteRepository>(s, dbPath));

#if DEBUG
		builder.Logging.AddDebug();
#endif

		return builder.Build();
	}
}

