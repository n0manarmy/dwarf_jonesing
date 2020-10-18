using Godot;
using System;
using System.Collections.Generic;

namespace Dwarf.GameDataObjects 
{
    public class GameData : Node
    {

        public static int rounds = 0;

        public static int totalTime = 500;
        public static int currentTime = 0;
        public static List<Degree> degrees = CreateDegrees();
        public static List<Location> locations = CreateLocations();
        public static List<Player> players = CreatePlayers();
        public static List<Job> jobs = CreateJobs();

        public static String characterNodePath = "/root/RootScene/TravelPath/Character";
        public static int totalGameRounds = 0;

        public class Player
        {
            public int pos;
            public String jobName = "None";
            public bool eaten = false;
            public int happinessScore = 0;
            public int maxHappinessScore = 0;
            public int wealthScore = 0;
            public int maxWealthScore = 0;
            public int jobScore = 0;
            public int maxJobScore = 0;
            public int educationScore = 0;
            public int maxEducationScore = 0;

            public Player(int pos, int maxHappinessScore, int maxWealthScore, int maxJobScore, int maxEducationScore) {
                this.pos = pos;
                this.maxHappinessScore = maxHappinessScore;
                this.maxWealthScore = maxWealthScore;
                this.maxJobScore = maxJobScore;
                this.maxEducationScore = maxEducationScore;
            }
        }

        private static List<Player> CreatePlayers() {
            return new List<Player>()
            {
                new Player(1, 100, 100, 100, 100),
            };
        }

        // private static void CreatePlayerQueue(int count) {
        //     for(int x = 0; x < count; x++) {
                
        //     players = new List<Player>()
        //     {
        //         new Player(1, 100, 100, 100, 100),
        //     };
        // }

        public class Location 
        {
            public String labelName;
            public String buttonName;
            public Vector2 tileMapPos;
            public List<Job> jobs;

            public Location(String name, String buttonName, Vector2 pos, List<Job> jobs) {
                this.labelName = name;
                this.buttonName = buttonName;
                this.tileMapPos = pos;
                this.jobs = jobs;
            }
        }

        private static List<Location> CreateLocations() {
        return new List<Location>()
            {
                new Location("LeSecurity", "LeSecurityButton", new Vector2(7,9), new List<Job>()),
                new Location("Market", "MarketButton", new Vector2(10, 20), new List<Job>()),
                new Location("Bank", "BankButton", new Vector2(7, 31), new List<Job>()),
                new Location("Factory", "FactoryButton", new Vector2(16, 41), new List<Job>()),
                new Location("Employment", "EmploymentButton", new Vector2(27, 41), new List<Job>()),
                new Location("University", "UniversityButton", new Vector2(42, 44), new List<Job>()),
                new Location("Stone and Carpentry", "StoneAndCarpentryButton", new Vector2(52, 42), new List<Job>()),
                new Location("Clothing", "ClothingButton", new Vector2(50, 30), new List<Job>()),
                new Location("Kitchen", "KitchenButton", new Vector2(58, 19), new List<Job>()),
                new Location("Crafts", "CraftsButton", new Vector2(52, 9), new List<Job>() {
                    new Job("Clerk", 3.0, GetDegreeByName("None"), 0, false),
                    new Job("Assistant Manager", 4.0, GetDegreeByName("Junior College"), 0, false),
                    new Job("Manager", 5.0, GetDegreeByName("Business Administration"), 0, false),
                }),
                new Location("Pawn Shop", "PawnShopButton", new Vector2(42, 10), new List<Job>()),
                new Location("Dormitory", "DormitoryButton", new Vector2(31, 9), new List<Job>()),
                new Location("Rental Office", "RentalOfficeButton", new Vector2(20, 10), new List<Job>())
            };
        }

        public class Job {
            public String jobName;
            public double baseWage;
            public Degree requiredDegree;
            public int experienceLevel;
            public bool available;

            public Job(String name, double baseWage, Degree requiredDegree, int experienceLevel, bool available) {
                this.jobName = name;
                this.baseWage = baseWage;
                this.requiredDegree = requiredDegree;
                this.experienceLevel = experienceLevel;
                this.available = available;
            }
        }

        private static List<Job> CreateJobs() {
            return new List<Job>() {
                
            };
        }

        public class Degree {
            public String degreeName;
            public int classCount;

            public Degree(String name, int classCount) {
                this.degreeName = name;
                this.classCount = classCount;
            }
        }

        private static List<Degree> CreateDegrees() {
            return new List<Degree> {
                new Degree("None", 0),
                new Degree("Junior College", 10),
                new Degree("Trade School", 10),
                new Degree("Business Administration", 10),
            };
        }

        public static Degree GetDegreeByName(String name) {
            foreach(Degree d in degrees) {
                if (d.degreeName == name) {
                    return d;
                }
            }

            return degrees[0];
        }
    }
}
