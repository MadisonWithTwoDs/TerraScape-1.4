using Steamworks;
using Terraria;
using Terraria.GameContent;
using Terraria.ID;
using Terraria.ModLoader;

namespace TerraScape.Content.Items.Accessories
{ 
	public class AmuletOfMagic : ModItem
	{
		public override void SetDefaults()
		{
			Item.accessory = true;
            Item.rare = ItemRarityID.Blue;
            Item.width = 18;
            Item.height = 29;
            Item.value = Item.sellPrice(0, 0, 50, 0);
		}
        public override void UpdateEquip(Player player)
        {
            //Adds 10% more damage to magic damage class
            player.GetDamage(DamageClass.Magic) += 0.10f;
        }
        /* 
        Test recipe to make sure item is working 
        Proper recipe to be added with time
        */
        public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ItemID.DirtBlock, 1);
			recipe.AddTile(TileID.WorkBenches);
			recipe.Register();
		} 
	}
}