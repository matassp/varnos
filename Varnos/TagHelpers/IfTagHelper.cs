using Microsoft.AspNetCore.Razor.TagHelpers;

namespace Varnos.TagHelpers
{
    public class IfTagHelper : TagHelper
    {
        [HtmlAttributeName("include-if")]
        public bool Include { get; set; } = true;

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            output.TagName = null;
            if (Include)
                return;
            output.SuppressOutput();
        }
    }
}
