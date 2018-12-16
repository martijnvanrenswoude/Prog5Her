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
        private int amountOfAnswers;
        //Properties
        public List<Category> AllCategories { get; set; }
        public Category SelectedCategory { get; set; }
        public List<Question> AllQuestions { get; set; }
        public Answer[] AllAnswers {get;set;}
        
        public string QuestionName
        {
            get { return question.Question1; }
            set { question.Question1 = value; }
            }

        public int[] PossibleAmountOfAnswers { get; set; }
        public int AmountOfAnswers
        {
            get { return amountOfAnswers; }
            set { amountOfAnswers = value; AllAnswers = new Answer[value]; }
        }

        public Question SelectedQuestion
        {
            get { return this.question; }
            set { this.question = value; }
        }
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
            PossibleAmountOfAnswers = new int[] { 2, 3, 4 };
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
                question.AmountOfAnswers = amountOfAnswers;
                context.Questions.Add(question);
                context.SaveChanges();
            }
            AddAnswer();
            GetAllQuestions();
        }

        public void GetAllQuestions()
        {
            using(var context = new QuizDBEntities())
            {
               AllQuestions = context.Questions.ToList();

            }
            RaisePropertyChanged("AllQuestions");
        }

        public void AddAnswer()
        {
            
            using (var context = new QuizDBEntities())
            {
                for(int i = 0; i < AllAnswers.Length; i++)
                {
                    if(AllAnswers[i] != null)
                    {
                        AllAnswers[i] = new Answer { QuestionID = SelectedQuestion.Id };
                        context.Answers.Add(AllAnswers[i]);
                        context.SaveChanges();
                    }
                }

            }
        }

        public void GetAllAnswers()
        {
            using(var context = new QuizDBEntities())
            {
                AllAnswers = context.Answers.Where(a => a.QuestionID == SelectedQuestion.Id).ToArray();
            }
            RaisePropertyChanged("AllAnswers");
        }

        public void DeleteQuestion()
        {
            using(var context = new QuizDBEntities())
            {
                context.Questions.Attach(question);
                context.Questions.Remove(question);
                context.SaveChanges();
                
            }
            GetAllQuestions();
            RaisePropertyChanged("AllQuestions");
        }
        public void DeleteAnswer()
        {
            using (var context = new QuizDBEntities())
            {
                context.Answers.Attach(SelectedAnswer);
                context.Answers.Remove(SelectedAnswer);
                context.SaveChanges();
            }
        }
        public void GetAllCategories()
        {
            using (var context = new QuizDBEntities())
            {
               AllCategories = context.Categories.ToList();
            }
        }

        public void addToArray()
        {
            for(int i = 0; i < amountOfAnswers; i++)
            {
                if(AllAnswers[i] != null)
                {
                    AllAnswers[i] = SelectedAnswer;
                    break;
                }
            }
        }

    }
}
