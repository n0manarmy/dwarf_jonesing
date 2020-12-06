using Godot;
using System;
using System.Collections.Generic;
using Dwarf.GameDataObjects;
using Dwarf.StaticStrings;

public class TravelPath : Node

{
    [Export]
    public PackedScene Character;
    // Called when the node enters the scene tree for the first time.

    private ButtonGroup _buttonGroup = (ButtonGroup)GD.Load("res://res/LocationButtonResource.tres");

    public override void _Ready()
    {

    }

    public void DisableLocationsButtons(bool val) {
        GD.Print("TravelPath.DisableLocationsButtons()");
        foreach(Button _b in _buttonGroup.GetButtons()) {
            _b.Disabled = val;
        }
    }

    // Colored squares on main map, connected to this function. Invisible button overlays
    // are matched against the location list in GameData. When a match is found, the pos is set
    // and a path is calculated by Godot. This path is then set in the character.
    public void OnButtonMovePressed() {
        GD.Print("OnButtonMovePressed()");

        var player = GetNode<Character>(StaticStrings.characterNodePath);
        var pos = player.GlobalPosition;

        // var gameData = (GameData)GetNode("/root/GameData");

        var buttons = GetNode<Node>("ButtonNode");

        foreach (Button button in buttons.GetChildren()) {
            if (button.Pressed == true) {
                foreach (GameData.Location location in GameData.locations) {
                    if (button.Name == location.buttonName) {
                        GD.Print(location.buttonName);
                        GD.Print(location.labelName);
                        GD.Print(location.tileMapPos);
                        pos = location.tileMapPos;
                        player.destName = location.buttonName;
                        break;
                    }
                }
            }
        }

        //Convert tileset coords to World coords
        pos = GetMapToWorld(pos);
        GD.Print("Tileset to world coords: " + pos);
        var nav2d = GetNode<Navigation2D>("WalkingPath");
        var newPath = nav2d.GetSimplePath(player.GlobalPosition, pos);
        GD.Print("SimplePath: " + newPath);
        List<Vector2> pathList = new List<Vector2>(newPath);
        player.SetCharacterPath(pathList);
    }

    public Vector2 GetMapToWorld(Vector2 pos) {
        var travelPath = GetNode<TileMap>("WalkingPath/TravelPathTileMap");
        return travelPath.MapToWorld(pos);
    }
}
