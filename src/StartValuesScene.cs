using Godot;
using System;
using Dwarf.GameDataObjects;

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

    // Declare member variables here. Examples:
    // private int a = 2;
    // private string b = "text";

    /* 
    Required because slider connection passes a float value. Not doing any thing with float value but need
    to have the sliders pass their value to the label showing the total score.
    */
    public void CallUpdateGoalsValue(float x) {
        UpdateGoalsValue();
    }

    /*
    Collects the slider bars and then adds their current value, assigning to the label in the startvalues screen
    */
    public void UpdateGoalsValue() {
        var _wealthSlider = GetNode<Slider>(wealthSlider);
        var _happinessSlider = GetNode<Slider>(happinessSlider);
        var _educationSlider = GetNode<Slider>(educationSlider);
        var _jobSlider = GetNode<Slider>(jobSlider);
        
        GetNode<Label>(goalsValue).Text = (_wealthSlider.Value + _happinessSlider.Value + _educationSlider.Value + _jobSlider.Value).ToString();
    }

    /*
    Sets the value on the sliders to the max score for the player in gamedata. Increments the round counter to start the round
    which could be a problem when iterating multiple players. QueueFree clears the screen.
    TODO: add support for multiple players
    */
    public void OnDoneClicked() {
        GD.Print("StartValuesScene.OnDoneClicked()");
        // var gameData = GetNode<GameData>("/root/GameData");
        GameData.players[0].maxWealthScore = (int) GetNode<Slider>(wealthSlider).Value;
        GameData.players[0].maxHappinessScore = (int) GetNode<Slider>(happinessSlider).Value;
        GameData.players[0].maxJobScore = (int) GetNode<Slider>(jobSlider).Value;
        GameData.players[0].maxEducationScore = (int) GetNode<Slider>(educationSlider).Value;
        
        //enable all the location buttons
        var _buttons = (ButtonGroup)GD.Load("res://res/LocationButtonResource.tres");
        foreach(Button _b in _buttons.GetButtons()) {
            // GD.Print("_b.Name: " + _b.Name);
            _b.Disabled = false;
        }

        //Clear the slight transparent cover on the buttons
        var _coverLayer = GetNode<CanvasLayer>("/root/RootScene/BoardCoverLayer");
        _coverLayer.QueueFree();

        // GetNode<Label>("/root/RootScene/InfoScreen/DebugNode/HBoxContainer/VBoxValues/MaxWealthScoreValue").Text = GameData.players[0].maxWealthScore.ToString();
        // GetNode<Label>("/root/RootScene/InfoScreen/DebugNode/HBoxContainer/VBoxValues/MaxHappinessScoreValue").Text = GameData.players[0].maxHappinessScore.ToString();
        // GetNode<Label>("/root/RootScene/InfoScreen/DebugNode/HBoxContainer/VBoxValues/MaxEducationScoreValue").Text = GameData.players[0].maxEducationScore.ToString();
        // GetNode<Label>("/root/RootScene/InfoScreen/DebugNode/HBoxContainer/VBoxValues/MaxJobScoreValue").Text = GameData.players[0].maxJobScore.ToString();

        GetNode<DebugScene>("/root/RootScene/InfoScene/Background/DebugScene").IncrementRounds();

        QueueFree();
    }

    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {
        GD.Print("StartValuesScene._Ready()");
        UpdateGoalsValue();
    }

//  // Called every frame. 'delta' is the elapsed time since the previous frame.
//  public override void _Process(float delta)
//  {
//      
//  }
}
