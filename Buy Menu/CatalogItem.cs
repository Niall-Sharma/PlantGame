using Godot;

namespace Catalog
{
    public partial class CatalogItem : Resource
    {
		[Export]
		public Texture2D plantIcon;

		[Export]
		public string plantName;

		[Export]
		public int plantPrice;

		[Export]
		public int numberOfStages;
		[Export]
		public bool isReusable;
		[Export]
		public PackedScene plantPrefab;

        // Make sure you provide a parameterless constructor.
        // In C#, a parameterless constructor is different from a
        // constructor with all default values.
        // Without a parameterless constructor, Godot will have problems
        // creating and editing your resource via the inspector.
        public CatalogItem() : this(null, "", 0, 0,true,null) {}

        public CatalogItem(Texture2D plantIcon, string plantName, int plantPrice, int numberOfStages, bool isReusable, PackedScene plantPrefab)
        {
            plantIcon = this.plantIcon;
			plantName = this.plantName;
			plantPrice = this.plantPrice;
			numberOfStages = this.numberOfStages;
			isReusable = this.isReusable;
			plantPrefab = this.plantPrefab;
        }
    }
}