Imports BSI_Info_Apps
Public Interface IParticipants
    Sub AddParticipant(participant As Participants)
    Function GetParticipants() As List(Of Participants)
End Interface
