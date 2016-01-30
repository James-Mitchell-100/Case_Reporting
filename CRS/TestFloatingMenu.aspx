<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/CRS.Master" CodeBehind="TestFloatingMenu.aspx.vb" Inherits="CRS.TestFloatingMenu" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <% '*************************************************************************************************************************************************************** %>
    <% 'Beginning of the Floating Menu %>
    <div id="fixeddiv" style=" position:absolute; width:400px; right:10px; top:200px; padding:16px; background:#FFFFFF; border:2px solid #2266AA"> 
        <div id="upperleft" style="float: left">
            <img alt="" src="Graphics/UpperLeftArrow.gif" onclick="javavscript:move_upper_left();" height="25" width="25" />
        </div>
        <div id="upperright" style="float: right">
            <img alt="" src="Graphics/UpperRightArrow.gif" onclick="javavscript:move_upper_right();" height="25" width="25" />
        </div>
        <br />
        <br />
            <asp:Label ID="lblFloatingMenuText" runat="server" Text="Text For Floating Menu"></asp:Label>
        <br />
        <br />
        <div id="lowerleft" style="float: left">
            <img alt="" src="Graphics/LowerLeftArrow.gif" onclick="javavscript:move_lower_left();" height="25" width="25" />
        </div>
        <div id="lowerright" style="float: right">
            <img alt="" src="Graphics/LowerRightArrow.gif" onclick="javavscript:move_lower_right();" height="25" width="25" />
        </div>
    </div>

    <script type="text/javascript"><!--
        /* Script by: www.jtricks.com 
        * Version: 20071127 
        * Latest version: 
        * www.jtricks.com/javascript/navigation/fixed_menu.html 
        */
        fixedMenuId = 'fixeddiv';

        var fixedMenu =
    {
        hasInner: typeof (window.innerWidth) == 'number',
        hasElement: document.documentElement != null
           && document.documentElement.clientWidth,

        menu: document.getElementById
            ? document.getElementById(fixedMenuId)
            : document.all
              ? document.all[fixedMenuId]
              : document.layers[fixedMenuId]
    };

        fixedMenu.computeShifts = function () {
            fixedMenu.shiftX = fixedMenu.hasInner
            ? pageXOffset
            : fixedMenu.hasElement
              ? document.documentElement.scrollLeft
              : document.body.scrollLeft;
            if (fixedMenu.targetLeft > 0)
                fixedMenu.shiftX += fixedMenu.targetLeft;
            else {
                fixedMenu.shiftX +=
                (fixedMenu.hasElement
                  ? document.documentElement.clientWidth
                  : fixedMenu.hasInner
                    ? window.innerWidth - 20
                    : document.body.clientWidth)
                - fixedMenu.targetRight
                - fixedMenu.menu.offsetWidth;
            }

            fixedMenu.shiftY = fixedMenu.hasInner
            ? pageYOffset
            : fixedMenu.hasElement
              ? document.documentElement.scrollTop
              : document.body.scrollTop;
            if (fixedMenu.targetTop > 0)
                fixedMenu.shiftY += fixedMenu.targetTop;
            else {
                fixedMenu.shiftY +=
                (fixedMenu.hasElement
                ? document.documentElement.clientHeight
                : fixedMenu.hasInner
                  ? window.innerHeight - 20
                  : document.body.clientHeight)
                - fixedMenu.targetBottom
                - fixedMenu.menu.offsetHeight;
            }
        };

        fixedMenu.moveMenu = function () {
            fixedMenu.computeShifts();

            if (fixedMenu.currentX != fixedMenu.shiftX
            || fixedMenu.currentY != fixedMenu.shiftY) {
                fixedMenu.currentX = fixedMenu.shiftX;
                fixedMenu.currentY = fixedMenu.shiftY;

                if (document.layers) {
                    fixedMenu.menu.left = fixedMenu.currentX;
                    fixedMenu.menu.top = fixedMenu.currentY;
                }
                else {
                    fixedMenu.menu.style.left = fixedMenu.currentX + 'px';
                    fixedMenu.menu.style.top = fixedMenu.currentY + 'px';
                }
            }

            fixedMenu.menu.style.right = '';
            fixedMenu.menu.style.bottom = '';
        };

        fixedMenu.floatMenu = function () {
            fixedMenu.moveMenu();
            setTimeout('fixedMenu.floatMenu()', 20);
        };

        // addEvent designed by Aaron Moore  
        fixedMenu.addEvent = function (element, listener, handler) {
            if (typeof element[listener] != 'function' ||
           typeof element[listener + '_num'] == 'undefined') {
                element[listener + '_num'] = 0;
                if (typeof element[listener] == 'function') {
                    element[listener + 0] = element[listener];
                    element[listener + '_num']++;
                }
                element[listener] = function (e) {
                    var r = true;
                    e = (e) ? e : window.event;
                    for (var i = 0; i < element[listener + '_num']; i++)
                        if (element[listener + i](e) === false)
                            r = false;
                    return r;
                }
            }

            //if handler is not already stored, assign it  
            for (var i = 0; i < element[listener + '_num']; i++)
                if (element[listener + i] == handler)
                    return;
            element[listener + element[listener + '_num']] = handler;
            element[listener + '_num']++;
        };

        fixedMenu.supportsFixed = function () {
            var testDiv = document.createElement("div");
            testDiv.id = "testingPositionFixed";
            testDiv.style.position = "fixed";
            testDiv.style.top = "0px";
            testDiv.style.right = "0px";
            document.body.appendChild(testDiv);
            var offset = 1;
            if (typeof testDiv.offsetTop == "number"
            && testDiv.offsetTop != null
            && testDiv.offsetTop != "undefined") {
                offset = parseInt(testDiv.offsetTop);
            }
            if (offset == 0) {
                return true;
            }

            return false;
        };

        fixedMenu.init = function () {
            if (fixedMenu.supportsFixed())
                fixedMenu.menu.style.position = "fixed";
            else {
                var ob =
                document.layers
                ? fixedMenu.menu
                : fixedMenu.menu.style;

                fixedMenu.targetLeft = parseInt(ob.left);
                fixedMenu.targetTop = parseInt(ob.top);
                fixedMenu.targetRight = parseInt(ob.right);
                fixedMenu.targetBottom = parseInt(ob.bottom);

                if (document.layers) {
                    menu.left = 0;
                    menu.top = 0;
                }
                fixedMenu.addEvent(window, 'onscroll', fixedMenu.moveMenu);
                fixedMenu.floatMenu();
            }
        };

        fixedMenu.addEvent(window, 'onload', fixedMenu.init);  
      
    //--></script>  
    
    <script type="text/javascript"><!--
    function move_upper_left() {
        //alert('Upper Left');
        if (fixedMenu.menu.style.position == 'fixed') {
            fixedMenu.menu.style.left = '10px';
            fixedMenu.menu.style.top = '200px';
            fixedMenu.menu.style.right = '';
            fixedMenu.menu.style.bottom = '';
        }
        else {
            fixedMenu.targetLeft = 10;
            fixedMenu.targetTop = 200;
            fixedMenu.targetRight = '';
            fixedMenu.targetBottom = '';
        }
    }

    function move_upper_right() {
        //alert('Upper Right');
        if (fixedMenu.menu.style.position == 'fixed') {
            fixedMenu.menu.style.left = '';
            fixedMenu.menu.style.top = '200px';
            fixedMenu.menu.style.right = '10px';
            fixedMenu.menu.style.bottom = '';
        }
        else {
            fixedMenu.targetLeft = '';
            fixedMenu.targetTop = 200;
            fixedMenu.targetRight = 10;
            fixedMenu.targetBottom = '';
        }
    }

    function move_lower_left() {
        //alert('Lower Left');
        if (fixedMenu.menu.style.position == 'fixed') {
            fixedMenu.menu.style.left = '10px';
            fixedMenu.menu.style.top = '';
            fixedMenu.menu.style.right = '';
            fixedMenu.menu.style.bottom = '10px';
        }
        else {
            fixedMenu.targetLeft = 10;
            fixedMenu.targetTop = '';
            fixedMenu.targetRight = '';
            fixedMenu.targetBottom = 10;
        }
    }

    function move_lower_right() {
        //alert('Lower Right');
        if (fixedMenu.menu.style.position == 'fixed') {
            fixedMenu.menu.style.left = '';
            fixedMenu.menu.style.top = '';
            fixedMenu.menu.style.right = '10px';
            fixedMenu.menu.style.bottom = '10px';
        }
        else {
            fixedMenu.targetLeft = '';
            fixedMenu.targetTop = '';
            fixedMenu.targetRight = 10;
            fixedMenu.targetBottom = 10;
        }
    }
    //--></script>
    <% 'End of the Floating Menu %>
    <% '*************************************************************************************************************************************************************** %>
    Blaaaaaa
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    Blaaaaaa
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    Blaaaaaa
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    Blaaaaaa
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    Blaaaaaa
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    Blaaaaaa
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    Blaaaaaa
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    Blaaaaaa
    </asp:Content>
