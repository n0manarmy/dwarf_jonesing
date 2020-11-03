using Godot;
using System;
using Dwarf.GameDataObjects;

public class LocationScene : Node
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
    Sets the value on the sliders to the max score for the player in gamedata. Increments the round counter to start the round
    which could be a problem when iterating multiple players. QueueFree clears the screen.
    TODO: add support for multiple players
    */
    public void OnDoneClicked() {
        GetNode<InfoScene>("/root/RootScene/InfoScene").DisableLocationsButtons(false);
        QueueFree();
    }

    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {
        GD.Print("StartValuesScene._Ready()");
    }

//  // Called every frame. 'delta' is the elapsed time since the previous frame.
//  public override void _Process(float delta)
//  {
//      
//  }
}
