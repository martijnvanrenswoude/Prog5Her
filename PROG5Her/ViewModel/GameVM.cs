using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PROG5Her.ViewModel
{
    class GameVM : ViewModelBase

    {
        //vars
        //properties
        public List<Questionnaire> AllQuestionnaires { get; set; }
        public Questionnaire SelectedQuestionnaire { get; set; }

        //constructor
        public GameVM()
        {

        }
        //methods
        public void GetAllQuestionnairesFromDatabase()
        {
            using(var context = new QuizDBEntities())
            {
                AllQuestionnaires = context.Questionnaires.ToList();
            }
        }
    }
}
