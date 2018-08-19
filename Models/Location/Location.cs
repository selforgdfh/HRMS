using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using HRMS.Core;
using HRMS.DBModel;

namespace HRMS.Models.Location
{
    [Serializable]
    public class Location : ILocation
    {
        HRMSEntities DbContext = new HRMSEntities();
        public int AddLocation()
        {
            throw new NotImplementedException();
        }

        public int DeleteLocation()
        {
            throw new NotImplementedException();
        }

        public List<DBModel.location> getLocations()
        {
            return DbContext.locations.ToList();
        }

        public string getTreeView(bool encode, bool add, bool edit, bool del, bool select)
        {
            Location objLocation = new Location();
            //DataTable dtLocations = objLocation.getLocations();
            List<DBModel.location> dtLocations = objLocation.getLocations();
            string addStr = "";
            if (add)
                addStr = createAddStr("");
            TreeNode nRoot = new TreeNode(addStr + "Location(s)", "");
            nRoot._hide = false;
            TreeView trvLocations = new TreeView("tree");
            if (select)
                trvLocations.select = true;

            foreach (DBModel.location dr in dtLocations.Where(x => x.parentID == null))
            {
                string AddStr = "";
                if (add)
                    AddStr = createAddStr(dr.locationsCode.ToString());
                string editStr = "";
                if (edit)
                    editStr = " <img title=\"Click here to Edit\" style=\"cursor:pointer\" onclick=\"edit('" + dr.locationsCode.ToString() + "');\" width=\"13\" height=\"13\" src=\"../../Content/Img/edit.png\" /> ";
                string delStr = "";
                if (del)
                    delStr = " <img  title=\"Click here to Delete\" style=\"cursor:pointer\" onclick=\"del('" + dr.locationsCode.ToString() + "');\" width=\"13\" height=\"13\" src=\"../../Content/Img/delete.png\" /> ";
                TreeNode tn = new TreeNode(AddStr + editStr + delStr + dr.locationsCode.ToString() + "  " + dr.locationsCode.ToString(), dr.locationsCode.ToString(), "");
                tn._hide = false;
                nRoot.addChild(getNode(dtLocations, dr.locationsCode.ToString(), tn, add, edit, del));
            }
            trvLocations.addNode(nRoot);
            trvLocations.checkBox = false;
            if (encode)
                return Uri.EscapeDataString(trvLocations.getTreeText());
            else
                return trvLocations.getTreeText();
        }

        private TreeNode getNode(List<DBModel.location> dtLocation, string parentID, TreeNode parentNode, bool add, bool edit, bool del)
        {
            foreach (DBModel.location dr in dtLocation.Where(x => x.parentID.ToString() == parentID))
            {
                string AddStr = "";
                if (add)
                    AddStr = createAddStr(dr.locationsCode.ToString());
                string editStr = "";
                if (edit)
                    editStr = " <img title=\"Click here to Edit\" style=\"cursor:hand\" onclick=\"edit('" + dr.locationsCode.ToString() + "');\" width=\"13\" height=\"13\" src=\"../../Content/Img/edit.png\" /> ";
                string delStr = "";
                if (del)
                    delStr = " <img title=\"Click here to Delete\" style=\"cursor:hand\" onclick=\"del('" + dr.locationsCode.ToString() + "');\" width=\"13\" height=\"13\" src=\"../../Content/Img/delete.png\" /> ";

                TreeNode node = new TreeNode(AddStr + editStr + delStr + dr.locationsCode.ToString() + "  " + dr.locationsCode.ToString(), dr.locationsCode.ToString(), "");
                node._hide = false;
                parentNode.addChild(getNode(dtLocation, dr.locationsCode.ToString(), node, add, edit, del));
            }
            return parentNode;
        }

        private String createAddStr(string id)
        {
            return "<span style=\"cursor:hand\"><img title=\"Click here to Add\" onclick=\"add('" + id + "');\" width=\"13\" height=\"13\" src=\"../../Content/Img/add.png\" /></span>";
        }

        public int UpdateLocation()
        {
            throw new NotImplementedException();
        }


    }
}