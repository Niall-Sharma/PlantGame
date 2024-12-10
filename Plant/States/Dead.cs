using Godot;
using System;

public partial class Dead : State
{

	public override void _OnExit()
	{
		GetTree().QueueDelete(GetParent().GetParent());
	}
}
