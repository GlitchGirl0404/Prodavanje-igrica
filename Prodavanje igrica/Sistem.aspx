<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="Sistem.aspx.cs" Inherits="Prodavanje_igrica.Sistem" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <%
        System.Data.DataSet ds = new System.Data.DataSet();
        ds = Prodavanje_igrica.Klasa.SistemSelect();
        Response.Write("<table>");
        for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
        {
            Response.Write("<tr>");
            Response.Write("<td>");
            Response.Write(ds.Tables[0].Rows[i]["naziv"]);
            Response.Write("</td>");
        }
        Response.Write("</table>");
    %>
<br />
<asp:Label ID="Label1" runat="server" Text="Naziv"></asp:Label>
<asp:TextBox ID="naziv" runat="server"></asp:TextBox>
<br />
<asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Dodaj" />
</asp:Content>