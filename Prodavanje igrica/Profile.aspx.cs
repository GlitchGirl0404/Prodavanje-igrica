using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
namespace Prodavanje_igrica
{
    public partial class Profile : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void Button1_Click(object sender, EventArgs e)
        {
            int rezultat;
            rezultat = Klasa.DodajNovac(Session["korisnik"].ToString(), int.Parse(novac.Text));
            if (rezultat == 0)
            {
                Response.Redirect("Profile.aspx");
            }
            else
            {
                Response.Redirect("greska.aspx");
            }
        }
    }
}