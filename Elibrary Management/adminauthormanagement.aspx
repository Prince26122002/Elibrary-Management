<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site1.Master" CodeBehind="adminauthormanagement.aspx.vb" Inherits="Elibrary_Management.adminauthormanagement" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <style>
.form-group
{
margin-bottom:15px;  
}
label
{
margin-bottom:5px;    
}
</style>
    <div class="container">
  <div class="row">
     <div class="col-md-5">
       <div class="card">
         <div class="card-body">
           <div class="row">
              <div class="col">
                <center>
                    <h4>Author Details</h4>
                </center>
              </div>
           </div>
           <div class="row">
              <div class="col">
                <center>
                    <img width="100px" src="imgs/writer.png" />
                </center>
              </div>
           </div>
           <div class="row">
              <div class="col">
                <hr>
              </div>
           </div>
           <br />
           <div class="row">
              <div class="col-md-4">
                <label>Author ID</label>
                <div class="form-group">
                  <div class="input-group">
                    <asp:TextBox ID="TextBox1" CssClass="form-control" runat="server" placeholder="ID"></asp:TextBox>
                    <asp:Button ID="Button1" class="btn btn-primary" runat="server" Text="Go" OnClick="Button1_Click"/>
                  </div>
                </div>
              </div>
              <div class="col-md-8">
                <label>Author Name</label>
                <div class="form-group">
                    <asp:TextBox ID="TextBox2" CssClass="form-control" runat="server" placeholder="Author Name"></asp:TextBox>
                </div>
              </div>
           </div>
   
           <div class="row">
              <div class="col-4">
                 <div class="form-group">
                     <asp:Button ID="Button2" class="btn btn-success btn-lg form-control" runat="server" Text="Add" OnClick="Button2_Click"/>
                </div>
              </div>
              <div class="col-4">
                 <div class="form-group">
                     <asp:Button ID="Button3" class="btn btn-warning btn-lg form-control" runat="server" Text="Update" OnClick="Button3_Click"/>
                </div>
              </div>
              <div class="col-4">
                 <div class="form-group">
                     <asp:Button ID="Button4" class="btn btn-danger btn-lg form-control" runat="server" Text="Delete" OnClick="Button4_Click"/>
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
                    <h4>Author List</h4>
                </center>
              </div>
           </div>
           <div class="row">
              <div class="col">
                <hr>
              </div>
           </div>

            <div class="row">
                <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
                    ConnectionString="<%$ ConnectionStrings:elibraryDBConnectionString %>" 
                    SelectCommand="SELECT * FROM [author_master_tbl]"></asp:SqlDataSource>
              <div class="col">
                  <asp:GridView ID="GridView1" class="table table-striped table-bordered" 
                      runat="server" AutoGenerateColumns="False" DataKeyNames="author_id" 
                      DataSourceID="SqlDataSource1">
                      <Columns>
                          <asp:BoundField DataField="author_id" HeaderText="author_id" ReadOnly="True" 
                              SortExpression="author_id" />
                          <asp:BoundField DataField="author_name" HeaderText="author_name" 
                              SortExpression="author_name" />
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
