<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPrincipal.Master" AutoEventWireup="true"
    CodeBehind="Associado_Login.aspx.cs" Inherits="Thermas_Piratininga_2014_Responsivo.Associado_Login" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="conteudo" runat="server">
    <div class="container">
        <h2 class="form-signin-heading" style="text-align: center;">
            Por favor, faça o Login</h2>
        <p style="text-align: justify;">
            Pensando em seu maior conforto, o Thermas criou uma área exclusiva para seus associados.
            Uma ferramenta que permite ver a situação do seu título, planos cadastrados, boletos
            pagos, dependentes cadastrados, entre outras funcionalidades.</p>
        <p style="text-align: justify;">
            Caso ainda não possua senha de acesso, <a href="mailto:contato@thermasdepiratininga.com.br?subject=Solicitação de senha para área do associado">
                <b>envie um e-mail para contato@thermasdepiratininga.com.br</b></a> com os dados
            do titular: <b>Nome completo, CPF, RG, celular, e-mail, série e número do título</b>.</p>

            <asp:DropDownList runat="server" ID="ddlSerie" class="form-control"></asp:DropDownList>

            <asp:TextBox ID="txtTitulo" runat="server" class="form-control" placeholder="Título"
            required autofocus></asp:TextBox>

            <asp:TextBox ID="txtSenha" runat="server" TextMode="Password" placeholder="Senha" class="form-control" required></asp:TextBox>
        <hr />
        <asp:Button ID="btnAutenticar" runat="server" Text="Entrar" OnClick="btnAutenticar_Click" class="btn btn-lg btn-primary btn-block" />

        <asp:Label runat="server" Text="" ID="lblErro" ForeColor="Red"></asp:Label>
    </div>
</asp:Content>
