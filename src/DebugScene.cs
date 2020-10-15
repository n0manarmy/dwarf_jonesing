using Godot;
using System;
using Dwarf.GameDataObjects;

public class DebugScene : Node
{
    // Declare member variables here. Examples:
    // private int a = 2;
    // private string b = "text";

    private static String totalTimeValueNode =     "HBoxContainer/VBoxValues/TotalTimeValue";
    private static String timeUsedValueNode =      "HBoxContainer/VBoxValues/TimeUsedValue";
    private static String statusValueNode =        "HBoxContainer/VBoxValues/StatusValue";
    private static String eatenValueNode =         "HBoxContainer/VBoxValues/EatenValue";
    private static String roundsValue =            "HBoxContainer/VBoxValues/RoundsValue";
    private static String jobValue =               "HBoxContainer/VBoxValues/JobNameValue";

    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {
        GD.Print("DebugScene._Ready()");
        GetNode<Label>(totalTimeValueNode).Text = GameData.totalTime.ToString();
        GetNode<Label>(timeUsedValueNode).Text = GameData.currentTime.ToString();
        GetNode<Label>(eatenValueNode).Text = GameData.players[0].eaten.ToString();
        GetNode<Label>(jobValue).Text = GameData.players[0].jobName.ToString();
        
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