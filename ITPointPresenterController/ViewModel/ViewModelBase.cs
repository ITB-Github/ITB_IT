using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITPointPresenterController
{
    public abstract class ViewModelBase : INotifyPropertyChanged
    {
        [AttributeUsage(AttributeTargets.Property, AllowMultiple = true)]
        protected class DependsUponAttribute : Attribute
        {
            public string DependancyName { get; private set; }

            public DependsUponAttribute(string propertyName)
            {
                DependancyName = propertyName;
            }
        }

        protected virtual void RaisePropertyChanged(string propertyName)
        {
            var handlers = PropertyChanged;
            if (handlers != null)
            {
                foreach (var property in AllNotifiedProperties(propertyName))
                    handlers(this, new PropertyChangedEventArgs(property));
            }
        }

        private IEnumerable<string> DependantProperties(string inputName)
        {
            return from property in GetType().GetProperties()
                   where property.GetCustomAttributes(typeof(DependsUponAttribute), true).Cast<DependsUponAttribute>()
                         .Any(attribute => attribute.DependancyName == inputName)
                   select property.Name;
        }

        private IEnumerable<string> NotifiedProperties(IEnumerable<string> inputs)
        {
            var dependancies = from input in inputs
                               from dependancy in DependantProperties(input)
                               select dependancy;

            return inputs.Union(dependancies).Distinct();
        }

        private IEnumerable<string> AllNotifiedProperties(string inputName)
        {
            IEnumerable<string> results = new[] { inputName };

            while (NotifiedProperties(results).Count() > results.Count())
                results = NotifiedProperties(results);

            return results;
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
