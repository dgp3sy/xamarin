using System;
using System.Collections.Generic;

namespace NotePage.Models
{
    public class Note
    { // these properties correspond to the itemsDetalPage.xaml
        public String Id { get; set; }
        public String Heading { get; set; } // available for data binding (public)
        public String Text { get; set; } // available for data binding (public)
        public String Course { get; set; }
    }
}
