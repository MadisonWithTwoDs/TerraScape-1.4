using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;
using Terraria;
using Terraria.GameContent;
using Terraria.ID;
using Terraria.ModLoader;

namespace TerraScape.Content.Items.Weapons.Summon{
    public class AbyssalWhipProjectile : ModProjectile
	{
		public override void SetStaticDefaults() {
			// This makes the projectile use whip collision detection and allows flasks to be applied to it.
			ProjectileID.Sets.IsAWhip[Type] = true;
		}

		public override void SetDefaults() {
			// This method quickly sets the whip's properties.
			Projectile.DefaultToWhip();

			// use these to change from the vanilla defaults
			// Projectile.WhipSettings.Segments = 20;
			// Projectile.WhipSettings.RangeMultiplier = 1f;
		}

		private float Timer {
			get => Projectile.ai[0];
			set => Projectile.ai[0] = value;
		}

		private float ChargeTime {
			get => Projectile.ai[1];
			set => Projectile.ai[1] = value;
		}

		// This example uses PreAI to implement a charging mechanic.
		// If you remove this, also remove Item.channel = true from the item's SetDefaults.
		public override bool PreAI() {
			Player owner = Main.player[Projectile.owner];

			// Like other whips, this whip updates twice per frame (Projectile.extraUpdates = 1), so 120 is equal to 1 second.
			if (!owner.channel || ChargeTime >= 120) {
				return true; // Let the vanilla whip AI run.
			}

			if (++ChargeTime % 12 == 0) // 1 segment per 12 ticks of charge.
				Projectile.WhipSettings.Segments++;

			// Increase range up to 2x for full charge.
			Projectile.WhipSettings.RangeMultiplier += 1 / 120f;

			// Reset the animation and item timer while charging.
			owner.itemAnimation = owner.itemAnimationMax;
			owner.itemTime = owner.itemTimeMax;

			return false; // Prevent the vanilla whip AI from running.
		}

		/* public override void OnHitNPC(NPC target, NPC.HitInfo hit, int damageDone) {
			target.AddBuff(ModContent.BuffType<AbyssalWhipProjectile>(), 240);
			Main.player[Projectile.owner].MinionAttackTargetNPC = target.whoAmI;
			Projectile.damage = (int)(Projectile.damage * 0.5f); // Multihit penalty. Decrease the damage the more enemies the whip hits.
		} */

		// This method draws a line between all points of the whip, in case there's empty space between the sprites.
		private void DrawLine(List<Vector2> list) {
			Texture2D texture = TextureAssets.FishingLine.Value;
			Rectangle frame = texture.Frame();
			Vector2 origin = new Vector2(frame.Width / 2, 2);

			Vector2 pos = list[0];
			for (int i = 0; i < list.Count - 1; i++) {
				Vector2 element = list[i];
				Vector2 diff = list[i + 1] - element;

				float rotation = diff.ToRotation() - MathHelper.PiOver2;
				Color color = Lighting.GetColor(element.ToTileCoordinates(), Color.White);
				Vector2 scale = new Vector2(1, (diff.Length() + 2) / frame.Height);

				Main.EntitySpriteDraw(texture, pos - Main.screenPosition, frame, color, rotation, origin, scale, SpriteEffects.None, 0);

				pos += diff;
			}
		}

