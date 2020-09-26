using Godot;
using System;

public class FollowRoad : Path2D
{
    // Declare member variables here. Examples:
    // private int a = 2;
    // private string b = "text";


    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {
        SetProcess(true);
        var tween = new Tween();
        tween.Repeat = true;
        var follow = GetNode<PathFollow2D>("FollowRoad");
        tween.InterpolateProperty(follow, "unit_offset", 0, 1, 6, Tween.TransitionType.Linear, Tween.EaseType.OutIn);
        tween.Start();
        GD.Print("end of FollowRoad._Ready");
    }

    // Called every frame. 'delta' is the elapsed time since the previous frame.
    public override void _Process(float delta)
    {
        var follow = GetNode<PathFollow2D>("FollowRoad");
        follow.Offset = (follow.Offset + 100 * delta);
        // follow.SetOffset(follow.GetOffset() + 100 * delta);
    }
}
