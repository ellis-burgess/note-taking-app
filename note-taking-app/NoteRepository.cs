using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;
using note_taking_app.Models;

namespace note_taking_app
{
	public class NoteRepository
	{
		string _dbPath;

		public string StatusMessage { get; set; }

		private SQLiteAsyncConnection conn;

		private async Task Init()
		{
			if (conn != null)
				return;

			conn = new SQLiteAsyncConnection(_dbPath);

			await conn.CreateTableAsync<Note>();
		}

		public NoteRepository(string dbPath)
		{
			_dbPath = dbPath;
		}

        public async Task AddNewNote(string noteTitle, string noteContent)
        {
            int result = 0;
            try
            {
                // Call Init()
                await Init();

                // Validate title and content are both not empty
                if (string.IsNullOrEmpty(noteTitle))
                    throw new Exception("Title can't be empty.");

				if (string.IsNullOrEmpty(noteContent))
					throw new Exception("Note can't be empty.");

				result = await conn.InsertAsync(
                    new Note
                    {
                        NoteTitle = noteTitle,
                        NoteContent = noteContent
                    });

                StatusMessage = string.Format(
                    "New note \"{0}\" saved", noteTitle);
            }
            catch (Exception ex)
            {
                StatusMessage = string.Format(
                    "Failed to add {0}. Error: {1})",
                    noteTitle, ex.Message);
            }

        }

        public async Task<List<Note>> GetAllNotes()
        {
            try
            {
                await Init();
                return await conn.Table<Note>().ToListAsync();
            }
            catch (Exception ex)
            {
                StatusMessage = string.Format(
                    "Failed to retrieve data. {0}",
                    ex.Message);
            }

            return new List<Note>();
        }

        public async Task<Note> GetNote(int noteID)
        {
            try
            {
                await Init();
                return await conn.Table<Note>().
                    FirstOrDefaultAsync(n => n.Id == noteID);
            }
            catch (Exception ex)
            {
                StatusMessage = string.Format(
                    "Error retrieving note. {0}",
                    ex.Message);
            }

            return new Note();
        }
    }
}

