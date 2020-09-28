using Godot;
using System;
using System.Collections.Generic;

public class TravelPath : Node
{
    [Export]
    public PackedScene Character;
    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {
        var tween = GetNode<Tween>("WalkingEffect");
        tween.Repeat = true;
        var player = GetNode<Character>("Character");
        tween.InterpolateProperty(player, "position", 0, 1, 6, Tween.TransitionType.Linear, Tween.EaseType.InOut);
        GD.Print("WalkingPath._Ready()");
        tween.Start();
    }

    public void OnButtonMovePressed() {
        GD.Print("OnButtonMovePressed()");

        var player = GetNode<Character>("Character");
        var travelPath = GetNode<TileMap>("WalkingPath/TravelPathTileMap");
        var pos = player.GlobalPosition;

        var buttons = GetNode<Node>("ButtonNode");

        foreach (Button button in buttons.GetChildren()) {
            if (button.Pressed == true) {
                switch (button.Name) {
                    case "LeSecurityButton":
                        pos = new Vector2(7,9);
                        break;
                    case "MarketButton":
                        pos = new Vector2(10, 20);
                        break;
                    case "BankButton":
                        pos = new Vector2(7, 31);
                        break;
                    case "FactoryButton":
                        pos = new Vector2(16, 41);
                        break;
                    case "EmploymentButton":
                        pos = new Vector2(27, 41);
                        break;
                    case "UniversityButton":
                        pos = new Vector2(42, 44);
                        break;
                    case "StoneAndCarpentryButton":
                        pos = new Vector2(52, 42);
                        break;
                    case "ClothingButton":
                        pos = new Vector2(50, 30);
                        break;
                    case "KitchenButton":
                        pos = new Vector2(58, 19);
                        break;
                    case "CraftsButton":
                        pos = new Vector2(52, 9);
                        break;
                    case "PawnShopButton":
                        pos = new Vector2(42, 10);
                        break;
                    case "DormitoryButton":
                        pos = new Vector2(31, 9);
                        break;
                    case "RentalOfficeButton":
                        pos = new Vector2(20, 10);
                        break;
                    default:
                        break;
                }
            }
        }

        pos = travelPath.MapToWorld(pos);
        var nav2d = GetNode<Navigation2D>("WalkingPath");
        var newPath = nav2d.GetSimplePath(player.GlobalPosition, pos);
        List<Vector2> pathList = new List<Vector2>(newPath);
        player.SetCharacterPath(pathList);
    }
}
