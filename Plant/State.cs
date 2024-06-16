using Godot;
using System;

[GlobalClass]
public partial class State : Node
{
	[Export]
	public float TimeInState;

	[Export]
	public Timer timer;

	[Export]
	public State nextState;

	[Export]
	public Texture2D plantSprite;
	

	public PlantMain plantMain;

	public Master master;
	public Sprite2D sprite2D;

	public TextureProgressBar growthBar;

	// Called when the node enters the scene tree for the first time.

	public virtual void _OnEnter()
	{
		timer.Start(TimeInState);
		sprite2D.Texture = plantSprite;
		growthBar.MaxValue = TimeInState;
	}

	public virtual void _OnExit(){
		timer.Stop();
		GetParent<StateMachine>().setNextState(nextState);		
	}

    public override void _Ready()
    {
		sprite2D = GetParent().GetParent().GetChild<Sprite2D>(0);
        timer = GetChild<Timer>(0);
		timer.Timeout += () => _OnExit();
    }

	public virtual void _update(){
		growthBar.Value = timer.TimeLeft;
	}

}
