Imports BSI_Info_Apps

Public Interface IEvents
    Sub InsertEvent(events As [Events])
    Function GetEventById(eventId As Integer) As [Events]
    Function GetAllEvents() As IEnumerable(Of Events)
    Sub DeleteEvent(eventId As Integer)
    Sub UpdateEvent(events As [Events])

End Interface
