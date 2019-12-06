 <%@ Page Language="C#" AutoEventWireup="true" CodeFile="Checkin_out.aspx.cs" Inherits="Checkin_out" %>


<!DOCTYPE html>
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
<script src="https://ajax.aspnetcdn.com/ajax/jQuery/jquery-3.4.1.min.js"></script>
<script type="text/javascript"  lang="Javascript">
     function DisableBackButton() {
       window.history.forward()
      }
     DisableBackButton();
     window.onload = DisableBackButton;
     window.onpageshow = function(evt) { if (evt.persisted) DisableBackButton() }
     window.onunload = function () { void (0) }

     
     function checkInJs(url) {
        
           
         
             var xmlHttp = new XMLHttpRequest();
             xmlHttp.open("GET", url, false); // false for synchronous request
             xmlHttp.send(null);       
             alert = alert("You have successfully checked In");
             return xmlHttp.responseText;
        
     }

     function checkOutJs(urlo) {



         var xmlHttp = new XMLHttpRequest();
         xmlHttp.open("GET", urlo, false); // false for synchronous request
         xmlHttp.send(null);
         alert = alert("You have successfully checked Out");
         return xmlHttp.responseText;

     }


 </script>

     
          
</head>
<body  runat="server">
<form runat="server">     
<asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>

 <asp:UpdatePanel runat="server"  >       
 <ContentTemplate>
             
<!-- Slideshow Header -->
<div class="w3-bar w3-top w3-white w3-card">
<a class="w3-text-blue w3-left w3-padding-large"  >Conference Room Booking Portal  </a>
</div>

</ContentTemplate>
</asp:UpdatePanel>


<!-- CheckIn-Out-->
 <div class="w3-card" style="margin-left:287px;margin-top:3%;position:fixed;width:1448px;height:93.5%" runat="server" visible="true" id="rit" >
<div class="w3-full" >
<p><a class="w3-text-red w3-padding" style="align-content:center;font-size:medium"  >Check-In | Check-Out</a></p>
</div>
<div  class="w3-center"  style="margin-right:33px;margin-top:5%;margin-bottom:3%">
<asp:button  runat="server" Text="Check-In"   class="w3-bar-item w3-button w3-green  w3-border "  Width="26%" ID="Check_In"  OnClick="Check_In_Click"></asp:button>
<asp:button  runat="server" Text="Check-Out"  class="w3-bar-item w3-button w3-green  w3-border"  Width="26%"  ID="Check_Out"   OnClick="Check_Out_Click" ></asp:button> 
</div>

<div  class="w3-middle" style="margin-top:2%;margin-bottom:5%;margin-left:12%" >	
<asp:GridView ID="GridView1" runat="server"  AutoPostback="False" CellPadding="4"  AllowPaging="True" PageSize="8" BackColor="White" BorderColor="#3366CC" GridLines="Both"  AutoGenerateColumns="False" DataKeyNames="eid" >
<Columns>
<asp:TemplateField HeaderText="Select Request">
     <ItemTemplate>
     <asp:CheckBox ID="CheckBox1"  runat="server"  onclick="checkbox()"  HeaderText="Select"  />
     </ItemTemplate>
     </asp:TemplateField>
                       <asp:BoundField DataField="eid" HeaderText="Sr No"  SortExpression="Sr No" />
                       <asp:BoundField DataField="PsNo" HeaderText="Ps. No" SortExpression="Ps. No" />
                       <asp:BoundField DataField="Name" HeaderText="Employee Name" SortExpression="Employee Name" />                   
                       <asp:BoundField DataField="date" HeaderText="Date" SortExpression="Date" />
                       <asp:BoundField DataField="confroom" HeaderText="Conferrence Room" SortExpression="Conferrence Room" />
                       <asp:BoundField DataField="Checkin" HeaderText="Check-In" SortExpression="Check-In" />
                       <asp:BoundField DataField="Checkout" HeaderText="Check-Out" SortExpression="Check-Out" />
                       <asp:BoundField DataField="Status" HeaderText="Status" SortExpression="Status" />  
                       <asp:BoundField DataField="uc" HeaderText="Check-In Time" SortExpression="Check-In Time" />
                       <asp:BoundField DataField="uo" HeaderText="Check-Out Time" SortExpression="Check-Out Time" />
</Columns>  
</asp:GridView>	
</div>
<div  class="w3-center"  style="margin-left:145px;margin-top:36.5%;margin-bottom:2%">
<div  class="w3-row-padding" ><p style="color:black" class="w3-right"  >© 2019. All Rights Reserved | Design by: Under Internship in LTHE Onshore IT, Baroda</p></div>          
</div>
</div>



<!-- Sidebar/menu -->
<nav class=" w3-light-grey " style="z-index:0;width:280px; left: 0px;position:fixed" id="mySidebar">  
<hr />
       
<div class="w3-container w3-disaply-container" >
      <p><label><i class="fa fa-id-badge"></i> Ps. No</label></p>
      <asp:TextBox ID="txtno" class="w3-input w3-border" runat="server"   ReadOnly="true"></asp:TextBox>     
      <p><label><i class="fa fa-user-circle"></i> Name</label></p>
      <asp:TextBox ID="TextBox4"  runat="server"  class="w3-input w3-border" ReadOnly="true"></asp:TextBox>  
      <p><label><i class="fa fa-envelope"></i> E-mail</label></p> 
      <asp:TextBox ID="TextBox5"  runat="server" class="w3-input w3-border" ReadOnly="true"></asp:TextBox>
<br />
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


<p>
<p><asp:button  runat="server" Text="Home" ID="rid"   Class="w3-button w3-block w3-green w3-left-justify"  OnClick="rid_Click"></asp:button></p>  
<p><asp:button runat="server" Text="My Bookings"  class=" w3-button w3-block w3-blue w3-left-justify" OnClick="Unnamed_Click1"  ></asp:button></p>
<p><asp:button runat="server" Text="Logout"  class=" w3-button w3-block  w3-left-justify" OnClick="Unnamed_Click" ></asp:button></p>
</p> 
    <hr />
</div>  
</nav>

</form>
</body>
</html>
