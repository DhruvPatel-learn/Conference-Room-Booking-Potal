<%@ Page Language="C#" AutoEventWireup="true"  EnableEventValidation="false"  CodeFile="useradmin.aspx.cs" Inherits="useradmin" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<%@ Register Assembly="System.Web.DataVisualization, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" Namespace="System.Web.UI.DataVisualization.Charting" TagPrefix="drdo" %>



  
<!DOCTYPE html>
<script runat="server">

  
</script>


<html>
<head runat="server">
<title>CRB Portal</title>
<meta charset="UTF-8">
<meta name="viewport" content="width=device-width, initial-scale=1">
<link rel="stylesheet" href="https://www.w3schools.com/w3css/4/w3.css">
<link rel="stylesheet" href="https://fonts.googleapis.com/css?family=Raleway">
<link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/4.7.0/css/font-awesome.min.css">

<style>
body,h1,h2,h3,h4,h5,h6 {font-family: "Raleway", Arial, Helvetica, sans-serif}
.mySlides {display: none}
</style>
<script type="text/javascript"  lang="Javascript">
     function DisableBackButton() {
       window.history.forward()
      }
     DisableBackButton();
     window.onload = DisableBackButton;
     window.onpageshow = function(evt) { if (evt.persisted) DisableBackButton() }
     window.onunload = function() { void (0) }
 </script>
</head>

<body  runat="server">
<form runat="server" >     
<asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>

<asp:UpdatePanel runat="server">
<ContentTemplate>

<!-- Slideshow Header -->
<div class="w3-bar w3-top w3-white w3-card">
<a class="w3-text-blue w3-left w3-padding-large">Conference Room Booking Portal  </a>
</div>            
</ContentTemplate>
</asp:UpdatePanel>



<!----Request Approval--->
 <div class="w3-card" style="margin-left:287px;margin-top:3%;position:fixed;width:1448px;height:93.5%" runat="server" visible="true" id="rit" >
<br />
<div class="w3-full"  >
<a class="w3-text-red w3-padding" style="align-content:center;font-size:medium"  >Booking Request Management</a>
<div  class="w3-center"  style="margin-left:20px;margin-top:5%">
<asp:button  runat="server" Text="Approve"  Id="Approve_Request" style="margin-left:15px"  class="w3-bar-item w3-button w3-green  w3-border "  Width="30.33%" OnClick="Approve_Request_Click" ></asp:button>
<asp:button  runat="server" Text="Reject" Id="Reject_Reject" style="margin-right:95px" class="w3-bar-item w3-button w3-green  w3-border"  Width="30.33%"  OnClick="Reject_Reject_Click" ></asp:button> 
</div>
</div> 
<div  class="w3-middle" style="margin-left:145px;margin-top:3%;position:fixed">

      <asp:GridView ID="GridView1" runat="server" AutoPostback="False" AutoGenerateColumns="False"  BackColor="White" BorderColor="#3366CC" BorderStyle="None" BorderWidth="1px" CellPadding="4"  DataKeyNames="eid" OnSelectedIndexChanged="GridView1_SelectedIndexChanged" OnPageIndexChanging="GridView1_PageIndexChanging" AllowPaging="True" PageSize="10" >   
     <Columns>
     <asp:TemplateField HeaderText="Select Request">
     <ItemTemplate>
     <asp:CheckBox ID="CheckBox1" runat="server"  HeaderText="Select" />
     </ItemTemplate>
     </asp:TemplateField>
                       <asp:BoundField DataField="eid" HeaderText="Sr No"  SortExpression="Sr No" />
                       <asp:BoundField DataField="PsNo" HeaderText="Ps. No" SortExpression="Ps. No" />
                       <asp:BoundField DataField="Name" HeaderText="Employee Name" SortExpression="Employee Name" />
                       <asp:BoundField DataField="email" HeaderText="E-mail" SortExpression="E-mail" />
                       <asp:BoundField DataField="date" HeaderText="Date" SortExpression="Date" />
                       <asp:BoundField DataField="confroom" HeaderText="Conferrence Room" SortExpression="Conferrence Room" />
                       <asp:BoundField DataField="Checkin" HeaderText="Check-In" SortExpression="Check-In" />
                       <asp:BoundField DataField="Checkout" HeaderText="Check-Out" SortExpression="Check-Out" />
                       <asp:BoundField DataField="Status" HeaderText="Status" SortExpression="Status" />
                      
    </Columns>   
    </asp:GridView>

  
<div id="zoom" style="margin-top:20%" >
<asp:Label ID="Label1" runat="server" Visible="false" >
<a class="w3-text-red w3-padding" style="margin-left:25%;font-size:medium"  >Note*: Reject by stating valid reason and click "Submit" button!</a>
</asp:Label>
</div>
<asp:TextBox Visible="false" ID="txtComment" style="margin-left:16.5%;margin-right:130px" Class="w3-center" runat="server" Height="150px" Width="67%" TextMode="MultiLine" ></asp:TextBox>
<br/>  
<asp:button Visible="false" runat="server" Text="Submit" style="margin-right:95px;margin-left:16.5%;margin-top:2px;margin-bottom:5%" class="w3-bar-item w3-button w3-yellow  w3-border"  Width="67%"  ID="submit" OnClick="submit_Click"></asp:button> 
</div>
 <div  class="w3-center"  style="margin-left:145px;margin-top:43.5%;margin-bottom:2%">

    <div  class="w3-row-padding" ><p style="color:black" class="w3-right"  >© 2019. All Rights Reserved | Design by: Under Internship in LTHE Onshore IT, Baroda</p></div>          
     </div>  	
</div>


<!-- Sidebar/menu -->    
<nav class=" w3-light-grey " style="z-index:0;width:280px; left: 0px;position:fixed" id="mySidebar">  

<hr />
<div class="w3-container w3-disaply-container ">

      <p><label><i class="fa fa-id-badge"></i> Ps. No</label></p>
      <asp:TextBox ID="psno" class="w3-input w3-border" runat="server" ReadOnly="true" ValidateRequestMode="Disabled"  OnTextChanged="psno_TextChanged"  ></asp:TextBox>     
      <p><label><i class="fa fa-user-circle"></i> Name</label></p>
      <asp:TextBox ID="TextBox4"  runat="server"  class="w3-input w3-border" ReadOnly="true" ></asp:TextBox>  
      <p><label><i class="fa fa-envelope"></i> E-mail</label></p> 
      <asp:TextBox ID="TextBox5"  runat="server" class="w3-input w3-border"  ReadOnly="true" ></asp:TextBox>
 <br/>    
<hr />
<hr />
<hr />
<hr />
<hr />
<hr />
<hr />
<hr />
<hr />
<hr />
<hr />
<hr />
<hr />
<hr />
<hr />
<hr />
<hr />
<hr />
<hr />
<hr />
<p><asp:button runat="server" Text="Home" Id="Home" class=" w3-button w3-block w3-green w3-left-justify"  OnClick="Home_Click"  ></asp:button></p>
<p><asp:button runat="server" Text="Logout" Id="Logout" class=" w3-button w3-block  w3-left-justify"  OnClick="Logout_Click"></asp:button></p>


<hr/>
</div>   
</nav>
          
</form>
</body>
</html>
