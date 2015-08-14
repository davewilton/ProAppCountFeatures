using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using ArcGIS.Core.Data;
using ArcGIS.Desktop.Framework.Threading.Tasks;
using ArcGIS.Desktop.Mapping;

namespace ProAppCountFeatures
{
    class SampleQueuedTask
    {

        public Task<int> CountFeaturesAsyc()
        {
            Func<int> methodToCall = CountFeatures;
            return QueuedTask.Run(methodToCall);

        }

        private static int CountFeatures()
        {
            // You can now access fine grained API's and
            // edit here whilst debugging

            //get the layer
            var activeMap = MapView.Active.Map;

            //get the first feature layer
            var featureLayer = activeMap.GetLayersAsFlattenedList().OfType<FeatureLayer>().FirstOrDefault();
            if (featureLayer == null) throw new Exception();

            //get the underlying feature class for each layer
            var featureClass = featureLayer.GetTable() as FeatureClass;
            if (featureClass == null) throw new Exception("No feature class in map");

            var featCursor = featureClass.Search(null, false);
            //loop through the features and count
            var i = 0;
            while (featCursor.MoveNext())
            {
                i++;
            }
            return i;
        }

    }
}
