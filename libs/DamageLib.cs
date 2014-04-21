/*
 * Library: DamageLib
 * Author: Vis, ZeroX
 * Date: 21.04.2014
 * Version: 1
 * Methods:
 * - getDmg(Obj_AI_Hero, SpellType, [StageType])
 * - CalcMagicDmg(double, Obj_AI_Hero)
 * - CalcPhysicalDmg(double, Obj_AI_Hero)
 */

using System;
using System.Collections.Generic;
using LeagueSharp;
using System.Net;

public static class DamageLib
{
    private static int localversion = 1;
    static DamageLib()
    {
        Game.PrintChat("<font color='#33FFFF'>>> DamageLib [V." + localversion + "] by Vis & ZeroX loaded <<</font>");
        // Version Check
        WebClient wc = new WebClient();
        wc.Proxy = null;
        wc.DownloadStringCompleted += wc_DownloadStringCompleted;
        wc.DownloadStringAsync(new Uri("https://raw.githubusercontent.com/Andyi19/LeagueSharp/master/libs/DamageLibVersion.txt"));
        // Get my Hero
        switch (ObjectManager.Player.BaseSkinName)
        {
            case "Aatrox":
                champ = Aatrox;
                break;
            case "Ahri":
                champ = Ahri;
                break;
            case "Akali":
                champ = Akali;
                break;
            case "Alistar":
                champ = Alistar;
                break;
            case "Amumu":
                champ = Amumu;
                break;
            case "Anivia":
                champ = Anivia;
                break;
            case "Annie":
                champ = Annie;
                break;
            case "Ashe":
                champ = Ashe;
                break;
            case "Blitzcrank":
                champ = Blitzcrank;
                break;
            case "Brand":
                champ = Brand;
                break;
            case "Caitlyn":
                champ = Caitlyn;
                break;
            case "Cassiopeia":
                champ = Cassiopeia;
                break;
            case "ChoGath":
                champ = ChoGath;
                break;
            case "Corki":
                champ = Corki;
                break;
            case "Darius":
                champ = Darius;
                break;
            case "Diana":
                champ = Diana;
                break;
            case "Draven":
                champ = Draven;
                break;
            case "DrMundo":
                champ = DrMundo;
                break;
            case "Elise":
                champ = Elise;
                break;
            case "Evelynn":
                champ = Evelynn;
                break;
            case "Ezreal":
                champ = Ezreal;
                break;
            case "Fiddlesticks":
                champ = Fiddlesticks;
                break;
            case "Fiora":
                champ = Fiora;
                break;
            case "Fizz":
                champ = Fizz;
                break;
            case "Galio":
                champ = Galio;
                break;
            case "Gangplank":
                champ = Gangplank;
                break;
            case "Garen":
                champ = Garen;
                break;
            case "Gragas":
                champ = Gragas;
                break;
            case "Graves":
                champ = Graves;
                break;
            case "Hecarim":
                champ = Hecarim;
                break;
            case "Heimerdinger":
                champ = Heimerdinger;
                break;
            case "Irelia":
                champ = Irelia;
                break;
            case "Janna":
                champ = Janna;
                break;
            case "JarvanIV":
                champ = JarvanIV;
                break;
            case "Jax":
                champ = Jax;
                break;
            case "Jayce":
                champ = Jayce;
                break;
            case "Jinx":
                champ = Jinx;
                break;
            case "Karma":
                champ = Karma;
                break;
            case "Karthus":
                champ = Karthus;
                break;
            case "Kassadin":
                champ = Kassadin;
                break;
            case "Katarina":
                champ = Katarina;
                break;
            case "Kayle":
                champ = Kayle;
                break;
            case "Kennen":
                champ = Kennen;
                break;
            case "KhaZix":
                champ = KhaZix;
                break;
            case "KogMaw":
                champ = KogMaw;
                break;
            case "Leblanc":
                champ = LeBlanc;
                break;
            case "LeeSin":
                champ = LeeSin;
                break;
            case "Leona":
                champ = Leona;
                break;
            case "Lissandra":
                champ = Lissandra;
                break;
            case "Lucian":
                champ = Lucian;
                break;
            case "Lulu":
                champ = Lulu;
                break;
            case "Lux":
                champ = Lux;
                break;
            case "Malphite":
                champ = Malphite;
                break;
            case "Malzahar":
                champ = Malzahar;
                break;
            case "Maokai":
                champ = Maokai;
                break;
            case "MasterYi":
                champ = MasterYi;
                break;
            case "MissFortune":
                champ = MissFortune;
                break;
            case "Mordekaiser":
                champ = Mordekaiser;
                break;
            case "Morgana":
                champ = Morgana;
                break;
            case "Nami":
                champ = Nami;
                break;
            case "Nasus":
                champ = Nasus;
                break;
            case "Nautilus":
                champ = Nautilus;
                break;
            case "Nidalee":
                champ = Nidalee;
                break;
            case "Nocturne":
                champ = Nocturne;
                break;
            case "Nunu":
                champ = Nunu;
                break;
            case "Olaf":
                champ = Olaf;
                break;
            case "Orianna":
                champ = Orianna;
                break;
            case "Pantheon":
                champ = Pantheon;
                break;
            case "Poppy":
                champ = Poppy;
                break;
            case "Quinn":
                champ = Quinn;
                break;
            case "Rammus":
                champ = Rammus;
                break;
            case "Renekton":
                champ = Renekton;
                break;
            case "Rengar":
                champ = Rengar;
                break;
            case "Riven":
                champ = Riven;
                break;
            case "Rumble":
                champ = Rumble;
                break;
            case "Ryze":
                champ = Ryze;
                break;
            case "Sejuani":
                champ = Sejuani;
                break;
            case "Shaco":
                champ = Shaco;
                break;
            case "Shen":
                champ = Shen;
                break;
            case "Shyvanna":
                champ = Shyvana;
                break;
            case "Singed":
                champ = Singed;
                break;
            case "Sion":
                champ = Sion;
                break;
            case "Sivir":
                champ = Sivir;
                break;
            case "Skarner":
                champ = Skarner;
                break;
            case "Sona":
                champ = Sona;
                break;
            case "Soraka":
                champ = Soraka;
                break;
            case "Swain":
                champ = Swain;
                break;
            case "Syndra":
                champ = Syndra;
                break;
            case "Talon":
                champ = Talon;
                break;
            case "Taric":
                champ = Taric;
                break;
            case "Teemo":
                champ = Teemo;
                break;
            case "Thresh":
                champ = Thresh;
                break;
            case "Tristana":
                champ = Tristana;
                break;
            case "Trundle":
                champ = Trundle;
                break;
            case "Tryndamere":
                champ = Tryndamere;
                break;
            case "TwistedFate":
                champ = TwistedFate;
                break;
            case "Twitch":
                champ = Twitch;
                break;
            case "Udyr":
                champ = Udyr;
                break;
            case "Urgot":
                champ = Urgot;
                break;
            case "Varus":
                champ = Varus;
                break;
            case "Vayne":
                champ = Vayne;
                break;
            case "Veigar":
                champ = Veigar;
                break;
            case "Velkoz":
                champ = Velkoz;
                break;
            case "Vi":
                champ = Vi;
                break;
            case "Viktor":
                champ = Viktor;
                break;
            case "Vladimir":
                champ = Vladimir;
                break;
            case "Volibear":
                champ = Volibear;
                break;
            case "Warwick":
                champ = Warwick;
                break;
            case "MonkeyKing":
                champ = MonkeyKing;
                break;
            case "Xerath":
                champ = Xerath;
                break;
            case "XinZhao":
                champ = XinZhao;
                break;
            case "Yasuo":
                champ = Yasuo;
                break;
            case "Yorick":
                champ = Yorick;
                break;
            case "Zac":
                champ = Zac;
                break;
            case "Zed":
                champ = Zed;
                break;
            case "Ziggs":
                champ = Ziggs;
                break;
            case "Zilean":
                champ = Zilean;
                break;
            case "Zyra":
                champ = Zyra;
                break;
            default:
                Game.PrintChat("DamageLib: Could not find the champion '" + ObjectManager.Player.BaseSkinName + "'. Please report this in the forums, it's either a wrong typed name or a new hero that needs to be added!");
                break;
        }
        // Get Masteries
        foreach (Mastery mastery in ObjectManager.Player.Masteries)
        {
            if (mastery.Page == MasteryPage.Offense)
            {
                if (mastery.Id == 65) // double edged sword
                {
                    if (mastery.Points == 1)
                    {
                        doubleedgedsword = true;
                    }
                }
                else if (mastery.Id == 146) // havoc
                {
                    if (mastery.Points == 1)
                    {
                        havoc = true;
                    }
                }
                else if (mastery.Id == 132) // arcane blade
                {
                    if (mastery.Points == 1)
                    {
                        arcaneblade = true;
                    }
                }
                else if (mastery.Id == 100) // executioner
                {
                    if (mastery.Points == 1)
                    {
                        executioner = 1;
                    }
                    else if (mastery.Points == 2)
                    {
                        executioner = 2;
                    }
                    else if (mastery.Points == 3)
                    {
                        executioner = 3;
                    }
                }
            }
        }

        // Get enemy masteries
        foreach (Obj_AI_Hero hero in ObjectManager.Get<Obj_AI_Hero>())
        {
            if (hero != null && hero.IsValid == true)
            {
                int unyielding = 0;
                int block = 0;
                foreach (Mastery mastery in hero.Masteries)
                {
                    if (mastery.Page == MasteryPage.Defense)
                    {
                        if (mastery.Id == 81) // Unyielding
                        {
                            if (mastery.Points == 1)
                            {
                                if (hero.CombatType == GameObjectCombatType.Melee)
                                {
                                    unyielding = 2;
                                }
                                else
                                {
                                    unyielding = 1;
                                }
                            }
                        }
                        if (mastery.Id == 65) // Block
                        {
                            if (mastery.Points == 1)
                            {
                                block = 1;
                            }
                            else if (mastery.Points == 2)
                            {
                                block = 2;
                            }
                        }
                    }
                }
                enemyList.Add(new Enemy { NetworkId = hero.NetworkId, block = block, unyielding = unyielding });
            }
        }
    }

    static void wc_DownloadStringCompleted(object sender, DownloadStringCompletedEventArgs e)
    {
        try
        {
            int version = Convert.ToInt32(e.Result);
            if (version > localversion)
            {
                Game.PrintChat("<font color='#33FFFF'>DamageLib: New Update available!</font>");
            }
            else if (version == localversion)
            {
                Game.PrintChat("<font color='#33FFFF'>DamageLib: You have to most recent version loaded!</font>");
            }
        }
        catch
        {
            Game.PrintChat("<font color='#33FFFF'>DamageLib: Could not get Version Info!</font>");
        }
    }

    private static List<Enemy> enemyList = new List<Enemy>();

    private static ChampDamage champ;
    private delegate double ChampDamage(Obj_AI_Hero enemy, SpellType type, StageType stagetype);

    private static bool IsBetween<T>(this T item, T start, T end)
    {
        return Comparer<T>.Default.Compare(item, start) >= 0
            && Comparer<T>.Default.Compare(item, end) <= 0;
    }

    // offsensive masteries
    private static bool doubleedgedsword = false;
    private static bool havoc = false;
    private static int executioner = 0;
    private static bool arcaneblade = false;

    /// <summary>
    /// Calculates the damage into the physical damage using Armor, Armorpenetration and Masteries
    /// </summary>
    /// <param name="dmg">The basic damage</param>
    /// <param name="enemy">The enemy hero object</param>
    /// <returns>Returns the physical damage</returns>
    public static double CalcPhysicalDmg(double dmg, Obj_AI_Hero enemy)
    {
        double additionaldmg = 0;
        if (doubleedgedsword == true)
        {
            if (ObjectManager.Player.CombatType == GameObjectCombatType.Melee)
            {
                additionaldmg += dmg * 0.02;
            }
            else
            {
                additionaldmg += dmg * 0.015;
            }
        }
        if (havoc == true)
        {
            additionaldmg += dmg * 0.03;
        }
        if (executioner > 0)
        {
            if (executioner == 1)
            {
                if ((enemy.Health / enemy.MaxHealth) * 100 < 20)
                {
                    additionaldmg += dmg * 0.05;
                }
            }
            else if (executioner == 2)
            {
                if ((enemy.Health / enemy.MaxHealth) * 100 < 35)
                {
                    additionaldmg += dmg * 0.05;
                }
            }
            else if (executioner == 3)
            {
                if ((enemy.Health / enemy.MaxHealth) * 100 < 50)
                {
                    additionaldmg += dmg * 0.05;
                }
            }
        }
        Enemy currentenemy = enemyList.Find(e => e.NetworkId == enemy.NetworkId);
        int reducedmg = currentenemy.unyielding;
        double newarmor = enemy.Armor * ObjectManager.Player.PercentArmorPenetrationMod;
        double dmgreduction = 100 / (100 + newarmor - ObjectManager.Player.FlatArmorPenetrationMod);
        return (((dmg + additionaldmg) * dmgreduction)) - reducedmg;
    }

    /// <summary>
    /// Calculates the damage into the magic damage using MR, Magicpenetration and Masteries
    /// </summary>
    /// <param name="dmg">The basic damage</param>
    /// <param name="enemy">The enemy hero object</param>
    /// <returns>Returns the magic damage</returns>
    public static double CalcMagicDmg(double dmg, Obj_AI_Hero enemy)
    {
        double additionaldmg = 0;
        if (doubleedgedsword == true)
        {
            if (ObjectManager.Player.CombatType == GameObjectCombatType.Melee)
            {
                additionaldmg = dmg * 0.02;
            }
            else
            {
                additionaldmg = dmg * 0.015;
            }
        }
        if (havoc == true)
        {
            additionaldmg += dmg * 0.03;
        }
        if (executioner > 0)
        {
            if (executioner == 1)
            {
                if ((enemy.Health / enemy.MaxHealth) * 100 < 20)
                {
                    additionaldmg += dmg * 0.05;
                }
            }
            else if (executioner == 2)
            {
                if ((enemy.Health / enemy.MaxHealth) * 100 < 35)
                {
                    additionaldmg += dmg * 0.05;
                }
            }
            else if (executioner == 3)
            {
                if ((enemy.Health / enemy.MaxHealth) * 100 < 50)
                {
                    additionaldmg += dmg * 0.05;
                }
            }
        }
        Enemy currentenemy = enemyList.Find(e => e.NetworkId == enemy.NetworkId);
        int reducedmg = currentenemy.unyielding;
        double newspellblock = enemy.SpellBlock * ObjectManager.Player.PercentMagicPenetrationMod;
        double dmgreduction = 100 / (100 + newspellblock - ObjectManager.Player.FlatMagicPenetrationMod);
        return (((dmg + additionaldmg) * dmgreduction)) - reducedmg;
    }

    /// <summary>
    /// Calculates the damage of a Spell, Auto Attack or Item for an enemy champion.
    /// </summary>
    /// <param name="enemy">The enemy hero object</param>
    /// <param name="type">The type of Spell</param>
    /// <param name="stagetype">The stage of the Spell</param>
    /// <returns>Returns the physical/magic damage</returns>
    public static double getDmg(Obj_AI_Hero enemy, SpellType type, StageType stagetype = StageType.Default)
    {
        switch (type)
        {
            case SpellType.AD:
                if (arcaneblade == false)
                {
                    Enemy currentenemy = enemyList.Find(e => e.NetworkId == enemy.NetworkId);
                    int dmgreduce = currentenemy.block;
                    int reduce2 = 0;
                    double multiplier = 1;
                    double plusdmg = 0;
                    foreach (InventorySlot inv in enemy.InventoryItems)
                    {
                         if ((int)inv.Id == 1054) // Dorans Shield -> Basic attacks -8 dmg
                        {
                            reduce2 += 8;
                        }
                        if ((int)inv.Id == 3047) // Ninja Tabi
                        {
                            multiplier -= 0.095;
                        }
                    }
                    foreach (InventorySlot slot in ObjectManager.Player.InventoryItems)
                    {
                        if ((int)slot.Id == 3153) // BOTRK
                        {
                            plusdmg = enemy.Health * 0.05;
                        }
                    }
                    return CalcPhysicalDmg((ObjectManager.Player.BaseAttackDamage + ObjectManager.Player.FlatPhysicalDamageMod) * multiplier - reduce2 + plusdmg, enemy) - dmgreduce;
                }
                else
                {
                    Enemy currentenemy = enemyList.Find(e => e.NetworkId == enemy.NetworkId);
                    int dmgreduce = currentenemy.block;
                    int reduce2 = 0;
                    double multiplier = 1;
                    double plusdmg = 0;
                    foreach (InventorySlot inv in enemy.InventoryItems)
                    {
                        if ((int)inv.Id == 1054) // Dorans Shield -> Basic attacks -8 dmg
                        {
                            reduce2 += 8;
                        }
                        if ((int)inv.Id == 3047) // Ninja Tabi
                        {
                            multiplier -= 0.095;
                        }
                    }
                    foreach (InventorySlot slot in ObjectManager.Player.InventoryItems)
                    {
                        if ((int)slot.Id == 3153) // BOTRK
                        {
                            plusdmg = enemy.Health * 0.05;
                        }
                    }
                    double bonusmagicdmg = CalcMagicDmg(0.05 * ObjectManager.Player.FlatMagicDamageMod, enemy);
                    return CalcPhysicalDmg((ObjectManager.Player.BaseAttackDamage + ObjectManager.Player.FlatPhysicalDamageMod) * multiplier - reduce2 + plusdmg, enemy) + bonusmagicdmg - dmgreduce;
                }
            case SpellType.IGNITE:
                return (50 + (ObjectManager.Player.Level * 20)) - (enemy.HPRegenRate * 5) / 2;
            case SpellType.HEXGUN:
                return CalcMagicDmg(150 + (0.4 * ObjectManager.Player.FlatMagicDamageMod), enemy);
            case SpellType.DFG:
                return CalcMagicDmg((0.15 * enemy.Health), enemy);
            case SpellType.BOTRK:
                return CalcPhysicalDmg(0.15 * enemy.MaxHealth, enemy);
            case SpellType.BILGEWATER:
                return CalcMagicDmg(100, enemy);
            case SpellType.TIAMAT:
                return CalcPhysicalDmg(ObjectManager.Player.BaseAttackDamage + ObjectManager.Player.FlatPhysicalDamageMod, enemy);
            case SpellType.HYDRA:
                return CalcPhysicalDmg(ObjectManager.Player.BaseAttackDamage + ObjectManager.Player.FlatPhysicalDamageMod, enemy);
            case SpellType.Q:
                if (ObjectManager.Player.Spellbook.GetSpell(SpellSlot.Q).Level > 0)
                {
                    return champ(enemy, type, stagetype);
                }
                else
                {
                    return 0;
                }
            case SpellType.W:
                if (ObjectManager.Player.Spellbook.GetSpell(SpellSlot.W).Level > 0)
                {
                    return champ(enemy, type, stagetype);
                }
                else
                {
                    return 0;
                }
            case SpellType.E:
                if (ObjectManager.Player.Spellbook.GetSpell(SpellSlot.E).Level > 0)
                {
                    return champ(enemy, type, stagetype);
                }
                else
                {
                    return 0;
                }
            case SpellType.R:
                if (ObjectManager.Player.Spellbook.GetSpell(SpellSlot.R).Level > 0)
                {
                    return champ(enemy, type, stagetype);
                }
                else
                {
                    return 0;
                }
            default:
                throw new InvalidSpellTypeException();
        }
    }

    private static double Aatrox(Obj_AI_Hero enemy, SpellType type, StageType stagetype)
    {
        switch (type)
        {
            case SpellType.Q:
                return CalcPhysicalDmg((25 + (ObjectManager.Player.Spellbook.GetSpell(SpellSlot.Q).Level * 45)) + (0.6 * ObjectManager.Player.FlatPhysicalDamageMod), enemy);
            case SpellType.W:
                return CalcPhysicalDmg((25 + (ObjectManager.Player.Spellbook.GetSpell(SpellSlot.W).Level * 35)) + (1.0 * ObjectManager.Player.FlatPhysicalDamageMod), enemy); // 3rd hit Damage
            case SpellType.E:
                return CalcMagicDmg((40 + (ObjectManager.Player.Spellbook.GetSpell(SpellSlot.E).Level * 35)) + (0.6 * ObjectManager.Player.FlatPhysicalDamageMod) + (0.6 * ObjectManager.Player.FlatMagicDamageMod), enemy);
            case SpellType.R:
                return CalcMagicDmg((100 + (ObjectManager.Player.Spellbook.GetSpell(SpellSlot.R).Level * 100)) + (1.0 * ObjectManager.Player.FlatMagicDamageMod), enemy); // magic dmg when casted
            default:
                throw new InvalidSpellTypeException();
        }
    }

    private static double Ahri(Obj_AI_Hero enemy, SpellType type, StageType stagetype)
    {
        switch (type)
        {
            case SpellType.Q:
                switch (stagetype)
                {
                    case StageType.FirstDamage:
                        return CalcMagicDmg((15 + (ObjectManager.Player.Spellbook.GetSpell(SpellSlot.Q).Level * 25)) + (0.325 * ObjectManager.Player.FlatMagicDamageMod), enemy); // way to the enemy
                    case StageType.SecondDamage:
                        return (15 + (ObjectManager.Player.Spellbook.GetSpell(SpellSlot.Q).Level * 25)) + (0.325 * ObjectManager.Player.FlatMagicDamageMod); // way back true dmg
                    case StageType.Default:
                        double waytoenemy = CalcMagicDmg((15 + (ObjectManager.Player.Spellbook.GetSpell(SpellSlot.Q).Level * 25)) + (0.325 * ObjectManager.Player.FlatMagicDamageMod), enemy);
                        double wayback = (15 + (ObjectManager.Player.Spellbook.GetSpell(SpellSlot.Q).Level * 25)) + (0.325 * ObjectManager.Player.FlatMagicDamageMod);
                        return waytoenemy + wayback; // both
                    default:
                        throw new InvalidSpellTypeException();
                }
            case SpellType.W:
                switch (stagetype)
                {
                    case StageType.Default:
                        return CalcMagicDmg((24 + (ObjectManager.Player.Spellbook.GetSpell(SpellSlot.W).Level * 40)) + (0.64 * ObjectManager.Player.FlatMagicDamageMod), enemy); // all 3 stacks on 1 unit
                    case StageType.FirstDamage:
                        return CalcMagicDmg((40 + (ObjectManager.Player.Spellbook.GetSpell(SpellSlot.W).Level * 25)) + (0.4 * ObjectManager.Player.FlatMagicDamageMod), enemy); // 1 w hitting
                    default:
                        throw new InvalidSpellTypeException();
                }
            case SpellType.E:
                return CalcMagicDmg((30 + (ObjectManager.Player.Spellbook.GetSpell(SpellSlot.E).Level * 30)) + (0.35 * ObjectManager.Player.FlatMagicDamageMod), enemy);
            case SpellType.R:
                switch (stagetype)
                {
                    case StageType.FirstDamage:
                        return CalcMagicDmg((30 + (ObjectManager.Player.Spellbook.GetSpell(SpellSlot.R).Level * 40)) + (0.3 * ObjectManager.Player.FlatMagicDamageMod), enemy); // 1 ult 
                    case StageType.Default:
                        return CalcMagicDmg((90 + (ObjectManager.Player.Spellbook.GetSpell(SpellSlot.R).Level * 120)) + (0.9 * ObjectManager.Player.FlatMagicDamageMod), enemy); // max dmg to 1 unit
                    default:
                        throw new InvalidSpellTypeException();
                }
            default:
                throw new InvalidSpellTypeException();
        }
    }

    private static double Akali(Obj_AI_Hero enemy, SpellType type, StageType stagetype)
    {
        switch (type)
        {
            case SpellType.Q:
                switch (stagetype)
                {
                    case StageType.FirstDamage:
                        return CalcMagicDmg((15 + (ObjectManager.Player.Spellbook.GetSpell(SpellSlot.Q).Level * 20)) + (0.4 * ObjectManager.Player.FlatMagicDamageMod), enemy); // q throw
                    case StageType.Default:
                        return CalcMagicDmg((20 + (ObjectManager.Player.Spellbook.GetSpell(SpellSlot.Q).Level * 25)) + (0.5 * ObjectManager.Player.FlatMagicDamageMod), enemy); // q throw + hitted with something
                    default:
                        throw new InvalidSpellTypeException();
                }
            case SpellType.W:
                throw new InvalidSpellTypeException();
            case SpellType.E:
                return CalcPhysicalDmg((5 + (ObjectManager.Player.Spellbook.GetSpell(SpellSlot.E).Level * 25)) + (0.6 * (ObjectManager.Player.FlatPhysicalDamageMod + ObjectManager.Player.BaseAttackDamage)) + (0.3 * ObjectManager.Player.FlatMagicDamageMod), enemy);
            case SpellType.R:
                return CalcMagicDmg((25 + (ObjectManager.Player.Spellbook.GetSpell(SpellSlot.R).Level * 75)) + (0.5 * ObjectManager.Player.FlatMagicDamageMod), enemy);
            default:
                throw new InvalidSpellTypeException();
        }
    }

    private static double Alistar(Obj_AI_Hero enemy, SpellType type, StageType stagetype)
    {
        switch (type)
        {
            case SpellType.Q:
                return CalcMagicDmg((15 + (ObjectManager.Player.Spellbook.GetSpell(SpellSlot.Q).Level * 45)) + (0.5 * ObjectManager.Player.FlatMagicDamageMod), enemy);
            case SpellType.W:
                return CalcMagicDmg((0 + (ObjectManager.Player.Spellbook.GetSpell(SpellSlot.W).Level * 55)) + (0.7 * ObjectManager.Player.FlatMagicDamageMod), enemy);
            case SpellType.E:
                throw new InvalidSpellTypeException();
            case SpellType.R:
                throw new InvalidSpellTypeException();
            default:
                throw new InvalidSpellTypeException();
        }
    }

