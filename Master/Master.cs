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
	bool isNight;
	double timeElapsed;
	int days = 1;
	private void _on_watering_button_toggled(bool toggled_on){
		GD.Print(toggled_on);
		waterToggle = toggled_on;
	}

	public bool checkWaterToggle(){
		return waterToggle;
	}

	public void AddCurrency(float amount){
		currency += amount;
		currencyLabel.Text = currency.ToString();
	}
	public void RemoveCurrency(float amount){
		currency -= amount;
		currencyLabel.Text = currency.ToString();
	}
	private void _on_buy_button_pressed(){
		buyMenu.Visible = !buyMenu.Visible;
		menuCode.UpdateMenu();
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
		timeElapsed = (float)(timeElapsed+delta*10);
		float minutes = (float)(timeElapsed/60);
		float seconds = (float)(timeElapsed%60);
		if(minutes<10 && seconds >= 10){
			stopwatch.Text = "0" + minutes.ToString().PadDecimals(0) + ":" + seconds.ToString().PadDecimals(0);

		}
		if(minutes < 10 && seconds < 10){
			stopwatch.Text = "0" + minutes.ToString().PadDecimals(0) + ":" + "0"+ seconds.ToString().PadDecimals(0);
		}
		if(minutes >= 10 && seconds < 10){
			stopwatch.Text =  minutes.ToString().PadDecimals(0) + ":" + "0"+ seconds.ToString().PadDecimals(0);
		}
		if(minutes >= 10 && seconds >= 10){
			stopwatch.Text =  minutes.ToString().PadDecimals(0) + ":" + seconds.ToString().PadDecimals(0);
		}

		// string seconds = (timeElapsed*100).ToString();
		// seconds = seconds.PadDecimals(0);
		// if(timeElapsed > .64){
		// 	minutes++;
		// 	timeElapsed = 0;
		// }
		if(minutes > 23){
			timeElapsed = 0;
			minutes = 0;
			days+=1;
			dayCounter.Text = "Day " + days.ToString();
		}

		if(minutes > 19 && isNight){
			windowSprite.Texture = sprites[2];
			isNight = false;

		}
		if(minutes > 7 && !isNight){
			isNight = true;
			Random rng = new Random();
			windowSprite.Texture = sprites[rng.Next(0,1)];
		}

     }
}
