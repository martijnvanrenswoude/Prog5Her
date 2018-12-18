using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using PROG5Her.View;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;


namespace PROG5Her.ViewModel
{
    public class HomeViewModel : ViewModelBase
    {
        //vars
        public QuizCRUDView quizCrudView;
        private AddQuestionAndAnswerView questionCrudView;
        private AddNewQuiz newQuizView;
        private GameView gameView;
        private Questionnaire selectedQuiz;
        //properties
        public Questionnaire SelectedQuiz
        {
            get{ return selectedQuiz; }
            set
            {
                selectedQuiz = value;
                base.RaisePropertyChanged("SelectedQuiz");         
            }
        }
        public AddQuestionAndAnswerView QuestionCrudView
        {
            get {return questionCrudView;}
            set { questionCrudView = value; }
        }
        public QuizCRUDView QuizCrudView
        {
            get { return quizCrudView; }
            set { quizCrudView = value; }
        }
        public ObservableCollection<Questionnaire> AllQuizes { get; set; }
        //commands
        public RelayCommand PlayQuizCommand { get; set; }
        public RelayCommand OpenQuestionCrudViewCommand { get; set; }
        public RelayCommand OpenQuizCrudViewCommand { get; set; }

        public RelayCommand OpenNewQuizViewCommand { get; set; }
        //constructor
        public HomeViewModel()
        {
            //lists
            getAllQuizes();
            //set commands
            PlayQuizCommand =               new RelayCommand(PlayQuiz);
            OpenQuestionCrudViewCommand =   new RelayCommand(OpenQuestionCrudView);
            OpenQuizCrudViewCommand =       new RelayCommand(OpenQuizCrudView);
            OpenNewQuizViewCommand = new RelayCommand(openNewQuizView);
        }
        //functions
        private void getAllQuizes()
        {
            using (var context = new QuizDBEntities())
            {
                AllQuizes = new ObservableCollection<Questionnaire>(context.Questionnaire.ToList());
            }
        }
        //command functions
        private void OpenQuestionCrudView()
        {
            QuestionCrudView = new AddQuestionAndAnswerView();
            QuestionCrudView.Show();
        }
        private void OpenQuizCrudView()
        {
            quizCrudView = new QuizCRUDView();
            quizCrudView.Show();
        }
        private void openNewQuizView()
        {
            newQuizView = new AddNewQuiz();
            newQuizView.Show();
        }
        private void PlayQuiz()
        {
            gameView = new GameView();
            gameView.Show();
        }
    }
}
