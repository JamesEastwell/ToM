using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public class Game
{
    private IInput Input;
    private IOutput Output;
    private Player[] PlayerList;
    private int TargetScore;
    protected Game(IInput Input, IOutput Output)
    {
        Output.DisplayIntro();
        this.Input = Input;
        this.Output = Output;
        this.TargetScore = Input.TotalScore();
        int NumPlayers = Input.TotalPlayers();
        PlayerList = new Player[NumPlayers];
        for (int i = 0; i < NumPlayers; i++)
        {
            PlayerList[i] = new Player(5);
        }
    }

    public void Run()
    {
        //Display Intro
        //Take input for total players and target score
        bool GameOver = false;
        while (GameOver == false)
        {
            foreach (Player Player in PlayerList)
            {
                //Roll
                Input.DoRoll();
                for (int i = 0; i < 5; i++)
                {
                    Player.RollDie(i);
                }
                int[] SortedDie = Player.SortDie();
                Output.DisplayRoll(SortedDie);
                int[] Matched = Player.SummariseRolls();
                int[] MatchingDie = GetMostOccurring(Matched);
                ChangeScore(MatchingDie, Player);
                Output.NextPlayer();
            }

            GameOver = EndRound();
        }
        //Display EndGame
        Output.EndGame(PlayerList);
    }
    private int[] GetMostOccurring(int[] Matched)
    {
        int TimesRecurring = 0;
        for (int i = 0; i < Matched.Length; i++)
        {
            if (Matched[i] > TimesRecurring)
            {
                TimesRecurring = Matched[i];
            }
        }
        int FaceofRecurring = (Array.IndexOf(Matched, TimesRecurring)) + 1;
        int[] MatchingDie = new int[2];
        MatchingDie[0] = TimesRecurring;
        MatchingDie[1] = FaceofRecurring;
        return MatchingDie;
    }
    public void ChangeScore(int[] MatchingDie, Player Player)
    {
        MatchingDie = DecideReroll(MatchingDie, Player);
        int Score = Player.GetScore();
        switch (MatchingDie[0])
        {
            case 3:
                //add 3
                Score = Score + 3;
                Player.SetScore(Score);
                break;
            case 4:
                //add 6
                Score = Score + 6;
                Player.SetScore(Score);
                break;
            case 5:
                //add 12
                Score = Score + 12;
                Player.SetScore(Score);
                break;
            default:
                //Scored Nothing
                Console.WriteLine("You scored nothing");
                break;
        }

    }
    public int[] DecideReroll(int[] MatchingDie, Player Player)
    {
        if (MatchingDie[0] == 2)
        {
            //reroll
            Input.DoRoll();
            for (int i = 0; i < 5; i++)
            {
                Die Die = Player.GetDie(i);
                int DieNumber = Die.GetValue();
                if (DieNumber != MatchingDie[1])
                {
                    Player.RollDie(i);
                }
            }
            int[] SortedDie = Player.SortDie();
            int[] Matched = Player.SummariseRolls();
            MatchingDie = GetMostOccurring(Matched);
            Output.DisplayRoll(SortedDie);
        }
        return MatchingDie;

    }
    public bool EndRound()
    {
        foreach(Player Player in PlayerList)
        {
            int Score = Player.GetScore();
            if (Score >= TargetScore)
            {
                return true;
            }
        }
        Output.SummariseRound(PlayerList);
        return false;
    }
}