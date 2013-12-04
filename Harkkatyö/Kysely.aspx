<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Kysely.aspx.cs" Inherits="Kysely" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <link rel="stylesheet" href="App_Themes/Theme1/StyleSheet.css"/>
    
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <h1>Lisää kysymys</h1>
    Kysymys: <asp:TextBox TextMode="MultiLine" width="300" Height="100" ID="kysymys" runat="server"></asp:TextBox>
    <br /><asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" 
            ControlToValidate="kysymys"/>

    Vastausten määrä: <asp:DropDownList id="maara" runat="server" OnSelectedIndexChanged="maara_SelectedIndexChanged" AutoPostBack="True" >
        <asp:ListItem>2</asp:ListItem>
        <asp:ListItem>3</asp:ListItem>
        <asp:ListItem>4</asp:ListItem>
        <asp:ListItem>5</asp:ListItem>
       
    </asp:DropDownList>

    Aika: <asp:DropDownList ID="aika" runat="server" AutoPostBack="true">
            <asp:ListItem Value="10">10 min</asp:ListItem>
            <asp:ListItem Value="30">30 min</asp:ListItem>
            <asp:ListItem Value="60">1 tunti</asp:ListItem>
            <asp:ListItem Value="120">2 tuntia</asp:ListItem>
          </asp:DropDownList>



    <asp:TextBox ID="vaiht1" runat="server"></asp:TextBox>
    <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server"
            ControlToValidate="vaiht1" 
            
            ValidationExpression="^[a-öA-Ö0-9]*$" />
    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
            ControlToValidate="vaiht1"/>
    


    <asp:TextBox ID="vaiht2" runat="server"></asp:TextBox>
    <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server"
            ControlToValidate="vaiht2" 
            
            ValidationExpression="^[a-öA-Ö0-9]*$" />
    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
            ControlToValidate="vaiht2"/>


    <asp:TextBox ID="vaiht3" runat="server" Visible="false"></asp:TextBox>
    <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server"
            ControlToValidate="vaiht3" 
            
            ValidationExpression="^[a-öA-Ö0-9]*$" />
    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" 
            ControlToValidate="vaiht3"/>

    <asp:TextBox ID="vaiht4" runat="server" Visible="false"></asp:TextBox>
    <asp:RegularExpressionValidator ID="RegularExpressionValidator4" runat="server"
            ControlToValidate="vaiht4" 
            
            ValidationExpression="^[a-öA-Ö0-9]*$" />
    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" 
            ControlToValidate="vaiht4"/>

    <asp:TextBox ID="vaiht5" runat="server" Visible="false"></asp:TextBox>
    <asp:RegularExpressionValidator ID="RegularExpressionValidator5" runat="server"
            ControlToValidate="vaiht5" 
            
            ValidationExpression="^[a-öA-Ö0-9]*$" />
    <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" 
            ControlToValidate="vaiht5"/>
    
    <asp:Button ID="submit" runat="server" Text="Lisää" CssClass="button" OnClick="submit_Click" />
    <asp:Button ID="Vastaamaan" runat="server" Text="Vastaamaan"  CssClass="button"  OnClick="Vastaamaan_Click" CausesValidation="false" /><br />

    <asp:Label ID="lis" runat="server"></asp:Label>
</asp:Content>


