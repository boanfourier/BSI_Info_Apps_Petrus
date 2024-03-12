using BSI_Info_Apps;
using DAL;
using System;
using System.Collections.Generic;
using System.Text;

public class NotesBLL : INotesBLL
{
    private readonly INotes _notesDAL;
    public NotesBLL()
    {
        _notesDAL = new NotesDAL();
    }

    void INotesBLL.AddNote(CreateNotesDTO createNote)
    {
        try
        {
            var notes = new Notes
            {
                note_id = createNote.note_id,
                event_id = createNote.event_id,
                note_text = createNote.note_text,
                created_at = createNote.created_at,
            };

            if (createNote != null)
            {
                _notesDAL.InsertNote(notes);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error occurred: {ex.Message}");
            throw;
        }
    }


    bool INotesBLL.DeleteNoteById(int noteId)
    {
        throw new NotImplementedException();
    }

    IEnumerable<NotesDTO> INotesBLL.GetAllNotes()
    {
        try
        {
            var notes = _notesDAL.GetAllNotes();
            var notesDTOs = new List<NotesDTO>();

            foreach (var notesObj in notes)
            {
                var notesdto = new NotesDTO
                {
                    note_id = notesObj.note_id,
                    event_id = notesObj.event_id,
                    note_text = notesObj.note_text,
                    created_at = notesObj.created_at,
                };

                notesDTOs.Add(notesdto);
            }

            return notesDTOs;
        }
        catch (Exception ex)
        {

            Console.WriteLine($"Error occurred: {ex.Message}");
            throw;
        }

    }

    NotesDTO INotesBLL.GetNoteById(int noteId)
    {
        throw new NotImplementedException();
    }

    IEnumerable<NotesDTO> INotesBLL.GetNotesByEventId(int eventId)
    {
        throw new NotImplementedException();
    }

    bool INotesBLL.UpdateNote(NotesDTO note)
    {
        throw new NotImplementedException();
    }
}
