using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sitecore.Pipelines.GetRenderingDatasource;
using Sitecore.Data.Fields;

namespace Training.Utilities.BaseCore.Pipelines
{
   public  class SetAllowedCreate
   {
         public void Process(GetRenderingDatasourceArgs args)
         {
             CheckboxField allow_create = args.RenderingItem.Fields["allow create"];            

             if (allow_create != null && !allow_create.Checked)
             {
                 args.Prototype = null;
             }
         }
    }
}
