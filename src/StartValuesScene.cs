using Godot;
using System;
using Dwarf.GameDataObjects;
using Dwarf.StaticStrings;

public class StartValuesScene : Node
{
    private static String startingValuesNodeName =      "";
    private static String vboxContainerName =           "VBoxContainer/";
    private static String hboxGoalsContainerName =      "HBoxGoalsLabelContainer/";
    private static String hboxSliderContainerName =     "HBoxSliderContainer/";

    private static String goalsValue = startingValuesNodeName + 
        vboxContainerName + 
        "HBoxGoalsLabelContainer/GoalsValue";

    private static String wealthSlider = startingValuesNodeName + 
        vboxContainerName + 
        hboxSliderContainerName + "HBoxWealthContainer/WealthSlider";

    private static String happinessSlider = startingValuesNodeName + 
        vboxContainerName + 
        hboxSliderContainerName + "HBoxHappinessContainer/HappinessSlider";
    
    private static String educationSlider = startingValuesNodeName + 
        vboxContainerName + 
        hboxSliderContainerName + "HBoxEducationContainer/EducationSlider";

    private static String jobSlider = startingValuesNodeName + 
        vboxContainerName + 
        hboxSliderContainerName + "HBoxJobContainer/JobSlider";

    /* 
    Required because slider connection passes a float value. Not doing any thing with float value but need
    to have the sliders pass their value to the label showing the total score.
    */
    public void CallUpdateGoalsValue(float x) {
        GetNode<ScoringEngine>(StaticStrings.scoringEngine).SetMaxWealthScore(GameData.currentPlayer, (int) GetNode<Slider>(wealthSlider).Value);
        GetNode<ScoringEngine>(StaticStrings.scoringEngine).SetMaxJobScore(GameData.currentPlayer, (int) GetNode<Slider>(jobSlider).Value);
        GetNode<ScoringEngine>(StaticStrings.scoringEngine).SetMaxEducationScore(GameData.currentPlayer, (int) GetNode<Slider>(educationSlider).Value);
        GetNode<ScoringEngine>(StaticStrings.scoringEngine).SetMaxHappinessScore(GameData.currentPlayer, (int) GetNode<Slider>(happinessSlider).Value);
    }
    
    /*
    Sets the value on the sliders to the max score for the player in gamedata. Increments the round counter to start the round
    which could be a problem when iterating multiple players. QueueFree clears the screen.
    TODO: add support for multiple players
    */
    public void OnDoneClicked() {
        GD.Print("StartValuesScene.OnDoneClicked()");
        
        //enable all the location buttons
        var _buttons = (ButtonGroup)GD.Load("res://res/LocationButtonResource.tres");
        foreach(Button _b in _buttons.GetButtons()) {
            // GD.Print("_b.Name: " + _b.Name);
            _b.Disabled = false;
        }

        //Clear the slight transparent cover on the buttons
        var _coverLayer = GetNode<CanvasLayer>("/root/RootScene/BoardCoverLayer");
        _coverLayer.QueueFree();

        GameData.rounds += 1;
        GameData.UpdateEconomy();

        // GetNode<DebugScene>(StaticStrings.debugScene)._Ready();
        QueueFree();
    }

    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {
        GD.Print("StartValuesScene._Ready()");
        GetNode<ScoringEngine>(StaticStrings.scoringEngine).Connect("MaxScoreUpdated", this, nameof(UpdateMaxScore));
        // UpdateGoalsValue();
    }

    public void UpdateMaxScore(int val) {
        GetNode<Label>(goalsValue).Text = val.ToString();
    }

//  // Called every frame. 'delta' is the elapsed time since the previous frame.
//  public override void _Process(float delta)
//  {
//      
//  }
}
