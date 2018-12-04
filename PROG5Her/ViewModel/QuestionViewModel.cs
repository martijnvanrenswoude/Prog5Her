using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PROG5Her.ViewModel
{
    class QuestionViewModel : ViewModelBase


    {

        //Variable
        private Question question;
        //Properties
        //Constructor

        public QuestionViewModel()
        {
            question = new Question();

        }
    }
}
