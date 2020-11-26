using Godot;
using System;
using System.Collections.Generic;
using Dwarf.GameDataObjects;
using Dwarf.StaticStrings;

public class Character : Sprite
{
    // Declare member variables here. Examples:
    // private int a = 2;
    // private string b = "text";

    private List<Vector2> characterPath; //list of pathing points
    private Vector2 START_POS = new Vector2(31, 9);
    public String destName;

    [Export]
    private int speed = 300;
    public bool moving = false;

    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {
        MySetProcess(false);
    }

    // Called every frame. 'delta' is the elapsed time since the previous frame.
    public override void _Process(float delta)
    {
        // GD.Print("_Process");
        var distance = speed * delta;
        MoveAlongPath(distance);
    }

    public void ResetPlayerPosition() {
        var player = GetNode<Character>(StaticStrings.characterNodePath);
        var travelPath = GetNode<TileMap>("/root/RootScene/TravelPath/WalkingPath/TravelPathTileMap");

        player.Position = travelPath.MapToWorld(START_POS);        
    }

    //iterates through characterPath coordinates, calculating distances between the points.
    public void MoveAlongPath(float distance) {
        // GD.Print("Character.MoveAlongPath()");
        // var debugScene = GetNode<DebugScene>(StaticStrings.debugScene);
        var timerEngine = GetNode<TimerEngine>("../../TimerEngine");

        var start = Position;
        for (int i = 0; i < characterPath.Count; i++) {
            var distToNext = start.DistanceTo(characterPath[i]);
            timerEngine.IncrementTimeValue(1);
            if (characterPath.Count == 1) {
                // GD.Print("Pop Menu for location");
                // debugScene.IncrementTimeValue(10);
                // infoScene.PresentLocationScene(GetNode<Character>(GameData.characterNodePath).Position);
                MySetProcess(false);
            }
            if (GameData.currentTime >= GameData.totalTime) {
                EndPlayerturn();
                break;
            }
            if (distance <= distToNext && distance >= 0.0) {
                // GD.Print("distance <= distToNext && distance >= 0.0");
                // GD.Print("distToNext: " + distToNext);
                // GD.Print("distance: " + distance);
                Position = start.LinearInterpolate(characterPath[i], distance / distToNext);
                break;
            } else if (distance < 0.0) {
                // GD.Print("else if (distance < 0.0)");
                // GD.Print("distance: " + distance);
                Position = characterPath[i];
                MySetProcess(false);
                break;
            }

            distance -= distToNext;
            start = characterPath[i];
            // GD.Print("end for loop distance: " + distance);
            characterPath.RemoveAt(i);
        }
    }

    public void EndPlayerturn() {
        characterPath.Clear();
        GetNode<Character>(StaticStrings.characterNodePath).ResetPlayerPosition();
        var debugScene = GetNode<Node>("/root/RootScene/InfoScene/Background").GetNode<DebugScene>("DebugScene");
        var timerEngine = GetNode<TimerEngine>("../TimerEngine");

        debugScene.SetStatusText("Your time is up!");
        timerEngine.IncrementRounds();
        timerEngine.ResetTimeUsed();
        
        MySetProcess(false);
    }

    public void SetCharacterPath(List<Vector2> path) {
        GD.Print("Character.SetCharacterPath()");
        GD.Print("path.count: " + path.Count);

        characterPath = path;
        MySetProcess(true);
    }

    // Capture if the character is moving to avoid tripping Area2D objects while moving
    public void MySetProcess(bool val) {
        moving = val;
        SetProcess(val);
    }
}
