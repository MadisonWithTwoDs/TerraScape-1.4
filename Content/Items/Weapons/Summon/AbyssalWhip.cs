using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace TerraScape.Content.Items.Weapons.Summon
{
	public class AbyssalWhip : ModItem{
		public override void SetDefaults(){
			// This method quickly sets the whip's properties.
			// Mouse over to see its parameters.
			Item.DefaultToWhip(ModContent.ProjectileType<AbyssalWhipProjectile>(), 82, 2, 4);
			Item.rare = ItemRarityID.Green;
			Item.channel = true;
		}

		public override void AddRecipes(){
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ItemID.DirtBlock, 1);
			recipe.AddTile(TileID.WorkBenches);
			recipe.Register();
		}
		// Makes the whip receive melee prefixes
		public override bool MeleePrefix() {
			return true;
		}
	}
}
/* namespace TerraScape.Content.Items.Weapons.Melee{ 
	// This is a basic item template.
	// Please see tModLoader's ExampleMod for every other example:
	// https://github.com/tModLoader/tModLoader/tree/stable/ExampleMod
	public class AbyssalWhip : ModItem{
		// The Display Name and Tooltip of this item can be edited in the 'Localization/en-US_Mods.TutorialMod.hjson' file.
		public override void SetDefaults(){
			//Took these from the example flail
			Item.useStyle = ItemUseStyleID.Shoot; // How you use the item (swinging, holding out, etc.)
			Item.useAnimation = 45; // The item's use time in ticks (60 ticks == 1 second.)
			Item.useTime = 45; // The item's use time in ticks (60 ticks == 1 second.)
			Item.knockBack = 6.75f; // The knockback of your flail, this is dynamically adjusted in the projectile code.
			Item.width = 30; // Hitbox width of the item.
			Item.height = 10; // Hitbox height of the item.
			Item.damage = 32; // The damage of your flail, this is dynamically adjusted in the projectile code.
			Item.crit = 7; // Critical damage chance %
			Item.scale = 1.1f;
			Item.noUseGraphic = true; // This makes sure the item does not get shown when the player swings his hand
			Item.shoot = ModContent.ProjectileType<AbyssalWhipProjectile>(); // The flail projectile
			Item.shootSpeed = 12f; // The speed of the projectile measured in pixels per frame.
			Item.UseSound = SoundID.Item1; // The sound that this item makes when used
			Item.rare = ItemRarityID.Orange; // The color of the name of your item
			Item.value = Item.sellPrice(gold: 2, silver: 50); // Sells for 2 gold 50 silver
			Item.DamageType = DamageClass.MeleeNoSpeed; // Deals melee damage
			Item.channel = true;
			Item.noMelee = true; // This makes sure the item does not deal damage from the swinging animation
		}

		public override void AddRecipes(){
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ItemID.DirtBlock, 10);
			recipe.AddTile(TileID.WorkBenches);
			recipe.Register();
		}
	}
} */