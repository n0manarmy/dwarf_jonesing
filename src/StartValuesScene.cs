using Godot;
using System;
using Dwarf.GameDataObjects;
using Dwarf.StaticStrings;

public class StartValuesScene : Node2D
{
    [Signal]
    public delegate void GoalsValueUpdated();

    [Signal]
    public delegate void GoalsValuesDone(Vector2 ignore, bool disableLocationsButtons);

    private static String vboxContainerName =           "VBoxContainer/";
    private static String hboxGoalsContainerName =      "HBoxGoalsLabelContainer/";
    private static String hboxSliderContainerName =     "HBoxSliderContainer/";

    private static String goalsValue = vboxContainerName + 
        "HBoxGoalsLabelContainer/GoalsValue";

    private static String wealthSlider = vboxContainerName + 
        hboxSliderContainerName + "HBoxWealthContainer/WealthSlider";

    private static String happinessSlider = vboxContainerName + 
        hboxSliderContainerName + "HBoxHappinessContainer/HappinessSlider";
    
    private static String educationSlider = vboxContainerName + 
        hboxSliderContainerName + "HBoxEducationContainer/EducationSlider";

    private static String jobSlider = vboxContainerName + 
        hboxSliderContainerName + "HBoxJobContainer/JobSlider";

    /* 
    Required because slider connection passes a float value. Not doing any thing with float value but need
    to have the sliders pass their value to the label showing the total score.
    */
    public void SliderValueChanged(float x) {
        // UpdateGoalsValue();
        EmitSignal(nameof(GoalsValueUpdated));
    }
    
    /*
    Sets the value on the sliders to the max score for the player in gamedata. Increments the round counter to start the round
    which could be a problem when iterating multiple players. QueueFree clears the screen.
    TODO: add support for multiple players
    */
    public void OnDoneClicked() {
        GD.Print(this.GetType().Name + ".OnDoneClicked()");     
        EmitSignal(nameof(GoalsValuesDone), new Vector2(), false);
        // GetNode<DebugScene>(StaticStrings.debugScene)._Ready();
        QueueFree();
    }

    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {
        GD.Print(this.GetType().Name + "._Ready()");
        this.Connect("GoalsValueUpdated", this, nameof(UpdateGoalsValue));
    }

    public void UpdateGoalsValue() {
        GetNode<Label>(goalsValue).Text = (
            (int) GetNode<Slider>(wealthSlider).Value +
            (int) GetNode<Slider>(jobSlider).Value +
            (int) GetNode<Slider>(educationSlider).Value +
            (int) GetNode<Slider>(happinessSlider).Value
        ).ToString();
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
