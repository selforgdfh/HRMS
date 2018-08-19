using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HRMS.Core
{
    public class SearchFilters
    {
        string word;
        int page;
        int rows;
        string searchString;

        public string Word
        {
            get
            {
                return word;
            }

            set
            {
                word = value;
            }
        }

        public string SearchString
        {
            get
            {
                return searchString;
            }

            set
            {
                searchString = value;
            }
        }

        public int Rows
        {
            get
            {
                return rows;
            }

            set
            {
                rows = value;
            }
        }

        public int Page
        {
            get
            {
                return page;
            }

            set
            {
                page = value;
            }
        }
    }
}