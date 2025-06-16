using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
namespace Prodavanje_igrica
{
    public partial class Zanr : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void Button1_Click(object sender, EventArgs e)
        {
            int rezultat;
            rezultat = Klasa.ZanrInsert(naziv.Text);
            if (rezultat == 0)
            {
                Response.Redirect("Zanr.aspx");
            }
            else
            {
                Response.Redirect("Greska.aspx");
            }
        }
    }
}