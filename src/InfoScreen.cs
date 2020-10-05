using Godot;
using System;
using Dwarf.GameDataObjects;

public class InfoScreen : CanvasLayer
{
    // Declare member variables here. Examples:
    // private int a = 2;
    // private string b = "text";

    private static String totalTimeValueNode =     "DebugNode/VBoxValues/TotalTimeValue";
    private static String timeUsedValueNode =      "DebugNode/VBoxValues/TimeUsedValue";
    private static String statusValueNode =        "DebugNode/VBoxValues/StatusValue";
    private static String eatenValueNode =         "DebugNode/VBoxValues/EatenValue";
    private static String roundsValue =            "DebugNode/VBoxValues/RoundsValue";
    private static String jobValue =               "DebugNode/VBoxValues/JobNameValue";

    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {
        GD.Print("InfoScreen._Ready()");
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