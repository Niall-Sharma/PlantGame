using Catalog;
using Godot;
using System;

public partial class BuyMenu : VBoxContainer
{
	[Export]
	CatalogItem[] catalogItems;

	[Export]
	TextureRect plantIcon;

	[Export]
	Label plantName;

	[Export]
	Label plantPrice;

	[Export]
	Label stages;


	public int index = 0;

	private void _on_previous_pressed(){
		if(index > 0){
			index--;
			UpdateMenu();
		}
	}

	private void _on_buy_plant_pressed(){
		GetParent().GetParent().GetParent<Master>().BuyPlant(catalogItems[index].plantPrefab, catalogItems[index].plantPrice);
	}

	private void _on_advance_pressed(){
		if(index < catalogItems.Length-1){
			index++;
			UpdateMenu();
		}
	}

	void UpdateMenu(){
		plantIcon.Texture = catalogItems[index].plantIcon;
		plantName.Text = catalogItems[index].plantName;
		plantPrice.Text = "$"+catalogItems[index].plantPrice.ToString();
		stages.Text = catalogItems[index].numberOfStages.ToString() + " Stages";
	}
}
