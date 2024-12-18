Imports System.Data.SqlClient
Imports System.Configuration

Public Class adminmember
    Inherits System.Web.UI.Page
    Dim strcon As String = ConfigurationManager.ConnectionStrings("con").ConnectionString

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        GridView1.DataBind()
    End Sub

    Protected Sub LinkButton4_Click(ByVal sender As Object, ByVal e As EventArgs) Handles LinkButton4.Click
        getMemberByID()
    End Sub

    Protected Sub LinkButton1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles LinkButton1.Click
        updateMemberStatusByID("active")
    End Sub

    Protected Sub LinkButton2_Click(ByVal sender As Object, ByVal e As EventArgs) Handles LinkButton2.Click
        updateMemberStatusByID("pending")
    End Sub

    Protected Sub LinkButton3_Click(ByVal sender As Object, ByVal e As EventArgs) Handles LinkButton3.Click
        updateMemberStatusByID("deactive")
    End Sub

    Sub getMemberByID()
        Try
            Dim con As New SqlConnection(strcon)
            If con.State = ConnectionState.Closed Then
                con.Open()
            End If

            Dim cmd As SqlCommand = New SqlCommand("SELECT * FROM member_master_tbl WHERE member_id='" + TextBox1.Text.Trim() + "'", con)
            Dim dr As SqlDataReader = cmd.ExecuteReader()

            If dr.HasRows Then
                While dr.Read()
                    TextBox2.Text = dr.GetValue(0).ToString()
                    TextBox7.Text = dr.GetValue(10).ToString()
                    TextBox10.Text = dr.GetValue(1).ToString()
                    TextBox8.Text = dr.GetValue(2).ToString()
                    TextBox9.Text = dr.GetValue(3).ToString()
                    TextBox11.Text = dr.GetValue(4).ToString()
                    TextBox12.Text = dr.GetValue(5).ToString()
                    TextBox13.Text = dr.GetValue(6).ToString()
                    TextBox6.Text = dr.GetValue(7).ToString()
                End While
            Else
                Response.Write("<script>alert('Invalid Member ID')</script>")
            End If

            dr.Close()
            con.Close()
        Catch ex As Exception
            Response.Write("<script>alert('" + ex.Message + "')</script>")
        End Try


    End Sub

    Sub updateMemberStatusByID(ByVal status As String)
        Try
            Dim con As New SqlConnection(strcon)
            If con.State = ConnectionState.Closed Then
                con.Open()
            End If

            Dim cmd As SqlCommand = New SqlCommand("UPDATE member_master_tbl SET account_status='" + status + "' WHERE member_id='" + TextBox1.Text.Trim() + "'", con)
            cmd.ExecuteNonQuery()
            con.Close()
            GridView1.DataBind()
            Response.Write("<script>alert('Member Status Updated')</script>")
        Catch ex As Exception
            Response.Write("<script>alert('" + ex.Message + "')</script>")
        End Try

    End Sub

    Protected Sub Button3_Click(ByVal sender As Object, ByVal e As EventArgs) Handles Button3.Click
        Try
            Dim con As New SqlConnection(strcon)
            If con.State = ConnectionState.Closed Then
                con.Open()
            End If

            Dim cmd As SqlCommand = New SqlCommand("DELETE FROM member_master_tbl WHERE member_id='" + TextBox1.Text.Trim() + "'", con)
            cmd.ExecuteNonQuery()

            con.Close()
            GridView1.DataBind()


            Response.Write("<script>alert('Member Deleted Successfully')</script>")
        Catch ex As Exception
            Response.Write("<script>alert('" + ex.Message + "')</script>")
        End Try
    End Sub
End Class