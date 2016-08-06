using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace Thermas_Piratininga_2014_Responsivo
{
    public partial class Associado_Inicio : System.Web.UI.Page
    {
        Rotinas r = new Rotinas();
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!r.ValidarSession(this, "session_associado_serie"))
                    Response.Redirect("Default.aspx");

                if (!r.ValidarSession(this, "session_associado_titulo"))
                    Response.Redirect("Default.aspx");

                string serie = Session["session_associado_serie"].ToString();
                string titulo = Session["session_associado_titulo"].ToString();

                string sql = "SELECT T.TIT_NOME FROM TITULO AS T INNER JOIN SERIE AS S ON T.TIT_SER = S.ID WHERE T.TIT_NUM = '" + titulo + "' AND T.TIT_CLA = 1 AND S.SER_ABV = '" + serie + "'";
                DataTable dt = r.SelecionaBancoMYSQL(sql, "constr_MySQL_Thermas");
                if (dt.Rows.Count > 0)
                {
                    lblUsuario.Text = dt.Rows[0]["TIT_NOME"].ToString();
                }
            }
            catch (Exception er)
            {
                Response.Write(er.Message);
            }
        }


    }
}