using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HRMS.Core
{
    public class DropDown
    {

        string id;

        string name;

        public string Id
        {
            get
            {
                return id;
            }

            set
            {
                id = value;
            }
        }

        public string Name
        {
            get
            {
                return name;
            }

            set
            {
                name = value;
            }
        }

    }
}