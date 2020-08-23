using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace ITPointPresenterController
{
    public static class Designer
    {
        private static readonly bool isDesignMode;
        public static bool IsDesignMode
        {
            get { return isDesignMode; }
        }
        static Designer()
        {
            DependencyProperty prop =
                DesignerProperties.IsInDesignModeProperty;
            isDesignMode =
                (bool)DependencyPropertyDescriptor.
                    FromProperty(prop, typeof(FrameworkElement))
                          .Metadata.DefaultValue;
        }
    }
}
