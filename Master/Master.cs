using Godot;
using System;

public partial class Master : Node2D
{


	public float currency;
	bool waterToggle;
	[Export]
	Label currencyLabel;

	[Export]
	PackedScene[] plants;

	[Export]
	Control buyMenu;

	[Export]
	BuyMenu menuCode;
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
}
