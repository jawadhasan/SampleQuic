using System;
using System.Collections.Generic;

namespace WebApplication30.Models
{
    public static class InMemoryData
    {
        public static List<Quiz> GetQuizData()
        {
            var quizData = new List<Quiz>();

            var quiz1 = new Quiz();
            quiz1.Id = "quiz1";
            quiz1.CreationDate = DateTime.UtcNow;
            quiz1.QuizText = "Quiz about Web Technologies";
            quiz1.Questions.Add(new Question
            {
                Id = "question1",
                QuestionText = "HTML stands for?",
                Marks = 50,
                Answers = new List<Answer>
                {
                    new Answer
                    {
                        Id = "a1",
                        AnswerText = "Hyper Tel Mark Language",
                        IsCorrect = false
                    },
                    new Answer
                    {
                        Id = "a2",
                        AnswerText = "Hyper Text Markup Language",
                        IsCorrect = true
                    }
                }
            });
            quiz1.Questions.Add(new Question
            {
                Id = "question2",
                QuestionText = "Angular is what type of Framework?",
                Marks = 100,
                Answers = new List<Answer>
                {
                    new Answer
                    {
                        Id = "a101",
                        AnswerText = "Front-End",
                        IsCorrect = true
                    },
                    new Answer
                    {
                        Id = "a102",
                        AnswerText = "Back-End",
                        IsCorrect = false
                    }
                }
            });
            quiz1.Questions.Add(new Question
            {
                Id = "question3",
                QuestionText = "Who is powerful avenger?",
                Marks = 200,
                Answers = new List<Answer>
                {
                    new Answer
                    {
                        Id = "a201",
                        AnswerText = "Captain America",
                        IsCorrect = true
                    },
                    new Answer
                    {
                        Id = "a202",
                        AnswerText = "Hulk",
                        IsCorrect = false
                    },
                    new Answer
                    {
                        Id = "a203",
                        AnswerText = "Iron Man",
                        IsCorrect = false
                    }
                }
            });
            quizData.Add(quiz1);



            var quiz2 = new Quiz();
            quiz2.Id = "quiz2";
            quiz2.CreationDate = DateTime.UtcNow;
            quiz2.QuizText = "Quiz about C#";
            quiz2.Questions.Add(new Question
            {
                Id = "questionc1",
                QuestionText = "C# is a statically typed language?",
                Marks = 50,
                Answers = new List<Answer>
                {
                    new Answer
                    {
                        Id = "ca1",
                        AnswerText = "No",
                        IsCorrect = false
                    },
                    new Answer
                    {
                        Id = "ca2",
                        AnswerText = "yes",
                        IsCorrect = true
                    }
                }
            });
            quiz2.Questions.Add(new Question
            {
                Id = "questionc2",
                QuestionText = "Multiple Inhertiance is supported in C#?",
                Marks = 150,
                Answers = new List<Answer>
                {
                    new Answer
                    {
                        Id = "ca21",
                        AnswerText = "No",
                        IsCorrect = true
                    },
                    new Answer
                    {
                        Id = "ca22",
                        AnswerText = "yes",
                        IsCorrect = false
                    }
                }
            });

            quizData.Add(quiz2);



            return quizData;
        }
    }
}