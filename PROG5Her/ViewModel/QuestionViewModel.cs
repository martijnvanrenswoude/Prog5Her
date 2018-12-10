using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Input;

namespace PROG5Her.ViewModel
{
    public class QuestionViewModel : ViewModelBase
    { 
        //Variable
        private Question question;
        private Answer answer;
        //Properties
        //public List<Category> AllCategories { get; set; }
        //public Category SelectedCategory { get; set; }
        public List<Question> AllQuestions { get; set; }
        public List<Answer> AllAnswers { get; set; }
        public String QuestionName { get; set; }
        public Question SelectedQuestion { get; set; }
        public Answer SelectedAnswer { get; set; }
        public ICommand AddAnswerCommand { get; set; }
        public bool CorrectAnswer
        {
            get { if (SelectedAnswer.IsCorrect != null) { return (bool)SelectedAnswer.IsCorrect; }; return false; }
            set { SelectedAnswer.IsCorrect = value; }
        }
        //Constructor

        public QuestionViewModel()
        {
            question = new Question();


        }

        public void addQuestion()
        {
            using(var context = new QuizDBEntities())
            {
                context.Questions.Add(question);
                context.SaveChanges();
            }
        }

        public void GetAllQuestions()
        {
            using(var context = new QuizDBEntities())
            {
               AllQuestions = context.Questions.ToList();
            }
        }

        public void AddAnswer()
        {
            answer = new Answer();
            answer.QuestionID = SelectedQuestion.Id;
            AllAnswers.Add(answer);
            using (var context = new QuizDBEntities())
            {
                context.Answers.Add(answer);
            }
        }


    }
}
