using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class Monster
{
    protected Sprite cardImage = null;
    protected string monName = "Training Dummy";
    protected string subtype = null;
    protected int tier = 0;
    protected int gold = 0;
    protected int commontreasure = 0;
    protected int qualitytreasure = 0;
    protected int victorypoints = 0;
    protected bool allrewarded = false;
    protected float clericgem = 0;
    protected float warriorgem = 0;
    protected float roguegem = 0;
    protected float magegem = 0;
    protected int shield = 0;
    protected int powershield = 0;
    protected int evade = 0;
    protected int armor = 0;
    protected int damagereducedpercombatant = 0;
    protected int limithands = 0;
    protected int alldamagereduced = 0;
    protected int regen = 0;
    protected int gem1regen = 0;
    protected int gem2regen = 0;
    protected int gem4regen = 0;
    protected int gem1skillboost = 0;
    protected int gem2skillboost = 0;
    protected int gem1allboost = 0;
    protected int gem2allboost = 0;
    protected int gem3allboost = 0;
    protected int gem1skilldrop = 0;
    protected int gem2skilldrop = 0;
    protected int gem1evade = 0;
    protected int gem2evade = 0;
    protected int gem4evade = 0;
    protected int gem1armor = 0;
    protected int gem2armor = 0;
    protected string defense = null;
    protected string defenseattack = null;
    protected string defensecounterattack = null;
    protected int defensegem = 0;
    protected int defgem1heal = 0;
    protected int defgem3heal = 0;
    protected int defgem3abilityshield = 0;
    protected bool defgem4flee = false;
    protected int defenseshield = 0;
    protected int defensepowershield = 0;
    protected bool defenseshieldrestore = false;
    protected int defenseheal = 0;
    protected int defenseenergy = 0;
    protected int defensespellboost = 0;
    protected bool defenseinflictfear = false;
    protected string balanced = null; 
    protected int balancedboostformissing10health = 0;
    protected bool balancedshieldrestore = false;
    protected bool balancedforceplayerdiscardhand = false;
    protected int balancedcollateralbydiscard = 0;
    protected int balancedboostbyshieldcount = 0;
    protected int balanceshieldbreakbyshieldcount = 0;
    protected bool balancedsacrificeshields = false;
    protected int balancedhealforplayersdamaged = 0;
    protected int balancedboostbyattackforcediscard = 0;
    protected int balancedgem2spellboost = 0;
    protected bool balancedgem2homing = false;
    protected string balanceattack = null;
    protected string offense = null;
    protected int offenseboostbyshieldcount = 0;
    protected bool offensesacrificeshields = false;
    protected int offensereducebycardsinhand = 0;
    protected string offenseattack = null;
    protected int offenseselfdamage = 0;
    protected int offensegem2energy = 0;
    protected int offensegem = 0;
    protected bool offenseinflictburning = false;
    protected bool offenseinflictcrippled = false;
    protected string special = null;
    protected int specialrollcombatandboost = 0;
    protected int specialrollskillandboost = 0;
    protected int specialrollswordskillboost = 0;
    protected bool specialrollshieldgem3pierce = false;
    protected int specialrollshieldgem3heal = 0;
    protected int specialrollshieldheal = 0;
    protected int specialrollshieldshieldbreak = 0;
    protected bool specialrollspecialpierce = false;
    protected string specialattack = null;
    protected bool specialdiscardhandsdrawlimited = false;
    protected int specialgem = 0;
    protected int specialheal = 0;
    protected int specialrollcombatasattack = 0;
    protected int specialskillboost = 0;
    protected int specialrollskillandpair = 0;
    protected int specialmill = 0;
    protected string specialmillattack = null;
    protected int specialmilldefenseheal = 0;
    protected int specialmilltechniqueallboost = 0;
    protected bool specialmilltechniquepierce = false;
    protected bool specialinflictslowed = false;
    protected int specialenergy = 0;
    protected string specialdefense = null;
    protected string specialdefenseattack = null;
    protected int specialdefenseheal = 0;
    protected string specialoffense = null;
    protected int specialoffensegem = 0;
    protected int specialoffenseenergy = 0;
    //Mosnter Mod variables
    protected int goldpertier = 0;
    protected int treasurerolls = 0;
    protected bool pierce = false;
    protected string clericattackaddshieldbreak = null;
    protected bool attackaddhoming = false;
    protected bool attackaddpierce = false;
    protected int defenseaddabilityshield = 0;
    protected int allboost = 0;
    protected int maxhealth = 0;
    protected int maxhealthpertier = 0;
    protected int rogueallboost = 0;
    protected int rogueevade = 0;
    protected int mageallboost = 0;
    protected int warriorarmor = 0;
    protected bool warriorpierce = false;
    protected int playeralldropperarmorevade = 0;
    protected bool tier1upgrade = false;
    protected bool specialflee = false;
    protected int bonusaction = 0;
    protected int ethereal = 0;
    protected bool isMod = false;
    protected List<Monster> mods = new List<Monster>();
    protected int currentHP = 0;
    protected int currentShields = 0;
    protected int currentPowerShields = 0;
    protected int currentAbilityShields = 0;
    protected int currentAbilityPowerShields = 0;
    protected int trainedShields = 0;
    protected int gemCount = 0;

    public void loadCard(string filepath, string imagepath, bool _isMod){
        
        //Loading image
        isMod = _isMod;
        byte[] imageData = System.IO.File.ReadAllBytes(imagepath);
        int width = 975;
        int height = 1125;
        if (isMod){
            width = 180;
            height = 474;
        }
        Texture2D tex = new Texture2D(2,2);
        tex.LoadImage(imageData);
        if (isMod) cardImage = Sprite.Create(tex,new Rect(0,0,width,height),Vector2.zero);
        else cardImage = Sprite.Create(tex,new Rect(40,40,width-40,height-40),Vector2.zero);
        //Loading card and parsing it.
        var lines = File.ReadAllLines(filepath);
        //Breaks down each component of laoded file and populates values. Not all cards have all values.
        foreach (string line in lines){
            string[] value = line.Split(':');
            if (value[0].CompareTo("name")==0)
                monName = value[1];
            if (value[0].CompareTo("subtype")==0) 
                subtype = value[1];
            if (value[0].CompareTo("tier")==0) 
                int.TryParse(value[1], out tier);
            if (value[0].CompareTo("gold")==0) 
                int.TryParse(value[1], out gold);
            if (value[0].CompareTo("commontreasure")==0) 
                int.TryParse(value[1], out commontreasure);
            if (value[0].CompareTo("qualitytreasure")==0) 
                int.TryParse(value[1], out qualitytreasure);
            if (value[0].CompareTo("victorypoints")==0) 
                int.TryParse(value[1], out victorypoints);
            if (value[0].CompareTo("clericgem")==0) 
                float.TryParse(value[1], out clericgem);
            if (value[0].CompareTo("warriorgem")==0) 
                float.TryParse(value[1], out warriorgem);
            if (value[0].CompareTo("roguegem")==0) 
                float.TryParse(value[1], out roguegem);
            if (value[0].CompareTo("magegem")==0) 
                float.TryParse(value[1], out magegem);
            if (value[0].CompareTo("shield")==0) 
                int.TryParse(value[1], out shield);
            if (value[0].CompareTo("powershield")==0) 
                int.TryParse(value[1], out powershield);
            if (value[0].CompareTo("evade")==0) 
                int.TryParse(value[1], out evade);
            if (value[0].CompareTo("armor")==0) 
                int.TryParse(value[1], out armor);
            if (value[0].CompareTo("damagereducedpercombatant")==0) 
                int.TryParse(value[1], out damagereducedpercombatant);
            if (value[0].CompareTo("limithands")==0) 
                int.TryParse(value[1], out limithands);
            if (value[0].CompareTo("alldamagereduced")==0) 
                int.TryParse(value[1], out alldamagereduced);
            if (value[0].CompareTo("regen")==0) 
                int.TryParse(value[1], out regen);
            if (value[0].CompareTo("gem1regen")==0) 
                int.TryParse(value[1], out gem1regen);
            if (value[0].CompareTo("gem2regen")==0) 
                int.TryParse(value[1], out gem2regen);
            if (value[0].CompareTo("gem4regen")==0) 
                int.TryParse(value[1], out gem4regen);
            if (value[0].CompareTo("gem1skillboost")==0) 
                int.TryParse(value[1], out gem1skillboost);
            if (value[0].CompareTo("gem2skillboost")==0) 
                int.TryParse(value[1], out gem2skillboost);
            if (value[0].CompareTo("gem1allboost")==0) 
                int.TryParse(value[1], out gem1allboost);
            if (value[0].CompareTo("gem2allboost")==0) 
                int.TryParse(value[1], out gem2allboost);
            if (value[0].CompareTo("gem3allboost")==0) 
                int.TryParse(value[1], out gem3allboost);
            if (value[0].CompareTo("gem1skilldrop")==0) 
                int.TryParse(value[1], out gem1skilldrop);
            if (value[0].CompareTo("gem2skilldrop")==0) 
                int.TryParse(value[1], out gem2skilldrop);
            if (value[0].CompareTo("gem1evade")==0) 
                int.TryParse(value[1], out gem1evade);
            if (value[0].CompareTo("gem2evade")==0) 
                int.TryParse(value[1], out gem2evade);
            if (value[0].CompareTo("gem4evade")==0) 
                int.TryParse(value[1], out gem4evade);
            if (value[0].CompareTo("gem1armor")==0) 
                int.TryParse(value[1], out gem1armor);
            if (value[0].CompareTo("gem2armor")==0) 
                int.TryParse(value[1], out gem2armor);
            if (value[0].CompareTo("defense")==0) 
                defense = value[1];
            if (value[0].CompareTo("defenseattack")==0) 
                defenseattack = value[1];
            if (value[0].CompareTo("defensecounterattack")==0) 
                defensecounterattack = value[1];
            if (value[0].CompareTo("defensegem")==0) 
                int.TryParse(value[1], out defensegem);
            if (value[0].CompareTo("defgem1heal")==0) 
                int.TryParse(value[1], out defgem1heal);
            if (value[0].CompareTo("defgem3heal")==0) 
                int.TryParse(value[1], out defgem3heal);
            if (value[0].CompareTo("defgem3abilityshield")==0) 
                int.TryParse(value[1], out defgem3abilityshield);
            if (value[0].CompareTo("defgem4flee")==0) 
                bool.TryParse(value[1], out defgem4flee);
            if (value[0].CompareTo("defenseshield")==0) 
                int.TryParse(value[1], out defenseshield);
            if (value[0].CompareTo("defensepowershield")==0) 
                int.TryParse(value[1], out defensepowershield);
            if (value[0].CompareTo("defenseshieldrestore")==0) 
                bool.TryParse(value[1], out defenseshieldrestore);
            if (value[0].CompareTo("allrewarded")==0) 
                bool.TryParse(value[1], out allrewarded);
            if (value[0].CompareTo("defenseheal")==0) 
                int.TryParse(value[1], out defenseheal);
            if (value[0].CompareTo("defenseenergy")==0) 
                int.TryParse(value[1], out defenseenergy);
            if (value[0].CompareTo("defensespellboost")==0) 
                int.TryParse(value[1], out defensespellboost);
            if (value[0].CompareTo("defenseinflictfear")==0) 
                bool.TryParse(value[1], out defenseinflictfear);
            if (value[0].CompareTo("balanced")==0) 
                balanced = value[1]; 
            if (value[0].CompareTo("balancedboostformissing10health")==0) 
                int.TryParse(value[1], out balancedboostformissing10health);
            if (value[0].CompareTo("balancedshieldrestore")==0) 
                bool.TryParse(value[1], out balancedshieldrestore);
            if (value[0].CompareTo("balancedforceplayerdiscardhand")==0) 
                bool.TryParse(value[1], out balancedforceplayerdiscardhand);
            if (value[0].CompareTo("balancedcollateralbydiscard")==0) 
                int.TryParse(value[1], out balancedcollateralbydiscard);
            if (value[0].CompareTo("balancedboostbyshieldcount")==0) 
                int.TryParse(value[1], out balancedboostbyshieldcount);
            if (value[0].CompareTo("balanceshieldbreakbyshieldcount")==0) 
                int.TryParse(value[1], out balanceshieldbreakbyshieldcount);
            if (value[0].CompareTo("balancedsacrificeshields")==0) 
                bool.TryParse(value[1], out balancedsacrificeshields);
            if (value[0].CompareTo("balancedhealforplayersdamaged")==0) 
                int.TryParse(value[1], out balancedhealforplayersdamaged);
            if (value[0].CompareTo("balancedboostbyattackforcediscard")==0) 
                int.TryParse(value[1], out balancedboostbyattackforcediscard);
            if (value[0].CompareTo("balancedgem2spellboost")==0) 
                int.TryParse(value[1], out balancedgem2spellboost);
            if (value[0].CompareTo("balancedgem2homing")==0) 
                bool.TryParse(value[1], out balancedgem2homing);
            if (value[0].CompareTo("balanceattack")==0) 
                balanceattack = value[1];
            if (value[0].CompareTo("offense")==0) 
                offense = value[1];
            if (value[0].CompareTo("offenseboostbyshieldcount")==0) 
                int.TryParse(value[1], out offenseboostbyshieldcount);
            if (value[0].CompareTo("subtoffensesacrificeshieldsype")==0) 
                bool.TryParse(value[1], out offensesacrificeshields);
            if (value[0].CompareTo("offensereducebycardsinhand")==0) 
                int.TryParse(value[1], out offensereducebycardsinhand);
            if (value[0].CompareTo("offenseattack")==0) 
                offenseattack = value[1];
            if (value[0].CompareTo("offenseselfdamage")==0) 
                int.TryParse(value[1], out offenseselfdamage);
            if (value[0].CompareTo("offensegem2energy")==0) 
                int.TryParse(value[1], out offensegem2energy);
            if (value[0].CompareTo("offensegem")==0) 
                int.TryParse(value[1], out offensegem);
            if (value[0].CompareTo("offenseinflictburning")==0) 
                bool.TryParse(value[1], out offenseinflictburning);
            if (value[0].CompareTo("offenseinflictcrippled")==0) 
                bool.TryParse(value[1], out offenseinflictcrippled);
            if (value[0].CompareTo("special")==0) 
                special = value[1];
            if (value[0].CompareTo("specialrollcombatandboost")==0) 
                int.TryParse(value[1], out specialrollcombatandboost);
            if (value[0].CompareTo("specialrollskillandboost")==0) 
                int.TryParse(value[1], out specialrollskillandboost);
            if (value[0].CompareTo("specialrollswordskillboost")==0) 
                int.TryParse(value[1], out specialrollswordskillboost);
            if (value[0].CompareTo("specialrollshieldgem3pierce")==0) 
                bool.TryParse(value[1], out specialrollshieldgem3pierce);
            if (value[0].CompareTo("specialrollshieldgem3heal")==0) 
                int.TryParse(value[1], out specialrollshieldgem3heal);
            if (value[0].CompareTo("specialrollshieldheal")==0) 
                int.TryParse(value[1], out specialrollshieldheal);
            if (value[0].CompareTo("specialrollshieldshieldbreak")==0) 
                int.TryParse(value[1], out specialrollshieldshieldbreak);
            if (value[0].CompareTo("specialrollspecialpierce")==0) 
                bool.TryParse(value[1], out specialrollspecialpierce);
            if (value[0].CompareTo("specialattack")==0) 
                specialattack = value[1];
            if (value[0].CompareTo("specialdiscardhandsdrawlimited")==0) 
                bool.TryParse(value[1], out specialdiscardhandsdrawlimited);
            if (value[0].CompareTo("specialgem")==0) 
                int.TryParse(value[1], out specialgem);
            if (value[0].CompareTo("specialheal")==0) 
                int.TryParse(value[1], out specialheal);
            if (value[0].CompareTo("specialrollcombatasattack")==0) 
                int.TryParse(value[1], out specialrollcombatasattack);
            if (value[0].CompareTo("specialskillboost")==0) 
                int.TryParse(value[1], out specialskillboost);
            if (value[0].CompareTo("specialrollskillandpair")==0) 
                int.TryParse(value[1], out specialrollskillandpair);
            if (value[0].CompareTo("specialmill")==0) 
                int.TryParse(value[1], out specialmill);
            if (value[0].CompareTo("specialmillattack")==0) 
                specialmillattack = value[1];
            if (value[0].CompareTo("specialmilldefenseheal")==0) 
                int.TryParse(value[1], out specialmilldefenseheal);
            if (value[0].CompareTo("specialmilltechniqueallboost")==0) 
                int.TryParse(value[1], out specialmilltechniqueallboost);
            if (value[0].CompareTo("specialmilltechniquepierce")==0) 
                bool.TryParse(value[1], out specialmilltechniquepierce);
            if (value[0].CompareTo("specialinflictslowed")==0) 
                bool.TryParse(value[1], out specialinflictslowed);
            if (value[0].CompareTo("specialenergy")==0) 
                int.TryParse(value[1], out specialenergy);
            if (value[0].CompareTo("specialdefense")==0) 
                specialdefense = value[1];
            if (value[0].CompareTo("specialdefenseattack")==0) 
                specialdefenseattack = value[1];
            if (value[0].CompareTo("specialdefenseheal")==0) 
                int.TryParse(value[1], out specialdefenseheal);
            if (value[0].CompareTo("specialoffense")==0) 
                specialoffense = value[1];
            if (value[0].CompareTo("specialoffensegem")==0) 
                int.TryParse(value[1], out specialoffensegem);
            if (value[0].CompareTo("specialoffenseenergy")==0) 
                int.TryParse(value[1], out specialoffenseenergy);
            // The rest of these are from Monster Mods
            if (value[0].CompareTo("goldpertier")==0) 
                int.TryParse(value[1], out goldpertier);
            if (value[0].CompareTo("treasurerolls")==0) 
                int.TryParse(value[1], out treasurerolls);
            if (value[0].CompareTo("pierce")==0) 
                bool.TryParse(value[1], out pierce);
            if (value[0].CompareTo("specialmillattack")==0)
                clericattackaddshieldbreak = value[1];
            if (value[0].CompareTo("attackaddhoming")==0) 
                bool.TryParse(value[1], out attackaddhoming);
            if (value[0].CompareTo("attackaddpierce")==0) 
                bool.TryParse(value[1], out attackaddpierce);
            if (value[0].CompareTo("defenseaddabilityshield")==0) 
                int.TryParse(value[1], out defenseaddabilityshield);
            if (value[0].CompareTo("allboost")==0) 
                int.TryParse(value[1], out allboost);
            if (value[0].CompareTo("maxhealth")==0) 
                int.TryParse(value[1], out maxhealth);
            if (value[0].CompareTo("maxhealthpertier")==0) 
                int.TryParse(value[1], out maxhealthpertier);
            if (value[0].CompareTo("rogueallboost")==0) 
                int.TryParse(value[1], out rogueallboost);
            if (value[0].CompareTo("rogueevade")==0) 
                int.TryParse(value[1], out rogueevade);
            if (value[0].CompareTo("mageallboost")==0) 
                int.TryParse(value[1], out mageallboost);
            if (value[0].CompareTo("warriorarmor")==0) 
                int.TryParse(value[1], out warriorarmor);
            if (value[0].CompareTo("warriorpierce")==0) 
                bool.TryParse(value[1], out warriorpierce);
            if (value[0].CompareTo("playeralldropperarmorevade")==0) 
                int.TryParse(value[1], out playeralldropperarmorevade);
            if (value[0].CompareTo("tier1upgrade")==0) 
                bool.TryParse(value[1], out tier1upgrade);
            if (value[0].CompareTo("specialflee")==0) 
                bool.TryParse(value[1], out specialflee);
            if (value[0].CompareTo("bonusaction")==0) 
                int.TryParse(value[1], out bonusaction);
            if (value[0].CompareTo("ethereal")==0) 
                int.TryParse(value[1], out ethereal);
        }
    }
    public string GetMonType(){
        return subtype;
    }
    public string GetName(){
        return monName;
    }
    public Sprite Image(){
        return cardImage;
    }
    public int[] Shields(){
        int totalShields = shield;
        //Currently, no mods add shields
        return new int[]{currentShields,totalShields};
    }
    public int[] PowerShields(){
        int totalShields = powershield;
        //Currently, no mods add powershields
        return new int[]{currentPowerShields,totalShields};
    }
    public int[] AbilityShields(){
        int totalShields = defenseshield;
        if (gemCount >= 3) totalShields += defgem3abilityshield;
        return new int[]{currentAbilityShields,totalShields};
    }
    public int[] AbilityPowerShields(){
        int totalShields = defensepowershield;
        //Nothing adds to this value presently
        return new int[]{currentAbilityShields,totalShields};
    }
    public int[] TrainedShields(){
        int totalShields = defenseaddabilityshield;
        return new int[]{trainedShields,totalShields};
    }
    public virtual int[] Health(){
        int maxHP = 10 * tier;
        maxHP += maxhealth;
        maxHP += maxhealthpertier * tier;
        return new int[]{currentHP, maxHP};
    }
    public int[] getRewards(){
        int[] rewards = new int[4];
        rewards[0] = gold; rewards[1] = commontreasure + qualitytreasure; rewards[2] = victorypoints; rewards[3] = 1 + treasurerolls;
        return rewards;
    }
    public int GetSellValue(){
        int sellValue = gold;
        foreach (Monster m in mods){
            sellValue -= m.gold;
        }
        return sellValue;
    }
    public bool IsMod(){
        return isMod;
    }
    public void IsMod(bool _isMod){
        isMod = _isMod;
    }
    public void setMods(List<Monster> _mods){
        mods = _mods;
        foreach (Monster m in _mods){
            gold += m.gold;
            goldpertier += m.goldpertier;
            treasurerolls += m.treasurerolls;
            qualitytreasure += m.qualitytreasure;
            victorypoints += m.victorypoints;
            regen += m.regen;
            pierce = pierce || m.pierce;
            clericattackaddshieldbreak += m.clericattackaddshieldbreak;
            attackaddhoming = attackaddhoming || m.attackaddhoming;
            attackaddpierce = attackaddpierce || m.attackaddpierce;
            defenseaddabilityshield += m.defenseaddabilityshield;
            allboost += m.allboost;
            maxhealth += m.maxhealth;
            maxhealthpertier += m.maxhealthpertier;
            evade += m.evade;
            rogueallboost += m.rogueallboost;
            rogueevade += m.rogueevade;
            mageallboost += m.mageallboost;
            armor += m.armor;
            warriorarmor += m.warriorarmor;
            warriorpierce = warriorpierce || m.warriorpierce;
            playeralldropperarmorevade += m.playeralldropperarmorevade;
            tier1upgrade = tier1upgrade || m.tier1upgrade;
            specialdiscardhandsdrawlimited = specialdiscardhandsdrawlimited || m.specialdiscardhandsdrawlimited;
            specialflee = specialflee || m.specialflee;
            bonusaction += m.bonusaction;
            ethereal += m.ethereal;
        }
    }
    public List<Monster> getMods(){
        return mods;
    }
    public void setStats(int health, int shields, int powshields, int abishields, int abipowshields, int trainshields){
        currentHP = health;
        currentShields = shields;
        currentPowerShields = powshields;
        currentAbilityShields = abishields;
        currentAbilityPowerShields = abipowshields;
        trainedShields = trainshields;
    }
    public int Tier(){
        return tier;
    }
    public bool getAllRewarded(){
        return allrewarded;
    }
    public float[] GetGem(){
        return new float[]{warriorgem,clericgem,roguegem,magegem};
    }
    public Monster Clone(){
        Monster mon = new Monster();
        mon.cardImage = cardImage;
        mon.monName = monName;
        mon.subtype = subtype;
        mon.tier = tier;
        mon.gold = gold;
        mon.commontreasure = commontreasure;
        mon.qualitytreasure = qualitytreasure;
        mon.victorypoints = victorypoints;
        mon.clericgem = clericgem;
        mon.warriorgem = warriorgem;
        mon.roguegem = roguegem;
        mon.magegem = magegem;
        mon.shield = shield;
        mon.powershield = powershield;
        mon.evade = evade;
        mon.armor = armor;
        mon.damagereducedpercombatant = damagereducedpercombatant;
        mon.limithands = limithands;
        mon.alldamagereduced = alldamagereduced;
        mon.regen = regen;
        mon.gem1regen = gem1regen;
        mon.gem2regen = gem2regen;
        mon.gem4regen = gem4regen;
        mon.gem1skillboost = gem1skillboost;
        mon.gem2skillboost = gem2skillboost;
        mon.gem1allboost = gem1allboost;
        mon.gem2allboost = gem2allboost;
        mon.gem3allboost = gem3allboost;
        mon.gem1skilldrop = gem1skilldrop;
        mon.gem2skilldrop = gem2skilldrop;
        mon.gem1evade = gem1evade;
        mon.gem2evade = gem2evade;
        mon.gem4evade = gem4evade;
        mon.gem1armor = gem1armor;
        mon.gem2armor = gem2armor;
        mon.defense = defense;
        mon.defenseattack = defenseattack;
        mon.defensecounterattack = defensecounterattack;
        mon.defensegem = defensegem;
        mon.defgem1heal = defgem1heal;
        mon.defgem3heal = defgem3heal;
        mon.defgem3abilityshield = defgem3abilityshield;
        mon.defgem4flee = defgem4flee;
        mon.defenseshield = defenseshield;
        mon.defensepowershield = defensepowershield;
        mon.defenseshieldrestore = defenseshieldrestore;
        mon.defenseheal = defenseheal;
        mon.defenseenergy = defenseenergy;
        mon.defensespellboost = defensespellboost;
        mon.defenseinflictfear = defenseinflictfear;
        mon.balanced = balanced; 
        mon.balancedboostformissing10health = balancedboostformissing10health;
        mon.balancedshieldrestore = balancedshieldrestore;
        mon.balancedforceplayerdiscardhand = balancedforceplayerdiscardhand;
        mon.balancedcollateralbydiscard = balancedcollateralbydiscard;
        mon.balancedboostbyshieldcount = balancedboostbyshieldcount;
        mon.balanceshieldbreakbyshieldcount = balanceshieldbreakbyshieldcount;
        mon.balancedsacrificeshields = balancedsacrificeshields;
        mon.balancedhealforplayersdamaged = balancedhealforplayersdamaged;
        mon.balancedboostbyattackforcediscard = balancedboostbyattackforcediscard;
        mon.balancedgem2spellboost = balancedgem2spellboost;
        mon.balancedgem2homing = balancedgem2homing;
        mon.balanceattack = balanceattack;
        mon.offense = offense;
        mon.offenseboostbyshieldcount = offenseboostbyshieldcount;
        mon.offensesacrificeshields = offensesacrificeshields;
        mon.offensereducebycardsinhand = offensereducebycardsinhand;
        mon.offenseattack = offenseattack;
        mon.offenseselfdamage = offenseselfdamage;
        mon.offensegem2energy = offensegem2energy;
        mon.offensegem = offensegem;
        mon.offenseinflictburning = offenseinflictburning;
        mon.offenseinflictcrippled = offenseinflictcrippled;
        mon.special = special;
        mon.specialrollcombatandboost = specialrollcombatandboost;
        mon.specialrollskillandboost = specialrollskillandboost;
        mon.specialrollswordskillboost = specialrollswordskillboost;
        mon.specialrollshieldgem3pierce = specialrollshieldgem3pierce;
        mon.specialrollshieldgem3heal = specialrollshieldgem3heal;
        mon.specialrollshieldheal = specialrollshieldheal;
        mon.specialrollshieldshieldbreak = specialrollshieldshieldbreak;
        mon.specialrollspecialpierce = specialrollspecialpierce;
        mon.specialattack = specialattack;
        mon.specialdiscardhandsdrawlimited = specialdiscardhandsdrawlimited;
        mon.specialgem = specialgem;
        mon.specialheal = specialheal;
        mon.specialrollcombatasattack = specialrollcombatasattack;
        mon.specialskillboost = specialskillboost;
        mon.specialrollskillandpair = specialrollskillandpair;
        mon.specialmill = specialmill;
        mon.specialmillattack = specialmillattack;
        mon.specialmilldefenseheal = specialmilldefenseheal;
        mon.specialmilltechniqueallboost = specialmilltechniqueallboost;
        mon.specialmilltechniquepierce = specialmilltechniquepierce;
        mon.specialinflictslowed = specialinflictslowed;
        mon.specialenergy = specialenergy;
        mon.specialdefense = specialdefense;
        mon.specialdefenseattack = specialdefenseattack;
        mon.specialdefenseheal = specialdefenseheal;
        mon.specialoffense = specialoffense;
        mon.specialoffensegem = specialoffensegem;
        mon.specialoffenseenergy = specialoffenseenergy;
        //Mosnter Mod variables
        mon.goldpertier = goldpertier;
        mon.treasurerolls = treasurerolls;
        mon.pierce = pierce;
        mon.clericattackaddshieldbreak = clericattackaddshieldbreak;
        mon.attackaddhoming = attackaddhoming;
        mon.attackaddpierce = attackaddpierce;
        mon.defenseaddabilityshield = defenseaddabilityshield;
        mon.allboost = allboost;
        mon.maxhealth = maxhealth;
        mon.maxhealthpertier = maxhealthpertier;
        mon.rogueallboost = rogueallboost;
        mon.rogueevade = rogueevade;
        mon.mageallboost = mageallboost;
        mon.warriorarmor = warriorarmor;
        mon.warriorpierce = warriorpierce;
        mon.playeralldropperarmorevade = playeralldropperarmorevade;
        mon.tier1upgrade = tier1upgrade;
        mon.specialflee = specialflee;
        mon.bonusaction = bonusaction;
        mon.ethereal = ethereal;
        mon.isMod = isMod;
        return mon;
    }
    
}
