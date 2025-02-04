using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace TerraScape.Content.Items.Accessories
{ 
	public class BerserkerNecklace: ModItem
	{
		public override void SetDefaults()
		{
			Item.accessory = true;
            Item.rare = ItemRarityID.Red;
            Item.width = 22;
            Item.height = 31;
            Item.value = Item.sellPrice(0, 15, 0, 0);
		}
        public override void UpdateEquip(Player player)
        {
            //Adds melee damage equal to the amount of defence under 100
            //Ex: Def = 90 | 100-90 = 10 | player gets +10 meleedamage
            int addedDamage;
            if(player.statDefense < 100){
                addedDamage = 100 - player.statDefense;
                player.GetDamage(DamageClass.Melee) += addedDamage;
            }
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