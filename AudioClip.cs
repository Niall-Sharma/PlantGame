// BotStats.cs
using Godot;

namespace Audio
{
    public partial class AudioClip : Resource
    {
        [Export(PropertyHint.Range, "0,10")]
        public float volume { get; set; }

        [Export]
        public AudioStream file { get; set; }

        // Make sure you provide a parameterless constructor.
        // In C#, a parameterless constructor is different from a
        // constructor with all default values.
        // Without a parameterless constructor, Godot will have problems
        // creating and editing your resource via the inspector.
        public AudioClip() : this(0, null) {}

        public AudioClip(float volume, AudioStream file)
        {
            volume = this.volume;
            file = this.file;
        }
    }
}