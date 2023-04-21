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

		private SQLiteConnection conn;

		private void Init()
		{
			if (conn != null)
				return;

			Console.WriteLine("Path" + _dbPath);
			conn = new SQLiteConnection(_dbPath);
			conn.CreateTable<Note>();
		}

		public NoteRepository(string dbPath)
		{
			_dbPath = dbPath;
		}

		public void AddNewPerson(string name)
		{
			int result = 0;
			try
			{
				Init();

				if (string.IsNullOrEmpty(name))
					throw new Exception("Valid name required.");

				result = conn.Insert(new Note { NoteContent = name });

				StatusMessage = string.Format("{0} record(s) added", result);
			}
			catch (Exception ex)
			{
				StatusMessage = string.Format("Failed to add {0}. Error: {1})",
					name, ex.Message);
			}

		}

        public void AddNewNote(string note)
        {
            int result = 0;
            try
            {
                Init();

                if (string.IsNullOrEmpty(note))
                    throw new Exception("Note can't be empty.");

                result = conn.Insert(new Note { NoteContent = note });

                StatusMessage = string.Format("{0} record(s) added", result);
            }
            catch (Exception ex)
            {
                StatusMessage = string.Format("Failed to add {0}. Error: {1})",
                    note, ex.Message);
            }

        }
    }
}

