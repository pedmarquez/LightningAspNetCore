using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Razor.TagHelpers;
using System;
using System.Collections.Generic;
using System.Text;

namespace Lightning.Lib.TagHelpers
{
    [HtmlTargetElement(Attributes = "slds-button-icon")]
    public class ButtonIconTagHelper: TagHelper
    {
        public string Title { get; set; }
      //  public IconColor IconColor { get; set; }
        public IconSprite IconSprite { get; set; }
        public string IconName { get; set; }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
           
            output.Attributes.RemoveAll("slds-button-icon");
           // var buttonTag = new TagBuilder();
            output.Attributes.Add("class", "slds-button-icon");

           
            var svgTag = new TagBuilder("svg");
            svgTag.AddCssClass("slds-button__icon");
            var useTag = new TagBuilder("use");
            useTag.Attributes.Add("xlink:href", $"/assets/icons/{IconSprite.ToString().ToLower()}-sprite/svg/symbols.svg#{IconName}");

            svgTag.InnerHtml.AppendHtml(useTag);
            output.Content.AppendHtml(svgTag);
            //  base.Process(context, output);
        }
    }
}
