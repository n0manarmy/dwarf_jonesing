using Godot;
using System;

public class InfoScreen : CanvasLayer
{
    // Declare member variables here. Examples:
    // private int a = 2;
    // private string b = "text";
    public int totalTime = 500;
    public int currentTime = 0;

    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {
        GD.Print("InfoScreen._Ready()");
        GetNode<Label>("TotalTimeValue").Text = totalTime.ToString();
        GetNode<Label>("TimeUsedValue").Text = currentTime.ToString();
    }

    // Called every frame. 'delta' is the elapsed time since the previous frame.
    // public override void _Process(float delta)
    // {

    // }

    public void updateCurrentTimeValue(int val) {
        GD.Print("InfoScreen.updateCurrentTimeValue()");
        currentTime += val;
        GetNode<Label>("TimeUsedValue").Text = (currentTime).ToString();
    }

    public void setStatusText(String val) {
        GetNode<Label>("StatusValue").Text = val.ToString();
    }
}