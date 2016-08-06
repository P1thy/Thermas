using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace Thermas_Piratininga_2014_Responsivo
{
    public partial class Associado_Login : System.Web.UI.Page
    {
        Rotinas r = new Rotinas();
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (r.ValidarSession(this, "session_associado_serie"))
                    Response.Redirect("Associado_Inicio.aspx");

                if (r.ValidarSession(this, "session_associado_titulo"))
                    Response.Redirect("Associado_Inicio.aspx");

                if (!IsPostBack)
                {
                    string sql = "SELECT id, ser_abv FROM SERIE order by ser_abv";
                    DataTable dt = r.SelecionaBancoMYSQL(sql, "constr_MySQL_Thermas");
                    if (dt.Rows.Count > 0)
                    {
                        ddlSerie.DataSource = dt;
                        ddlSerie.DataTextField = "ser_abv";
                        ddlSerie.DataValueField = "ser_abv";
                        ddlSerie.DataBind();
                    }
                }
            }
            catch (Exception er)
            {
                Response.Write(er.Message);
            }
        }

        protected void btnAutenticar_Click(object sender, EventArgs e)
        {
            try
            {
                lblErro.Text = string.Empty;
                string titulo = txtTitulo.Text.ToLower();
                string serie = ddlSerie.SelectedValue.ToString();
                string senha = txtSenha.Text;

                if (r.TemSQLInjection(titulo))
                {
                    lblErro.Text = "Dados incorretos!";
                    return;
                }


                if (r.TemSQLInjection(senha))
                {
                    lblErro.Text = "Dados incorretos!";
                    return;
                }

                string sql = "SELECT id_acesso FROM associado_acesso WHERE ACESSO_SERIE = '" + serie + "' AND ACESSO_TITULO = '" + titulo + "' AND ACESSO_SENHA = '" + senha + "'";
                DataTable dt = r.SelecionaBancoMYSQL(sql, "constr_MySQL_Thermas");

                if (dt.Rows.Count == 1)
                {
                    Session["session_associado_serie"] = serie;
                    Session["session_associado_titulo"] = titulo;
                    Response.Redirect("Associado_Inicio.aspx");
                }
                else
                {
                    lblErro.Text = "Usuário e/ou senha inválidos.";
                }
            }
            catch (Exception er)
            {
                lblErro.Text = "Erro: " + er.ToString();
            }
        }
    }
}