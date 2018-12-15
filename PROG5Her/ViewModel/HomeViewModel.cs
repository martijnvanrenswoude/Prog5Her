using GalaSoft.MvvmLight.Command;
using PROG5Her.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace PROG5Her.ViewModel
{
    public class HomeViewModel
    {
        //vars
        private AddQuestionAndAnswerView questionCrudView;
        private QuizCRUDView quizCrudView;
        //properties
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
        //commands
        public RelayCommand OpenQuestionCrudViewCommand { get; set; }
        public RelayCommand OpenQuizCrudViewCommand { get; set; }
        //constructor
        public HomeViewModel()
        {
            //set commands
            OpenQuestionCrudViewCommand =   new RelayCommand(OpenQuestionCrudView);
            OpenQuizCrudViewCommand =       new RelayCommand(OpenQuizCrudView);
        }
        //functions

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
    }
}
