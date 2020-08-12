using Prism.Mvvm;

namespace Cardan.PlanChecker18.ViewModels
{
    public class MainViewModel : BindableBase
    {
        private string _title = "ESAPIX Starter Application";
        public string Title
        {
            get { return _title; }
            set { SetProperty(ref _title, value); }
        }

        public MainViewModel()
        {

        }
    }
}
