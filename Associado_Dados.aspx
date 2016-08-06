<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPageCliente.master" AutoEventWireup="true" CodeBehind="Associado_Dados.aspx.cs" Inherits="Thermas_Piratininga_2014_Responsivo.Associado_Dados" %>

<asp:Content ID="Content1" ContentPlaceHolderID="conteudo_area_cliente" runat="server">
<script type="text/javascript" src="http://code.jquery.com/jquery-1.11.1.min.js"></script>
    <script type="text/javascript" src="lightbox_fresco/js/fresco/fresco.js"></script>
    <link rel="stylesheet" type="text/css" href="lightbox_fresco/css/fresco/fresco.css" />
    <style type="text/css">
        .css img
        {
            float: left;
            width: 250;
            height: 200;
            padding: 5px;
            margin: 0px 10px 10px 0;
        }
    </style>



    <div align="center">
        <table width="95%" align="center">
            <tr>
                <td>
                    <p>
                        <div class="titulo">
                            
                        </div>
                    </p>
                    <p style="text-align: justify; font-size: medium; line-height: 30px;">
                    <b>Dados do Título:&nbsp;<asp:Label runat="server" ID="lblTitulo"></asp:Label></b><br />
                        <asp:Label runat="server" ID="lblDados"></asp:Label>
                    </p>
                </td>
            </tr>
            <tr>
                <td style="text-align: justify; font-size: small;">
                    <asp:GridView runat="server" ID="gvDadosCadastrais" BorderColor="White" ForeColor="Black"
                        Width="100%">
                        <AlternatingRowStyle BackColor="#ADD8E6" />
                        <HeaderStyle BackColor="#5166ED" BorderColor="White" BorderStyle="None" />
                    </asp:GridView>
                </td>
            </tr>
            <tr>
            <td align="center">
                <asp:Label runat="server" ID="lblFotos"></asp:Label>
            </td>
            </tr>
            <tr>
                <td align="left">
                    <p style="text-align: justify; font-size: small; line-height: 30px;">
                        <a href="mailto:contato@thermasdepiratininga.com.br">Informe alteração de cadastro via
                            E-mail</a>.
                    </p>
                </td>
            </tr>
            <tr>
                <td>
                    &nbsp;
                </td>
            </tr>
            <tr>
                <td>
                    <b>Convidados do mês</b>
                </td>
            </tr>
            <tr>
                <td style="text-align: justify; font-size: small;">
                    <asp:GridView runat="server" ID="gvConvidados" BorderColor="White" ForeColor="Black"
                        Width="100%">
                        <AlternatingRowStyle BackColor="#ADD8E6" />
                        <HeaderStyle BackColor="#5166ED" BorderColor="White" BorderStyle="None" />
                    </asp:GridView>
                    <asp:Label runat="server" ID="lblConvidados"></asp:Label>
                </td>
            </tr>
        </table>
    </div>


</asp:Content>
