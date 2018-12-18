/*
  In App.xaml:
  <Application.Resources>
      <vm:ViewModelLocator xmlns:vm="clr-namespace:PROG5Her"
                           x:Key="Locator" />
  </Application.Resources>
  
  In the View:
  DataContext="{Binding Source={StaticResource Locator}, Path=ViewModelName}"

  You can also use Blend to do all this with the tool's support.
  See http://www.galasoft.ch/mvvm
*/

using CommonServiceLocator;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Ioc;


namespace PROG5Her.ViewModel
{
    /// <summary>
    /// This class contains static references to all the view models in the
    /// application and provides an entry point for the bindings.
    /// </summary>
    public class ViewModelLocator
    {
        /// <summary>
        /// Initializes a new instance of the ViewModelLocator class.
        /// </summary>
        public ViewModelLocator()
        {
            ServiceLocator.SetLocatorProvider(() => SimpleIoc.Default);

            ////if (ViewModelBase.IsInDesignModeStatic)
            ////{
            ////    // Create design time view services and models
            ////    SimpleIoc.Default.Register<IDataService, DesignDataService>();
            ////}
            ////else
            ////{
            ////    // Create run time view services and models
            ////    SimpleIoc.Default.Register<IDataService, DataService>();
            ////}

            SimpleIoc.Default.Register<MainViewModel>();
            SimpleIoc.Default.Register<HomeViewModel>();
            SimpleIoc.Default.Register<QuestionViewModel>();
            SimpleIoc.Default.Register<QuizEditDeleteViewModel>();
            

        }

        public MainViewModel Main
        {
            get
            {
                return ServiceLocator.Current.GetInstance<MainViewModel>();
            }
        }

        public HomeViewModel HomeVM
        {
            get
            {
                return ServiceLocator.Current.GetInstance<HomeViewModel>();
            }
        }
        public QuestionViewModel QuestionVM
        {
            get
            {
                return ServiceLocator.Current.GetInstance<QuestionViewModel>();
            }
        }
        public QuizEditDeleteViewModel QuizEditDeleteVM
        {
            get
            {
                return ServiceLocator.Current.GetInstance<QuizEditDeleteViewModel>();
            }
        }

        public QuizViewModel QuizVM
        {
            get
            {
                return new QuizViewModel();
            }
        }

        public GameVM GameVM
        {
            get
            {
                return new GameVM(HomeVM.SelectedQuiz);
            }
        }


        public static void Cleanup()
        {
            // TODO Clear the ViewModels
        }
    }
}