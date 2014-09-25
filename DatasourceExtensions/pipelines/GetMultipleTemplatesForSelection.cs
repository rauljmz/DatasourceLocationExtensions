using Sitecore.Data.Fields;
using Sitecore.Data.Items;
using Sitecore.Data.Managers;
using Sitecore.Diagnostics;
using Sitecore.Pipelines.GetRenderingDatasource;
using Sitecore.Text;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Training.Utilities.BaseCore.Pipelines
{
    public class GetMultipleTemplatesForSelection
    {
        public void Process(GetRenderingDatasourceArgs args)
        {
            foreach (string str in new ListString(args.RenderingItem["Allowed Templates"]))
            {
                var template = TemplateManager.GetTemplate(str, args.ContentDatabase);
                if (template != null)
                {
                    args.TemplatesForSelection.Add(template);
                }
            }
        }
    }
}