    private static double Amumu(Obj_AI_Hero enemy, SpellType type, StageType stagetype)
    {
        switch (type)
        {
            case SpellType.Q:
                return CalcMagicDmg((30 + (ObjectManager.Player.Spellbook.GetSpell(SpellSlot.Q).Level * 50)) + (0.7 * ObjectManager.Player.FlatMagicDamageMod), enemy);
            case SpellType.W:
                double basedmg = CalcMagicDmg((4 + (ObjectManager.Player.Spellbook.GetSpell(SpellSlot.W).Level * 4)), enemy);
                double percentofmaxhealth = (1.2 + (ObjectManager.Player.Spellbook.GetSpell(SpellSlot.W).Level * 0.3));
                double additionalpercentper100ap = 0;
                if (ObjectManager.Player.FlatMagicDamageMod < 100)
                {
                    additionalpercentper100ap = 0;
                }
                else if (ObjectManager.Player.FlatMagicDamageMod.IsBetween(100, 199))
                {
                    additionalpercentper100ap = 1;
                }
                else if (ObjectManager.Player.FlatMagicDamageMod.IsBetween(200, 299))
                {
                    additionalpercentper100ap = 2;
                }
                else if (ObjectManager.Player.FlatMagicDamageMod.IsBetween(300, 399))
                {
                    additionalpercentper100ap = 3;
                }
                else if (ObjectManager.Player.FlatMagicDamageMod.IsBetween(400, 499))
                {
                    additionalpercentper100ap = 4;
                }
                else if (ObjectManager.Player.FlatMagicDamageMod.IsBetween(500, 599))
                {
                    additionalpercentper100ap = 5;
                }
                else if (ObjectManager.Player.FlatMagicDamageMod.IsBetween(600, 699))
                {
                    additionalpercentper100ap = 6;
                }
                else if (ObjectManager.Player.FlatMagicDamageMod.IsBetween(700, 799))
                {
                    additionalpercentper100ap = 7;
                }
                else if (ObjectManager.Player.FlatMagicDamageMod.IsBetween(800, 899))
                {
                    additionalpercentper100ap = 8;
                }
                else if (ObjectManager.Player.FlatMagicDamageMod >= 900)
                {
                    additionalpercentper100ap = 9;
                }
                double healthbase = enemy.MaxHealth / 100 * (percentofmaxhealth + additionalpercentper100ap);
                return basedmg + CalcMagicDmg(healthbase, enemy);
            case SpellType.E:
                return CalcMagicDmg((50 + (ObjectManager.Player.Spellbook.GetSpell(SpellSlot.E).Level * 25)) + (0.5 * ObjectManager.Player.FlatMagicDamageMod), enemy);
            case SpellType.R:
                return CalcMagicDmg((50 + (ObjectManager.Player.Spellbook.GetSpell(SpellSlot.R).Level * 100)) + (0.8 * ObjectManager.Player.FlatMagicDamageMod), enemy);
            default:
                throw new InvalidSpellTypeException();
        }
    }

    private static double Anivia(Obj_AI_Hero enemy, SpellType type, StageType stagetype)
    {
        switch (type)
        {
            case SpellType.Q:
                switch (stagetype)
                {
                    case StageType.Default:
                        return CalcMagicDmg((60 + (ObjectManager.Player.Spellbook.GetSpell(SpellSlot.Q).Level * 60)) + (1.0 * ObjectManager.Player.FlatMagicDamageMod), enemy); // when stunned (both of dmg)
                    case StageType.FirstDamage:
                        return CalcMagicDmg((30 + (ObjectManager.Player.Spellbook.GetSpell(SpellSlot.Q).Level * 30)) + (0.5 * ObjectManager.Player.FlatMagicDamageMod), enemy); // when going through
                    default:
                        throw new InvalidSpellTypeException();
                }
            case SpellType.W:
                throw new InvalidSpellTypeException();
            case SpellType.E:
                switch (stagetype)
                {
                    case StageType.Default:
                        return CalcMagicDmg((50 + (ObjectManager.Player.Spellbook.GetSpell(SpellSlot.E).Level * 60)) + (1.0 * ObjectManager.Player.FlatMagicDamageMod), enemy); // when "Chilled"
                    case StageType.FirstDamage:
                        return CalcMagicDmg((25 + (ObjectManager.Player.Spellbook.GetSpell(SpellSlot.E).Level * 30)) + (0.5 * ObjectManager.Player.FlatMagicDamageMod), enemy); // basic dmg
                    default:
                        throw new InvalidSpellTypeException();
                }
            case SpellType.R:
                return CalcMagicDmg((40 + (ObjectManager.Player.Spellbook.GetSpell(SpellSlot.R).Level * 40)) + (0.25 * ObjectManager.Player.FlatMagicDamageMod), enemy); // per tick
            default:
                throw new InvalidSpellTypeException();
        }
    }

    private static double Annie(Obj_AI_Hero enemy, SpellType type, StageType stagetype)
    {
        switch (type)
        {
            case SpellType.Q:
                return CalcMagicDmg((45 + (ObjectManager.Player.Spellbook.GetSpell(SpellSlot.Q).Level * 35)) + (0.8 * ObjectManager.Player.FlatMagicDamageMod), enemy);
            case SpellType.W:
                return CalcMagicDmg((25 + (ObjectManager.Player.Spellbook.GetSpell(SpellSlot.W).Level * 45)) + (0.85 * ObjectManager.Player.FlatMagicDamageMod), enemy);
            case SpellType.E:
                return CalcMagicDmg((10 + (ObjectManager.Player.Spellbook.GetSpell(SpellSlot.E).Level * 10)) + (0.2 * ObjectManager.Player.FlatMagicDamageMod), enemy);
            case SpellType.R:
                switch (stagetype)
                {
                    case StageType.Default:
                        return CalcMagicDmg((85 + (ObjectManager.Player.Spellbook.GetSpell(SpellSlot.R).Level * 125)) + (1.0 * ObjectManager.Player.FlatMagicDamageMod), enemy); // max damage with first tick of tibbers sunfire
                    case StageType.FirstDamage:
                        return CalcMagicDmg((50 + (ObjectManager.Player.Spellbook.GetSpell(SpellSlot.R).Level * 125)) + (0.8 * ObjectManager.Player.FlatMagicDamageMod), enemy); // basic ult summoner dmg
                    case StageType.SecondDamage:
                        return CalcMagicDmg(35 + (0.2 * ObjectManager.Player.FlatMagicDamageMod), enemy); // per tick of tibbers sunfire
                    default:
                        throw new InvalidSpellTypeException();
                }
            default:
                throw new InvalidSpellTypeException();
        }
    }

    private static double Ashe(Obj_AI_Hero enemy, SpellType type, StageType stagetype)
    {
        switch (type)
        {
            case SpellType.Q:
                throw new InvalidSpellTypeException();
            case SpellType.W:
                return CalcPhysicalDmg((30 + (ObjectManager.Player.Spellbook.GetSpell(SpellSlot.W).Level * 10)) + (ObjectManager.Player.FlatPhysicalDamageMod + ObjectManager.Player.BaseAttackDamage), enemy);
            case SpellType.E:
                throw new InvalidSpellTypeException();
            case SpellType.R:
                switch (stagetype)
                {
                    case StageType.Default:
                        return CalcMagicDmg((75 + (ObjectManager.Player.Spellbook.GetSpell(SpellSlot.R).Level * 175)) + (1.0 * ObjectManager.Player.FlatMagicDamageMod), enemy);
                    case StageType.FirstDamage:
                        return CalcMagicDmg((37.5 + (ObjectManager.Player.Spellbook.GetSpell(SpellSlot.R).Level * 87.5)) + (0.5 * ObjectManager.Player.FlatMagicDamageMod), enemy); // dmg around the explode radius
                    default:
                        throw new InvalidSpellTypeException();
                }
            default:
                throw new InvalidSpellTypeException();
        }
    }

    private static double Blitzcrank(Obj_AI_Hero enemy, SpellType type, StageType stagetype)
    {
        switch (type)
        {
            case SpellType.Q:
                return CalcMagicDmg((25 + (ObjectManager.Player.Spellbook.GetSpell(SpellSlot.Q).Level * 55)) + (1.0 * ObjectManager.Player.FlatMagicDamageMod), enemy);
            case SpellType.W:
                throw new InvalidSpellTypeException();
            case SpellType.E:
                return CalcPhysicalDmg((ObjectManager.Player.BaseAttackDamage + ObjectManager.Player.FlatPhysicalDamageMod), enemy); // only the additional dmg
            case SpellType.R:
                switch (stagetype)
                {
                    case StageType.Default:
                        return CalcMagicDmg((125 + (ObjectManager.Player.Spellbook.GetSpell(SpellSlot.R).Level * 125)) + (1.0 * ObjectManager.Player.FlatMagicDamageMod), enemy);
                    case StageType.FirstDamage:
                        return CalcMagicDmg((0 + (ObjectManager.Player.Spellbook.GetSpell(SpellSlot.R).Level * 100)) + (0.2 * ObjectManager.Player.FlatMagicDamageMod), enemy); // passive dmg
                    default:
                        throw new InvalidSpellTypeException();
                }
            default:
                throw new InvalidSpellTypeException();
        }
    }

    private static double Brand(Obj_AI_Hero enemy, SpellType type, StageType stagetype)
    {
        switch (type)
        {
            case SpellType.Q:
                return CalcMagicDmg((40 + (ObjectManager.Player.Spellbook.GetSpell(SpellSlot.Q).Level * 40)) + (0.65 * ObjectManager.Player.FlatMagicDamageMod), enemy);
            case SpellType.W:
                switch (stagetype)
                {
                    case StageType.Default:
                        return CalcMagicDmg((30 + (ObjectManager.Player.Spellbook.GetSpell(SpellSlot.W).Level * 45)) + (0.6 * ObjectManager.Player.FlatMagicDamageMod), enemy);
                    case StageType.FirstDamage:
                        return CalcMagicDmg((37.5 + (ObjectManager.Player.Spellbook.GetSpell(SpellSlot.W).Level * 56.25)) + (0.75 * ObjectManager.Player.FlatMagicDamageMod), enemy); // blazed dmg
                    default:
                        throw new InvalidSpellTypeException();
                }
            case SpellType.E:
                return CalcMagicDmg((35 + (ObjectManager.Player.Spellbook.GetSpell(SpellSlot.E).Level * 35)) + (0.55 * ObjectManager.Player.FlatMagicDamageMod), enemy);
            case SpellType.R:
                switch (stagetype)
                {
                    case StageType.Default:
                        return CalcMagicDmg((150 + (ObjectManager.Player.Spellbook.GetSpell(SpellSlot.R).Level * 300)) + (1.5 * ObjectManager.Player.FlatMagicDamageMod), enemy); // Max possible dmg to one unit
                    case StageType.FirstDamage:
                        return CalcMagicDmg((50 + (ObjectManager.Player.Spellbook.GetSpell(SpellSlot.R).Level * 100)) + (0.5 * ObjectManager.Player.FlatMagicDamageMod), enemy); // damage per bounce
                    default:
                        throw new InvalidSpellTypeException();
                }
            default:
                throw new InvalidSpellTypeException();
        }
    }

    private static double Caitlyn(Obj_AI_Hero enemy, SpellType type, StageType stagetype)
    {
        switch (type)
        {
            case SpellType.Q:
                switch (stagetype)
                {
                    case StageType.Default:
                        return CalcPhysicalDmg((-20 + (ObjectManager.Player.Spellbook.GetSpell(SpellSlot.W).Level * 40)) + (1.3 * (ObjectManager.Player.FlatPhysicalDamageMod + ObjectManager.Player.BaseAttackDamage)), enemy); // first hit dmg
                    case StageType.FirstDamage:
                        return CalcPhysicalDmg((-10 + (ObjectManager.Player.Spellbook.GetSpell(SpellSlot.W).Level * 20)) + (0.65 * (ObjectManager.Player.FlatPhysicalDamageMod + ObjectManager.Player.BaseAttackDamage)), enemy); // min damage
                    default:
                        throw new InvalidSpellTypeException();
                }
            case SpellType.W:
                return CalcMagicDmg((30 + (ObjectManager.Player.Spellbook.GetSpell(SpellSlot.W).Level * 50)) + (0.6 * ObjectManager.Player.FlatMagicDamageMod), enemy);
            case SpellType.E:
                return CalcMagicDmg((30 + (ObjectManager.Player.Spellbook.GetSpell(SpellSlot.E).Level * 50)) + (0.8 * (ObjectManager.Player.FlatMagicDamageMod)), enemy);
            case SpellType.R:
                return CalcPhysicalDmg((25 + (ObjectManager.Player.Spellbook.GetSpell(SpellSlot.R).Level * 225)) + (2.0 * ObjectManager.Player.FlatPhysicalDamageMod), enemy);
            default:
                throw new InvalidSpellTypeException();
        }
    }

    private static double Cassiopeia(Obj_AI_Hero enemy, SpellType type, StageType stagetype)
    {
        switch (type)
        {
            case SpellType.Q:
                switch (stagetype)
                {
                    case StageType.FirstDamage:
                        return CalcMagicDmg((12 + (ObjectManager.Player.Spellbook.GetSpell(SpellSlot.Q).Level * 13)) + (0.2666 * ObjectManager.Player.FlatMagicDamageMod), enemy); // first sec
                    case StageType.SecondDamage:
                        return CalcMagicDmg((24 + (ObjectManager.Player.Spellbook.GetSpell(SpellSlot.Q).Level * 26)) + (0.5333 * ObjectManager.Player.FlatMagicDamageMod), enemy); // second sec
                    case StageType.Default:
                        return CalcMagicDmg((35 + (ObjectManager.Player.Spellbook.GetSpell(SpellSlot.Q).Level * 40)) + (0.8 * ObjectManager.Player.FlatMagicDamageMod), enemy); // all dmg
                    case StageType.ThirdDamage:
                        return CalcMagicDmg((35 + (ObjectManager.Player.Spellbook.GetSpell(SpellSlot.Q).Level * 40)) + (0.8 * ObjectManager.Player.FlatMagicDamageMod), enemy); // 3 hits -> all dmg
                    default:
                        throw new InvalidSpellTypeException();
                }
            case SpellType.W:
                switch (stagetype)
                {
                    case StageType.Default:
                        return CalcMagicDmg((135 + (ObjectManager.Player.Spellbook.GetSpell(SpellSlot.W).Level * 90)) + (1.35 * ObjectManager.Player.FlatMagicDamageMod), enemy); // complete w dmg
                    case StageType.FirstDamage:
                        return CalcMagicDmg((15 + (ObjectManager.Player.Spellbook.GetSpell(SpellSlot.W).Level * 10)) + (0.15 * ObjectManager.Player.FlatMagicDamageMod), enemy); // per second
                    default:
                        throw new InvalidSpellTypeException();
                }
            case SpellType.E:
                return CalcMagicDmg((15 + (ObjectManager.Player.Spellbook.GetSpell(SpellSlot.E).Level * 35)) + (0.55 * ObjectManager.Player.FlatMagicDamageMod), enemy);
            case SpellType.R:
                return CalcMagicDmg((75 + (ObjectManager.Player.Spellbook.GetSpell(SpellSlot.R).Level * 125)) + (0.6 * ObjectManager.Player.FlatMagicDamageMod), enemy);
            default:
                throw new InvalidSpellTypeException();
        }
    }

    private static double ChoGath(Obj_AI_Hero enemy, SpellType type, StageType stagetype)
    {
        switch (type)
        {
            case SpellType.Q:
                return CalcMagicDmg((25 + (ObjectManager.Player.Spellbook.GetSpell(SpellSlot.Q).Level * 55)) + (1.0 * ObjectManager.Player.FlatMagicDamageMod), enemy);
            case SpellType.W:
                return CalcMagicDmg((25 + (ObjectManager.Player.Spellbook.GetSpell(SpellSlot.W).Level * 50)) + (0.7 * ObjectManager.Player.FlatMagicDamageMod), enemy);
            case SpellType.E:
                return CalcMagicDmg((5 + (ObjectManager.Player.Spellbook.GetSpell(SpellSlot.E).Level * 15)) + (0.3 * ObjectManager.Player.FlatMagicDamageMod), enemy);
            case SpellType.R:
                return (125 + (ObjectManager.Player.Spellbook.GetSpell(SpellSlot.R).Level * 175));
            default:
                throw new InvalidSpellTypeException();
        }
    }

    private static double Corki(Obj_AI_Hero enemy, SpellType type, StageType stagetype)
    {
        switch (type)
        {
            case SpellType.Q:
                return CalcMagicDmg((30 + (ObjectManager.Player.Spellbook.GetSpell(SpellSlot.Q).Level * 50)) + (0.5 * ObjectManager.Player.FlatMagicDamageMod) + (0.5 * ObjectManager.Player.FlatPhysicalDamageMod), enemy);
            case SpellType.W:
                switch (stagetype)
                {
                    case StageType.Default:
                        return CalcMagicDmg((75 + (ObjectManager.Player.Spellbook.GetSpell(SpellSlot.W).Level * 75)) + (1.0 * ObjectManager.Player.FlatMagicDamageMod), enemy); // dmg complete
                    case StageType.FirstDamage:
                        return CalcMagicDmg((30 + (ObjectManager.Player.Spellbook.GetSpell(SpellSlot.W).Level * 30)) + (0.4 * ObjectManager.Player.FlatMagicDamageMod), enemy); // per second dmg
                    default:
                        throw new InvalidSpellTypeException();
                }
            case SpellType.E:
                switch (stagetype)
                {
                    case StageType.Default:
                        return CalcPhysicalDmg((32 + (ObjectManager.Player.Spellbook.GetSpell(SpellSlot.E).Level * 48)) + (1.6 * ObjectManager.Player.FlatPhysicalDamageMod), enemy); // dmg complete
                    case StageType.FirstDamage:
                        return CalcPhysicalDmg((8 + (ObjectManager.Player.Spellbook.GetSpell(SpellSlot.E).Level * 12)) + (0.4 * ObjectManager.Player.FlatPhysicalDamageMod), enemy); // per sec
                    default:
                        throw new InvalidSpellTypeException();
                }
            case SpellType.R:
                switch (stagetype)
                {
                    case StageType.Default:
                        return CalcMagicDmg((20 + (ObjectManager.Player.Spellbook.GetSpell(SpellSlot.R).Level * 80)) + (0.3 * ObjectManager.Player.FlatMagicDamageMod) + ((0.1 + (ObjectManager.Player.Spellbook.GetSpell(SpellSlot.R).Level * 0.1)) * ObjectManager.Player.FlatPhysicalDamageMod), enemy); // normal missile
                    case StageType.FirstDamage:
                        return CalcMagicDmg((30 + (ObjectManager.Player.Spellbook.GetSpell(SpellSlot.R).Level * 120)) + (0.45 * ObjectManager.Player.FlatMagicDamageMod) + ((0.15 + (ObjectManager.Player.Spellbook.GetSpell(SpellSlot.R).Level * 0.15)) * ObjectManager.Player.FlatPhysicalDamageMod), enemy); // every 4th
                    default:
                        throw new InvalidSpellTypeException();
                }
            default:
                throw new InvalidSpellTypeException();
        }
    }

    private static double Darius(Obj_AI_Hero enemy, SpellType type, StageType stagetype)
    {
        switch (type)
        {
            case SpellType.Q:
                switch (stagetype)
                {
                    case StageType.Default:
                        return CalcPhysicalDmg((52.5 + (ObjectManager.Player.Spellbook.GetSpell(SpellSlot.Q).Level * 52.5)) + (1.05 * ObjectManager.Player.FlatPhysicalDamageMod), enemy); // max damage (outer half)
                    case StageType.FirstDamage:
                        return CalcPhysicalDmg((35 + (ObjectManager.Player.Spellbook.GetSpell(SpellSlot.Q).Level * 35)) + (0.7 * ObjectManager.Player.FlatPhysicalDamageMod), enemy); // inner half
                    default:
                        throw new InvalidSpellTypeException();
                }
            case SpellType.W:
                //double basicattack = CalcPhysicalDmg(ObjectManager.Player.FlatPhysicalDamageMod + ObjectManager.Player.BaseAttackDamage, enemy);
                double bonusdmg = CalcPhysicalDmg(0.2 * ObjectManager.Player.Spellbook.GetSpell(SpellSlot.W).Level, enemy); // only the bonus dmg
                //return basicattack + bonusdmg;
                return bonusdmg;
            case SpellType.E:
                throw new InvalidSpellTypeException();
            case SpellType.R:
                switch (stagetype)
                {
                    case StageType.Default:
                        return ((140 + (180 * ObjectManager.Player.Spellbook.GetSpell(SpellSlot.R).Level)) * (1.5 * ObjectManager.Player.FlatPhysicalDamageMod)); // at 5 stacks
                    case StageType.FirstDamage:
                        return ((70 + (90 * ObjectManager.Player.Spellbook.GetSpell(SpellSlot.R).Level)) * (0.75 * ObjectManager.Player.FlatPhysicalDamageMod)); // foreach stack
                    default:
                        throw new InvalidSpellTypeException();
                }
            default:
                throw new InvalidSpellTypeException();
        }
    }

    private static double Diana(Obj_AI_Hero enemy, SpellType type, StageType stagetype)
    {
        switch (type)
        {
            case SpellType.Q:
                return CalcMagicDmg((25 + (ObjectManager.Player.Spellbook.GetSpell(SpellSlot.Q).Level * 35)) + (0.7 * ObjectManager.Player.FlatMagicDamageMod), enemy);
            case SpellType.W:
                switch (stagetype)
                {
                    case StageType.Default:
                        return CalcMagicDmg((30 + (ObjectManager.Player.Spellbook.GetSpell(SpellSlot.W).Level * 36)) + (0.6 * ObjectManager.Player.FlatMagicDamageMod), enemy); // all on one target
                    case StageType.FirstDamage:
                        return CalcMagicDmg((10 + (ObjectManager.Player.Spellbook.GetSpell(SpellSlot.W).Level * 12)) + (0.2 * ObjectManager.Player.FlatMagicDamageMod), enemy); // single orb
                    default:
                        throw new InvalidSpellTypeException();
                }
            case SpellType.E:
                throw new InvalidSpellTypeException();
            case SpellType.R:
                return CalcMagicDmg((40 + (ObjectManager.Player.Spellbook.GetSpell(SpellSlot.R).Level * 60)) + (0.6 * ObjectManager.Player.FlatMagicDamageMod), enemy);
            default:
                throw new InvalidSpellTypeException();
        }
    }

    private static double DrMundo(Obj_AI_Hero enemy, SpellType type, StageType stagetype)
    {
        switch (type)
        {
            case SpellType.Q:
                double tmpdmg = CalcMagicDmg((enemy.Health / 100) * (12 + (3 * ObjectManager.Player.Spellbook.GetSpell(SpellSlot.Q).Level)), enemy);
                double mindmg = CalcMagicDmg(30 + (50 * ObjectManager.Player.Spellbook.GetSpell(SpellSlot.Q).Level), enemy);
                if (tmpdmg > mindmg)
                {
                    return tmpdmg;
                }
                else
                {
                    return mindmg;
                }
            case SpellType.W:
                return CalcMagicDmg((20 + (ObjectManager.Player.Spellbook.GetSpell(SpellSlot.W).Level * 15)) + (0.2 * ObjectManager.Player.FlatMagicDamageMod), enemy);
            case SpellType.E:
                throw new InvalidSpellTypeException();
            case SpellType.R:
                throw new InvalidSpellTypeException();
            default:
                throw new InvalidSpellTypeException();
        }
    }

    private static double Draven(Obj_AI_Hero enemy, SpellType type, StageType stagetype)
    {
        switch (type)
        {
            case SpellType.Q:
                //double baseattack = CalcPhysicalDmg(ObjectManager.Player.BaseAttackDamage + ObjectManager.Player.FlatPhysicalDamageMod, enemy);
                double bonusdmg = CalcPhysicalDmg((0.35 + (ObjectManager.Player.Spellbook.GetSpell(SpellSlot.Q).Level * 0.1)) * (ObjectManager.Player.BaseAttackDamage + ObjectManager.Player.FlatPhysicalDamageMod), enemy);
                //return baseattack + bonusdmg;
                return bonusdmg; // only the bonus dmg
            case SpellType.W:
                throw new InvalidSpellTypeException();
            case SpellType.E:
                return CalcPhysicalDmg((35 + (ObjectManager.Player.Spellbook.GetSpell(SpellSlot.E).Level * 35)) + (0.5 * (ObjectManager.Player.FlatPhysicalDamageMod)), enemy);
            case SpellType.R:
                switch (stagetype)
                {
                    case StageType.Default:
                        return CalcPhysicalDmg((150 + (ObjectManager.Player.Spellbook.GetSpell(SpellSlot.R).Level * 200)) + (2.2 * ObjectManager.Player.FlatPhysicalDamageMod), enemy); // both hit
                    case StageType.FirstDamage:
                        return CalcPhysicalDmg((75 + (ObjectManager.Player.Spellbook.GetSpell(SpellSlot.R).Level * 100)) + (1.1 * ObjectManager.Player.FlatPhysicalDamageMod), enemy); // way to enemy
                    case StageType.SecondDamage:
                        return CalcPhysicalDmg((75 + (ObjectManager.Player.Spellbook.GetSpell(SpellSlot.R).Level * 100)) + (1.1 * ObjectManager.Player.FlatPhysicalDamageMod), enemy); // way back
                    case StageType.ThirdDamage:
                        return CalcPhysicalDmg((30 + (ObjectManager.Player.Spellbook.GetSpell(SpellSlot.R).Level * 40)) + (0.44 * ObjectManager.Player.FlatPhysicalDamageMod), enemy); // minimum damage 1 hit
                    case StageType.FourthDamage:
                        return CalcPhysicalDmg((60 + (ObjectManager.Player.Spellbook.GetSpell(SpellSlot.R).Level * 80)) + (0.88 * ObjectManager.Player.FlatPhysicalDamageMod), enemy); // minimum damage 2 hits
                    default:
                        throw new InvalidSpellTypeException();
                }
            default:
                throw new InvalidSpellTypeException();
        }
    }

