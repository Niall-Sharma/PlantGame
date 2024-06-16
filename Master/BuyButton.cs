using Godot;
using System;

public partial class BuyButton : Button
{

    [Export]
    Node2D plant;
	private void _on_pressed(){
        var scene = GD.Load<PackedScene>("res://Plant/plant.tscn");
        var instance = scene.Instantiate();
        GetParent().GetParent().AddChild(instance);
    }
}
