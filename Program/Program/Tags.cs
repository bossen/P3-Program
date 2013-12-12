using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    class Tags
    {
        #region Fields
        private List<string> _tagNames = new List<string>();
        private string _tag;
        #endregion

        #region Proterties
        public string Tag 
        {
            get
            {
                return _tag;
            }
            private set
            {
                if (_tagNames.Contains(value))
                {
                    _tag = value;
                }
            }
        }
        #endregion

        #region Contructors
        public Tags() { }

        public Tags(string tagname)
        {
            Tag = tagname;
        }

        #endregion

    }
}
