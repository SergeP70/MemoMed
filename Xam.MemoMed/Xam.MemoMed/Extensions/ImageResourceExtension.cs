using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Xam.MemoMed.Extensions
{
    /// <summary>
    /// XAML extensie om embedded afbeeldingen in XAML weer te geven
    /// </summary>
    [ContentProperty("Source")]
    public class ImageResourceExtension : IMarkupExtension
    {
        public string Source { get; set; }
        public object ProvideValue(IServiceProvider serviceProvider)
        {
            if (Source==null)
            {
                return null;
            }
            // Get the ImageSource based on the given ResourceId
            var imageSource = ImageSource.FromResource(Source);
            return imageSource;
        }
    }
}
