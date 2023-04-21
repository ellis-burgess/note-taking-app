using System;
using SQLite;

namespace note_taking_app.Models
{
	[Table("notes")]
	public class Note
	{
		[PrimaryKey, AutoIncrement]
		public int Id { get; set; }

        [MaxLength(250), Unique]
        public string NoteContent { get; set; }
	}
}