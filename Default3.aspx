<%@ Page Language="C#" AutoEventWireup="true" EnableEventValidation="false"  CodeFile="Default3.aspx.cs" Inherits="Default3" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<%@ Register Assembly="System.Web.DataVisualization, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" Namespace="System.Web.UI.DataVisualization.Charting" TagPrefix="asp" %>


  


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

</head>
<body  runat="server"   >
  
    <form runat="server" timeout="2">     
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>

<!-- Sidebar/menu -->
<nav class=" w3-light-grey " style="z-index:0;width:280px;position:fixed"   id="mySidebar">
<hr/>
    <div class="w3-container w3-disaply-container ">
  

      <form action="/action_page.php" target="_blank">  

      <p><label><i class="fa fa-id-badge"></i> Ps. No</label></p>
      <asp:TextBox ID="txtno" class="w3-input w3-border" runat="server"  OnTextChanged="txtno_TextChanged" ReadOnly="true"></asp:TextBox>     
      <p><label><i class="fa fa-user-circle"></i> Name</label></p>
      <asp:TextBox ID="TextBox4"  runat="server"  class="w3-input w3-border" ReadOnly="true"></asp:TextBox>  
      <p><label><i class="fa fa-envelope"></i> E-mail</label></p> 
      <asp:TextBox ID="TextBox5"  runat="server" class="w3-input w3-border" ReadOnly="true"></asp:TextBox>
      <p><label><i class="fa fa-calendar-check-o"></i> Date</label></p>
      <asp:TextBox ID="TextBox1" autocomplete="off"  class="w3-input w3-border" runat="server" OnTextChanged="TextBox1_TextChanged" AutoPostBack="true" ></asp:TextBox>
      <ajaxToolkit:CalendarExtender ID="Calendar1" runat="server" PopupButtonID="imgPopup"  TargetControlID="TextBox1" Format="dd/MM/yyyy" />          


      <p><label><i class="fa fa-comments-o"></i> Conference Room</label></p>
      <asp:DropDownList class="w3-input w3-border" DatatextField="ConfRoom" DataValueField="Roomid" ID="DropDownList1" AppendDataBoundItems="true" runat="server"  AutoPostBack="true" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged">
      <asp:ListItem value="0">--Check Availability--</asp:ListItem> 
      </asp:DropDownList>   
    
    <p><label><i class="fa fa-fw fa-clock-o"></i>Check-In</label></p>       
    <asp:TextBox ID="TextBox2" class="w3-input w3-border"  runat="server" TextMode="Time" OnTextChanged="TextBox2_TextChanged"></asp:TextBox>
    <p><label><i class="fa fa-fw fa-clock-o"></i>Check-Out</label></p>  
    <asp:TextBox ID="TextBox3" class="w3-input w3-border"  TextMode="Time"  ValidationGroup="v1" runat="server" OnTextChanged="TextBox3_TextChanged"></asp:TextBox>    
<br />
<p>
<p><asp:button  runat="server" Text="Request" ID="rid"   Class="w3-button w3-block w3-green w3-left-justify " OnClick="rid_Click"></asp:button></p>  
<p><asp:button runat="server" Text="My Bookings"  class=" w3-button w3-block w3-blue w3-left-justify" OnClick="Unnamed_Click1" PostBackUrl="~/My Bookings.aspx" ></asp:button></p>
<p><asp:button runat="server" Text="Logout"  class=" w3-button w3-block  w3-left-justify" OnClick="Unnamed_Click"></asp:button></p>
</p>
</form>
 </div>
</nav>
<!-- Subscribe Modal -->
<div id="subscribe" class="w3-modal">
  <div class="w3-modal-content w3-animate-zoom w3-padding-large">
    <div class="w3-container w3-white w3-center">
     <i onclick="document.getElementById('subscribe').style.display='none'" class="fa fa-remove w3-button w3-xlarge w3-right w3-transparent"></i>
      <h2 class="w3-wide ">LTHE Onshore IT Helpdesk</h2>
      <p><i class="fa fa-phone"></i> : +0265 245 1355<br /> <i class="fa fa-envelope"></i> : OnshoreITHelpdesk@LARSENTOUBRO.com<br /></p>
      <p>Questions? Go ahead, ask them:</p>
      <p><input class="w3-input w3-border" type="text" placeholder="Name" required name="Name"></p>
      <p><input class="w3-input w3-border" type="text" placeholder="Email" required name="Email"></p>
      <p><input class="w3-input w3-border" type="text" placeholder="Message" required name="Message"></p>
       <button type="submit" class="w3-button w3-padding-large w3-green w3-margin-bottom ">Send a Message</button>
    </div>
  </div>
</div>
<!-- Top menu on small screens -->
       



  <!-- Slideshow Header -->
 <div class="w3-bar w3-top w3-white w3-card">
<a class="w3-text-blue w3-left w3-padding-large"  >Conference Room Booking Portal  </a>

</div>
            <div class="w3-card" style="margin-left:292px;margin-top:55px;position:fixed;width:1440px;margin-bottom:300%" runat="server" visible="true" id="rit" >

              <div  id="id1" runat="server"  visible="false" style="margin-left:250px;margin-right:135px;margin-top:50px;width:72.10%;height:100%">
              <img src="images\G1.jpg" >            
               <div class="w3-display-bottom w3-container  w3-black" style="width:86.70%">
              <p>G1</p>
              </div>
              </div>
             
         <div id="id2" runat="server"  visible="false" style="margin-left:250px;margin-right:135px;margin-top:50px;width:72.10%;height:100%">
              <img src="images\G2.jpg" >
              <div class="w3-display-bottom w3-container w3-black"  style="width:86.70%">
              <p>G2</p>
              </div>
              </div>

         <div id="id3" runat="server"  visible="false"  style="margin-left:250px;margin-right:135px;margin-top:50px;width:72.10%;height:100%">             
              <img src="images\G3.jpg" >
              <div class="w3-display-bottom w3-container w3-black" style="width:86.70%">
              <p>G3 : <i class="fa  fa-fw fa-wifi" ></i> <i1 class="fa  fa-fw fa-tv" ></i1> <i2 class="fa fa-skype" ></i2>           <i3 class="fa  fa-fw fa-male"></i3>: 8</p>
              </div>
              </div>
          
         <div id="id4" runat="server"  visible="false"  style="margin-left:250px;margin-right:135px;margin-top:50px;width:72.10%;height:100%">
              <img src="images\G4.jpg" >
              <div class="w3-display-bottom w3-container w3-black"  style="width:86.70%">
              <p>G4</p>
              </div>
              </div>
<p>

    
        <div style="text-align:center">
        <p style="font-size:155%;color:#204673;font-weight:bold"> Check Availability</p>                                                                      
        </div>  
		
       
<div  style="margin-top:2%;margin-left:22.5%;margin-bottom:1%"> 		
<asp:GridView ID="GridView1" runat="server" CellPadding="14" ForeColor="#333333" OnSelectedIndexChanged="GridView1_SelectedIndexChanged"  OnPageIndexChanging="GridView1_PageIndexChanging" OnRowDataBound="GridView1_RowDataBound"  Width="25%" >

</asp:GridView>	
</div>

</div>    


</form>
</body>
</html>
