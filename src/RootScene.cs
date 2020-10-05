using Godot;
using System;
using System.Collections.Generic;
using Dwarf.GameDataObjects;

public class RootScene : Node2D
{
    // Declare member variables here. Examples:
    // private int a = 2;
    // private string b = "text";


    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {
        // GetNode<Character>("TravelPath/Character").Position = START_POS;
        GetNode<Character>(GameData.characterNodePath).ResetPlayerPosition();
        GetNode<InfoScreen>("/root/RootScene/InfoScreen").IncrementRounds();
    }

//  // Called every frame. 'delta' is the elapsed time since the previous frame.
//  public override void _Process(float delta)
//  {
//      
//  }
}
