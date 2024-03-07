Imports BSI_Info_Apps

Public Interface ILocations
    Function InsertLocation(location As Locations) As Integer
    Function GetLocationById(locationId As Integer) As Locations
End Interface
