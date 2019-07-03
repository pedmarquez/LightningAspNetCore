using Microsoft.AspNetCore.Razor.TagHelpers;
using System.Collections.Generic;

namespace Lightning.TagHelpers
{
    public enum Variante
    {
        None,
        Neutral,
        Brand,
        OutlineBrand,
        Destructive
    }
    [HtmlTargetElement(Attributes = "slds-button")]
    public class ButtonTagHelper : TagHelper
    {
        private Dictionary<Variante, string> buttonStyles = new Dictionary<Variante, string> {
             { Variante.Neutral, "neutral" },
             { Variante.Brand, "brand" },
             { Variante.OutlineBrand, "outline-brand" },
             { Variante.Destructive, "destructive" }
        };
        public Variante Variante { get; set; }
        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            output.Attributes.RemoveAll("slds-button");

            var clases = new List<string> { "slds-button" };

            if (Variante != Variante.None)
                clases.Add($"slds-button_{ buttonStyles[this.Variante]}");

            if (output.Attributes.TryGetAttribute("class", out var @class))
                clases.Add(@class.Value.ToString());

            output.Attributes.SetAttribute("class", string.Join(" ", clases));
        }
    }
}
