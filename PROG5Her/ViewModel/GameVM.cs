﻿using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Input;

namespace PROG5Her.ViewModel
{
    class GameVM : ViewModelBase

        //raisepropertychangen
        //view maken
    {
        //vars
        private QuizDBEntities context;
        private int questionlistindex;
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
        public ICommand StartQuizCommand { get; set; }
        //constructor
        public GameVM()
        {
            context = new QuizDBEntities();
            GetAllQuestionnairesFromDatabase();
            Answer1Command = new RelayCommand(Answer1);
            Answer2Command = new RelayCommand(Answer2);
            Answer3Command = new RelayCommand(Answer3);
            Answer4Command = new RelayCommand(Answer4);
            StartQuizCommand = new RelayCommand(StartNewQuiz);
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
                RaisePropertyChanged("QuestionAnswers");
            }
        }

        public void IncreaseAmountOfCorrectAnswers()
        {
            AmountOfCorrectAnswers++;
        }
        
        public void Answer1()
        {
            if (QuestionAnswers[0] != null)
            {
                if (QuestionAnswers[0].IsCorrect == true)
                {
                    IncreaseAmountOfCorrectAnswers();
                }
            }

        }
        public void Answer2()
        {
            if (QuestionAnswers[1] != null)
            {
                if (QuestionAnswers[1].IsCorrect == true)
                {
                    
                    IncreaseAmountOfCorrectAnswers();
                }
            }
        }
        public void Answer3()
        {
            if (QuestionAnswers[2] != null)
            {
                if (QuestionAnswers[2].IsCorrect == true)
                {
                    IncreaseAmountOfCorrectAnswers();
                }
                GetNewQuestion();
            }

        }
        public void Answer4()
        {
            if(QuestionAnswers[3] != null)
            {
                if (QuestionAnswers[3].IsCorrect == true)
                {
                    IncreaseAmountOfCorrectAnswers();
                }
                GetNewQuestion();
            }
        }

        public void GetNewQuestion()
        {
            if(QuestionnaireQuestions[questionlistindex] != null)
            {
                SelectedQuestion = QuestionnaireQuestions[questionlistindex];
                GetQuestionAnswersFromDatabase();
                RaisePropertyChanged("SelectedQuestion");
            }
            questionlistindex++;
        }

        public void StartNewQuiz()
        {
            GetAllQuestionnaireQuestionsFromDatabase();
            GetNewQuestion();
        }
    }
}
