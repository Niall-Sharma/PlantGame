using Audio;
using Godot;
using System;

public partial class Master : Node2D
{


	public float currency;
	bool waterToggle;
	[Export]
	Label currencyLabel;

	[Export]
	Control buyMenu;

	[Export]
	BuyMenu menuCode;

	[ExportCategory("Time Labels")]
	[Export]
	Label stopwatch;
	[Export]
	Label dayCounter;

	[ExportCategory("Window")]
	[Export]
	Texture2D[] sprites;
	[Export]
	Sprite2D windowSprite;
	[Export]
	CanvasModulate canvasModulate;
	bool isNight = false;
	double timeElapsed = 480;
	int days = 1;

	[ExportCategory("Lamps")]
	[Export]
	Node2D[] lamps;
	[Export]
	Node2D sunLight;

	[ExportCategory("Audio")]
	[Export]
	AudioClip pressButtonSound;
	[Export]
	AudioManager audioManager;

	//Turn lamps on or off
	public void toggleLamps(bool toggle){
		foreach (Node2D lamp in lamps)
		{
			lamp.GetChild<PointLight2D>(1).Visible = toggle;
			sunLight.Visible = !toggle;
		}
	}

	//Toggle watering can
	private void _on_watering_button_toggled(bool toggled_on){
		waterToggle = toggled_on;
		audioManager.PlayAudio(pressButtonSound);
	}

	public bool checkWaterToggle(){
		return waterToggle;
	}

	//Add player currency
	public void AddCurrency(float amount){
		currency += amount;
		currencyLabel.Text = currency.ToString();
	}

	//Remove player currency
	public void RemoveCurrency(float amount){
		currency -= amount;
		currencyLabel.Text = currency.ToString();
	}

	//Open or close buy menu
	private void _on_buy_button_pressed(){
		buyMenu.Visible = !buyMenu.Visible;
		menuCode.UpdateMenu();
		audioManager.PlayAudio(pressButtonSound);
	}
	public void BuyPlant(PackedScene instance, int price){
		if(currency - price >= 0){
			var thing = instance.Instantiate();
			AddChild(thing);
			RemoveCurrency(price);
		}		

	}

	public override void _Process(double delta)
	{
		//This is how the stopwatch at the top of the screen works
		timeElapsed = (float)(timeElapsed+delta*10);
		float minutes = (float)(timeElapsed/60);
		float seconds = (float)(timeElapsed%60);
		//For format 0#:##
		if(minutes<10 && seconds >= 10){
			stopwatch.Text = "0" + minutes.ToString().PadDecimals(0) + ":" + seconds.ToString().PadDecimals(0);

		}
		//For format 0#:0#
		if(minutes < 10 && seconds < 10){
			stopwatch.Text = "0" + minutes.ToString().PadDecimals(0) + ":" + "0"+ seconds.ToString().PadDecimals(0);
		}
		//For format ##:0#
		if(minutes >= 10 && seconds < 10){
			stopwatch.Text =  minutes.ToString().PadDecimals(0) + ":" + "0"+ seconds.ToString().PadDecimals(0);
		}
		//For format ##:##
		if(minutes >= 10 && seconds >= 10){
			stopwatch.Text =  minutes.ToString().PadDecimals(0) + ":" + seconds.ToString().PadDecimals(0);
		}
		//If we have reached midnight reset the clock and upp the day
		if(minutes > 23){
			timeElapsed = 0;
			minutes = 0;
			days+=1;
			dayCounter.Text = "Day " + days.ToString();
		}
		//Change the scene to night time
		if(minutes > 19 && isNight){
			windowSprite.Texture = sprites[2];
			isNight = false;
			toggleLamps(true);
			GD.Print("IsNight: "+isNight);

		}
		//Change the scene to daytime
		if(minutes > 7 && minutes < 19 && !isNight){
			isNight = true;
			Random rng = new Random();
			windowSprite.Texture = sprites[rng.Next(0,1)];
			toggleLamps(false);
			GD.Print("IsNight: "+isNight);
		}

	 }
}
