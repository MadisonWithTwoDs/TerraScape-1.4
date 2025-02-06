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
		public override void ModifyHitNPC(Player player, NPC target, ref NPC.HitModifiers modifiers){
			if (Main.rand.NeftFloat() < 0.1f)

			for(int 1=0, int<3:i++){
				int extraDamage = (int)(player.GetWeaponDamage(Item)*0.5f);
				target.StrikeNPC(extraDamage, 0f, player.direction);

				for (int j = 0; j < 5; j++){ // Create multiple dust particles
                	Dust dust = Dust.NewDustDirect(player.position, player.width, player.height, DustID.Shadowflame, 
                    player.velocity.X * -0.5f, player.velocity.Y * -0.5f, 100, default, 1.5f);
                	dust.noGravity = true; // Make the dust float
                	dust.fadeIn = 1.2f; // Slightly increase its lifespan
                	dust.velocity *= 0.2f; // Slow down movement for a trailing effect
            	}
			}
		}
		
			
		

		public override void AddRecipes(){
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ItemID.DirtBlock, 1);
			recipe.AddTile(TileID.WorkBenches);
			recipe.Register();
		}
	}
}
