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
        public static int currentPlayer = 0;

        public static List<Degree> degrees = CreateDegrees();
        public static List<Location> locations = CreateLocations();
        public static List<Player> players = CreatePlayers();
        public static List<Job> jobs = CreateJobs();

        public static int baseEconValue = 10;
        public static int econMin = 5;
        public static int econMax = 20;

        // public static ButtonGroup locationButtonGroup = InitButtonGroup();

        public static String characterNodePath = "/root/RootScene/TravelPath/Character";
        public static String travelPathTileMap = "/root/RootScene/TravelPath/WalkingPath/TravelPathTileMap";
        public static int totalGameRounds = 0;

        public class Player
        {
            public int pos;
            public Job job = new Job("None", 00.0, degrees[0], 00, false);
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
            public List<Degree> degress = new List<Degree>();

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

        public static Player getCurrentPlayer() {
            return GameData.players[currentPlayer];
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
            public String locationID;
            public String labelName;
            public String buttonName;
            public Vector2 tileMapPos;
            public List<Job> jobs;

            public Location(String locationID, String name, String buttonName, Vector2 pos, List<Job> jobs) {
                this.locationID = locationID;
                this.labelName = name;
                this.buttonName = buttonName;
                this.tileMapPos = pos;
                this.jobs = jobs;
            }

            public Vector2 getInsideBuildingLocation() {
                return new Vector2(tileMapPos.x, tileMapPos.y - 3);
            }
        }

        public static Location GetLocation(String _locationID) {
            foreach(Location loc in locations) {
                if(loc.locationID == _locationID) {
                    return loc;
                }
            }
            return null;
        }

        //TODO Consider base wage as a base value multiplied by the economic value for the current salary,
        //instead of actual wages. Base salary X economic factor being x * y where y a min/max range
        public class Job : Godot.Object {
            public String jobName;
            public double baseWage;
            public Degree requiredDegree;
            public int expRequired;
            public bool available;

            public Job(String name, double baseWage, Degree requiredDegree, int expRequired, bool available) {
                this.jobName = name;
                this.baseWage = baseWage;
                this.requiredDegree = requiredDegree;
                this.expRequired = expRequired;
                this.available = available;
            }

            public Job(String[] values) {
                this.jobName =          values[0];
                this.baseWage =         System.Convert.ToDouble(values[1]);
                this.requiredDegree =   GetDegreeByID(values[2]);
                this.expRequired =  System.Convert.ToInt32(values[3]);
                this.available =        System.Convert.ToBoolean(values[4]);
            }

            // public String[] GetJobStringArray() {
            //     String[] values = new String[jobName, baseWage.ToString(), requiredDegree.ID.ToString(), experienceLevel.ToString(), available.ToString()]; 
            //     return new String[0];
            // }

            public String GetJobDataForSplit() {
                return jobName + "|" + 
                    baseWage.ToString()+ "|" +
                    requiredDegree.ID.ToString()+ "|" +
                    expRequired.ToString()+ "|" +
                    available.ToString(); 
            }
        }

        private static List<Location> CreateLocations() {
            return new List<Location>()
            {
                new Location("12", "LeSecurity",          "12_MoveButton", new Vector2(07, 09), new List<Job>()),
                new Location("11", "Market",              "11_MoveButton", new Vector2(10, 19), new List<Job>()
                {
                    new Job("Janitor",              04.0, degrees[0],   00, false),
                    new Job("Checker",              07.0, degrees[0],   05, false),
                    new Job("Butcher",              10.0, degrees[0],   10, false),
                    new Job("Assistant Manager",    14.0, degrees[1],   15, false),
                    new Job("Manager",              17.0, degrees[2],   20, false),
                }),
                new Location("10", "Bank",                "10_MoveButton", new Vector2(07, 30), new List<Job>()
                {
                    new Job("Janitor",              05.0, degrees[0],   00, false),
                    new Job("Teller",               09.0, degrees[0],   05, false),
                    new Job("Assistant Manager",    12.0, degrees[1],   10, false),
                    new Job("Manager",              18.0, degrees[3],   15, false),
                    new Job("Investment Broker",    20.0, degrees[8],   20, false),
                }),
                //TODO Set experience multiplyer for here on down
                new Location("09", "Factory",             "09_MoveButton", new Vector2(16, 40), new List<Job>()
                {
                    new Job("Janitor",              07.0, degrees[0],   00, false),
                    new Job("Assembly Worker",      07.0, degrees[2],   05, false),
                    new Job("Secretary",            08.0, degrees[3],   10, false),
                    new Job("Machinist's Helper",   09.0, degrees[4],   15, false),
                    new Job("Executive Secretary",  17.0, degrees[3],   20, false),
                    new Job("Machinist",            18.0, degrees[6],   25, false),
                    new Job("Department Manager",   20.0, degrees[3],   30, false),
                    new Job("Engineer",             21.0, degrees[6],   35, false),
                    new Job("General Manager",      23.0, degrees[6],   40, false),
                }),
                new Location("08", "Employment",          "08_MoveButton", new Vector2(27, 40), new List<Job>()),
                new Location("07", "University",          "07_MoveButton", new Vector2(42, 43), new List<Job>()
                {
                    new Job("Janitor",              03.0, degrees[0],   00, false),
                    new Job("Teacher",              09.0, degrees[7],   10, false),
                    new Job("Professor",            19.0, degrees[9],   20, false),
                }),
                new Location("06", "Stone and Carpentry", "06_MoveButton", new Vector2(52, 41), new List<Job>()
                {
                    new Job("Salesperson",          04.0, degrees[1],   00, false),
                    new Job("Electronic's Repair",  09.0, degrees[4],   10, false),
                    new Job("Manager",              12.0, degrees[3],   20, false),
                }),
                new Location("05", "Clothing",            "05_MoveButton", new Vector2(50, 29), new List<Job>()
                {
                    new Job("Salesperson",          06.0, degrees[0],   00, false),
                    new Job("Assistant Manager",    08.0, degrees[1],   10, false),
                    new Job("Manager",              10.0, degrees[3],   20, false),
                }),
                new Location("04", "Kitchen",             "04_MoveButton", new Vector2(59, 19), new List<Job>()
                {
                    new Job("Cook",                 03.0, degrees[1],   00, false),
                    new Job("Clerk",                04.0, degrees[0],   05, false),
                    new Job("Assistant Manager",    05.0, degrees[1],   10, false),
                    new Job("Manager",              06.0, degrees[3],   20, false),
                }),
                new Location("03", "Crafts",              "03_MoveButton", new Vector2(52, 08), new List<Job>() 
                {
                    new Job("Clerk",                03.0, degrees[0],   00, false),
                    new Job("Assistant Manager",    04.0, degrees[1],   10, false),
                    new Job("Manager",              05.0, degrees[3],   20, false),
                }),
                new Location("02", "Pawn Shop",           "02_MoveButton", new Vector2(42, 09), new List<Job>()),
                new Location("01", "Dormitory",           "01_MoveButton", new Vector2(31, 08), new List<Job>()),
                new Location("13", "Rental Office",       "13_MoveButton", new Vector2(20, 09), new List<Job>())
            };
        }

        private static List<Job> CreateJobs() {
            return new List<Job>() {
            
            };
        }

        public class Degree {
            public int ID;
            public String degreeName;
            public int classCount;

            public Degree(int ID, String name, int classCount) {
                this.ID = ID;
                this.degreeName = name;
                this.classCount = classCount;
            }
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

        public static Boolean hasDegree(int currentPlayer, Degree degree) {
            foreach(Degree d in players[currentPlayer].degress) {
                if(d.ID == degree.ID) {
                    return true;
                }
            }
            return false;
        }
    }
}
