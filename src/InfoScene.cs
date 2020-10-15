using Godot;
using System;

using Dwarf.GameDataObjects;



public class InfoScene : Node
{
    // Declare member variables here. Examples:
    // private int a = 2;
    // private string b = "text";

    private PackedScene _startValuesScene = (PackedScene)GD.Load("res://scenes/StartValuesScene.tscn");
    private PackedScene _debugScene = (PackedScene)GD.Load("res://scenes/DebugScene.tscn");

    //Location menus
    private PackedScene _jobsLocationScene = (PackedScene)GD.Load("res://scenes/JobsLocationScene.tscn");

    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {
        Node startValues = _startValuesScene.Instance();
        Node debugScene = _debugScene.Instance();

        GetNode<CanvasLayer>("Background").AddChild(debugScene);
        GetNode<CanvasLayer>("Background").AddChild(startValues);
    }

    /*
    We send the location tag from the last stop of the player. Iterate over all the locations, converting their
    tileset location to the world grid location. If there's a map. Call that scene and present it.
    */
    public void PresentLocationScene(Vector2 locationTag) {
        GD.Print("InfoScene.PresentLocationScene");
        var travelPath = GetNode<TravelPath>("/root/RootScene/TravelPath");
        // GD.Print("LocationTag: " + locationTag.Floor());
        foreach(GameData.Location location in GameData.locations) {
            // GD.Print("location.timeMapPos" + travelPath.GetMapToWorld(location.tileMapPos));
            if(locationTag.Floor() == travelPath.GetMapToWorld(location.tileMapPos)) {
                switch (location.labelName) {
                case "LeSecurity":
                    GD.Print(location.labelName);
                    break;
                case "Market": 
                    GD.Print(location.labelName);
                    break;
                case "Bank":
                    GD.Print(location.labelName);
                    break;
                case "Factory":
                    GD.Print(location.labelName);
                    break;
                case "Employment":
                    GD.Print(location.labelName);
                    break;
                case "University":
                    GD.Print(location.labelName);
                    break;
                case "Stone and Carpentry":
                    GD.Print(location.labelName);
                    break;
                case "Clothing":
                    GD.Print(location.labelName);
                    break;
                case "Kitchen":
                    GD.Print(location.labelName);
                    break;
                case "Crafts":
                    GD.Print(location.labelName);
                    break;
                case "Pawn Shop":
                    GD.Print(location.labelName);
                    break;
                case "Dormitory":
                    GD.Print(location.labelName);
                    break;
                case "Rental Office":
                    GD.Print(location.labelName);
                    break;
                default:
                    break;
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
