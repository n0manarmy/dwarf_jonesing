using Godot;
using System;
using System.Collections.Generic;
// using Dwarf.GameDataObjects;
// using Dwarf.StaticStrings;


public class Player : Node2D
{
    // Declare member variables here. Examples:
    // private int a = 2;
    // private string b = "text";

    // public Job job = GameData.jobs[0];
    [Export]
    private int workExp = 0;
    [Export]
    private bool eaten = false;
    [Export]
    private int happinessScore = 0;
    [Export]
    private int maxHappinessScore = 0;
    [Export]
    private int wealthScore = 0;
    [Export]
    private int maxWealthScore = 0;
    [Export]
    private int jobScore = 0;
    [Export]
    private int maxJobScore = 0;
    [Export]
    private int educationScore = 0;
    [Export]
    private int maxEducationScore = 0;
    [Export]
    public int turnTime = 0;

    public List<Vector2> movementPath;

    private TileMap travelPathTileMap;
    // public List<Degree> playerDegrees = new List<Degree>();

        //     public Player(int pos, int maxHappinessScore, int maxWealthScore, int maxJobScore, int maxEducationScore) {
        //         this.pos = pos;
        //         this.maxHappinessScore = maxHappinessScore;
        //         this.maxWealthScore = maxWealthScore;
        //         this.maxJobScore = maxJobScore;
        //         this.maxEducationScore = maxEducationScore;
        //         this.playerDegrees.Add(GameData.degrees[0]);
        //     }

        //     public void SetJob(Job job) {
        //         this.job = job;
        //     }
        // }

    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {
        GD.Print(this.GetType().Name + "._Ready()");
        GetNode<TravelPath>("../../TravelPath").Connect("PositionUpdated", this, nameof(UpdateSpritePosition));
        GetNode<TravelPath>("../../TravelPath").Connect("TurnOver", this, nameof(EndPlayerturn));

        travelPathTileMap = GetNode<TileMap>("../WalkingPath/TravelPathTileMap");
    }

    public void UpdateSpritePosition(Vector2 pos) {
        GD.Print(this.GetType().Name + ".UpdateSpritePosition");
        GD.Print(this.GetType().Name + ".pos.x: " + pos.x + " pos.y: " + pos.y);
        // GetNode<Sprite>("Sprite").Position = travelPathTileMap.MapToWorld(pos);
        GetNode<Sprite>("Sprite").Position = pos;
        // this.Position =pos;
    }

    public void EndPlayerturn() {
        GD.Print(this.GetType().Name + ".EndPlayerturn");
        var travelPath = GetNode<TravelPath>("../../TravelPath");
        var travelPathTileMap = GetNode<TileMap>("../WalkingPath/TravelPathTileMap");
        UpdateSpritePosition(travelPathTileMap.MapToWorld(GetNode<TravelPath>("../../TravelPath").START_POS));

        // var debugScene = GetNode<DebugScene>("../../DebugScene");
        // var timerEngine = GetNode<TimerEngine>("../../TimerEngine");
        // debugScene.SetStatusText("Your time is up!");
        // timerEngine.IncrementRounds();
        // timerEngine.ResetTimeUsed();
    }
}
