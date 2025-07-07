using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace repro_wpffluent_datagrid
{

    public sealed class CachedTabControl : TabControl
    {
        private readonly Dictionary<object, FrameworkElement> _cache = new();

        protected override void OnSelectionChanged(SelectionChangedEventArgs e)
        {
            if (e.AddedItems.Count > 0)
            {
                var vm = e.AddedItems[0];
                var tabItem = (TabItem)ItemContainerGenerator.ContainerFromItem(vm);

                if (!_cache.TryGetValue(vm, out var view))
                {
                    var template = TryFindResource(new DataTemplateKey(vm.GetType()))
                                   as DataTemplate
                                   ?? throw new InvalidOperationException(
                                          $"No DataTemplate found for {vm.GetType().Name}!");

                    view = (FrameworkElement)template.LoadContent();
                    view.DataContext = vm;
                    _cache[vm] = view;
                }

                tabItem.Content = view;
            }

            base.OnSelectionChanged(e);
        }

        // Cache aufräumen, falls Items entfernt werden
        protected override void OnItemsChanged(NotifyCollectionChangedEventArgs e)
        {
            base.OnItemsChanged(e);
            if (e.Action is NotifyCollectionChangedAction.Remove or NotifyCollectionChangedAction.Replace)
                foreach (var old in e.OldItems.Cast<object>())
                    _cache.Remove(old);
            if (e.Action == NotifyCollectionChangedAction.Reset)
                _cache.Clear();
        }
    }
}
