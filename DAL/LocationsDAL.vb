Imports System.Data.SqlClient
Imports BSI_Info_Apps

Public Class LocationsDAL
    Implements ILocations
    Private Const strConn As String = "Server=.\SQLEXPRESS02;Database=BSI_info;Trusted_Connection=True;"
    Private conn As SqlConnection
    Private cmd As SqlCommand
    Private dr As SqlDataReader

    Public Sub New()
        conn = New SqlConnection(strConn)
    End Sub

    Public Function InsertLocation(location As Locations) As Integer Implements ILocations.InsertLocation
        Dim query As String = "INSERT INTO Locations (name, address, capacity, description) " &
                              "VALUES (@name, @address, @capacity, @description); " &
                              "SELECT SCOPE_IDENTITY();"

        Using connection As New SqlConnection(strConn)
            Using command As New SqlCommand(query, connection)
                command.Parameters.AddWithValue("@name", location.name)
                command.Parameters.AddWithValue("@address", location.address)
                command.Parameters.AddWithValue("@capacity", If(location.capacity.HasValue, CType(location.capacity, Object), DBNull.Value))
                command.Parameters.AddWithValue("@description", location.description)

                Try
                    connection.Open()
                    Return Convert.ToInt32(command.ExecuteScalar())
                Catch ex As Exception
                    ' Handle exception (e.g., log or rethrow)
                    Throw
                End Try
            End Using
        End Using
    End Function

    Public Function GetLocationById(locationId As Integer) As Locations Implements ILocations.GetLocationById
        Dim query As String = "SELECT * FROM Locations WHERE location_id = @location_id"
        Dim locationItem As New Locations()

        Using connection As New SqlConnection(strConn)
            Using command As New SqlCommand(query, connection)
                command.Parameters.AddWithValue("@location_id", locationId)

                Try
                    connection.Open()
                    Using reader As SqlDataReader = command.ExecuteReader()
                        If reader.Read() Then
                            locationItem.location_id = Convert.ToInt32(reader("location_id"))
                            locationItem.name = Convert.ToString(reader("name"))
                            locationItem.address = Convert.ToString(reader("address"))
                            locationItem.capacity = If(reader("capacity") IsNot DBNull.Value, CType(reader("capacity"), Integer?), Nothing)
                            locationItem.description = Convert.ToString(reader("description"))
                        End If
                    End Using
                Catch ex As Exception
                    ' Handle exception (e.g., log or rethrow)
                    Throw
                End Try
            End Using
        End Using

        Return locationItem
    End Function
    Public Function GetAllLocations() As IEnumerable(Of Locations) Implements ILocations.GetAllLocations
        Dim locations As New List(Of Locations)()
        Dim query As String = "SELECT * FROM Locations"

        Using connection As New SqlConnection(strConn)
            Using command As New SqlCommand(query, connection)
                Try
                    connection.Open()
                    Using reader As SqlDataReader = command.ExecuteReader()
                        While reader.Read()
                            Dim locationItem As New Locations()
                            locationItem.location_id = Convert.ToInt32(reader("location_id"))
                            locationItem.name = Convert.ToString(reader("name"))
                            locationItem.address = Convert.ToString(reader("address"))
                            locationItem.capacity = If(reader("capacity") IsNot DBNull.Value, CType(reader("capacity"), Integer?), Nothing)
                            locationItem.description = Convert.ToString(reader("description"))
                            locations.Add(locationItem)
                        End While
                    End Using
                Catch ex As Exception
                    ' Handle exception (e.g., log or rethrow)
                    Throw
                End Try
            End Using
        End Using

        Return locations
    End Function
End Class
