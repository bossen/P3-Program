using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Topic
    {
        private List<string> _topicNames = new List<string>() { "Festival", "Church", "Culture", "Nature", "Sport", "Political" };
        private string _name;

        [Key]
        public int TopicID { get; set; }
        public string Name { 
            get 
            {
                return _name;
            }
            set
            {
                if (_topicNames.Contains(value))
                {
                    _name = value;
                }
            }
        }
    }
}
