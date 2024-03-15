using CommunityToolkit.Mvvm.ComponentModel;
using NotWordlev2.Models;
using NotWordlev2.Views;
using System.Threading.Tasks;
using System.Windows.Input;

namespace NotWordlev2.ViewModels
{
     partial class GameViewModel : ObservableObject //Singleton, endast 1 instans kan skapas
     {
        private static readonly GameViewModel instance = new GameViewModel();

        public static GameViewModel Instance
        {
            get { return instance; }
        }

        public ICommand InsertLettersCommand { get; } //mvvm toolkit för databindning knappar
        public string AnswerText { get; set; } //for databind display

        // 6 rader
        int rowIndex;
        // 5 columner/bokstäver
        int columnIndex;

        char[] Answer;

        public char[] KeyboardRow1 { get; }
        public char[] KeyboardRow2 { get; }
        public char[] KeyboardRow3 { get; }

        [ObservableProperty]
        private Word[] rows;

        private GameViewModel()
        {
            Task.Run(async () => await RandomWordTask()).Wait(); //get random word from API

            KeyboardRow1 = "QWERTYUIOP".ToCharArray();
            KeyboardRow2 = "ASDFGHJKL".ToCharArray();
            KeyboardRow3 = "←ZXCVBNM↵".ToCharArray();

            InsertLettersCommand = new Command<char>(InsertLetters);

            rows = new Word[6]
            {
                new Word(),
                new Word(),
                new Word(),
                new Word(),
                new Word(),
                new Word()
            };
        }

        private async Task RandomWordTask()
        {
            string word = await RandomWordAPI.GetRandomWord();
            Answer = word.ToCharArray();

            AnswerText = new string(Answer); 
        }

        public async void Enter()
        {
            if (columnIndex != 5)
            {
                return; //om inte hela raden är fylld return
            }

            var correct = Rows[rowIndex].Validate(Answer);

            if (correct)
            {
                await Application.Current.MainPage.Navigation.PushAsync(new WinPage());

                return;
            }

            if (rowIndex == 5)
            {
                await Application.Current.MainPage.Navigation.PushAsync(new LosePage());

            }
            else
            {
                rowIndex++;
                columnIndex = 0;
            }
        }

        public void InsertLetters(char letter)
        {
            if (letter == '↵') //om enter
            {
                Enter();
                return;
            }

            if (letter == '←') //om backspace
            {
                if (columnIndex == 0)
                    return;
                columnIndex--;
                Rows[rowIndex].Letters[columnIndex].Input = ' ';

                return;
            }

            if (columnIndex == 5) //om rad är full
                return;

            Rows[rowIndex].Letters[columnIndex].Input = letter;
            columnIndex++;
        }
    }
}
