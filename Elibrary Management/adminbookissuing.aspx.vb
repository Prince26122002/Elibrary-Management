Imports System.Data.SqlClient
Imports System.Configuration
Public Class adminbookissuing
    Inherits System.Web.UI.Page
    Dim strcon As String = ConfigurationManager.ConnectionStrings("con").ConnectionString
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Protected Sub Button2_Click(ByVal sender As Object, ByVal e As EventArgs) Handles Button2.Click
        getNames()
    End Sub

    Protected Sub Button3_Click(ByVal sender As Object, ByVal e As EventArgs) Handles Button3.Click
        If checkIfBookExists() AndAlso checkIfMemberExists() Then
            If checkIfIssueEntryExists() Then
                Response.Write("<script>alert('This Member already has this book')</script>")
            Else
                issueBook()
            End If

        Else
            Response.Write("<script>alert('Wrong Member or Book ID')</script>")
        End If
    End Sub

    Protected Sub Button4_Click(ByVal sender As Object, ByVal e As EventArgs) Handles Button4.Click
        If checkIfBookExists() AndAlso checkIfMemberExists() Then
            If checkIfIssueEntryExists() Then
                Response.Write("<script>alert('This entry does not exist')</script>")
            Else

                returnBook()

            End If

        Else
            Response.Write("<script>alert('Wrong or Book ID')</script>")
        End If
    End Sub

    Sub returnBook()
        Try
            Dim con As New SqlConnection(strcon)
            If con.State = ConnectionState.Closed Then
                con.Open()
            End If

            Dim cmd As New SqlCommand("DELETE FROM book_issue_tbl WHERE book_id='" + TextBox1.Text.Trim() + "' AND member_id='" + TextBox2.Text.Trim() + "'", con)
            ' cmd.Parameters.AddWithValue("@book_id", TextBox1.Text.Trim())
            Dim result As Int32 = cmd.ExecuteNonQuery()
            If result > 0 Then
                cmd = New SqlCommand("update book_master_tbl set current_stock = current_stock+1 WHERE book_id='" + TextBox1.Text.Trim() + "'", con)
                cmd.ExecuteNonQuery()
                con.Close()
                Response.Write("<script>alert('Book Returned Successfully')</script>")
                GridView1.DataBind()
            Else
                Response.Write("<script>alert('No matching record found to delete')</script>")
            End If


        Catch ex As Exception
            Response.Write("<script>alert('" + ex.Message + "')</script>")
        End Try
    End Sub
    Sub issueBook()
        Try
            Dim con As New SqlConnection(strcon)
            If con.State = ConnectionState.Closed Then
                con.Open()
            End If
            Dim cmd As SqlCommand = New SqlCommand("INSERT INTO book_issue_tbl(member_id,member_name,book_id,book_name,issue_date,due_date) VALUES(@member_id,@member_name,@book_id,@book_name,@issue_date,@due_date)", con)
            cmd.Parameters.AddWithValue("@member_id", TextBox2.Text.Trim())
            cmd.Parameters.AddWithValue("@member_name", TextBox3.Text.Trim())
            cmd.Parameters.AddWithValue("@book_id", TextBox1.Text.Trim())
            cmd.Parameters.AddWithValue("@book_name", TextBox4.Text.Trim())
            cmd.Parameters.AddWithValue("@issue_date", TextBox5.Text.Trim())
            cmd.Parameters.AddWithValue("@due_date", TextBox6.Text.Trim())
            cmd.ExecuteNonQuery()

            cmd = New SqlCommand("Update book_master_tbl SET current_stock = current_stock - 1 WHERE book_id ='" + TextBox1.Text.Trim() + "'", con)
            cmd.ExecuteNonQuery()
            con.Close()
            Response.Write("<script>alert('Book Issue Successfully')</script>")

            GridView1.DataBind()


        Catch ex As Exception
            Response.Write("<script>alert('" + ex.Message + "')</script>")
        End Try
    End Sub

    Sub getNames()
        Try
            Dim con As New SqlConnection(strcon)
            If con.State = ConnectionState.Closed Then
                con.Open()
            End If

            Dim cmd As SqlCommand = New SqlCommand("SELECT book_name FROM book_master_tbl WHERE book_id='" + TextBox1.Text.Trim() + "'", con)
            Dim da As SqlDataAdapter = New SqlDataAdapter(cmd)
            Dim dt As DataTable = New DataTable()
            da.Fill(dt)

            If (dt.Rows.Count >= 1) Then
                TextBox4.Text = dt.Rows(0)("book_name").ToString()
            Else
                Response.Write("<script>alert('Wrong Book ID')</script>")

            End If

            cmd = New SqlCommand("SELECT full_name FROM member_master_tbl WHERE member_id='" + TextBox2.Text.Trim() + "'", con)
            da = New SqlDataAdapter(cmd)
            dt = New DataTable()
            da.Fill(dt)

            If (dt.Rows.Count >= 1) Then
                TextBox3.Text = dt.Rows(0)("full_name").ToString()
            Else
                Response.Write("<script>alert('Wrong User ID')</script>")

            End If
        Catch ex As Exception
            Response.Write("<script>alert('" + ex.Message + "')</script>")
        End Try
    End Sub

    Function checkIfBookExists() As Boolean
        Dim con As New SqlConnection(strcon)
        Try
            If con.State = ConnectionState.Closed Then
                con.Open()
            End If
            Dim cmd As New SqlCommand("SELECT * from book_master_tbl where book_id='" + TextBox1.Text.Trim() + "' AND current_stock > 0", con)
            Dim da As New SqlDataAdapter(cmd)
            Dim dt As New DataTable()
            da.Fill(dt)

            If dt.Rows.Count >= 1 Then
                Return True
            Else
                Return False
            End If

        Catch ex As Exception
            Response.Write("<script>alert('" + ex.Message + "')</script>")
            Return False
        Finally
            If con.State = ConnectionState.Open Then
                con.Close()
            End If
        End Try
    End Function
  

    Function checkIfMemberExists() As Boolean
        Dim con As New SqlConnection(strcon)
        Try
            If con.State = ConnectionState.Closed Then
                con.Open()
            End If
            Dim cmd As New SqlCommand("SELECT full_name from member_master_tbl where member_id='" + TextBox2.Text.Trim() + "'", con)
            Dim da As New SqlDataAdapter(cmd)
            Dim dt As New DataTable()
            da.Fill(dt)

            If dt.Rows.Count >= 1 Then
                Return True
            Else
                Return False
            End If

        Catch ex As Exception
            Response.Write("<script>alert('" + ex.Message + "')</script>")
            Return False
        Finally
            If con.State = ConnectionState.Open Then
                con.Close()
            End If
        End Try
    End Function
    Function checkIfIssueEntryExists() As Boolean
        Dim con As New SqlConnection(strcon)
        Try
            If con.State = ConnectionState.Closed Then
                con.Open()
            End If
            Dim cmd As New SqlCommand("SELECT full_name from book_issue_tbl where member_id='" + TextBox2.Text.Trim() + "' AND book_id='" + TextBox1.Text.Trim() + "'", con)
            Dim da As New SqlDataAdapter(cmd)
            Dim dt As New DataTable()
            da.Fill(dt)

            If dt.Rows.Count >= 1 Then
                Return True
            Else
                Return False
            End If

        Catch ex As Exception
            Response.Write("<script>alert('" + ex.Message + "')</script>")
            Return False
        Finally
            If con.State = ConnectionState.Open Then
                con.Close()
            End If
        End Try
    End Function

    Protected Sub GridView1_RowDataBound(ByVal sender As Object, ByVal e As GridViewRowEventArgs)
        Try
            If e.Row.RowType = DataControlRowType.DataRow Then
                Dim dt As DateTime = Convert.ToDateTime(e.Row.Cells(5).Text)
                Dim today As DateTime = DateTime.Today
                If today > dt Then
                    e.Row.BackColor = System.Drawing.Color.PaleVioletRed
                End If
            End If
        Catch ex As Exception
            Response.Write("<script>alert('" + ex.Message + "')</script>")
        End Try

    End Sub


End Class