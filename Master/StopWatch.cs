using Godot;
using System;
using System.Globalization;
public partial class StopWatch : Label
{
	public double timeElapsed;
	public int days = 1;
	[Export]
	Label dayLabel;
	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		timeElapsed = (float)(timeElapsed+delta);
		// float minutes = (float)(timeElapsed/60);
		// float seconds = (float)(timeElapsed%60);
		// if(minutes<10 && seconds >= 10){
		// 	Text = "0" + minutes.ToString().PadDecimals(0) + ":" + seconds.ToString().PadDecimals(0);

		// }
		// if(minutes < 10 && seconds < 10){
		// 	Text = "0" + minutes.ToString().PadDecimals(0) + ":" + "0"+ seconds.ToString().PadDecimals(0);
		// }
		// if(minutes >= 10 && seconds < 10){
		// 	Text =  minutes.ToString().PadDecimals(0) + ":" + "0"+ seconds.ToString().PadDecimals(0);
		// }
		// if(minutes >= 10 && seconds >= 10){
		// 	Text =  minutes.ToString().PadDecimals(0) + ":" + seconds.ToString().PadDecimals(0);
		// }

		string seconds = timeElapsed.ToString();
		seconds = seconds.PadDecimals(2);
		seconds = seconds.Replace('.', ':');
		if(timeElapsed < 10){
			seconds = "0"+seconds;
		}
		Text = seconds;
		if(timeElapsed > 23){
			timeElapsed = 0;
			days++;
			dayLabel.Text = "Day " + days.ToString();
		}
	}
}
