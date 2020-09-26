using Godot;
using System;
using System.Collections.Generic;

public class Character : Sprite
{
    // Declare member variables here. Examples:
    // private int a = 2;
    // private string b = "text";

    private List<Vector2> characterPath;

    [Export]
    private int speed = 200;

    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {
        SetProcess(false);
    }



    // Called every frame. 'delta' is the elapsed time since the previous frame.
    public override void _Process(float delta)
    {
        var distance = speed * delta;
        MoveAlongPath(distance);
    }

    public void MoveAlongPath(float distance) {
        GD.Print("MoveAlongPath");
        var start = Position;
        // GD.Print(start);
        // foreach(var i in characterPath) {
        for (int i = 0; i < characterPath.Count; i++) {
            // GD.Print("foreach i:", characterPath[i]);
            var distToNext = start.DistanceTo(characterPath[i]);
            if (distance <= distToNext && distance >= 0.0) {
                Position = start.LinearInterpolate(characterPath[i], distance / distToNext);
                break;
            } else if (distance < 0.0) {
                Position = characterPath[i];
                SetProcess(false);
                break;
            }
            distance -= distToNext;
            start = characterPath[i];
            characterPath.RemoveAt(i);
        }
    }

    public void SetCharacterPath(List<Vector2> path) {
        GD.Print("SetCharacterPath");
        characterPath = path;
        if (path.Count == 0) {
            return;
        } else {
            SetProcess(true);
        }
    }
}
