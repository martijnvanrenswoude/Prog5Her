using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;

namespace PROG5Her.ViewModel
{
    public class QuizEditDeleteViewModel: ViewModelBase
    {
        //vars
        private Questionnaire selectedEditQuiz;
        private Questionnaire selectedDeleteQuiz;
        private String quizName;
        private Categories selectedCategory;
        //properties
        public ObservableCollection<Questionnaire> AllQuizes { get; set; }
        public ObservableCollection<Categories> AllCategories { get; set; }
        public ObservableCollection<Question> SelectedQuestions { get; set; }
        public Questionnaire SelectedEditQuiz
        {

            get { return selectedEditQuiz; }
            set
            {
                selectedEditQuiz = value;
                QuizName = selectedEditQuiz.Name;
                SelectedCategory = getCategory(selectedEditQuiz.Category);
                getSelectedQuestions();
                base.RaisePropertyChanged("SelectedEditQuiz");
            }
        }
        public Questionnaire SelectedDeleteQuiz
        {

            get { return selectedDeleteQuiz; }
            set
            {
                selectedDeleteQuiz = value;
                base.RaisePropertyChanged("SelectedDeleteQuiz");
            }
        }
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
                base.RaisePropertyChanged("SelectedCategory");
            }
        }

        //commands
        public RelayCommand RemoveQuestionCommand { get; set; }
        public RelayCommand DeleteQuizCommand { get; set; }
        public RelayCommand SaveChangesCommand { get; set; }

        //constructor
        public QuizEditDeleteViewModel()
        {
            getAllCategories();
            getAllQuizes();
            //commands
            RemoveQuestionCommand = new RelayCommand(RemoveQuestion);
            DeleteQuizCommand = new RelayCommand(DeleteQuiz);
            SaveChangesCommand = new RelayCommand(SaveChanges);
        }
        
        //funcitons
        private void getSelectedQuestions()
        {
           // SelectedQuestions = new ObservableCollection<Question>(SelectedEditQuiz.Question.ToList());
        }
        private void getAllCategories()
        {
            using (var context = new QuizDBEntities())
            {
                AllCategories = new ObservableCollection<Categories>(context.Categories.ToList());
            }
        }
        private void getAllQuizes()
        {
            AllQuizes = null;
            using (var context = new QuizDBEntities())
            {
                AllQuizes = new ObservableCollection<Questionnaire>(context.Questionnaire.ToList());
            }
        }
        private Categories getCategory(String c)
        {
            foreach(var ct in AllCategories)
            {
                if (ct.category.Equals(c))
                {
                    return ct;
                }
            }
            return null;
        }

        // command functions
        private void RemoveQuestion()
        {
            throw new NotImplementedException();
        }
        private void DeleteQuiz()
        {
            throw new NotImplementedException();
        }

        private void SaveChanges()
        {
            throw new NotImplementedException();
        }
    }
}
