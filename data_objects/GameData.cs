using Godot;
using System;
using System.Collections.Generic;

namespace Dwarf.GameDataObjects 
{
    public class GameData : Node
    {
        public static String characterNodePath = "/root/RootScene/TravelPath/Character";

        public class Location {
            public String labelName;
            public String buttonName;
            public Vector2 tileMapPos;

            public Location(String name, String buttonName, Vector2 pos) {
                this.labelName = name;
                this.buttonName = buttonName;
                this.tileMapPos = pos;
            }
        }

        public static List<Location> locations = new List<Location>()
        {
            new Location("LeSecurity", "LeSecurityButton", new Vector2(7,9)),
            new Location("Market", "MarketButton", new Vector2(10, 20)),
            new Location("Bank", "BankButton", new Vector2(7, 31)),
            new Location("Factory", "FactoryButton", new Vector2(16, 41)),
            new Location("Employment", "EmploymentButton", new Vector2(27, 41)),
            new Location("University", "UniversityButton", new Vector2(42, 44)),
            new Location("Stone and Carpentry", "StoneAndCarpentryButton", new Vector2(52, 42)),
            new Location("Clothing", "ClothingButton", new Vector2(50, 30)),
            new Location("Kitchen", "KitchenButton", new Vector2(58, 19)),
            new Location("Crafts", "CraftsButton", new Vector2(52, 9)),
            new Location("Pawn Shop", "PawnShopButton", new Vector2(42, 10)),
            new Location("Dormitory", "DormitoryButton", new Vector2(31, 9)),
            new Location("Rental Office", "RentalOfficeButton", new Vector2(20, 10))
        };
    }
}