    private static double Elise(Obj_AI_Hero enemy, SpellType type, StageType stagetype)
    {
        switch (type)
        {
            case SpellType.Q:
                if (ObjectManager.Player.Spellbook.GetSpell(SpellSlot.Q).Name == "EliseHumanQ")
                {
                    double basedmg = CalcMagicDmg((5 + (ObjectManager.Player.Spellbook.GetSpell(SpellSlot.Q).Level * 35)), enemy);
                    double percentofcurrenthealth = 8;
                    double additionalpercentper100ap = 0;
                    if (ObjectManager.Player.FlatMagicDamageMod < 100)
                    {
                        additionalpercentper100ap = 0;
                    }
                    else if (ObjectManager.Player.FlatMagicDamageMod.IsBetween(100, 199))
                    {
                        additionalpercentper100ap = 3;
                    }
                    else if (ObjectManager.Player.FlatMagicDamageMod.IsBetween(200, 299))
                    {
                        additionalpercentper100ap = 6;
                    }
                    else if (ObjectManager.Player.FlatMagicDamageMod.IsBetween(300, 399))
                    {
                        additionalpercentper100ap = 9;
                    }
                    else if (ObjectManager.Player.FlatMagicDamageMod.IsBetween(400, 499))
                    {
                        additionalpercentper100ap = 12;
                    }
                    else if (ObjectManager.Player.FlatMagicDamageMod.IsBetween(500, 599))
                    {
                        additionalpercentper100ap = 15;
                    }
                    else if (ObjectManager.Player.FlatMagicDamageMod.IsBetween(600, 699))
                    {
                        additionalpercentper100ap = 18;
                    }
                    else if (ObjectManager.Player.FlatMagicDamageMod.IsBetween(700, 799))
                    {
                        additionalpercentper100ap = 21;
                    }
                    else if (ObjectManager.Player.FlatMagicDamageMod.IsBetween(800, 899))
                    {
                        additionalpercentper100ap = 24;
                    }
                    else if (ObjectManager.Player.FlatMagicDamageMod >= 900)
                    {
                        additionalpercentper100ap = 27;
                    }
                    double healthbase = enemy.Health / 100 * (percentofcurrenthealth + additionalpercentper100ap);
                    return basedmg + CalcMagicDmg(healthbase, enemy);
                }
                else
                { // Spider Q
                    double basedmg = CalcMagicDmg((20 + (ObjectManager.Player.Spellbook.GetSpell(SpellSlot.Q).Level * 40)), enemy);
                    double percentofcurrenthealth = 8;
                    double additionalpercentper100ap = 0;
                    if (ObjectManager.Player.FlatMagicDamageMod < 100)
                    {
                        additionalpercentper100ap = 0;
                    }
                    else if (ObjectManager.Player.FlatMagicDamageMod.IsBetween(100, 199))
                    {
                        additionalpercentper100ap = 3;
                    }
                    else if (ObjectManager.Player.FlatMagicDamageMod.IsBetween(200, 299))
                    {
                        additionalpercentper100ap = 6;
                    }
                    else if (ObjectManager.Player.FlatMagicDamageMod.IsBetween(300, 399))
                    {
                        additionalpercentper100ap = 9;
                    }
                    else if (ObjectManager.Player.FlatMagicDamageMod.IsBetween(400, 499))
                    {
                        additionalpercentper100ap = 12;
                    }
                    else if (ObjectManager.Player.FlatMagicDamageMod.IsBetween(500, 599))
                    {
                        additionalpercentper100ap = 15;
                    }
                    else if (ObjectManager.Player.FlatMagicDamageMod.IsBetween(600, 699))
                    {
                        additionalpercentper100ap = 18;
                    }
                    else if (ObjectManager.Player.FlatMagicDamageMod.IsBetween(700, 799))
                    {
                        additionalpercentper100ap = 21;
                    }
                    else if (ObjectManager.Player.FlatMagicDamageMod.IsBetween(800, 899))
                    {
                        additionalpercentper100ap = 24;
                    }
                    else if (ObjectManager.Player.FlatMagicDamageMod >= 900)
                    {
                        additionalpercentper100ap = 27;
                    }
                    double healthbase = (enemy.MaxHealth - enemy.Health) / 100 * (percentofcurrenthealth + additionalpercentper100ap); // of missing health
                    return basedmg + CalcMagicDmg(healthbase, enemy);
                }
            case SpellType.W:
                if (ObjectManager.Player.Spellbook.GetSpell(SpellSlot.Q).Name == "EliseHumanW")
                {
                    return CalcMagicDmg((25 + (ObjectManager.Player.Spellbook.GetSpell(SpellSlot.W).Level * 50)) + (0.8 * ObjectManager.Player.FlatMagicDamageMod), enemy);
                }
                else
                {
                    throw new InvalidSpellTypeException();
                }
            case SpellType.E:
                throw new InvalidSpellTypeException();
            case SpellType.R:
                throw new InvalidSpellTypeException(); // switchting to spider / human
            default:
                throw new InvalidSpellTypeException();
        }
    }

    private static double Evelynn(Obj_AI_Hero enemy, SpellType type, StageType stagetype)
    {
        switch (type)
        {
            case SpellType.Q:
                return CalcMagicDmg((20 + (ObjectManager.Player.Spellbook.GetSpell(SpellSlot.Q).Level * 20)) + (0.45 * ObjectManager.Player.FlatMagicDamageMod) + (0.5 * ObjectManager.Player.FlatPhysicalDamageMod), enemy);
            case SpellType.W:
                throw new InvalidSpellTypeException();
            case SpellType.E:
                return CalcPhysicalDmg((30 + (ObjectManager.Player.Spellbook.GetSpell(SpellSlot.E).Level * 40)) + (1.0 * ObjectManager.Player.FlatMagicDamageMod) + (1.0 * ObjectManager.Player.FlatPhysicalDamageMod), enemy);
            case SpellType.R:
                double percentage = 15 + (5 * ObjectManager.Player.Spellbook.GetSpell(SpellSlot.R).Level);
                double additionalpercentper100ap = 0;
                if (ObjectManager.Player.FlatMagicDamageMod < 100)
                {
                    additionalpercentper100ap = 0;
                }
                else if (ObjectManager.Player.FlatMagicDamageMod.IsBetween(100, 199))
                {
                    additionalpercentper100ap = 1;
                }
                else if (ObjectManager.Player.FlatMagicDamageMod.IsBetween(200, 299))
                {
                    additionalpercentper100ap = 2;
                }
                else if (ObjectManager.Player.FlatMagicDamageMod.IsBetween(300, 399))
                {
                    additionalpercentper100ap = 3;
                }
                else if (ObjectManager.Player.FlatMagicDamageMod.IsBetween(400, 499))
                {
                    additionalpercentper100ap = 4;
                }
                else if (ObjectManager.Player.FlatMagicDamageMod.IsBetween(500, 599))
                {
                    additionalpercentper100ap = 5;
                }
                else if (ObjectManager.Player.FlatMagicDamageMod.IsBetween(600, 699))
                {
                    additionalpercentper100ap = 6;
                }
                else if (ObjectManager.Player.FlatMagicDamageMod.IsBetween(700, 799))
                {
                    additionalpercentper100ap = 7;
                }
                else if (ObjectManager.Player.FlatMagicDamageMod.IsBetween(800, 899))
                {
                    additionalpercentper100ap = 8;
                }
                else if (ObjectManager.Player.FlatMagicDamageMod >= 900)
                {
                    additionalpercentper100ap = 9;
                }
                double healthbase = enemy.MaxHealth / 100 * (percentage + additionalpercentper100ap);
                return CalcMagicDmg(healthbase, enemy);
            default:
                throw new InvalidSpellTypeException();
        }
    }

    private static double Ezreal(Obj_AI_Hero enemy, SpellType type, StageType stagetype)
    {
        switch (type)
        {
            case SpellType.Q:
                return CalcPhysicalDmg((15 + (ObjectManager.Player.Spellbook.GetSpell(SpellSlot.Q).Level * 20)) + (1.0 * (ObjectManager.Player.BaseAttackDamage + ObjectManager.Player.FlatPhysicalDamageMod)) + (0.4 * ObjectManager.Player.FlatMagicDamageMod), enemy);
            case SpellType.W:
                return CalcMagicDmg((25 + (ObjectManager.Player.Spellbook.GetSpell(SpellSlot.W).Level * 45)) + (0.8 * (ObjectManager.Player.FlatMagicDamageMod)), enemy);
            case SpellType.E:
                return CalcMagicDmg((25 + (ObjectManager.Player.Spellbook.GetSpell(SpellSlot.E).Level * 50)) + (0.75 * (ObjectManager.Player.FlatMagicDamageMod)), enemy);
            case SpellType.R:
                switch (stagetype)
                {
                    case StageType.Default:
                        return CalcMagicDmg((200 + (ObjectManager.Player.Spellbook.GetSpell(SpellSlot.R).Level * 150)) + (1.0 * (ObjectManager.Player.FlatPhysicalDamageMod + ObjectManager.Player.BaseAttackDamage)) + (0.9 * ObjectManager.Player.FlatMagicDamageMod), enemy); // basic dmg
                    case StageType.FirstDamage:
                        return CalcMagicDmg((60 + (ObjectManager.Player.Spellbook.GetSpell(SpellSlot.R).Level * 45)) + (0.3 * (ObjectManager.Player.FlatPhysicalDamageMod + ObjectManager.Player.BaseAttackDamage)) + (0.27 * ObjectManager.Player.FlatMagicDamageMod), enemy); // minimum damage after multiple targets were hitted
                    default:
                        throw new InvalidSpellTypeException();
                }
            default:
                throw new InvalidSpellTypeException();
        }
    }

    private static double Fiddlesticks(Obj_AI_Hero enemy, SpellType type, StageType stagetype)
    {
        switch (type)
        {
            case SpellType.Q:
                throw new InvalidSpellTypeException();
            case SpellType.W:
                switch (stagetype)
                {
                    case StageType.Default:
                        return CalcMagicDmg((150 + (ObjectManager.Player.Spellbook.GetSpell(SpellSlot.W).Level * 150)) + (2.25 * (ObjectManager.Player.FlatMagicDamageMod)), enemy); // complete dmg
                    case StageType.FirstDamage:
                        return CalcMagicDmg((30 + (ObjectManager.Player.Spellbook.GetSpell(SpellSlot.W).Level * 30)) + (0.45 * (ObjectManager.Player.FlatMagicDamageMod)), enemy); // per second
                    default:
                        throw new InvalidSpellTypeException();
                }
            case SpellType.E:
                switch (stagetype)
                {
                    case StageType.Default:
                        return CalcMagicDmg((45 + (ObjectManager.Player.Spellbook.GetSpell(SpellSlot.E).Level * 20)) + (0.45 * (ObjectManager.Player.FlatMagicDamageMod)), enemy); // damage per bounce
                    case StageType.FirstDamage:
                        return CalcMagicDmg((135 + (ObjectManager.Player.Spellbook.GetSpell(SpellSlot.E).Level * 60)) + (1.35 * (ObjectManager.Player.FlatMagicDamageMod)), enemy); // max damage to the same target
                    default:
                        throw new InvalidSpellTypeException();
                }
            case SpellType.R:
                switch (stagetype)
                {
                    case StageType.Default:
                        return CalcMagicDmg((25 + (ObjectManager.Player.Spellbook.GetSpell(SpellSlot.R).Level * 100)) + (0.45 * (ObjectManager.Player.FlatMagicDamageMod)), enemy); // damage per sec
                    case StageType.FirstDamage:
                        return CalcMagicDmg((125 + (ObjectManager.Player.Spellbook.GetSpell(SpellSlot.R).Level * 500)) + (2.25 * (ObjectManager.Player.FlatMagicDamageMod)), enemy); // dmg complete
                    default:
                        throw new InvalidSpellTypeException();
                }
            default:
                throw new InvalidSpellTypeException();
        }
    }

    private static double Fiora(Obj_AI_Hero enemy, SpellType type, StageType stagetype)
    {
        switch (type)
        {
            case SpellType.Q:
                switch (stagetype)
                {
                    case StageType.Default:
                        return CalcPhysicalDmg((30 + (ObjectManager.Player.Spellbook.GetSpell(SpellSlot.Q).Level * 50)) + (1.2 * ObjectManager.Player.FlatPhysicalDamageMod), enemy); // for both jumps
                    case StageType.FirstDamage:
                        return CalcPhysicalDmg((15 + (ObjectManager.Player.Spellbook.GetSpell(SpellSlot.Q).Level * 25)) + (0.6 * ObjectManager.Player.FlatPhysicalDamageMod), enemy); // for 1 jump
                    default:
                        throw new InvalidSpellTypeException();
                }
            case SpellType.W:
                return CalcMagicDmg((10 + (ObjectManager.Player.Spellbook.GetSpell(SpellSlot.W).Level * 50)) + (1.0 * ObjectManager.Player.FlatMagicDamageMod), enemy);
            case SpellType.E:
                throw new InvalidSpellTypeException();
            case SpellType.R:
                switch (stagetype)
                {
                    case StageType.Default:
                        return CalcPhysicalDmg((-20 + (ObjectManager.Player.Spellbook.GetSpell(SpellSlot.R).Level * 340)) + (2.4 * ObjectManager.Player.FlatPhysicalDamageMod), enemy); // max dmg to 1 target // TODO: Check if correct, Wiki giving some shit to me
                    case StageType.FirstDamage:
                        return CalcPhysicalDmg((-10 + (ObjectManager.Player.Spellbook.GetSpell(SpellSlot.R).Level * 170)) + (1.2 * ObjectManager.Player.FlatPhysicalDamageMod), enemy); // 1 hit damage
                    default:
                        throw new InvalidSpellTypeException();
                }
            default:
                throw new InvalidSpellTypeException();
        }
    }

    private static double Fizz(Obj_AI_Hero enemy, SpellType type, StageType stagetype)
    {
        switch (type)
        {
            case SpellType.Q:
                double addmg = CalcPhysicalDmg(ObjectManager.Player.BaseAttackDamage + ObjectManager.Player.FlatPhysicalDamageMod, enemy);
                double mdmg = CalcMagicDmg((-20 + (ObjectManager.Player.Spellbook.GetSpell(SpellSlot.Q).Level * 30)) + (0.6 * ObjectManager.Player.FlatMagicDamageMod), enemy);
                return addmg + mdmg;
            case SpellType.W:
                switch (stagetype)
                {
                    case StageType.Default:
                        return CalcMagicDmg((5 + (ObjectManager.Player.Spellbook.GetSpell(SpellSlot.W).Level * 5)) + (0.25 * ObjectManager.Player.FlatMagicDamageMod), enemy); // active dmg
                    case StageType.FirstDamage:
                        double basedmg = CalcMagicDmg((20 + (10 * ObjectManager.Player.Spellbook.GetSpell(SpellSlot.W).Level) + (0.35 * ObjectManager.Player.FlatMagicDamageMod)), enemy); // passive dmg
                        double percentage = 3 + ObjectManager.Player.Spellbook.GetSpell(SpellSlot.W).Level;
                        return basedmg + ((enemy.MaxHealth - enemy.Health) / 100) * percentage;
                    default:
                        throw new InvalidSpellTypeException();
                }
            case SpellType.E:
                return CalcMagicDmg((20 + (ObjectManager.Player.Spellbook.GetSpell(SpellSlot.E).Level * 50)) + (0.75 * ObjectManager.Player.FlatMagicDamageMod), enemy);
            case SpellType.R:
                return CalcMagicDmg((75 + (ObjectManager.Player.Spellbook.GetSpell(SpellSlot.R).Level * 125)) + (1.0 * ObjectManager.Player.FlatMagicDamageMod), enemy);
            default:
                throw new InvalidSpellTypeException();
        }
    }

    private static double Galio(Obj_AI_Hero enemy, SpellType type, StageType stagetype)
    {
        switch (type)
        {
            case SpellType.Q:
                return CalcMagicDmg((25 + (ObjectManager.Player.Spellbook.GetSpell(SpellSlot.Q).Level * 55)) + (0.6 * ObjectManager.Player.FlatMagicDamageMod), enemy);
            case SpellType.W:
                throw new InvalidSpellTypeException();
            case SpellType.E:
                return CalcMagicDmg((15 + (ObjectManager.Player.Spellbook.GetSpell(SpellSlot.E).Level * 45)) + (0.5 * ObjectManager.Player.FlatMagicDamageMod), enemy);
            case SpellType.R:
                return CalcMagicDmg((110 + (ObjectManager.Player.Spellbook.GetSpell(SpellSlot.R).Level * 110)) + (0.6 * ObjectManager.Player.FlatMagicDamageMod), enemy);
            default:
                throw new InvalidSpellTypeException();
        }
    }

    private static double Gangplank(Obj_AI_Hero enemy, SpellType type, StageType stagetype)
    {
        switch (type)
        {
            case SpellType.Q:
                return CalcPhysicalDmg((-5 + (ObjectManager.Player.Spellbook.GetSpell(SpellSlot.Q).Level * 25)) + (1.0 * (ObjectManager.Player.FlatPhysicalDamageMod + ObjectManager.Player.BaseAttackDamage)), enemy);
            case SpellType.W:
                throw new InvalidSpellTypeException();
            case SpellType.E:
                throw new InvalidSpellTypeException();
            case SpellType.R:
                return CalcMagicDmg((30 + (ObjectManager.Player.Spellbook.GetSpell(SpellSlot.R).Level * 45)) + (0.2 * ObjectManager.Player.FlatMagicDamageMod), enemy); // per canonball, 25 max but randomly
            default:
                throw new InvalidSpellTypeException();
        }
    }

    private static double Garen(Obj_AI_Hero enemy, SpellType type, StageType stagetype)
    {
        switch (type)
        {
            case SpellType.Q:
                return CalcPhysicalDmg((5 + (ObjectManager.Player.Spellbook.GetSpell(SpellSlot.Q).Level * 25)) + (0.4 * (ObjectManager.Player.FlatPhysicalDamageMod + ObjectManager.Player.BaseAttackDamage)), enemy);
            case SpellType.W:
                throw new InvalidSpellTypeException();
            case SpellType.E:
                switch (stagetype)
                {
                    case StageType.Default:
                        return CalcPhysicalDmg((-15 + (ObjectManager.Player.Spellbook.GetSpell(SpellSlot.E).Level * 75)) + ((1.8 + (0.3 * ObjectManager.Player.Spellbook.GetSpell(SpellSlot.E).Level)) * (ObjectManager.Player.FlatPhysicalDamageMod + ObjectManager.Player.BaseAttackDamage)), enemy); // complete e dmg
                    case StageType.FirstDamage:
                        return CalcPhysicalDmg((-5 + (ObjectManager.Player.Spellbook.GetSpell(SpellSlot.E).Level * 25)) + ((0.6 + (0.1 * ObjectManager.Player.Spellbook.GetSpell(SpellSlot.E).Level)) * (ObjectManager.Player.FlatPhysicalDamageMod + ObjectManager.Player.BaseAttackDamage)), enemy); // per sec
                    default:
                        throw new InvalidSpellTypeException();
                }
            case SpellType.R:
                double basedmg = CalcMagicDmg(175 + (175 * ObjectManager.Player.Spellbook.GetSpell(SpellSlot.R).Level), enemy);
                double hpbonus = 0;
                if (ObjectManager.Player.Spellbook.GetSpell(SpellSlot.R).Level == 1)
                {
                    hpbonus = (enemy.MaxHealth - enemy.Health) / 3.5;
                }
                else if (ObjectManager.Player.Spellbook.GetSpell(SpellSlot.R).Level == 2)
                {
                    hpbonus = (enemy.MaxHealth - enemy.Health) / 3;
                }
                else if (ObjectManager.Player.Spellbook.GetSpell(SpellSlot.R).Level == 2)
                {
                    hpbonus = (enemy.MaxHealth - enemy.Health) / 2.5;
                }
                return basedmg + CalcMagicDmg(hpbonus, enemy);
            default:
                throw new InvalidSpellTypeException();
        }
    }

    private static double Gragas(Obj_AI_Hero enemy, SpellType type, StageType stagetype)
    {
        switch (type)
        {
            case SpellType.Q:
                return CalcMagicDmg((40 + (ObjectManager.Player.Spellbook.GetSpell(SpellSlot.Q).Level * 40)) + (0.6 * ObjectManager.Player.FlatMagicDamageMod), enemy);
            case SpellType.W:
                double hpbonus = (enemy.MaxHealth / 100) * 7 + ObjectManager.Player.Spellbook.GetSpell(SpellSlot.W).Level;
                return CalcMagicDmg((-10 + (ObjectManager.Player.Spellbook.GetSpell(SpellSlot.W).Level * 30)) + (0.3 * ObjectManager.Player.FlatMagicDamageMod) + hpbonus, enemy);
            case SpellType.E:
                return CalcPhysicalDmg((30 + (ObjectManager.Player.Spellbook.GetSpell(SpellSlot.E).Level * 50)) + (0.6 * ObjectManager.Player.FlatMagicDamageMod), enemy);
            case SpellType.R:
                return CalcMagicDmg((100 + (ObjectManager.Player.Spellbook.GetSpell(SpellSlot.R).Level * 100)) + (0.7 * ObjectManager.Player.FlatMagicDamageMod), enemy);
            default:
                throw new InvalidSpellTypeException();
        }
    }

    private static double Graves(Obj_AI_Hero enemy, SpellType type, StageType stagetype)
    {
        switch (type)
        {
            case SpellType.Q:
                switch (stagetype)
                {
                    case StageType.Default:
                        return CalcPhysicalDmg((42.5 + (ObjectManager.Player.Spellbook.GetSpell(SpellSlot.Q).Level * 59.5)) + (1.36 * ObjectManager.Player.FlatPhysicalDamageMod), enemy); // max dmg
                    case StageType.FirstDamage:
                        return CalcPhysicalDmg((25 + (ObjectManager.Player.Spellbook.GetSpell(SpellSlot.Q).Level * 35)) + (0.8 * ObjectManager.Player.FlatPhysicalDamageMod), enemy); // for each struck hit
                    default:
                        throw new InvalidCastException();
                }
            case SpellType.W:
                return CalcMagicDmg((10 + (ObjectManager.Player.Spellbook.GetSpell(SpellSlot.W).Level * 50)) + (0.6 * ObjectManager.Player.FlatMagicDamageMod), enemy);
            case SpellType.E:
                throw new InvalidSpellTypeException();
            case SpellType.R:
                return CalcPhysicalDmg((150 + (ObjectManager.Player.Spellbook.GetSpell(SpellSlot.R).Level * 100)) + (1.5 * ObjectManager.Player.FlatPhysicalDamageMod), enemy);
            default:
                throw new InvalidSpellTypeException();
        }
    }

    private static double Hecarim(Obj_AI_Hero enemy, SpellType type, StageType stagetype)
    {
        switch (type)
        {
            case SpellType.Q:
                return CalcPhysicalDmg((25 + (ObjectManager.Player.Spellbook.GetSpell(SpellSlot.Q).Level * 35)) + (0.6 * ObjectManager.Player.FlatPhysicalDamageMod), enemy);
            case SpellType.W:
                switch (stagetype)
                {
                    case StageType.Default:
                        return CalcMagicDmg((10 + (ObjectManager.Player.Spellbook.GetSpell(SpellSlot.W).Level * 10)) + (0.2 * ObjectManager.Player.FlatMagicDamageMod), enemy); // complete dmg
                    case StageType.FirstDamage:
                        return CalcMagicDmg((10 + (ObjectManager.Player.Spellbook.GetSpell(SpellSlot.W).Level * 50)) + (0.6 * ObjectManager.Player.FlatMagicDamageMod), enemy); // per sec
                    default:
                        throw new InvalidSpellTypeException();
                }
            case SpellType.E:
                switch (stagetype)
                {
                    case StageType.Default:
                        return CalcPhysicalDmg((10 + (ObjectManager.Player.Spellbook.GetSpell(SpellSlot.E).Level * 70)) + (1.0 * ObjectManager.Player.FlatPhysicalDamageMod), enemy); // max e dmg
                    case StageType.FirstDamage:
                        return CalcPhysicalDmg((5 + (ObjectManager.Player.Spellbook.GetSpell(SpellSlot.E).Level * 35)) + (0.5 * ObjectManager.Player.FlatPhysicalDamageMod), enemy); // min e dmg
                    default:
                        throw new InvalidSpellTypeException();
                }
            case SpellType.R:
                return CalcMagicDmg((50 + (ObjectManager.Player.Spellbook.GetSpell(SpellSlot.R).Level * 100)) + (1.0 * ObjectManager.Player.FlatMagicDamageMod), enemy);

            default:
                throw new InvalidSpellTypeException();
        }
    }

