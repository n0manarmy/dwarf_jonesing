using Godot;
using System;
using System.Collections.Generic;

namespace Dwarf.GameDataObjects 
{   
    public class Degree :Godot.Object 
    {
        public int ID;
        public String degreeName;
        public int classCount;

        public Degree(int ID, String name, int classCount) {
            this.ID = ID;
            this.degreeName = name;
            this.classCount = classCount;
        }
    }

    public class Location : Godot.Object
    {
        public String locationID;
        public String labelName;
        public String buttonName;
        public Vector2 tileMapPos;
        public List<int> jobIDs;

        public Location(String locationID, String name, String buttonName, Vector2 pos, List<int> jobs) {
            this.locationID = locationID;
            this.labelName = name;
            this.buttonName = buttonName;
            this.tileMapPos = pos;
            this.jobIDs = jobs;
        }

        public Vector2 getInsideBuildingLocation() {
            return new Vector2(tileMapPos.x, tileMapPos.y - 3);
        }
    }

    // public class Player : Godot.Object
    // {   
    //     public int pos;
    //     public Job job = GameData.jobs[0];
    //     public int workExp = 0;
    //     public bool eaten = false;
    //     public int happinessScore = 0;
    //     public int maxHappinessScore = 0;
    //     public int wealthScore = 0;
    //     public int maxWealthScore = 0;
    //     public int jobScore = 0;
    //     public int maxJobScore = 0;
    //     public int educationScore = 0;
    //     public int maxEducationScore = 0;
    //     public List<Degree> playerDegrees = new List<Degree>();

    //     public Player(int pos, int maxHappinessScore, int maxWealthScore, int maxJobScore, int maxEducationScore) {
    //         this.pos = pos;
    //         this.maxHappinessScore = maxHappinessScore;
    //         this.maxWealthScore = maxWealthScore;
    //         this.maxJobScore = maxJobScore;
    //         this.maxEducationScore = maxEducationScore;
    //         this.playerDegrees.Add(GameData.degrees[0]);
    //     }

    //     public void SetJob(Job job) {
    //         this.job = job;
    //         EmitSignal(nameof(JobChanged), job.jobName);
    //     }
    // }

    //TODO Consider base wage as a base value multiplied by the economic value for the current salary,
    //instead of actual wages. Base salary X economic factor being x * y where y a min/max range
    public class Job : Godot.Object {
        public int ID;
        public String jobName;
        public double baseWage;
        public Degree requiredDegree;
        public int expRequired;
        public bool available;

        public Job(int ID, String name, double baseWage, Degree requiredDegree, int expRequired, bool available) {
            this.ID = ID;
            this.jobName = name;
            this.baseWage = baseWage;
            this.requiredDegree = requiredDegree;
            this.expRequired = expRequired;
            this.available = available;
        }

        public Job(String[] values) {
            this.ID =               System.Convert.ToInt32(values[0]);
            this.jobName =          values[1];
            this.baseWage =         System.Convert.ToDouble(values[2]);
            this.requiredDegree =   GameData.GetDegreeByID(values[3]);
            this.expRequired =      System.Convert.ToInt32(values[4]);
            this.available =        System.Convert.ToBoolean(values[5]);
        }


        public String GetJobDataForSplit() {
            return 
                this.jobName + "|" + 
                this.baseWage.ToString()+ "|" +
                this.requiredDegree.ID.ToString()+ "|" +
                this.expRequired.ToString()+ "|" +
                this.available.ToString(); 
        }

        public override string ToString() {
            return 
                "jobName: " + this.jobName +
                "\nbaseWage: " + this.baseWage.ToString() +
                "\nrequiredDegree.ID: " + this.requiredDegree.ID.ToString() +
                "\nexpRequired: " + this.expRequired.ToString() +
                "\navailable: " + this.available.ToString();
        }
    }

    public class GameData : Node2D
    {
        [Signal]
        public delegate void JobChanged(String jobName);
        
        public static int rounds = 0;

        public static int totalTime = 500;
        public static int currentTime = 0;
        public static int currentPlayer = 0;

