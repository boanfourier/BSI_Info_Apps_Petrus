using BSI_Info_Apps;
using BSI_Info_BLL.DTO;
using DAL;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

public class NotesBLL : INotesBLL
{
    private readonly INotes _notesDAL;
    public NotesBLL()
    {
        _notesDAL = new NotesDAL();
    }

    public void DeleteNoteById(int noteId)
    {
         _notesDAL.DeleteNoteById(noteId);
    }

    public void UpdateNote(UpdateNotesDTO updatenote)
    {
        try
        {
            if (updatenote == null)
            {
                Console.WriteLine("UpdateNotesDTO is null.");
                return;
            }

            var notes = new Notes
            {
                note_id = updatenote.note_id,
                event_id = updatenote.event_id,
                note_text = updatenote.note_text,
                created_at = updatenote.created_at
            };

            _notesDAL.UpdateNote(notes);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error occurred: {ex.Message}");
            throw;
        }
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

    public NotesDTO GetNoteById(int noteId)
    {
        try
        {
            var notes = _notesDAL.GetNoteById(noteId);
            var notedto = new NotesDTO
            {
                note_id = notes.note_id,
                event_id = notes.event_id,
                note_text = notes.note_text,
                created_at = notes.created_at,
            };

            return notedto;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error occurred: {ex.Message}");
            throw;
        }
    }


    IEnumerable<NotesDTO> INotesBLL.GetNotesByEventId(int eventId)
    {
        throw new NotImplementedException();
    }

   
}
