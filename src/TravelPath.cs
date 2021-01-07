using Godot;
using System;
using System.Collections.Generic;

public class TravelPath : Node

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

    public Vector2 START_POS = new Vector2(31, 9);
    // private List<Vector2> characterPath; //list of pathing points
    public String destName;
    private static int MAX_TIME = 500;

    private int pathPoints = 0;
    private int transition = 0;




    public override void _Ready()
    {
        MySetProcess(false);
        // DisableLocationsButtons(true);
    }

    public void DisableLocationsButtons(bool val) {
        GD.Print("TravelPath.DisableLocationsButtons()");
        var _buttonGroup = (ButtonGroup)GD.Load("res://res/LocationButtonResource.tres");
        
        foreach(Button _b in _buttonGroup.GetButtons()) {
            _b.Disabled = val;
        }
    }

    public void ResetPlayerPosition() {
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

        // var player = GetNode<Player>("Player");
        var buttons = GetNode<Node>("ButtonNode");

        // var pos = new Vector2();
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

        var player = GetNode<Player>("Player");

        //Convert tileset coords to World coords
        dst = GetNode<TileMap>("WalkingPath/TravelPathTileMap").MapToWorld(dst);
        GD.Print("Tileset to world coords: " + dst);
        // var nav2d = GetNode<Navigation2D>("WalkingPath").GetSimplePath(player.GlobalPosition, pos);
        // GD.Print("SimplePath: " + nav2d.ToString());
        // List<Vector2> pathList = new List<Vector2>(nav2d);
        // SetPlayerPath(pathList);
        // player.movement_path = pathList;
        player.movement_path = GetNode<Navigation2D>("WalkingPath").GetSimplePath(player.Position, dst);
        GD.Print(this.GetType().Name + ".player.movement_path.Length: " + player.movement_path.Length);
        foreach (Vector2 v in player.movement_path) {
            GD.Print(v);
        }
        // MySetProcess(true);
    }

    //iterates through characterPath coordinates, calculating distances between the points.
    public void MoveAlongPath(float distance) {
        GD.Print(this.GetType().Name + ".MoveAlongPath");
        var lastPos = GetNode<Node2D>("Player").Position;
        var player = GetNode<Player>("Player");
        // GD.Print("player.movement_path.Length: " + player.movement_path.Length);
        for(var i = 1; i < player.movement_path.Length; i++) {
            GD.Print("i: " + i);
            GD.Print("player.movement_path[i]: " + player.movement_path[i]);
            var distToNext = lastPos.DistanceTo(player.movement_path[i]);
            // timerEngine.IncrementTimeValue(1);
            player.turnTime = player.turnTime + 1;
            // if (player.movement_path.Length == 1) {
            //     // GD.Print("Pop Menu for location");
            //     // debugScene.IncrementTimeValue(10);
            //     // infoScene.PresentLocationScene(GetNode<Player>(GameData.characterNodePath).Position);
            //     MySetProcess(false);
            // }
            if (player.turnTime >= MAX_TIME) {
                EmitSignal(nameof(TurnOver));
                MySetProcess(false);
                break;
            }
            // if (distance <= distToNext && distance >= 0.0) {
            if (distance <= distToNext) {
                // GD.Print("distance <= distToNext && distance >= 0.0");
                // GD.Print("distToNext: " + distToNext);
                // GD.Print("distance: " + distance);
                // character.Position = start.LinearInterpolate(characterPath[i], distance / distToNext);
                var pos = lastPos.LinearInterpolate(player.movement_path[i], distance / distToNext);
                EmitSignal(nameof(PositionUpdated), pos);
                // character.Position = start.LinearInterpolate(characterPath[i], distance / distToNext);
                break;
            } 
            
            if (distance < 0.0) {
                // GD.Print("else if (distance < 0.0)");
                // GD.Print("distance: " + distance);
                // character.Position = characterPath[i];
                // var pos = lastPos.LinearInterpolate(player.movement_path[i], distance / distToNext);
                MySetProcess(false);
                EmitSignal(nameof(PositionUpdated), player.movement_path[0]);
                break;
            }

            // MySetProcess(false);
            distance -= distToNext;
            lastPos = player.movement_path[i];
            // start = player.movement_path[i];
            // GD.Print("end for loop distance: " + distance);
        }
    }

    // Capture if the character is moving to avoid tripping Area2D objects while moving
    public void MySetProcess(bool moving) {
        SetProcess(moving);
    }
    
    // Called every frame. 'delta' is the elapsed time since the previous frame.
    public override void _Process(float delta)
    {
        // GD.Print("_Process");
        var distance = speed * delta;
        MoveAlongPath(distance);
    }
}
