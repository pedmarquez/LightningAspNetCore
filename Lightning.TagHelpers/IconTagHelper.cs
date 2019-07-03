using Microsoft.AspNetCore.Razor.TagHelpers;
using System.Collections.Generic;

namespace Lightning.TagHelpers
{
    public enum IconColor
    {
        None,
        Default,
        Success,
        Warning,
        Error,
        Light
    }
    public enum IconSprite
    {
      //  None,
        Action,
        Custom,
        Doctype,
        Standard,
        Utility
    }


    [HtmlTargetElement("slds-icon")]
    public class IconTagHelper: TagHelper
    {
        public IconColor IconColor { get; set; }
        public IconSprite Sprite { get; set; }
        public string Icon { get; set; }
        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            var clases = new List<string> { "slds-icon" };
            output.TagName = "svg";
          

            if(IconColor != IconColor.None)
               clases.Add( $"slds-icon-text-{IconColor.ToString().ToLower()}");

            output.Attributes.SetAttribute("class", string.Join(" ", clases));

            output.Content.SetHtmlContent($"<use xlink:href='/assets/icons/{Sprite.ToString().ToLower()}-sprite/svg/symbols.svg#{Icon}'></use>");
        }
    }
}
