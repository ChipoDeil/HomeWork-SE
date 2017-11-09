using System;
using System.Collections.Generic;
using System.Linq;
using LeagueLeo;
using LeagueLeo.Facades;

namespace LeagueLeoClient
{
    class Program
    {
        static InJsonUserRepository userRepository = new InJsonUserRepository();
        static InJsonUsersWordRepository usersWordRepository = new InJsonUsersWordRepository();
        static InJsonWordRepository wordRepository = new InJsonWordRepository();
        static UserManager userManager = new UserManager(userRepository);
        static UsersWordRepositoryManager usersWordRepositoryManager = new UsersWordRepositoryManager(usersWordRepository,
                                                                userRepository);
        static GlobalDictionaryManager globalDictionaryManager = new GlobalDictionaryManager(wordRepository);
        static Guid currentId;
        static void Main(string[] args)
        {
            var listOfWords = globalDictionaryManager.GetAllWords();
            if (listOfWords.ToArray().Length == 0)
            { 
                FillWithWords(globalDictionaryManager);
            }

            LoginUser();
        }

        static void FillWithWords(IGlobalDictionaryManager globalDictionaryManager)
        {
            var listOfWords = new List<Word>() {
                new Word("new", "новый", Guid.NewGuid()),
                new Word("hello", "привет", Guid.NewGuid()),
                new Word("bye", "пока", Guid.NewGuid()),
                new Word("name", "имя", Guid.NewGuid()),
                new Word("school", "школа", Guid.NewGuid())
            };
            foreach (Word current in listOfWords) {
                globalDictionaryManager.AddWord(current);
            }
        }

        public static  void RegisterUser()
        {
            Console.WriteLine("Введите nickname");
            string newNickName = Console.ReadLine();
            Guid newUserId = userManager.AddUser(newNickName);
            currentId = newUserId;
            Menu();
        }

        public static void LoginUser()
        {
            Console.WriteLine("Введите id или пустое поле, чтобы зарегистрироваться");
            var input = Console.ReadLine();
            if (input.Equals(""))
            {
                RegisterUser();
            }
            else
            {
                try { 
                    Guid currentLocId = Guid.Parse(input);
                    var listOfUsers = userManager.GetAllUsers().ToList();
                    var currentUser = listOfUsers.Find(current => current.Id == currentLocId);
                    if (currentUser == null)
                    {
                        Console.WriteLine("Пользователь с таким id не существует.");
                        LoginUser();
                    }
                    else
                    {
                        currentId = currentLocId;
                        Menu();
                    }
                }
                catch
                {
                    Console.WriteLine("Упс... Что-то пошло не так.");
                    LoginUser();
                }
                
            }
        }

        public static void Menu() {
            Console.WriteLine("Чтобы посмотреть список своих слов, введите 0");
            Console.WriteLine("Чтобы посмотреть список всех слов, введите 1");
            Console.WriteLine("Чтобы добавить своё слово, введите 2");
            Console.WriteLine("Чтобы добавить слово из словаря, введите 3");
            Console.WriteLine("Чтобы начать играть, введите 4");
            Console.WriteLine("Для выхода введите 5");
            try
            {
                var input = Int32.Parse(Console.ReadLine());
                switch (input)
                {
                    case 0:
                        ShowUsersWords();
                        Menu();
                        break;
                    case 1:
                        ShowAllWords();
                        Menu();
                        break;
                    case 2:
                        AddOwnWord();
                        Menu();
                        break;
                    case 3:
                        AddWordFromGlobal();
                        Menu();
                        break;
                    case 4:
                        StartPrint();
                        Menu();
                        break;
                    case 5:
                        return;
                    default:
                        Menu();
                        break;
                }
            }
            catch
            {
                Console.WriteLine("Упс... Что-то пошло не так.");
                Menu();
            }

        }

        private static void AddWordFromGlobal()
        {
            Console.WriteLine("Введите Id добавляемого слова");
            var wordId = Guid.Parse(Console.ReadLine());
            var wordToAdding = globalDictionaryManager.GetWord(wordId);
            usersWordRepository.AddWordForUser(currentId, wordToAdding);
            Console.WriteLine("Слово успешно добавлено!");
        }

        private static void StartPrint()
        {
            Console.WriteLine("Если перевод и оригинал слова будут совпадать, пиши +, иначе -");
            try
            {
                var game = new GameSprint(usersWordRepository, userRepository, currentId);
                for (int i = 0; i < Properties.minWordsToStartSplit; i++)
                {
                    var random = game.GetRandomWord();
                    Console.WriteLine(random.Original + " = " + random.Translation);
                    string input = Console.ReadLine();
                    bool result = game.IsAnswerRight(random.Original, random.Translation, input.Equals("+"));
                    if (result)
                    {
                        Console.WriteLine("Молодчина!");
                    }
                    else
                    {
                        Console.WriteLine("Эх, ошибка!");
                    }
                }
            }
            catch
            {
                Console.WriteLine("Вероятно, у вас недостаточно слов для старта сплита.");
            }
        }

        private static void AddOwnWord()
        {
            Console.WriteLine("Введите оригинал слова (пустую строку для выхода)");
            var original = Console.ReadLine();
            if (original.Equals(""))
            {
                return;
            }
            Console.WriteLine("Введите перевод слова");
            var translation = Console.ReadLine();
            var word = new Word(original, translation, Guid.NewGuid());
            usersWordRepositoryManager.AddWordForUser(word, currentId);
            Console.WriteLine("Слово успешно добавлено!");
        }

        private static void ShowAllWords()
        {
            var listOfAllWords = globalDictionaryManager.GetAllWords().ToList();
            Console.WriteLine("ID |Оригинал | Перевод");
            foreach (Word currentWord in listOfAllWords)
            {
                Console.WriteLine(currentWord.Id + " | " + currentWord.Original + " | " + currentWord.Translation);
            }
        }

        private static void ShowUsersWords()
        {
            try
            {
                var listOfWords = usersWordRepositoryManager.LoadWordsForUser(currentId).ToList();
                Console.WriteLine("Оригинал | Перевод | Количество очков");
                foreach (Word currentWord in listOfWords)
                {
                    Console.WriteLine(currentWord.Original + " | " + currentWord.Translation + " | " + currentWord.Points);
                }
            }
            catch
            {
                Console.WriteLine("В вашем словаре пока нет слов");
            }
            
        }
    }
}
