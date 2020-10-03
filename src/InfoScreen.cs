using Godot;
using System;

public class InfoScreen : CanvasLayer
{
    // Declare member variables here. Examples:
    // private int a = 2;
    // private string b = "text";
    public int totalTime = 2600;
    public int currentTime = 0;

    private String totalTimeValueNode = "DebugScreen/TotalTimeValue";
    private String timeUsedValueNode = "DebugScreen/TimeUsedValue";
    private String statusValueNode = "DebugScreen/StatusValue";
    private String eatenValueNode = "DebugScreen/EatenValue";

    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {
        GD.Print("InfoScreen._Ready()");
        GetNode<Label>(totalTimeValueNode).Text = totalTime.ToString();
        GetNode<Label>(timeUsedValueNode).Text = currentTime.ToString();
        GetNode<Label>(eatenValueNode).Text = GetNode<Character>("/root/RootScene/TravelPath/Character").eaten.ToString();
    }

    // Called every frame. 'delta' is the elapsed time since the previous frame.
    // public override void _Process(float delta)
    // {

    // }

    public void updateCurrentTimeValue(int val) {
        // GD.Print("InfoScreen.updateCurrentTimeValue()");
        currentTime += val;
        GetNode<Label>(timeUsedValueNode).Text = (currentTime).ToString();
    }

    public void setStatusText(String val) {
        GetNode<Label>(statusValueNode).Text = val.ToString();
    }
}