using System.Collections.Generic;
using System.Linq;
using Android.Support.V4.App;

namespace CleanHouse.Adapters
{
    public class TabsFragmentAdapter : FragmentStatePagerAdapter
    {
        private readonly Dictionary<string, Fragment> _tabs;
    
        public override int Count => _tabs.Count;

        public TabsFragmentAdapter(FragmentManager fm) : base(fm)
        {
            _tabs = new Dictionary<string, Fragment>();
        }

        public void AddTub(string name, Fragment tab) => _tabs.TryAdd(name, tab);
    
        public override Fragment GetItem(int position) => _tabs.Values.ToList()[position];
    }
}