    private static double Heimerdinger(Obj_AI_Hero enemy, SpellType type, StageType stagetype)
    {
        switch (type)
        {
            case SpellType.Q:
                switch (stagetype)
                {
                    case StageType.Default:
                        return CalcMagicDmg((6 + (ObjectManager.Player.Spellbook.GetSpell(SpellSlot.Q).Level * 6)) + (0.15 * ObjectManager.Player.FlatMagicDamageMod), enemy); // per hit dmg
                    case StageType.FirstDamage:
                        return CalcMagicDmg((20 + (ObjectManager.Player.Spellbook.GetSpell(SpellSlot.Q).Level * 20)) + (0.55 * ObjectManager.Player.FlatMagicDamageMod), enemy); // energy blast dmg
                    default:
                        throw new InvalidSpellTypeException();
                }
            case SpellType.W:
                switch (stagetype)
                {
                    case StageType.Default:
                        return CalcMagicDmg((54 + (ObjectManager.Player.Spellbook.GetSpell(SpellSlot.W).Level * 54)) + (0.92 * ObjectManager.Player.FlatMagicDamageMod), enemy); // max dmg to 1 target
                    case StageType.FirstDamage:
                        return CalcMagicDmg((30 + (ObjectManager.Player.Spellbook.GetSpell(SpellSlot.W).Level * 30)) + (0.45 * ObjectManager.Player.FlatMagicDamageMod), enemy); // foreach hitting missile
                    default:
                        throw new InvalidSpellTypeException();
                }
            case SpellType.E:
                return CalcMagicDmg((20 + (ObjectManager.Player.Spellbook.GetSpell(SpellSlot.E).Level * 40)) + (0.6 * ObjectManager.Player.FlatMagicDamageMod), enemy);
            case SpellType.R:
                throw new InvalidSpellTypeException();
            default:
                throw new InvalidSpellTypeException();
        }
    }

    private static double Irelia(Obj_AI_Hero enemy, SpellType type, StageType stagetype)
    {
        switch (type)
        {
            case SpellType.Q:
                return CalcPhysicalDmg((-10 + (ObjectManager.Player.Spellbook.GetSpell(SpellSlot.Q).Level * 30)) + (1.0 * (ObjectManager.Player.BaseAttackDamage + ObjectManager.Player.FlatPhysicalDamageMod)), enemy);
            case SpellType.W:
                return 15 * ObjectManager.Player.Spellbook.GetSpell(SpellSlot.W).Level;
            case SpellType.E:
                return CalcMagicDmg((30 + (ObjectManager.Player.Spellbook.GetSpell(SpellSlot.E).Level * 50)) + (0.5 * ObjectManager.Player.FlatMagicDamageMod), enemy);
            case SpellType.R:
                switch (stagetype)
                {
                    case StageType.Default:
                        return CalcPhysicalDmg((160 + (ObjectManager.Player.Spellbook.GetSpell(SpellSlot.R).Level * 160)) + (2.4 * ObjectManager.Player.FlatPhysicalDamageMod) + (2.0 * ObjectManager.Player.FlatMagicDamageMod), enemy); // max dmg to 1 target
                    case StageType.FirstDamage:
                        return CalcPhysicalDmg((40 + (ObjectManager.Player.Spellbook.GetSpell(SpellSlot.R).Level * 40)) + (0.6 * ObjectManager.Player.FlatPhysicalDamageMod) + (0.5 * ObjectManager.Player.FlatMagicDamageMod), enemy); // dmg per blade
                    default:
                        throw new InvalidCastException();
                }
            default:
                throw new InvalidSpellTypeException();
        }
    }

    private static double Janna(Obj_AI_Hero enemy, SpellType type, StageType stagetype)
    {
        switch (type)
        {
            case SpellType.Q:
                switch (stagetype)
                {
                    case StageType.Default:
                        return CalcMagicDmg((65 + (ObjectManager.Player.Spellbook.GetSpell(SpellSlot.Q).Level * 40)) + (0.65 * ObjectManager.Player.FlatMagicDamageMod), enemy); // max dmg
                    case StageType.FirstDamage:
                        return CalcMagicDmg((35 + (ObjectManager.Player.Spellbook.GetSpell(SpellSlot.Q).Level * 25)) + (0.35 * ObjectManager.Player.FlatMagicDamageMod), enemy); // damage when directly casted
                    default:
                        throw new InvalidSpellTypeException();
                }
            case SpellType.W:
                return CalcMagicDmg((5 + (ObjectManager.Player.Spellbook.GetSpell(SpellSlot.W).Level * 55)) + (0.5 * ObjectManager.Player.FlatMagicDamageMod), enemy);
            case SpellType.E:
                throw new InvalidSpellTypeException();
            case SpellType.R:
                throw new InvalidSpellTypeException();
            default:
                throw new InvalidSpellTypeException();
        }
    }

    private static double JarvanIV(Obj_AI_Hero enemy, SpellType type, StageType stagetype)
    {
        switch (type)
        {
            case SpellType.Q:
                return CalcPhysicalDmg((25 + (ObjectManager.Player.Spellbook.GetSpell(SpellSlot.Q).Level * 45)) + (1.2 * ObjectManager.Player.FlatPhysicalDamageMod), enemy);
            case SpellType.W:
                throw new InvalidCastException();
            case SpellType.E:
                return CalcMagicDmg((15 + (ObjectManager.Player.Spellbook.GetSpell(SpellSlot.E).Level * 45)) + (0.8 * ObjectManager.Player.FlatMagicDamageMod), enemy);
            case SpellType.R:
                return CalcPhysicalDmg((75 + (ObjectManager.Player.Spellbook.GetSpell(SpellSlot.R).Level * 125)) + (1.5 * ObjectManager.Player.FlatPhysicalDamageMod), enemy);
            default:
                throw new InvalidSpellTypeException();
        }
    }

    private static double Jax(Obj_AI_Hero enemy, SpellType type, StageType stagetype)
    {
        switch (type)
        {
            case SpellType.Q:
                return CalcPhysicalDmg((30 + (ObjectManager.Player.Spellbook.GetSpell(SpellSlot.Q).Level * 40)) + (1.0 * ObjectManager.Player.FlatPhysicalDamageMod) + (0.6 * ObjectManager.Player.FlatMagicDamageMod), enemy);
            case SpellType.W:
                return CalcMagicDmg((5 + (ObjectManager.Player.Spellbook.GetSpell(SpellSlot.W).Level * 35)) + (0.6 * ObjectManager.Player.FlatMagicDamageMod), enemy);
            case SpellType.E:
                return CalcMagicDmg((25 + (ObjectManager.Player.Spellbook.GetSpell(SpellSlot.E).Level * 25)) + (0.5 * ObjectManager.Player.FlatMagicDamageMod), enemy);
            case SpellType.R:
                return CalcMagicDmg((40 + (ObjectManager.Player.Spellbook.GetSpell(SpellSlot.R).Level * 60)) + (0.7 * ObjectManager.Player.FlatMagicDamageMod), enemy);
            default:
                throw new InvalidSpellTypeException();
        }
    }

    private static double Jayce(Obj_AI_Hero enemy, SpellType type, StageType stagetype)
    {
        switch (type)
        {
            case SpellType.Q:
                if (ObjectManager.Player.Spellbook.GetSpell(SpellSlot.Q).Name == "JayceToTheSkies")
                {
                    return CalcPhysicalDmg((-25 + (ObjectManager.Player.Spellbook.GetSpell(SpellSlot.Q).Level * 45)) + (1.0 * ObjectManager.Player.FlatPhysicalDamageMod), enemy);
                }
                else
                {
                    switch (stagetype)
                    {
                        case StageType.Default:
                            return CalcPhysicalDmg((7 + (ObjectManager.Player.Spellbook.GetSpell(SpellSlot.Q).Level * 77)) + (1.68 * ObjectManager.Player.FlatPhysicalDamageMod), enemy); // e + q
                        case StageType.FirstDamage:
                            return CalcPhysicalDmg((5 + (ObjectManager.Player.Spellbook.GetSpell(SpellSlot.Q).Level * 55)) + (1.2 * ObjectManager.Player.FlatPhysicalDamageMod), enemy); // q only
                        default:
                            throw new InvalidSpellTypeException();
                    }
                }
            case SpellType.W:
                if (ObjectManager.Player.Spellbook.GetSpell(SpellSlot.Q).Name == "JayceStaticField")
                {
                    switch (stagetype)
                    {
                        case StageType.Default:
                            return CalcMagicDmg((30 + (ObjectManager.Player.Spellbook.GetSpell(SpellSlot.W).Level * 70)) + (1.0 * ObjectManager.Player.FlatMagicDamageMod), enemy); // complete dmg
                        case StageType.FirstDamage:
                            return CalcMagicDmg((7.5 + (ObjectManager.Player.Spellbook.GetSpell(SpellSlot.W).Level * 17.5)) + (0.25 * ObjectManager.Player.FlatMagicDamageMod), enemy); // per sec
                        default:
                            throw new InvalidSpellTypeException();
                    }
                }
                else
                {
                    return 0; // return 0, no exception as when switching the name isn't directly changed and ppl will already try to calculate
                }
            case SpellType.E:
                if (ObjectManager.Player.Spellbook.GetSpell(SpellSlot.Q).Name == "JayceThunderingBlow")
                {
                    double percentage = 5 + (3 * ObjectManager.Player.Spellbook.GetSpell(SpellSlot.E).Level);
                    return CalcMagicDmg(((enemy.MaxHealth / 100) * percentage) + (ObjectManager.Player.FlatPhysicalDamageMod), enemy);
                }
                else
                {
                    return 0;
                }
            case SpellType.R:
                throw new InvalidSpellTypeException();
            default:
                throw new InvalidSpellTypeException();
        }
    }

    private static double Jinx(Obj_AI_Hero enemy, SpellType type, StageType stagetype)
    {
        switch (type)
        {
            case SpellType.Q:
                throw new InvalidSpellTypeException();
            case SpellType.W:
                return CalcPhysicalDmg((-40 + (ObjectManager.Player.Spellbook.GetSpell(SpellSlot.W).Level * 50)) + (1.4 * (ObjectManager.Player.BaseAttackDamage + ObjectManager.Player.FlatPhysicalDamageMod)), enemy);
            case SpellType.E:
                return CalcMagicDmg((25 + (ObjectManager.Player.Spellbook.GetSpell(SpellSlot.E).Level * 55)) + (1.0 * ObjectManager.Player.FlatMagicDamageMod), enemy);
            case SpellType.R:
                switch (stagetype)
                {
                    case StageType.Default:
                        double percentage = CalcPhysicalDmg(((enemy.MaxHealth - enemy.Health) / 100) * (20 + (5 * ObjectManager.Player.Spellbook.GetSpell(SpellSlot.R).Level)), enemy);
                        return percentage + CalcPhysicalDmg((150 + (ObjectManager.Player.Spellbook.GetSpell(SpellSlot.R).Level * 100)) + (1.0 * ObjectManager.Player.FlatPhysicalDamageMod), enemy); // max dmg
                    case StageType.FirstDamage:
                        double percentage2 = CalcPhysicalDmg(((enemy.MaxHealth - enemy.Health) / 100) * (20 + (5 * ObjectManager.Player.Spellbook.GetSpell(SpellSlot.R).Level)), enemy);
                        return percentage2 + CalcPhysicalDmg((75 + (ObjectManager.Player.Spellbook.GetSpell(SpellSlot.R).Level * 50)) + (0.5 * ObjectManager.Player.FlatPhysicalDamageMod), enemy); // min dmg
                    default:
                        throw new InvalidCastException();
                }
            default:
                throw new InvalidSpellTypeException();
        }
    }

    private static double Karma(Obj_AI_Hero enemy, SpellType type, StageType stagetype)
    {
        switch (type)
        {
            case SpellType.Q:
                switch (stagetype)
                {
                    case StageType.Default:
                        return CalcMagicDmg((35 + (ObjectManager.Player.Spellbook.GetSpell(SpellSlot.Q).Level * 45)) + (0.6 * ObjectManager.Player.FlatMagicDamageMod), enemy); // basic q
                    case StageType.FirstDamage:
                        double baseqdmg = CalcMagicDmg((35 + (ObjectManager.Player.Spellbook.GetSpell(SpellSlot.Q).Level * 45)) + (0.6 * ObjectManager.Player.FlatMagicDamageMod), enemy); // mantra q (with bonus, not with detonation)
                        double bonusqdmg = CalcMagicDmg((-25 + (ObjectManager.Player.Spellbook.GetSpell(SpellSlot.Q).Level)) + (0.3 * ObjectManager.Player.FlatMagicDamageMod), enemy);
                        return baseqdmg + bonusqdmg;
                    default:
                        throw new InvalidSpellTypeException();
                }
            case SpellType.W:
                switch (stagetype)
                {
                    case StageType.Default:
                        return CalcMagicDmg((10 + (ObjectManager.Player.Spellbook.GetSpell(SpellSlot.W).Level * 50)) + (0.6 * ObjectManager.Player.FlatMagicDamageMod), enemy); // basic w
                    case StageType.FirstDamage:
                        return CalcMagicDmg((0 + (ObjectManager.Player.Spellbook.GetSpell(SpellSlot.W).Level * 75)) + (0.6 * ObjectManager.Player.FlatMagicDamageMod), enemy); // mantra w
                    default:
                        throw new InvalidSpellTypeException();
                }
            case SpellType.E:
                return CalcMagicDmg((-20 + (ObjectManager.Player.Spellbook.GetSpell(SpellSlot.E).Level * 80)) + (0.6 * ObjectManager.Player.FlatMagicDamageMod), enemy); // mantra e (shield with dmg)
            case SpellType.R:
                throw new InvalidSpellTypeException();
            default:
                throw new InvalidSpellTypeException();
        }
    }

    private static double Karthus(Obj_AI_Hero enemy, SpellType type, StageType stagetype)
    {
        switch (type)
        {
            case SpellType.Q:
                switch (stagetype)
                {
                    case StageType.Default:
                        return CalcMagicDmg((40 + (ObjectManager.Player.Spellbook.GetSpell(SpellSlot.Q).Level * 40)) + (0.6 * ObjectManager.Player.FlatMagicDamageMod), enemy); // single target dmg
                    case StageType.FirstDamage:
                        return CalcMagicDmg((20 + (ObjectManager.Player.Spellbook.GetSpell(SpellSlot.Q).Level * 20)) + (0.3 * ObjectManager.Player.FlatMagicDamageMod), enemy); // multi target dmg
                    default:
                        throw new InvalidSpellTypeException();
                }
            case SpellType.W:
                throw new InvalidSpellTypeException();
            case SpellType.E:
                return CalcMagicDmg((10 + (ObjectManager.Player.Spellbook.GetSpell(SpellSlot.E).Level * 20)) + (0.2 * ObjectManager.Player.FlatMagicDamageMod), enemy);
            case SpellType.R:
                return CalcMagicDmg((100 + (ObjectManager.Player.Spellbook.GetSpell(SpellSlot.R).Level * 150)) + (0.6 * ObjectManager.Player.FlatMagicDamageMod), enemy);
            default:
                throw new InvalidSpellTypeException();
        }
    }

    private static double Kassadin(Obj_AI_Hero enemy, SpellType type, StageType stagetype)
    {
        switch (type)
        {
            case SpellType.Q:
                return CalcMagicDmg((55 + (ObjectManager.Player.Spellbook.GetSpell(SpellSlot.Q).Level * 25)) + (0.7 * ObjectManager.Player.FlatMagicDamageMod), enemy);
            case SpellType.W:
                return CalcMagicDmg((15 + (ObjectManager.Player.Spellbook.GetSpell(SpellSlot.W).Level * 25)) + (0.6 * ObjectManager.Player.FlatMagicDamageMod), enemy);
            case SpellType.E:
                return CalcMagicDmg((55 + (ObjectManager.Player.Spellbook.GetSpell(SpellSlot.E).Level * 25)) + (0.7 * ObjectManager.Player.FlatMagicDamageMod), enemy);
            case SpellType.R:
                return CalcMagicDmg((60 + (ObjectManager.Player.Spellbook.GetSpell(SpellSlot.R).Level * 20)) + (0.02 * ObjectManager.Player.MaxMana), enemy);
            default:
                throw new InvalidSpellTypeException();
        }
    }

    private static double Katarina(Obj_AI_Hero enemy, SpellType type, StageType stagetype)
    {
        switch (type)
        {
            case SpellType.Q:
                switch (stagetype)
                {
                    case StageType.Default:
                        return CalcMagicDmg((35 + (ObjectManager.Player.Spellbook.GetSpell(SpellSlot.Q).Level * 40)) + (0.6 * ObjectManager.Player.FlatMagicDamageMod), enemy); // total dmg (mark + detonation)
                    case StageType.FirstDamage:
                        return CalcMagicDmg((35 + (ObjectManager.Player.Spellbook.GetSpell(SpellSlot.Q).Level * 25)) + (0.45 * ObjectManager.Player.FlatMagicDamageMod), enemy); // mark damage
                    default:
                        throw new InvalidSpellTypeException();
                }
            case SpellType.W:
                return CalcMagicDmg((5 + (ObjectManager.Player.Spellbook.GetSpell(SpellSlot.W).Level * 35)) + (0.25 * ObjectManager.Player.FlatMagicDamageMod) + (0.6 * ObjectManager.Player.FlatPhysicalDamageMod), enemy);
            case SpellType.E:
                return CalcMagicDmg((35 + (ObjectManager.Player.Spellbook.GetSpell(SpellSlot.E).Level * 25)) + (0.4 * ObjectManager.Player.FlatMagicDamageMod), enemy);
            case SpellType.R:
                switch (stagetype)
                {
                    case StageType.Default:
                        return CalcMagicDmg((225 + (ObjectManager.Player.Spellbook.GetSpell(SpellSlot.R).Level * 175)) + (2.5 * ObjectManager.Player.FlatMagicDamageMod) + (3.75 * ObjectManager.Player.FlatPhysicalDamageMod), enemy); // complete ult dmg
                    case StageType.FirstDamage:
                        return CalcMagicDmg((22.5 + (ObjectManager.Player.Spellbook.GetSpell(SpellSlot.R).Level * 17.5)) + (0.25 * ObjectManager.Player.FlatMagicDamageMod) + (0.375 * ObjectManager.Player.FlatPhysicalDamageMod), enemy); // for each blade
                    default:
                        throw new InvalidSpellTypeException();
                }
            default:
                throw new InvalidSpellTypeException();
        }
    }

    private static double Kayle(Obj_AI_Hero enemy, SpellType type, StageType stagetype)
    {
        switch (type)
        {
            case SpellType.Q:
                return CalcMagicDmg((10 + (ObjectManager.Player.Spellbook.GetSpell(SpellSlot.Q).Level * 50)) + (0.6 * ObjectManager.Player.FlatMagicDamageMod) + (1.0 * ObjectManager.Player.FlatPhysicalDamageMod), enemy);
            case SpellType.W:
                throw new InvalidSpellTypeException();
            case SpellType.E:
                return CalcMagicDmg((10 + (ObjectManager.Player.Spellbook.GetSpell(SpellSlot.E).Level * 10)) + (0.4 * ObjectManager.Player.FlatMagicDamageMod), enemy);
            case SpellType.R:
                throw new InvalidSpellTypeException();
            default:
                throw new InvalidSpellTypeException();
        }
    }

    private static double Kennen(Obj_AI_Hero enemy, SpellType type, StageType stagetype)
    {
        switch (type)
        {
            case SpellType.Q:
                return CalcMagicDmg((35 + (ObjectManager.Player.Spellbook.GetSpell(SpellSlot.Q).Level * 40)) + (0.75 * ObjectManager.Player.FlatMagicDamageMod), enemy);
            case SpellType.W:
                switch (stagetype)
                {
                    case StageType.Default:
                        return CalcMagicDmg((35 + (ObjectManager.Player.Spellbook.GetSpell(SpellSlot.W).Level * 30)) + (0.55 * ObjectManager.Player.FlatMagicDamageMod), enemy); // active dmg
                    case StageType.FirstDamage:
                        return CalcMagicDmg(((0.3 + (0.1 * ObjectManager.Player.Spellbook.GetSpell(SpellSlot.W).Level)) * ObjectManager.Player.FlatPhysicalDamageMod), enemy); // pasive dmg
                    default:
                        throw new InvalidSpellTypeException();
                }
            case SpellType.E:
                return CalcMagicDmg((45 + (ObjectManager.Player.Spellbook.GetSpell(SpellSlot.E).Level * 40)) + (0.6 * ObjectManager.Player.FlatMagicDamageMod), enemy);
            case SpellType.R:
                switch (stagetype)
                {
                    case StageType.Default:
                        return CalcMagicDmg((45 + (ObjectManager.Player.Spellbook.GetSpell(SpellSlot.R).Level * 195)) + (1.2 * ObjectManager.Player.FlatMagicDamageMod), enemy); // max dmg to 1 target
                    case StageType.FirstDamage:
                        return CalcMagicDmg((15 + (ObjectManager.Player.Spellbook.GetSpell(SpellSlot.R).Level * 65)) + (0.4 * ObjectManager.Player.FlatMagicDamageMod), enemy); // dmg per bolt
                    default:
                        throw new InvalidSpellTypeException();
                }
            default:
                throw new InvalidSpellTypeException();
        }
    }

    private static double KhaZix(Obj_AI_Hero enemy, SpellType type, StageType stagetype)
    {
        switch (type)
        {
            case SpellType.Q:
                switch (stagetype)
                {
                    case StageType.Default:
                        return CalcPhysicalDmg((40 + (ObjectManager.Player.Spellbook.GetSpell(SpellSlot.Q).Level * 30)) + (1.5 * ObjectManager.Player.FlatPhysicalDamageMod), enemy); // basic q dmg
                    case StageType.FirstDamage:
                        return CalcPhysicalDmg((58 + (ObjectManager.Player.Spellbook.GetSpell(SpellSlot.Q).Level * 43.5)) + (2.175 * ObjectManager.Player.FlatPhysicalDamageMod), enemy); // isolated q
                    default:
                        throw new InvalidSpellTypeException();
                }
            case SpellType.W:
                return CalcPhysicalDmg((35 + (ObjectManager.Player.Spellbook.GetSpell(SpellSlot.W).Level * 40)) + (1.0 * ObjectManager.Player.FlatPhysicalDamageMod), enemy);
            case SpellType.E:
                return CalcPhysicalDmg((30 + (ObjectManager.Player.Spellbook.GetSpell(SpellSlot.E).Level * 35)) + (0.2 * ObjectManager.Player.FlatPhysicalDamageMod), enemy);
            case SpellType.R:
                throw new InvalidSpellTypeException();
            default:
                throw new InvalidSpellTypeException();
        }
    }

    private static double KogMaw(Obj_AI_Hero enemy, SpellType type, StageType stagetype)
    {
        switch (type)
        {
            case SpellType.Q:
                return CalcMagicDmg((30 + (ObjectManager.Player.Spellbook.GetSpell(SpellSlot.Q).Level * 50)) + (0.5 * ObjectManager.Player.FlatMagicDamageMod), enemy);
            case SpellType.W:
                double percentofmaxhealth = (1.0 + (ObjectManager.Player.Spellbook.GetSpell(SpellSlot.W).Level));
                double additionalpercentper100ap = 0;
                if (ObjectManager.Player.FlatMagicDamageMod < 100)
                {
                    additionalpercentper100ap = 0;
                }
                else if (ObjectManager.Player.FlatMagicDamageMod.IsBetween(100, 199))
                {
                    additionalpercentper100ap = 1;
                }
                else if (ObjectManager.Player.FlatMagicDamageMod.IsBetween(200, 299))
                {
                    additionalpercentper100ap = 2;
                }
                else if (ObjectManager.Player.FlatMagicDamageMod.IsBetween(300, 399))
                {
                    additionalpercentper100ap = 3;
                }
                else if (ObjectManager.Player.FlatMagicDamageMod.IsBetween(400, 499))
                {
                    additionalpercentper100ap = 4;
                }
                else if (ObjectManager.Player.FlatMagicDamageMod.IsBetween(500, 599))
                {
                    additionalpercentper100ap = 5;
                }
                else if (ObjectManager.Player.FlatMagicDamageMod.IsBetween(600, 699))
                {
                    additionalpercentper100ap = 6;
                }
                else if (ObjectManager.Player.FlatMagicDamageMod.IsBetween(700, 799))
                {
                    additionalpercentper100ap = 7;
                }
                else if (ObjectManager.Player.FlatMagicDamageMod.IsBetween(800, 899))
                {
                    additionalpercentper100ap = 8;
                }
                else if (ObjectManager.Player.FlatMagicDamageMod >= 900)
                {
                    additionalpercentper100ap = 9;
                }
                double healthbase = enemy.MaxHealth / 100 * (percentofmaxhealth + additionalpercentper100ap);
                return CalcMagicDmg(healthbase, enemy);
            case SpellType.E:
                return CalcMagicDmg((10 + (ObjectManager.Player.Spellbook.GetSpell(SpellSlot.E).Level * 50)) + (0.7 * ObjectManager.Player.FlatMagicDamageMod), enemy);
            case SpellType.R:
                return CalcMagicDmg((90 + (ObjectManager.Player.Spellbook.GetSpell(SpellSlot.R).Level * 90)) + (0.3 * ObjectManager.Player.FlatMagicDamageMod) + (0.5 * ObjectManager.Player.FlatPhysicalDamageMod), enemy); // 125% bonus dmg to champs
            default:
                throw new InvalidSpellTypeException();
        }
    }

