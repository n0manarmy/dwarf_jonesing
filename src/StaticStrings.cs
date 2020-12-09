using Godot;
using System;

namespace Dwarf.StaticStrings {
    public class StaticStrings : Node
    {
        public static String jobNotAvailable        = "This job currently isn't available. Check again another time";
        public static String notEnoughEducation     = "You do not have the education required for this job";
        public static String notEnoughExperience    = "You do not have enough experience for this job";
        public static String gotTheJob              = "You got the job!";
        public static String outOfTime              = "You are out of time!";

        public static String characterNodePath      = "/root/RootScene/TravelPath/Character";
        public static String travelPathTileMap      = "/root/RootScene/TravelPath/WalkingPath/TravelPathTileMap";
        public static String infoScene              = "/root/RootScene/InfoScene";
        public static String debugScene             = "/root/RootScene/InfoScene/Background/DebugScene";

        public static String scoringEngine          = "/root/RootScene/ScoringEngine";
        public static String timerEngine            = "/root/RootScene/TimerEngine";
        public static String scene08                = "/root/RootScene/InfoScene/Scene08";
        public static String gameData               = "/root/GameData";

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