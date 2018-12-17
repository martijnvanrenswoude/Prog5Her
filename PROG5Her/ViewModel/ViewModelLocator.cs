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

    public class ViewModelLocator
    {

        public ViewModelLocator()
        {
            ServiceLocator.SetLocatorProvider(() => SimpleIoc.Default);

            SimpleIoc.Default.Register<MainViewModel>();
            SimpleIoc.Default.Register<QuestionViewModel>();
            SimpleIoc.Default.Register<QuizViewModel>();
            SimpleIoc.Default.Register<HomeViewModel>();
            SimpleIoc.Default.Register<GameVM>();
        }

        public MainViewModel Main
        {
            get
            {
                return ServiceLocator.Current.GetInstance<MainViewModel>();
            }
        }

        public QuestionViewModel QuestionVM => ServiceLocator.Current.GetInstance<QuestionViewModel>();
        public QuizViewModel QuizVM => ServiceLocator.Current.GetInstance<QuizViewModel>();
        public HomeViewModel HomeVM => ServiceLocator.Current.GetInstance<HomeViewModel>();
        public GameVM GameVM => ServiceLocator.Current.GetInstance<GameVM>();


        public static void Cleanup()
        {

        }
    }
}