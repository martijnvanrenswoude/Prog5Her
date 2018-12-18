using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Windows;

namespace PROG5Her.ViewModel
{
    public class QuizViewModel : ViewModelBase
    {
        //vars
        private Categories selectedCategory;
        private Question selectedQuestion;
        private String quizName;
        private Questionnaire selectedQuiz;

        //properties
        public ObservableCollection<Categories> AllCategories { get; set; }
        public ObservableCollection<Question> SelectedQuestions { get; set; }
        public ObservableCollection<Question> PossibleQuestions { get; set; }
        public ObservableCollection<Questionnaire> AllQuizes { get; set; }
        public String QuizName
        {
            get { return quizName; }
            set
            {
                quizName = value;
                RaisePropertyChanged("QuizName");
            }
        }
        public Categories SelectedCategory
        {

            get { return selectedCategory; }
            set
            {
                selectedCategory = value;
                getAllCategoryQuestions();
                emptySelectedQuestions();
                base.RaisePropertyChanged("SelectedCategory");
            }
        }
        public Question SelectedQuestion 
        {
            get { return selectedQuestion; }
            set
            {
                selectedQuestion = value;
            }
        }
        public Questionnaire SelectedQuiz
        {

            get { return selectedQuiz; }
            set
            {
                selectedQuiz = value;
                base.RaisePropertyChanged("SelectedQuiz");
            }
        }

        //commands
        public RelayCommand AddQuestionCommand { get; set; }
        public RelayCommand AddQuizCommand { get; set; }
        public RelayCommand DeleteQuizCommand { get; set; }
        //constructor
        public QuizViewModel()
        {            
            getAllCategories();
            getAllQuizes();
            SelectedQuestions = new ObservableCollection<Question>();
            PossibleQuestions = new ObservableCollection<Question>();
            //commands
            AddQuestionCommand =    new RelayCommand(addQuestion);
            AddQuizCommand =        new RelayCommand(addQuiz);
            DeleteQuizCommand =     new RelayCommand(deleteQuiz);
        }
        //functions
        private void emptyPossibleQuestions()
        {
            while(PossibleQuestions.Count > 0)
            {
                PossibleQuestions.RemoveAt(0);
            }
        }
        private void emptySelectedQuestions()
        {
            while (SelectedQuestions.Count > 0)
            {
                SelectedQuestions.RemoveAt(0);
            }
        }
        private void getAllCategories()
        {
            using (var context = new QuizDBEntities())
            {
                AllCategories = new ObservableCollection<Categories>(context.Categories.ToList());
            }
        }
        private void getAllCategoryQuestions()
        {
            emptyPossibleQuestions();
            ObservableCollection<Question> temp;
            using (var context = new QuizDBEntities())
            {
                temp = new ObservableCollection<Question>(context.Question.ToList());
            }
            for(int i=0;i<temp.Count;i++)
            {
                if(temp[i].CategoryID == SelectedCategory.ID)
                {
                    PossibleQuestions.Add(temp[i]);
                    
                }
            }
            RaisePropertyChanged("PossibleQuestions");
        }
        private void getAllQuizes()
        {
            AllQuizes = null;
            using (var context = new QuizDBEntities())
            {
                AllQuizes = new ObservableCollection<Questionnaire>(context.Questionnaire.ToList());
            }
        }
        //command functions
        private void addQuestion()
        {
            if(SelectedQuestion != null && SelectedQuestions.Count < 10)
            {
                SelectedQuestions.Add(SelectedQuestion);
            }            
        }

        private void deleteQuiz()
        {
           
            using (var context = new QuizDBEntities())
            {                
                context.Questionnaire.Attach(SelectedQuiz);
                context.Questionnaire.Remove(SelectedQuiz);
                context.SaveChanges();
            }
            AllQuizes.Remove(SelectedQuiz);
            RaisePropertyChanged("AllQuestions");           
        }
        private void addQuiz()
        {
            if(QuizName != null && SelectedCategory !=null && SelectedQuestions.Count >= 2 && SelectedQuestions.Count <= 10)
            {
                Questionnaire q = new Questionnaire();
                q.Name = QuizName;
                q.Category = SelectedCategory.category;
                using (var context = new QuizDBEntities())
                {
                    foreach (var qw in SelectedQuestions)
                    {
                       q.Question.Add(qw);
                    }
                    context.Questionnaire.Add(q);
                    context.SaveChanges();
                }
                QuizName = null;
                emptySelectedQuestions();
                getAllQuizes();
            }  
        }
    }
}
