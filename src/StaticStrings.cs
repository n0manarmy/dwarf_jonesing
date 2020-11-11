using Godot;
using System;

namespace Dwarf.StaticStrings {
    public class StaticStrings : Node
    {
        public static String jobNotAvailable =      "This job currently isn't available. Check again another time";
        public static String notEnoughEducation =   "You do not have the degress or education for this job";
        public static String notEnoughExperience =  "You do not have enough experience for this job";
        public static String gotTheJob =            "You got the job!";

        // Called when the node enters the scene tree for the first time.
        public override void _Ready()
        {
            
        }

    //  // Called every frame. 'delta' is the elapsed time since the previous frame.
    //  public override void _Process(float delta)
    //  {
    //      
    //  }
    }
}