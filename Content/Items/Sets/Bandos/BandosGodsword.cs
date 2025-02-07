using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Audio;

namespace TerraScape.Content.Items.Sets.Bandos{ 
	public class BandosGodsword : ModItem{
		public override void SetDefaults(){
			Item.damage = 132;
			Item.DamageType = DamageClass.Melee;
			Item.width = 50;
			Item.height = 50;
			Item.useTime = 30;
			Item.useAnimation = 30;
			Item.useTurn = true;
			Item.useStyle = ItemUseStyleID.Swing;
			Item.knockBack = 11;
			Item.value = Item.buyPrice(silver: 1);
			Item.rare = ItemRarityID.Master;
			Item.UseSound = SoundID.Item1;
			Item.autoReuse = true;
			//Item.shoot = ProjectileID.HolyArrow;
		}

        public override void ModifyHitNPC(Player player, NPC target, ref NPC.HitModifiers modifiers){
            if(Main.rand.NextFloat() < 0.1f){
                modifiers.SourceDamage *= 1.5f; //adds 50% to the damage of the attack
                target.AddBuff(BuffID.Ichor, 300); //Adds a 5 second debuff to the npc that drops its defence by 15
                //SoundEngine.PlaySound(new SoundStyle("TerraScape/Assets/Sounds/Melee/DragonClawProc"), player.position);//Adds a sound when NPC debuff is procced

                for (int j = 0; j < 10; j++){ // Spawn more dust particles
                		Dust dust = Dust.NewDustDirect(player.position, player.width/2, player.height/2, DustID.RedTorch, 0f, 0f, 100, default, 2.5f); // Increased scale
                		dust.noGravity = true; // Prevent dust from falling
                		dust.fadeIn = 1.5f; // Makes dust last longer
                		dust.velocity *= 0.1f; // Slower movement for a lingering effect
                		dust.alpha = 150; // Makes the dust more transparent
            		}
            }
        }

        public override void AddRecipes(){
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ItemID.DirtBlock, 10);
			recipe.AddTile(TileID.WorkBenches);
			recipe.Register();
        }
    }
}
