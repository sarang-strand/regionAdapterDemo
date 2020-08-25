using Prism.Regions;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace demo
{
    class StackRegionAdapter : RegionAdapterBase<StackPanel>
    {
        public StackRegionAdapter(IRegionBehaviorFactory regionBehaviorFactory)
            : base(regionBehaviorFactory)
        {

        }

        protected override void Adapt(IRegion region, StackPanel regionTarget)
        {
            region.Views.CollectionChanged += (s, e) =>
            {
                if (e.Action == System.Collections.Specialized.NotifyCollectionChangedAction.Add)
                {
                    //MessageBox.Show("Adapt is called for adding views!!");
                    foreach (FrameworkElement element in e.NewItems)
                    {
                        regionTarget.Children.Add(element);
                    }
                }

                else if (e.Action == System.Collections.Specialized.NotifyCollectionChangedAction.Remove)
                {
                    int i = region.Views.Count();
                    string msg = "Removing view number {0}!!";
                    MessageBox.Show(string.Format(msg, region.Views.Count()));
                    regionTarget.Children.RemoveAt(regionTarget.Children.Count - 1);
                }
            };
        }

        protected override IRegion CreateRegion()
        {
            return new Region();
        }
    }
}
