using Godot;

public class RootScene : Node2D
{
    // Declare member variables here. Examples:
    // private int a = 2;
    // private string b = "text";
    [Signal]
    public delegate void StartupDisableLocationButtons(Vector2 pos, bool disableLocButtons);

    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {
        GD.Print(this.GetType().Name + "._Ready");
        EmitSignal(nameof(StartupDisableLocationButtons), new Vector2(0,0), true);
        // GetNode<TravelPath>("TravelPath").DisableLocationsButtons(true);
    }

//  // Called every frame. 'delta' is the elapsed time since the previous frame.
//  public override void _Process(float delta)
//  {
//      
//  }
}
