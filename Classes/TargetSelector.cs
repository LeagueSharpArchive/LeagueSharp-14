using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LeagueSharp;
using LeagueSharp.Math;
using System.Drawing;
using System.Windows.Input;

namespace TF
{
    class Program
    {
        static void Main(string[] args)
        {
            GameMode gamemode = GameMode.Connecting;

            while (gamemode != GameMode.Running)
            {
                gamemode = Game.Mode;
            }

            if (ObjectManager.Player.BaseSkinName == "TwistedFate")
            {
                Game.OnWndProc += Game_OnWndProc;
                Game.PrintChat(">> TF by Andyi loaded <<");
            }
        }

        private static int lastW;

        static void Game_OnWndProc(WndEventArgs args)
        {
            if (MenuGUI.IsChatOpen == true)
                return;

            if (args.Msg == 0x100)
            {
                switch (args.WParam)
                {
                    case 'E':
                        GetCard(CardType.Blue);
                        args.Process = false;
                        break;
                    case 'T':
                        GetCard(CardType.Gold);
                        args.Process = false;
                        break;
                    case 'G':
                        GetCard(CardType.Red);
                        args.Process = false;
                        break;
                }
            }
        }

        private enum CardType
        {
            Blue,
            Gold,
            Red,
        }

        private static void GetCard(CardType type)
        {
            if (ObjectManager.Player.Spellbook.CanUseSpell(SpellSlot.W) == SpellState.Ready)
            {
                if (ObjectManager.Player.Spellbook.GetSpell(SpellSlot.W).Name == "PickACard" && Environment.TickCount > lastW + 3000)
                {
                    ObjectManager.Player.Spellbook.CastSpell(SpellSlot.W);
                    lastW = Environment.TickCount;
                }
                switch (type)
                {
                    case CardType.Blue:
                        if (ObjectManager.Player.Spellbook.GetSpell(SpellSlot.W).Name == "bluecardlock")
                        {
                            ObjectManager.Player.Spellbook.CastSpell(SpellSlot.W);
                        }
                        break;
                    case CardType.Gold:
                        if (ObjectManager.Player.Spellbook.GetSpell(SpellSlot.W).Name == "goldcardlock")
                        {
                            ObjectManager.Player.Spellbook.CastSpell(SpellSlot.W);
                        }
                        break;
                    case CardType.Red:
                        if (ObjectManager.Player.Spellbook.GetSpell(SpellSlot.W).Name == "redcardlock")
                        {
                            ObjectManager.Player.Spellbook.CastSpell(SpellSlot.W);
                        }
                        break;
                }
            }
        }
    }
}
