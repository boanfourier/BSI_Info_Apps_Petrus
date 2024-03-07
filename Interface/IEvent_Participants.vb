Imports BSI_Info_Apps

Public Interface IEvent_Participants
    Function InsertEventParticipant(eventParticipant As Event_Participants) As Integer
    Function GetEventParticipantById(eventParticipantId As Integer) As Event_Participants
End Interface
