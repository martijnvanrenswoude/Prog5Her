using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
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
        public List<Category> AllCategories { get; set; }
        public Category SelectedCategory { get; set; }
        public List<Question> AllQuestions { get; set; }
        public List<Answer> AllAnswers { get; set; }
        public string QuestionName
        {
            get { return question.Question1; }
            set { question.Question1 = value; }
            }
        public Question SelectedQuestion { get; set; }
        public Answer SelectedAnswer { get; set; }
        public ICommand AddAnswerCommand { get; set; }
        public ICommand AddQuestionCommand { get; set; }
        public ICommand DeleteAnswerCommand { get; set; }
        public ICommand DeleteQuestionCommand { get; set; }
        public bool CorrectAnswer
        {
            get { if (SelectedAnswer.IsCorrect != null) { return (bool)SelectedAnswer.IsCorrect; }; return false; }
            set { SelectedAnswer.IsCorrect = value; }
        }
        public string AnswerName {
            get { return answer.Answer1; }
            set { answer.Answer1 = value; }
        }
        //Constructor

        public QuestionViewModel()
        {
            question = new Question();
            GetAllCategories();
            GetAllQuestions();
            AddAnswerCommand = new RelayCommand(AddAnswer);
            AddQuestionCommand = new RelayCommand(addQuestion);
            DeleteAnswerCommand = new RelayCommand(DeleteAnswer);
            DeleteQuestionCommand = new RelayCommand(DeleteQuestion);
        }

        public void addQuestion()
        {
            using(var context = new QuizDBEntities())
            {
                question.CategoryID = SelectedCategory.ID;
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

        public void DeleteQuestion()
        {
            using(var context = new QuizDBEntities())
            {
                context.Questions.Remove(SelectedQuestion);
            }
        }
        public void DeleteAnswer()
        {
            using (var context = new QuizDBEntities())
            {
                context.Answers.Remove(SelectedAnswer);
            }
        }
        public void GetAllCategories()
        {
            using (var context = new QuizDBEntities())
            {
               AllCategories = context.Categories.ToList();
            }
        }


    }
}
