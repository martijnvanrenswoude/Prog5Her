using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Windows.Input;

namespace PROG5Her.ViewModel
{
    public class QuestionViewModel : ViewModelBase
    { 
        //Variable
        
        private Question question;
        private Answers answer;
        private int amountOfAnswers;
        //Properties
        public ObservableCollection<Categories> AllCategories { get; set; }
        public Categories SelectedCategory { get; set; }
        public List<Question> AllQuestions { get; set; }
        public Answers[] AllAnswers {get;set;}
        
        public string QuestionName
        {
            get { return question.Question1; }
            set { question.Question1 = value; }
            }

        public int[] PossibleAmountOfAnswers { get; set; }
        public int AmountOfAnswers
        {
            get { return amountOfAnswers; }
            set { amountOfAnswers = value; AllAnswers = new Answers[value]; }
        }

        public Question SelectedQuestion
        {
            get { return this.question; }
            set { this.question = value; GetAllAnswers(); }
        }
        public Answers SelectedAnswer
        {
            get { return answer; }
            set {
                
                answer = value;
                UpdateAnswer();
            }
        }
        public ICommand AddAnswerCommand { get; set; }
        public ICommand AddQuestionCommand { get; set; }
        public RelayCommand DeleteAnswerCommand { get; set; }
        public ICommand DeleteQuestionCommand { get; set; }
        public bool CorrectAnswer
        {
            
            get { if (SelectedAnswer.IsCorrect != null) { return (bool)SelectedAnswer.IsCorrect; }; return false; }
            set { SelectedAnswer.IsCorrect = value; UpdateAnswer(); RaisePropertyChanged("CorrectAnswer"); }
        }
        public string AnswerName {
            get { return SelectedAnswer.Answer; }
            set { SelectedAnswer.Answer = value; UpdateAnswer(); RaisePropertyChanged("AnswerName"); }
        }

        public List<Questionnaire> QuestionQuestionnaires { get; set; }
        public List<Question> QuestionnaireQuestions { get; set; }
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

        //functions
        public void addQuestion()
        {
            using(var context = new QuizDBEntities())
            {
                question.CategoryID = SelectedCategory.ID;
                question.AmountOfAnswers = amountOfAnswers;
                context.Question.Add(question);
                context.SaveChanges();
            }
            AddAnswer();
            GetAllQuestions();
            SelectedCategory = null;
            QuestionName = null;
            PossibleAmountOfAnswers = null;
            
        }

        public void GetAllQuestions()
        {
            using(var context = new QuizDBEntities())
            {
               AllQuestions = context.Question.ToList();

            }
            RaisePropertyChanged("AllQuestions");
            
        }

        public void AddAnswer()
        {            
            using (var context = new QuizDBEntities())
            {
                for(int i = 0; i < AllAnswers.Length; i++)
                {
                    if(AllAnswers[i] == null)
                    {
                        AllAnswers[i] = new Answers { QuestionID = SelectedQuestion.Id };
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
            //using(var context = new QuizDBEntities())
            //{
            //    context.Question.Attach(question);
            //    context.Question.Remove(question);
            //    context.SaveChanges();                
            //}
            //GetAllQuestions();
            //RaisePropertyChanged("AllQuestions");
            AllQuestions.Remove(question);
        }
        public void DeleteAnswer()
        {
            using (var context = new QuizDBEntities())
            {

               // QuestionnaireQuestions = context.Question.Where(q => q.Questionnaire.Any(qu => qu.Id == SelectedQuestionnaire.Id)).ToList();
               //QuestionQuestionnaires = context.Questionnaire.Where(q => q.Question.Any(qu => qu.Id == SelectedQuestion.Id)).ToList();

                context.Answers.Attach(SelectedAnswer);
                context.Answers.Remove(SelectedAnswer);
                context.SaveChanges();
            }
            GetAllQuestions();
            RaisePropertyChanged("AllQuestions");
        }
        public void GetAllCategories()
        {
            using (var context = new QuizDBEntities())
            {
               AllCategories = new ObservableCollection<Categories>(context.Categories.ToList());
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

        public void UpdateAnswer()
        {
            using(var context = new QuizDBEntities())
            {
                context.Answers.Attach(SelectedAnswer);
                context.SaveChanges();
            }
        }

        //public void DeleteFromKoppelTabel()
        //{
        //    using (var context = new QuizDBEntities())
        //    {
        //        var questions = context.Questions.Where(q => q.Questionnaire).ToList();
        //        //q.Questionnaire.SingleOrDefault(q => q.ID = SelectedQuestion.Id)
        //    }
        //}
    }
}
