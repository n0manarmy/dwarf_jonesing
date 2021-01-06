using Godot;
using System;

public class DebugScene : Node2D
{
    // Declare member variables here. Examples:
    // private int a = 2;
    // private string b = "text";

    private static String totalTimeValueNode =      "DebugContainer/HBoxContainer/VBoxValues/TotalTimeValue";
    private static String timeUsedValueNode =       "DebugContainer/HBoxContainer/VBoxValues/TimeUsedValue";
    private static String statusValueNode =         "DebugContainer/HBoxContainer/VBoxValues/StatusValue";
    private static String eatenValueNode =          "DebugContainer/HBoxContainer/VBoxValues/EatenValue";
    private static String roundsValue =             "DebugContainer/HBoxContainer/VBoxValues/RoundsValue";
    private static String jobValue =                "DebugContainer/HBoxContainer/VBoxValues/JobNameValue";
    private static String happinessScoreValue =     "DebugContainer/HBoxContainer2/VBoxValues/HappinessScoreValue";
    private static String wealthScoreValue =        "DebugContainer/HBoxContainer2/VBoxValues/WealthScoreValue";
    private static String jobScoreValue =           "DebugContainer/HBoxContainer2/VBoxValues/JobScoreValue";
    private static String educationScoreValue =     "DebugContainer/HBoxContainer2/VBoxValues/EducationScoreValue";
    private static String maxHappinessScoreValue =  "DebugContainer/HBoxContainer3/VBoxValues/MaxHappinessScoreValue";
    private static String maxWealthScoreValue =     "DebugContainer/HBoxContainer3/VBoxValues/MaxWealthScoreValue";
    private static String maxJobScoreValue =        "DebugContainer/HBoxContainer3/VBoxValues/MaxJobScoreValue";
    private static String maxEducationScoreValue =  "DebugContainer/HBoxContainer3/VBoxValues/MaxEducationScoreValue";


    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {
        GD.Print(this.GetType().Name + "._Ready()");
        // GetNode<Label>(totalTimeValueNode).Text =           GameData.totalTime.ToString();
        // GetNode<Label>(timeUsedValueNode).Text =            GameData.currentTime.ToString();
        // GetNode<Label>(eatenValueNode).Text =               GameData.players[GameData.currentPlayer].eaten.ToString();
        // GetNode<Label>(jobValue).Text =                     GameData.players[GameData.currentPlayer].job.jobName.ToString();

        // GetNode<GameData>(StaticStrings.scene08).Connect("JobChanged", this, nameof(UpdateJobLabel));

        GetNode<TimerEngine>("../TimerEngine").Connect("RoundTimerUpdated", this, nameof(UpdateTimeUsedLabel));

        GetNode<ScoringEngine>("../ScoringEngine").Connect("JobScoreUpdated", this, nameof(UpdateJobScore));
        GetNode<ScoringEngine>("../ScoringEngine").Connect("EducationScoreUpdated", this, nameof(UpdateEducationScore));
        GetNode<ScoringEngine>("../ScoringEngine").Connect("HappinessScoreUpdated", this, nameof(UpdateHappinessScore));
        GetNode<ScoringEngine>("../ScoringEngine").Connect("WealthScoreUpdated", this, nameof(UpdateWealthScore));

        GetNode<ScoringEngine>("../ScoringEngine").Connect("MaxJobScoreUpdated", this, nameof(UpdateJobMaxScore));
        GetNode<ScoringEngine>("../ScoringEngine").Connect("MaxEducationScoreUpdated", this, nameof(UpdateEducationMaxScore));
        GetNode<ScoringEngine>("../ScoringEngine").Connect("MaxHappinessScoreUpdated", this, nameof(UpdateHappinessMaxScore));
        GetNode<ScoringEngine>("../ScoringEngine").Connect("MaxWealthScoreUpdated", this, nameof(UpdateWealthMaxScore));

        
        var scoringEngine = GetNode<ScoringEngine>("../ScoringEngine");
        // scoringEngine.SetMaxJobScore(GameData.currentPlayer, GameData.players[GameData.currentPlayer].maxJobScore);
        // scoringEngine.SetMaxWealthScore(GameData.currentPlayer, GameData.players[GameData.currentPlayer].maxWealthScore);
        // scoringEngine.SetMaxEducationScore(GameData.currentPlayer, GameData.players[GameData.currentPlayer].maxEducationScore);
        // scoringEngine.SetMaxHappinessScore(GameData.currentPlayer, GameData.players[GameData.currentPlayer].maxHappinessScore);

        // scoringEngine.SetMaxJobScore(GameData.currentPlayer,        GameData.BASE_STARTING_DIFFICULTY);
        // scoringEngine.SetMaxWealthScore(GameData.currentPlayer,     GameData.BASE_STARTING_DIFFICULTY);
        // scoringEngine.SetMaxEducationScore(GameData.currentPlayer,  GameData.BASE_STARTING_DIFFICULTY);
        // scoringEngine.SetMaxHappinessScore(GameData.currentPlayer,  GameData.BASE_STARTING_DIFFICULTY);
    }

