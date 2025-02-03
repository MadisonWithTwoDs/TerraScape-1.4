using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace TerraScape.Content.Items.Accessories
{ 
	public class AmuletOfFury : ModItem
	{
		public override void SetDefaults()
		{
			Item.accessory = true;
            Item.rare = ItemRarityID.Yellow;
            Item.width = 18;
            Item.height = 29;
            Item.value = Item.sellPrice(0, 10, 0, 0);
		}
         public override void UpdateEquip(Player player)
        {
            //Adds 10% more damage to each type of damage class
            player.GetDamage(DamageClass.Melee) += 0.10f;
            player.GetDamage(DamageClass.Ranged) += 0.10f;
            player.GetDamage(DamageClass.Magic) += 0.10f;
            player.GetDamage(DamageClass.Summon) += 0.10f;
            player.GetDamage(DamageClass.Throwing) += 0.10f;
            //Adds +15 to defense
            player.statDefense += 15;
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