        public static List<Degree> degrees = CreateDegrees();
        public static List<Location> locations = CreateLocations();
        public static List<Job> jobs = CreateJobs();
        public static List<Player> players = CreatePlayers();

        public static int baseEconValue = 10;
        public static int econMin = 5;
        public static int econMax = 20;
        public static int BASE_STARTING_DIFFICULTY = 50;

        public static int BUTTON_CLICKED_ADD_TIME = 10;

        public static int totalGameRounds = 0;

        private static List<Player> CreatePlayers() {
            return new List<Player>()
            {
                new Player(1, BASE_STARTING_DIFFICULTY, BASE_STARTING_DIFFICULTY, BASE_STARTING_DIFFICULTY, BASE_STARTING_DIFFICULTY),
            };
        }

        public class Player : Godot.Object
        {   
            public int pos;
            public Job job = GameData.jobs[0];
            public int workExp = 0;
            public bool eaten = false;
            public int happinessScore = 0;
            public int maxHappinessScore = 0;
            public int wealthScore = 0;
            public int maxWealthScore = 0;
            public int jobScore = 0;
            public int maxJobScore = 0;
            public int educationScore = 0;
            public int maxEducationScore = 0;
            public List<Degree> playerDegrees = new List<Degree>();

            public Player(int pos, int maxHappinessScore, int maxWealthScore, int maxJobScore, int maxEducationScore) {
                this.pos = pos;
                this.maxHappinessScore = maxHappinessScore;
                this.maxWealthScore = maxWealthScore;
                this.maxJobScore = maxJobScore;
                this.maxEducationScore = maxEducationScore;
                this.playerDegrees.Add(GameData.degrees[0]);
            }

            public void SetJob(Job job) {
                this.job = job;
                EmitSignal(nameof(JobChanged), job.jobName);
            }
        }

        public static Player getCurrentPlayer() {
            return GameData.players[currentPlayer];
        }

        public static Location GetLocation(String _locationID) {
            foreach(Location loc in locations) {
                if(loc.locationID == _locationID) {
                    return loc;
                }
            }
            return null;
        }

        private static List<Location> CreateLocations() {
            return new List<Location>()
            {
                new Location("Scene12", "LeSecurity",          "12_MoveButton", new Vector2(07, 09), new List<int>()),
                new Location("Scene11", "Market",              "11_MoveButton", new Vector2(10, 19), new List<int>(){1,2,3,4,5}),
                new Location("Scene10", "Bank",                "10_MoveButton", new Vector2(07, 30), new List<int>(){6,7,8,9,10}),
                new Location("Scene09", "Factory",             "09_MoveButton", new Vector2(16, 40), new List<int>(){11,12,13,14,15,16,17,18,19}),
                new Location("Scene08", "Employment",          "08_MoveButton", new Vector2(27, 40), new List<int>()),
                new Location("Scene07", "University",          "07_MoveButton", new Vector2(42, 43), new List<int>(){20,21,22}),
                new Location("Scene06", "Stone and Carpentry", "06_MoveButton", new Vector2(52, 41), new List<int>(){23,24,25}),
                new Location("Scene05", "Clothing",            "05_MoveButton", new Vector2(50, 29), new List<int>(){26,27,28}),
                new Location("Scene04", "Kitchen",             "04_MoveButton", new Vector2(59, 19), new List<int>(){29,30,31,32}),
                new Location("Scene03", "Crafts",              "03_MoveButton", new Vector2(52, 08), new List<int>(){33,34,35}),
                new Location("Scene02", "Pawn Shop",           "02_MoveButton", new Vector2(42, 09), new List<int>()),
                new Location("Scene01", "Dormitory",           "01_MoveButton", new Vector2(31, 08), new List<int>()),
                new Location("Scene13", "Rental Office",       "13_MoveButton", new Vector2(20, 09), new List<int>())
            };
        }

