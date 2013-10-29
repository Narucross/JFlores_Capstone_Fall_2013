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
