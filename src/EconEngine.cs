using Godot;
using System;
using System.Collections.Generic;

using Dwarf.GameDataObjects;

public class EconEngine : Node
{
    // Declare member variables here. Examples:
    // private int a = 2;
    // private string b = "text";

    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {
        
    }

//  // Called every frame. 'delta' is the elapsed time since the previous frame.
//  public override void _Process(float delta)
//  {
//      
//  }

    public static int AdjustEconomy(int val) {
        //get our RNG
        var rng = new RandomNumberGenerator();

        var results = rng.RandiRange(GameData.econMin, GameData.econMax);
        if(results < GameData.econMin) {
            results = GameData.econMin;
        } else if (results > GameData.econMax) {
            results = GameData.econMax;
        }

        // GD.Print("AdjustEconomy results: " + results);
        return results;
    }

    public static List<Location> SetJobAvailability(List<Location> locations) {
        var rng = new RandomNumberGenerator();

        foreach(Job job in GameData.jobs) {
            if (rng.RandiRange(1, 4) > 1) {
                job.available = true;
            } else {
                job.available = false;
            }
        }

        return locations;
    }

    //iterate and adjust salaries
    public static List<Location> AdjustJobSalaries(List<Location> locations) {
        var rng = new RandomNumberGenerator();
        foreach(Job job in GameData.jobs) {
            double tempWage = job.baseWage * ((double) GameData.baseEconValue / 10);
            // GD.Print("AdjustJobSalaries tempWage: " + tempWage);
            job.baseWage = tempWage;
        }

        return locations;
    }
}