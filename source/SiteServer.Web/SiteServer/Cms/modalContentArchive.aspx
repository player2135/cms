﻿<%@ Page Language="C#" Inherits="SiteServer.BackgroundPages.Cms.ModalContentArchive" Trace="false"%>
<%@ Register TagPrefix="bairong" Namespace="SiteServer.BackgroundPages.Controls" Assembly="SiteServer.BackgroundPages" %>
<!DOCTYPE html>
<html>
<head>
<meta charset="utf-8">
<!--#include file="../inc/header.aspx"-->
</head>

<body>
<!--#include file="../inc/openWindow.html"-->
<form class="form-inline" runat="server">
<asp:Button id="btnSubmit" useSubmitBehavior="false" OnClick="Submit_OnClick" runat="server" style="display:none" />
<bairong:alerts runat="server"></bairong:alerts>

	<div class="alert alert-info">
	  <h5>此操作将归档所选内容，确认吗？</h5>
	</div>

</form>
</body>
</html>
