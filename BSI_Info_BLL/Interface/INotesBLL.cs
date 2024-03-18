using BSI_Info_Apps;
using BSI_Info_BLL.DTO;
using System;
using System.Collections.Generic;

public interface INotesBLL
{
 
    void AddNote(CreateNotesDTO newNote);
    void UpdateNote(UpdateNotesDTO updatenote);
    void DeleteNoteById(int noteId);
    NotesDTO GetNoteById(int noteId);

    IEnumerable<NotesDTO> GetAllNotes();
    IEnumerable<NotesDTO> GetNotesByEventId(int eventId);
}
