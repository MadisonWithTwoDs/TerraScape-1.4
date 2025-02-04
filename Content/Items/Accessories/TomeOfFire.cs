using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace TerraScape.Content.Items.Accessories{ 
	public class TomeOfFire: ModItem{
		public override void SetDefaults(){
			Item.accessory = true;
            Item.rare = ItemRarityID.Yellow;
            Item.width = 22;
            Item.height = 31;
            Item.value = Item.sellPrice(0, 15, 0, 0);
		}
        
        public override void UpdateEquip(Player player){
            //10% increased Magic Damage
            //Magical Attacks imbued with flames
            player.GetDamage(DamageClass.Magic) += 0.10f;
            //Need to add the flames buff
        }

        /* 
        Test recipe to make sure item is working 
        Proper recipe to be added with time
        */
        public override void AddRecipes(){
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ItemID.DirtBlock, 1);
			recipe.AddTile(TileID.WorkBenches);
			recipe.Register();
		} 
	}
}