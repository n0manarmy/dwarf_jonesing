using Godot;
using System;

using Dwarf.GameDataObjects;



public class InfoScene : Node2D
{
    // Declare member variables here. Examples:
    // private int a = 2;
    // private string b = "text";

    // private PackedScene _startValuesScene = (PackedScene)GD.Load("res://scenes/StartValuesScene.tscn");
    // private PackedScene _debugScene = (PackedScene)GD.Load("res://scenes/DebugScene.tscn");
    // private PackedScene _scene08 = (PackedScene)GD.Load("res://scenes/Scene08.tscn");


    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {
        GD.Print(this.GetType().Name + "._Ready()");
        // Node startValues = _startValuesScene.Instance();
        // Node debugScene = _debugScene.Instance();
        // Node storeScreenPlaceholder = _storeScreenPlaceholder.Instance();

        // GetNode<CanvasLayer>("Background").AddChild(debugScene);
        // GetNode<CanvasLayer>("Background").AddChild(startValues);
    }

    /*
    We send the location tag from the last stop of the player. Iterate over all the locations, converting their
    tileset location to the world grid location. If there's a map. Call that scene and present it.
    */
    //TODO Continue building menu for each location
    public void PresentLocationScene(String _locID) {
        GD.Print("InfoScene.PresentLocationScene");
        
        var travelPath = GetNode<TravelPath>("/root/RootScene/TravelPath");
        
        travelPath.DisableLocationsButtons(true);

        foreach(GameData.Location location in GameData.locations) {
            if(location.locationID == _locID) {
                var debugScene = GetNodeOrNull<DebugScene>("DebugScene");
                if (debugScene != null) {
                    debugScene.SetProcess(false);
                }
                switch (_locID) {
                case "Scene01": GD.Print("location.locationID: " + location.locationID); break;
                case "Scene02": GD.Print("location.locationID: " + location.locationID); break;
                case "Scene03": GD.Print("location.locationID: " + location.locationID); break;
                case "Scene04": GD.Print("location.locationID: " + location.locationID); break;
                case "Scene05": GD.Print("location.locationID: " + location.locationID); break;
                case "Scene06": GD.Print("location.locationID: " + location.locationID); break;
                case "Scene07": GD.Print("location.locationID: " + location.locationID); break;
                case "Scene08": 
                    GD.Print("location.locationID: " + location.locationID);
                    GetNode<Node2D>("../InfoScene/" + location.locationID).ZIndex = 10;
                    break; 
                case "Scene09": GD.Print("location.locationID: " + location.locationID); break;
                case "Scene10": GD.Print("location.locationID: " + location.locationID); break;
                case "Scene11": GD.Print("location.locationID: " + location.locationID); break;
                case "Scene12": GD.Print("location.locationID: " + location.locationID); break;
                case "Scene13": GD.Print("location.locationID: " + location.locationID); break;
                default: break;
                }
            }
        }
    }

//  // Called every frame. 'delta' is the elapsed time since the previous frame.
//  public override void _Process(float delta)
//  {
//      
//  }

}
