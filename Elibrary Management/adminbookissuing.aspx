<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site1.Master" CodeBehind="adminbookissuing.aspx.vb" Inherits="Elibrary_Management.adminbookissuing" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<style>
.row
{
margin-bottom:15px;  
}
label
{
margin-bottom:5px;    
}
</style>

<div class="container-fluid">
  <div class="row">
     <div class="col-md-5">
       <div class="card">
         <div class="card-body">
           <div class="row">
              <div class="col">
                <center>
                    <h4>Book Issuing</h4>
                </center>
              </div>
           </div>
           <div class="row">
              <div class="col">
                <center>
                    <img width="100px" src="imgs/books.png" />
                </center>
              </div>
           </div>
           <div class="row">
              <div class="col">
                <hr>
              </div>
           </div>
           
           <div class="row">
              <div class="col-md-6">
                <label>Member ID</label>
                <div class="form-group">
                    <asp:TextBox ID="TextBox2" CssClass="form-control" runat="server" placeholder="ID"></asp:TextBox>
                </div>
              </div>
              <div class="col-6">
                <label>Book ID</label>
                 <div class="form-group">
                   <div class="input-group">
                     <asp:TextBox ID="TextBox1" CssClass="form-control" runat="server" placeholder="ID"></asp:TextBox>
                     <asp:Button ID="Button2" class="btn btn-primary" runat="server" placeholder="ID" Text="Go" />
                   </div>
                 </div>
               </div>
              </div>

           <div class="row">
              <div class="col-md-6">
                <label>Member Name</label>
                <div class="form-group">
                    <asp:TextBox ID="TextBox3" CssClass="form-control" runat="server" placeholder="Member Name" ReadOnly="True"></asp:TextBox>
                </div>
              </div>
              <div class="col-md-6">
                <label>Book Name</label>
                <div class="form-group">
                    <asp:TextBox ID="TextBox4" CssClass="form-control" runat="server" placeholder="Book Name" ReadOnly="True"></asp:TextBox>
                </div>
              </div>
            </div>

           <div class="row">
              <div class="col-md-6">
                <label>Start Date</label>
                <div class="form-group">
                    <asp:TextBox ID="TextBox5" CssClass="form-control" runat="server" placeholder="Start Date" TextMode="Date" ReadOnly="False"></asp:TextBox>
                </div>
              </div>
              <div class="col-md-6">
                <label>Due Date</label>
                <div class="form-group">
                    <asp:TextBox ID="TextBox6" CssClass="form-control" runat="server" placeholder="End Date" TextMode="Date" ReadOnly="False"></asp:TextBox>
                </div>
              </div>
            </div>
            
            <div class="row">
              <div class="col-6">
                 <div class="form-group">
                   <asp:Button ID="Button3" class="btn btn-primary btn-lg form-control" runat="server" Text="Issue" />
                </div>
              </div>
              <div class="col-6">
                 <div class="form-group">
                     <asp:Button ID="Button4" class="btn btn-success btn-lg form-control" runat="server" Text="Return" />
                </div>
              </div>
           </div>
         </div>
       </div>
       <a href="homepage.aspx"><< Back to Home</a><br />
       <br />
    </div>

    <div class="col-md-7">
       <div class="card">
         <div class="card-body">
          
           <div class="row">
              <div class="col">
                <center>
                    <h4>Issued Book List</h4>
                </center>
              </div>
           </div>
           <div class="row">
              <div class="col">
                <hr>
              </div>
           </div>

            <div class="row">
              <div class="col">
                  <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
                      ConnectionString="<%$ ConnectionStrings:elibraryDBConnectionString %>" 
                      SelectCommand="SELECT * FROM [book_issue_tbl]"></asp:SqlDataSource>
                  <asp:GridView ID="GridView1" class="table table-striped table-bordered" 
                      runat="server" AutoGenerateColumns="False" OnRowDataBound="GridView1_RowDataBound" DataSourceID="SqlDataSource1">
                      <Columns>
                          <asp:BoundField DataField="member_id" HeaderText="Member ID" 
                              SortExpression="member_id" />
                          <asp:BoundField DataField="member_name" HeaderText="Member Name" 
                              SortExpression="member_name" />
                          <asp:BoundField DataField="book_id" HeaderText="Book ID" 
                              SortExpression="book_id" />
                          <asp:BoundField DataField="book_name" HeaderText="Book Name" 
                              SortExpression="book_name" />
                          <asp:BoundField DataField="issue_date" HeaderText="Issue Date" 
                              SortExpression="issue_date" />
                          <asp:BoundField DataField="due_date" HeaderText="Due Date" 
                              SortExpression="due_date" />
                      </Columns>
                  </asp:GridView>
              </div>
           </div>
           <br />
       </div>  
       </div>
       
    </div>
  </div>
</div>

</asp:Content>
