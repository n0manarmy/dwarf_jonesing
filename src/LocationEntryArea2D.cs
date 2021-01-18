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
        var player = GetNodeOrNull<Player>("../../Player");
        var travelPathTileMap = GetNodeOrNull<TileMap>("../TravelPathTileMap");
        if(travelPathTileMap == null) {
            GD.Print("travelPath: null");
        } else {
            GD.Print("travelPath: " + travelPathTileMap);   
        }
        GD.Print(this.GetType().Name + ".this.Name: " + this.Name);
        var pos = new Vector2();

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
            player.UpdateSpritePosition(travelPathTileMap.MapToWorld(pos));
            GetNode<TravelPath>("../../../TravelPath").MySetProcess(false);
            EmitSignal(nameof(LocationEntered));

    }
}
