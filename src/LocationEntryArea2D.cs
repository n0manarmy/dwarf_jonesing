using Godot;
using System;
using Dwarf.StaticStrings;

public class LocationEntryArea2D : Area2D
{
    // Declare member variables here. Examples:
    // private int a = 2;
    // private string b = "text";
    [Signal]
    public delegate void LocationEntered();

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
        GD.Print(this.GetType().Name + ".OnArea2DBodyEntered");
        // GD.Print(body.GetSlideCollision(0).Collider);
        var sprite = GetNodeOrNull<Sprite>("../../Player/Sprite");
        GD.Print("sprite: " + sprite);
        var travelPath = GetNodeOrNull<TileMap>("../TravelPathTileMap");
        if(travelPath == null) {
            GD.Print("travelPath: null");
        } else {
            GD.Print("travelPath: " + travelPath);   
        }
        GD.Print("this.Name: " + this.Name);
        var pos = new Vector2(sprite.Position);

        switch(this.Name) {
            case "Scene12":
                pos = new Vector2(07, 09);
                break;
            case "Scene11":
                pos = new Vector2(10, 19);
                break;
            case "Scene10":
                pos = new Vector2(07, 30);
                break;
            case "Scene09":
                pos = new Vector2(16, 40);
                break;
            case "Scene08":
                pos = new Vector2(27, 40);
                break;
            case "Scene07":
                pos = new Vector2(42, 43);
                break;
            case "Scene06":
                pos = new Vector2(52, 41);
                break;
            case "Scene05":
                pos = new Vector2(52, 41);
                break;
            case "Scene04":
                pos = new Vector2(59, 19);
                break;
            case "Scene03":
                pos = new Vector2(52, 08);
                break;
            case "Scene02":
                pos = new Vector2(42, 09);
                break;
            case "Scene01":
                pos = new Vector2(31, 08);
                break;
            case "Scene13":
                pos = new Vector2(20, 09);
                break;
            }
            
            pos.y = pos.y - 3;
            sprite.Position = travelPath.MapToWorld(pos);
            EmitSignal(nameof(LocationEntered), this.Name);


        //if player not moving, check location and send scene info to InfoScene
        // if (!_player.moving) {
        //     var _infoScene = GetNode<InfoScene>(StaticStrings.infoScene);
        //     var _travelPath = GetNode<TileMap>(StaticStrings.travelPathTileMap);
        //     var _tileMapPos = _travelPath.WorldToMap(GetNode<Player>(StaticStrings.characterNodePath).Position);

        //     Vector2 _currentPlayerPos = _player.Position;
        //     GD.Print("OnArea2DBodyEntered._currentPlayerPos: " + _currentPlayerPos);
        //     GD.Print("OnArea2DBodyEntered._tileMapPos: " + _tileMapPos);
        //     GD.Print("OnArea2DBodyEntered.Name: " + Name);
        //     var _locID = Name.Split("_")[0];
        //     GD.Print("OnArea2DBodyEntered._locID: " + _locID);

        //     // iterate over locations and when we find our location, move the player inside the building
        //     foreach(Location loc in GameData.locations) {
        //         if(loc.locationID == _locID) {
        //             _player.Position = _travelPath.MapToWorld(loc.getInsideBuildingLocation());
        //             break;
        //         }
        //     }
        //     //Call InfoScene to present location scene
        //     _infoScene.PresentLocationScene(_locID);

        // }
    }
}
