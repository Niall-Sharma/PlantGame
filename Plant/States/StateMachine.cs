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
	
	[ExportCategory("Debug")]
	[Export]
	public Label debugLabel;

	[ExportCategory("Watering")]

	[Export]

	public Timer waterTimer;

	[Export]

	public float timeToWater;

	[Export]
	public ProgressBar timerLabel;

	[Export]
	PlantMain plantMain;

	Master master;

	[Export]
	TextureProgressBar growthBar;
	
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		master = GetParent().GetParent<Master>();
		waterTimer.Start(timeToWater);
		waterTimer.Timeout += () => KillPlant();
		setNextState(initialState);		
		foreach (var state in states)
		{
			state.sprite2D = sprite2D;
			state.plantMain = plantMain;
			state.master = master;
			state.growthBar = growthBar;
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

		if(plantMain.mouseInArea && currentState != states[4] && Input.IsMouseButtonPressed(MouseButton.Left) && master.checkWaterToggle()){
			waterTimer.Stop();
			waterTimer.Start(timeToWater);
		}
	}

	public void switchState(){		
		currentState = nextState;
		currentState._OnEnter();
		debugLabel.Text = currentState.Name;
	}

	public void setNextState(State state){
		nextState = state;
	}

	public void KillPlant(){
		setNextState(states[4]);
		waterTimer.Stop();
	}

}
