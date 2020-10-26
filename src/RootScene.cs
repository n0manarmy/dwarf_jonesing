using Godot;

public class RootScene : Node2D
{
    // Declare member variables here. Examples:
    // private int a = 2;
    // private string b = "text";


    // private PackedScene _infoScene = (PackedScene)GD.Load("res://scenes/InfoScene.tscn");

    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {
        // Node infoScene = _infoScene.Instance();
        // AddChild(infoScene);
        // GetNode<Character>(GameData.characterNodePath).ResetPlayerPosition();
        // var _locationButtonGroup = (ButtonGroup)GD.Load("res://res/LocationButtonResource.tres");
        // GD.Print(_locationButtonGroup);

        

        var _buttons = (ButtonGroup)GD.Load("res://res/LocationButtonResource.tres");

        foreach(Button _b in _buttons.GetButtons()) {
            // GD.Print("_b.Name: " + _b.Name);
            _b.Disabled = true;
        }
    }

//  // Called every frame. 'delta' is the elapsed time since the previous frame.
//  public override void _Process(float delta)
//  {
//      
//  }
}
