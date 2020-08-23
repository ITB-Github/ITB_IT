using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IT_TeamPointMainScreenInteractor
{
    public interface ScreenBoundary
    {
        string GetNormalScreenInstruction();
        string GetFullScreenInstruction(int screenId);
        string GetScreenInfo();
        string GetScreenPreview();
    }
}
