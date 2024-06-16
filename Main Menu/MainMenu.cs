using Godot;
using System;

public partial class MainMenu : Control
{

	private void _on_start_pressed(){
		GetTree().ChangeSceneToFile("res://Master/master.tscn");
	}

	private void _on_options_pressed(){

	}

	private void _on_quit_pressed(){
		GetTree().Quit();
	}


}