        // private static List<Location> CreateLocations() {
        //     return new List<Location>()
        //     {
        //         new Location("12", "LeSecurity",          "12_MoveButton", new Vector2(07, 09), new List<Job>()),
        //         new Location("11", "Market",              "11_MoveButton", new Vector2(10, 19), new List<Job>()
        //         {
        //             new Job("Janitor",              04.0, degrees[0],   00, false),
        //             new Job("Checker",              07.0, degrees[0],   05, false),
        //             new Job("Butcher",              10.0, degrees[0],   10, false),
        //             new Job("Assistant Manager",    14.0, degrees[1],   15, false),
        //             new Job("Manager",              17.0, degrees[2],   20, false),
        //         }),
        //         new Location("10", "Bank",                "10_MoveButton", new Vector2(07, 30), new List<Job>()
        //         {
        //             new Job("Janitor",              05.0, degrees[0],   00, false),
        //             new Job("Teller",               09.0, degrees[0],   05, false),
        //             new Job("Assistant Manager",    12.0, degrees[1],   10, false),
        //             new Job("Manager",              18.0, degrees[3],   15, false),
        //             new Job("Investment Broker",    20.0, degrees[8],   20, false),
        //         }),
        //         //TODO Set experience multiplyer for here on down
        //         new Location("09", "Factory",             "09_MoveButton", new Vector2(16, 40), new List<Job>()
        //         {
        //             new Job("Janitor",              07.0, degrees[0],   00, false),
        //             new Job("Assembly Worker",      07.0, degrees[2],   05, false),
        //             new Job("Secretary",            08.0, degrees[3],   10, false),
        //             new Job("Machinist's Helper",   09.0, degrees[4],   15, false),
        //             new Job("Executive Secretary",  17.0, degrees[3],   20, false),
        //             new Job("Machinist",            18.0, degrees[6],   25, false),
        //             new Job("Department Manager",   20.0, degrees[3],   30, false),
        //             new Job("Engineer",             21.0, degrees[6],   35, false),
        //             new Job("General Manager",      23.0, degrees[6],   40, false),
        //         }),
        //         new Location("08", "Employment",          "08_MoveButton", new Vector2(27, 40), new List<Job>()),
        //         new Location("07", "University",          "07_MoveButton", new Vector2(42, 43), new List<Job>()
        //         {
        //             new Job("Janitor",              03.0, degrees[0],   00, false),
        //             new Job("Teacher",              09.0, degrees[7],   10, false),
        //             new Job("Professor",            19.0, degrees[9],   20, false),
        //         }),
        //         new Location("06", "Stone and Carpentry", "06_MoveButton", new Vector2(52, 41), new List<Job>()
        //         {
        //             new Job("Salesperson",          04.0, degrees[1],   00, false),
        //             new Job("Electronic's Repair",  09.0, degrees[4],   10, false),
        //             new Job("Manager",              12.0, degrees[3],   20, false),
        //         }),
        //         new Location("05", "Clothing",            "05_MoveButton", new Vector2(50, 29), new List<Job>()
        //         {
        //             new Job("Salesperson",          06.0, degrees[0],   00, false),
        //             new Job("Assistant Manager",    08.0, degrees[1],   10, false),
        //             new Job("Manager",              10.0, degrees[3],   20, false),
        //         }),
        //         new Location("04", "Kitchen",             "04_MoveButton", new Vector2(59, 19), new List<Job>()
        //         {
        //             new Job("Cook",                 03.0, degrees[1],   00, false),
        //             new Job("Clerk",                04.0, degrees[0],   05, false),
        //             new Job("Assistant Manager",    05.0, degrees[1],   10, false),
        //             new Job("Manager",              06.0, degrees[3],   20, false),
        //         }),
        //         new Location("03", "Crafts",              "03_MoveButton", new Vector2(52, 08), new List<Job>() 
        //         {
        //             new Job("Clerk",                03.0, degrees[0],   00, false),
        //             new Job("Assistant Manager",    04.0, degrees[1],   10, false),
        //             new Job("Manager",              05.0, degrees[3],   20, false),
        //         }),
        //         new Location("02", "Pawn Shop",           "02_MoveButton", new Vector2(42, 09), new List<Job>()),
        //         new Location("01", "Dormitory",           "01_MoveButton", new Vector2(31, 08), new List<Job>()),
        //         new Location("13", "Rental Office",       "13_MoveButton", new Vector2(20, 09), new List<Job>())
        //     };
        // }

