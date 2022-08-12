namespace QuizApp
{
    class Program
    {
        public enum Menu
        {
            StartQuiz = 1,
            AddQuestion,
            ShowDashboard,
            Statistics,
            ShowStatistics,
            ClearStatistics,
        };

        public static Dictionary<string, string> uzbek = new Dictionary<string, string>()
        {
            {"Menyudagi tanlovlardan birini tanlang.", "Menyudagi tanlovlardan birini tanlang. "},
            {"Testni boshlash uchun ismingizni kiriting.", "Testni boshlash uchun ismingizni kiriting. " },
            {"Savol:", "Savol: " },
            {"Javobni tanlang.", "Javobni tanlang. " },
            {"Javobingiz to'g'ri.", "Javobingiz to'g'ri. "},
            {"Javobingiz noto'g'ri.", "Javobingiz noto'g'ri. "},
            {"Natijani olish uchun 'Enter' ni bosing.", "Natijani olish uchun 'Enter' ni bosing. "},
            {"Davom etish uchun 'Enter' ni bosing.", "Davom etish uchun 'Enter' ni bosing. "},
            {"Quyida xato topilgan savollarning javoblari:", "Quyida xato topilgan savollarning javoblari: " },
            {"-savolning javobi", "-savolning javobi " }, 
            {"Sizning natijangiz:", "Sizning natijangiz: " },
            {"Savol qo'shish uchun parolni kiriting:", "Savol qo'shish uchun parolni kiriting: " },
            {"Parol xato kiritildi.", "Parol xato kiritildi. " },
            {"Parol to'g'ri kiritildi.", "Parol to'g'ri kiritildi. " },
            {"Savolni kiriting:", "Savolni kiriting: " },
            {"Savol tanlovini kiritasizmi? Yes | No", "Savol tanlovini kiritasizmi? Yes | No " },
            {"-tanlovni kiriting:", "-tanlovni kiriting: "},
            {"Savol javobining raqamini kiriting:", "Savol javobining raqamini kiriting: " },
            {"Savol muvaffaqiyatli qo'shildi.", "Savol muvaffaqiyatli qo'shildi. " },
            {"Mavjud savollar:", "Mavjud savollar: "},
            {"Yuqoridagilardan birini tanlang:", "Yuqoridagilardan birini tanlang: " },
            {"Siz hali birorta ham urinish qilmadingiz!", "Siz hali birorta ham urinish qilmadingiz! "},
            {"Statistika muvaffaqiyatli tozalandi.", "Statistika muvaffaqiyatli tozalandi. " }
        };

        public static Dictionary<string, string> english = new Dictionary<string, string>()
        {
            {"Menyudagi tanlovlardan birini tanlang.", "Choose one option from Menu. "},
            {"Testni boshlash uchun ismingizni kiriting.", "Enter your name to start app. " },
            {"Savol:", "Question: " },
            {"Javobni tanlang.", "Choose your answer. " },
            {"Javobingiz to'g'ri.", "Answer is correct. "},
            {"Javobingiz noto'g'ri.", "Answer is incorrect. "},
            {"Natijani olish uchun 'Enter' ni bosing.", "To see the result press 'Enter'. "},
            {"Davom etish uchun 'Enter' ni bosing.", "To continue press 'Enter'. "},
            {"Quyida xato topilgan savollarning javoblari:", "These are answers of questions which you have done wrong: " },
            {"-savolning javobi", "-answer of question " },
            {"Sizning natijangiz:", "Your result: " },
            {"Savol qo'shish uchun parolni kiriting:", "To add a question enter password: " },
            {"Parol xato kiritildi.", "Password is incorrect. " },
            {"Parol to'g'ri kiritildi.", "Password is correct. " },
            {"Savolni kiriting:", "Enter the 'Question': " },
            {"Savol tanlovini kiritasizmi? Yes | No", "Do you want to enter choice of Question? Yes | No " },
            {"-tanlovni kiriting:", "-Enter choice of Question: "},
            {"Savol javobining raqamini kiriting:", "Enter number of correct choice of Question: " },
            {"Savol muvaffaqiyatli qo'shildi.", "Question has been added successfully. " },
            {"Mavjud savollar:", "Existing questions: "},
            {"Yuqoridagilardan birini tanlang:", "Choose one option from above: " },
            {"Siz hali birorta ham urinish qilmadingiz!", "You have not tried yet! "},
            {"Statistika muvaffaqiyatli tozalandi.", "Statistics has been cleared successfully! " }
        };

        public static Dictionary<string, string> appLang = uzbek;

        public static string password = "2001";

        public static List<List<string>> questions = new List<List<string>>();
        public static List<User> results = new List<User>();

        public static void Main(string[] args)
        {
            Console.WriteLine("English: Choose the language of the APP. (O'zbekcha: Dastur tilini tanlang.)");
            Console.WriteLine("1. English");
            Console.WriteLine("2. Uzbek");
            var language = Console.ReadLine();
            if (language == "1")
            {
                appLang = english;
            }

            StartQuizApp();
        }
        
        public static void StartQuizApp()
        {
            ShowMenu(Menu.StartQuiz);
            ShowMenu(Menu.AddQuestion);
            ShowMenu(Menu.ShowDashboard);
            ShowMenu(Menu.Statistics);

            Console.Write(appLang["Menyudagi tanlovlardan birini tanlang."]);
            var option = Console.ReadLine();
            switch (option)
            {
                case "1":
                    StartQuiz();
                    break;

                case "2":
                    AddQuestion();
                    break;

                case "3":
                    ShowDashboard();
                    break;

                case "4": 
                    Statistics();
                    break;

            }
        }

        public static void ShowMenu(Menu menu, int i = 0)
        {
            Console.WriteLine($"{(int)menu - i}. {menu}");
        }

        public static void StartQuiz()
        {
            if (questions.Count() == 0)
            {
                AddDefaultQuestions(questions);
            }

            Console.Write(appLang["Testni boshlash uchun ismingizni kiriting."]);
            var name = Console.ReadLine()!;

            int numberOfCorrectAnswers = 0;
            List<int> indexesOfIncorrectAnswers = new List<int>();
            for (int i = 0; i < questions.Count(); i++)
            {
                for (int j = 0; j < questions[i].Count() - 1; j++)
                {
                    Console.WriteLine(j == 0 ? $"{appLang["Savol:"]} {questions[i][j]}" : $"{j}. {questions[i][j]}");
                }
                   
                Console.Write(appLang["Javobni tanlang."]);
                var answer = Console.ReadLine();
                if (answer == questions[i].Last())
                {
                    Console.WriteLine(appLang["Javobingiz to'g'ri."]);
                    numberOfCorrectAnswers++;
                }
                else 
                {
                    Console.WriteLine(appLang["Javobingiz noto'g'ri."]);
                    indexesOfIncorrectAnswers.Add(i);
                }
               
                Console.Write(i == questions.Count() - 1 ? appLang["Natijani olish uchun 'Enter' ni bosing."] : appLang["Davom etish uchun 'Enter' ni bosing."]);
                Console.ReadKey();
                Console.WriteLine();
            }

            if (indexesOfIncorrectAnswers.Count > 0)
            {
                Console.WriteLine(appLang["Quyida xato topilgan savollarning javoblari:"]);
                foreach (var index in indexesOfIncorrectAnswers)
                {
                    Console.WriteLine($"\t{index + 1}{appLang["-savolning javobi"]} {questions[index][int.Parse(questions[index].Last())]}");
                }
            }

            

            Console.WriteLine($"{appLang["Sizning natijangiz:"]} {numberOfCorrectAnswers} / {questions.Count()}");
            results.Add(new User(name, numberOfCorrectAnswers, questions.Count()));

            Console.WriteLine();
            StartQuizApp();
        }

        public static void AddQuestion()
        {
            Console.Write(appLang["Savol qo'shish uchun parolni kiriting:"]);
            var newPassword = Console.ReadLine();
            if (password != newPassword)
            {
                Console.WriteLine(appLang["Parol xato kiritildi."]);
                StartQuizApp();
            } 
            else
            {
                Console.WriteLine(appLang["Parol to'g'ri kiritildi."]);
            }

            List<string> question = new List<string>();
            
            Console.Write(appLang["Savolni kiriting:"]);
            question.Add(Console.ReadLine()!);

            int numberOfChoices = 0;

            string isChoiceYes;
            do
            {
                Console.WriteLine(appLang["Savol tanlovini kiritasizmi? Yes | No"]);
                isChoiceYes = Console.ReadLine()!;
                if (isChoiceYes == "Yes")
                {
                    numberOfChoices++;
                    Console.Write(numberOfChoices + appLang["-tanlovni kiriting:"]);
                    var choice = Console.ReadLine()!;
                    question.Add(choice);
                }
            }
            while (isChoiceYes == "Yes");
            
            Console.Write(appLang["Savol javobining raqamini kiriting:"]);
            question.Add(Console.ReadLine()!);

            questions.Add(question);
            Console.WriteLine(appLang["Savol muvaffaqiyatli qo'shildi."]);
            
            Console.WriteLine();
            StartQuizApp();
        }

        public static void ShowDashboard()
        {
            if (questions.Count == 0)
            {
                AddDefaultQuestions(questions);
            }

            Console.WriteLine(appLang["Mavjud savollar:"]);
            foreach(var question in questions)
            {
                Console.WriteLine($"\t{question.First()}");
            }

            Console.WriteLine();
            StartQuizApp();
        }

        public static void Statistics()
        {
            ShowMenu(Menu.ShowStatistics, 4);
            ShowMenu(Menu.ClearStatistics, 4);
            Console.Write(appLang["Yuqoridagilardan birini tanlang:"]);
            var input = Console.ReadLine();

            switch (input)
            {
                case "1":
                    ShowStatistics();
                    break;

                case "2": 
                    ClearStatistics();
                    break;
            }
            

            void ShowStatistics()
            {
                if (results.Count() == 0)
                {
                    Console.WriteLine(appLang["Siz hali birorta ham urinish qilmadingiz!"]);
                }
                else
                {
                    var newResults = results.OrderByDescending(user => (double)user.NumberOfCorrectAnswers / user.NumberOfQuestions * 100).ToList();

                    for (int i = 0; i < newResults.Count(); i++)
                    {
                        Console.WriteLine($"{i + 1}. {newResults[i].Name} - {newResults[i].NumberOfCorrectAnswers} / {newResults[i].NumberOfQuestions}");
                    }
                }
            }

            void ClearStatistics()
            {
                results.Clear();
                Console.WriteLine(appLang["Statistika muvaffaqiyatli tozalandi."]);
            }

            Console.WriteLine();
            StartQuizApp();


        }

        public static void AddDefaultQuestions(List<List<string>> questions)
        {
            questions.Add(new List<string> { "12 + 8 = ?", "128", "20", "30", "18", "2" });
            questions.Add(new List<string> { "17 - 8 = ?", "178", "8", "7", "9", "4" });
            questions.Add(new List<string> { "9 * 8 = ?", "72", "98", "89", "82", "1" });
            questions.Add(new List<string> { "20 / 4 = ?", "204", "4", "5", "9", "3" });
        }
    }
}