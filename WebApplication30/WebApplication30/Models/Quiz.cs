using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace WebApplication30.Models
{
    public class Quiz
    {
        public string Id { get; set; }
        public DateTime CreationDate { get; set; }
        public string QuizText { get; set; }
        public virtual List<Question> Questions { get; set; }

        public int TotalMarks => Questions.Sum(q => q.Marks);

        public Quiz()
        {
            Questions = new List<Question>();
        }
    }

    public class Question
    {
        public string Id { get; set; }
        public string QuestionText { get; set; }
        public int Marks { get; set; }
        public virtual List<Answer> Answers { get; set; }

        public Question()
        {
            Answers = new List<Answer>();
        }
    }

    public class Answer
    {
        public string Id { get; set; }
        public string AnswerText { get; set; }
        public bool IsCorrect { get; set; }
    }


    public class LoginVm
    {
        [DisplayName("Student Name")]
        [Required]
        public string StudentName { get; set; }

        [DisplayName("Quiz")]
        [Required]
        public string QuizId { get;set;}
        public List<QuizVm> Quizzes { get; set; }

        public LoginVm()
        {
            Quizzes = new List<QuizVm>();
        }
    }
    public class QuizVm
    {
        public string Id { get; set; }
        public string Text { get; set; }

        public QuizVm()
        {
        }
        public QuizVm(string id, string text)
        {
            Id = id;
            Text = text;
        }
    }
    public class UserSelection
    {
        public string QuizId { get; set; } //selected QuizId
        public string StudentName { get; set; } //Student.Name

        public UserSelection()
        {
            
        }

        public UserSelection(string quizId, string studentName)
        {
            QuizId = quizId;
            StudentName = studentName;
        }
    }


    public class StudentExamViewModel
    {
        public string QuizId { get; set; } //selected QuizId
        public string StudentName { get; set; } //Student.Name
        public string QuizText { get; set; } //Quiz.Text
        public List<QuestionVm> QuestionsList { get; set; } = new List<QuestionVm>();

    }

    public class QuestionVm
    {
        public string QuestionId { get; set; }

        [Required]
        public string SelectedAnswerId { get; set; }//hold the user selection
        public string QuestionText { get; set; } //Question.text
        public List<AnswerVm> Answers { get; set; }

        public QuestionVm()
        {
            Answers = new List<AnswerVm>();
        }

        public QuestionVm(string questionTest):this()
        {
            QuestionText = questionTest;
        }
    }

    public class AnswerVm
    {
        public string Id { get; set; }
        public string AnswerText { get; set; }
    }

    public class ExamResult
    {
        public string StudentName { get; set; }
        public string ExamName { get; set; }
        public int TotalMarks { get; set; }
        public int MarksObtained { get; set; }

        public ExamResult()
        {
        }

        public ExamResult(string studentName, string examName, int totalMarks, int marksObtained)
        {
            StudentName = studentName;
            ExamName = examName;
            TotalMarks = totalMarks;
            MarksObtained = marksObtained;
        }
    }

}