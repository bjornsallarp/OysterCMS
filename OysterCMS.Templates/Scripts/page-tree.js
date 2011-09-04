$(function () {
    $("#oyster-page-tree").jstree({
        // the `plugins` array allows you to configure the active plugins on this instance
        "plugins": ["themes", "json_data", "ui", "crrm", "hotkeys", "contextmenu"],
        // each plugin you have included can have its own config object
        "core": { "initially_open": ["phtml_1"], "animation": 0 },
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
    .bind("select_node.jstree", function (e, data) {
        window.location = '/?pageid=' + data.rslt.obj.attr('id');
    })
    .bind("loaded.jstree", function (event, data) {
    });
});