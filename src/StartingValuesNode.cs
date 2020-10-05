using Godot;
using System;

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
