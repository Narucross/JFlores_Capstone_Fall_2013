using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SmoothDesktop.Models
{
    public class ZoneTemplate
    {
        /// <summary>
        /// The name of the Template
        /// </summary>
        public String TemplateName { get; set; }

        /// <summary>
        /// The Number of zones currently
        /// </summary>
        public ZoneDimensions[] Zones { get; set; }



        [JsonIgnore]
        public Screen[] Screens { get; set; }

        public CurrentProgram[] Programs { get; set; }

        public ZoneTemplate() { }
        public ZoneTemplate(ZoneTemplate t) {
            TemplateName = t.TemplateName;
            Zones = t.Zones;
            Programs = t.Programs.OrderBy(x => x.PointerId).ToArray();
        }
    }
}
