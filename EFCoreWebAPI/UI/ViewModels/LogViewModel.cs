using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UI.ViewModels
{
    public class LogViewModel
    {
        public int id { get; set; }
        public string controllerName { get; set; }
        public string actionName { get; set; }
        public string actionType { get; set; }
        public DateTime date { get; set; }
    }
}
