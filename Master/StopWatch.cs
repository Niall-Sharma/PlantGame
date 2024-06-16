using Godot;
using System;

public partial class StopWatch : Label
{
	public double timeElapsed;
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		timeElapsed = (float)(timeElapsed+delta);
		float minutes = (float)(timeElapsed/60);
		float seconds = (float)(timeElapsed%60);
		if(minutes<10 && seconds >= 10){
			Text = "0" + minutes.ToString().PadDecimals(0) + ":" + seconds.ToString().PadDecimals(0);

		}
		if(minutes < 10 && seconds < 10){
			Text = "0" + minutes.ToString().PadDecimals(0) + ":" + "0"+ seconds.ToString().PadDecimals(0);
		}
		if(minutes >= 10 && seconds < 10){
			Text =  minutes.ToString().PadDecimals(0) + ":" + "0"+ seconds.ToString().PadDecimals(0);
		}
		if(minutes >= 10 && seconds >= 10){
			Text =  minutes.ToString().PadDecimals(0) + ":" + seconds.ToString().PadDecimals(0);
		}
	}
}
