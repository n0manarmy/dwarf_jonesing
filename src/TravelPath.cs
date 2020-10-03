using Godot;
using System;
using System.Collections.Generic;
using Dwarf.GameDataObjects;

public class TravelPath : Node
{
    [Export]
    public PackedScene Character;
    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {
        var tween = GetNode<Tween>("WalkingEffect");
        tween.Repeat = true;
        var player = GetNode<Character>("Character");
        tween.InterpolateProperty(player, "position", 0, 1, 6, Tween.TransitionType.Linear, Tween.EaseType.InOut);
        GD.Print("WalkingPath._Ready()");
        tween.Start();
    }

    public void OnButtonMovePressed() {
        GD.Print("OnButtonMovePressed()");

        var player = GetNode<Character>("/root/RootScene/TravelPath/Character");
        var travelPath = GetNode<TileMap>("WalkingPath/TravelPathTileMap");
        var pos = player.GlobalPosition;

        var gameData = (GameData)GetNode("/root/GameData");

        var buttons = GetNode<Node>("ButtonNode");

        foreach (Button button in buttons.GetChildren()) {
            if (button.Pressed == true) {
                foreach (GameData.Location location in GameData.locations) {
                    if (button.Name == location.buttonName) {
                        GD.Print(location.buttonName);
                        GD.Print(location.labelName);
                        GD.Print(location.tileMapPos);
                        pos = location.tileMapPos;
                        break;
                    }
                }
            }
        }

        pos = travelPath.MapToWorld(pos);
        var nav2d = GetNode<Navigation2D>("WalkingPath");
        var newPath = nav2d.GetSimplePath(player.GlobalPosition, pos);
        List<Vector2> pathList = new List<Vector2>(newPath);
        player.SetCharacterPath(pathList);
    }
}
