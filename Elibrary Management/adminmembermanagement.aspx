<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site1.Master" CodeBehind="adminmembermanagement.aspx.vb" Inherits="Elibrary_Management.adminmember" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<style>
.row{
margin-bottom:12px;
}
label
{
margin-bottom:2px;  
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
                    <h4>Member Details</h4>
                </center>
              </div>
           </div>
           <div class="row">
              <div class="col">
                <center>
                    <img width="100px" src="imgs/generaluser.png" />
                </center>
              </div>
           </div>
           <div class="row">
              <div class="col">
                <hr>
              </div>
           </div>
           
           <div class="row">
              <div class="col-3">
                <label>Member ID</label>
                 <div class="form-group">
                   <div class="input-group">
                     <asp:TextBox ID="TextBox1" CssClass="form-control" runat="server" placeholder="ID"></asp:TextBox>
                    <asp:LinkButton ID="LinkButton4" class="btn btn-primary" runat="server" Text="Go" OnClick="LinkButton4_Click"></asp:LinkButton>
                   </div>
                 </div>
               </div>
              <div class="col-md-4">
                <label>Full Name</label>
                <div class="form-group">
                    <asp:TextBox ID="TextBox2" CssClass="form-control" runat="server" placeholder="Full Name" ReadOnly="True"></asp:TextBox>
                </div>
              </div>
              <div class="col-md-5">
                <label>Account Status</label>
                 <div class="form-group">
                   <div class="input-group">
                     <asp:TextBox ID="TextBox7" CssClass="form-control" runat="server" placeholder="Account Status" ReadOnly="True"></asp:TextBox>
                     <asp:LinkButton ID="LinkButton1" class="btn btn-success ms-1" runat="server" ><i class="fa-solid fa-circle-check" OnClick="LinkButton1_Click" ></i></asp:LinkButton>
                     <asp:LinkButton ID="LinkButton2" class="btn btn-warning ms-1" runat="server" ><i class="far fa-circle-pause" OnClick="LinkButton2_Click"></i></asp:LinkButton>
                     <asp:LinkButton ID="LinkButton3" class="btn btn-danger ms-1" runat="server" ><i class="fas fa-circle-xmark" OnClick="LinkButton3_Click"></i></asp:LinkButton>
                   </div>
                 </div>
               </div>
            </div>

            <div class="row">
              <div class="col-md-4">
                <label>DOB</label>
                <div class="form-group">
                    <asp:TextBox ID="TextBox10" CssClass="form-control" runat="server" placeholder="DOB" TextMode="Date" ReadOnly="true"></asp:TextBox>
                </div>
              </div>
              <div class="col-md-4">
                <label>Contact No</label>
                <div class="form-group">
                    <asp:TextBox ID="TextBox8" CssClass="form-control" runat="server" placeholder="Contact No" TextMode="Number" ReadOnly="true"></asp:TextBox>
                </div>
              </div>
              <div class="col-md-4">
                <label>Email Id</label>
                <div class="form-group">
                    <asp:TextBox ID="TextBox9" CssClass="form-control" runat="server" placeholder="Email Id" TextMode="Email" ReadOnly="true"></asp:TextBox>
                </div>
              </div>
              
            </div>

            <div class="row">
              <div class="col-md-4">
                <label>State</label>
                <div class="form-group">
                    <asp:TextBox ID="TextBox11" CssClass="form-control" runat="server" placeholder="State" ReadOnly="true"></asp:TextBox>
                </div>
              </div>
              <div class="col-md-4">
                <label>City</label>
                <div class="form-group">
                    <asp:TextBox ID="TextBox12" CssClass="form-control" runat="server" placeholder="City"  ReadOnly="true"></asp:TextBox>
                </div>
              </div>
              <div class="col-md-4">
                <label>Pincode</label>
                <div class="form-group">
                    <asp:TextBox ID="TextBox13" CssClass="form-control" runat="server" placeholder="Pincode"  ReadOnly="true"></asp:TextBox>
                </div>
              </div>
              
            </div>

           <div class="row">
              <div class="col-md-12">
                <label>Full Postal Address</label>
                <div class="form-group">
                    <asp:TextBox ID="TextBox6" CssClass="form-control" runat="server" placeholder="Full Postal Address" TextMode="Multiline" ReadOnly="True" Rows="2"></asp:TextBox>
                </div>
              </div>
            </div>
            
            <div class="row">
              <div class="col-8 mx-auto">
                 <div class="form-group">
                   <asp:Button ID="Button3" class="btn btn-danger btn-lg form-control" runat="server" Text="Delete User Permanently" />
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
                    <h4>Member List</h4>
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
                      SelectCommand="SELECT * FROM [member_master_tbl]"></asp:SqlDataSource>
                  <asp:GridView ID="GridView1" class="table table-striped table-bordered" 
                      runat="server" AutoGenerateColumns="False" DataKeyNames="member_id" 
                      DataSourceID="SqlDataSource1">
                      <Columns>
                          <asp:BoundField DataField="member_id" HeaderText="ID" ReadOnly="True" 
                              SortExpression="member_id" />
                          <asp:BoundField DataField="full_name" HeaderText="Name" 
                              SortExpression="full_name" />
                          <asp:BoundField DataField="account_status" HeaderText="Account Status" 
                              SortExpression="account_status" />
                          <asp:BoundField DataField="dob" HeaderText="DoB" 
                              SortExpression="dob" />
                          <asp:BoundField DataField="contact_no" HeaderText="Contact No" 
                              SortExpression="contact_no" />
                          <asp:BoundField DataField="email" HeaderText="Email ID" 
                              SortExpression="email" />
                          <asp:BoundField DataField="state" HeaderText="State" 
                              SortExpression="state" />
                          <asp:BoundField DataField="city" HeaderText="City" SortExpression="city" />
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
