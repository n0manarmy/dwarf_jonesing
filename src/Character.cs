using Godot;
using System;
using System.Collections.Generic;

public class Character : Sprite
{
    // Declare member variables here. Examples:
    // private int a = 2;
    // private string b = "text";

    private List<Vector2> characterPath; //list of pathing points
    private Vector2 START_POS = new Vector2(31, 9);
    private static String characterNodePath = "/root/RootScene/TravelPath/Character";

    [Export]
    private int speed = 300;

    [Export]
    public bool eaten = false;

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

    public void ResetPlayerPosition() {
        var player = GetNode<Character>(characterNodePath);
        var travelPath = GetNode<TileMap>("/root/RootScene/TravelPath/WalkingPath/TravelPathTileMap");
        player.Position = travelPath.MapToWorld(START_POS);
        
    }

    public void MoveAlongPath(float distance) {
        // GD.Print("MoveAlongPath");
        var start = Position;
        var infoScreen = GetNode<InfoScreen>("/root/RootScene/InfoScreen");
        // GD.Print(start);
        // foreach(var i in characterPath) {
        for (int i = 0; i < characterPath.Count; i++) {
            var distToNext = start.DistanceTo(characterPath[i]);
            infoScreen.updateCurrentTimeValue(1);
            if (characterPath.Count == 1) {
                infoScreen.updateCurrentTimeValue(10);
                GD.Print("Pop Menu for location");

            }
            if (infoScreen.currentTime >= infoScreen.totalTime) {
                infoScreen.setStatusText("Your time is up!");
                characterPath.Clear();
                GetNode<Character>(characterNodePath).ResetPlayerPosition();
                break;
            }
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
            GD.Print("path.Count == 0");
            SetProcess(false);
            return;
        } else {
            GD.Print("path.Count != 0");
            SetProcess(true);
        }
    }
}
