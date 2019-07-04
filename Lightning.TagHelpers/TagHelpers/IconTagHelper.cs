using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Razor.TagHelpers;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Lightning.Lib.TagHelpers
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

    public enum IconSize
    {
        None,
        xxSmall,
        xSmall,
        Small,
        Large
    }


    [HtmlTargetElement("slds-icon")]
    public class IconTagHelper : TagHelper
    {
        Dictionary<IconSize, string> sizes = new Dictionary<IconSize, string>{
            {
                IconSize.xxSmall,"slds-icon_xx-small"
            },
            {
                IconSize.xSmall,"slds-icon_x-small"
            },
                {
                IconSize.Small,"slds-icon_small"
            },
                 
                {
                IconSize.Large,"slds-icon_large"
            },
            };
        public string Title { get; set; }
        public IconColor IconColor { get; set; }
        public IconSprite IconSprite { get; set; }
        public string IconName { get; set; }

        public IconSize IconSize { get; set; }
        public override async Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
        {
            output.TagName = "";
            var containerTag = new TagBuilder("span");
            containerTag.AddCssClass("slds-icon_container");
            containerTag.AddCssClass($"slds-icon-{IconSprite.ToString().ToLower()}-{IconName.ToLower()}");

            containerTag.Attributes.Add("title", Title);
            var svgTag = new TagBuilder("svg");
            svgTag.AddCssClass("slds-icon");


            var assistiveTextTag = new TagBuilder("span");
            assistiveTextTag.AddCssClass("slds-assistive-text");
            assistiveTextTag.InnerHtml.Append(Title);

            if (output.Attributes.TryGetAttribute("class", out var @class))
                svgTag.AddCssClass(@class.Value.ToString());


            if (IconColor != IconColor.None)
                svgTag.AddCssClass($"slds-icon-text-{IconColor.ToString().ToLower()}");

            if (IconSize != IconSize.None)
                svgTag.AddCssClass(sizes[IconSize]);

            var useTag = new TagBuilder("use");
            useTag.Attributes.Add("xlink:href", $"/assets/icons/{IconSprite.ToString().ToLower()}-sprite/svg/symbols.svg#{IconName}");

            svgTag.InnerHtml.AppendHtml(useTag);
            containerTag.InnerHtml
                .AppendHtml(svgTag)
                .AppendHtml(assistiveTextTag);

            output.Content.SetHtmlContent(containerTag);

            // return base.ProcessAsync(context, output);
        }

    }
}
