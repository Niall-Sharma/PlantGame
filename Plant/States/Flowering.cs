using Godot;
using System;

public partial class Flowering : State
{

	[Export]
	float value;

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
		master.AddCurrency(value);
		GetParent<StateMachine>().setNextState(nextState);
	}

}
