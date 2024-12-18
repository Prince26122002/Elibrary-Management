Imports System.Data.SqlClient
Imports System.Configuration
Public Class adminpublishermanagement
    Inherits System.Web.UI.Page
    Dim strcon As String = ConfigurationManager.ConnectionStrings("con").ConnectionString
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        GridView1.DataBind()
    End Sub

    Protected Sub Button2_Click(ByVal sender As Object, ByVal e As EventArgs) Handles Button2.Click
        If checkIfPublisherExists() Then
            Response.Write("<script>alert('Publisher with this ID already Exists. You cannot add another Publisher with the same Publisher ID')</script>")
        Else
            addNewPublisher()
        End If
    End Sub

    Protected Sub Button3_Click(ByVal sender As Object, ByVal e As EventArgs) Handles Button3.Click
        If checkIfPublisherExists() Then
            updatePublisher()

        Else
            Response.Write("<script>alert('Publisher does not exist')</script>")
        End If
    End Sub

    Protected Sub Button4_Click(ByVal sender As Object, ByVal e As EventArgs) Handles Button4.Click
        If checkIfPublisherExists() Then
            deletePublisher()

        Else
            Response.Write("<script>alert('Publisher does not exist')</script>")
        End If
    End Sub

    Protected Sub Button1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles Button1.Click
        getPublisherByID()
    End Sub
    Sub deletePublisher()
        Try
            Dim con As New SqlConnection(strcon)
            If con.State = ConnectionState.Closed Then
                con.Open()
            End If
            Dim cmd As SqlCommand = New SqlCommand("DELETE from publisher_master_tbl WHERE publisher_id='" + TextBox1.Text.Trim() + "'", con)

            cmd.ExecuteNonQuery()
            con.Close()
            Response.Write("<script>alert('Publisher Deleted Successfully')</script>")
            clearForm()
            GridView1.DataBind()
        Catch ex As Exception
            Response.Write("<script>alert('" + ex.Message + "')</script>")
        End Try
    End Sub
    Sub updatePublisher()
        Try
            Dim con As New SqlConnection(strcon)
            If con.State = ConnectionState.Closed Then
                con.Open()
            End If
            Dim cmd As SqlCommand = New SqlCommand("UPDATE publisher_master_tbl SET publisher_name=@publisher_name WHERE publisher_id='" + TextBox1.Text.Trim() + "'", con)

            cmd.Parameters.AddWithValue("@publisher_name", TextBox2.Text.Trim())
            cmd.ExecuteNonQuery()
            con.Close()
            Response.Write("<script>alert('Publisher Updated Successfully')</script>")
            clearForm()
            GridView1.DataBind()
        Catch ex As Exception
            Response.Write("<script>alert('" + ex.Message + "')</script>")
        End Try
    End Sub
    Sub addNewPublisher()
        Try
            Dim con As New SqlConnection(strcon)
            If con.State = ConnectionState.Closed Then
                con.Open()
            End If
            Dim cmd As SqlCommand = New SqlCommand("INSERT INTO publisher_master_tbl(publisher_id,publisher_name) VALUES(@publisher_id,@publisher_name)", con)
            cmd.Parameters.AddWithValue("@publisher_id", TextBox1.Text.Trim())
            cmd.Parameters.AddWithValue("@publisher_name", TextBox2.Text.Trim())
            cmd.ExecuteNonQuery()
            con.Close()
            Response.Write("<script>alert('Publisher added Successfully')</script>")
            clearForm()
            GridView1.DataBind()


        Catch ex As Exception
            Response.Write("<script>alert('" + ex.Message + "')</script>")
        End Try
    End Sub

    Function checkIfPublisherExists() As Boolean
        Try
            Dim con As New SqlConnection(strcon)
            If con.State = ConnectionState.Closed Then
                con.Open()
            End If
            Dim cmd As SqlCommand = New SqlCommand("SELECT * from publisher_master_tbl where publisher_id='" + TextBox1.Text.Trim() + "'", con)
            Dim da As SqlDataAdapter = New SqlDataAdapter(cmd)
            Dim dt As DataTable = New DataTable()
            da.Fill(dt)

            If dt.Rows.Count >= 1 Then
                Return True
            Else
                Return False
            End If
            con.Close()
            Response.Write("<script>alert('Sign Up Successful. Go to User Login to Login')</script>")
        Catch ex As Exception
            Response.Write("<script>alert('" + ex.Message + "')</script>")
            Return False
        End Try
    End Function
    Sub clearForm()
        TextBox1.Text = ""
        TextBox2.Text = ""
    End Sub
    Sub getPublisherByID()
        Try
            Dim con As New SqlConnection(strcon)
            If con.State = ConnectionState.Closed Then
                con.Open()
            End If
            Dim cmd As SqlCommand = New SqlCommand("SELECT * from publisher_master_tbl where publisher_id='" + TextBox1.Text.Trim() + "'", con)
            Dim da As SqlDataAdapter = New SqlDataAdapter(cmd)
            Dim dt As DataTable = New DataTable()
            da.Fill(dt)

            If dt.Rows.Count >= 1 Then
                TextBox2.Text = dt.Rows(0)(1).ToString()

            Else
                Response.Write("<script>alert('Invalid Publisher ID')</script>")
            End If

        Catch ex As Exception
            Response.Write("<script>alert('" + ex.Message + "')</script>")
        End Try
    End Sub
End Class