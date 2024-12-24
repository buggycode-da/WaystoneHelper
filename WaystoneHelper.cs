using System;

using CharacterData.Utils;
using ExileCore2;
using ExileCore2.PoEMemory.Components;
using ExileCore2.PoEMemory.MemoryObjects;

using System.Numerics;

using System.Drawing;


namespace WaysstoneHelper;

public class WaystoneHelper : BaseSettingsPlugin<WaystoneHelperSettings>
{
    private IngameState InGameState => GameController.IngameState;
    public override void Render()
    {

        var inventoryPanel = InGameState.IngameUi.InventoryPanel;
        if (inventoryPanel.IsVisible)
        {
            var inventoryItems = GameController.IngameState.ServerData.PlayerInventories[0].Inventory.InventorySlotItems;
            foreach ( var item in inventoryItems )
            {
                var mapComponent = item.Item.GetComponent<Map>();
                if (mapComponent == null)
                    continue;
                var drawRect = item.GetClientRect();
                drawRect.Top += 20;
                drawRect.Bottom -= 0;
                drawRect.Right -= 20;
                drawRect.Left += 0;

                var itemMods = item.Item.GetComponent<Mods>() ?? null;
                var mapName = itemMods.UniqueName;
                //convert itemMods to list and logMessage

                int prefixCount = 0;
                int suffixCount = 0;

                // Iterate through the mods
                foreach (var mod in itemMods.ItemMods)
                {
                    if (mod.DisplayName.StartsWith("of", StringComparison.OrdinalIgnoreCase))
                    {
                        suffixCount++;
                    }
                    else
                    {
                        prefixCount++;
                    }
                }

                // Store the counts in an array
                string[] counts = new string[] { prefixCount.ToString(), suffixCount.ToString() };
             
                if (Convert.ToInt32(counts[0]) < 3)
                {
                    TextRenderHelper.DrawMultilineText(Graphics, counts, new Vector2(drawRect.X, drawRect.Y), Color.FromArgb(255, 255, 85, 85));
                }
            }
        }
    }
}