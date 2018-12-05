using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PROG5Her.ViewModel
{
    public class QuestionViewModel : ViewModelBase
    { 
        //Variable
        private Question question;
        //Properties
        public List<Question> AllQuestions { get; set; }
        public List<Answer> AllAnswers { get; set; }
        public String QuestionName { get; set; }
        public Question SelectedQuestion { get; set; }
        //Constructor

        public QuestionViewModel()
        {
            question = new Question();

        }

        public void addQuestion()
        {
            using(var context = new Prog5HerDBEntities())
            {
                context.Questions.Add(question);
                context.SaveChanges();
            }
        }

        public void GetAllQuestions()
        {
            using(var context = new Prog5HerDBEntities())
            {
                AllQuestions = context.Questions.ToList();
            }
        }

    }
}
