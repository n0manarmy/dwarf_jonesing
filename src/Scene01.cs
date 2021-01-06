using Godot;
using System;
using System.Collections.Generic;
using Dwarf.GameDataObjects;

//TODO - Build Job button to check experience, availability, and education
//#About
//This class is the jobs class. The jobs listing and availability are controlled
//by this class.

[Signal]
public delegate void SceneDoneClicked();

public class Scene01 : Node2D
{
    private String THIS_SCENE = "Scene01";

    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {
        
    }

    public void BuildSceneDetails() {
        GetNode<Label>("TextBackground/NameLabel").Text = GameData.GetLocation(THIS_SCENE).labelName;
    }

    public void OnDoneButtonClicked() {
        var node = GetNodeOrNull<TravelPath>("TravelPath");        
        if(node != null) {
            node.DisableLocationsButtons(false);
        }
        GetNode<Node2D>("../" + THIS_SCENE).ZIndex = 0;
        QueueFree();
    }

//  // Called every frame. 'delta' is the elapsed time since the previous frame.
//  public override void _Process(float delta)
//  {
//      
//  }
}
