<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="jatekos2.aspx.cs" Inherits="WebApplication2.jatekos1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
        </div>
        <asp:Label ID="penzlabel" runat="server" Text="Label"></asp:Label>
        <br />
        <asp:Label ID="tartozaslabel" runat="server" Text="Label"></asp:Label>
        <br />
        <asp:Button ID="tartozasfizetes" runat="server" OnClick="tartozasfizetes_Click" Text="Tartozás Kifizetése" />
        <asp:Button ID="tartozas20000" runat="server" Text="Tartozás: 20000 FT kifizetése" OnClick="tartozas20000_Click" />
        <asp:Label ID="tartozasnincselegpenz" runat="server" ForeColor="Red" Text="Nincs elég pénzed!"></asp:Label>
        <p>
            Egyéb összeg: <asp:TextBox ID="egyebtartozasfizetes" runat="server"></asp:TextBox>
            Ft
            <asp:Button ID="egyebosszegfizetesbtn" runat="server" OnClick="egyebosszegfizetesbtn_Click" Text="Fizetés" />
            <asp:Label ID="egyebosszegfizeteserror" runat="server" ForeColor="Red" Text="Kérjük Számot adjon meg!" Visible="False"></asp:Label>
        </p>
        <p>
            &nbsp;</p>
        <p>
            <asp:Button ID="hazvasarlasbtn" runat="server" BackColor="#006600" Height="93px" OnClick="hazvasarlasbtn_Click" Text="Ház vásárlása (300000 FT)" Width="1195px" />
&nbsp;&nbsp;&nbsp;
        </p>
        <asp:ImageButton ID="mososzobaimg" runat="server" Height="210px" ImageUrl="~/pics/mosokonyha.jpg" OnClick="mososzobaimg_Click" Width="400px" />
        <asp:ImageButton ID="szobabutorimg" runat="server" Height="210px" ImageUrl="~/pics/szobabutor.jpg" Width="400px" OnClick="szobabutorimg_Click" />
        <asp:ImageButton ID="radioimg" runat="server" Height="210px" ImageUrl="~/pics/radio.jpg" Width="200px" OnClick="radioimg_Click" />
        <asp:ImageButton ID="tvimg" runat="server" Height="210px" ImageUrl="~/pics/tv.jpg" Width="291px" OnClick="tvimg_Click" />
        <br />
        <asp:ImageButton ID="pinpongasztalimg" runat="server" Height="210px" ImageUrl="~/pics/pingpong.jpg" Width="400px" OnClick="pinpongasztalimg_Click" />
        <asp:ImageButton ID="konyhaimg" runat="server" Height="210px" ImageUrl="~/pics/konyha.jpg" Width="400px" OnClick="konyhaimg_Click" />
        <asp:ImageButton ID="hutoimg" runat="server" Height="210px" Width="142px" ImageUrl="~/pics/huto.jpg" OnClick="hutoimg_Click" />
        <asp:ImageButton ID="bicikliimg" runat="server" Height="210px" Width="182px" ImageUrl="~/pics/kerekpar.jpg" OnClick="bicikliimg_Click" style="margin-right: 35px" />
        <asp:ImageButton ID="porszivoimg" runat="server" Height="210px" Width="189px" ImageUrl="~/pics/porszivo.jpg" OnClick="porszivoimg_Click" style="margin-left: 0px" />
        <p>
            <asp:Label ID="eloszorvegyelhazat" runat="server" ForeColor="Red" Text="Először vegyél házat!"></asp:Label>
&nbsp;&nbsp;&nbsp;
            <asp:Label ID="nincselegpenzedhaz" runat="server" ForeColor="Red" Text="Nincs elég pénzed!" Visible="False"></asp:Label>
        </p>
        <p>
            &nbsp;</p>
        <asp:Button ID="plus20000" runat="server" Height="107px" OnClick="plus5000_Click" Text="+20000" Width="253px" />
        <asp:Button ID="minus5000" runat="server" Height="107px" OnClick="minus5000_Click" Text="-5000" Width="253px" />
        <asp:Label ID="nincselegpenzed" runat="server" ForeColor="Red" Text="Nincs elég pénzed!" Visible="False"></asp:Label>
        <br />
        <br />
        Összeg hozzáadása:
        <asp:TextBox ID="hozzaadastextbox" runat="server" Width="218px"></asp:TextBox>
        <asp:Button ID="hozzaadasbutton" runat="server" Height="52px" OnClick="hozzaadasbutton_Click" Text="Hozzáadás" Width="179px" />
        <asp:Label ID="szamotirjbe" runat="server" Text="Számot írj be!"></asp:Label>
        <br />
        Összeg levonása:
        <asp:TextBox ID="levonastextbox" runat="server"></asp:TextBox>
        <asp:Button ID="levonasbutton" runat="server" Height="49px" OnClick="levonasbutton_Click" Text="Levonás" Width="179px" />
    </form>
    <p>
        &nbsp;</p>
</body>
</html>
