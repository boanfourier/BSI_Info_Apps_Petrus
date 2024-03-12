Imports BSI_Info_Apps

Public Interface INotes
    Function InsertNote(note As Notes) As Integer
    Function GetNoteById(noteId As Integer) As Notes
    Function GetAllNotes() As IEnumerable(Of Notes)
End Interface
