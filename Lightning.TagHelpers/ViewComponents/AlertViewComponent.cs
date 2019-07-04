using Microsoft.AspNetCore.Mvc;

namespace Lightning.Lib.ViewComponents
{
    public enum AlertVariant
    {
        Info,
        Warning,
        Error,
        Offline

    }
    public class AlertViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke(string title, AlertVariant variant = AlertVariant.Info)
        {
            
            ViewData["Title"] = title;
            ViewData["Variant"] = variant;
            return View();
        }
    }
}
