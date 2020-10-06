using Godot;
using System;
using Dwarf.GameDataObjects;

public class StartingValuesNode : Node
{
    private static String startingValuesNodeName =      "/root/RootScene/InfoScreen/StartingValuesNode/";
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

    public void CallUpdateGoalsValue(float x) {
        UpdateGoalsValue();
    }

    public void UpdateGoalsValue() {
        var _wealthSlider = GetNode<Slider>(wealthSlider);
        var _happinessSlider = GetNode<Slider>(happinessSlider);
        var _educationSlider = GetNode<Slider>(educationSlider);
        var _jobSlider = GetNode<Slider>(jobSlider);
        GetNode<Label>(goalsValue).Text = (_wealthSlider.Value + _happinessSlider.Value + _educationSlider.Value + _jobSlider.Value).ToString();

    }

    public void OnDoneClicked() {
        // var gameData = GetNode<GameData>("/root/GameData");
        GameData.players[0].maxWealthScore = (int) GetNode<Slider>(wealthSlider).Value;
        GameData.players[0].maxHappinessScore = (int) GetNode<Slider>(happinessSlider).Value;
        GameData.players[0].maxJobScore = (int) GetNode<Slider>(jobSlider).Value;
        GameData.players[0].maxEducationScore = (int) GetNode<Slider>(educationSlider).Value;

        GetNode<Label>("/root/RootScene/InfoScreen/DebugNode/HBoxContainer/VBoxValues/MaxWealthScoreValue").Text = GameData.players[0].maxWealthScore.ToString();
        GetNode<Label>("/root/RootScene/InfoScreen/DebugNode/HBoxContainer/VBoxValues/MaxHappinessScoreValue").Text = GameData.players[0].maxHappinessScore.ToString();
        GetNode<Label>("/root/RootScene/InfoScreen/DebugNode/HBoxContainer/VBoxValues/MaxEducationScoreValue").Text = GameData.players[0].maxEducationScore.ToString();
        GetNode<Label>("/root/RootScene/InfoScreen/DebugNode/HBoxContainer/VBoxValues/MaxJobScoreValue").Text = GameData.players[0].maxJobScore.ToString();
        QueueFree();
    }

    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {
        UpdateGoalsValue();
    }

//  // Called every frame. 'delta' is the elapsed time since the previous frame.
//  public override void _Process(float delta)
//  {
//      
//  }
}
