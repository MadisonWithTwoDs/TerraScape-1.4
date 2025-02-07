using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.NPC;
using Terraria.Audio;


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
			Item.rare = ItemRarityID.Master;
			Item.UseSound = SoundID.Item1;
			Item.autoReuse = true;
		}
		public override void ModifyHitNPC(Player player, NPC target, ref NPC.HitModifiers modifiers){
			if (Main.rand.NextFloat() < 0.1f){
				 SoundEngine.PlaySound(new SoundStyle("TerraScape/Assets/Sounds/Melee/DragonClawProc"), player.position);

			for(int i = 0; i < 3 ; i++){
				HitInfo extraHit = new HitInfo(){
					Damage =  (int)(player.GetWeaponDamage(Item) * 0.5f),
					Knockback = 0f,
					Crit = false
				};
				target.StrikeNPC(extraHit);

				 	// Improved Afterimage Effect
            		for (int j = 0; j < 10; j++){ // Spawn more dust particles
                		Dust dust = Dust.NewDustDirect(player.position, player.width, player.height, DustID.Shadowflame, 0f, 0f, 100, default, 2.5f); // Increased scale
                		dust.noGravity = true; // Prevent dust from falling
                		dust.fadeIn = 1.5f; // Makes dust last longer
                		dust.velocity *= 0.1f; // Slower movement for a lingering effect
                		dust.alpha = 150; // Makes the dust more transparent
            		}
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