		public override bool PreDraw(ref Color lightColor) {
			List<Vector2> list = new List<Vector2>();
			Projectile.FillWhipControlPoints(Projectile, list);

			DrawLine(list);

			//Main.DrawWhip_WhipBland(Projectile, list);
			// The code below is for custom drawing.
			// If you don't want that, you can remove it all and instead call one of vanilla's DrawWhip methods, like above.
			// However, you must adhere to how they draw if you do.

			SpriteEffects flip = Projectile.spriteDirection < 0 ? SpriteEffects.None : SpriteEffects.FlipHorizontally;

			Texture2D texture = TextureAssets.Projectile[Type].Value;

			Vector2 pos = list[0];

			for (int i = 0; i < list.Count - 1; i++) {
				// These two values are set to suit this projectile's sprite, but won't necessarily work for your own.
				// You can change them if they don't!
				Rectangle frame = new Rectangle(0, 0, 10, 26); // The size of the Handle (measured in pixels)
				Vector2 origin = new Vector2(5, 8); // Offset for where the player's hand will start measured from the top left of the image.
				float scale = 1;

				// These statements determine what part of the spritesheet to draw for the current segment.
				// They can also be changed to suit your sprite.
				if (i == list.Count - 2) {
					// This is the head of the whip. You need to measure the sprite to figure out these values.
					frame.Y = 74; // Distance from the top of the sprite to the start of the frame.
					frame.Height = 18; // Height of the frame.

					// For a more impactful look, this scales the tip of the whip up when fully extended, and down when curled up.
					Projectile.GetWhipSettings(Projectile, out float timeToFlyOut, out int _, out float _);
					float t = Timer / timeToFlyOut;
					scale = MathHelper.Lerp(0.5f, 1.5f, Utils.GetLerpValue(0.1f, 0.7f, t, true) * Utils.GetLerpValue(0.9f, 0.7f, t, true));
				}
				else if (i > 10) {
					// Third segment
					frame.Y = 58;
					frame.Height = 16;
				}
				else if (i > 5) {
					// Second Segment
					frame.Y = 42;
					frame.Height = 16;
				}
				else if (i > 0) {
					// First Segment
					frame.Y = 26;
					frame.Height = 16;
				}

				Vector2 element = list[i];
				Vector2 diff = list[i + 1] - element;

				float rotation = diff.ToRotation() - MathHelper.PiOver2; // This projectile's sprite faces down, so PiOver2 is used to correct rotation.
				Color color = Lighting.GetColor(element.ToTileCoordinates());

				Main.EntitySpriteDraw(texture, pos - Main.screenPosition, frame, color, rotation, origin, scale, flip, 0);

				pos += diff;
			}
			return false;
		}
	}



