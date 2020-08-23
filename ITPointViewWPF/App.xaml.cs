using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using HardDrive;
using SQLserverConnect;
using FullScreenAPI;
using IT_TeamPointMainScreenInteractor;
using ITPointPresenterController;
using FileOpenerAPI;

namespace ITPointViewWPF
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        [STAThread]
        public static void Main()
        {
            Application app = new Application();

            HDMain hdMain = new HDMain();
            SQLserverConnectMain sqlMain = new SQLserverConnectMain();
            ScreenImplementationMain screenMain = new ScreenImplementationMain();
            FileOpenerServiceMain fileService = new FileOpenerServiceMain();
            //
            ViewMain viewMain = new ViewMain();
            //
            ITPointPresenterControllerMain pcMain = new
                ITPointPresenterControllerMain(
                    viewMain.GetITControlViewModel(),
                    viewMain.GetPreviewViewModel(),
                    viewMain.GetOverviewViewModel()
                );
            //
            IT_Control_InteractorMain interactorMain = new
                IT_Control_InteractorMain(hdMain.GetHardDriveGateway(),
                screenMain.GetScreenBoundary(),
                sqlMain.GetPointDataGateway(),
                pcMain.GetOutputBoundary(),
                fileService.GetFileOpenerAPI());
            //
            pcMain.AttachInputBoundary(interactorMain.GetInputBoundary());
            //
            app.Run(viewMain.GetMainWindow());

            //app.Run(new OverviewView());

        }
    }
}
