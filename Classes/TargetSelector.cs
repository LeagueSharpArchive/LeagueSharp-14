using System;
using System.Linq;
using LeagueSharp;
using LeagueSharp.Math;

public class TargetSelector
{
    public enum TargetingMode
    {
        LowHP,
        MostAD,
        MostAP,
        Closest,
        NearMouse,
        AutoPriority,
    }

    private float _range;
    private TargetingMode _mode;
    public Obj_AI_Hero target;
    private bool drawcircle = false;
    private bool update = true;

    public TargetSelector(float range, TargetingMode mode)
    {
        _range = range;
        _mode = mode;

        Game.OnGameUpdate += Game_OnGameUpdate;
        Drawing.OnDraw += Drawing_OnDraw;
    }

    void Drawing_OnDraw(EventArgs args)
    {
        if (drawcircle == true && target != null && target.IsVisible == true && target.IsVisible == true && target.IsEnemy == true)
        {
            Drawing.DrawCircle(target.Position, 125, System.Drawing.Color.White);
        }
    }

    private static double lasttick = 0;

    void Game_OnGameUpdate(EventArgs args)
    {
        if (Environment.TickCount > lasttick + 500)
        {
            lasttick = Environment.TickCount;
            if (update == true)
            {
                switch (_mode)
                {
                    case TargetingMode.LowHP:
                        target = GetLowestHPTarget();
                        break;
                    case TargetingMode.MostAD:
                        target = MostAD();
                        break;
                    case TargetingMode.MostAP:
                        target = MostAP();
                        break;
                    case TargetingMode.Closest:
                        target = Closest();
                        break;
                    case TargetingMode.NearMouse:
                        target = NearMouse();
                        break;
                    case TargetingMode.AutoPriority:
                        target = AutoPriority();
                        break;
                }
            }
        }
    }

    private Obj_AI_Hero GetLowestHPTarget()
    {
        Obj_AI_Hero lowesttarget = null;
        foreach (Obj_AI_Hero target in ObjectManager.Get<Obj_AI_Hero>())
        {
            if (target != null && target.IsValid == true && target.IsEnemy == true && target.IsDead == false && target.IsVisible == true && Vector3.Distance(ObjectManager.Player.Position, target.Position) <= _range)
            {
                if (lowesttarget == null)
                {
                    lowesttarget = target;
                }
                else
                {
                    if (target.Health < lowesttarget.Health)
                    {
                        lowesttarget = target;
                    }
                }
            }
        }
        return lowesttarget;
    }

    private Obj_AI_Hero MostAD()
    {
        Obj_AI_Hero mostad = null;
        foreach (Obj_AI_Hero target in ObjectManager.Get<Obj_AI_Hero>())
        {
            if (target != null && target.IsValid == true && target.IsEnemy == true && target.IsDead == false && target.IsVisible == true && Vector3.Distance(ObjectManager.Player.Position, target.Position) <= _range)
            {
                if (mostad == null)
                {
                    mostad = target;
                }
                else
                {
                    if (target.BaseAttackDamage + target.FlatPhysicalDamageMod < mostad.BaseAttackDamage + mostad.FlatPhysicalDamageMod)
                    {
                        mostad = target;
                    }
                }
            }
        }
        return mostad;
    }

    private Obj_AI_Hero MostAP()
    {
        Obj_AI_Hero mostap = null;
        foreach (Obj_AI_Hero target in ObjectManager.Get<Obj_AI_Hero>())
        {
            if (target != null && target.IsValid == true && target.IsEnemy == true && target.IsDead == false && target.IsVisible == true && Vector3.Distance(ObjectManager.Player.Position, target.Position) <= _range)
            {
                if (mostap == null)
                {
                    mostap = target;
                }
                else
                {
                    if (target.FlatMagicDamageMod < mostap.FlatMagicDamageMod)
                    {
                        mostap = target;
                    }
                }
            }
        }
        return mostap;
    }

    private Obj_AI_Hero Closest()
    {
        Obj_AI_Hero closest = null;
        foreach (Obj_AI_Hero target in ObjectManager.Get<Obj_AI_Hero>())
        {
            if (target != null && target.IsValid == true && target.IsEnemy == true && target.IsDead == false && target.IsVisible == true && Vector3.Distance(ObjectManager.Player.Position, target.Position) <= _range)
            {
                if (closest == null)
                {
                    closest = target;
                }
                else
                {
                    if (Vector3.Distance(ObjectManager.Player.Position, target.Position) < Vector3.Distance(ObjectManager.Player.Position, closest.Position))
                    {
                        closest = target;
                    }
                }
            }
        }
        return closest;
    }

