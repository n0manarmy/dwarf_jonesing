using Godot;
using System;
using System.Collections.Generic;

public class TravelPath : Node2D

{
    // [Export]
    // public PackedScene Player;    
    [Export]
    private int speed = 300;

    [Export]
    public bool moving = false;

    [Signal]
    public delegate void PositionUpdated();

    [Signal]
    public delegate void TurnOver();

    public Vector2 START_POS = new Vector2(31, 10);
    // private List<Vector2> characterPath; //list of pathing points
    public String destName;
    private static int MAX_TIME = 500;

    public override void _Ready()
    {
        MySetProcess(false);
        // _scene01.Connect("Scene01DoneClicked", this, nameof(DisableLocationsButtons));

        var rootScene = GetNodeOrNull<RootScene>("../../RootScene");
        if (rootScene != null) {
            rootScene.Connect("StartupDisableLocationButtons", this, nameof(DisableLocationsButtons));
        }

        // GetNodeOrNull<Scene01Screen>("InfoScene/Scene01Screen").Connect("Scene01DoneClicked", this, nameof(DisableLocationsButtons));
        // GetNodeOrNull<Scene02>("InfoScene/Scene02").Connect("Scene02DoneClicked", this, nameof(DisableLocationsButtons));
        // GetNodeOrNull<Scene03>("InfoScene/Scene03").Connect("Scene03DoneClicked", this, nameof(DisableLocationsButtons));
        // GetNodeOrNull<Scene04>("InfoScene/Scene04").Connect("Scene04DoneClicked", this, nameof(DisableLocationsButtons));
        // GetNodeOrNull<Scene05>("InfoScene/Scene05").Connect("Scene05DoneClicked", this, nameof(DisableLocationsButtons));
        // GetNodeOrNull<Scene06>("InfoScene/Scene06").Connect("Scene06DoneClicked", this, nameof(DisableLocationsButtons));
        // GetNodeOrNull<Scene07>("InfoScene/Scene07").Connect("Scene07DoneClicked", this, nameof(DisableLocationsButtons));
        // GetNodeOrNull<Scene08>("InfoScene/Scene08").Connect("Scene08DoneClicked", this, nameof(DisableLocationsButtons));
        // GetNodeOrNull<Scene09>("InfoScene/Scene09").Connect("Scene09DoneClicked", this, nameof(DisableLocationsButtons));
        // GetNodeOrNull<Scene10>("InfoScene/Scene10").Connect("Scene10DoneClicked", this, nameof(DisableLocationsButtons));
        // GetNodeOrNull<Scene11>("InfoScene/Scene11").Connect("Scene11DoneClicked", this, nameof(DisableLocationsButtons));
        // GetNodeOrNull<Scene12>("InfoScene/Scene12").Connect("Scene12DoneClicked", this, nameof(DisableLocationsButtons));
        // GetNodeOrNull<Scene13>("InfoScene/Scene13").Connect("Scene13DoneClicked", this, nameof(DisableLocationsButtons));
        
        GetNodeOrNull<StartValuesScene>("../StartValuesScene").Connect("GoalsValueDone", this,  nameof(DisableLocationsButtons));

        GetNodeOrNull<LocationEntryArea2D>("WalkingPath/Scene01").Connect("LocationEntered", this,  nameof(DisableLocationsButtons));
        GetNodeOrNull<LocationEntryArea2D>("WalkingPath/Scene02").Connect("LocationEntered", this,  nameof(DisableLocationsButtons));
        GetNodeOrNull<LocationEntryArea2D>("WalkingPath/Scene03").Connect("LocationEntered", this,  nameof(DisableLocationsButtons));
        GetNodeOrNull<LocationEntryArea2D>("WalkingPath/Scene04").Connect("LocationEntered", this,  nameof(DisableLocationsButtons));
        GetNodeOrNull<LocationEntryArea2D>("WalkingPath/Scene05").Connect("LocationEntered", this,  nameof(DisableLocationsButtons));
        GetNodeOrNull<LocationEntryArea2D>("WalkingPath/Scene06").Connect("LocationEntered", this,  nameof(DisableLocationsButtons));
        GetNodeOrNull<LocationEntryArea2D>("WalkingPath/Scene07").Connect("LocationEntered", this,  nameof(DisableLocationsButtons));
        GetNodeOrNull<LocationEntryArea2D>("WalkingPath/Scene08").Connect("LocationEntered", this,  nameof(DisableLocationsButtons));
        GetNodeOrNull<LocationEntryArea2D>("WalkingPath/Scene09").Connect("LocationEntered", this,  nameof(DisableLocationsButtons));
        GetNodeOrNull<LocationEntryArea2D>("WalkingPath/Scene10").Connect("LocationEntered", this,  nameof(DisableLocationsButtons));
        GetNodeOrNull<LocationEntryArea2D>("WalkingPath/Scene11").Connect("LocationEntered", this,  nameof(DisableLocationsButtons));
        GetNodeOrNull<LocationEntryArea2D>("WalkingPath/Scene12").Connect("LocationEntered", this,  nameof(DisableLocationsButtons));
        GetNodeOrNull<LocationEntryArea2D>("WalkingPath/Scene13").Connect("LocationEntered", this,  nameof(DisableLocationsButtons));


    }

    public void DisableLocationsButtons(Vector2 _ignore, bool val) {
        GD.Print(this.GetType().Name + ".DisableLocationsButtons()");
        var _buttonGroup = (ButtonGroup)GD.Load("res://res/LocationButtonResource.tres");
        
        foreach(Button _b in _buttonGroup.GetButtons()) {
            _b.Disabled = val;
        }
    }

