using Godot;
using System;
using Dwarf.GameDataObjects;
using Dwarf.StaticStrings;

public class DebugScene : Node
{
    // Declare member variables here. Examples:
    // private int a = 2;
    // private string b = "text";

    private static String totalTimeValueNode =      "HBoxContainer/VBoxValues/TotalTimeValue";
    private static String timeUsedValueNode =       "HBoxContainer/VBoxValues/TimeUsedValue";
    private static String statusValueNode =         "HBoxContainer/VBoxValues/StatusValue";
    private static String eatenValueNode =          "HBoxContainer/VBoxValues/EatenValue";
    private static String roundsValue =             "HBoxContainer/VBoxValues/RoundsValue";
    private static String jobValue =                "HBoxContainer/VBoxValues/JobNameValue";
    private static String happinessScoreValue =     "HBoxContainer/VBoxValues/HappinessScoreValue";
    private static String wealthScoreValue =        "HBoxContainer/VBoxValues/WealthScoreValue";
    private static String jobScoreValue =           "HBoxContainer/VBoxValues/JobScoreValue";
    private static String educationScoreValue =     "HBoxContainer/VBoxValues/EducationScoreValue";
    private static String maxHappinessScoreValue =  "HBoxContainer/VBoxValues/MaxHappinessScoreValue";
    private static String maxWealthScoreValue =     "HBoxContainer/VBoxValues/MaxWealthScoreValue";
    private static String maxJobScoreValue =        "HBoxContainer/VBoxValues/MaxJobScoreValue";
    private static String maxEducationScoreValue =  "HBoxContainer/VBoxValues/MaxEducationScoreValue";


    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {
        GD.Print("DebugScene._Ready()");
        // GetNode<Label>(timeUsedValueNode).Text =            GameData.currentTime.ToString();
        // GetNode<Label>(eatenValueNode).Text =               GameData.players[GameData.currentPlayer].eaten.ToString();
        // GetNode<Label>(jobValue).Text =                     GameData.players[GameData.currentPlayer].job.jobName.ToString();
        // GetNode<Label>(happinessScoreValue).Text =          GameData.players[GameData.currentPlayer].happinessScore.ToString();
        // GetNode<Label>(wealthScoreValue).Text =             GameData.players[GameData.currentPlayer].wealthScore.ToString();        
        // GetNode<Label>(jobScoreValue).Text =                GameData.players[GameData.currentPlayer].jobScore.ToString();
        // GetNode<Label>(educationScoreValue).Text =          GameData.players[GameData.currentPlayer].educationScore.ToString();
        // GetNode<Label>(maxHappinessScoreValue).Text =       GameData.players[GameData.currentPlayer].maxHappinessScore.ToString(); 
        // GetNode<Label>(maxWealthScoreValue).Text =          GameData.players[GameData.currentPlayer].maxWealthScore.ToString();        
        // GetNode<Label>(maxJobScoreValue).Text =             GameData.players[GameData.currentPlayer].maxJobScore.ToString();
        // GetNode<Label>(maxEducationScoreValue).Text =       GameData.players[GameData.currentPlayer].maxEducationScore.ToString(); 

        GetNode<TimerEngine>(StaticStrings.timerEngine).Connect("RoundTimerUpdated", this, nameof(UpdateTimeUsedLabel));

        GetNode<ScoringEngine>(StaticStrings.scoringEngine).Connect("JobScoreUpdated", this, nameof(UpdateJobScore));
        GetNode<ScoringEngine>(StaticStrings.scoringEngine).Connect("EducationScoreUpdated", this, nameof(UpdateEducationScore));
        GetNode<ScoringEngine>(StaticStrings.scoringEngine).Connect("HappinessScoreUpdated", this, nameof(UpdateHappinessScore));
        GetNode<ScoringEngine>(StaticStrings.scoringEngine).Connect("WealthScoreUpdated", this, nameof(UpdateWealthScore));

        GetNode<ScoringEngine>(StaticStrings.scoringEngine).Connect("MaxJobScoreUpdated", this, nameof(UpdateJobMaxScore));
        GetNode<ScoringEngine>(StaticStrings.scoringEngine).Connect("MaxEducationScoreUpdated", this, nameof(UpdateEducationMaxScore));
        GetNode<ScoringEngine>(StaticStrings.scoringEngine).Connect("MaxHappinessScoreUpdated", this, nameof(UpdateHappinessMaxScore));
        GetNode<ScoringEngine>(StaticStrings.scoringEngine).Connect("MaxWealthScoreUpdated", this, nameof(UpdateWealthMaxScore));
        
    }

    public void UpdateEaten(bool val) {
        GetNode<Label>(eatenValueNode).Text =               val.ToString();
    }

    public void UpdateJob(GameData.Job job) {
        GetNode<Label>(jobValue).Text =                     job.jobName.ToString();
    }

    public void UpdateHappinessScore(int val) {
        GetNode<Label>(happinessScoreValue).Text =          val.ToString();
    }

    public void UpdateWealthScore(int val) {
        GetNode<Label>(wealthScoreValue).Text =             val.ToString();
    }

    public void UpdateJobScore(int val) {
        GetNode<Label>(jobScoreValue).Text =                val.ToString();
    }

    public void UpdateEducationScore(int val) {
        GetNode<Label>(educationScoreValue).Text =          val.ToString();
    }

    public void UpdateHappinessMaxScore(int val) {
        GetNode<Label>(maxHappinessScoreValue).Text =          val.ToString();
    }

    public void UpdateWealthMaxScore(int val) {
        GetNode<Label>(maxWealthScoreValue).Text =             val.ToString();
    }

    public void UpdateJobMaxScore(int val) {
        GetNode<Label>(maxJobScoreValue).Text =                val.ToString();
    }

    public void UpdateEducationMaxScore(int val) {
        GetNode<Label>(maxEducationScoreValue).Text =          val.ToString();
    }

    // public void UpdateMaxScores(int happy, int wealth, int job, int education) {
    //     GetNode<Label>(maxHappinessScoreValue).Text =       happy.ToString();
    //     GetNode<Label>(maxWealthScoreValue).Text =          wealth.ToString();
    //     GetNode<Label>(maxJobScoreValue).Text =             job.ToString();
    //     GetNode<Label>(maxEducationScoreValue).Text =       education.ToString();
    // }

    public void UpdateValues() {
        GetNode<Label>(totalTimeValueNode).Text =           GameData.totalTime.ToString();
    }

    // Called every frame. 'delta' is the elapsed time since the previous frame.
    // public override void _Process(float delta)
    // {

    // }

    public void UpdateTimeUsedLabel(int val) {
        GetNode<Label>(timeUsedValueNode).Text = val.ToString();
    }

    public void SetStatusText(String val) {
        GetNode<Label>(statusValueNode).Text = val.ToString();
    }
}