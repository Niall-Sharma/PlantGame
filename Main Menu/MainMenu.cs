using Godot;
using System;

public partial class MainMenu : Control
{
	[Export]
	Control startMenu;

	[Export]
	Control optionsMenu;
	private void _on_start_pressed(){
		GetTree().ChangeSceneToFile("res://Master/master.tscn");
	}

	private void _on_options_pressed(){
		optionsMenu.Visible = true;
		startMenu.Visible = false;
	}

	private void _on_quit_pressed(){
		GetTree().Quit();
	}

	private void _on_back_button_pressed(){
		optionsMenu.Visible = false;
		startMenu.Visible = true;
	}

	private void _on_master_slider_value_changed(){

	}

	private void _on_sound_effect_slider_value_changed(){

	}

	private void _on_music_slider_value_changed(){
		
	}

}
