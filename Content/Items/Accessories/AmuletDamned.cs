using Terraria;
using Terraria.GameContent;
using Terraria.ID;
using Terraria.ModLoader;

/* Dont know if this is going to stay. Really only useful with Barrows NPCs added */

namespace TerraScape.Content.Items.Accessories
{ 
	public class AmuletDamned : ModItem
	{
		public override void SetDefaults()
		{
			Item.accessory = true;
            Item.rare = ItemRarityID.Lime;
            Item.width = 22;
            Item.height = 31;
            Item.value = Item.sellPrice(0, 5, 0, 0);
		}
		//Test recipe to make sure item is working
		public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ItemID.DirtBlock, 1);
			recipe.AddTile(TileID.WorkBenches);
			recipe.Register();
		} 
	}
}