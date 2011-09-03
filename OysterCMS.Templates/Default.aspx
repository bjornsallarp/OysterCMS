<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="OysterCMS._Default" %>

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
      <script src="Scripts/jsTree/jquery.jstree.js" type="text/javascript"></script>
      <script src="Scripts/jsTree/_lib/jquery.cookie.js" type="text/javascript"></script>
      <script src="Scripts/jsTree/_lib/jquery.hotkeys.js" type="text/javascript"></script>
  </head>

  <body>
    <form id="form1" runat="server">
    <br />
    <br />
    <div class="container">
        <div class="row">
            <div class="span4">
                <div id="demo1" class="demo"></div>
                <script type="text/javascript" class="source below">
                    $(function () {
                        $("#demo1").jstree({
                            // the `plugins` array allows you to configure the active plugins on this instance
                            "plugins": ["themes", "json_data", "ui", "crrm", "hotkeys", "contextmenu"],
                            // each plugin you have included can have its own config object
                            "core": { "initially_open": ["phtml_1"] },
                            // it makes sense to configure a plugin only if overriding the defaults
                            "themes": {
                                "theme": "default",
                                "dots": true,
                                "icons": false
                            },
                            "contextmenu": {
                                items: function () {
                                    return { 
                                        "rename": {
                                            // The item label
                                            "label": "Rename",
                                            // The function to execute upon a click
                                            "action": function (obj) { alert('hejsan'); },
                                            // All below are optional 
                                            "_disabled": false, 	// clicking the item won't do a thing
                                            "_class": "class", // class is applied to the item LI node
                                            "separator_before": false, // Insert a separator before the item
                                            "separator_after": false, 	// Insert a separator after the item
                                            // false or string - if does not contain `/` - used as classname
                                            "icon": false
                                        },
                                        "create": {
                                            "label": "Create new page",
                                            "action": function (obj) { window.location = '/?createnew=1&pageid=' + $(obj).attr('id'); },
                                            "_disabled": false,
                                            "_class": "class",
                                            "separator_before": false, // Insert a separator before the item
                                            "separator_after": false, 	// Insert a separator after the item
                                            // false or string - if does not contain `/` - used as classname
                                            "icon": false
                                        }
                                    }
                                }
                            },
                            "json_data": {
                                "ajax": {
                                    url: "/Services/PageTreeService.svc/children",
                                    dataType: "json",
                                    type: "POST",
                                    contentType: "application/json",
                                    success: function (pages) {
                                        if (pages) {
                                            for (var i = 0; i < pages.length; i++) {
                                                pages[i]['attr'] = { id: pages[i].Id };
                                            }
                                        }
                                        return pages;
                                    },
                                    data: function (n) {
                                        if (n == undefined || n <= 0) {
                                            return {};
                                        }
                                        else {
                                            return '{ "parent": "' + $(n).attr('id') + '"}';
                                        }
                                    }
                                }
                            }
                        })
                    })
                    .bind("select_node.jstree", function (e, data) {
                        window.location = '/?createnew=1&pageid=' + $(obj).attr('id');
                    })
		            .bind("loaded.jstree", function (event, data) {
		                // you get two params - event & data - check the core docs for a detailed description
		            });
                </script>
            </div>
            <div class="span12">
                <asp:Label runat="server" ID="lbl_Heading" />
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
