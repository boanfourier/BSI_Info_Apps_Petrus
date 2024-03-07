Imports BSI_Info_Apps

Public Interface IEvents
    Function InsertEvent(events As [Events]) As Integer
    Function GetEventById(eventId As Integer) As [Events]
End Interface
