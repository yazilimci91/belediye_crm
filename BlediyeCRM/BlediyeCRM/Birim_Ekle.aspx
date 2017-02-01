﻿<%@ Page Title="" Language="C#" MasterPageFile="~/MASTER.Master" AutoEventWireup="true" CodeBehind="Birim_Ekle.aspx.cs" Inherits="BlediyeCRM.pages.Birim_Ekle" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">



    <div class="row">
        <div class="col-md-12">
            <div class="card">
                <div class="card-header">
                    <div class="btn btn-primary">
                        <i class="fa fa-mail-reply"></i>
                        <a href="BirimleriGoruntule.aspx?BELEDIYE_ID=<%=Convert.ToInt32(Request.QueryString["BELEDIYE_ID"]) %>" style="color: white">Geri Dön  </a>
                    </div>
                </div>
                <div class="card-header">
                    Birim İşlemleri
                </div>
                <div class="card-body">
                    <div class="row">

                        <div class="col-md-6">
                            <div class="section-body">

                                <div class="form-group">
                                    <label class="col-md-3 control-label">BİRİM ADI</label>
                                    <div class="col-md-9">
                                        <asp:TextBox ID="txtBirimAdi" MaxLength="100" CssClass="form-control" placeholder="Birim adı" runat="server"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="*** Birim adı yazmalısınız" ControlToValidate="txtBirimAdi" Font-Bold="false" ForeColor="#FF3300"></asp:RequiredFieldValidator>
                                    </div>
                                </div>


                                <div class="form-group">
                                    <label class="col-md-3 control-label">TELEFON</label>
                                    <div class="col-md-9">
                                        <asp:TextBox ID="txtTelefon" TextMode="Number" CssClass="form-control" placeholder="Telefon Numarası" runat="server"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ErrorMessage="*** 
                                    Telefon  yazmalısınız"
                                            ControlToValidate="txtTelefon" Font-Bold="false" ForeColor="#FF3300"></asp:RequiredFieldValidator>
                                    </div>
                                </div>

                                <div class="form-group">
                                    <label class="col-md-3 control-label">DAHİLİ NUMARA</label>
                                    <div class="col-md-9">
                                        <asp:TextBox ID="txtDahili" TextMode="Number" CssClass="form-control" placeholder="Dahili Numarası" runat="server"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator12" runat="server" ErrorMessage="*** 
                                    Dahili numarası  yazmalısınız.."
                                            ControlToValidate="txtDahili" Font-Bold="false" ForeColor="#FF3300"></asp:RequiredFieldValidator>
                                    </div>
                                </div>



                                <div class="form-group">
                                    <label class="col-md-3 control-label">GSM</label>
                                    <div class="col-md-9">
                                        <asp:TextBox ID="txtGsm" TextMode="Number" CssClass="form-control" placeholder="Cep Telefon Numarası" Text="" runat="server"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator13" runat="server" ErrorMessage="*** Cep Telefonu yazmalısınız"
                                            ControlToValidate="txtGsm" Font-Bold="false" ForeColor="#FF3300"></asp:RequiredFieldValidator>
                                    </div>
                                </div>


                            </div>
                        </div>



                        <div class="col-md-6">

                            <div class="form-group">
                                <label class="col-md-3 control-label">YETKİLİ ADI</label>
                                <div class="col-md-9">
                                    <asp:TextBox ID="txtYetkiliAdi" MaxLength="70" CssClass="form-control" placeholder="Yetikili Adı" runat="server"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="*** Yetkili adı yazmalısınız" ControlToValidate="txtYetkiliAdi" Font-Bold="false" ForeColor="#FF3300"></asp:RequiredFieldValidator>
                                </div>
                            </div>


                            <div class="form-group">
                                <label class="col-md-3 control-label">GÖREVİ</label>
                                <div class="col-md-9">
                                    <asp:TextBox ID="txtGorevi" MaxLength="100" CssClass="form-control" placeholder="Partisi" runat="server"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator11" runat="server" ErrorMessage="*** Görevi yazmalısınız..." ControlToValidate="txtGorevi" ForeColor="Red"></asp:RequiredFieldValidator>
                                </div>
                            </div>


                            <div class="form-group">
                                <label class="col-md-3 control-label">EMAIL</label>
                                <div class="col-md-9">
                                    <asp:TextBox ID="txtEmail" MaxLength="150" CssClass="form-control" TextMode="Email" placeholder="Email adresi" runat="server"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator14" runat="server" ErrorMessage="*** Email yazmalısınız..." ControlToValidate="txtEmail" ForeColor="Red"></asp:RequiredFieldValidator>
                                </div>
                            </div>



                            <div class="form-group">
                                <label class="col-md-3 control-label">NOT - AÇIKLAMA</label>
                                <div class="col-md-9">
                                    <asp:TextBox ID="txtNot" TextMode="MultiLine" MaxLength="500" CssClass="form-control" placeholder="Not - Açıklama" runat="server"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" ErrorMessage="*** Not  yazmalısınız" ControlToValidate="txtNot" Font-Bold="false" ForeColor="#FF3300"></asp:RequiredFieldValidator>
                                </div>
                            </div>


                        </div>

                        <div class="form-group has-success">
                            <div class="col-md-9">
                                <asp:Button ID="btnKaydet" CssClass="btn btn-primary" runat="server" Text="Kaydet" OnClick="btnKaydet_Click" />
                               
                                <br />
                                <br />
                                <asp:Label ID="lblsonuc" runat="server" Text="" Visible="true"></asp:Label>
                            </div>
                        </div>


                    </div>

                    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>

                    <ajaxToolkit:ModalPopupExtender ID="ModalPopupExtender1" runat="server" PopupControlID="Panel1" TargetControlID="Label1" BackgroundCssClass="modalBackground" CancelControlID="btnHide">
                    </ajaxToolkit:ModalPopupExtender>

                    <asp:Panel ID="Panel1" runat="server" CssClass="modalPopup" Style="display: none; width: 200px">
                        <div class="header">
                            Bilgi
                        </div>
                        <div class="body">
                            <asp:Label ID="Label1" runat="server" Text=""></asp:Label>
                        </div>
                        <div class="footer" align="right">
                            <asp:Button ID="btnHide" runat="server" CssClass="no" Text="Kapat" />
                        </div>
                    </asp:Panel>







                </div>
            </div>
        </div>
    </div>



</asp:Content>
