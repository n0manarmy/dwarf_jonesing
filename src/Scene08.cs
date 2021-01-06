using Godot;
using System;
using System.Collections.Generic;
using Dwarf.GameDataObjects;
using Dwarf.StaticStrings;

//TODO - Build Job button to check experience, availability, and education
//#About
//This class is the jobs class. The jobs listing and availability are controlled
//by this class.
public class Scene08 : Node2D
{
    private String THIS_SCENE = "Scene08";

    [Signal]
    public delegate void JobClicked(Godot.Collections.Array job);

    [Signal]
    public delegate void JobChanged(String jobName);

    enum MenuState {
        CompaniesList,
        JobsList,
    }

    private MenuState _thisMenuState = MenuState.CompaniesList;

    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {
        GD.Print(this.Name + "._Ready");
        BuildSceneDetails();
        BuildCompaniesListButtons(); 
    }

    public void BuildSceneDetails() {
        GD.Print(this.Name + ".BuildSceneDetails");
        GetNode<Label>("TextBackground/NameLabel").Text = GameData.GetLocation(THIS_SCENE).labelName;
    }

    public void BuildCompaniesListButtons() {
        GD.Print(this.Name + ".BuildCompaniesListButtons");

        _thisMenuState = MenuState.CompaniesList;
        var _jobsButtonNode = GetNode<VBoxContainer>("TextBackground/JobsButtonContainer");
        List<Location> _jobLocations = new List<Location>();

        foreach(Location location in GameData.locations) {
            if(location.jobIDs.Count > 0) {
                Button button = new Button();
                button.Text = location.labelName;
                button.Name = location.locationID;
                
                button.Connect("pressed", this, "OnJobLocationNamePressed");
                _jobsButtonNode.AddChild(button);
            }
        }
    }

    public void BuildJobsButtons(Location location) {
        GD.Print(this.Name + ".BuildJobsButtons");

        _thisMenuState = MenuState.JobsList;
        RemoveButtons();

        List<Location> _jobLocations = new List<Location>();
        var _jobsButtonNode = GetNode<VBoxContainer>("TextBackground/JobsButtonContainer");
        foreach(int id in location.jobIDs) {
            if(location.jobIDs.Contains(id)) {
                Button button = new Button();
                // button.Name = GameData.jobs[id].GetJobDataForSplit();
                button.Name = id.ToString();
                button.Text = GameData.jobs[id].jobName + " - $" + String.Format("{0:00}", GameData.jobs[id].baseWage);
                button.Align = Button.TextAlign.Left;
                GD.Print("BuildJobsButtons button.text: " + button.Text);

                // var jobArray = new Godot.Collections.Array() {job.jobName};
                // GD.Print(jobArray.Count);

                // button.Connect("JobClicked", this, nameof(OnJobNamePressed), new Godot.Collections.Array() {job});
                button.Connect("pressed", this, nameof(OnJobNamePressed));
                // button.AddUserSignal(nameof(JobClicked));

                GD.Print(GameData.jobs[id].jobName);
                _jobsButtonNode.AddChild(button);
            }
        }
        _jobsButtonNode.Update();
    }

    public void RemoveButtons() {
        GD.Print(this.Name + ".RemoveButtons");

        var buttons = GetNodeOrNull<VBoxContainer>("TextBackground/JobsButtonContainer");
        if (buttons != null) {
            foreach(Button button in buttons.GetChildren()) {
                button.QueueFree();
            }
        }
    }

    public void OnDoneButtonClicked() {
        GD.Print(this.Name + ".OnDoneButtonClicked");

        switch (_thisMenuState) {
        case MenuState.CompaniesList:
            // var node = GetNodeOrNull<TravelPath>("/root/RootScene/TravelPath");        
            // if(node != null) {
            //     node.DisableLocationsButtons(false);
            // }
            // GetNode<Node2D>("../" + THIS_SCENE).ZIndex = -10;
            break;
        case MenuState.JobsList:
            RemoveButtons();
            BuildCompaniesListButtons();
            break;
        }
        // var node = GetNodeOrNull<TravelPath>("/root/RootScene/TravelPath");        
        // if(node != null) {
        //     node.DisableLocationsButtons(false);
        // }
        // GetNode<Node2D>("../" + THIS_SCENE).ZIndex = 0;
        QueueFree();
    }

    
    public void OnJobLocationNamePressed() {
        GD.Print(this.Name + ".OnJobLocationNamePressed");

        var buttons = GetNode<VBoxContainer>("TextBackground/JobsButtonContainer");
        foreach (Button button in buttons.GetChildren()) {
            if (button.Pressed == true) {
                foreach (Location location in GameData.locations) {
                    if(location.locationID == button.Name) {
                        BuildJobsButtons(location);
                    }
                }
            }
        }
    }

    public void OnJobNamePressed() {
        GD.Print(this.Name + ".OnJobNamePressed");

        var buttons = GetNode<VBoxContainer>("TextBackground/JobsButtonContainer");
        var infoLabelBox = GetNode<Label>("TextBackground/InfoLabelBox");
        GameData.Player player = GameData.players[GameData.currentPlayer];

        if (GameData.currentTime > GameData.totalTime) {    
            infoLabelBox.Text = StaticStrings.outOfTime;
        } else {

            GameData.currentTime = GameData.currentTime + GameData.BUTTON_CLICKED_ADD_TIME;
        
            foreach (Button b in buttons.GetChildren()) {
                if (b.Pressed == true) {
                    var job = GameData.jobs[System.Convert.ToInt32(b.Name)];
                    GD.Print("OnJobNamePressed: " + job.ToString());                
                    try {
                        if(!job.available) {
                            infoLabelBox.Text = StaticStrings.jobNotAvailable;
                        }  else
                        //Broken, find out why
                        if(!GameData.players[GameData.currentPlayer].playerDegrees.Contains(job.requiredDegree)) {
                            infoLabelBox.Text = StaticStrings.notEnoughEducation;
                        } else 
                        if(GameData.getCurrentPlayer().job != null && (GameData.getCurrentPlayer().workExp < job.expRequired)) {
                            infoLabelBox.Text = StaticStrings.notEnoughExperience;
                        } else {
                            infoLabelBox.Text = StaticStrings.gotTheJob;
                            GameData.getCurrentPlayer().SetJob(job);
                            EmitSignal(nameof(JobChanged), job.jobName);
                        }
                    }
                    catch (NullReferenceException e) {
                        GD.Print($"NullReferenceException Handler: {e}");
                    }
                }
            }
        }
    }

}
