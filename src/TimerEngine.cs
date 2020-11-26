using Godot;
using System;
using Dwarf.GameDataObjects;

public class TimerEngine : Node2D
{
    [Signal]
    public delegate void RoundTimerUpdated();
    
    [Signal]
    public delegate void RoundsIncremented();

    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {
        
    }

    public void ResetTimeUsed() {
        GameData.currentTime = 0;
        EmitSignal(nameof(RoundTimerUpdated), 0);
    }

    public void IncrementTimeValue(int val) {
        GameData.currentTime += val;
        EmitSignal(nameof(RoundTimerUpdated), GameData.currentTime);
    }

    public void IncrementRounds() {
        GameData.rounds += 1;
        EmitSignal(nameof(RoundsIncremented));
    }

//  // Called every frame. 'delta' is the elapsed time since the previous frame.
//  public override void _Process(float delta)
//  {
//      
//  }
}
