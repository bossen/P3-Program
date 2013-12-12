using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Tag
    {
        #region Fields
        private List<string> _tagNames = new List<string>() { "Festival", "Church", "Culture", "Nature", "Sport", "Political" };
        private string _tag;
        #endregion

        #region Proterties
        public int ID { get; set; }
        public string Name 
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
        public Tag() { }

        public Tag(string tagname)
        {
            Name = tagname;
        }

        #endregion

    }
}
