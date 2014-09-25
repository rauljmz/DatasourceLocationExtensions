using Sitecore.Data.Items;
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
    public class GetDatasourceLocationWithQuery
    {
        private static string PREFIX = "query:";
        public void Process(GetRenderingDatasourceArgs args)
        {
            Assert.IsNotNull((object)args, "args");
            foreach (string str in new ListString(args.RenderingItem["Datasource Location"]))
            {
                string path = str;
                if (path.StartsWith(PREFIX))
                {
                    var location = args.ContentDatabase.GetItem(args.ContextItemPath).Axes.SelectSingleItem(path.Substring(PREFIX.Length));
                    if (location != null) args.DatasourceRoots.Add(location);
                }
                else
                {
                    //support relative paths without the need for a query
                    if (str.StartsWith("./", StringComparison.InvariantCulture) && !string.IsNullOrEmpty(args.ContextItemPath))
                        path = args.ContextItemPath + str.Remove(0, 1);
                    Item obj = args.ContentDatabase.GetItem(path);
                    if (obj != null)
                        args.DatasourceRoots.Add(obj);
                }
            }
        }
    }
}
