using System.Globalization;
using ArcGIS.Desktop.Framework.Contracts;


namespace ProAppCountFeatures
{
    internal class BtnCountPoints : Button
    {
        protected async override void OnClick()
        {
            var points = new SampleQueuedTask();
            var result = await points.CountFeaturesAsyc();
            ArcGIS.Desktop.Framework.Dialogs.MessageBox.Show(result.ToString(CultureInfo.InvariantCulture));
        }
    }
}
