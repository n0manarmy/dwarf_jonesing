using Godot;
using System;

public class InfoScene : Node2D
{
    [Signal]
    public delegate void DisableLocationsButtons();

    // private PackedScene _startValuesScene = (PackedScene)GD.Load("res://scenes/StartValuesScene.tscn");
    // private PackedScene _debugScene = (PackedScene)GD.Load("res://scenes/DebugScene.tscn");
    // private PackedScene _scene01 = (PackedScene)ResourceLoader.Load("res://scenes/Scene01.tscn");
    // private PackedScene _scene02 = (PackedScene)ResourceLoader.Load("res://scenes/Scene02.tscn");
    // private PackedScene _scene03 = (PackedScene)ResourceLoader.Load("res://scenes/Scene03.tscn");
    // private PackedScene _scene04 = (PackedScene)ResourceLoader.Load("res://scenes/Scene04.tscn");
    // private PackedScene _scene05 = (PackedScene)ResourceLoader.Load("res://scenes/Scene05.tscn");
    // private PackedScene _scene06 = (PackedScene)ResourceLoader.Load("res://scenes/Scene06.tscn");
    // private PackedScene _scene07 = (PackedScene)ResourceLoader.Load("res://scenes/Scene07.tscn");
    // private PackedScene _scene08 = (PackedScene)ResourceLoader.Load("res://scenes/Scene08.tscn");
    // private PackedScene _scene09 = (PackedScene)ResourceLoader.Load("res://scenes/Scene09.tscn");
    // private PackedScene _scene10 = (PackedScene)ResourceLoader.Load("res://scenes/Scene10.tscn");
    // private PackedScene _scene11 = (PackedScene)ResourceLoader.Load("res://scenes/Scene11.tscn");
    // private PackedScene _scene12 = (PackedScene)ResourceLoader.Load("res://scenes/Scene12.tscn");
    // private PackedScene _scene13 = (PackedScene)ResourceLoader.Load("res://scenes/Scene13.tscn");

    private Scene01Screen scene01;
    private Scene02 scene02;
    private Scene03 scene03;
    private Scene04 scene04;
    private Scene05 scene05;
    private Scene06 scene06;
    private Scene07 scene07;
    private Scene08 scene08;
    private Scene09 scene09;
    private Scene10 scene10;
    private Scene11 scene11;
    private Scene12 scene12;
    private Scene13 scene13;

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
        GetNodeOrNull<LocationEntryArea2D>("../WalkingPath/Scene02").Connect("LocationEntered", this,  nameof(PresentLocationScene));
        GetNodeOrNull<LocationEntryArea2D>("../WalkingPath/Scene03").Connect("LocationEntered", this,  nameof(PresentLocationScene));
        GetNodeOrNull<LocationEntryArea2D>("../WalkingPath/Scene04").Connect("LocationEntered", this,  nameof(PresentLocationScene));
        GetNodeOrNull<LocationEntryArea2D>("../WalkingPath/Scene05").Connect("LocationEntered", this,  nameof(PresentLocationScene));
        GetNodeOrNull<LocationEntryArea2D>("../WalkingPath/Scene06").Connect("LocationEntered", this,  nameof(PresentLocationScene));
        GetNodeOrNull<LocationEntryArea2D>("../WalkingPath/Scene07").Connect("LocationEntered", this,  nameof(PresentLocationScene));
        GetNodeOrNull<LocationEntryArea2D>("../WalkingPath/Scene08").Connect("LocationEntered", this,  nameof(PresentLocationScene));
        GetNodeOrNull<LocationEntryArea2D>("../WalkingPath/Scene09").Connect("LocationEntered", this,  nameof(PresentLocationScene));
        GetNodeOrNull<LocationEntryArea2D>("../WalkingPath/Scene10").Connect("LocationEntered", this,  nameof(PresentLocationScene));
        GetNodeOrNull<LocationEntryArea2D>("../WalkingPath/Scene11").Connect("LocationEntered", this,  nameof(PresentLocationScene));
        GetNodeOrNull<LocationEntryArea2D>("../WalkingPath/Scene12").Connect("LocationEntered", this,  nameof(PresentLocationScene));
        GetNodeOrNull<LocationEntryArea2D>("../WalkingPath/Scene13").Connect("LocationEntered", this,  nameof(PresentLocationScene));

