using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using System.ComponentModel.DataAnnotations.Schema;

namespace Model
{
    public class Topic
    {
        #region Fields

        #endregion

        #region Properties
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
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
            if (this.Church == that.Church && this.Church == true)
            {
                likeness++;
            }
            if (this.Festival == that.Festival && this.Festival == true)
            {
                likeness++;
            }
            if (this.Culture == that.Culture && this.Culture == true)
            {
                likeness++;
            }
            if (this.Nature == that.Nature && this.Nature == true)
            {
                likeness++;
            }
            if (this.Sport == that.Sport && this.Sport == true)
            {
                likeness++;
            }
            if (this.Political == that.Political && this.Political == true)
            {
                likeness++;
            }
            return likeness;
        }

        public void QuickSetProperties(Topic topic)
        {
            this.Church = topic.Church;
            this.Culture = topic.Culture;
            this.Festival = topic.Festival;
            this.Nature = topic.Nature;
            this.Political = topic.Political;
            this.Sport = topic.Sport;
        }
        /// <summary>
        /// A quick way to load some values into the properties
        /// </summary>
        /// <param name="church">Church setting</param>
        /// <param name="culture">Culture setting</param>
        /// <param name="festival">Festival setting</param>
        /// <param name="nature">Nature setting</param>
        /// <param name="political">Political setting</param>
        /// <param name="sport">Sport setting</param>
        public void QuickSetProperties(bool church, bool culture, bool festival, bool nature, bool political, bool sport)
        {
            this.Church = church;
            this.Culture = culture;
            this.Festival = festival;
            this.Nature = nature;
            this.Political = political;
            this.Sport = sport;
        }
        #endregion

        public string Print()
        {
            string result = "";
            foreach (PropertyInfo prop in this.GetType().GetProperties())
            {
                object value = prop.GetValue(this);
                if (value.GetType() == typeof(bool))
                {
                    if ((bool)value)
                    {
                        result += prop.Name + " ";
                    }
                }
            }
            return result;
        }
    }
}
