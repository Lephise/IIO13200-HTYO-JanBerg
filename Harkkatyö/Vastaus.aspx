<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Vastaus.aspx.cs" Inherits="Vastaus" %>

<%@ Register Assembly="System.Web.DataVisualization, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" Namespace="System.Web.UI.DataVisualization.Charting" TagPrefix="asp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <link rel="stylesheet" href="App_Themes/Theme1/StyleSheet.css"/>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server"><br />
    <asp:Label ID="label" runat="server"></asp:Label>
  
    <asp:Chart ID="pie" CssClass="pie" runat="server" Visible="false">
                <Series>
                    <asp:Series Name="Testing" YValueType="Int32" ChartType="Pie">

			        <Points>
				

			        </Points>
		        </asp:Series>
                </Series>
                <ChartAreas>
                    <asp:ChartArea Name="ChartArea1"></asp:ChartArea>
                </ChartAreas>
            </asp:Chart>
        

    <asp:RadioButtonList ID="buttoset" runat="server" CssClass="radio"></asp:RadioButtonList>


    



    <asp:Button ID="btn" runat="server" OnClick="btn_Click" CssClass="button" Text="Vastaa" /> <br />
    <asp:Button ID="btnPre" runat="server" Text="Edellinen" CssClass="button"  OnClick="btnPre_Click"/>
    <asp:Button ID="btnNext" runat="server" Text="Seuraava"  CssClass="button" OnClick="btnNext_Click"/> 
    <br />
    <asp:Button ID="btnNew" runat="server" Text="Luo Kysely"  CssClass="button" OnClick="btnNew_Click"/>
    <asp:Button ID="btnShow" runat="server" Text="Näytä tulokset" CssClass="button" OnClick="btnShow_Click"/>
    <asp:Label ID="vastmaara" runat="server"></asp:Label>
    <asp:Label ID="derp" runat="server"></asp:Label>
    
    
 
    

    
    
</asp:Content>