        scene01 = GetNodeOrNull<Scene01Screen>("Scene01Screen");
        scene02 = GetNodeOrNull<Scene02>("Scene02");
        scene03 = GetNodeOrNull<Scene03>("Scene03");
        scene04 = GetNodeOrNull<Scene04>("Scene04");
        scene05 = GetNodeOrNull<Scene05>("Scene05");
        scene06 = GetNodeOrNull<Scene06>("Scene06");
        scene07 = GetNodeOrNull<Scene07>("Scene07");
        scene08 = GetNodeOrNull<Scene08>("Scene08");
        scene09 = GetNodeOrNull<Scene09>("Scene09");
        scene10 = GetNodeOrNull<Scene10>("Scene10");
        scene11 = GetNodeOrNull<Scene11>("Scene11");
        scene12 = GetNodeOrNull<Scene12>("Scene12");
        scene13 = GetNodeOrNull<Scene13>("Scene13");

        scene01.Hide();
        scene02.Hide();
        scene03.Hide();
        scene04.Hide();
        scene05.Hide();
        scene06.Hide();
        scene07.Hide();
        scene08.Hide();
        scene09.Hide();
        scene10.Hide();
        scene11.Hide();
        scene12.Hide();
        scene13.Hide();
    }

    /*
    We send the location tag from the last stop of the player. Iterate over all the locations, converting their
    tileset location to the world grid location. If there's a map. Call that scene and present it.
    */
    //TODO Continue building menu for each location
    public void PresentLocationScene(String _locID) {
        GD.Print(this.GetType().Name + ".PresentLocationScene");
        GD.Print(this.GetType().Name +"_locID: " + _locID);
        var travelPath = GetNodeOrNull<TravelPath>("../../TravelPath");
        if (travelPath == null) {
            GD.Print(this.GetType().Name +".travelPath == null");
            GetTree().Quit();
        }
        // var infoScene = GetNode<Node2D>("../InfoScene");
        
        EmitSignal(nameof(DisableLocationsButtons), new Vector2(0,0), true);
        GD.Print(this.GetType().Name +"._locID: " + _locID); 

        switch (_locID) {
            case "Scene01": 
                // this.AddChild(_scene01.Instance());
                scene01.Show();
                GD.Print(this.GetType().Name + "scene01.Show();");
                break;
            case "Scene02": 
                // this.AddChild(_scene02.Instance());
                scene02.Show();
                GD.Print(this.GetType().Name + "scene02.Show();");
                break;
            case "Scene03": 
                // this.AddChild(_scene03.Instance());
                scene03.Show();
                GD.Print(this.GetType().Name + "scene03.Show();");
                break;
            case "Scene04": 
                // thisAddChild(_scene04.Instance());
                scene04.Show();
                GD.Print(this.GetType().Name + "scene04.Show();");
                break;
            case "Scene05": 
                // this.AddChild(_scene05.Instance());
                scene05.Show();
                GD.Print(this.GetType().Name + "scene05.Show();");
                break;
            case "Scene06": 
                // this.AddChild(_scene06.Instance());
                scene06.Show();
                GD.Print(this.GetType().Name + "scene06.Show();");
                break;
            case "Scene07": 
                // this.AddChild(_scene07.Instance());
                scene07.Show();
                GD.Print(this.GetType().Name + "scene07.Show();");
                break;
            case "Scene08": 
                // this.AddChild(_scene08.Instance());
                scene08.Show();
                GD.Print(this.GetType().Name + "scene08.Show();");
                break; 
            case "Scene09": 
                // this.AddChild(_scene09.Instance()); 
                scene09.Show();
                GD.Print(this.GetType().Name + "scene09.Show();");
                break;
            case "Scene10": 
                // this.AddChild(_scene10.Instance()); 
                scene10.Show();
                GD.Print(this.GetType().Name + "scene10.Show();");
                break;
            case "Scene11": 
                // this.AddChild(_scene11.Instance()); 
                scene11.Show();
                GD.Print(this.GetType().Name + "scene11.Show();");
                break;
            case "Scene12": 
                // this.AddChild(_scene12.Instance()); 
                scene12.Show();
                GD.Print(this.GetType().Name + "scene12.Show();");
                break;
            case "Scene13": 
                // this.AddChild(_scene13.Instance()); 
                scene13.Show();
                GD.Print(this.GetType().Name + "scene13.Show();");
                break;
            default: 
                break;
        }
    }

//  // Called every frame. 'delta' is the elapsed time since the previous frame.
//  public override void _Process(float delta)
//  {
//      
//  }

}
