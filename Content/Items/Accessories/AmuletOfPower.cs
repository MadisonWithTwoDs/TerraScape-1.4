using Steamworks;
using Terraria;
using Terraria.GameContent;
using Terraria.ID;
using Terraria.ModLoader;

/* Dont know if this is going to stay. Really only useful with Barrows NPCs added */

namespace TerraScape.Content.Items.Accessories
{ 
	public class AmuletOfPower : ModItem
	{
		public override void SetDefaults()
		{
			Item.accessory = true;
            Item.rare = ItemRarityID.Blue;
            Item.width = 18;
            Item.height = 29;
            Item.value = Item.sellPrice(0, 1, 0, 0);
		}
        public override void UpdateEquip(Player player)
        {
            //Adds 6% more damage to each type of damage class
            player.GetDamage(DamageClass.Melee) += 0.06f;
            player.GetDamage(DamageClass.Ranged) += 0.06f;
            player.GetDamage(DamageClass.Magic) += 0.06f;
            player.GetDamage(DamageClass.Summon) += 0.06f;
            player.GetDamage(DamageClass.Throwing) += 0.06f;
            //Adds +6 to defense
            player.statDefense += 6;
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