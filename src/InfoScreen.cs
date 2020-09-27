using Godot;
using System;

public class InfoScreen : CanvasLayer
{
    // Declare member variables here. Examples:
    // private int a = 2;
    // private string b = "text";
    private int totalTime = 50;
    private int currentTime = 0;

    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {
        GetNode<Label>("TotalTimeValue").Text = totalTime.ToString();
        GetNode<Label>("TimeUsedValue").Text = currentTime.ToString();
    }

    // Called every frame. 'delta' is the elapsed time since the previous frame.
    // public override void _Process(float delta)
    // {

    // }

    public void updateCurrentTimeValue(int value) {
        GetNode<Label>("TimeUsedValue").Text = (currentTime + value).ToString();
    }
}
