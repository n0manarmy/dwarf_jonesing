using Godot;
using System;
using Dwarf.GameDataObjects;

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
        GetNode<Label>(totalTimeValueNode).Text =           GameData.totalTime.ToString();
        GetNode<Label>(timeUsedValueNode).Text =            GameData.currentTime.ToString();
        GetNode<Label>(eatenValueNode).Text =               GameData.players[0].eaten.ToString();
        GetNode<Label>(jobValue).Text =                     GameData.players[0].jobName.ToString();
        GetNode<Label>(happinessScoreValue).Text =          GameData.players[0].happinessScore.ToString();
        GetNode<Label>(wealthScoreValue).Text =             GameData.players[0].wealthScore.ToString();        
        GetNode<Label>(jobScoreValue).Text =                GameData.players[0].jobScore.ToString();
        GetNode<Label>(educationScoreValue).Text =          GameData.players[0].educationScore.ToString();
        GetNode<Label>(maxHappinessScoreValue).Text =       GameData.players[0].maxHappinessScore.ToString(); 
        GetNode<Label>(maxWealthScoreValue).Text =          GameData.players[0].maxWealthScore.ToString();        
        GetNode<Label>(maxJobScoreValue).Text =             GameData.players[0].maxJobScore.ToString();
        GetNode<Label>(maxEducationScoreValue).Text =       GameData.players[0].maxEducationScore.ToString();

        
    }

    // Called every frame. 'delta' is the elapsed time since the previous frame.
    // public override void _Process(float delta)
    // {

    // }

    public void ResetTimeUsed() {
        GameData.currentTime = 0;
        GetNode<Label>(timeUsedValueNode).Text = GameData.currentTime.ToString();
    }

    public void IncrementTimeValue(int val) {
        // GD.Print("InfoScreen.updateCurrentTimeValue()");
        GameData.currentTime += val;
        GetNode<Label>(timeUsedValueNode).Text = (GameData.currentTime).ToString();
    }

    public void SetStatusText(String val) {
        GetNode<Label>(statusValueNode).Text = val.ToString();
    }

    public void IncrementRounds() {
        GameData.rounds += 1;
        GetNode<Label>(roundsValue).Text = GameData.rounds.ToString();
    }
}