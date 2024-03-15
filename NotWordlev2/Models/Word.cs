using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotWordlev2.Models
{
    public class Word
    {
        public Letter[] Letters { get; set; }
        public Word()
        {
            Letters = new Letter[5]
            {
            new Letter(),
            new Letter(),
            new Letter(),
            new Letter(),
            new Letter()
            };
        }

        
        public bool Validate(char[] Answer)
        {
            //om tid finns, titta mot ordlista 

            int correctLetters = 0; 

            
            for (int i = 0; i < Letters.Length; i++)
            {
                var letter = Letters[i];
                if (letter.Input == Answer[i])
                {
                    letter.Color = Colors.Green; //bokstav rätt plats
                    correctLetters++;
                }
                else if (Answer.Contains(letter.Input))
                {
                    letter.Color = Colors.Yellow; //bokstav finns i answer
                }
                else
                {
                    letter.Color = Colors.Gray; //bokstav inte i answer
                }
            }

            return correctLetters == 5; // om 5 correct, return true
        }
    }

    public partial class Letter : ObservableObject
    {
        public Letter()
        {
            Color = Colors.LightGray; //bakgrund frame
        }

        [ObservableProperty]
        private char input;

        [ObservableProperty]
        private Color color;
    }
}
