using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace TerraScape.Content.Items.Armor.Bandos{
    public class BandosChestplate : ModItem{
        public override void SetDefaults()
        {
            Item.width = 18;
            Item.height = 18;
            Item.value = Item.buyPrice(gold: 5);
            Item.rare = ItemRarityID.Master;
            Item.defense = 23; // Defense value
            Item.bodySlot = 0;
        }

        public override void UpdateEquip(Player player){
            player.GetCritChance(DamageClass.Melee) += 12; // +12% crit chance to melee
        }
    }
}