	// ExampleFlail and ExampleFlailProjectile show the minimum amount of code needed for a flail using the existing vanilla code and behavior. ExampleAdvancedFlail and ExampleAdvancedFlailProjectile need to be consulted if more advanced customization is desired, or if you want to learn more advanced modding techniques.
	// ExampleFlailProjectile is a copy of the Sunfury flail projectile.
	/* internal class AbyssalWhipProjectile : ModProjectile
	{
		public override void SetStaticDefaults() {
			ProjectileID.Sets.HeldProjDoesNotUsePlayerGfxOffY[Type] = true;
		}

		public override void SetDefaults() {
			Projectile.netImportant = true; // This ensures that the projectile is synced when other players join the world.
			Projectile.width = 22; // The width of your projectile
			Projectile.height = 22; // The height of your projectile
			Projectile.friendly = true; // Deals damage to enemies
			Projectile.penetrate = -1; // Infinite pierce
			Projectile.DamageType = DamageClass.Melee; // Deals melee damage
			Projectile.scale = 0.8f;
			Projectile.usesLocalNPCImmunity = true; // Used for hit cooldown changes in the ai hook
			Projectile.localNPCHitCooldown = 10; // This facilitates custom hit cooldown logic

			// Here we reuse the flail projectile aistyle and set the aitype to the Sunfury. These lines will get our projectile to behave exactly like Sunfury would. This only affects the AI code, you'll need to adapt other code for the other behaviors you wish to use.
			Projectile.aiStyle = ProjAIStyleID.Flail;
			AIType = ProjectileID.Sunfury;

			// These help center the projectile as it rotates since its hitbox and scale doesn't match the actual texture size
			DrawOffsetX = -6;
			DrawOriginOffsetY = -6;
		}

		// All of the following methods are additional behaviors of Sunfury that are not automatically inherited by ExampleFlailProjectile through the use of Projectile.aiStyle and AIType. You'll need to find corresponding code in the decompiled source code if you wish to clone a different vanilla projectile as a starting point.

		// Draw the projectile in full brightness, ignoring lighting conditions.
		public override Color? GetAlpha(Color lightColor) {
			return Color.White;
		}

		// In PreDrawExtras, we trick the game into thinking the projectile is actually a Sunfury projectile. After PreDrawExtras, the Terraria code will draw the chain. Drawing the chain ourselves is quite complicated, ExampleAdvancedFlailProjectile has an example of that. Then, in PreDraw, we restore the Projectile.type back to normal so we don't break anything.  
		public override bool PreDrawExtras() {
			Projectile.type = ProjectileID.Sunfury;
			return base.PreDrawExtras();
		}
		public override bool PreDraw(ref Color lightColor) {
			Projectile.type = ModContent.ProjectileType<AbyssalWhipProjectile>();

			// This code handles the after images.
			if (Projectile.ai[0] == 1f) {
				Texture2D projectileTexture = TextureAssets.Projectile[Projectile.type].Value;
				Vector2 drawPosition = Projectile.position + new Vector2(Projectile.width, Projectile.height) / 2f + Vector2.UnitY * Projectile.gfxOffY - Main.screenPosition;
				Vector2 drawOrigin = new Vector2(projectileTexture.Width, projectileTexture.Height) / 2f;
				Color drawColor = Projectile.GetAlpha(lightColor);
				drawColor.A = 127;
				drawColor *= 0.5f;
				int launchTimer = (int)Projectile.ai[1];
				if (launchTimer > 5) {
					launchTimer = 5;
				}

				SpriteEffects spriteEffects = Projectile.spriteDirection == 1 ? SpriteEffects.None : SpriteEffects.FlipHorizontally;

				for (float transparency = 1f; transparency >= 0f; transparency -= 0.125f) {
					float opacity = 1f - transparency;
					Vector2 drawAdjustment = Projectile.velocity * -launchTimer * transparency;
					Main.EntitySpriteDraw(projectileTexture, drawPosition + drawAdjustment, null, drawColor * opacity, Projectile.rotation, drawOrigin, Projectile.scale * 1.15f * MathHelper.Lerp(0.5f, 1f, opacity), spriteEffects, 0);
				}
			}

			return base.PreDraw(ref lightColor);
		}

		// Another thing that won't automatically be inherited by using Projectile.aiStyle and AIType are effects that happen when the projectile hits something. Here we see the code responsible for applying the OnFire debuff to players and enemies.
		public override void OnHitNPC(NPC target, NPC.HitInfo hit, int damageDone) {
			if (Main.rand.NextBool(2)) {
				target.AddBuff(BuffID.OnFire, 300);
			}
		}

		public override void OnHitPlayer(Player target, Player.HurtInfo info) {
			if (Main.rand.NextBool(4)) {
				target.AddBuff(BuffID.OnFire, 180, quiet: false);
			}
		}

		// Finally, you can slightly customize the AI if you read and understand the vanilla aiStyle source code. You can't customize the range, retract speeds, or anything else. If you need to customize those things, you'll need to follow ExampleAdvancedFlailProjectile. This example spawns a Grenade right when the flail starts to retract. 
		public override void AI() {
			// The only reason this code works is because the author read the vanilla code and comprehended it well enough to tack on additional logic.
			if (Main.myPlayer == Projectile.owner && Projectile.ai[0] == 2f && Projectile.ai[1] == 0f) {
				Projectile.NewProjectile(Projectile.GetSource_FromThis(), Projectile.Center, Projectile.velocity, ProjectileID.Grenade, Projectile.damage, Projectile.knockBack, Main.myPlayer);
				Projectile.ai[1]++;
			}
		}
	} */
}