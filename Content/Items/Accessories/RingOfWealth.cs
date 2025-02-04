using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.GameContent.ItemDropRules;

namespace TerraScape.Content.Items.Accessories
{ 
	public class RingOfWealth: ModItem
	{
		public override void SetDefaults()
		{
			Item.accessory = true;
            Item.rare = ItemRarityID.Yellow;
            Item.width = 18;
            Item.height = 29;
            Item.value = Item.sellPrice(0, 5, 0, 0);
		}

        //Checks if the ring is eqiupped, otherwise the drop buff would be permanent
        public class playerWealth : ModPlayer{
            public bool playerWealthEquipped;
            public override void ResetEffects(){
                playerWealthEquipped = false;
            }
        }

        //This should double the chance of hitting rare drop table on boss kills
        public void ModifyNPCLoot(NPC npc, NPCLoot npcLoot){
            if(npc.boss){
                foreach(var rule in npcLoot.Get()){
                    if(rule is CommonDrop commonDrop){

                        int newChance = commonDrop.chanceDenominator / 2;
                        
                        if (newChance < 1) newChance = 1;
                        npcLoot.Remove(rule);
                        npcLoot.Add(ItemDropRule.Common(commonDrop.itemId, newChance));
                    }
                }
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
/*
Without the Ring Equipped 
--------------------------
Suspicious Grinning Eye = 10
Eye of Cthulu Trophy = 2
--------------------------

With Ring Equipped
--------------------------
Suspicious Grinning Eye = 
Eye of Cthulu Trophy = 
--------------------------
*/