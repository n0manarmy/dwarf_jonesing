using Godot;
using System;
using System.Collections.Generic;
using Dwarf.GameDataObjects;

//TODO - Build Job button to check experience, availability, and education

public class Scene08 : Node2D
{
    enum MenuState {
        CompaniesList,
        JobsList,
    }

    private MenuState _thisMenuState = MenuState.CompaniesList;

    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {
        BuildSceneDetails();
        BuildCompaniesListButtons(); 
    }

    public void BuildSceneDetails() {
        GetNode<Label>("TextBackground/NameLabel").Text = GameData.GetLocation("08").labelName;
    }

    public void BuildCompaniesListButtons() {
        _thisMenuState = MenuState.CompaniesList;
        var _jobsButtonNode = GetNode<VBoxContainer>("TextBackground/JobsButtonContainer");
        List<GameData.Location> _jobLocations = new List<GameData.Location>();

        foreach(GameData.Location location in GameData.locations) {
            if(location.jobs.Count > 0) {
                Button button = new Button();
                button.Text = location.labelName;
                button.Name = location.locationID;
                
                button.Connect("pressed", this, "OnJobLocationNamePressed");
                _jobsButtonNode.AddChild(button);
            }
        }
    }

    public void BuildJobsButtons(GameData.Location location) {
        _thisMenuState = MenuState.JobsList;
        RemoveButtons();

        List<GameData.Location> _jobLocations = new List<GameData.Location>();
        var _jobsButtonNode = GetNode<VBoxContainer>("TextBackground/JobsButtonContainer");
        foreach(GameData.Job job in location.jobs) {
            Button button = new Button();
            button.Text = job.jobName + " - $" + String.Format("{0:00}", job.baseWage);
            button.Align = Button.TextAlign.Left;
            GD.Print("BuildJobsButtons button.text: " + button.Text);
            
            button.Connect("pressed", this, "OnJobNamePressed");
            _jobsButtonNode.AddChild(button);
        }
        _jobsButtonNode.Update();
    }

    public void RemoveButtons() {
        var buttons = GetNode<VBoxContainer>("TextBackground/JobsButtonContainer");
        foreach(Button button in buttons.GetChildren()) {
            button.QueueFree();
        }
    }

    public void OnDoneButtonClicked() {
        switch (_thisMenuState) {
        case MenuState.CompaniesList:
            GetNode<InfoScene>("/root/RootScene/InfoScene").DisableLocationsButtons(false);
            QueueFree();
            break;
        case MenuState.JobsList:
            RemoveButtons();
            BuildCompaniesListButtons();
            break;
        }
    }

    
    public void OnJobLocationNamePressed() {
        GD.Print("Scene08.OnJobNamePressed");

        var buttons = GetNode<VBoxContainer>("TextBackground/JobsButtonContainer");
        foreach (Button button in buttons.GetChildren()) {
            if (button.Pressed == true) {
                foreach (GameData.Location location in GameData.locations) {
                    if(location.locationID == button.Name) {
                        BuildJobsButtons(location);
                    }
                }
            }
        }
    }

    

//  // Called every frame. 'delta' is the elapsed time since the previous frame.
//  public override void _Process(float delta)
//  {
//      
//  }
}
