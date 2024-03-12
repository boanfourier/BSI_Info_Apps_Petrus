Imports BSI_Info_Apps

Public Interface IOrganizers
    Sub AddOrganizer(ByVal organizer As Organizer)
    Function GetAllOrganizer() As List(Of Organizer)
End Interface