    private static double LeBlanc(Obj_AI_Hero enemy, SpellType type, StageType stagetype)
    {
        switch (type)
        {
            case SpellType.Q:
                switch (stagetype)
                {
                    case StageType.Default:
                        return CalcMagicDmg((60 + (ObjectManager.Player.Spellbook.GetSpell(SpellSlot.Q).Level * 50)) + (0.8 * ObjectManager.Player.FlatMagicDamageMod), enemy); // total q dmg
                    case StageType.FirstDamage:
                        return CalcMagicDmg((30 + (ObjectManager.Player.Spellbook.GetSpell(SpellSlot.Q).Level * 25)) + (0.4 * ObjectManager.Player.FlatMagicDamageMod), enemy); // first q or detonation, same dmg
                    default:
                        throw new InvalidSpellTypeException();
                }
            case SpellType.W:
                return CalcMagicDmg((45 + (ObjectManager.Player.Spellbook.GetSpell(SpellSlot.W).Level * 40)) + (0.6 * ObjectManager.Player.FlatMagicDamageMod), enemy);
            case SpellType.E:
                switch (stagetype)
                {
                    case StageType.Default:
                        return CalcMagicDmg((30 + (ObjectManager.Player.Spellbook.GetSpell(SpellSlot.E).Level * 50)) + (1.0 * ObjectManager.Player.FlatMagicDamageMod), enemy); // total e dmg
                    case StageType.FirstDamage:
                        return CalcMagicDmg((15 + (ObjectManager.Player.Spellbook.GetSpell(SpellSlot.E).Level * 25)) + (0.5 * ObjectManager.Player.FlatMagicDamageMod), enemy); // first e or detonation, same dmg
                    default:
                        throw new InvalidSpellTypeException();
                }
            case SpellType.R:
                switch (stagetype)
                {
                    case StageType.Default:
                        throw new InvalidSpellTypeException();
                    case StageType.FirstDamage:
                        return CalcMagicDmg((0 + (ObjectManager.Player.Spellbook.GetSpell(SpellSlot.R).Level * 100)) + (0.65 * ObjectManager.Player.FlatMagicDamageMod), enemy); // q as ulted version
                    case StageType.SecondDamage:
                        return CalcMagicDmg((0 + (ObjectManager.Player.Spellbook.GetSpell(SpellSlot.R).Level * 150)) + (0.975 * ObjectManager.Player.FlatMagicDamageMod), enemy); // w as ulted version
                    case StageType.ThirdDamage:
                        return CalcMagicDmg((0 + (ObjectManager.Player.Spellbook.GetSpell(SpellSlot.R).Level * 100)) + (0.65 * ObjectManager.Player.FlatMagicDamageMod), enemy); // e as ulted version
                    default:
                        throw new InvalidSpellTypeException();
                }
            default:
                throw new InvalidSpellTypeException();
        }
    }

    private static double LeeSin(Obj_AI_Hero enemy, SpellType type, StageType stagetype)
    {
        switch (type)
        {
            case SpellType.Q:
                switch (stagetype)
                {
                    case StageType.Default:
                        return CalcPhysicalDmg(40 + ((ObjectManager.Player.Spellbook.GetSpell(SpellSlot.Q).Level * 60)) + (1.8 * ObjectManager.Player.FlatPhysicalDamageMod) + (8 * ((enemy.MaxHealth / enemy.Health) / 100)), enemy);
                    case StageType.FirstDamage:
                        return CalcPhysicalDmg(20 + ((ObjectManager.Player.Spellbook.GetSpell(SpellSlot.Q).Level * 30)) + (0.9 * ObjectManager.Player.FlatPhysicalDamageMod), enemy);
                    default:
                        throw new InvalidSpellTypeException();
                }
            case SpellType.W:
                throw new InvalidSpellTypeException();
            case SpellType.E:
                return CalcMagicDmg((25 + (ObjectManager.Player.Spellbook.GetSpell(SpellSlot.E).Level * 35)) + ObjectManager.Player.FlatMagicDamageMod, enemy);
            case SpellType.R:
                return CalcPhysicalDmg((ObjectManager.Player.Spellbook.GetSpell(SpellSlot.R).Level * 200) + (2.0 * ObjectManager.Player.FlatMagicDamageMod), enemy);
            default:
                throw new InvalidSpellTypeException();
        }
    }

    private static double Leona(Obj_AI_Hero enemy, SpellType type, StageType stagetype)
    {
        switch (type)
        {
            case SpellType.Q:
                return CalcMagicDmg((10 + (ObjectManager.Player.Spellbook.GetSpell(SpellSlot.Q).Level * 30)) + (0.30 * ObjectManager.Player.FlatMagicDamageMod), enemy);
            case SpellType.W:
                return CalcMagicDmg((10 + (ObjectManager.Player.Spellbook.GetSpell(SpellSlot.W).Level * 50)) + (0.40 * ObjectManager.Player.FlatMagicDamageMod), enemy);
            case SpellType.E:
                return CalcMagicDmg((20 + (ObjectManager.Player.Spellbook.GetSpell(SpellSlot.E).Level * 40)) + (0.40 * ObjectManager.Player.FlatMagicDamageMod), enemy);
            case SpellType.R:
                return CalcMagicDmg((50 + (ObjectManager.Player.Spellbook.GetSpell(SpellSlot.R).Level * 100)) + (0.80 * ObjectManager.Player.FlatMagicDamageMod), enemy);
            default:
                throw new InvalidSpellTypeException();
        }
    }

    private static double Lissandra(Obj_AI_Hero enemy, SpellType type, StageType stagetype)
    {
        switch (type)
        {
            case SpellType.Q:
                return CalcMagicDmg((40 + (ObjectManager.Player.Spellbook.GetSpell(SpellSlot.Q).Level * 35)) + (0.65 * ObjectManager.Player.FlatMagicDamageMod), enemy);
            case SpellType.W:
                return CalcMagicDmg((30 + (ObjectManager.Player.Spellbook.GetSpell(SpellSlot.W).Level * 40)) + (0.60 * ObjectManager.Player.FlatMagicDamageMod), enemy);
            case SpellType.E:
                return CalcMagicDmg((25 + (ObjectManager.Player.Spellbook.GetSpell(SpellSlot.E).Level * 45)) + (0.60 * ObjectManager.Player.FlatMagicDamageMod), enemy);
            case SpellType.R:
                return CalcMagicDmg((50 + (ObjectManager.Player.Spellbook.GetSpell(SpellSlot.R).Level * 100)) + (0.70 * ObjectManager.Player.FlatMagicDamageMod), enemy);
            default:
                throw new InvalidSpellTypeException();
        }
    }

    private static double Lucian(Obj_AI_Hero enemy, SpellType type, StageType stagetype)
    {
        switch (type)
        {
            case SpellType.Q:
                return CalcPhysicalDmg((50 + (ObjectManager.Player.Spellbook.GetSpell(SpellSlot.Q).Level * 30)) + (45 + (ObjectManager.Player.Spellbook.GetSpell(SpellSlot.Q).Level * 15)) * ObjectManager.Player.FlatPhysicalDamageMod, enemy);
            case SpellType.W:
                return CalcMagicDmg((20 + (ObjectManager.Player.Spellbook.GetSpell(SpellSlot.W).Level * 40)) + (0.6 * ObjectManager.Player.FlatMagicDamageMod) + (0.9 * ObjectManager.Player.FlatMagicDamageMod), enemy);
            case SpellType.E:
                throw new InvalidSpellTypeException();
            case SpellType.R:
                return CalcPhysicalDmg((30 + (ObjectManager.Player.Spellbook.GetSpell(SpellSlot.Q).Level * 10)) + (0.1 * ObjectManager.Player.FlatMagicDamageMod) + (0.3 * ObjectManager.Player.FlatPhysicalDamageMod), enemy);
            default:
                throw new InvalidSpellTypeException();
        }
    }

    private static double Lulu(Obj_AI_Hero enemy, SpellType type, StageType stagetype)
    {
        switch (type)
        {
            case SpellType.Q:
                return CalcMagicDmg((35 + (ObjectManager.Player.Spellbook.GetSpell(SpellSlot.Q).Level * 45)) + (0.5 * ObjectManager.Player.FlatMagicDamageMod), enemy);
            case SpellType.W:
                throw new InvalidSpellTypeException();
            case SpellType.E:
                return CalcMagicDmg((50 + (ObjectManager.Player.Spellbook.GetSpell(SpellSlot.E).Level * 30)) + (0.4 * ObjectManager.Player.FlatMagicDamageMod), enemy);
            case SpellType.R:
                throw new InvalidSpellTypeException();
            default:
                throw new InvalidSpellTypeException();
        }
    }

    private static double Lux(Obj_AI_Hero enemy, SpellType type, StageType stagetype)
    {
        switch (type)
        {
            case SpellType.Q:
                return CalcMagicDmg((10 + (ObjectManager.Player.Spellbook.GetSpell(SpellSlot.Q).Level * 50)) + (0.7 * ObjectManager.Player.FlatMagicDamageMod), enemy);
            case SpellType.W:
                throw new InvalidSpellTypeException();
            case SpellType.E:
                return CalcMagicDmg((15 + (ObjectManager.Player.Spellbook.GetSpell(SpellSlot.E).Level * 45)) + (0.6 * ObjectManager.Player.FlatMagicDamageMod), enemy);
            case SpellType.R:
                return CalcMagicDmg((200 + (ObjectManager.Player.Spellbook.GetSpell(SpellSlot.R).Level * 100)) + (0.75 * ObjectManager.Player.FlatMagicDamageMod), enemy);
            default:
                throw new InvalidSpellTypeException();
        }
    }

    private static double Malphite(Obj_AI_Hero enemy, SpellType type, StageType stagetype)
    {
        switch (type)
        {
            case SpellType.Q:
                return CalcMagicDmg((20 + (ObjectManager.Player.Spellbook.GetSpell(SpellSlot.Q).Level * 50)) + (0.6 * ObjectManager.Player.FlatMagicDamageMod), enemy);
            case SpellType.W:
                throw new InvalidSpellTypeException();
            case SpellType.E:
                return CalcMagicDmg((20 + (ObjectManager.Player.Spellbook.GetSpell(SpellSlot.E).Level * 40)) + (0.2 * ObjectManager.Player.FlatMagicDamageMod) + (0.3 * ObjectManager.Player.Armor), enemy);
            case SpellType.R:
                return CalcMagicDmg((100 + (ObjectManager.Player.Spellbook.GetSpell(SpellSlot.R).Level * 100)) + (1.3 * ObjectManager.Player.FlatMagicDamageMod), enemy);
            default:
                throw new InvalidSpellTypeException();
        }
    }


    private static double Malzahar(Obj_AI_Hero enemy, SpellType type, StageType stagetype)
    {
        switch (type)
        {
            case SpellType.Q:
                return CalcMagicDmg((25 + (ObjectManager.Player.Spellbook.GetSpell(SpellSlot.Q).Level * 55)) + (0.8 * ObjectManager.Player.FlatMagicDamageMod), enemy);
            case SpellType.W:
                return CalcMagicDmg(((ObjectManager.Player.Spellbook.GetSpell(SpellSlot.W).Level + 3) + (0.1 * ObjectManager.Player.FlatMagicDamageMod)) * (enemy.MaxHealth / 100), enemy);
            case SpellType.E:
                return CalcMagicDmg((20 + (ObjectManager.Player.Spellbook.GetSpell(SpellSlot.E).Level * 60)) + (0.8 * ObjectManager.Player.FlatMagicDamageMod), enemy);
            case SpellType.R:
                return CalcMagicDmg((100 + (ObjectManager.Player.Spellbook.GetSpell(SpellSlot.R).Level * 100)) + (1.3 * ObjectManager.Player.FlatMagicDamageMod), enemy);
            default:
                throw new InvalidSpellTypeException();
        }
    }

    private static double Maokai(Obj_AI_Hero enemy, SpellType type, StageType stagetype)
    {
        switch (type)
        {
            case SpellType.Q:
                return CalcMagicDmg((25 + (ObjectManager.Player.Spellbook.GetSpell(SpellSlot.Q).Level * 45)) + (0.4 * ObjectManager.Player.FlatMagicDamageMod), enemy);
            case SpellType.W:
                return CalcMagicDmg((45 + (ObjectManager.Player.Spellbook.GetSpell(SpellSlot.E).Level * 35)) + (0.8 * ObjectManager.Player.FlatMagicDamageMod), enemy);
            case SpellType.E:
                switch (stagetype)
                {
                    case StageType.Default:
                        return CalcMagicDmg((35 + (ObjectManager.Player.Spellbook.GetSpell(SpellSlot.E).Level * 85)) + (1.0 * ObjectManager.Player.FlatMagicDamageMod), enemy);
                    case StageType.FirstDamage:
                        return CalcMagicDmg((5 + (ObjectManager.Player.Spellbook.GetSpell(SpellSlot.E).Level * 35)) + (0.4 * ObjectManager.Player.FlatMagicDamageMod), enemy);
                    default:
                        throw new InvalidSpellTypeException();
                }
            case SpellType.R:
                return CalcMagicDmg((200 + (ObjectManager.Player.Spellbook.GetSpell(SpellSlot.R).Level * 100)) + (0.5 * ObjectManager.Player.FlatMagicDamageMod), enemy);
            default:
                throw new InvalidSpellTypeException();
        }
    }


    private static double MasterYi(Obj_AI_Hero enemy, SpellType type, StageType stagetype)
    {
        switch (type)
        {
            case SpellType.Q:
                return CalcPhysicalDmg((10 + (ObjectManager.Player.Spellbook.GetSpell(SpellSlot.Q).Level * 35)) + (ObjectManager.Player.FlatPhysicalDamageMod + ObjectManager.Player.BaseAttackDamage), enemy);
            case SpellType.W:
                throw new InvalidSpellTypeException();
            case SpellType.E:
                throw new InvalidSpellTypeException();
            case SpellType.R:
                throw new InvalidSpellTypeException();
            default:
                throw new InvalidSpellTypeException();
        }
    }

    private static double MissFortune(Obj_AI_Hero enemy, SpellType type, StageType stagetype)
    {
        switch (type)
        {
            case SpellType.Q:
                switch (stagetype)
                {
                    case StageType.FirstDamage:
                        return CalcPhysicalDmg((5 + (ObjectManager.Player.Spellbook.GetSpell(SpellSlot.Q).Level * 15)) + (0.85 * (ObjectManager.Player.FlatPhysicalDamageMod + ObjectManager.Player.BaseAttackDamage)), enemy);
                    case StageType.SecondDamage:
                        return CalcPhysicalDmg((10 + (ObjectManager.Player.Spellbook.GetSpell(SpellSlot.Q).Level * 30)) + (ObjectManager.Player.FlatPhysicalDamageMod + ObjectManager.Player.BaseAttackDamage), enemy);
                    default:
                        throw new InvalidSpellTypeException();
                }
            case SpellType.W:
                throw new InvalidSpellTypeException();
            case SpellType.E:
                return CalcMagicDmg((35 + (ObjectManager.Player.Spellbook.GetSpell(SpellSlot.E).Level * 55)) + (0.8 * ObjectManager.Player.FlatMagicDamageMod), enemy);
            case SpellType.R:
                switch (stagetype)
                {
                    case StageType.Default:
                        return CalcPhysicalDmg((200 + (ObjectManager.Player.Spellbook.GetSpell(SpellSlot.R).Level * 200)) + (1.6 * ObjectManager.Player.FlatMagicDamageMod), enemy);
                    case StageType.FirstDamage:
                        return CalcPhysicalDmg((25 + (ObjectManager.Player.Spellbook.GetSpell(SpellSlot.R).Level * 25)) + (0.2 * ObjectManager.Player.FlatMagicDamageMod), enemy);
                    default:
                        throw new InvalidSpellTypeException();
                }
            default:
                throw new InvalidSpellTypeException();
        }
    }

    private static double Mordekaiser(Obj_AI_Hero enemy, SpellType type, StageType stagetype)
    {
        switch (type)
        {
            case SpellType.Q:
                switch (stagetype)
                {
                    case StageType.Default:
                        return CalcMagicDmg((82.5 + (ObjectManager.Player.Spellbook.GetSpell(SpellSlot.Q).Level * 49.5)) + (0.66 * ObjectManager.Player.FlatMagicDamageMod) + (1.65 * ObjectManager.Player.FlatPhysicalDamageMod), enemy);
                    case StageType.FirstDamage:
                        return CalcMagicDmg((50 + (ObjectManager.Player.Spellbook.GetSpell(SpellSlot.Q).Level * 30)) + (0.40 * ObjectManager.Player.FlatMagicDamageMod) + (1.0 * ObjectManager.Player.FlatPhysicalDamageMod), enemy);
                    default:
                        throw new InvalidSpellTypeException();
                }
            case SpellType.W:
                switch (stagetype)
                {
                    case StageType.Default:
                        return CalcMagicDmg((60 + (ObjectManager.Player.Spellbook.GetSpell(SpellSlot.W).Level * 84)) + (1.2 * ObjectManager.Player.FlatMagicDamageMod), enemy);
                    case StageType.FirstDamage:
                        return CalcMagicDmg((10 + (ObjectManager.Player.Spellbook.GetSpell(SpellSlot.W).Level * 14)) + (0.20 * ObjectManager.Player.FlatMagicDamageMod), enemy);
                    default:
                        throw new InvalidSpellTypeException();
                }
            case SpellType.E:
                return CalcMagicDmg((25 + (ObjectManager.Player.Spellbook.GetSpell(SpellSlot.E).Level * 45)) + (0.6 * ObjectManager.Player.FlatMagicDamageMod), enemy);
            case SpellType.R:
                return CalcMagicDmg(((19 + (ObjectManager.Player.Spellbook.GetSpell(SpellSlot.R).Level * 5)) + (0.4 * ObjectManager.Player.FlatMagicDamageMod)) * (1 - (enemy.MaxHealth / 100)), enemy);
            default:
                throw new InvalidSpellTypeException();
        }
    }

    private static double Morgana(Obj_AI_Hero enemy, SpellType type, StageType stagetype)
    {
        switch (type)
        {
            case SpellType.Q:
                return CalcMagicDmg((25 + (ObjectManager.Player.Spellbook.GetSpell(SpellSlot.Q).Level * 55)) + (0.60 * ObjectManager.Player.FlatMagicDamageMod), enemy);
            case SpellType.W:
                switch (stagetype)
                {
                    case StageType.Default:
                        return CalcMagicDmg((75 + (ObjectManager.Player.Spellbook.GetSpell(SpellSlot.W).Level * 105)) + (1.65 * ObjectManager.Player.FlatMagicDamageMod), enemy);
                    case StageType.FirstDamage:
                        return CalcMagicDmg((50 + (ObjectManager.Player.Spellbook.GetSpell(SpellSlot.W).Level * 70)) + (1.10 * ObjectManager.Player.FlatMagicDamageMod), enemy);
                    default:
                        throw new InvalidSpellTypeException();
                }
            case SpellType.E:
                throw new InvalidSpellTypeException();
            case SpellType.R:
                switch (stagetype)
                {
                    case StageType.Default:
                        return CalcMagicDmg((200 + (ObjectManager.Player.Spellbook.GetSpell(SpellSlot.R).Level * 150)) + (1.40 * ObjectManager.Player.FlatMagicDamageMod), enemy);
                    case StageType.FirstDamage:
                        return CalcMagicDmg((100 + (ObjectManager.Player.Spellbook.GetSpell(SpellSlot.R).Level * 75)) + (0.7 * ObjectManager.Player.FlatMagicDamageMod), enemy);
                    default:
                        throw new InvalidSpellTypeException();
                }
            default:
                throw new InvalidSpellTypeException();
        }
    }

    private static double Nami(Obj_AI_Hero enemy, SpellType type, StageType stagetype)
    {
        switch (type)
        {
            case SpellType.Q:
                return CalcMagicDmg((20 + (ObjectManager.Player.Spellbook.GetSpell(SpellSlot.Q).Level * 55)) + (0.50 * ObjectManager.Player.FlatMagicDamageMod), enemy);
            case SpellType.W:
                return CalcMagicDmg((30 + (ObjectManager.Player.Spellbook.GetSpell(SpellSlot.W).Level * 40)) + (0.50 * ObjectManager.Player.FlatMagicDamageMod), enemy);
            case SpellType.E:
                return CalcMagicDmg((10 + (ObjectManager.Player.Spellbook.GetSpell(SpellSlot.E).Level * 15)) + (0.20 * ObjectManager.Player.FlatMagicDamageMod), enemy);
            case SpellType.R:
                return CalcMagicDmg((50 + (ObjectManager.Player.Spellbook.GetSpell(SpellSlot.R).Level * 100)) + (0.60 * ObjectManager.Player.FlatMagicDamageMod), enemy);
            default:
                throw new InvalidSpellTypeException();
        }
    }

    private static double Nasus(Obj_AI_Hero enemy, SpellType type, StageType stagetype)
    {
        switch (type)
        {
            case SpellType.Q:
                return CalcPhysicalDmg((10 + (ObjectManager.Player.Spellbook.GetSpell(SpellSlot.Q).Level * 20)), enemy);
            case SpellType.W:
                throw new InvalidSpellTypeException();
            case SpellType.E:
                switch (stagetype)
                {
                    case StageType.Default:
                        return CalcMagicDmg((30 + (ObjectManager.Player.Spellbook.GetSpell(SpellSlot.E).Level * 80)) + (1.2 * ObjectManager.Player.FlatMagicDamageMod), enemy);
                    case StageType.FirstDamage:
                        return CalcMagicDmg((3 + (ObjectManager.Player.Spellbook.GetSpell(SpellSlot.E).Level * 8)) + (0.12 * ObjectManager.Player.FlatMagicDamageMod), enemy);
                    default:
                        throw new InvalidSpellTypeException();
                }
            case SpellType.R:
                switch (stagetype)
                {
                    case StageType.Default:
                        return CalcMagicDmg((((ObjectManager.Player.Spellbook.GetSpell(SpellSlot.R).Level + 2) + (0.01 * ObjectManager.Player.FlatMagicDamageMod)) * (enemy.MaxHealth / 100)) * 15, enemy);
                    case StageType.FirstDamage:
                        return CalcMagicDmg(((ObjectManager.Player.Spellbook.GetSpell(SpellSlot.R).Level + 2) + (0.01 * ObjectManager.Player.FlatMagicDamageMod)) * (enemy.MaxHealth / 100), enemy);
                    default:
                        throw new InvalidSpellTypeException();
                }
            default:
                throw new InvalidSpellTypeException();
        }
    }

    private static double Nautilus(Obj_AI_Hero enemy, SpellType type, StageType stagetype)
    {
        switch (type)
        {
            case SpellType.Q:
                return CalcMagicDmg((15 + (ObjectManager.Player.Spellbook.GetSpell(SpellSlot.Q).Level * 45)) + (0.75 * ObjectManager.Player.FlatMagicDamageMod), enemy);
            case SpellType.W:
                return CalcMagicDmg((25 + (ObjectManager.Player.Spellbook.GetSpell(SpellSlot.W).Level * 15)) + (0.40 * ObjectManager.Player.FlatMagicDamageMod), enemy);
            case SpellType.E:
                switch (stagetype)
                {
                    case StageType.Default:
                        return CalcMagicDmg((40 + (ObjectManager.Player.Spellbook.GetSpell(SpellSlot.E).Level * 80)) + (1.0 * ObjectManager.Player.FlatMagicDamageMod), enemy);
                    case StageType.FirstDamage:
                        return CalcMagicDmg((20 + (ObjectManager.Player.Spellbook.GetSpell(SpellSlot.E).Level * 40)) + (0.50 * ObjectManager.Player.FlatMagicDamageMod), enemy);
                    default:
                        throw new InvalidSpellTypeException();
                }
            case SpellType.R:
                return CalcMagicDmg((75 + (ObjectManager.Player.Spellbook.GetSpell(SpellSlot.R).Level * 125)) + (0.80 * ObjectManager.Player.FlatMagicDamageMod), enemy);
            default:
                throw new InvalidSpellTypeException();
        }
    }

    private static double Nidalee(Obj_AI_Hero enemy, SpellType type, StageType stagetype)
    {
        switch (type)
        {
            case SpellType.Q:
                if (ObjectManager.Player.Spellbook.GetSpell(SpellSlot.Q).Name == "JavelinToss")
                {
                    switch (stagetype)
                    {
                        case StageType.Default:
                            return CalcMagicDmg((37 + (ObjectManager.Player.Spellbook.GetSpell(SpellSlot.Q).Level * 100)) + (1.625 * ObjectManager.Player.FlatMagicDamageMod), enemy); // max dmg
                        case StageType.FirstDamage:
                            return CalcMagicDmg((15 + (ObjectManager.Player.Spellbook.GetSpell(SpellSlot.Q).Level * 40)) + (0.65 * ObjectManager.Player.FlatMagicDamageMod), enemy); // min dmg
                        default:
                            throw new InvalidSpellTypeException();
                    }
                }
                else
                {
                    switch (stagetype)
                    {
                        case StageType.Default:
                            return CalcPhysicalDmg((30 + (ObjectManager.Player.Spellbook.GetSpell(SpellSlot.R).Level * 90)) + (3.0 * ObjectManager.Player.FlatPhysicalDamageMod), enemy); // max dmg
                        case StageType.FirstDamage:
                            return CalcPhysicalDmg((10 + (ObjectManager.Player.Spellbook.GetSpell(SpellSlot.R).Level * 30)) + (1.0 * ObjectManager.Player.FlatPhysicalDamageMod), enemy); // base dmg
                        default:
                            throw new InvalidSpellTypeException();
                    }
                }
            case SpellType.W:
                if (ObjectManager.Player.Spellbook.GetSpell(SpellSlot.W).Name == "Bushwhack")
                {
                    return CalcMagicDmg((35 + (ObjectManager.Player.Spellbook.GetSpell(SpellSlot.W).Level * 45)) + (0.4 * ObjectManager.Player.FlatMagicDamageMod), enemy);
                }
                else
                {
                    return CalcMagicDmg((75 + (ObjectManager.Player.Spellbook.GetSpell(SpellSlot.R).Level * 50)) + (0.4 * ObjectManager.Player.FlatMagicDamageMod), enemy);
                }
            case SpellType.E:
                if (ObjectManager.Player.Spellbook.GetSpell(SpellSlot.E).Name == "PrimalSurge")
                {
                    return 0; // no exception as switchting won't change the name directly
                }
                else
                {
                    return CalcMagicDmg((75 + (ObjectManager.Player.Spellbook.GetSpell(SpellSlot.R).Level * 75)) + (0.6 * ObjectManager.Player.FlatMagicDamageMod), enemy);
                }
            case SpellType.R:
                throw new InvalidSpellTypeException();
            default:
                throw new InvalidSpellTypeException();
        }
    }

