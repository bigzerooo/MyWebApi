using System;

namespace UI.ViewModels
{
    public class LogViewModel
    {
        public int Id { get; set; }
        public string ControllerName { get; set; }
        public string ActionName { get; set; }
        public string ActionType { get; set; }
        public DateTime Date { get; set; }
    }
}
