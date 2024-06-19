using Audio;
using Godot;
using System;

public partial class AudioManager : Node
{


	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}

	public void PlayAudio(AudioClip clip){
		var playback = new AudioStreamPlayer2D();
		AddChild(playback);
		playback.Stream = clip.file;
		playback.VolumeDb = clip.volume;
		playback.Play();
		playback.Finished += () => GetTree().QueueDelete(playback);

		
	}

	public void PlayMusic(AudioClip audio){
		var playback = new AudioStreamPlayer2D();
		AddChild(playback);
		playback.Stream = audio.file;
		playback.VolumeDb = audio.volume;
		playback.Play();
	}
}