    private static double Nocturne(Obj_AI_Hero enemy, SpellType type, StageType stagetype)
    {
        switch (type)
        {
            case SpellType.Q:
                return CalcPhysicalDmg((15 + (ObjectManager.Player.Spellbook.GetSpell(SpellSlot.Q).Level * 45)) + (0.75 * ObjectManager.Player.FlatPhysicalDamageMod), enemy);
            case SpellType.W:
                throw new InvalidSpellTypeException();
            case SpellType.E:
                return CalcMagicDmg((ObjectManager.Player.Spellbook.GetSpell(SpellSlot.E).Level * 50) + (1.0 * ObjectManager.Player.FlatMagicDamageMod), enemy);
            case SpellType.R:
                return CalcPhysicalDmg((50 + (ObjectManager.Player.Spellbook.GetSpell(SpellSlot.R).Level * 100)) + (1.2 * ObjectManager.Player.FlatPhysicalDamageMod), enemy);
            default:
                throw new InvalidSpellTypeException();
        }
    }

    private static double Nunu(Obj_AI_Hero enemy, SpellType type, StageType stagetype)
    {
        switch (type)
        {
            case SpellType.Q:
                return (250 + (ObjectManager.Player.Spellbook.GetSpell(SpellSlot.Q).Level * 150));
            case SpellType.W:
                throw new InvalidSpellTypeException();
            case SpellType.E:
                return CalcMagicDmg((40 + (ObjectManager.Player.Spellbook.GetSpell(SpellSlot.E).Level * 45)) + (1.0 * ObjectManager.Player.FlatMagicDamageMod), enemy);
            case SpellType.R:
                switch (stagetype)
                {
                    case StageType.Default:
                        return CalcMagicDmg((375 + (ObjectManager.Player.Spellbook.GetSpell(SpellSlot.R).Level * 250)) + (2.5 * ObjectManager.Player.FlatMagicDamageMod), enemy);
                    case StageType.FirstDamage:
                        return CalcMagicDmg((46.875 + (ObjectManager.Player.Spellbook.GetSpell(SpellSlot.R).Level * 31.25)) + (0.3125 * ObjectManager.Player.FlatMagicDamageMod), enemy);
                    default:
                        throw new InvalidSpellTypeException();
                }
            default:
                throw new InvalidSpellTypeException();
        }
    }

    private static double Olaf(Obj_AI_Hero enemy, SpellType type, StageType stagetype)
    {
        switch (type)
        {
            case SpellType.Q:
                return CalcPhysicalDmg((25 + (ObjectManager.Player.Spellbook.GetSpell(SpellSlot.Q).Level * 45)) + (1.0 * ObjectManager.Player.FlatPhysicalDamageMod), enemy);
            case SpellType.W:
                throw new InvalidSpellTypeException();
            case SpellType.E:
                return (25 + (ObjectManager.Player.Spellbook.GetSpell(SpellSlot.E).Level * 45) + (0.4 * (ObjectManager.Player.FlatPhysicalDamageMod + ObjectManager.Player.BaseAttackDamage)));
            case SpellType.R:
                throw new InvalidSpellTypeException();
            default:
                throw new InvalidSpellTypeException();
        }
    }

    private static double Orianna(Obj_AI_Hero enemy, SpellType type, StageType stageType)
    {
        switch (type)
        {
            case SpellType.Q:
                return CalcMagicDmg((60.0 + (30.0 * ObjectManager.Player.Spellbook.GetSpell(SpellSlot.Q).Level) + (0.5 * ObjectManager.Player.FlatMagicDamageMod)), enemy);
            case SpellType.W:
                return CalcMagicDmg((70.0 + (45.0 * ObjectManager.Player.Spellbook.GetSpell(SpellSlot.W).Level) + (0.7 * ObjectManager.Player.FlatMagicDamageMod)), enemy);
            case SpellType.E:
                return CalcMagicDmg((60.0 + (30.0 * ObjectManager.Player.Spellbook.GetSpell(SpellSlot.E).Level) + (0.3 * ObjectManager.Player.FlatMagicDamageMod)), enemy);
            case SpellType.R:
                return CalcMagicDmg((150.0 + (75.0 * ObjectManager.Player.Spellbook.GetSpell(SpellSlot.R).Level) + (0.7 * ObjectManager.Player.FlatMagicDamageMod)), enemy);
            default:
                throw new InvalidSpellTypeException();
        }
    }

    private static double Pantheon(Obj_AI_Hero enemy, SpellType type, StageType stagetype)
    {
        switch (type)
        {
            case SpellType.Q:
                return CalcPhysicalDmg((25 + (ObjectManager.Player.Spellbook.GetSpell(SpellSlot.Q).Level * 40)) + (1.4 * ObjectManager.Player.FlatPhysicalDamageMod) + (0.5 * ObjectManager.Player.FlatMagicDamageMod), enemy);
            case SpellType.W:
                return CalcMagicDmg((25 + (ObjectManager.Player.Spellbook.GetSpell(SpellSlot.W).Level * 25)) + (1.0 * ObjectManager.Player.FlatMagicDamageMod), enemy);
            case SpellType.E:
                switch (stagetype)
                {
                    case StageType.Default:
                        return CalcPhysicalDmg((20 + (ObjectManager.Player.Spellbook.GetSpell(SpellSlot.E).Level * 60)) + (3.6 * ObjectManager.Player.FlatPhysicalDamageMod), enemy);
                    case StageType.FirstDamage:
                        return CalcPhysicalDmg((6 + (ObjectManager.Player.Spellbook.GetSpell(SpellSlot.E).Level * 20)) + (1.2 * ObjectManager.Player.FlatMagicDamageMod), enemy);
                    default:
                        throw new InvalidSpellTypeException();
                }
            case SpellType.R:
                return CalcMagicDmg((100 + (ObjectManager.Player.Spellbook.GetSpell(SpellSlot.R).Level * 300)) + (1.0 * ObjectManager.Player.FlatMagicDamageMod), enemy);
            default:
                throw new InvalidSpellTypeException();
        }
    }

    private static double Poppy(Obj_AI_Hero enemy, SpellType type, StageType stagetype)
    {
        switch (type)
        {
            case SpellType.Q:
                return CalcMagicDmg((ObjectManager.Player.Spellbook.GetSpell(SpellSlot.Q).Level * 20) + (1.0 * (ObjectManager.Player.FlatPhysicalDamageMod + ObjectManager.Player.BaseAttackDamage)) + (0.6 * ObjectManager.Player.FlatMagicDamageMod) + (0.08 * enemy.MaxHealth), enemy);
            case SpellType.W:
                throw new InvalidSpellTypeException();
            case SpellType.E:
                switch (stagetype)
                {
                    case StageType.Default:
                        return CalcMagicDmg((25 + (ObjectManager.Player.Spellbook.GetSpell(SpellSlot.E).Level * 25)) + (0.4 * ObjectManager.Player.FlatMagicDamageMod), enemy);
                    case StageType.FirstDamage:
                        return CalcMagicDmg((50 + (ObjectManager.Player.Spellbook.GetSpell(SpellSlot.E).Level * 75)) + (0.8 * ObjectManager.Player.FlatMagicDamageMod), enemy);
                    default:
                        throw new InvalidSpellTypeException();
                }
            case SpellType.R:
                throw new InvalidSpellTypeException();
            default:
                throw new InvalidSpellTypeException();
        }
    }

    private static double Quinn(Obj_AI_Hero enemy, SpellType type, StageType stagetype)
    {
        switch (type)
        {
            case SpellType.Q:
                return CalcMagicDmg((30 + (ObjectManager.Player.Spellbook.GetSpell(SpellSlot.Q).Level * 40)) + (0.65 * ObjectManager.Player.FlatPhysicalDamageMod) + (0.5 * ObjectManager.Player.FlatMagicDamageMod), enemy);
            case SpellType.W:
                throw new InvalidSpellTypeException();
            case SpellType.E:
                return CalcMagicDmg((10 + (ObjectManager.Player.Spellbook.GetSpell(SpellSlot.E).Level * 30)) + (0.20 * ObjectManager.Player.FlatPhysicalDamageMod), enemy);
            case SpellType.R:
                return CalcMagicDmg(((70 + (ObjectManager.Player.Spellbook.GetSpell(SpellSlot.R).Level * 50)) + (0.50 * ObjectManager.Player.FlatPhysicalDamageMod)) * (2 - enemy.Health / enemy.MaxHealth), enemy);
            default:
                throw new InvalidSpellTypeException();
        }
    }

    private static double Rammus(Obj_AI_Hero enemy, SpellType type, StageType stagetype)
    {
        switch (type)
        {
            case SpellType.Q:
                return CalcMagicDmg((50 + (ObjectManager.Player.Spellbook.GetSpell(SpellSlot.Q).Level * 50)) + (1.0 * ObjectManager.Player.FlatMagicDamageMod), enemy);
            case SpellType.W:
                return CalcMagicDmg((5 + (ObjectManager.Player.Spellbook.GetSpell(SpellSlot.Q).Level * 10)) + (0.1 * ObjectManager.Player.Armor), enemy);
            case SpellType.E:
                throw new InvalidSpellTypeException();
            case SpellType.R:
                switch (stagetype)
                {
                    case StageType.Default:
                        return CalcMagicDmg((520 + (ObjectManager.Player.Spellbook.GetSpell(SpellSlot.Q).Level * 520)) + (2.4 * ObjectManager.Player.FlatMagicDamageMod), enemy);
                    case StageType.FirstDamage:
                        return CalcMagicDmg((ObjectManager.Player.Spellbook.GetSpell(SpellSlot.Q).Level * 65) + (0.3 * ObjectManager.Player.FlatMagicDamageMod), enemy);
                    default:
                        throw new InvalidSpellTypeException();
                }
            default:
                throw new InvalidSpellTypeException();
        }
    }

    private static double Renekton(Obj_AI_Hero enemy, SpellType type, StageType stagetype)
    {
        switch (type)
        {
            case SpellType.Q:
                switch (stagetype)
                {
                    case StageType.Default:
                        return CalcPhysicalDmg(30 + (ObjectManager.Player.Spellbook.GetSpell(SpellSlot.Q).Level * 30) + ((0.8 * ObjectManager.Player.FlatPhysicalDamageMod)), enemy); // basic q
                    case StageType.FirstDamage:
                        return CalcPhysicalDmg(45 + (ObjectManager.Player.Spellbook.GetSpell(SpellSlot.Q).Level * 45) + ((1.2 * ObjectManager.Player.FlatPhysicalDamageMod)), enemy); // empowered q
                    default:
                        throw new InvalidCastException();
                }
            case SpellType.W:
                switch (stagetype)
                {
                    case StageType.Default:
                        return CalcPhysicalDmg(-10 + (ObjectManager.Player.Spellbook.GetSpell(SpellSlot.W).Level * 20) + ((1.5 * (ObjectManager.Player.FlatPhysicalDamageMod + ObjectManager.Player.BaseAttackDamage))), enemy); // basic w
                    case StageType.FirstDamage:
                        return CalcPhysicalDmg(-15 + (ObjectManager.Player.Spellbook.GetSpell(SpellSlot.W).Level * 30) + ((2.25 * (ObjectManager.Player.FlatPhysicalDamageMod + ObjectManager.Player.BaseAttackDamage))), enemy); // empowered w
                    default:
                        throw new InvalidCastException();
                }
            case SpellType.E:
                switch (stagetype)
                {
                    case StageType.Default:
                        return CalcPhysicalDmg(0 + (ObjectManager.Player.Spellbook.GetSpell(SpellSlot.E).Level * 30) + ((0.9 * (ObjectManager.Player.FlatPhysicalDamageMod))), enemy); // basic e
                    case StageType.FirstDamage:
                        return CalcPhysicalDmg(0 + (ObjectManager.Player.Spellbook.GetSpell(SpellSlot.E).Level * 45) + ((1.35 * (ObjectManager.Player.FlatPhysicalDamageMod))), enemy); // empowered e
                    default:
                        throw new InvalidCastException();
                }
            case SpellType.R:
                switch (stagetype)
                {
                    case StageType.Default:
                        return CalcMagicDmg((450 * ObjectManager.Player.Spellbook.GetSpell(SpellSlot.R).Level) + (1.5 * ObjectManager.Player.FlatMagicDamageMod), enemy); // complete dmg
                    case StageType.FirstDamage:
                        return CalcMagicDmg((30 * ObjectManager.Player.Spellbook.GetSpell(SpellSlot.R).Level) + (0.1 * ObjectManager.Player.FlatMagicDamageMod), enemy); // per sec
                    default:
                        throw new InvalidSpellTypeException();
                }
            default:
                throw new InvalidSpellTypeException();
        }
    }

    private static double Rengar(Obj_AI_Hero enemy, SpellType type, StageType stagetype)
    {
        switch (type)
        {
            case SpellType.Q:
                switch (stagetype)
                {
                    case StageType.Default:
                        return CalcPhysicalDmg(20 + (ObjectManager.Player.Spellbook.GetSpell(SpellSlot.Q).Level * 20) + ((0.95 * (5 * ObjectManager.Player.Spellbook.GetSpell(SpellSlot.Q).Level)) * (ObjectManager.Player.FlatPhysicalDamageMod + ObjectManager.Player.BaseAttackDamage)), enemy); // basic q
                    case StageType.FirstDamage:
                        return CalcPhysicalDmg(10 + (ObjectManager.Player.Level * 10) + (1.5 * ObjectManager.Player.FlatPhysicalDamageMod + ObjectManager.Player.BaseAttackDamage), enemy); // empowered q
                    default:
                        throw new InvalidCastException();
                }
            case SpellType.W:
                switch (stagetype)
                {
                    case StageType.Default:
                        return CalcMagicDmg(20 + (ObjectManager.Player.Spellbook.GetSpell(SpellSlot.W).Level * 30) + (0.8 * ObjectManager.Player.FlatMagicDamageMod), enemy); // basic w
                    case StageType.FirstDamage:
                        return CalcMagicDmg(25 + (ObjectManager.Player.Level * 15) + (0.8 * ObjectManager.Player.FlatMagicDamageMod), enemy); // empowered w
                    default:
                        throw new InvalidCastException();
                }
            case SpellType.E:
                switch (stagetype)
                {
                    case StageType.Default:
                        return CalcPhysicalDmg(50 + (ObjectManager.Player.Spellbook.GetSpell(SpellSlot.E).Level * 50) + (0.7 * ObjectManager.Player.FlatPhysicalDamageMod), enemy); // basic e
                    case StageType.FirstDamage:
                        return CalcPhysicalDmg(25 + (ObjectManager.Player.Level * 25) + (0.7 * ObjectManager.Player.FlatPhysicalDamageMod), enemy); // empowered e
                    default:
                        throw new InvalidCastException();
                }
            case SpellType.R:
                throw new InvalidSpellTypeException();
            default:
                throw new InvalidSpellTypeException();
        }
    }

    private static double Riven(Obj_AI_Hero enemy, SpellType type, StageType stagetype)
    {
        switch (type)
        {
            case SpellType.Q:
                switch (stagetype)
                {
                    case StageType.Default:
                        return CalcPhysicalDmg(30 + (ObjectManager.Player.Spellbook.GetSpell(SpellSlot.Q).Level * 60) + (105 + (ObjectManager.Player.Spellbook.GetSpell(SpellSlot.Q).Level * 15)) * (ObjectManager.Player.FlatPhysicalDamageMod + ObjectManager.Player.BaseAttackDamage), enemy);
                    case StageType.FirstDamage:
                        return CalcPhysicalDmg(-10 + (ObjectManager.Player.Spellbook.GetSpell(SpellSlot.Q).Level * 20) + (0.35 + (ObjectManager.Player.Spellbook.GetSpell(SpellSlot.Q).Level * 0.5)) * (ObjectManager.Player.FlatPhysicalDamageMod + ObjectManager.Player.BaseAttackDamage), enemy);
                    default:
                        throw new InvalidCastException();
                }
            case SpellType.W:
                return CalcPhysicalDmg(20 + (ObjectManager.Player.Spellbook.GetSpell(SpellSlot.R).Level * 30) + (1.0 * ObjectManager.Player.FlatPhysicalDamageMod), enemy);
            case SpellType.E:
                throw new InvalidSpellTypeException();
            case SpellType.R:
                if ((enemy.Health / enemy.MaxHealth) * 100 > 25)
                {
                    return CalcPhysicalDmg(40 + (ObjectManager.Player.Spellbook.GetSpell(SpellSlot.R).Level * 40) + (0.6 * ObjectManager.Player.FlatPhysicalDamageMod), enemy);
                }
                else
                {
                    return CalcPhysicalDmg(120 + (ObjectManager.Player.Spellbook.GetSpell(SpellSlot.R).Level * 120) + (1.8 * ObjectManager.Player.FlatPhysicalDamageMod), enemy);
                }
            default:
                throw new InvalidSpellTypeException();
        }
    }

    private static double Rumble(Obj_AI_Hero enemy, SpellType type, StageType stagetype)
    {
        switch (type)
        {
            case SpellType.Q:
                switch (stagetype)
                {
                    case StageType.Default:
                        return CalcMagicDmg(15 + (ObjectManager.Player.Spellbook.GetSpell(SpellSlot.Q).Level * 60) + (1.0 * ObjectManager.Player.FlatMagicDamageMod), enemy);
                    case StageType.FirstDamage:
                        return CalcMagicDmg(5 + (ObjectManager.Player.Spellbook.GetSpell(SpellSlot.Q).Level * 20) + (0.33 * ObjectManager.Player.FlatMagicDamageMod), enemy);
                    default:
                        throw new InvalidSpellTypeException();
                }
            case SpellType.W:
                throw new InvalidSpellTypeException();
            case SpellType.E:
                return CalcMagicDmg(20 + (ObjectManager.Player.Spellbook.GetSpell(SpellSlot.E).Level * 25) + (0.4 * ObjectManager.Player.FlatMagicDamageMod), enemy);
            case SpellType.R:
                switch (stagetype)
                {
                    case StageType.Default:
                        return CalcMagicDmg(325 + (ObjectManager.Player.Spellbook.GetSpell(SpellSlot.R).Level * 325) + (1.5 * ObjectManager.Player.FlatMagicDamageMod), enemy);
                    case StageType.FirstDamage:
                        return CalcMagicDmg(75 + (ObjectManager.Player.Spellbook.GetSpell(SpellSlot.R).Level * 55) + (0.30 * ObjectManager.Player.FlatMagicDamageMod), enemy);
                    default:
                        throw new InvalidSpellTypeException();
                }
            default:
                throw new InvalidSpellTypeException();
        }
    }

    private static double Ryze(Obj_AI_Hero enemy, SpellType type, StageType stagetype)
    {
        switch (type)
        {
            case SpellType.Q:
                return CalcMagicDmg(35 + (ObjectManager.Player.Spellbook.GetSpell(SpellSlot.Q).Level * 25) + (0.4 * ObjectManager.Player.FlatMagicDamageMod) + (0.065 * ObjectManager.Player.MaxMana), enemy);
            case SpellType.W:
                return CalcMagicDmg(25 + (ObjectManager.Player.Spellbook.GetSpell(SpellSlot.W).Level * 35) + (0.6 * ObjectManager.Player.FlatMagicDamageMod) + (0.045 * ObjectManager.Player.MaxMana), enemy);
            case SpellType.E:
                switch (stagetype)
                {
                    case StageType.Default:
                        return CalcMagicDmg(90 + (ObjectManager.Player.Spellbook.GetSpell(SpellSlot.E).Level * 60) + (1.05 * ObjectManager.Player.FlatMagicDamageMod) + (0.03 * ObjectManager.Player.MaxMana), enemy);
                    case StageType.FirstDamage:
                        return CalcMagicDmg(30 + (ObjectManager.Player.Spellbook.GetSpell(SpellSlot.E).Level * 20) + (0.35 * ObjectManager.Player.FlatMagicDamageMod) + (0.01 * ObjectManager.Player.MaxMana), enemy);
                    default:
                        throw new InvalidSpellTypeException();
                }
            case SpellType.R:
                throw new InvalidSpellTypeException();
            default:
                throw new InvalidSpellTypeException();
        }
    }

    private static double Sejuani(Obj_AI_Hero enemy, SpellType type, StageType stagetype)
    {
        switch (type)
        {
            case SpellType.Q:
                return CalcMagicDmg(10 + (ObjectManager.Player.Spellbook.GetSpell(SpellSlot.Q).Level * 30) + (2 + (ObjectManager.Player.Spellbook.GetSpell(SpellSlot.Q).Level * 2)) * (enemy.MaxHealth / 100), enemy);
            case SpellType.W:
                switch (stagetype)
                {
                    case StageType.Default:
                        return CalcMagicDmg(60 + (ObjectManager.Player.Spellbook.GetSpell(SpellSlot.W).Level * 60) + (0.9 * ObjectManager.Player.FlatMagicDamageMod) + ((ObjectManager.Player.ScriptHealthBonus / 100) * 10), enemy);
                    case StageType.FirstDamage:
                        return CalcMagicDmg(10 + (ObjectManager.Player.Spellbook.GetSpell(SpellSlot.W).Level * 10) + (0.15 * ObjectManager.Player.FlatMagicDamageMod) + ((ObjectManager.Player.ScriptHealthBonus / 100) * 0.25), enemy);
                    default:
                        throw new InvalidSpellTypeException();
                }
            case SpellType.E:
                return CalcMagicDmg(10 + (ObjectManager.Player.Spellbook.GetSpell(SpellSlot.E).Level * 50) + (0.5 * ObjectManager.Player.FlatMagicDamageMod), enemy);
            case SpellType.R:
                return CalcMagicDmg(50 + (ObjectManager.Player.Spellbook.GetSpell(SpellSlot.R).Level * 100) + (0.8 * ObjectManager.Player.FlatMagicDamageMod), enemy);
            default:
                throw new InvalidSpellTypeException();
        }
    }

    private static double Shaco(Obj_AI_Hero enemy, SpellType type, StageType stagetype)
    {
        switch (type)
        {
            case SpellType.Q:
                return CalcPhysicalDmg(0.20 + (ObjectManager.Player.Spellbook.GetSpell(SpellSlot.Q).Level * 0.20) * (ObjectManager.Player.FlatPhysicalDamageMod + ObjectManager.Player.BaseAbilityDamage), enemy);
            case SpellType.W:
                switch (stagetype)
                {
                    case StageType.Default:
                        return CalcMagicDmg(20 + (ObjectManager.Player.Spellbook.GetSpell(SpellSlot.W).Level * 15) + (0.2 * ObjectManager.Player.FlatMagicDamageMod), enemy);
                    case StageType.FirstDamage:
                        return CalcMagicDmg(200 + (ObjectManager.Player.Spellbook.GetSpell(SpellSlot.W).Level * 135) + (1.8 * ObjectManager.Player.FlatMagicDamageMod), enemy);
                    default:
                        throw new InvalidSpellTypeException();
                }
            case SpellType.E:
                return CalcMagicDmg(10 + (ObjectManager.Player.Spellbook.GetSpell(SpellSlot.E).Level * 40) + (1.0 * ObjectManager.Player.FlatMagicDamageMod) + (1.0 * ObjectManager.Player.FlatPhysicalDamageMod), enemy);
            case SpellType.R:
                return CalcMagicDmg(150 + (ObjectManager.Player.Spellbook.GetSpell(SpellSlot.R).Level * 150) + (1.0 * ObjectManager.Player.FlatMagicDamageMod), enemy);
            default:
                throw new InvalidSpellTypeException();
        }
    }

    private static double Shen(Obj_AI_Hero enemy, SpellType type, StageType stagetype)
    {
        switch (type)
        {
            case SpellType.Q:
                return CalcMagicDmg(20 + (ObjectManager.Player.Spellbook.GetSpell(SpellSlot.Q).Level * 40) + (0.6 * ObjectManager.Player.FlatMagicDamageMod), enemy);
            case SpellType.W:
                throw new InvalidSpellTypeException();
            case SpellType.E:
                return CalcMagicDmg(15 + (ObjectManager.Player.Spellbook.GetSpell(SpellSlot.E).Level * 35) + (0.5 * ObjectManager.Player.FlatMagicDamageMod), enemy);
            case SpellType.R:
                throw new InvalidSpellTypeException();
            default:
                throw new InvalidSpellTypeException();
        }
    }

