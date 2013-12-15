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
        #region Fields

        #endregion

        #region Properties
        [Key]
        public int TopicID { get; set; }
        [Display(Name="Festival")]
        public bool Festival { get; set; }
        [Display(Name = "Church")]
        public bool Church { get; set; }
        [Display(Name = "Culture")]
        public bool Culture { get; set; }
        [Display(Name = "Nature")]
        public bool Nature { get; set; }
        [Display(Name = "Sport")]
        public bool Sport { get; set; }
        [Display(Name = "Political")]
        public bool Political { get; set; }

        #endregion

        #region Constructors
        public Topic()
        {
            Festival = false;
            Church = false;
            Culture = false;
            Nature = false;
            Sport = false;
            Political = false;
        }

        #endregion

        #region Methods
        public int CompareTopics(Topic that)
        {
            int likeness = 0;
            if (this.Church == that.Church)
            {
                likeness++;
            }
            if (this.Festival == that.Festival)
            {
                likeness++;
            }
            if (this.Culture == that.Culture)
            {
                likeness++;
            }
            if (this.Nature == that.Nature)
            {
                likeness++;
            }
            if (this.Sport == that.Sport)
            {
                likeness++;
            }
            if (this.Political == that.Political)
            {
                likeness++;
            }
            return likeness;
        }
        #endregion


    }
}
