using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HRMS.Helper
{
    public class TreeView
    {
        List<TreeNode> _nodes = new List<TreeNode>();
        public bool checkBox = false;
        public bool select = false;
        string _id;
        public TreeView(string ID)
        {
            _id = ID;
        }
        public void addNode(TreeNode node)
        {
            _nodes.Add(node);
        }
        public string getTreeText()
        {
            string retStr;
            if (_nodes.Count == 0) return "";
            retStr = "<div style=\"padding:left=1.5cm\" ID = \"D" + _id + "\">";
            retStr += "<div class=\"treeDiv\" id=\"parent_D" + _id + "\" >";
            foreach (TreeNode _node in _nodes)
            {
                retStr += "" + _node.getNodeString(checkBox, select) + "";
            }
            retStr += "</div></div>";
            return retStr;
        }
        public string getTreeText(bool forAJAX)
        {
            if (!forAJAX) return getTreeText();
            string retStr;
            if (_nodes.Count == 0) return "";
            retStr = "";
            foreach (TreeNode _node in _nodes)
            {
                retStr += "" + _node.getNodeString(checkBox, select) + "";
            }
            retStr += "";
            return retStr;
        }
    }
    public class TreeNode
    {
        public string basePath = "../../";
        string _value;
        string _text;
        string _icons;
        public bool _expandable = false;
        public bool _hide = true;
        List<TreeNode> _childs = new List<TreeNode>();
        public TreeNode(String text, String value, String icons)
        {
            _value = value;
            _text = text;
            _icons = icons;
        }
        public TreeNode(String text, String value)
        {
            _value = value;
            _text = text;
            _icons = "";
        }
        public void addChild(TreeNode node)
        {
            _childs.Add(node);
        }

        public string getNodeString(bool ShowcheckBox, bool select)
        {
            if (_expandable) _hide = true;
            string selString = "";
            if (select) selString = "<a forTree = \"y\" class=\"node\" style=\"cursor:pointer\"  ondblclick=\"dblselect('" + _value + "')\" onClick=\"select('" + _value + "')\">" + _text
                + "</a>";
            else selString = _text;
            string hide = " style=\"display:none\" ";
            if (!_hide) hide = "";
            string chkBox = "";
            if (ShowcheckBox) chkBox = "<input type=\"checkbox\" onClick=\"chkUnchk(this)\" id=\"chk_" + _value + "\" />";
            string toggle = "<img id=\"img_parent_" + _value + "\" onclick=\"toggle('parent_" + _value + "');\" src=\"" + basePath + "Content/Img/plus.gif\" />";
            if (!_hide)
                toggle = "<img id=\"img_parent_" + _value + "\" onclick=\"toggle('parent_" + _value + "');\" src=\"" + basePath + "Content/Img/minus.gif\" />";
            string forImage = "imgID=\"img_parent_" + _value + "\"";
            if (_childs.Count == 0 && !_expandable)
            {
                toggle = "<img id=\"img_parent_" + _value + "\" src=\"" + basePath + "Content/Img/noimage.png\"/>";
                forImage = "";
            }
            string expand = " expanded=\"Y\" ";
            if (_expandable) expand = " expanded=\"N\" ";
            string retStr;
            retStr = "<div ID = \"D" + _value + "\">"
                + "" + toggle + chkBox + _icons + selString
                + "<div class=\"treeDiv\" " + forImage + " id=\"parent_" + _value + "\" " + expand + hide + ">";
            foreach (TreeNode _node in _childs)
            {
                retStr += "" + _node.getNodeString(ShowcheckBox, select) + "";
            }
            retStr += "</div></div>";
            return retStr;
        }
    }
}