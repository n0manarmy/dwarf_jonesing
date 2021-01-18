using Godot;
using System;

//TODO - Build Job button to check experience, availability, and education
//#About
//This class is the jobs class. The jobs listing and availability are controlled
//by this class.

[Signal]
public delegate void Scene02DoneClicked(Vector2 pos, bool disableLocButtons);

public class Scene02 : Node2D
{
    private String THIS_SCENE = "Scene01";
    private TravelPath travelPath;
    private TileMap travelPathTileMap;
    private Player player;
    private Sprite sprite;
    private Vector2 RETURN_POS = new Vector2(31, 10);

    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {
        GD.Print(this.GetType().Name + "._Ready");
        travelPath = GetNodeOrNull<TravelPath>("../../../TravelPath");
        if (null == travelPath) {
            GD.PrintErr(this.GetType().Name + ".travelPath is null");
        }       
        travelPathTileMap = GetNodeOrNull<TileMap>("../../../TravelPath/WalkingPath/TravelPathTileMap");
        if (null == travelPathTileMap) {
            GD.PrintErr(this.GetType().Name + ".travelPathTileMap is null");
        }
        player = GetNodeOrNull<Player>("../../Player");
        if (null == player) {
            GD.PrintErr(this.GetType().Name + ".player is null");
        }
        sprite = GetNodeOrNull<Sprite>("../../Player/Sprite");
        if (null == sprite) {
            GD.PrintErr(this.GetType().Name + ".sprite is null");
        }
        this.Hide();
    }
    
    public void OnDoneButtonClicked() {
        GD.Print(this.GetType().Name + ".OnDoneButtonClicked");
        EmitSignal(nameof(Scene02DoneClicked), RETURN_POS, false);
        QueueFree();
    }

//  // Called every frame. 'delta' is the elapsed time since the previous frame.
//  public override void _Process(float delta)
//  {
//      
//  }
}
