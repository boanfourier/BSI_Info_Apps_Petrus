Imports BSI_Info_Apps

Public Interface ILocations
    Function InsertLocation(location As Locations) As Integer
    Function GetLocationById(locationId As Integer) As Locations
    Function GetAllLocations() As IEnumerable(Of Locations)
    Function DeleteLocation(locationId As Integer) As Boolean
    Function UpdateLocation(location As Locations) As Boolean

End Interface
