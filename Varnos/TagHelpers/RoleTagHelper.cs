using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Razor.Runtime.TagHelpers;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace Varnos.TagHelpers
{
    
    [HtmlTargetElement("role")]
    public class RoleTagHelper : TagHelper
    {
        public string RoleName{get;set;}

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            output.TagName = "a";
            if (!string.IsNullOrEmpty(RoleName))
            {
                output.Content.SetContent("Signed in as: " + RoleName);
            }
        }
    }
}
