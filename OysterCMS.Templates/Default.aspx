<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="OysterCMS.Templates.Default" %>

<!DOCTYPE html>
<html lang="en">
<head runat="server">
    <meta charset="utf-8">
    <title><%= CurrentPage.PageName %></title>
    <meta name="description" content="">
    <meta name="author" content="">
    <!-- Le HTML5 shim, for IE6-8 support of HTML elements -->
    <!--[if lt IE 9]>
      <script src="http://html5shim.googlecode.com/svn/trunk/html5.js"></script>
    <![endif]-->
    <!-- Le styles -->
    <link href="/css/twitter-bootstrap/bootstrap-1.1.1.css" rel="stylesheet">
    <link href="/css/page.css" rel="stylesheet">
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
    <div id="masthead">
        <div class="inner">
            <div class="container">
                <h1>OysterCMS</h1>
                <p class="lead">
                    
                </p>
            </div>
            <!-- /container -->
        </div>
    </div>
    <div class="container body">
        <div class="container">
            <section id="about">
                <div class="page-header">
                    <h1><%=CurrentPage.MainHeading %></h1>
                </div>
                <div class="row">
                    <div class="span6 columns">
                        <%= CurrentPage.EditorBody %>  
                    </div>

                    <div class="span5 columns">
                      <h3>Browser support</h3>
                      <p>Bootstrap is tested and supported in major modern browsers like Chrome, Safari, Internet Explorer, and Firefox.</p>
                      <img src="assets/img/browsers.png" width="258px" height="48px" alt="Tested and supported in Chrome, Safari, Internet Explorer, and Firefox">
                      <ul>
                        <li>Latest Safari</li>
                        <li>Latest Google Chrome</li>

                        <li>Firefox 4+</li>
                        <li>Internet Explorer 7+</li>
                        <li>Opera 11</li>
                      </ul>
                    </div>
                    <div class="span5 columns">
                      <h3>What's included</h3>

                      <p>Bootstrap comes complete with compiled CSS, uncompiled, and example templates.</p>
                      <ul>
                        <li>All original .less files</li>
                        <li>Fully compiled and minified CSS</li>
                        <li>Complete styleguide documentation</li>
                        <li>Example page template (more to come soon)</li>

                      </ul>
                    </div>
            </div><!-- /row -->
        </section>
        <footer>
            <p>&copy; Oyster CMS</p>
        </footer>
    </div>
    </form>
</body>
</html>
