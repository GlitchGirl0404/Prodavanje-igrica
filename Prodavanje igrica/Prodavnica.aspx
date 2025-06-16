<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="Prodavnica.aspx.cs" Inherits="Prodavanje_igrica.Prodavnica" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div style = "width:100%">
        <%
            System.Data.DataSet ds = new System.Data.DataSet();
            ds = Prodavanje_igrica.Klasa.IgriceKojeClanNema(Session["korisnik"].ToString());
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
                Response.Write("<a href=Prodavnica.aspx?game=" + ds.Tables[0].Rows[i]["igrica_id"] + "&rel=da>Kupi</a>");
                Response.Write("</td>");
                Response.Write("<tr>");
            }
            Response.Write("</table>");
        %>
        <br />
        <asp:Label ID="Label1" runat="server" Text="Naziv"></asp:Label>
        <asp:TextBox ID="naziv" runat="server"></asp:TextBox>
        <br />
        <asp:Label ID="Label2" runat="server" Text="Datum"></asp:Label>
        <asp:Calendar ID="datum" runat="server"></asp:Calendar>
        <br />
        <asp:Label ID="Label3" runat="server" Text="Developer"></asp:Label>
        <asp:DropDownList ID="developer" runat="server" DataSourceID="SqlDataSource1" DataTextField="naziv" DataValueField="naziv">
        </asp:DropDownList>
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:ProdavanjeIgrica %>" SelectCommand="SELECT [naziv] FROM [Developer]"></asp:SqlDataSource>
        <br />
        <asp:Label ID="Label4" runat="server" Text="System"></asp:Label>
        <asp:DropDownList ID="sistem" runat="server" DataSourceID="SqlDataSource2" DataTextField="naziv" DataValueField="naziv">
        </asp:DropDownList>
        <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:ProdavanjeIgrica %>" SelectCommand="SELECT [naziv] FROM [Sistem]"></asp:SqlDataSource>
        <br />
        <asp:Label ID="Label5" runat="server" Text="Zanr"></asp:Label>
        <asp:DropDownList ID="zanr" runat="server" DataSourceID="SqlDataSource3" DataTextField="naziv" DataValueField="naziv">
        </asp:DropDownList>
        <asp:SqlDataSource ID="SqlDataSource3" runat="server" ConnectionString="<%$ ConnectionStrings:ProdavanjeIgrica %>" SelectCommand="SELECT [naziv] FROM [Zanr]"></asp:SqlDataSource>
        <br />
        <asp:Button ID="Button1" runat="server" Text="Dodaj" OnClick="Button1_Click" />
        <br />
    </div>
</asp:Content>