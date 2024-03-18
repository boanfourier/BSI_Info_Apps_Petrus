Imports BSI_Info_Apps

Public Interface INotes
    Function InsertNote(note As Notes) As Integer
    Function GetNoteById(noteId As Integer) As Notes
    Function GetAllNotes() As IEnumerable(Of Notes)
    Function UpdateNote(note As Notes) As Boolean
    Function DeleteNoteById(noteId As Integer) As Boolean
End Interface
