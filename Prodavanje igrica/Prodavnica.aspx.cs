using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
namespace Prodavanje_igrica
{
    public partial class Prodavnica : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string clan = Session["korisnik"].ToString();
            int igrica = Convert.ToInt32(Request.QueryString["game"]);
            int rezultat;
            rezultat = Klasa.InsertClanIgrica(clan, igrica);
            string rel = Request.QueryString["rel"];
            if (rel == "da")
            {
                Response.Redirect("Prodavnica.aspx");
            }
        }
        protected void Button1_Click(object sender, EventArgs e)
        {
            int rezultat;
            rezultat = Klasa.IgricaInsert(naziv.Text, datum.SelectedDate, developer.Text, sistem.Text, zanr.Text);
            if (rezultat == 0)
            {
                Response.Redirect("Prodavnica.aspx");
            }
            else
            {
                Response.Redirect("Greska.aspx");
            }
        }
    }
}