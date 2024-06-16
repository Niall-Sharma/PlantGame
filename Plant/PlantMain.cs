using Audio;
using Godot;
using System;

public partial class PlantMain : Area2D
{

	[Export]
	public bool isDraggable;
	[Export]
	AudioClip dropSoundEffect;
	public bool mouseInArea;
	public Master master;

	bool hasLanded;
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		master = GetParent().GetParent<Master>();

	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		if(isDraggable){
		}
		if(Input.IsMouseButtonPressed(MouseButton.Left) && mouseInArea && !master.checkWaterToggle()){
			GetParent<Node2D>().Position = GetGlobalMousePosition();
			GetParent<RigidBody2D>().Freeze = true;
			hasLanded = false;
		}
		else{
			GetParent<RigidBody2D>().Freeze = false;
			hasLanded = true;
		}
		if(Mathf.Snapped(GetParent<RigidBody2D>().LinearVelocity.Y, 0.05) == 0 && hasLanded){
			// GetParent().GetParent().GetChild<AudioManager>(0).PlayAudio(dropSoundEffect);
			// hasLanded = false;
		}
	}

    public override void _MouseEnter()
    {
		mouseInArea = true;
    }	

    public override void _MouseExit()
    {
		mouseInArea = false;
    }
}
