using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Input;

namespace PROG5Her.ViewModel
{
    class GameVM : ViewModelBase

    {
        //vars
        private QuizDBEntities context;
        //properties
        public List<Questionnaire> AllQuestionnaires { get; set; }
        public Questionnaire SelectedQuestionnaire { get; set; }
        public List<Question> QuestionnaireQuestions { get; set; }
        public Question SelectedQuestion { get; set;}
        public List<Answer> QuestionAnswers { get; set; }

        //gamestatistics properties
        public int AmountOfCorrectAnswers { get; set; }

        //Commands  
        public ICommand Answer1Command { get; set; }
        public ICommand Answer2Command { get; set; }
        public ICommand Answer3Command { get; set; }
        public ICommand Answer4Command { get; set; }
        //constructor
        public GameVM()
        {
            context = new QuizDBEntities();
            GetAllQuestionnairesFromDatabase();
            Answer1Command = new RelayCommand();
            Answer2Command = new RelayCommand();
            Answer3Command = new RelayCommand();
            Answer4Command = new RelayCommand();

        }
        //methods
        public void GetAllQuestionnairesFromDatabase()
        {
            using(context)
            {
                AllQuestionnaires = context.Questionnaires.ToList();
            }
        }

        public void GetAllQuestionnaireQuestionsFromDatabase()
        {
            using (context)
            {
                // QuestionnaireQuestions = context.Questions.Where(q => q.Questionnaires. == SelectedQuestionnaire.Id);
                QuestionnaireQuestions = context.Questions.Where(q => q.Questionnaires.Any(qu => qu.Id == SelectedQuestionnaire.Id)).ToList();
            }
        }

        public void GetQuestionAnswersFromDatabase()
        {
            using (context)
            {
                QuestionAnswers = context.Answers.Where(a => a.QuestionID == SelectedQuestion.Id).ToList();
            }
        }

        public void IncreaseAmountOfCorrectAnswers()
        {
            AmountOfCorrectAnswers++;
        }
        
        public void Answer1()
        {

        }
        public void Answer2()
        {

        }
        public void Answer3()
        {

        }
        public void Answer4()
        {

        }


    }
}
