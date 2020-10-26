using Godot;
using System;
using Dwarf.GameDataObjects;

public class LocationEntryArea2D : Area2D
{
    // Declare member variables here. Examples:
    // private int a = 2;
    // private string b = "text";

    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {
        
    }

//  // Called every frame. 'delta' is the elapsed time since the previous frame.
//  public override void _Process(float delta)
//  {
//      
//  }

    //listener for player moving around the board. If player not moving and on Area2d box
    //then move player inside of the building. 
    //TODO disable buttons until player clicks done? This would prevent player from "moving"
    //through the building out to the road. Done button would move player back to the road.
    public void OnArea2DBodyEntered(KinematicBody2D body) {
        var _player = GetNode<Character>(GameData.characterNodePath);
        if (!_player.moving) {
            ButtonGroup _buttonGroup = (ButtonGroup)GD.Load("res://res/LocationButtonResource.tres");
            var _infoScene = GetNode<InfoScene>("/root/RootScene/InfoScene");
            var _travelPath = GetNode<TileMap>(GameData.travelPathTileMap);
            var _tileMapPos = _travelPath.WorldToMap(GetNode<Character>(GameData.characterNodePath).Position);

            foreach(Button _b in _buttonGroup.GetButtons()) {
                _b.Disabled = true;
            }
            Vector2 _currentPlayerPos = _player.Position;
            GD.Print("_currentPlayerPos: " + _currentPlayerPos);

            GD.Print(_tileMapPos);
            GD.Print(Name);
            var _locID = Name.Split("_")[0];

            foreach(GameData.Location loc in GameData.locations) {
                if(loc.locationID == _locID) {
                    _player.Position = _travelPath.MapToWorld(loc.getInsideBuildingLocation());
                    break;
                }
            }
        }
    }
}