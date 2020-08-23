using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace ITPointPresenterController
{
    public class PreviewViewModel : ViewModelBase
    {
        PreviewIController _iCtrl;
        public void AttachController(PreviewIController iCtrl)
        {
            _iCtrl = iCtrl;
        }
        ObservableCollection<ScreenViewModel> _Screens;
        public ObservableCollection<ScreenViewModel> Screens
        {
            get
            {
                return _Screens;
            }
            set
            {
                _Screens = value;
                RaisePropertyChanged("Screens");
            }
        }

        ScreenViewModel _ScreenChosen;
        public ScreenViewModel ScreenChosen
        {
            get
            {
                return _ScreenChosen;
            }
            set
            {
                _ScreenChosen = value;
                RaisePropertyChanged("ScreenChosen");
            }
        }

        Visibility _Visible;
        public Visibility Visible
        {
            get
            {
                if (Designer.IsDesignMode)
                    return Visibility.Visible;
                return _Visible;
            }
            set
            {
                _Visible = value;
                RaisePropertyChanged("Visible");
            }
        }

        public PreviewViewModel()
        {
            Screens = new ObservableCollection<ScreenViewModel>();
            ScreenViewModel screen = new ScreenViewModel();
            Screens.Add(screen);

            ScreenChosen = screen;

            Visible = Visibility.Collapsed;
        }

        ///

        public void ChooseScreen()
        {
            if (ScreenChosen.Id < 0 || _iCtrl == null)
            {
                return;
            }

            _iCtrl.ChooseScreen(ScreenChosen.Id);
        }
    }
}
