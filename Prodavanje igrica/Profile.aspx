<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="Profile.aspx.cs" Inherits="Prodavanje_igrica.Profile" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div style = "width:100%">
        <div style = "width:30%; float:left">
            <%
                System.Data.DataSet ds = new System.Data.DataSet();
                ds = Prodavanje_igrica.Klasa.ClanSelect(Session["korisnik"].ToString());
                Response.Write("<table>");
                Response.Write("<tr>");
                Response.Write("<td>");
                Response.Write("Username: ");
                Response.Write("</td>");
                Response.Write("<td>");
                Response.Write(ds.Tables[0].Rows[0]["username"]);
                Response.Write("</td>");
                Response.Write("</tr>");
                Response.Write("<tr>");
                Response.Write("<td>");
                Response.Write("Password: ");
                Response.Write("</td>");
                Response.Write("<td>");
                Response.Write(ds.Tables[0].Rows[0]["pasvord"]);
                Response.Write("</td>");
                Response.Write("</tr>");
                Response.Write("<tr>");
                Response.Write("<td>");
                Response.Write("Datum uclanjenja: ");
                Response.Write("</td>");
                Response.Write("<td>");
                Response.Write(ds.Tables[0].Rows[0]["datum_uclanjenja"]);
                Response.Write("</td>");
                Response.Write("</tr>");
                Response.Write("<tr>");
                Response.Write("<td>");
                Response.Write("Novac:");
                Response.Write("</td>");
                Response.Write("<td>");
                Response.Write(ds.Tables[0].Rows[0]["novac"]);
                Response.Write("</td>");
                Response.Write("</tr>");
                Response.Write("</table>");
            %>
            <asp:Label ID="Label1" runat="server" Text="Dodaj novac"></asp:Label>
            <asp:TextBox ID="novac" runat="server"></asp:TextBox>
            <br />
            <asp:Button ID="Button1" runat="server" Text="Dodaj" OnClick="Button1_Click" />
        </div>
        <div style = "width:70%; float:left">
            <%
                ds = new System.Data.DataSet();
                ds = Prodavanje_igrica.Klasa.IgriceClana(Session["korisnik"].ToString());
                Response.Write("<table>");
                Response.Write("<tr>");
                Response.Write("<td>");
                Response.Write("Naziv");
                Response.Write("</td>");
                Response.Write("<td>");
                Response.Write("Datum izlaska");
                Response.Write("</td>");
                Response.Write("<td>");
                Response.Write("Developer");
                Response.Write("</td>");
                Response.Write("<td>");
                Response.Write("Sistem");
                Response.Write("</td>");
                Response.Write("<td>");
                Response.Write("Zanr");
                Response.Write("</td>");
                Response.Write("</tr>");
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    Response.Write("<tr>");
                    Response.Write("<td>");
                    Response.Write(ds.Tables[0].Rows[i]["naziv"]);
                    Response.Write("</td>");
                    Response.Write("<td>");
                    Response.Write(ds.Tables[0].Rows[i]["datum_izlaska"]);
                    Response.Write("</td>");
                    Response.Write("<td>");
                    Response.Write(ds.Tables[0].Rows[i]["developer"]);
                    Response.Write("</td>");
                    Response.Write("<td>");
                    Response.Write(ds.Tables[0].Rows[i]["sistem"]);
                    Response.Write("</td>");
                    Response.Write("<td>");
                    Response.Write(ds.Tables[0].Rows[i]["zanr"]);
                    Response.Write("</td>");
                    Response.Write("<td>");
                    Response.Write("<a href=Profile.aspx?game=" + ds.Tables[0].Rows[i]["igrica_id"] + "&rel=da>Delete</a>");
                    Response.Write("</td>");
                    Response.Write("<tr>");
                }
                Response.Write("</table>");
            %>
        </div>
    </div>
</asp:Content>