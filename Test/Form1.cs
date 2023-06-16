using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;

namespace Test
{
    public partial class TestForm : Form
    {
        private List<Question> questions;
        private int currentQuestionIndex;
        private int correctAnswersCount;

        public TestForm()
        {
            InitializeComponent();
            Load += TestForm_Load;
        }

        private void TestForm_Load(object sender, EventArgs e)
        {
            string currentDirectory = AppDomain.CurrentDomain.BaseDirectory;
            string questionsFilePath = "C:\\Users\\Shin\\Desktop\\voprosi.txt";

            LoadQuestionsFromFile(questionsFilePath);

            answerRadioButton1.CheckedChanged += answerRadio_CheckedChanged;
            answerRadioButton2.CheckedChanged += answerRadio_CheckedChanged;
            answerRadioButton3.CheckedChanged += answerRadio_CheckedChanged;

            // Начало теста
            StartTest();
        }

        private void LoadQuestionsFromFile(string fileName)
        {
            questions = new List<Question>();

            if (File.Exists(fileName))
            {
                using (StreamReader sr = new StreamReader(fileName))
                {
                    string line;
                    while ((line = sr.ReadLine()) != null)
                    {
                        // Парсинг строк из файла и создание объектов вопросов
                        // Формат файла: вопрос;ответ1;ответ2;ответ3;правильный_ответ
                        string[] parts = line.Split(';');
                        if (parts.Length == 5)
                        {
                            string questionText = parts[0];
                            string[] answerOptions = new string[] { parts[1], parts[2], parts[3] };
                            int correctAnswerIndex = int.Parse(parts[4]);
                            Question question = new Question(questionText, answerOptions, correctAnswerIndex);
                            questions.Add(question);
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("Файл с вопросами не найден.");
            }
        }

        private void StartTest()
        {
            // Инициализация начальных значений
            currentQuestionIndex = 0;
            correctAnswersCount = 0;

            // Отображение первого вопроса
            ShowQuestion(currentQuestionIndex);
        }

        private void ShowQuestion(int questionIndex)
        {
            // Проверка наличия вопроса по заданному индексу
            if (questionIndex >= 0 && questionIndex < questions.Count)
            {
                Question question = questions[questionIndex];

                // Отображение вопроса и вариантов ответов на форме
                questionLabel.Text = question.Text;
                answerRadioButton1.Text = question.AnswerOptions[0];
                answerRadioButton2.Text = question.AnswerOptions[1];
                answerRadioButton3.Text = question.AnswerOptions[2];

                // Очистка выбранного ответа
                answerRadioButton1.Checked = false;
                answerRadioButton2.Checked = false;
                answerRadioButton3.Checked = false;

                // Обновление прогресс-бара
                progressBar.Maximum = questions.Count;
                progressBar.Value = questionIndex + 1;

                // Переключение доступности кнопки "Ок"
                okButton.Enabled = false;
            }
            else
            {
                // Если вопросы закончились, выводится окно результата
                ShowTestResult();
            }
        }

        private void ShowTestResult()
        {
            // Окно с результатами теста
            MessageBox.Show($"Тест завершен.\nКоличество правильных ответов: {correctAnswersCount} из {questions.Count}");

            // Закрытие формы
            Close();
        }

        public void answerRadio_CheckedChanged(object sender, EventArgs e)
        {
            // Переключение доступности кнопки "Ок" при выборе ответа
            okButton.Enabled = true;
        }

        private void okButton_Click(object sender, EventArgs e)
        {
            // Проверка выбранного ответа
            if (answerRadioButton1.Checked || answerRadioButton2.Checked || answerRadioButton3.Checked)
            {
                int selectedAnswerIndex = GetSelectedAnswerIndex();

                // Проверка правильности ответа
                if (selectedAnswerIndex == questions[currentQuestionIndex].CorrectAnswerIndex)
                {
                    correctAnswersCount++;
                }

                // Переход к следующему вопросу
                currentQuestionIndex++;
                ShowQuestion(currentQuestionIndex);
            }
            else
            {
                MessageBox.Show("Выберите один из вариантов ответа.");
            }
        }



        private int GetSelectedAnswerIndex()
        {
            if (answerRadioButton1.Checked)
            {
                return 1;
            }
            else if (answerRadioButton2.Checked)
            {
                return 2;
            }
            else if (answerRadioButton3.Checked)
            {
                return 3;
            }

            // Вернуть значение по умолчанию или сгенерировать исключение, указывающее, что ответ не выбран.
            return -1;
        }

    }

    public class Question
    {
        public string Text { get; }
        public string[] AnswerOptions { get; }
        public int CorrectAnswerIndex { get; }

        public Question(string text, string[] answerOptions, int correctAnswerIndex)
        {
            Text = text;
            AnswerOptions = answerOptions;
            CorrectAnswerIndex = correctAnswerIndex;
        }
    }
}