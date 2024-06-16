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
	Label reusable;

	[Export]
	Master master;

	public int index = 0;


	public override void _Ready(){
		UpdateMenu();
	}

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

	public void UpdateMenu(){
		plantIcon.Texture = catalogItems[index].plantIcon;
		plantName.Text = catalogItems[index].plantName;
		plantPrice.Text = "$"+catalogItems[index].plantPrice.ToString();
		if(master.currency >= catalogItems[index].plantPrice){
			plantPrice.Modulate = Colors.Green;
		}else{
			plantPrice.Modulate = Colors.Red;
		}
		if(catalogItems[index].isReusable){
			reusable.Text = "Can Be Harvested";
			reusable.Modulate = Colors.Orange;	
		}
		else{
			reusable.Text = "Can Not Harvested";
			reusable.Modulate = Colors.Yellow;	
		}
		// reusable.Text = catalogItems[index].numberOfStages.ToString() + " Stages";
	}
}