        private static List<Job> CreateJobs() {
            return new List<Job>()
            {
                new Job( 0, "None",                 00.0, degrees[0],   00, false),
                new Job( 1, "Janitor",              04.0, degrees[0],   00, false),
                new Job( 2, "Checker",              07.0, degrees[0],   05, false),
                new Job( 3, "Butcher",              10.0, degrees[0],   10, false),
                new Job( 4, "Assistant Manager",    14.0, degrees[1],   15, false),
                new Job( 5, "Manager",              17.0, degrees[2],   20, false),
                new Job( 6, "Janitor",              05.0, degrees[0],   00, false),
                new Job( 7, "Teller",               09.0, degrees[0],   05, false),
                new Job( 8, "Assistant Manager",    12.0, degrees[1],   10, false),
                new Job( 9, "Manager",              18.0, degrees[3],   15, false),
                new Job(10, "Investment Broker",    20.0, degrees[8],   20, false),
                new Job(11, "Janitor",              07.0, degrees[0],   00, false),
                new Job(12, "Assembly Worker",      07.0, degrees[2],   05, false),
                new Job(13, "Secretary",            08.0, degrees[3],   10, false),
                new Job(14, "Machinist's Helper",   09.0, degrees[4],   15, false),
                new Job(15, "Executive Secretary",  17.0, degrees[3],   20, false),
                new Job(16, "Machinist",            18.0, degrees[6],   25, false),
                new Job(17, "Department Manager",   20.0, degrees[3],   30, false),
                new Job(18, "Engineer",             21.0, degrees[6],   35, false),
                new Job(19, "General Manager",      23.0, degrees[6],   40, false),
                new Job(20, "Janitor",              03.0, degrees[0],   00, false),
                new Job(21, "Teacher",              09.0, degrees[7],   10, false),
                new Job(22, "Professor",            19.0, degrees[9],   20, false),
                new Job(23, "Salesperson",          04.0, degrees[1],   00, false),
                new Job(24, "Electronic's Repair",  09.0, degrees[4],   10, false),
                new Job(25, "Manager",              12.0, degrees[3],   20, false),
                new Job(26, "Salesperson",          06.0, degrees[0],   00, false),
                new Job(27, "Assistant Manager",    08.0, degrees[1],   10, false),
                new Job(28, "Manager",              10.0, degrees[3],   20, false),
                new Job(29, "Cook",                 03.0, degrees[1],   00, false),
                new Job(30, "Clerk",                04.0, degrees[0],   05, false),
                new Job(31, "Assistant Manager",    05.0, degrees[1],   10, false),
                new Job(32, "Manager",              06.0, degrees[3],   20, false),
                new Job(33, "Clerk",                03.0, degrees[0],   00, false),
                new Job(34, "Assistant Manager",    04.0, degrees[1],   10, false),
                new Job(35, "Manager",              05.0, degrees[3],   20, false)
            };
        }

        private static List<Degree> CreateDegrees() {
            return new List<Degree> {
                new Degree(00, "None", 0),
                new Degree(01, "Junior College", 10),
                new Degree(02, "Trade School", 10),
                new Degree(03, "Business Administration", 10),
                new Degree(04, "Electronics", 10),
                new Degree(05, "Pre-Engineering", 10),
                new Degree(06, "Engineering", 10),
                new Degree(07, "Academic", 10),
                new Degree(08, "Grad School", 10),
                new Degree(09, "Post Doctoral", 10),
                new Degree(10, "Research", 10),
                new Degree(11, "Publishing", 10),
            };
        }

        public static Degree GetDegreeByID(String id) {
            foreach(Degree d in GameData.degrees) {
                if (d.ID == System.Convert.ToInt32(id)) {
                    return d;
                }
            }
            return null;
        }

        public static Degree GetDegreeByName(String name) {
            foreach(Degree d in degrees) {
                if (d.degreeName == name) {
                    return d;
                }
            }

            return degrees[0];
        }

        public static void UpdateEconomy() {
            baseEconValue = EconEngine.AdjustEconomy(baseEconValue);
            locations = EconEngine.SetJobAvailability(locations);
            locations = EconEngine.AdjustJobSalaries(locations);
        }
    }
}
