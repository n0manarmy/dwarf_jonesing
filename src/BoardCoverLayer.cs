using Godot;
using System;

public class BoardCoverLayer : Node2D
{
    // Declare member variables here. Examples:
    // private int a = 2;
    // private string b = "text";

    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {
        var startValuesScene = GetNodeOrNull<StartValuesScene>("/root/RootScene/StartValuesScene");
        if (startValuesScene != null) {
            startValuesScene.Connect("GoalsValuesDone", this, nameof(RemoveBoardOverlay));
        }
    }

    public void RemoveBoardOverlay() {
        GD.Print(this.GetType().Name + ".RemoveBoardOverlay");
        QueueFree();
    }

//  // Called every frame. 'delta' is the elapsed time since the previous frame.
//  public override void _Process(float delta)
//  {
//      
//  }
}
