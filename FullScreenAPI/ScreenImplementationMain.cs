using IT_TeamPointMainScreenInteractor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FullScreenAPI
{
    public class ScreenImplementationMain
    {

        private ScreenImplementation implementation;
        public ScreenImplementationMain()
        {
            implementation = new ScreenImplementation();
        }

        public ScreenBoundary GetScreenBoundary()
        {
            return implementation as ScreenBoundary;
        }
    }
}
