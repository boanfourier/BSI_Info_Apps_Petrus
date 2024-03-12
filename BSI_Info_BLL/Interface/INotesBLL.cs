using BSI_Info_Apps;
using System;
using System.Collections.Generic;

public interface INotesBLL
{
 
    void AddNote(CreateNotesDTO newNote);
    bool UpdateNote(NotesDTO note);
    bool DeleteNoteById(int noteId);
    NotesDTO GetNoteById(int noteId);

    IEnumerable<NotesDTO> GetAllNotes();
    IEnumerable<NotesDTO> GetNotesByEventId(int eventId);
}
