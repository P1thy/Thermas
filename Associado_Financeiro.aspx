<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPageCliente.master" AutoEventWireup="true" CodeBehind="Associado_Financeiro.aspx.cs" Inherits="Thermas_Piratininga_2014_Responsivo.Associado_Financeiro" %>
<asp:Content ID="Content1" ContentPlaceHolderID="conteudo_area_cliente" runat="server">
<table width="95%" align="center">
            <tr>
                <td>
                    <p>
                        <div class="titulo">
                            Título:
                            <asp:Label runat="server" ID="lblTitulo"></asp:Label>
                        </div>
                    </p>
                    <p style="text-align: justify; font-size: medium; line-height: 30px;">
                        <asp:Label runat="server" ID="lblDados"></asp:Label>
                    </p>
                </td>
            </tr>
            <tr>
                <td>
                    <b>Plano Cadastrados</b>
                </td>
            </tr>
            <tr>
                <td style="text-align: justify; font-size: small;">
                    <asp:GridView runat="server" ID="gvPlanos" BorderColor="White" ForeColor="Black"
                        Width="100%">
                        <AlternatingRowStyle BackColor="#ADD8E6" />
                        <HeaderStyle BackColor="#5166ED" BorderColor="White" BorderStyle="None" />
                    </asp:GridView>
                    <asp:Label runat="server" ID="lblPlanos"></asp:Label>
                </td>
            </tr>
            <tr>
                <td>
                    &nbsp;
                </td>
            </tr>
            <tr>
                <td>
                    <b>Financeiro</b>
                </td>
            </tr>
            <tr>
                <td style="text-align: justify; font-size: small;">
                    <asp:GridView runat="server" ID="gvFinanceiro" BorderColor="White" ForeColor="Black"
                        Width="100%">
                        <AlternatingRowStyle BackColor="#ADD8E6" />
                        <HeaderStyle BackColor="#5166ED" BorderColor="White" BorderStyle="None" />
                    </asp:GridView>
                    <asp:Label runat="server" ID="lblFinanceiro"></asp:Label>
                </td>
            </tr>
        </table>


</asp:Content>
