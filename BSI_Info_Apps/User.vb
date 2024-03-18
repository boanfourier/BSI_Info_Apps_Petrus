Imports System
Imports System.Collections.Generic

Public Class User
    Public Sub New()
        Me.Roles = New List(Of Role)()
    End Sub

    Public Property Username As String
    Public Property Password As String
    Public Property LastLogin As Date
    Public Property IsLocked As Boolean
    Public Property MaxAttempt As Byte
    Public Property FirstName As String
    Public Property LastName As String
    Public Property Address As String
    Public Property Email As String
    Public Property Telp As String
    Public Property SecurityQuestion As String
    Public Property SecurityAnswer As String
    Public Property Roles As IEnumerable(Of Role)
End Class
