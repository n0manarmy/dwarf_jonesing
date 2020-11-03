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
    public void OnArea2DBodyEntered(KinematicBody2D body) {
        //get player
        var _player = GetNode<Character>(GameData.characterNodePath);

        //if player not moving, check location and send scene info to InfoScene
        if (!_player.moving) {
            var _infoScene = GetNode<InfoScene>("/root/RootScene/InfoScene");
            var _travelPath = GetNode<TileMap>(GameData.travelPathTileMap);
            var _tileMapPos = _travelPath.WorldToMap(GetNode<Character>(GameData.characterNodePath).Position);

            Vector2 _currentPlayerPos = _player.Position;
            GD.Print("OnArea2DBodyEntered._currentPlayerPos: " + _currentPlayerPos);
            GD.Print("OnArea2DBodyEntered._tileMapPos: " + _tileMapPos);
            GD.Print("OnArea2DBodyEntered.Name: " + Name);
            var _locID = Name.Split("_")[0];
            GD.Print("OnArea2DBodyEntered._locID: " + _locID);

            // iterate over locations and when we find our location, move the player inside the building
            foreach(GameData.Location loc in GameData.locations) {
                if(loc.locationID == _locID) {
                    _player.Position = _travelPath.MapToWorld(loc.getInsideBuildingLocation());
                    break;
                }
            }
            //Call InfoScene to present location scene
            _infoScene.PresentLocationScene(_locID);

        }
    }
}
