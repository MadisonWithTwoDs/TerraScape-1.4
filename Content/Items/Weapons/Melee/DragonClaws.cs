using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace TerraScape.Content.Items.Weapons.Melee{ 
	public class DragonClaws : ModItem{
		public override void SetDefaults(){
			Item.damage = 73;
			Item.DamageType = DamageClass.Melee;
			Item.width = 28;
			Item.height = 30;
			Item.useTime = 10;
			Item.useAnimation = 10;
            Item.useTurn = true;
			Item.useStyle = ItemUseStyleID.Swing;
			Item.knockBack = 2;
			Item.value = Item.buyPrice(gold: 3);
			Item.rare = ItemRarityID.Yellow;
			Item.UseSound = SoundID.Item1;
			Item.autoReuse = true;
		}

		public override void AddRecipes(){
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ItemID.DirtBlock, 1);
			recipe.AddTile(TileID.WorkBenches);
			recipe.Register();
		}
	}
}