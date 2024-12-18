Imports System.Data.SqlClient
Imports System.Configuration
Imports System.IO

Public Class adminbookinventory
    Inherits System.Web.UI.Page
    Dim strcon As String = ConfigurationManager.ConnectionStrings("con").ConnectionString
    Shared global_filepath As String
    Shared global_actual_stock As Int32
    Shared global_current_stock As Int32
    Shared global_issued_books As Int32


    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            fillAuthorPublisherValues()
        End If
        GridView1.DataBind()
    End Sub


    Protected Sub Button3_Click(ByVal sender As Object, ByVal e As EventArgs) Handles Button3.Click
        If checkIfBookExists() Then
            Response.Write("<script>alert('Book Already Exists, try some other Book ID')</script>")
        Else
            addNewBook()
        End If
    End Sub

    Protected Sub Button1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles Button1.Click
        updateBookByID()

    End Sub

    Protected Sub Button2_Click(ByVal sender As Object, ByVal e As EventArgs) Handles Button2.Click
        deleteBookByID()
    End Sub

    Sub updateBookByID()
        If checkIfBookExists() Then
            Dim con As New SqlConnection(strcon)
            Try

                Dim actual_stock As Int32 = Convert.ToInt32(TextBox11.Text.Trim())
                Dim current_stock As Int32 = Convert.ToInt32(TextBox12.Text.Trim())
                If actual_stock <> global_actual_stock Then
                    If actual_stock < global_issued_books Then
                        Response.Write("<script>alert('Actual Stock value cannot be less than issued books')</script>")
                        Return
                    Else
                        current_stock = actual_stock - global_issued_books
                        TextBox12.Text = current_stock.ToString()
                    End If
                End If


                Dim genres As String = ""
                For Each i As Integer In ListBox1.GetSelectedIndices()
                    genres &= ListBox1.Items(i).ToString() & ","
                Next
                genres = genres.TrimEnd(",")


                Dim filepath As String = "~/books/books1.png"
                If FileUpload1.HasFile Then
                    Dim filename As String = Path.GetFileName(FileUpload1.PostedFile.FileName)
                    FileUpload1.SaveAs(Server.MapPath("~/books/" + filename))
                    filepath = "~/books/" + filename
                Else
                    filepath = global_filepath
                End If


                If con.State = ConnectionState.Closed Then
                    con.Open()
                End If

                Dim cmd As SqlCommand = New SqlCommand("UPDATE book_master_tbl SET book_name=@book_name, genre=@genre, author_name=@author_name, publisher_name=@publisher_name, publish_date=@publish_date, language=@language, edition=@edition, book_cost=@book_cost, no_of_pages=@no_of_pages, book_description=@book_description, actual_stock=@actual_stock, current_stock=@current_stock, book_img_link=@book_img_link WHERE book_id=@book_id", con)


                cmd.Parameters.AddWithValue("@book_id", TextBox1.Text.Trim())
                cmd.Parameters.AddWithValue("@book_name", TextBox2.Text.Trim())
                cmd.Parameters.AddWithValue("@genre", genres)
                cmd.Parameters.AddWithValue("@author_name", DropDownList3.SelectedItem.Value)
                cmd.Parameters.AddWithValue("@publisher_name", DropDownList2.SelectedItem.Value)
                cmd.Parameters.AddWithValue("@publish_date", TextBox3.Text.Trim())
                cmd.Parameters.AddWithValue("@language", DropDownList1.SelectedItem.Value)
                cmd.Parameters.AddWithValue("@edition", TextBox8.Text.Trim())
                cmd.Parameters.AddWithValue("@book_cost", TextBox9.Text.Trim())
                cmd.Parameters.AddWithValue("@no_of_pages", TextBox4.Text.Trim())
                cmd.Parameters.AddWithValue("@book_description", TextBox6.Text.Trim())
                cmd.Parameters.AddWithValue("@actual_stock", actual_stock.ToString())
                cmd.Parameters.AddWithValue("@current_stock", current_stock.ToString())
                cmd.Parameters.AddWithValue("@book_img_link", filepath)


                Dim rowsAffected As Integer = cmd.ExecuteNonQuery()

                If rowsAffected > 0 Then
                    Response.Write("<script>alert('Book Status Updated Successfully')</script>")
                    GridView1.DataBind()
                Else
                    Response.Write("<script>alert('No rows were updated')</script>")
                End If
            Catch ex As Exception
                Response.Write("<script>alert('" + ex.Message + "')</script>")
            Finally
                If con.State = ConnectionState.Open Then
                    con.Close()
                End If
            End Try
        Else
            Response.Write("<script>alert('Invalid Book ID')</script>")
        End If
    End Sub


    Sub getBookByID()
        Dim con As New SqlConnection(strcon)
        Try
            If con.State = ConnectionState.Closed Then
                con.Open()
            End If

            Dim cmd As SqlCommand = New SqlCommand("SELECT * FROM book_master_tbl WHERE book_id = @book_id", con)
            cmd.Parameters.AddWithValue("@book_id", TextBox1.Text.Trim())

            Dim da As SqlDataAdapter = New SqlDataAdapter(cmd)
            Dim dt As DataTable = New DataTable()
            da.Fill(dt)

            If dt.Rows.Count >= 1 Then

                TextBox2.Text = dt.Rows(0)("book_name").ToString()
                TextBox3.Text = dt.Rows(0)("publish_date").ToString()
                TextBox8.Text = dt.Rows(0)("edition").ToString()
                TextBox9.Text = dt.Rows(0)("book_cost").ToString().Trim()
                TextBox4.Text = dt.Rows(0)("no_of_pages").ToString().Trim()
                TextBox6.Text = dt.Rows(0)("book_description").ToString()
                TextBox11.Text = dt.Rows(0)("actual_stock").ToString().Trim()
                TextBox12.Text = dt.Rows(0)("current_stock").ToString().Trim()
                TextBox13.Text = (If(String.IsNullOrEmpty(dt.Rows(0)("actual_stock").ToString()), 0, Convert.ToInt32(dt.Rows(0)("actual_stock"))) -
                 If(String.IsNullOrEmpty(dt.Rows(0)("current_stock").ToString()), 0, Convert.ToInt32(dt.Rows(0)("current_stock")))).ToString()


                DropDownList1.SelectedValue = dt.Rows(0)("language").ToString().Trim()
                DropDownList2.SelectedValue = dt.Rows(0)("publisher_name").ToString().Trim()
                DropDownList3.SelectedValue = dt.Rows(0)("author_name").ToString().Trim()
                ListBox1.ClearSelection()



                Dim genre() As String = If(IsDBNull(dt.Rows(0)("genre")), New String() {}, dt.Rows(0)("genre").ToString().Trim().Split(","))

                For Each item As ListItem In ListBox1.Items
                    item.Selected = False
                Next

                For Each g As String In genre
                    Dim listItem As ListItem = ListBox1.Items.FindByText(g.Trim())
                    If listItem IsNot Nothing Then
                        listItem.Selected = True
                    End If
                Next
                global_actual_stock = Convert.ToInt32(dt.Rows(0)("actual_stock").ToString().Trim())
                global_current_stock = Convert.ToInt32(dt.Rows(0)("current_stock").ToString().Trim())
                global_issued_books = global_actual_stock - global_current_stock
                global_filepath = dt.Rows(0)("book_img_link").ToString()

            Else
                Response.Write("<script>alert('Invalid Book ID')</script>")
            End If

        Catch ex As Exception
            Response.Write("<script>alert('" + ex.Message + "')</script>")
        Finally

            con.Close()
        End Try
    End Sub

    Sub fillAuthorPublisherValues()
        Try
            Dim con As New SqlConnection(strcon)
            If con.State = ConnectionState.Closed Then
                con.Open()
            End If

            Dim cmd As SqlCommand = New SqlCommand("SELECT author_name FROM author_master_tbl", con)
            Dim da As SqlDataAdapter = New SqlDataAdapter(cmd)
            Dim dt As DataTable = New DataTable()
            da.Fill(dt)
            DropDownList3.DataSource = dt
            DropDownList3.DataValueField = "author_name"
            DropDownList3.DataBind()

            cmd = New SqlCommand("SELECT publisher_name FROM publisher_master_tbl", con)
            da = New SqlDataAdapter(cmd)
            dt = New DataTable()
            da.Fill(dt)
            DropDownList2.DataSource = dt
            DropDownList2.DataValueField = "publisher_name"
            DropDownList2.DataBind()
        Catch ex As Exception
            Response.Write("<script>alert('" + ex.Message + "')</script>")
        End Try
    End Sub

    Sub addNewBook()
        Try
            Dim genres As String = ""
            For Each i As Integer In ListBox1.GetSelectedIndices()
                genres &= ListBox1.Items(i).ToString() & ","
            Next
            genres = genres.Remove(genres.Length - 1)

            Dim filepath As String = "~/books/books1.png"
            If FileUpload1.HasFile Then
                Dim filename As String = Path.GetFileName(FileUpload1.PostedFile.FileName)
                FileUpload1.SaveAs(Server.MapPath("~/books/" + filename))
                filepath = "~/books/" + filename
            End If

            Dim con As New SqlConnection(strcon)
            If con.State = ConnectionState.Closed Then
                con.Open()
            End If

            Dim cmd As SqlCommand = New SqlCommand("INSERT INTO book_master_tbl(book_id,book_name,genre,author_name,publisher_name,publish_date,language,edition,book_cost,no_of_pages,book_description,actual_stock,current_stock,book_img_link) values(@book_id,@book_name,@genre,@author_name,@publisher_name,@publish_date,@language,@edition,@book_cost,@no_of_pages,@book_description,@actual_stock,@current_stock,@book_img_link)", con)

            cmd.Parameters.AddWithValue("@book_id", TextBox1.Text.Trim())
            cmd.Parameters.AddWithValue("@book_name", TextBox2.Text.Trim())
            cmd.Parameters.AddWithValue("@genre", genres)
            cmd.Parameters.AddWithValue("@author_name", DropDownList3.SelectedItem.Value)
            cmd.Parameters.AddWithValue("@publisher_name", DropDownList2.SelectedItem.Value)
            cmd.Parameters.AddWithValue("@publish_date", TextBox3.Text.Trim())
            cmd.Parameters.AddWithValue("@language", DropDownList1.SelectedItem.Value)
            cmd.Parameters.AddWithValue("@edition", TextBox8.Text.Trim())
            cmd.Parameters.AddWithValue("@book_cost", TextBox9.Text.Trim())
            cmd.Parameters.AddWithValue("@no_of_pages", TextBox4.Text.Trim())
            cmd.Parameters.AddWithValue("@book_description", TextBox6.Text.Trim())
            cmd.Parameters.AddWithValue("@actual_stock", TextBox11.Text.Trim())
            cmd.Parameters.AddWithValue("@current_stock", TextBox11.Text.Trim())
            cmd.Parameters.AddWithValue("@book_img_link", filepath)


            cmd.ExecuteNonQuery()
            con.Close()
            Response.Write("<script>alert('Book added Successfully')</script>")
            GridView1.DataBind()



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
            Dim cmd As New SqlCommand("SELECT * from book_master_tbl where book_id=@book_id OR book_name=@book_name", con)
            cmd.Parameters.AddWithValue("@book_id", TextBox1.Text.Trim())
            cmd.Parameters.AddWithValue("@book_name", TextBox2.Text.Trim())

            Dim da As New SqlDataAdapter(cmd)
            Dim dt As New DataTable()
            da.Fill(dt)

            Return dt.Rows.Count >= 1
        Catch ex As Exception
            Response.Write("<script>alert('" + ex.Message + "')</script>")
            Return False
        Finally
            If con.State = ConnectionState.Open Then
                con.Close()
            End If
        End Try
    End Function


    Sub deleteBookByID()
        Try
            Dim con As New SqlConnection(strcon)
            If con.State = ConnectionState.Closed Then
                con.Open()
            End If

            Dim cmd As New SqlCommand("DELETE FROM book_master_tbl WHERE book_id=@book_id", con)
            cmd.Parameters.AddWithValue("@book_id", TextBox1.Text.Trim())
            cmd.ExecuteNonQuery()

            con.Close()
            GridView1.DataBind()

            Response.Write("<script>alert('Book Deleted Successfully')</script>")
        Catch ex As Exception
            Response.Write("<script>alert('" + ex.Message + "')</script>")
        End Try
    End Sub


    Protected Sub LinkButton4_Click(ByVal sender As Object, ByVal e As EventArgs) Handles LinkButton4.Click
        getBookByID()
    End Sub
End Class