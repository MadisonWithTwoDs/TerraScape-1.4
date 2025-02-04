using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace TerraScape.Content.Items.Accessories{ 
	public class TormentedBracelet: ModItem{
		public override void SetDefaults(){
			Item.accessory = true;
            Item.rare = ItemRarityID.Red;
            Item.width = 22;
            Item.height = 31;
            Item.value = Item.sellPrice(0, 15, 0, 0);
		}
        public class playerTormentedBracelet : ModPlayer{
            public bool TormentedBraceletEquipped;
            public override void ResetEffects(){
                TormentedBraceletEquipped = false;
            }
        }
        public override void UpdateEquip(Player player){
            //18% increased Magic Damage
            //Magical Attacks have a chance to unleash tormented souls
            //Amount of souls increase with lower HP
            player.GetDamage(DamageClass.Magic) += 0.18f;
            //Need to add the souls buff
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