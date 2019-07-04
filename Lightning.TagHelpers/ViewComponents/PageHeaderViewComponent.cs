using Lightning.Lib.TagHelpers;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Lightning.Lib.ViewComponents
{
    public class PageHeaderViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke(string title, IconSprite iconSprite, string iconName)
        {
            ViewData["Title"] = title;
            ViewData["IconSprite"] = iconSprite;
            ViewData["IconName"] = iconName;
            return View();
        }
    }
}
