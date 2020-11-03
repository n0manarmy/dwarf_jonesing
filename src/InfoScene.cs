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
    private PackedScene _scene08 = (PackedScene)GD.Load("res://scenes/Scene08.tscn");

    private ButtonGroup _buttonGroup = (ButtonGroup)GD.Load("res://res/LocationButtonResource.tres");

    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {
        Node startValues = _startValuesScene.Instance();
        Node debugScene = _debugScene.Instance();
        // Node storeScreenPlaceholder = _storeScreenPlaceholder.Instance();
        Node scene08 = _scene08.Instance();

        GetNode<CanvasLayer>("Background").AddChild(debugScene);
        GetNode<CanvasLayer>("Background").AddChild(startValues);
        // GetNode<CanvasLayer>("Background").AddChild(scene08);
    }

    public void DisableLocationsButtons(bool val) {
        GD.Print("InfoScene.ChangeLocationsButtons()");
        foreach(Button _b in _buttonGroup.GetButtons()) {
            _b.Disabled = val;
        }
    }

    /*
    We send the location tag from the last stop of the player. Iterate over all the locations, converting their
    tileset location to the world grid location. If there's a map. Call that scene and present it.
    */
    //TODO Continue building menu for each location
    public void PresentLocationScene(String _locID) {
        GD.Print("InfoScene.PresentLocationScene");
        
        var travelPath = GetNode<TravelPath>("/root/RootScene/TravelPath");
        
        DisableLocationsButtons(true);

        foreach(GameData.Location location in GameData.locations) {
            if(location.locationID == _locID) {
                switch (_locID) {
                case "01": GD.Print(location.labelName); break;
                case "02": GD.Print(location.labelName); break;
                case "03": GD.Print(location.labelName); break;
                case "04": GD.Print(location.labelName); break;
                case "05": GD.Print(location.labelName); break;
                case "06": GD.Print(location.labelName); break;
                case "07": GD.Print(location.labelName); break;
                case "08": 
                    GD.Print(location.labelName);
                    GetNode<CanvasLayer>("Background").AddChild(_scene08.Instance());
                    break; 
                case "09": GD.Print(location.labelName); break;
                case "10": GD.Print(location.labelName); break;
                case "11": GD.Print(location.labelName); break;
                case "12": GD.Print(location.labelName); break;
                case "13": GD.Print(location.labelName); break;
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
