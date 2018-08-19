using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using HRMS.DBModel;

namespace HRMS.Core
{
    public interface ILocation
    {
        List<location> getLocations();

        int AddLocation();

        int DeleteLocation();

        int UpdateLocation();

        string getTreeView(bool encode, bool add, bool edit, bool del, bool select);

        


    }
}