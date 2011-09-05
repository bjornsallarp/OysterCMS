<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="OysterCMS._Default" ValidateRequest="false"%>

<!DOCTYPE html>
<html lang="en">
  <head runat="server">
    <meta charset="utf-8">
    <title>Oyster CMS</title>
    <meta name="description" content="">
    <meta name="author" content="">

    <!-- Le HTML5 shim, for IE6-8 support of HTML elements -->
    <!--[if lt IE 9]>
      <script src="http://html5shim.googlecode.com/svn/trunk/html5.js"></script>
    <![endif]-->

    <!-- Le styles -->
    <link href="/css/twitter-bootstrap/bootstrap-1.1.1.css" rel="stylesheet">
    <link href="/css/edit.css" rel="stylesheet">

      <script src="http://ajax.googleapis.com/ajax/libs/jquery/1.6.2/jquery.min.js" type="text/javascript"></script>
      <script src="Scripts/tinymce/jquery.tinymce.js" type="text/javascript"></script>
      <script src="Scripts/jsTree/jquery.jstree.js" type="text/javascript"></script>
      <script src="Scripts/jsTree/_lib/jquery.cookie.js" type="text/javascript"></script>
      <script src="Scripts/jsTree/_lib/jquery.hotkeys.js" type="text/javascript"></script>

      <script src="Scripts/page-tree.js" type="text/javascript"></script>
      <script src="Scripts/edit-page.js" type="text/javascript"></script>
  </head>

  <body>
    <form id="form1" runat="server">
    <br />
    <br />
    <div class="container">
        <div class="row">
            <div class="span4">
                <div id="oyster-page-tree"></div>
            </div>
            <div class="span12">
                <asp:Label runat="server" ID="lbl_Heading" />
                <asp:ValidationSummary ID="validationSummary" runat="server" DisplayMode="BulletList" />
                <asp:Table runat="server" ID="EditControls">
                    <asp:TableFooterRow>
                        <asp:TableCell ColumnSpan="2" CssClass="text-right">
                            <asp:LinkButton runat="server" Text="Save" ID="btn_Save" CssClass="btn primary large" />
                        </asp:TableCell>
                    </asp:TableFooterRow>
                </asp:Table>         
            </div>
        </div>
        <footer>
            <p>&copy; Oyster CMS</p>
        </footer>
    </div>
    </form>
  </body>
</html>
