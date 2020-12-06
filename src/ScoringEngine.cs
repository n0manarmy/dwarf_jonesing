using Godot;
using System;
using Dwarf.GameDataObjects;

public class ScoringEngine : Node2D
{
    [Signal]
    public delegate void JobScoreUpdated(int val);
    
    [Signal]
    public delegate void EducationScoreUpdated(int val);
    
    [Signal]
    public delegate void WealthScoreUpdated(int val);

    [Signal]
    public delegate void HappinessScoreUpdated(int val);

    [Signal]
    public delegate void MaxJobScoreUpdated(int val);

    [Signal]
    public delegate void MaxEducationScoreUpdated(int val);
    
    [Signal]
    public delegate void MaxWealthScoreUpdated(int val);
    
    [Signal]
    public delegate void MaxHappinessScoreUpdated(int val);

    [Signal]
    public delegate void MaxScoreUpdated(int val);


    public void UpdateJobScore(int player_pos, int val) {
        GD.Print(this.GetType().Name + ".UpdateJobScore");
        GameData.players[player_pos].jobScore = GameData.players[player_pos].jobScore + val;

        EmitSignal(nameof(JobScoreUpdated), player_pos);
    }

    public void UpdateEducationScore(int player_pos, int val) {
        GD.Print(this.GetType().Name + ".UpdateEducationScore");
        GameData.players[player_pos].educationScore = GameData.players[player_pos].educationScore + val;
        
        EmitSignal(nameof(EducationScoreUpdated), player_pos);
    }

    public void UpdateWealthScore(int player_pos, int val) {
        GD.Print(this.GetType().Name + ".UpdateWealthScore");
        GameData.players[player_pos].wealthScore = GameData.players[player_pos].wealthScore + val;
        
        EmitSignal(nameof(WealthScoreUpdated), player_pos);
    }

    public void UpdateHappinessScore(int player_pos, int val) {
        GD.Print(this.GetType().Name + ".UpdateHappinessScore");
        GameData.players[player_pos].happinessScore = GameData.players[player_pos].happinessScore + val;
        
        EmitSignal(nameof(HappinessScoreUpdated), player_pos);
    }

    public void SetMaxHappinessScore(int player_pos, int val) {
        GD.Print(this.GetType().Name + ".SetMaxHappinessScore");
        GameData.players[player_pos].maxHappinessScore = val;
        
        EmitSignal(nameof(MaxHappinessScoreUpdated), val);
        EmitSignal(nameof(MaxScoreUpdated), GetMaxScore(player_pos));
    }

    public void SetMaxWealthScore(int player_pos, int val) {
        GD.Print(this.GetType().Name + ".SetMaxWealthScore");
        GameData.players[player_pos].maxWealthScore = val;
        
        EmitSignal(nameof(MaxWealthScoreUpdated), val);
        EmitSignal(nameof(MaxScoreUpdated), GetMaxScore(player_pos));
    }

    public void SetMaxJobScore(int player_pos, int val) {
        GD.Print(this.GetType().Name + ".SetMaxJobScore");
        GameData.players[player_pos].maxJobScore = val;

        EmitSignal(nameof(MaxJobScoreUpdated), val);
        EmitSignal(nameof(MaxScoreUpdated), GetMaxScore(player_pos));
    }

    public void SetMaxEducationScore(int player_pos, int val) {
        GD.Print(this.GetType().Name + ".SetMaxEducationScore");
        GameData.players[player_pos].maxEducationScore = val;

        EmitSignal(nameof(MaxEducationScoreUpdated), val);
        EmitSignal(nameof(MaxScoreUpdated), GetMaxScore(player_pos));
    }

    private int GetMaxScore(int player_pos) {
        return (GameData.players[player_pos].maxHappinessScore + 
            GameData.players[player_pos].maxWealthScore + 
            GameData.players[player_pos].maxJobScore + 
            GameData.players[player_pos].maxEducationScore);
    }

    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {
        
    }
}
