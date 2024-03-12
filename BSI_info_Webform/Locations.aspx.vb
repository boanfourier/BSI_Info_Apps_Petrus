Imports BSI_Info_Apps

Public Class Locations
    Inherits System.Web.UI.Page

    Private ReadOnly _locationsBLL As ILocationsBLL

    Public Sub New()
        _locationsBLL = New LocationsBLL()
    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            BindLocationsToGridView()
        End If
    End Sub

    Private Sub BindLocationsToGridView()
        Dim locations = _locationsBLL.GetAllLocations()
        GridViewLocations.DataSource = locations
        GridViewLocations.DataBind()
    End Sub
End Class



