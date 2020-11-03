using Godot;
using System;
using Dwarf.GameDataObjects;

public class Scene_08 : Node2D
{
    // Declare member variables here. Examples:
    // private int a = 2;
    // private string b = "text";

    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {
        
    }

    public void OnDoneButtonClicked() {
        QueueFree();
    }

    
    public void OnJobNamePressed() {

        var buttons = GetNode<Node2D>("/root/JobsNode/TextBackground/JobsButtonContainer/JobsButtons");

        foreach (Button button in buttons.GetChildren()) {
            if (button.Pressed == true) {
                foreach (GameData.Job job in GameData.jobs) {
                    if (button.Name == job.jobName) {
                        GD.Print(job.jobName);
                        GD.Print(job.requiredDegree);
                        GD.Print(job.baseWage);
                        break;
                    }
                }
            }
        }
    }

    

//  // Called every frame. 'delta' is the elapsed time since the previous frame.
//  public override void _Process(float delta)
//  {
//      
//  }
}