    public void ResetPlayerPosition() {
        GD.Print(this.GetType().Name + "ResetPlayerPosition");
        // var player = GetNode<Player>(StaticStrings.characterNodePath);
        var travelPathTileMap = GetNode<TileMap>("WalkingPath/TravelPathTileMap");
        // character.Position = travelPathTileMap.MapToWorld(START_POS);
        var pos = travelPathTileMap.MapToWorld(START_POS);
        EmitSignal(nameof(PositionUpdated), pos);
    }

    // Colored squares on main map, connected to this function. Invisible button overlays
    // are matched against the location list in GameData. When a match is found, the pos is set
    // and a path is calculated by Godot. This path is then set in the character.
    public void OnButtonMovePressed() {
        GD.Print(this.GetType().Name + ".OnButtonMovePressed()");

        var playerSprite = GetNode<Sprite>("Player/Sprite");
        var player = GetNode<Player>("Player");
        var buttons = GetNode<Node>("ButtonNode");
        var dst = new Vector2();

        foreach (Button button in buttons.GetChildren()) {
            if (button.Pressed == true) {
                MySetProcess(true);
                switch(button.Name) {
                case "12_MoveButton":
                    dst = new Vector2(07, 09);
                    GD.Print("button name: " + button.Name);
                    break;
                case "11_MoveButton":
                    dst = new Vector2(10, 19);
                    GD.Print("button name: " + button.Name);
                    break;
                case "10_MoveButton":
                    dst = new Vector2(07, 30);
                    GD.Print("button name: " + button.Name);
                    break;
                case "09_MoveButton":
                    dst = new Vector2(16, 40);
                    GD.Print("button name: " + button.Name);
                    break;
                case "08_MoveButton":
                    dst = new Vector2(27, 40);
                    GD.Print("button name: " + button.Name);
                    break;
                case "07_MoveButton":
                    dst = new Vector2(42, 43);
                    GD.Print("button name: " + button.Name);
                    break;
                case "06_MoveButton":
                    dst = new Vector2(52, 41);
                    GD.Print("button name: " + button.Name);
                    break;
                case "05_MoveButton":
                    dst = new Vector2(50, 29);
                    GD.Print("button name: " + button.Name);
                    break;
                case "04_MoveButton":
                    dst = new Vector2(59, 19);
                    GD.Print("button name: " + button.Name);
                    break;
                case "03_MoveButton":
                    dst = new Vector2(52, 08);
                    GD.Print("button name: " + button.Name);
                    break;
                case "02_MoveButton":
                    dst = new Vector2(42, 09);
                    GD.Print("button name: " + button.Name);
                    break;
                case "01_MoveButton":
                    dst = new Vector2(31, 08);
                    GD.Print("button name: " + button.Name);
                    break;
                case "13_MoveButton":
                    dst = new Vector2(20, 09);
                    GD.Print("button name: " + button.Name);
                    break;
                }
            }
        }


        //Convert tileset coords to World coords
        var travelPathTileMap = GetNode<TileMap>("WalkingPath/TravelPathTileMap");
        dst = travelPathTileMap.MapToWorld(dst);
        var path = GetNode<Navigation2D>("WalkingPath").GetSimplePath(playerSprite.Position, dst);
        player.movementPath = new List<Vector2>(path);

    }

    //iterates through characterPath coordinates, calculating distances between the points.
    public void MoveAlongPath(float distance) {
        GD.Print(this.GetType().Name + ".MoveAlongPath");
        var lastPos = GetNode<Sprite>("Player/Sprite").Position;
        var player = GetNode<Player>("Player");
        if(player.movementPath.Count == 0) {
            GD.Print("player.movement_path.Count: " + player.movementPath.Count);
            MySetProcess(false);
        }

        for(var i = 0; i < player.movementPath.Count; i++) {
            GD.Print("player.movement_path[i]: " + player.movementPath[i]);
            var distToNext = lastPos.DistanceTo(player.movementPath[i]);

            GD.Print("distToNext: " + distToNext);
            GD.Print("distance: " + distance);            
            // timerEngine.IncrementTimeValue(1);
            player.turnTime = player.turnTime + 1;
            if (player.movementPath.Count == 0) {
                GD.Print("Pop Menu for location");
                // debugScene.IncrementTimeValue(10);
                // infoScene.PresentLocationScene(GetNode<Player>(GameData.characterNodePath).Position);
                MySetProcess(false);
            }
            if (player.turnTime >= MAX_TIME) {
                EmitSignal(nameof(TurnOver));
                MySetProcess(false);
                break;
            }
            if (distance < 0.0) {
                GD.Print("distance < 0.0)");
                // GD.Print("distance: " + distance);
                // character.Position = characterPath[i];
                MySetProcess(false);
                EmitSignal(nameof(PositionUpdated), player.movementPath[i]);
                break;
            }
            // if (distance <= distToNext && distance >= 0.0) {
            if (distance <= distToNext) {
                GD.Print("distance <= distToNext");
                // GD.Print("distToNext: " + distToNext);
                // GD.Print("distance: " + distance);
                var pos = lastPos.LinearInterpolate(player.movementPath[i], distance / distToNext);
                EmitSignal(nameof(PositionUpdated), pos);
                break;
            } 

            distance -= distToNext;
            lastPos = player.movementPath[i];
            player.movementPath.RemoveAt(i);
        }
    }

    // Capture if the character is moving to avoid tripping Area2D objects while moving
    public void MySetProcess(bool moving) {
        SetProcess(moving);
    }
    
    // Called every frame. 'delta' is the elapsed time since the previous frame.
    public override void _Process(float delta)
    {
        GD.Print("_Process");
        var distance = speed * delta;
        MoveAlongPath(distance);
    }
}
