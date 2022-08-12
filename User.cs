using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizApp
{
    internal struct User
    {
        public string Name;
        public int NumberOfCorrectAnswers;
        public int NumberOfQuestions;

        public User(string name, int numberOfCorrectAnswers, int numberOfQuestions)
        {
            Name = name;
            NumberOfCorrectAnswers = numberOfCorrectAnswers;
            NumberOfQuestions = numberOfQuestions;
        }
    }
}
