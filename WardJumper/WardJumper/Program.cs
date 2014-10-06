using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LeagueSharp;
using LeagueSharp.Math;
using System.IO;

namespace WardJumper
{
    class Program
    {
        static void Main(string[] args)
        {
            Game.OnGameUpdate += Game_OnGameUpdate;
            GameObject.OnCreate += GameObject_OnCreate;
            Game.OnGameStart += Game_OnGameStart;
        }

        static void Game_OnGameStart(EventArgs args)
        {
            Game.PrintChat(">> WardJumper loaded <<");
        }

        static void GameObject_OnCreate(GameObject sender, EventArgs args)
        {
            if (sender.Type == GameObjectType.obj_AI_Minion)
            {
                Obj_AI_Minion ward = (Obj_AI_Minion)sender;

                if (ward.Name.ToLower().Contains("ward"))
                {
                    SpellDataInst jumpspell = null;
                    switch (ObjectManager.Player.BaseSkinName)
                    {
                        case "LeeSin":
                            if (ObjectManager.Player.Spellbook.GetSpell(SpellSlot.W).Name == "BlindMonkWOne")
                            {
                                jumpspell = ObjectManager.Player.Spellbook.GetSpell(SpellSlot.W);
                            }
                            break;
                        case "Katarina":
                            jumpspell = ObjectManager.Player.Spellbook.GetSpell(SpellSlot.E);
                            break;
                        case "Jax":
                            jumpspell = ObjectManager.Player.Spellbook.GetSpell(SpellSlot.Q);
                            break;
                    }

                    ObjectManager.Player.Spellbook.CastSpell(jumpspell.Slot, ward);
                }
            }
        }

        static void Game_OnGameUpdate(EventArgs args)
        {
            if (System.Windows.Input.Keyboard.IsKeyDown(System.Windows.Input.Key.G) && MenuGUI.IsChatOpen == false)
            {
                WardJump();
            }
        }

        private static int[] wardItems = { 2044, 2043, 2049, 2045, 3154, 3340, 3350, 3361 };
        private static int lastplaced = 0;

        private static void WardJump()
        {
            SpellDataInst jumpspell = null;
            switch(ObjectManager.Player.BaseSkinName)
            {
                case "LeeSin":
                    if (ObjectManager.Player.Spellbook.GetSpell(SpellSlot.W).Name == "BlindMonkWOne")
                    {
                        jumpspell = ObjectManager.Player.Spellbook.GetSpell(SpellSlot.W);
                    }
                    break;
                case "Katarina":
                    jumpspell = ObjectManager.Player.Spellbook.GetSpell(SpellSlot.E);
                    break;
                case "Jax":
                    jumpspell = ObjectManager.Player.Spellbook.GetSpell(SpellSlot.Q);
                    break;
            }

            if (jumpspell != null && Environment.TickCount > lastplaced + 3000)
            {
                if (ObjectManager.Player.Spellbook.CanUseSpell(jumpspell.Slot) == SpellState.Ready)
                {
                    Vector3 cursorPos = Game.CursorPos;
                    Vector3 myPos = ObjectManager.Player.Position;

                    Vector3 delta = cursorPos - myPos;
                    delta.Normalize();

                    Vector3 wardPosition = myPos + delta * (600 - 25);
                    //Vector3 wardPosition = cursorPos;

                    InventorySlot invSlot = FindBestWardItem();
                    if (invSlot != null)
                    {
                        invSlot.UseItem(wardPosition);
                    }
                }
            }
        }

        private static SpellDataInst GetItemSpell(InventorySlot invSlot)
        {
            return ObjectManager.Player.Spellbook.Spells.Where(spell => (int)spell.Slot == invSlot.Slot + 4).FirstOrDefault();
        }

        private static InventorySlot FindBestWardItem()
        {
            InventorySlot[] invItems = ObjectManager.Player.InventoryItems;

            foreach (InventorySlot item in invItems)
            {
                if (wardItems.Where(i => i == item.ItemId).FirstOrDefault() != default(int))
                {
                    SpellDataInst sdi = GetItemSpell(item);

                    if (sdi != default(SpellDataInst)
                        && sdi.State == SpellState.Ready)
                    {
                        return item;
                    }
                }
            }
            return null;
        }
    }
}