    public void UpdateJobLabel(String job) {
        GD.Print(this.GetType().Name + ".UpdateJobLabel()");
        GetNode<Label>(jobValue).Text = job;
    }

    public void UpdateEaten(bool val) {
        GD.Print(this.GetType().Name + ".UpdateEaten()");
        GetNode<Label>(eatenValueNode).Text =               val.ToString();
    }

    // public void UpdateJob(Job job) {
    //     GD.Print(this.GetType().Name + ".UpdateJob()");
    //     GetNode<Label>(jobValue).Text =                     job.jobName.ToString();
    // }

    public void UpdateHappinessScore(int val) {
        GD.Print(this.GetType().Name + ".UpdateHappinessScore()");
        GetNode<Label>(happinessScoreValue).Text =          val.ToString();
    }

    public void UpdateWealthScore(int val) {
        GD.Print(this.GetType().Name + ".UpdateWealthScore()");
        GetNode<Label>(wealthScoreValue).Text =             val.ToString();
    }

    public void UpdateJobScore(int val) {
        GD.Print(this.GetType().Name + ".UpdateJobScore()");
        GetNode<Label>(jobScoreValue).Text =                val.ToString();
    }

    public void UpdateEducationScore(int val) {
        GD.Print(this.GetType().Name + ".UpdateEducationScore()");
        GetNode<Label>(educationScoreValue).Text =          val.ToString();
    }

    public void UpdateHappinessMaxScore(int val) {
        GD.Print(this.GetType().Name + ".UpdateHappinessMaxScore()");
        GetNode<Label>(maxHappinessScoreValue).Text =          val.ToString();
    }

    public void UpdateWealthMaxScore(int val) {
        GD.Print(this.GetType().Name + ".UpdateWealthMaxScore()");
        GetNode<Label>(maxWealthScoreValue).Text =             val.ToString();
    }

    public void UpdateJobMaxScore(int val) {
        GD.Print(this.GetType().Name + ".UpdateJobMaxScore()");
        GetNode<Label>(maxJobScoreValue).Text =                val.ToString();
    }

    public void UpdateEducationMaxScore(int val) {
        GD.Print(this.GetType().Name + ".UpdateEducationMaxScore()");
        GetNode<Label>(maxEducationScoreValue).Text =          val.ToString();
    }

    // public void UpdateValues() {
    //     GD.Print(this.GetType().Name + ".UpdateValues()");
    //     GetNode<Label>(totalTimeValueNode).Text =           GameData.totalTime.ToString();
    // }

    // Called every frame. 'delta' is the elapsed time since the previous frame.
    // public override void _Process(float delta)
    // {

    // }

    public void UpdateTimeUsedLabel(int val) {
        // GD.Print(this.GetType().Name + ".UpdateTimeUsedLabel()");
        GetNode<Label>(timeUsedValueNode).Text = val.ToString();
    }

    public void SetStatusText(String val) {
        GD.Print(this.GetType().Name + ".SetStatusText()");
        GetNode<Label>(statusValueNode).Text = val.ToString();
    }
}