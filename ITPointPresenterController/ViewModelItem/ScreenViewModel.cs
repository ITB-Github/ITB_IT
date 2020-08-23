using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace ITPointPresenterController
{
    public class ScreenViewModel
    {
        public int Id { get; set; }
        public ImageSource Image { get; set; }
        public ScreenViewModel()
        {
            Id = -1;
            Image = Converter.ByteToImage(Utils.Converter.FromBase64ToBytes(Resource.NoImageBase64));
        }

        public ScreenViewModel(int id, ImageSource img)
        {
            Id = id;
            Image = img;
        }

    }
}
