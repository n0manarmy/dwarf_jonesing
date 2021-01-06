using Godot;
using System;

public class InfoScene : Node2D
{
    // Declare member variables here. Examples:
    // private int a = 2;
    // private string b = "text";

    // private PackedScene _startValuesScene = (PackedScene)GD.Load("res://scenes/StartValuesScene.tscn");
    // private PackedScene _debugScene = (PackedScene)GD.Load("res://scenes/DebugScene.tscn");
    private PackedScene _scene08 = (PackedScene)ResourceLoader.Load("res://scenes/Scene08.tscn");
    private PackedScene _scene01 = (PackedScene)ResourceLoader.Load("res://scenes/Scene01.tscn");

    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {
        GD.Print(this.GetType().Name + "._Ready()");
        // Node startValues = _startValuesScene.Instance();
        // Node debugScene = _debugScene.Instance();
        // Node storeScreenPlaceholder = _storeScreenPlaceholder.Instance();

        // GetNode<CanvasLayer>("Background").AddChild(debugScene);
        // GetNode<CanvasLayer>("Background").AddChild(startValues);
         GetNodeOrNull<LocationEntryArea2D>("../WalkingPath/Scene01").Connect("LocationEntered", this,  nameof(PresentLocationScene));
    }

    /*
    We send the location tag from the last stop of the player. Iterate over all the locations, converting their
    tileset location to the world grid location. If there's a map. Call that scene and present it.
    */
    //TODO Continue building menu for each location
    public void PresentLocationScene(String _locID) {
        GD.Print(this.GetType().Name + ".PresentLocationScene");
        GD.Print("_locID: " + _locID);
        var travelPath = GetNodeOrNull<TravelPath>("../../TravelPath");
        if (travelPath == null) {
            GD.Print("travelPath == null");
            GetTree().Quit();
        }
        // var infoScene = GetNode<Node2D>("../InfoScene");
        
        travelPath.DisableLocationsButtons(true);

        switch (_locID) {
            case "Scene01": 
                GD.Print("_locID: " + _locID); 
                this.AddChild(_scene01.Instance());
                break;
            case "Scene02": GD.Print("_locID: " + _locID); break;
            case "Scene03": GD.Print("_locID: " + _locID); break;
            case "Scene04": GD.Print("_locID: " + _locID); break;
            case "Scene05": GD.Print("_locID: " + _locID); break;
            case "Scene06": GD.Print("_locID: " + _locID); break;
            case "Scene07": GD.Print("_locID: " + _locID); break;
            case "Scene08": 
                GD.Print("_locID: " + _locID);
                this.AddChild(_scene08.Instance());
                break; 
            case "Scene09": GD.Print("_locID: " + _locID); break;
            case "Scene10": GD.Print("_locID: " + _locID); break;
            case "Scene11": GD.Print("_locID: " + _locID); break;
            case "Scene12": GD.Print("_locID: " + _locID); break;
            case "Scene13": GD.Print("_locID: " + _locID); break;
            default: break;
        }
    }

    // public void OnArea2DBodyEntered(KinematicBody2D body) {
    //     GD.Print(this.GetType().Name + ".OnArea2DBodyEntered");
    //     // GD.Print(body.GetSlideCollision(0).Collider);
    //     var sprite = GetNodeOrNull<Sprite>("../Player/Sprite");
    //     if (sprite == null) {GD.Print("sprite: null");} else {GD.Print("sprite: " + sprite);}
        
    //     var travelPathTileMap = GetNodeOrNull<TileMap>("TravelPath/WalkingPath/TravelPathTileMap");
    //     if (travelPathTileMap == null) {GD.Print("travelPathTileMap: null");} else {GD.Print("travelPathTileMap: " + travelPathTileMap);}

    //     GD.Print("travelPath: " + travelPathTileMap);
    //     GD.Print("this.Name: " + this.Name);
    //     var pos = new Vector2(sprite.Position);

    //     // var infoScene = GetNode<InfoScene>("../InfoScene");
    //     var travelPath = GetNode<TravelPath>("TravelPath");
    //     travelPath.DisableLocationsButtons(true);

    //     switch(this.Name) {
    //         case "Scene12":
    //             pos = new Vector2(07, 09);
    //             break;
    //         case "Scene11":
    //             pos = new Vector2(10, 19);
    //             break;
    //         case "Scene10":
    //             pos = new Vector2(07, 30);
    //             break;
    //         case "Scene09":
    //             pos = new Vector2(16, 40);
    //             break;
    //         case "Scene08":
    //             pos = new Vector2(27, 40);
    //             this.AddChild(_scene08.Instance());
    //             break;
    //         case "Scene07":
    //             pos = new Vector2(42, 43);
    //             break;
    //         case "Scene06":
    //             pos = new Vector2(52, 41);
    //             break;
    //         case "Scene05":
    //             pos = new Vector2(52, 41);
    //             break;
    //         case "Scene04":
    //             pos = new Vector2(59, 19);
    //             break;
    //         case "Scene03":
    //             pos = new Vector2(52, 08);
    //             break;
    //         case "Scene02":
    //             pos = new Vector2(42, 09);
    //             break;
    //         case "Scene01":
    //             pos = new Vector2(31, 08);
    //             break;
    //         case "Scene13_Area2D":
    //             pos = new Vector2(20, 09);
    //             break;
    //         }
            
    //         pos.y = pos.y - 3;
    //         sprite.Position = travelPathTileMap.MapToWorld(pos);


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
    // }

//  // Called every frame. 'delta' is the elapsed time since the previous frame.
//  public override void _Process(float delta)
//  {
//      
//  }

}
