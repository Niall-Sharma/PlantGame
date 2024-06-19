using Audio;
using Godot;
using System;

public partial class StateMachine : Node
{
	[Export]
	public State initialState;

	public State currentState;

	public State nextState;

	[Export]
	Sprite2D sprite2D;

	[Export]
	public State[] states;
	
	// [ExportCategory("Debug")]
	// [Export]
	// public Label debugLabel;

	[Export]

	public Timer waterTimer;



	[Export]
	public ProgressBar timerLabel;

	[Export]
	PlantMain plantMain;

	Master master;

	[Export]
	TextureProgressBar growthBar;

	[ExportCategory("Plant Stats")]
	[Export]
	public float timeToWater;
	[Export]
	public float plantValue;
	[Export]
	public bool isReusable;

	[ExportCategory("Audio")]
	[Export]
	AudioClip wateringSoundEffect;
	AudioManager audioManager;
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		master = GetParent().GetParent<Master>();
		waterTimer.Start(timeToWater);
		waterTimer.Timeout += () => KillPlant();
		setNextState(initialState);		
		audioManager = GetParent().GetParent().GetChild<AudioManager>(0);
		foreach (var state in states)
		{
			state.sprite2D = sprite2D;
			state.plantMain = plantMain;
			state.master = master;
			state.growthBar = growthBar;
			state.audioManager = audioManager;
		}
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		if(nextState != currentState){
			switchState();
		}
		currentState._update();
		// debugLabel.GlobalPosition = GetParent<Node2D>().GlobalPosition;
		timerLabel.Value = waterTimer.TimeLeft;
		timerLabel.MaxValue = timeToWater;

		if(plantMain.mouseInArea && currentState != states[4] && Input.IsActionJustReleased("Watering") && master.checkWaterToggle()){
			waterTimer.Stop();
			waterTimer.Start(timeToWater);
			audioManager.PlayAudio(wateringSoundEffect);

		}
	}

	public void switchState(){		
		currentState = nextState;
		currentState._OnEnter();
		// debugLabel.Text = currentState.Name;
	}

	public void setNextState(State state){
		nextState = state;
	}

	public void KillPlant(){
		currentState.timer.Stop();
		setNextState(states[4]);
		waterTimer.Stop();
	}

}