    private static double Shyvana(Obj_AI_Hero enemy, SpellType type, StageType stagetype)
    {
        switch (type)
        {
            case SpellType.Q:
                return CalcPhysicalDmg(0.75 + (ObjectManager.Player.Spellbook.GetSpell(SpellSlot.Q).Level * 0.05) * (ObjectManager.Player.FlatPhysicalDamageMod + ObjectManager.Player.BaseAbilityDamage), enemy);
            case SpellType.W:
                switch (stagetype)
                {
                    case StageType.Default:
                        return CalcMagicDmg(35 + (ObjectManager.Player.Spellbook.GetSpell(SpellSlot.W).Level * 105) + (1.4 * ObjectManager.Player.FlatPhysicalDamageMod), enemy);
                    case StageType.FirstDamage:
                        return CalcMagicDmg(5 + (ObjectManager.Player.Spellbook.GetSpell(SpellSlot.W).Level * 15) + (0.2 * ObjectManager.Player.FlatPhysicalDamageMod), enemy);
                    default:
                        throw new InvalidCastException();
                }
            case SpellType.E:
                return CalcMagicDmg(20 + (ObjectManager.Player.Spellbook.GetSpell(SpellSlot.E).Level * 40) + (0.6 * ObjectManager.Player.FlatMagicDamageMod), enemy);
            case SpellType.R:
                return CalcMagicDmg(50 + (ObjectManager.Player.Spellbook.GetSpell(SpellSlot.R).Level * 125) + (0.7 * ObjectManager.Player.FlatMagicDamageMod), enemy);
            default:
                throw new InvalidSpellTypeException();
        }
    }

    private static double Singed(Obj_AI_Hero enemy, SpellType type, StageType stagetype)
    {
        switch (type)
        {
            case SpellType.Q:
                switch (stagetype)
                {
                    case StageType.FirstDamage:
                        return CalcMagicDmg((10 + (ObjectManager.Player.Spellbook.GetSpell(SpellSlot.Q).Level * 12)) + (0.3 * ObjectManager.Player.FlatMagicDamageMod), enemy); // per sec
                    case StageType.Default:
                        return CalcMagicDmg((30 + (ObjectManager.Player.Spellbook.GetSpell(SpellSlot.Q).Level * 36)) + (0.9 * ObjectManager.Player.FlatMagicDamageMod), enemy); // complete dmg
                    default:
                        throw new InvalidSpellTypeException();
                }
            case SpellType.W:
                throw new InvalidSpellTypeException();
            case SpellType.E:
                return CalcMagicDmg((35 + (ObjectManager.Player.Spellbook.GetSpell(SpellSlot.E).Level * 45)) + (0.75 * ObjectManager.Player.FlatMagicDamageMod), enemy);
            case SpellType.R:
                throw new InvalidSpellTypeException();
            default:
                throw new InvalidSpellTypeException();
        }
    }

    private static double Sion(Obj_AI_Hero enemy, SpellType type, StageType stagetype)
    {
        switch (type)
        {
            case SpellType.Q:
                return CalcMagicDmg((12 + (ObjectManager.Player.Spellbook.GetSpell(SpellSlot.Q).Level * 57.5)) + (0.9 * ObjectManager.Player.FlatMagicDamageMod), enemy);
            case SpellType.W:
                return CalcMagicDmg((50 + (ObjectManager.Player.Spellbook.GetSpell(SpellSlot.W).Level * 50)) + (0.9 * ObjectManager.Player.FlatMagicDamageMod), enemy);
            case SpellType.E:
                throw new InvalidSpellTypeException();
            case SpellType.R:
                throw new InvalidSpellTypeException();
            default:
                throw new InvalidSpellTypeException();
        }
    }

    private static double Sivir(Obj_AI_Hero enemy, SpellType type, StageType stagetype)
    {
        switch (type)
        {
            case SpellType.Q:
                return CalcPhysicalDmg((5 + (ObjectManager.Player.Spellbook.GetSpell(SpellSlot.Q).Level * 20)) + ((0.6 + (0.1 * ObjectManager.Player.Spellbook.GetSpell(SpellSlot.Q).Level)) * ObjectManager.Player.FlatPhysicalDamageMod) + (0.5 * ObjectManager.Player.FlatMagicDamageMod), enemy); // basic physical dmg
            case SpellType.W:
                return CalcPhysicalDmg((ObjectManager.Player.BaseAttackDamage + ObjectManager.Player.FlatPhysicalDamageMod) * (0.45 + (0.05 * ObjectManager.Player.Spellbook.GetSpell(SpellSlot.W).Level)), enemy); // for each of 3
            case SpellType.E:
                throw new InvalidSpellTypeException();
            case SpellType.R:
                throw new InvalidSpellTypeException();
            default:
                throw new InvalidSpellTypeException();
        }
    }

    private static double Skarner(Obj_AI_Hero enemy, SpellType type, StageType stagetype)
    {
        switch (type)
        {
            case SpellType.Q:
                return CalcPhysicalDmg((10 + (ObjectManager.Player.Spellbook.GetSpell(SpellSlot.Q).Level * 15)) + (0.8 * ObjectManager.Player.FlatPhysicalDamageMod), enemy); // basic bonus dmg
            case SpellType.W:
                throw new InvalidSpellTypeException();
            case SpellType.E:
                return CalcMagicDmg((40 + (ObjectManager.Player.Spellbook.GetSpell(SpellSlot.E).Level * 40)) + (0.4 * ObjectManager.Player.FlatMagicDamageMod), enemy);
            case SpellType.R:
                return CalcMagicDmg((100 + (ObjectManager.Player.Spellbook.GetSpell(SpellSlot.R).Level * 100)) + (1.0 * ObjectManager.Player.FlatMagicDamageMod), enemy);
            default:
                throw new InvalidSpellTypeException();
        }
    }

    private static double Sona(Obj_AI_Hero enemy, SpellType type, StageType stagetype)
    {
        switch (type)
        {
            case SpellType.Q:
                return CalcMagicDmg((ObjectManager.Player.Spellbook.GetSpell(SpellSlot.Q).Level * 50) + (0.5 * ObjectManager.Player.FlatMagicDamageMod), enemy);
            case SpellType.W:
                throw new InvalidSpellTypeException();
            case SpellType.E:
                throw new InvalidSpellTypeException();
            case SpellType.R:
                return CalcMagicDmg((50 + (ObjectManager.Player.Spellbook.GetSpell(SpellSlot.R).Level * 100)) + (0.5 * ObjectManager.Player.FlatMagicDamageMod), enemy);
            default:
                throw new InvalidSpellTypeException();
        }
    }

    private static double Soraka(Obj_AI_Hero enemy, SpellType type, StageType stagetype)
    {
        switch (type)
        {
            case SpellType.Q:
                return CalcMagicDmg((35 + (ObjectManager.Player.Spellbook.GetSpell(SpellSlot.Q).Level * 25)) + (0.4 * ObjectManager.Player.FlatMagicDamageMod), enemy);
            case SpellType.W:
                throw new InvalidSpellTypeException();
            case SpellType.E:
                return CalcMagicDmg((10 + (ObjectManager.Player.Spellbook.GetSpell(SpellSlot.E).Level * 30)) + (0.4 * ObjectManager.Player.FlatMagicDamageMod) + (0.5 * ObjectManager.Player.MaxMana), enemy);
            case SpellType.R:
                throw new InvalidSpellTypeException();
            default:
                throw new InvalidSpellTypeException();
        }
    }


    private static double Swain(Obj_AI_Hero enemy, SpellType type, StageType stagetype)
    {
        switch (type)
        {
            case SpellType.Q:
                return CalcMagicDmg((10 + (ObjectManager.Player.Spellbook.GetSpell(SpellSlot.Q).Level * 15)) + (0.3 * ObjectManager.Player.FlatMagicDamageMod), enemy);
            case SpellType.W:
                return CalcMagicDmg((40 + (ObjectManager.Player.Spellbook.GetSpell(SpellSlot.W).Level * 40)) + (0.7 * ObjectManager.Player.FlatMagicDamageMod), enemy);
            case SpellType.E:
                return CalcMagicDmg((35 + (ObjectManager.Player.Spellbook.GetSpell(SpellSlot.E).Level * 40)) + (0.8 * ObjectManager.Player.FlatMagicDamageMod), enemy);
            case SpellType.R:
                return CalcMagicDmg((30 + (ObjectManager.Player.Spellbook.GetSpell(SpellSlot.R).Level * 20)) + (0.2 * ObjectManager.Player.FlatMagicDamageMod), enemy);//x sec
            default:
                throw new InvalidSpellTypeException();
        }
    }

    private static double Syndra(Obj_AI_Hero enemy, SpellType type, StageType stagetype)
    {
        switch (type)
        {
            case SpellType.Q:
                return CalcMagicDmg((30 + (ObjectManager.Player.Spellbook.GetSpell(SpellSlot.Q).Level * 40)) + (0.7 * ObjectManager.Player.FlatMagicDamageMod), enemy);
            case SpellType.W:
                return CalcMagicDmg((40 + (ObjectManager.Player.Spellbook.GetSpell(SpellSlot.W).Level * 40)) + (0.7 * ObjectManager.Player.FlatMagicDamageMod), enemy);
            case SpellType.E:
                return CalcMagicDmg((25 + (ObjectManager.Player.Spellbook.GetSpell(SpellSlot.E).Level * 45)) + (0.4 * ObjectManager.Player.FlatMagicDamageMod), enemy);
            case SpellType.R:
                switch (stagetype)
                {
                    case StageType.Default:
                        return CalcMagicDmg((45 + (ObjectManager.Player.Spellbook.GetSpell(SpellSlot.R).Level * 45)) + (0.2 * ObjectManager.Player.FlatMagicDamageMod), enemy); // for each orb
                    case StageType.FirstDamage:
                        return CalcMagicDmg((135 + (ObjectManager.Player.Spellbook.GetSpell(SpellSlot.R).Level * 135)) + (0.6 * ObjectManager.Player.FlatMagicDamageMod), enemy); // minimum dmg (3 balls)
                    default:
                        throw new InvalidSpellTypeException();
                }
            default:
                throw new InvalidSpellTypeException();
        }
    }

    private static double Talon(Obj_AI_Hero enemy, SpellType type, StageType stagetype)
    {
        switch (type)
        {
            case SpellType.Q:
                return CalcPhysicalDmg((0 + (ObjectManager.Player.Spellbook.GetSpell(SpellSlot.Q).Level * 40)) + (1.3 * (ObjectManager.Player.FlatPhysicalDamageMod)), enemy); // bonus dmg
            case SpellType.W:
                return CalcPhysicalDmg((5 + (ObjectManager.Player.Spellbook.GetSpell(SpellSlot.W).Level * 25)) + (0.60 * (ObjectManager.Player.FlatPhysicalDamageMod)), enemy);
            case SpellType.E:
                throw new InvalidSpellTypeException();
            case SpellType.R:
                return CalcPhysicalDmg((70 + (ObjectManager.Player.Spellbook.GetSpell(SpellSlot.R).Level * 50)) + (0.75 * (ObjectManager.Player.FlatPhysicalDamageMod)), enemy);
            default:
                throw new InvalidSpellTypeException();
        }
    }

    private static double Taric(Obj_AI_Hero enemy, SpellType type, StageType stagetype)
    {
        switch (type)
        {
            case SpellType.Q:
                throw new InvalidSpellTypeException();
            case SpellType.W:
                return CalcMagicDmg((ObjectManager.Player.Spellbook.GetSpell(SpellSlot.W).Level * 40) + (0.2 * ObjectManager.Player.Armor), enemy);
            case SpellType.E:
                return CalcMagicDmg((10 + (ObjectManager.Player.Spellbook.GetSpell(SpellSlot.E).Level * 30)) + (0.2 * ObjectManager.Player.FlatMagicDamageMod), enemy); // min e dmg
            case SpellType.R:
                return CalcMagicDmg((50 + (ObjectManager.Player.Spellbook.GetSpell(SpellSlot.R).Level * 100)) + (0.5 * ObjectManager.Player.FlatMagicDamageMod), enemy);
            default:
                throw new InvalidSpellTypeException();
        }
    }

    private static double Teemo/*Satan*/(Obj_AI_Hero enemy, SpellType type, StageType stagetype)
    {
        switch (type)
        {
            case SpellType.Q:
                return CalcMagicDmg((35 + (ObjectManager.Player.Spellbook.GetSpell(SpellSlot.Q).Level * 45)) + (0.80 * ObjectManager.Player.FlatMagicDamageMod), enemy);
            case SpellType.W:
                throw new InvalidSpellTypeException();
            case SpellType.E:
                return CalcMagicDmg((0 + (ObjectManager.Player.Spellbook.GetSpell(SpellSlot.E).Level * 34)) + (0.7 * ObjectManager.Player.FlatMagicDamageMod), enemy); // total dmg for one hit
            case SpellType.R:
                return CalcMagicDmg((75 + (ObjectManager.Player.Spellbook.GetSpell(SpellSlot.R).Level * 125)) + (0.5 * ObjectManager.Player.FlatMagicDamageMod), enemy);
            default:
                throw new InvalidSpellTypeException();
        }
    }

    private static double Thresh(Obj_AI_Hero enemy, SpellType type, StageType stagetype)
    {
        switch (type)
        {
            case SpellType.Q:
                return CalcMagicDmg((40 + (ObjectManager.Player.Spellbook.GetSpell(SpellSlot.Q).Level * 40)) + (0.50 * ObjectManager.Player.FlatMagicDamageMod), enemy);
            case SpellType.W:
                throw new InvalidSpellTypeException();
            case SpellType.E:
                return CalcMagicDmg((35 + (ObjectManager.Player.Spellbook.GetSpell(SpellSlot.E).Level * 30)) + (0.4 * ObjectManager.Player.FlatMagicDamageMod), enemy);
            case SpellType.R:
                return CalcMagicDmg((100 + (ObjectManager.Player.Spellbook.GetSpell(SpellSlot.R).Level * 150)) + (1.0 * ObjectManager.Player.FlatMagicDamageMod), enemy);
            default:
                throw new InvalidSpellTypeException();
        }
    }

    private static double Tristana(Obj_AI_Hero enemy, SpellType type, StageType stagetype)
    {
        switch (type)
        {
            case SpellType.Q:
                throw new InvalidSpellTypeException();
            case SpellType.W:
                return CalcMagicDmg((25 + (ObjectManager.Player.Spellbook.GetSpell(SpellSlot.W).Level * 45)) + (0.80 * ObjectManager.Player.FlatMagicDamageMod), enemy);
            case SpellType.E:
                switch (stagetype)
                {
                    case StageType.Default:
                        return CalcMagicDmg((70 + (ObjectManager.Player.Spellbook.GetSpell(SpellSlot.E).Level * 40)) + (1.0 * ObjectManager.Player.FlatMagicDamageMod), enemy); // active
                    case StageType.FirstDamage:
                        return CalcMagicDmg((25 + (ObjectManager.Player.Spellbook.GetSpell(SpellSlot.E).Level * 25)) + (0.25 * ObjectManager.Player.FlatMagicDamageMod), enemy); // passive
                    default:
                        throw new InvalidSpellTypeException();
                }
            case SpellType.R:
                return CalcMagicDmg((200 + (ObjectManager.Player.Spellbook.GetSpell(SpellSlot.R).Level * 100)) + (1.5 * ObjectManager.Player.FlatMagicDamageMod), enemy);
            default:
                throw new InvalidSpellTypeException();
        }
    }

    private static double Trundle(Obj_AI_Hero enemy, SpellType type, StageType stagetype)
    {
        switch (type)
        {
            case SpellType.Q:
                return CalcPhysicalDmg((0 + (ObjectManager.Player.Spellbook.GetSpell(SpellSlot.Q).Level * 20)) + ((0.95 + (0.05 * ObjectManager.Player.Spellbook.GetSpell(SpellSlot.Q).Level)) * ObjectManager.Player.FlatPhysicalDamageMod), enemy);
            case SpellType.W:
                throw new InvalidSpellTypeException();
            case SpellType.E:
                throw new InvalidSpellTypeException();
            case SpellType.R:
                double basepercent = 16 + (4 * ObjectManager.Player.Spellbook.GetSpell(SpellSlot.R).Level);
                double additionalpercentper100ap = 0;
                if (ObjectManager.Player.FlatMagicDamageMod < 100)
                {
                    additionalpercentper100ap = 0;
                }
                else if (ObjectManager.Player.FlatMagicDamageMod.IsBetween(100, 199))
                {
                    additionalpercentper100ap = 2;
                }
                else if (ObjectManager.Player.FlatMagicDamageMod.IsBetween(200, 299))
                {
                    additionalpercentper100ap = 4;
                }
                else if (ObjectManager.Player.FlatMagicDamageMod.IsBetween(300, 399))
                {
                    additionalpercentper100ap = 6;
                }
                else if (ObjectManager.Player.FlatMagicDamageMod.IsBetween(400, 499))
                {
                    additionalpercentper100ap = 8;
                }
                else if (ObjectManager.Player.FlatMagicDamageMod.IsBetween(500, 599))
                {
                    additionalpercentper100ap = 10;
                }
                else if (ObjectManager.Player.FlatMagicDamageMod.IsBetween(600, 699))
                {
                    additionalpercentper100ap = 12;
                }
                else if (ObjectManager.Player.FlatMagicDamageMod.IsBetween(700, 799))
                {
                    additionalpercentper100ap = 14;
                }
                else if (ObjectManager.Player.FlatMagicDamageMod.IsBetween(800, 899))
                {
                    additionalpercentper100ap = 16;
                }
                else if (ObjectManager.Player.FlatMagicDamageMod >= 900)
                {
                    additionalpercentper100ap = 18;
                }
                double healthbase = enemy.MaxHealth / 100 * (basepercent + additionalpercentper100ap);
                return CalcMagicDmg(healthbase, enemy);
            default:
                throw new InvalidSpellTypeException();
        }
    }

    private static double Tryndamere(Obj_AI_Hero enemy, SpellType type, StageType stagetype)
    {
        switch (type)
        {
            case SpellType.Q:
                throw new InvalidSpellTypeException();
            case SpellType.W:
                throw new InvalidSpellTypeException();
            case SpellType.E:
                return CalcPhysicalDmg((40 + (ObjectManager.Player.Spellbook.GetSpell(SpellSlot.E).Level * 30)) + (1.2 * (ObjectManager.Player.FlatPhysicalDamageMod)) + (1.0 * ObjectManager.Player.FlatMagicDamageMod), enemy);
            case SpellType.R:
                throw new InvalidSpellTypeException();
            default:
                throw new InvalidSpellTypeException();
        }
    }

    private static double TwistedFate(Obj_AI_Hero enemy, SpellType type, StageType stagetype)
    {
        switch (type)
        {
            case SpellType.Q:
                return CalcMagicDmg((10 + (ObjectManager.Player.Spellbook.GetSpell(SpellSlot.Q).Level * 50)) + (0.65 * ObjectManager.Player.FlatMagicDamageMod), enemy);
            case SpellType.W:
                switch (stagetype)
                {
                    case StageType.Default:
                        throw new InvalidSpellTypeException(); // W itself deals no dmg, card must be specified
                    case StageType.FirstDamage:
                        return CalcMagicDmg((20 + (ObjectManager.Player.Spellbook.GetSpell(SpellSlot.W).Level * 20)) + (0.5 * ObjectManager.Player.FlatMagicDamageMod) + (ObjectManager.Player.BaseAttackDamage + ObjectManager.Player.FlatPhysicalDamageMod), enemy); // Blue Card
                    case StageType.SecondDamage:
                        return CalcMagicDmg((15 + (ObjectManager.Player.Spellbook.GetSpell(SpellSlot.W).Level * 15)) + (0.5 * ObjectManager.Player.FlatMagicDamageMod) + (ObjectManager.Player.BaseAttackDamage + ObjectManager.Player.FlatPhysicalDamageMod), enemy); // Red Card
                    case StageType.ThirdDamage:
                        return CalcMagicDmg((7.5 + (ObjectManager.Player.Spellbook.GetSpell(SpellSlot.W).Level * 7.5)) + (0.5 * ObjectManager.Player.FlatMagicDamageMod) + (ObjectManager.Player.BaseAttackDamage + ObjectManager.Player.FlatPhysicalDamageMod), enemy); // Gold Card
                    default:
                        throw new InvalidSpellTypeException();
                }
            case SpellType.E:
                return CalcMagicDmg((30 + (ObjectManager.Player.Spellbook.GetSpell(SpellSlot.E).Level * 25)) + (0.5 * ObjectManager.Player.FlatMagicDamageMod), enemy);
            case SpellType.R:
                throw new InvalidSpellTypeException();
            default:
                throw new InvalidSpellTypeException();
        }
    }

    private static double Twitch(Obj_AI_Hero enemy, SpellType type, StageType stagetype)
    {
        switch (type)
        {
            case SpellType.Q:
                throw new InvalidSpellTypeException();
            case SpellType.W:
                throw new InvalidSpellTypeException();
            case SpellType.E:
                double basedmg = CalcPhysicalDmg(5 + (15 * ObjectManager.Player.Spellbook.GetSpell(SpellSlot.E).Level), enemy);
                double perstack = CalcPhysicalDmg(10 + (5 * ObjectManager.Player.Spellbook.GetSpell(SpellSlot.E).Level) + (0.2 * ObjectManager.Player.FlatMagicDamageMod) + (0.25 * ObjectManager.Player.FlatPhysicalDamageMod), enemy);
                switch (stagetype)
                {
                    case StageType.Default:
                        return basedmg + (5 * perstack); // complete dmg 5 stacks
                    case StageType.FirstDamage:
                        return basedmg + perstack; // foreach stack
                    default:
                        throw new InvalidSpellTypeException();
                }
            case SpellType.R:
                throw new InvalidSpellTypeException();
            default:
                throw new InvalidSpellTypeException();
        }
    }

    private static double Udyr(Obj_AI_Hero enemy, SpellType type, StageType stagetype)
    {
        switch (type)
        {
            case SpellType.Q:
                double percentadbonus = 1.1 + (ObjectManager.Player.Spellbook.GetSpell(SpellSlot.Q).Level * 0.1);
                return CalcPhysicalDmg((-20 + (ObjectManager.Player.Spellbook.GetSpell(SpellSlot.Q).Level * 50)) + (percentadbonus * (ObjectManager.Player.BaseAttackDamage + ObjectManager.Player.FlatPhysicalDamageMod)), enemy);
            case SpellType.W:
                throw new InvalidSpellTypeException();
            case SpellType.E:
                throw new InvalidSpellTypeException();
            case SpellType.R:
                return CalcMagicDmg((25 + (ObjectManager.Player.Spellbook.GetSpell(SpellSlot.R).Level * 50)) + (1.25 * ObjectManager.Player.FlatMagicDamageMod), enemy);
            default:
                throw new InvalidSpellTypeException();
        }
    }

    private static double Urgot(Obj_AI_Hero enemy, SpellType type, StageType stagetype)
    {
        switch (type)
        {
            case SpellType.Q:
                return CalcPhysicalDmg((ObjectManager.Player.Spellbook.GetSpell(SpellSlot.Q).Level * 30) - 20 + (0.85 * (ObjectManager.Player.BaseAttackDamage + ObjectManager.Player.FlatPhysicalDamageMod)), enemy);
            case SpellType.W:
                throw new InvalidSpellTypeException();
            case SpellType.E:
                return CalcPhysicalDmg((20 + (ObjectManager.Player.Spellbook.GetSpell(SpellSlot.E).Level * 55)) + (0.60 * (ObjectManager.Player.FlatPhysicalDamageMod)), enemy);
            case SpellType.R:
                throw new InvalidSpellTypeException();
            default:
                throw new InvalidSpellTypeException();
        }
    }

    private static double Varus(Obj_AI_Hero enemy, SpellType type, StageType stagetype)
    {
        switch (type)
        {
            case SpellType.Q:
                return CalcPhysicalDmg((-40 + (ObjectManager.Player.Spellbook.GetSpell(SpellSlot.Q).Level * 55)) + (1.6 * (ObjectManager.Player.BaseAttackDamage + ObjectManager.Player.FlatPhysicalDamageMod)), enemy); // max dmg, first target
            case SpellType.W:
                return CalcMagicDmg((6 + (ObjectManager.Player.Spellbook.GetSpell(SpellSlot.W).Level * 4)) + (0.25 * ObjectManager.Player.FlatMagicDamageMod), enemy); // passive magic dmg
            case SpellType.E:
                return CalcPhysicalDmg((30 + (ObjectManager.Player.Spellbook.GetSpell(SpellSlot.E).Level * 35)) + (0.60 * ObjectManager.Player.FlatPhysicalDamageMod), enemy);
            case SpellType.R:
                return CalcMagicDmg((50 + (ObjectManager.Player.Spellbook.GetSpell(SpellSlot.R).Level * 100)) + (1.0 * ObjectManager.Player.FlatMagicDamageMod), enemy);
            default:
                throw new InvalidSpellTypeException();
        }
    }

    private static double Vayne(Obj_AI_Hero enemy, SpellType type, StageType stagetype)
    {
        switch (type)
        {
            case SpellType.Q:
                double percentofbonusad = 0.25 + (0.05 * ObjectManager.Player.Spellbook.GetSpell(SpellSlot.Q).Level);
                return CalcPhysicalDmg(percentofbonusad * (ObjectManager.Player.BaseAttackDamage + ObjectManager.Player.FlatPhysicalDamageMod), enemy); // ony the bonus dmg
            case SpellType.W:
                double flattruedmg = 10 + (10 * ObjectManager.Player.Spellbook.GetSpell(SpellSlot.W).Level);
                double percentofenemyhp = 3 + (ObjectManager.Player.Spellbook.GetSpell(SpellSlot.W).Level);
                return flattruedmg + ((enemy.MaxHealth / 100) * percentofenemyhp);
            case SpellType.E:
                switch (stagetype)
                {
                    case StageType.Default:
                        return CalcPhysicalDmg((20 + (ObjectManager.Player.Spellbook.GetSpell(SpellSlot.E).Level * 70)) + (1.0 * ObjectManager.Player.FlatPhysicalDamageMod), enemy); // Damage when knock + against wall
                    case StageType.FirstDamage:
                        return CalcPhysicalDmg((10 + (ObjectManager.Player.Spellbook.GetSpell(SpellSlot.E).Level * 35)) + (0.5 * ObjectManager.Player.FlatPhysicalDamageMod), enemy); // Damage when knock starts
                    default:
                        throw new InvalidSpellTypeException();
                }
            case SpellType.R:
                throw new InvalidSpellTypeException();
            default:
                throw new InvalidSpellTypeException();
        }
    }

