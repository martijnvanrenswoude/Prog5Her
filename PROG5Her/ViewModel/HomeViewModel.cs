using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using PROG5Her.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace PROG5Her.ViewModel
{
    public class HomeViewModel : ViewModelBase
    {
        //vars
        private AddQuestionAndAnswerView questionCrudView;
        private QuizCRUDView quizCrudView;
        //properties
        public Questionnaire SelectedQuiz { get; set; }
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
        public List<Questionnaire> AllQuizes { get; set; }
        //commands
        public RelayCommand PlayQuizCommand { get; set; }
        public RelayCommand OpenQuestionCrudViewCommand { get; set; }
        public RelayCommand OpenQuizCrudViewCommand { get; set; }
        //constructor
        public HomeViewModel()
        {
            //lists
            getAllQuizes();
            //set commands
            PlayQuizCommand =               new RelayCommand(PlayQuiz);
            OpenQuestionCrudViewCommand =   new RelayCommand(OpenQuestionCrudView);
            OpenQuizCrudViewCommand =       new RelayCommand(OpenQuizCrudView);
        }
        //functions
        private void getAllQuizes()
        {
            using (var context = new QuizDBEntities())
            {
                AllQuizes = context.Questionnaires.ToList();
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
            QuizCrudView = new QuizCRUDView();
            QuizCrudView.Show();
        }

        private void PlayQuiz()
        {
            throw new NotImplementedException();
        }
    }
}
