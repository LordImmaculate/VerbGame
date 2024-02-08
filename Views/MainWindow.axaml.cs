using Avalonia.Controls;
using Avalonia.Input;
using System;
using System.Collections.Generic;
using Avalonia.Interactivity;
using Avalonia.Media;

namespace VerbGame.Views;

public partial class MainWindow : Window
{
    int correctVerbs = 0;
    int incorrectVerbs = 0;
    private string solution;

    public MainWindow()
    {
        InitializeComponent();
        RandomVerb();
    }

    private void TextBoxVerb_OnKeyDown(object? sender, KeyEventArgs e)
    {
        if (e.Key != Key.Enter) return;
        CheckVerb();
    }

    private void ButtonVerb_OnClick(object? sender, RoutedEventArgs e)
    {
        CheckVerb();
    }

    private void RandomVerb()
    {
        List<(string, string)> irregularVerbs = new List<(string, string)>
        {
            ("arise", "arose"),
            ("bear", "bore"),
            ("beat", "beat"),
            ("bend", "bent"),
            ("bet", "bet"),
            ("bid", "bid"),
            ("bite", "bit"),
            ("blow", "blew"),
            ("bring", "brought"),
            ("build", "built"),
            ("burst", "burst"),
            ("buy", "bought"),
            ("cast", "cast"),
            ("catch", "caught"),
            ("choose", "chose"),
            ("come", "came"),
            ("cost", "cost"),
            ("cut", "cut"),
            ("deal", "dealt"),
            ("dig", "dug"),
            ("do", "did"),
            ("draw", "drew"),
            ("drink", "drank"),
            ("drive", "drove"),
            ("eat", "ate"),
            ("fall", "fell"),
            ("feed", "fed"),
            ("feel", "felt"),
            ("fight", "fought"),
            ("find", "found"),
            ("fly", "flew"),
            ("forget", "forgot"),
            ("forgive", "forgave"),
            ("freeze", "froze"),
            ("get", "got"),
            ("give", "gave"),
            ("go", "went"),
            ("grow", "grew"),
            ("hang", "hung"),
            ("have", "had"),
            ("hear", "heard"),
            ("hide", "hid"),
            ("hit", "hit"),
            ("hold", "held"),
            ("hurt", "hurt"),
            ("keep", "kept"),
            ("know", "knew"),
            ("lay", "laid"),
            ("lead", "led"),
            ("leave", "left"),
            ("lend", "lent"),
            ("let", "let"),
            ("lie", "lay"),
            ("light", "lit"),
            ("lose", "lost"),
            ("make", "made"),
            ("mean", "meant"),
            ("meet", "met"),
            ("pay", "paid"),
            ("prove", "proved"),
            ("put", "put"),
            ("quit", "quit"),
            ("read", "read"),
            ("ride", "rode"),
            ("ring", "rang"),
            ("rise", "rose"),
            ("run", "ran"),
            ("say", "said"),
            ("see", "saw"),
            ("seek", "sought"),
            ("sell", "sold"),
            ("send", "sent"),
            ("set", "set"),
            ("shake", "shook"),
            ("shine", "shone"),
            ("shoot", "shot"),
            ("show", "showed"),
            ("shut", "shut"),
            ("sing", "sang"),
            ("sink", "sank"),
            ("sit", "sat"),
            ("sleep", "slept"),
            ("slide", "slid"),
            ("speak", "spoke"),
            ("spend", "spent"),
            ("split", "split"),
            ("spread", "spread"),
            ("stand", "stood"),
            ("steal", "stole"),
            ("stick", "stuck"),
            ("strike", "struck"),
            ("swear", "swore"),
            ("swim", "swam"),
            ("take", "took"),
            ("teach", "taught"),
            ("tear", "tore"),
            ("tell", "told"),
            ("think", "thought"),
            ("throw", "threw"),
            ("understand", "understood"),
            ("undertake", "undertook"),
            ("upset", "upset"),
            ("wake", "woke"),
            ("wear", "wore"),
            ("win", "won"),
            ("wind", "wound"),
            ("write", "wrote")
        };

        Random rnd = new Random();
        int randomIndex = rnd.Next(0, irregularVerbs.Count);
        string randomKey = irregularVerbs[randomIndex].Item1; // Accessing the first item of the tuple
        solution = irregularVerbs[randomIndex].Item2;

        TextBlockVerb.Text = randomKey;
    }

    private void CheckVerb()
    {
        if (TextBoxVerb.Text == solution)
        {
            TextBlockCorrect.IsVisible = true;
            TextBlockCorrect.Text = "Correct!";
            TextBlockCorrect.Foreground = Brushes.Green;
            TextBlockSolution.IsVisible = false;
            TextBoxVerb.Text = null;
            //soundPlayer("correctSound.wav");
            correctVerbs++;
            //toolStripLabelCorrect.Text = "Correct: " + correctVerbs;
            RandomVerb();
        }
        else
        {
            TextBlockCorrect.IsVisible = true;
            TextBlockCorrect.Text = "Incorrect";
            TextBlockCorrect.Foreground = Brushes.Red;
            TextBlockSolution.IsVisible = true;
            TextBlockSolution.Text = "The correct answer is: " + solution;
            TextBoxVerb.Text = null;
            incorrectVerbs++;
            //toolStripLabelIncorrect.Text = "Incorrect: " + incorrectVerbs;
        }
    }
}