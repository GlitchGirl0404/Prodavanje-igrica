<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="Developers.aspx.cs" Inherits="Prodavanje_igrica.Developers" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <%
        System.Data.DataSet ds = new System.Data.DataSet();
        ds = Prodavanje_igrica.Klasa.DeveloperSelect();
        Response.Write("<table>");
        for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
        {
            Response.Write("<tr>");
            Response.Write("<td>");
            Response.Write(ds.Tables[0].Rows[i]["naziv"]);
            Response.Write("</td>");
            Response.Write("<td>");
            Response.Write("<a href=" + ds.Tables[0].Rows[i]["site"] + ">Sajt</a>");
            Response.Write("</td>");
        }
        Response.Write("</table>");
    %>
    <br />
    <asp:Label ID="Label1" runat="server" Text="Naziv"></asp:Label>
    <asp:TextBox ID="naziv" runat="server"></asp:TextBox>
    <br />
    <asp:Label ID="Label2" runat="server" Text="Sajt"></asp:Label>
    <asp:TextBox ID="sajt" runat="server"></asp:TextBox>
    <br />
    <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Dodaj" />
</asp:Content>