using Audio;
using Godot;
using System;

public partial class Flowering : State
{
	[Export]
	AudioClip snipSound;
	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _update()
	{
		if(plantMain.mouseInArea && Input.IsMouseButtonPressed(MouseButton.Right)){
				HarvestPlant();
		}
	}

	public override void _OnEnter()
	{
		sprite2D.Texture = plantSprite;
	}

	void HarvestPlant(){
		master.AddCurrency(GetParent<StateMachine>().plantValue);
		audioManager.PlayAudio(snipSound);
		if(!GetParent<StateMachine>().isReusable){
			GetTree().QueueDelete(GetParent().GetParent());
		}
		GetParent<StateMachine>().setNextState(nextState);
	}

}