    private Obj_AI_Hero NearMouse()
    {
        Obj_AI_Hero nearmouse = null;
        foreach (Obj_AI_Hero target in ObjectManager.Get<Obj_AI_Hero>())
        {
            if (target != null && target.IsValid == true && target.IsEnemy == true && target.IsDead == false && target.IsVisible == true && Vector3.Distance(ObjectManager.Player.Position, target.Position) <= _range)
            {
                if (nearmouse == null)
                {
                    nearmouse = target;
                }
                else
                {
                    if (Vector3.Distance(Game.CursorPos, target.Position) < Vector3.Distance(Game.CursorPos, nearmouse.Position))
                    {
                        nearmouse = target;
                    }
                }
            }
        }
        return nearmouse;
    }

    private static string[] ap = new string[] { "Ahri", "Akali", "Anivia", "Annie", "Brand", "Cassiopeia", "Diana", "FiddleSticks", "Fizz", "Gragas", "Heimerdinger", "Karthus", "Kassadin", "Katarina", "Kayle", "Kennen", "Leblanc", "Lissandra", "Lux", "Malzahar", "Mordekaiser", "Morgana", "Nidalee", "Orianna", "Ryze", "Sion", "Swain", "Syndra", "Teemo", "TwistedFate", "Veigar", "Viktor", "Vladimir", "Xerath", "Ziggs", "Zyra", "Velkoz" };
    private static string[] sup = new string[] { "Blitzcrank", "Janna", "Karma", "Leona", "Lulu", "Nami", "Sona", "Soraka", "Thresh", "Zilean" };
    private static string[] tank = new string[] { "Amumu", "Chogath", "DrMundo", "Galio", "Hecarim", "Malphite", "Maokai", "Nasus", "Rammus", "Sejuani", "Shen", "Singed", "Skarner", "Volibear", "Warwick", "Yorick", "Zac", "Nunu", "Taric", "Alistar", "Garen", "Nautilus" };
    private static string[] ad = new string[] { "Ashe", "Caitlyn", "Corki", "Draven", "Ezreal", "Graves", "KogMaw", "MissFortune", "Quinn", "Sivir", "Talon", "Tristana", "Twitch", "Urgot", "Varus", "Vayne", "Zed", "Jinx", "Yasuo", "Lucian" };
    private static string[] bruiser = new string[] { "Darius", "Elise", "Evelynn", "Fiora", "Gangplank", "Jayce", "Pantheon", "Irelia", "JarvanIV", "Jax", "Khazix", "LeeSin", "Nocturne", "Olaf", "Poppy", "Renekton", "Rengar", "Riven", "Shyvana", "Trundle", "Tryndamere", "Udyr", "Vi", "MonkeyKing", "XinZhao", "Aatrox", "Rumble", "Shaco", "MasterYi" };

    private Obj_AI_Hero AutoPriority()
    {
        Obj_AI_Hero autopriority = null;
        int prio = 5;
        foreach (Obj_AI_Hero target in ObjectManager.Get<Obj_AI_Hero>())
        {
            if (target != null && target.IsValid == true && target.IsEnemy == true && target.IsDead == false && target.IsVisible == true && Vector3.Distance(ObjectManager.Player.Position, target.Position) <= _range)
            {
                if (autopriority == null)
                {
                    autopriority = target;
                    prio = FindPrioForTarget(target.BaseSkinName);
                }
                else
                {
                    if (FindPrioForTarget(target.BaseSkinName) < prio)
                    {
                        autopriority = target;
                        prio = FindPrioForTarget(target.BaseSkinName);
                    }
                    else if (FindPrioForTarget(target.BaseSkinName) == prio)
                    {
                        if (target.Health < autopriority.Health)
                        {
                            autopriority = target;
                            prio = FindPrioForTarget(target.BaseSkinName);
                        }
                    }
                }
            }
        }
        return autopriority;
    }

    private static int FindPrioForTarget(string baseskinname)
    {
        if (ap.Contains(baseskinname))
        {
            return 2;
        }
        else if (ad.Contains(baseskinname))
        {
            return 1;
        }
        else if (sup.Contains(baseskinname))
        {
            return 3;
        }
        else if (bruiser.Contains(baseskinname))
        {
            return 4;
        }
        else if (tank.Contains(baseskinname))
        {
            return 5;
        }
        else
        {
            return 5;
        }
    }

    public void setDrawCircleOfTarget(bool draw)
    {
        drawcircle = draw;
    }

    public void OverrideTarget(Obj_AI_Hero newtarget)
    {
        target = newtarget;
        update = false;
    }

    public void DisableTargetOverride()
    {
        update = true;
    }

    public float getRange()
    {
        return _range;
    }

    public void setRange(float range)
    {
        _range = range;
    }

    public TargetingMode getTargetingMode()
    {
        return _mode;
    }

    public void setTargetingMode(TargetingMode mode)
    {
        _mode = mode;
    }

    public override string ToString()
    {
        return "Target: " + target.BaseSkinName + "Range: " + _range.ToString() + "Mode: " + _mode.ToString();
    }
}