    private static double Veigar(Obj_AI_Hero enemy, SpellType type, StageType stagetype)
    {
        switch (type)
        {
            case SpellType.Q:
                return CalcMagicDmg((35 + (ObjectManager.Player.Spellbook.GetSpell(SpellSlot.Q).Level * 45)) + (0.60 * ObjectManager.Player.FlatMagicDamageMod), enemy);
            case SpellType.W:
                return CalcMagicDmg((70 + (ObjectManager.Player.Spellbook.GetSpell(SpellSlot.W).Level * 50)) + (1.0 * ObjectManager.Player.FlatMagicDamageMod), enemy);
            case SpellType.E:
                throw new InvalidSpellTypeException();
            case SpellType.R:
                return CalcMagicDmg((125 + (ObjectManager.Player.Spellbook.GetSpell(SpellSlot.R).Level * 125)) + (1.2 * ObjectManager.Player.FlatMagicDamageMod) + (0.8 * enemy.FlatMagicDamageMod), enemy);
            default:
                throw new InvalidSpellTypeException();
        }
    }

    private static double Velkoz(Obj_AI_Hero enemy, SpellType type, StageType stagetype)
    {
        switch (type)
        {
            case SpellType.Q:
                return CalcMagicDmg((40 + (ObjectManager.Player.Spellbook.GetSpell(SpellSlot.Q).Level * 40)) + (0.60 * ObjectManager.Player.FlatMagicDamageMod), enemy);
            case SpellType.W:
                switch (stagetype)
                {
                    case StageType.Default:
                        return CalcMagicDmg((25 + (ObjectManager.Player.Spellbook.GetSpell(SpellSlot.W).Level * 50)) + (0.625 * ObjectManager.Player.FlatMagicDamageMod), enemy); // complete dmg
                    case StageType.FirstDamage:
                        return CalcMagicDmg((10 + (ObjectManager.Player.Spellbook.GetSpell(SpellSlot.W).Level * 20)) + (0.25 * ObjectManager.Player.FlatMagicDamageMod), enemy); // first dmg
                    case StageType.SecondDamage:
                        return CalcMagicDmg((15 + (ObjectManager.Player.Spellbook.GetSpell(SpellSlot.W).Level * 30)) + (0.375 * ObjectManager.Player.FlatMagicDamageMod), enemy); // detonation
                    default:
                        throw new InvalidSpellTypeException();
                }
            case SpellType.E:
                return CalcMagicDmg((40 + (ObjectManager.Player.Spellbook.GetSpell(SpellSlot.E).Level * 30)) + (0.50 * ObjectManager.Player.FlatMagicDamageMod), enemy);
            case SpellType.R:
                return CalcMagicDmg((30 + (ObjectManager.Player.Spellbook.GetSpell(SpellSlot.R).Level * 20)) + (0.60 * ObjectManager.Player.FlatMagicDamageMod), enemy); //x 0,25sec
            default:
                throw new InvalidSpellTypeException();
        }
    }

    private static double Vi(Obj_AI_Hero enemy, SpellType type, StageType stagetype)
    {
        switch (type)
        {
            case SpellType.Q:
                return CalcPhysicalDmg((25 + (ObjectManager.Player.Spellbook.GetSpell(SpellSlot.Q).Level * 25)) + (0.80 * (ObjectManager.Player.FlatPhysicalDamageMod)), enemy);
            case SpellType.W:
                double percentage = 2.5 * (1.5 * ObjectManager.Player.Spellbook.GetSpell(SpellSlot.W).Level);
                double bonusadpercentage = percentage + (ObjectManager.Player.FlatPhysicalDamageMod / 34);
                return (enemy.MaxHealth / 100 * bonusadpercentage);
            case SpellType.E:
                return CalcPhysicalDmg((-10 + (ObjectManager.Player.Spellbook.GetSpell(SpellSlot.E).Level * 15)) + (0.70 * ObjectManager.Player.FlatMagicDamageMod) + (1.15 * ObjectManager.Player.FlatPhysicalDamageMod), enemy);
            case SpellType.R:
                return CalcPhysicalDmg((75 + (ObjectManager.Player.Spellbook.GetSpell(SpellSlot.R).Level * 125)) + (1.4 * ObjectManager.Player.FlatPhysicalDamageMod), enemy);
            default:
                throw new InvalidSpellTypeException();
        }
    }

    private static double Viktor(Obj_AI_Hero enemy, SpellType type, StageType stagetype)
    {
        switch (type)
        {
            case SpellType.Q:
                return CalcPhysicalDmg((55 + (ObjectManager.Player.Spellbook.GetSpell(SpellSlot.Q).Level * 35) + (0.60 * ObjectManager.Player.FlatMagicDamageMod)), enemy);
            case SpellType.W:
                throw new InvalidSpellTypeException();
            case SpellType.E:
                return CalcMagicDmg((25 + (ObjectManager.Player.Spellbook.GetSpell(SpellSlot.E).Level * 45)) + (0.70 * ObjectManager.Player.FlatMagicDamageMod), enemy);
            case SpellType.R:
                switch (stagetype)
                {
                    case StageType.Default:
                        return CalcMagicDmg((70 + (ObjectManager.Player.Spellbook.GetSpell(SpellSlot.R).Level * 120)) + (0.79 * ObjectManager.Player.FlatMagicDamageMod), enemy); // Total Initial Damage (initial + first dot)
                    case StageType.FirstDamage:
                        return CalcMagicDmg((50 + (ObjectManager.Player.Spellbook.GetSpell(SpellSlot.R).Level * 100)) + (0.55 * ObjectManager.Player.FlatMagicDamageMod), enemy); // Initial Damage
                    case StageType.SecondDamage:
                        return CalcMagicDmg((20 + (ObjectManager.Player.Spellbook.GetSpell(SpellSlot.R).Level * 20)) + (0.24 * ObjectManager.Player.FlatMagicDamageMod), enemy); // Damage per Tick
                    default:
                        throw new InvalidSpellTypeException();
                }
            default:
                throw new InvalidSpellTypeException();
        }
    }

    private static double Vladimir(Obj_AI_Hero enemy, SpellType type, StageType stagetype)
    {
        switch (type)
        {
            case SpellType.Q:
                return CalcPhysicalDmg((50 + (ObjectManager.Player.Spellbook.GetSpell(SpellSlot.Q).Level * 35) + (0.60 * ObjectManager.Player.FlatMagicDamageMod)), enemy);
            case SpellType.W:
                switch (stagetype)
                {
                    case StageType.Default:
                        return CalcMagicDmg((25 + (ObjectManager.Player.Spellbook.GetSpell(SpellSlot.W).Level * 55) + (15 * ObjectManager.Player.ScriptHealthBonus)), enemy); // complete w dmg
                    case StageType.FourthDamage:
                        return CalcMagicDmg((6.25 + (ObjectManager.Player.Spellbook.GetSpell(SpellSlot.W).Level * 13.75) + (3.75 * ObjectManager.Player.ScriptHealthBonus)), enemy); // per 0.5 sec
                    default:
                        throw new InvalidSpellTypeException();
                }
            case SpellType.E:
                double edmg = CalcMagicDmg((35 + (ObjectManager.Player.Spellbook.GetSpell(SpellSlot.E).Level * 25)) + (0.45 * ObjectManager.Player.FlatMagicDamageMod), enemy);
                switch (stagetype)
                {
                    case StageType.Default: // without any stacks
                        return edmg;
                    case StageType.FirstDamage: // 1 stack
                        return edmg * 1.25;
                    case StageType.SecondDamage: // 2 stacks
                        return edmg * 1.5;
                    case StageType.ThirdDamage: // 3 stacks
                        return edmg * 1.75;
                    case StageType.FourthDamage: // 4 stacks
                        return edmg * 2.0;
                    default:
                        throw new InvalidSpellTypeException();
                }
            case SpellType.R:
                return CalcMagicDmg((50 + (ObjectManager.Player.Spellbook.GetSpell(SpellSlot.R).Level * 100)) + (0.70 * ObjectManager.Player.FlatMagicDamageMod), enemy);
            default:
                throw new InvalidSpellTypeException();
        }
    }

    private static double Volibear(Obj_AI_Hero enemy, SpellType type, StageType stagetype)
    {
        switch (type)
        {
            case SpellType.Q:
                return CalcPhysicalDmg((ObjectManager.Player.Spellbook.GetSpell(SpellSlot.Q).Level * 30), enemy);
            case SpellType.W:
                double basedmg = CalcPhysicalDmg((35 + (ObjectManager.Player.Spellbook.GetSpell(SpellSlot.W).Level * 45)) + (0.15 * ObjectManager.Player.ScriptHealthBonus), enemy);
                double percentmissinghealth = 100 - ((enemy.Health / enemy.MaxHealth) * 100);
                return basedmg * percentmissinghealth;
            case SpellType.E:
                return CalcMagicDmg((15 + (ObjectManager.Player.Spellbook.GetSpell(SpellSlot.E).Level * 45)) + (0.60 * ObjectManager.Player.FlatMagicDamageMod), enemy);
            case SpellType.R:
                return CalcMagicDmg((ObjectManager.Player.Spellbook.GetSpell(SpellSlot.R).Level * 80) - 5 + (0.30 * ObjectManager.Player.FlatMagicDamageMod), enemy); //RÃœBERGUCKEN
            default:
                throw new InvalidSpellTypeException();
        }
    }

    private static double Warwick(Obj_AI_Hero enemy, SpellType type, StageType stagetype)
    {
        switch (type)
        {
            case SpellType.Q:
                double percentagedmg = CalcMagicDmg((enemy.MaxHealth / 100 * (6 + (2 * ObjectManager.Player.Spellbook.GetSpell(SpellSlot.Q).Level))) + (1.0 * ObjectManager.Player.FlatMagicDamageMod), enemy);
                double flatdmg = CalcMagicDmg((25 + (ObjectManager.Player.Spellbook.GetSpell(SpellSlot.Q).Level * 50)) + (1.0 * ObjectManager.Player.FlatMagicDamageMod), enemy);
                if (percentagedmg > flatdmg)
                {
                    return percentagedmg;
                }
                else
                {
                    return flatdmg;
                }
            case SpellType.W:
                throw new InvalidSpellTypeException();
            case SpellType.E:
                throw new InvalidSpellTypeException();
            case SpellType.R:
                switch (stagetype)
                {
                    case StageType.Default:
                        return CalcMagicDmg((165 + (ObjectManager.Player.Spellbook.GetSpell(SpellSlot.R).Level * 85)) + (2.0 * ObjectManager.Player.FlatPhysicalDamageMod), enemy); // 5 hits => complete ult
                    case StageType.FirstDamage:
                        return CalcMagicDmg((33 + (ObjectManager.Player.Spellbook.GetSpell(SpellSlot.R).Level * 17)) + (0.4 * ObjectManager.Player.FlatPhysicalDamageMod), enemy); // per hit
                    default:
                        throw new InvalidSpellTypeException();
                }
            default:
                throw new InvalidSpellTypeException();
        }
    }

    private static double MonkeyKing(Obj_AI_Hero enemy, SpellType type, StageType stagetype)
    {
        switch (type)
        {
            case SpellType.Q:
                return CalcPhysicalDmg((ObjectManager.Player.Spellbook.GetSpell(SpellSlot.Q).Level * 30) + (1.1 * (ObjectManager.Player.BaseAttackDamage + ObjectManager.Player.FlatPhysicalDamageMod)), enemy);
            case SpellType.W:
                return CalcMagicDmg((25 + (ObjectManager.Player.Spellbook.GetSpell(SpellSlot.W).Level * 45)) + (0.60 * ObjectManager.Player.FlatMagicDamageMod), enemy);
            case SpellType.E:
                return CalcPhysicalDmg((15 + (ObjectManager.Player.Spellbook.GetSpell(SpellSlot.E).Level * 45)) + (0.8 * (ObjectManager.Player.FlatPhysicalDamageMod)), enemy);
            case SpellType.R:
                switch (stagetype)
                {
                    case StageType.Default:
                        return CalcPhysicalDmg((-280 + (ObjectManager.Player.Spellbook.GetSpell(SpellSlot.R).Level * 360)) + (4.4 * (ObjectManager.Player.BaseAttackDamage + ObjectManager.Player.FlatPhysicalDamageMod)), enemy); // max damage
                    case StageType.FirstDamage:
                        return CalcPhysicalDmg((-70 + (ObjectManager.Player.Spellbook.GetSpell(SpellSlot.R).Level * 90)) + (1.1 * (ObjectManager.Player.BaseAttackDamage + ObjectManager.Player.FlatPhysicalDamageMod)), enemy); // per second
                    default:
                        throw new InvalidSpellTypeException();
                }
            default:
                throw new InvalidSpellTypeException();
        }
    }

    private static double Xerath(Obj_AI_Hero enemy, SpellType type, StageType stagetype)
    {
        switch (type)
        {
            case SpellType.Q:
                return CalcMagicDmg((40 + (ObjectManager.Player.Spellbook.GetSpell(SpellSlot.Q).Level * 40)) + (0.75 * ObjectManager.Player.FlatMagicDamageMod), enemy);
            case SpellType.W:
                return CalcMagicDmg((60 + (ObjectManager.Player.Spellbook.GetSpell(SpellSlot.W).Level * 30)) + (0.90 * ObjectManager.Player.FlatMagicDamageMod), enemy); //NOT EMPOWERED
            case SpellType.E:
                return CalcMagicDmg((50 + (ObjectManager.Player.Spellbook.GetSpell(SpellSlot.E).Level * 30)) + (0.45 * ObjectManager.Player.FlatMagicDamageMod), enemy);
            case SpellType.R:
                switch (stagetype)
                {
                    case StageType.Default:
                        return CalcMagicDmg((405 + (ObjectManager.Player.Spellbook.GetSpell(SpellSlot.R).Level * 165)) + (1.3 * ObjectManager.Player.FlatMagicDamageMod), enemy); // 3 hits on target
                    case StageType.FirstDamage:
                        return CalcMagicDmg((135 + (ObjectManager.Player.Spellbook.GetSpell(SpellSlot.R).Level * 55)) + (0.43 * ObjectManager.Player.FlatMagicDamageMod), enemy); // per hit
                    default:
                        throw new InvalidSpellTypeException();
                }
            default:
                throw new InvalidSpellTypeException();
        }
    }

    private static double XinZhao(Obj_AI_Hero enemy, SpellType type, StageType stagetype)
    {
        switch (type)
        {
            case SpellType.Q:
                return CalcPhysicalDmg((ObjectManager.Player.Spellbook.GetSpell(SpellSlot.Q).Level * 15) + (1.0 * (ObjectManager.Player.BaseAttackDamage + ObjectManager.Player.FlatPhysicalDamageMod)), enemy); // per hit
            case SpellType.W:
                throw new InvalidSpellTypeException();
            case SpellType.E:
                return CalcMagicDmg((50 + (ObjectManager.Player.Spellbook.GetSpell(SpellSlot.E).Level * 20)) + (0.6 * ObjectManager.Player.FlatMagicDamageMod), enemy);
            case SpellType.R:
                return CalcPhysicalDmg((-25 + (ObjectManager.Player.Spellbook.GetSpell(SpellSlot.R).Level * 100)) + (1.0 * ObjectManager.Player.FlatPhysicalDamageMod) + ((enemy.Health / 100) * 15), enemy);
            default:
                throw new InvalidSpellTypeException();
        }
    }

    private static double Yasuo(Obj_AI_Hero enemy, SpellType type, StageType stagetype)
    {
        switch (type)
        {
            case SpellType.Q:
                return CalcPhysicalDmg((ObjectManager.Player.Spellbook.GetSpell(SpellSlot.Q).Level * 20) + (1.0 * (ObjectManager.Player.BaseAttackDamage + ObjectManager.Player.FlatPhysicalDamageMod)), enemy);
            case SpellType.W:
                throw new InvalidSpellTypeException();
            case SpellType.E:
                return CalcMagicDmg((50 + (ObjectManager.Player.Spellbook.GetSpell(SpellSlot.E).Level * 20)) + (0.6 * ObjectManager.Player.FlatMagicDamageMod), enemy);
            case SpellType.R:
                return CalcPhysicalDmg((ObjectManager.Player.Spellbook.GetSpell(SpellSlot.R).Level * 100) + (1.5 * (ObjectManager.Player.FlatPhysicalDamageMod)), enemy);
            default:
                throw new InvalidSpellTypeException();
        }
    }

    private static double Yorick(Obj_AI_Hero enemy, SpellType type, StageType stagetype)
    {
        switch (type)
        {
            case SpellType.Q:
                return CalcPhysicalDmg((ObjectManager.Player.Spellbook.GetSpell(SpellSlot.Q).Level * 30) + (1.2 * (ObjectManager.Player.BaseAttackDamage + ObjectManager.Player.FlatPhysicalDamageMod)), enemy);
            case SpellType.W:
                return CalcMagicDmg((25 + (ObjectManager.Player.Spellbook.GetSpell(SpellSlot.W).Level * 35) + (1.0 * ObjectManager.Player.FlatMagicDamageMod)), enemy);
            case SpellType.E:
                return CalcMagicDmg((25 + (ObjectManager.Player.Spellbook.GetSpell(SpellSlot.E).Level * 30)) + (1.0 * (ObjectManager.Player.FlatPhysicalDamageMod)), enemy);
            case SpellType.R:
                throw new InvalidSpellTypeException();
            default:
                throw new InvalidSpellTypeException();
        }
    }

    private static double Zac(Obj_AI_Hero enemy, SpellType type, StageType stagetype)
    {
        switch (type)
        {
            case SpellType.Q:
                return CalcMagicDmg((30 + (ObjectManager.Player.Spellbook.GetSpell(SpellSlot.Q).Level * 40)) + (0.50 * ObjectManager.Player.FlatMagicDamageMod), enemy);
            case SpellType.W:
                double basedmg = CalcMagicDmg((25 + (ObjectManager.Player.Spellbook.GetSpell(SpellSlot.W).Level * 15)) + (0.35 * ObjectManager.Player.FlatMagicDamageMod), enemy);
                double percentofmaxhealth = (3 + (ObjectManager.Player.Spellbook.GetSpell(SpellSlot.W).Level));
                double additionalpercentper100ap = 0;
                if (ObjectManager.Player.FlatMagicDamageMod < 100)
                {
                    additionalpercentper100ap = 0;
                }
                else if (ObjectManager.Player.FlatMagicDamageMod.IsBetween(100, 199))
                {
                    additionalpercentper100ap = 2;
                }
                else if (ObjectManager.Player.FlatMagicDamageMod.IsBetween(200, 299))
                {
                    additionalpercentper100ap = 4;
                }
                else if (ObjectManager.Player.FlatMagicDamageMod.IsBetween(300, 399))
                {
                    additionalpercentper100ap = 6;
                }
                else if (ObjectManager.Player.FlatMagicDamageMod.IsBetween(400, 499))
                {
                    additionalpercentper100ap = 8;
                }
                else if (ObjectManager.Player.FlatMagicDamageMod.IsBetween(500, 599))
                {
                    additionalpercentper100ap = 10;
                }
                else if (ObjectManager.Player.FlatMagicDamageMod.IsBetween(600, 699))
                {
                    additionalpercentper100ap = 12;
                }
                else if (ObjectManager.Player.FlatMagicDamageMod.IsBetween(700, 799))
                {
                    additionalpercentper100ap = 14;
                }
                else if (ObjectManager.Player.FlatMagicDamageMod.IsBetween(800, 899))
                {
                    additionalpercentper100ap = 16;
                }
                else if (ObjectManager.Player.FlatMagicDamageMod >= 900)
                {
                    additionalpercentper100ap = 18;
                }
                double healthbase = enemy.MaxHealth / 100 * (percentofmaxhealth + additionalpercentper100ap);
                return basedmg + CalcMagicDmg(healthbase, enemy);
            case SpellType.E:
                return CalcMagicDmg((40 + (ObjectManager.Player.Spellbook.GetSpell(SpellSlot.E).Level * 40)) + (0.7 * ObjectManager.Player.FlatMagicDamageMod), enemy);
            case SpellType.R:
                switch (stagetype)
                {
                    case StageType.FirstDamage:
                        return CalcMagicDmg((70 + (ObjectManager.Player.Spellbook.GetSpell(SpellSlot.R).Level * 70)) + (0.4 * ObjectManager.Player.FlatMagicDamageMod), enemy); // first jump on enemy
                    case StageType.Default:
                        return CalcMagicDmg((175 + (ObjectManager.Player.Spellbook.GetSpell(SpellSlot.R).Level * 175)) + (1.0 * ObjectManager.Player.FlatMagicDamageMod), enemy); // all jumps on enemy
                    default:
                        throw new InvalidSpellTypeException();
                }
            default:
                throw new InvalidSpellTypeException();
        }
    }

    private static double Zed(Obj_AI_Hero enemy, SpellType type, StageType stagetype)
    {
        switch (type)
        {
            case SpellType.Q:
                return CalcPhysicalDmg((35 + (ObjectManager.Player.Spellbook.GetSpell(SpellSlot.Q).Level * 40)) + (1.0 * ObjectManager.Player.FlatPhysicalDamageMod), enemy); // 1 hit
            case SpellType.W:
                throw new InvalidSpellTypeException();
            case SpellType.E:
                return CalcPhysicalDmg((30 + (ObjectManager.Player.Spellbook.GetSpell(SpellSlot.E).Level * 30)) + (0.8 * ObjectManager.Player.FlatPhysicalDamageMod), enemy);
            case SpellType.R:
                return CalcPhysicalDmg(1.0 * (ObjectManager.Player.FlatMagicDamageMod + ObjectManager.Player.BaseAttackDamage), enemy); // base dmg
            default:
                throw new InvalidSpellTypeException();
        }
    }

    private static double Ziggs(Obj_AI_Hero enemy, SpellType type, StageType stagetype)
    {
        switch (type)
        {
            case SpellType.Q:
                return CalcMagicDmg((30 + (ObjectManager.Player.Spellbook.GetSpell(SpellSlot.Q).Level * 45)) + (0.35 * ObjectManager.Player.FlatMagicDamageMod), enemy);
            case SpellType.W:
                return CalcMagicDmg((35 + (ObjectManager.Player.Spellbook.GetSpell(SpellSlot.W).Level * 35)) + (0.35 * ObjectManager.Player.FlatMagicDamageMod), enemy);
            case SpellType.E:
                return CalcMagicDmg((15 + (ObjectManager.Player.Spellbook.GetSpell(SpellSlot.E).Level * 25)) + (0.30 * ObjectManager.Player.FlatMagicDamageMod), enemy); // per mine
            case SpellType.R:
                return CalcMagicDmg((125 + (ObjectManager.Player.Spellbook.GetSpell(SpellSlot.R).Level * 125)) + (0.35 * ObjectManager.Player.FlatMagicDamageMod), enemy);
            default:
                throw new InvalidSpellTypeException();
        }
    }

    private static double Zyra(Obj_AI_Hero enemy, SpellType type, StageType stagetype)
    {
        switch (type)
        {
            case SpellType.Q:
                return CalcMagicDmg((35 + (ObjectManager.Player.Spellbook.GetSpell(SpellSlot.Q).Level * 35)) + (0.65 * ObjectManager.Player.FlatMagicDamageMod), enemy);
            case SpellType.W:
                throw new InvalidSpellTypeException();
            case SpellType.E:
                return CalcMagicDmg((25 + (ObjectManager.Player.Spellbook.GetSpell(SpellSlot.E).Level * 35)) + (0.50 * ObjectManager.Player.FlatMagicDamageMod), enemy);
            case SpellType.R:
                return CalcMagicDmg((95 + (ObjectManager.Player.Spellbook.GetSpell(SpellSlot.R).Level * 85)) + (0.70 * ObjectManager.Player.FlatMagicDamageMod), enemy);
            default:
                throw new InvalidSpellTypeException();
        }
    }

    private static double Zilean(Obj_AI_Hero enemy, SpellType type, StageType stagetype)
    {
        switch (type)
        {
            case SpellType.Q:
                return CalcMagicDmg((35 + (ObjectManager.Player.Spellbook.GetSpell(SpellSlot.Q).Level * 55)) + (0.9 * ObjectManager.Player.FlatMagicDamageMod), enemy);
            case SpellType.W:
                throw new InvalidSpellTypeException();
            case SpellType.E:
                throw new InvalidSpellTypeException();
            case SpellType.R:
                throw new InvalidSpellTypeException();
            default:
                throw new InvalidSpellTypeException();
        }
    }
}

public enum SpellType
{
    Q,
    W,
    E,
    R,
    AD,
    IGNITE,
    HEXGUN,
    DFG,
    BOTRK,
    BILGEWATER,
    TIAMAT,
    HYDRA
}

public enum StageType
{
    FirstDamage,
    SecondDamage,
    ThirdDamage,
    FourthDamage,
    Default,
}

class InvalidSpellTypeException : Exception
{
    public InvalidSpellTypeException()
    {
        Game.PrintChat("<font color='#33FFFF'>DamageLib: InvalidSpellTypeException: Tried to get the damage of an invalid spell, a spell without damage, a wrong stagetype of a spell or a not supported spell</font>");
    }
}

class Enemy
{
    public int NetworkId;
    public int block;
    public int unyielding;
}