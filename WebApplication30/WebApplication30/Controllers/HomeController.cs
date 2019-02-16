using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication30.Models;

namespace WebApplication30.Controllers
{
    public class HomeController : Controller
    {

        private static List<QuizVm> BuildQuizVm(List<Quiz> quizzes)
        {
            var list = new List<QuizVm>();

            foreach (var quiz in quizzes)
            {
                list.Add(new QuizVm(quiz.Id, quiz.QuizText));
            }

            return list;
        }


        [HttpGet]
        public ActionResult Index()
        {
            var loginVm = new LoginVm();
            loginVm.StudentName = "jawadhasan80@gmail.com";
            //This could be read form database
            loginVm.Quizzes.AddRange(BuildQuizVm(InMemoryData.GetQuizData()));
            return View(loginVm);
        }
        

        [HttpPost]
        public ActionResult Index(LoginVm loginVm)
        {
            if (ModelState.IsValid)
            {
                var examVm = new UserSelection(loginVm.QuizId,loginVm.StudentName);
                return RedirectToAction("Exam", examVm);
            }
            loginVm.Quizzes.AddRange(BuildQuizVm(InMemoryData.GetQuizData()));
            return View(loginVm);
        }

        [HttpGet]
        public ActionResult Exam(UserSelection userSelection)
        {
            var quizData = InMemoryData.GetQuizData();
            var quiz = quizData.FirstOrDefault(q => q.Id == userSelection.QuizId);
            if (quiz != null)
            {
                var examVm = BuildExamVm(userSelection.StudentName, quiz);
                return View(examVm);
            }

            return View(new StudentExamViewModel());
        }

        


        [HttpPost]
        public ActionResult Exam(StudentExamViewModel examViewModel)
        {
            var quizes = InMemoryData.GetQuizData();
            var quiz = quizes.FirstOrDefault(q => q.Id == examViewModel.QuizId);

            if (quiz != null)
            {
                var examResult = GetExamResult(examViewModel.StudentName, quiz, examViewModel);
                return View("ExamResult", examResult);
            }
            return View("ExamResult", new ExamResult(examViewModel.StudentName, examViewModel.QuizText, 100, 0));
        }

        public ExamResult GetExamResult(string studentName, Quiz quiz, StudentExamViewModel examViewModel)
        {
            var marksObtained = 0;

            foreach (var question in examViewModel.QuestionsList)
            {
                //find the corresponding actual question
                var actualQuestion = quiz.Questions.FirstOrDefault(q => q.Id == question.QuestionId);
                if (actualQuestion != null)
                {
                    var actualAnswer = actualQuestion.Answers.FirstOrDefault(a => a.IsCorrect);
                    if (actualAnswer != null)
                    {
                        //now check it with given user answer
                        if (question.SelectedAnswerId == actualAnswer.Id)
                        {
                            marksObtained += actualQuestion.Marks;
                        }
                    }
                }
            }
            return new ExamResult(studentName, quiz.QuizText, quiz.TotalMarks, marksObtained);
        }


        private static StudentExamViewModel BuildExamVm(string studentName, Quiz quiz)
        {
            var examVm = new StudentExamViewModel();
            examVm.StudentName = studentName;
            examVm.QuizId = quiz.Id;
            examVm.QuizText = quiz.QuizText;
            foreach (var question in quiz.Questions)
            {
                var questionVm = new QuestionVm(question.QuestionText);
                questionVm.QuestionId = question.Id;
                foreach (var answer in question.Answers)
                {
                    var answerVm = new AnswerVm();
                    answerVm.Id = answer.Id;
                    answerVm.AnswerText = answer.AnswerText;
                    questionVm.Answers.Add(answerVm);
                }

                examVm.QuestionsList.Add(questionVm);
            }

            return examVm;
        }


   


    }
}