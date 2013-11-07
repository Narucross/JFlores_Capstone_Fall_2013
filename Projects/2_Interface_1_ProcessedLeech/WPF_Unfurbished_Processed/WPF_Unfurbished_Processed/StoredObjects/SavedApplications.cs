using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store_Rectangles
{
    /// <summary>
    /// A "Bean" for saving what the user wants the idea is to have a template and application coupling, this being the later.
    /// </summary>
    class SavedAppications
    {
        public SavedAppications()
        {
            SavedWindows = new List<SavedWindow>();
            // Need to know if overriding constructor will change the properties in any way...
        }


        /// <summary>
        /// Another word for "TemplateReference"
        /// </summary>
        public String TempateName { get; set; }
        public List<SavedWindow> SavedWindows { get; set; }


        public override bool Equals(object obj)
        {
            bool returnedValue = false;
            if (obj is SavedAppications)
            {
                SavedAppications variable = (SavedAppications)obj;
                if (variable.TempateName.Equals(this.TempateName))
                {
                    //Lists
                    bool containsAll = true;
                    for (int i = 0; i < this.SavedWindows.Count && containsAll; i++)
                    {
                        if (!variable.SavedWindows.Contains(this.SavedWindows.ElementAt(i))) {
                            containsAll = false;
                        }
                    }
                }
            }
            return returnedValue;
        }
        public override int GetHashCode()
        {
            return 1;
        }

        #region convience Methods

        public void Add(SavedWindow newWindow)
        {
            this.SavedWindows.Add(newWindow);
        }

        public bool Remove(SavedWindow window)
        {
            return this.SavedWindows.Remove(window);
        }
        #endregion
    }
}
