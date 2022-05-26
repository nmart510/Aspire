using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class Equipment
{
    Sprite cardImage;
    string name;
    string source;
    string type;
    string subtype = null; 
    int itemvalue = 0;
    string classrestricted = null;
    int heal = 0;
    int regenshare = 0;
    bool daily = false;
    bool dailyused = false;
    int runboost = 0;
    int skilldrop = 0, spelldrop = 0, alldrop = 0, skillboost = 0, spellboost = 0, allboost = 0;
    int skillboostorpierce = 0;
    int shieldbreak = 0;
    bool spellsignore = false, skillsignore = false, allignore = false;
    bool consume = false;
    int collateral = 0;
    bool pierce = false, homing = false, spellpierce = false, skillhoming = false;
    string versitile = null;
    int vskillboost = 0, vspellboost = 0, vallboost = 0;
    int powershield = 0, shield = 0;
    int armor = 0, evade = 0;
    int regen = 0;
    bool cripple = false;
    bool discardhand = false;
    string unique = null;
    bool flee = false;
    bool skillattackcritical = false;
    bool skacstun = false;
    bool rogue = false;
    bool rluck = false, rskillhoming = false, rrerollenemy = false, ravoid = false;
    int revade = 0, rshieldbreakorskillignore = 0, rcounter = 0;
    string rversitile = null;
    bool rvselfslow = false;
    bool rskillattackcritical = false;
    int rskacenergy = 0;
    bool cleric = false;
    int cshield = 0, cpowershield = 0, cshieldcounter = 0, cshieldbreak = 0, callboost = 0, cspellboost = 0;
    bool cshieldother = false, cshieldheal = false;
    string cversitile = null;
    int cvskilldrop = 0, cvspellboost = 0;
    bool ccritical = false;
    int cspacspellboost = 0, cspdcheal = 0, csptcenergy = 0;
    bool mage = false;
    int mspellboost = 0, mscry = 0, marmor = 0, menergy = 0;
    bool mspellpierce = false, msktospattack = false, mplaybottomofdeck = false;
    bool mspacritical = false;
    int mspacdraw = 0;
    bool warrior = false;
    bool wwarcry = false, warcryactive = false;
    int wheal = 0, wpowershield = 0, wskillboost = 0, wskillattackdraw = 0;
    bool wskillattackcritical = false;
    bool wskacpierceskillhoming = false;
    string wversitile = null;
    bool wtwohandbreakall = false;
    bool rhalf = false, mhalf = false, whalf = false, chalf = false, rwhalf = false, cmhalf = false, mrhalf = false;
    int t1shield = 0, t2shield = 0, t3allboost = 0,  t3regen = 0, t4armor = 0, t4evade = 0, t5armor = 0, t5evade = 0;
    int currentShields = 0, currentPowerShields = 0;
    Ability tomeLink = null;
    public void loadCard(string filepath, string imagepath){
        //Loading image
        byte[] imageData = System.IO.File.ReadAllBytes(imagepath);
        int width = 750;
        int height = 1125;
        Texture2D tex = new Texture2D(2,2);
        tex.LoadImage(imageData);
        cardImage = Sprite.Create(tex,new Rect(40,40,width-40,height-40),Vector2.zero);
        //Loading card and parsing it.
        var lines = File.ReadAllLines(filepath);
        //Breaks down each component of laoded file and populates values. Not all cards have all values.
        foreach (string line in lines){
            string[] value = line.Split(':');
            if (value[0].CompareTo("name")==0)
                name = value[1];
            if (value[0].CompareTo("source")==0)
                source = value[1];
            if (value[0].CompareTo("type")==0)
                type = value[1];
            if (value[0].CompareTo("subtype")==0)
                subtype = value[1];
            if (value[0].CompareTo("value")==0){
                int.TryParse(value[1], out int num);
                itemvalue = num;
            }
            if (value[0].CompareTo("classrestricted")==0)
                classrestricted = value[1];
            if (value[0].CompareTo("heal")==0){
                int.TryParse(value[1], out int num);
                heal = num;
            }
            if (value[0].CompareTo("regenshare")==0){
                int.TryParse(value[1], out int val);
                regenshare = val;
            }
            if (value[0].CompareTo("daily")==0){
                bool.TryParse(value[1], out bool val);
                daily = val;
            }
            if (value[0].CompareTo("runboost")==0){
                int.TryParse(value[1], out int num);
                runboost = num;
            }
            if (value[0].CompareTo("skilldrop")==0){
                int.TryParse(value[1], out int num);
                skilldrop = num;
            }
            if (value[0].CompareTo("spelldrop")==0){
                int.TryParse(value[1], out int num);
                spelldrop = num;
            }
            if (value[0].CompareTo("alldrop")==0){
                int.TryParse(value[1], out int num);
                alldrop = num;
            }
            if (value[0].CompareTo("skillboost")==0){
                int.TryParse(value[1], out int num);
                skillboost = num;
            }
            if (value[0].CompareTo("spellboost")==0){
                int.TryParse(value[1], out int num);
                spellboost = num;
            }
            if (value[0].CompareTo("allboost")==0){
                int.TryParse(value[1], out int num);
                allboost = num;
            }
            if (value[0].CompareTo("skillboostorpierce")==0){
                int.TryParse(value[1], out int num);
                skillboostorpierce = num;
            }
            if (value[0].CompareTo("shieldbreak")==0){
                int.TryParse(value[1], out int num);
                shieldbreak = num;
            }
            if (value[0].CompareTo("spellsignore")==0){
                bool.TryParse(value[1], out bool val);
                spellsignore = val;
            }
            if (value[0].CompareTo("skillsignore")==0){
                bool.TryParse(value[1], out bool val);
                skillsignore = val;
            }
            if (value[0].CompareTo("allignore")==0){
                bool.TryParse(value[1], out bool val);
                allignore = val;
            }
            if (value[0].CompareTo("consume")==0){
                bool.TryParse(value[1], out bool val);
                consume = val;
            }
            if (value[0].CompareTo("collateral")==0){
                int.TryParse(value[1], out int num);
                collateral = num;
            }
            if (value[0].CompareTo("pierce")==0){
                bool.TryParse(value[1], out bool val);
                pierce = val;
            }
            if (value[0].CompareTo("homing")==0){
                bool.TryParse(value[1], out bool val);
                homing = val;
            }
            if (value[0].CompareTo("versitile")==0)
                versitile = value[1];
            if (value[0].CompareTo("vskillboost")==0){
                int.TryParse(value[1], out int num);
                vskillboost = num;
            }
            if (value[0].CompareTo("vspellboost")==0){
                int.TryParse(value[1], out int num);
                vspellboost = num;
            }
            if (value[0].CompareTo("vallboost")==0){
                int.TryParse(value[1], out int num);
                vallboost = num;
            }
            if (value[0].CompareTo("powershield")==0){
                int.TryParse(value[1], out int num);
                powershield = num;
            }
            if (value[0].CompareTo("shield")==0){
                int.TryParse(value[1], out int num);
                shield = num;
            }
            if (value[0].CompareTo("armor")==0){
                int.TryParse(value[1], out int num);
                armor = num;
            }
            if (value[0].CompareTo("evade")==0){
                int.TryParse(value[1], out int num);
                evade = num;
            }
            if (value[0].CompareTo("regen")==0){
                int.TryParse(value[1], out int num);
                regen = num;
            }
            if (value[0].CompareTo("cripple")==0){
                bool.TryParse(value[1], out bool val);
                cripple = val;
            }
            if (value[0].CompareTo("discardhand")==0){
                bool.TryParse(value[1], out bool val);
                discardhand = val;
            }
            if (value[0].CompareTo("unique")==0)
                unique = value[1];
            if (value[0].CompareTo("flee")==0){
                bool.TryParse(value[1], out bool val);
                flee = val;
            }
            if (value[0].CompareTo("skillattackcritical")==0){
                bool.TryParse(value[1], out bool val);
                skillattackcritical = val;
            }
            if (value[0].CompareTo("skacstun")==0){
                bool.TryParse(value[1], out bool val);
                skacstun = val;
            }
            if (value[0].CompareTo("rogue")==0){
                bool.TryParse(value[1], out bool val);
                rogue = val;
            }
            if (value[0].CompareTo("rluck")==0){
                bool.TryParse(value[1], out bool val);
                rluck = val;
            }
            if (value[0].CompareTo("rskillhoming")==0){
                bool.TryParse(value[1], out bool val);
                rskillhoming = val;
            }
            if (value[0].CompareTo("rshieldbreakorskillignore")==0){
                int.TryParse(value[1], out int num);
                rshieldbreakorskillignore = num;
            }
            if (value[0].CompareTo("rrerollenemy")==0){
                bool.TryParse(value[1], out bool val);
                rrerollenemy = val;
            }
            if (value[0].CompareTo("rversitile")==0)
                rversitile = value[1];
            if (value[0].CompareTo("rvselfslow")==0){
                bool.TryParse(value[1], out bool val);
                rvselfslow = val;
            }
            if (value[0].CompareTo("rskillattackcritical")==0){
                bool.TryParse(value[1], out bool val);
                rskillattackcritical = val;
            }
            if (value[0].CompareTo("rskacenergy")==0){
                int.TryParse(value[1], out int num);
                rskacenergy = num;
            }
            if (value[0].CompareTo("revade")==0){
                int.TryParse(value[1], out int num);
                revade = num;
            }
            if (value[0].CompareTo("ravoid")==0){
                bool.TryParse(value[1], out bool val);
                ravoid = val;
            }
            if (value[0].CompareTo("rcounter")==0)
            if (value[0].CompareTo("cleric")==0){
                bool.TryParse(value[1], out bool val);
                cleric = val;
            }
            if (value[0].CompareTo("cshield")==0){
                int.TryParse(value[1], out int num);
                cshield = num;
            }
            if (value[0].CompareTo("cpowershield")==0){
                int.TryParse(value[1], out int num);
                cpowershield = num;
            }
            if (value[0].CompareTo("cshieldother")==0){
                bool.TryParse(value[1], out bool val);
                cshieldother = val;
            }
            if (value[0].CompareTo("cshieldheal")==0){
                bool.TryParse(value[1], out bool val);
                cshieldheal = val;
            }
            if (value[0].CompareTo("cshieldcounter")==0){
                int.TryParse(value[1], out int num);
                cshieldcounter = num;
            }
            if (value[0].CompareTo("cspellboost")==0){
                int.TryParse(value[1], out int num);
                cvspellboost = num;
            }
            if (value[0].CompareTo("cshieldbreak")==0){
                int.TryParse(value[1], out int num);
                cshieldbreak = num;
            }
            if (value[0].CompareTo("cversitile")==0)
                cversitile = value[1];
            if (value[0].CompareTo("cvskilldrop")==0){
                int.TryParse(value[1], out int num);
                cvskilldrop = num;
            }
            if (value[0].CompareTo("cvspellboost")==0){
                int.TryParse(value[1], out int num);
                cvspellboost = num;
            }
            if (value[0].CompareTo("callboost")==0){
                int.TryParse(value[1], out int num);
                callboost = num;
            }
            if (value[0].CompareTo("ccritical")==0){
                bool.TryParse(value[1], out bool val);
                ccritical = val;
            }
            if (value[0].CompareTo("cspacspellboost")==0){
                int.TryParse(value[1], out int num);
                cspacspellboost = num;
            }
            if (value[0].CompareTo("cspdcheal")==0){
                int.TryParse(value[1], out int num);
                cspdcheal = num;
            }
            if (value[0].CompareTo("csptcenergy")==0){
                int.TryParse(value[1], out int num);
                csptcenergy = num;
            }
            if (value[0].CompareTo("mage")==0){
                bool.TryParse(value[1], out bool val);
                mage = val;
            }
            if (value[0].CompareTo("mspellboost")==0){
                int.TryParse(value[1], out int num);
                mspellboost = num;
            }
            if (value[0].CompareTo("mspacritical")==0){
                bool.TryParse(value[1], out bool val);
                mspacritical = val;
            }
            if (value[0].CompareTo("mspacdraw")==0){
                int.TryParse(value[1], out int num);
                mspacdraw = num;
            }
            if (value[0].CompareTo("mscry")==0){
                int.TryParse(value[1], out int num);
                mscry = num;
            }
            if (value[0].CompareTo("marmor")==0){
                int.TryParse(value[1], out int num);
                marmor = num;
            }
            if (value[0].CompareTo("menergy")==0){
                int.TryParse(value[1], out int num);
                menergy = num;
            }
            if (value[0].CompareTo("mspellpierce")==0){
                bool.TryParse(value[1], out bool val);
                mspellpierce = val;
            }
            if (value[0].CompareTo("msktospattack")==0){
                bool.TryParse(value[1], out bool val);
                msktospattack = val;
            }
            if (value[0].CompareTo("mplaybottomofdeck")==0){
                bool.TryParse(value[1], out bool val);
                mplaybottomofdeck = val;
            }
            if (value[0].CompareTo("warrior")==0){
                bool.TryParse(value[1], out bool val);
                warrior = val;
            }
            if (value[0].CompareTo("wwarcry")==0){
                bool.TryParse(value[1], out bool val);
                wwarcry = val;
            }
            if (value[0].CompareTo("wheal")==0){
                int.TryParse(value[1], out int num);
                wheal = num;
            }
            if (value[0].CompareTo("wpowershield")==0){
                int.TryParse(value[1], out int num);
                wpowershield = num;
            }
            if (value[0].CompareTo("wskillboost")==0){
                int.TryParse(value[1], out int num);
                wskillboost = num;
            }
            if (value[0].CompareTo("wskillattackdraw")==0){
                int.TryParse(value[1], out int num);
                wskillattackdraw = num;
            }
            if (value[0].CompareTo("wskillattackcritical")==0){
                bool.TryParse(value[1], out bool val);
                wskillattackcritical = val;
            }
            if (value[0].CompareTo("wskacpierceskillhoming")==0){
                bool.TryParse(value[1], out bool val);
                wskacpierceskillhoming = val;
            }
            if (value[0].CompareTo("wversitile")==0)
                wversitile = value[1];
            if (value[0].CompareTo("wtwohandbreakall")==0){
                bool.TryParse(value[1], out bool val);
                wtwohandbreakall = val;
            }
            if (value[0].CompareTo("rhalf")==0){
                bool.TryParse(value[1], out bool val);
                rhalf = val;
            }
            if (value[0].CompareTo("mhalf")==0){
                bool.TryParse(value[1], out bool val);
                mhalf = val;
            }
            if (value[0].CompareTo("whalf")==0){
                bool.TryParse(value[1], out bool val);
                whalf = val;
            }
            if (value[0].CompareTo("chalf")==0){
                bool.TryParse(value[1], out bool val);
                chalf = val;
            }
            if (value[0].CompareTo("rwhalf")==0){
                bool.TryParse(value[1], out bool val);
                rwhalf = val;
            }
            if (value[0].CompareTo("cmhalf")==0){
                bool.TryParse(value[1], out bool val);
                cmhalf = val;
            }
            if (value[0].CompareTo("mrhalf")==0){
                bool.TryParse(value[1], out bool val);
                mrhalf = val;
            }
            if (value[0].CompareTo("t1shield")==0){
                int.TryParse(value[1], out int num);
                t1shield = num;
            }
            if (value[0].CompareTo("t2shield")==0){
                int.TryParse(value[1], out int num);
                t2shield = num;
            }
            if (value[0].CompareTo("t3allboost")==0){
                int.TryParse(value[1], out int num);
                t3allboost = num;
            }
            if (value[0].CompareTo("t3regen")==0){
                int.TryParse(value[1], out int num);
                t3regen = num;
            }
            if (value[0].CompareTo("t4armor")==0){
                int.TryParse(value[1], out int num);
                t4armor = num;
            }
            if (value[0].CompareTo("t4evade")==0){
                int.TryParse(value[1], out int num);
                t5evade = num;
            }
            if (value[0].CompareTo("t5armor")==0){
                int.TryParse(value[1], out int num);
                t4armor = num;
            }
            if (value[0].CompareTo("t5evade")==0){
                int.TryParse(value[1], out int num);
                t5evade = num;
            }
        }
    }
    public string[] GetEquipType(){
        string[] types = new string[2];
        types[0] = type; types[1] = subtype;
        if (subtype == null) types[1] = "";
        return types;
    }
    public string GetSource(){
        return source;
    }
    public Sprite Image(){
        return cardImage;
    }
    public string getName(){
        return name;
    }
    // checks to see if item has shields.
    public bool hasShields(string playerClass){
        if (shield > 0 || powershield > 0) return true;
        if (playerClass != null && playerClass.CompareTo("Warrior")==0 && wpowershield > 0 ) return true;
        if (playerClass != null && playerClass.CompareTo("Cleric")==0 && (cshield > 0 || cpowershield > 0)) return true;
        if (t1shield > 0) return true;
        else return false;
    }
    public int getArmor(string playerClass, int enemyTier){
        int totalArmor = armor;
        if (playerClass != null && playerClass.CompareTo("Mage")==0) totalArmor += marmor;
        if (enemyTier > 3) totalArmor += t4armor;
        if (enemyTier > 4) totalArmor += t5armor;
        return totalArmor;
    }
    public int getEvade(string playerClass, int enemyTier){
        int totalEvade = evade;
        if (playerClass != null && playerClass.CompareTo("Rogue")==0) totalEvade += revade;
        if (enemyTier > 3) totalEvade += t4evade;
        if (enemyTier > 4) totalEvade += t5evade;
        return totalEvade;
    }
    public int getShield(string playerClass, int enemyTier){
        int totalShield = shield;
        totalShield += t1shield;
        if (enemyTier > 1) totalShield += t2shield;
        if (playerClass != null && playerClass.CompareTo("Cleric")==0) totalShield += cshield;
        return totalShield;
    }
    public int getPowerShield(string playerClass){
        int totalPowerShield = powershield;
        if (playerClass != null && playerClass.CompareTo("Cleric")==0) totalPowerShield += cpowershield;
        if (playerClass != null && playerClass.CompareTo("Warrior")==0) totalPowerShield += wpowershield;
        return totalPowerShield;
    }
    public int getShieldBreak(string playerClass){
        int totalShieldBreak = shieldbreak;
        if (playerClass != null && playerClass.CompareTo("Cleric")==0 && cshieldbreak > 0) totalShieldBreak += cshieldbreak;
        return totalShieldBreak;
    }
    public int getSpellBoost(string playerClass, string equipSlot){
        int totalBoost = spellboost - spelldrop;
        if (versitile != null && equipSlot.CompareTo(versitile)==0) totalBoost += vspellboost;
        if (playerClass != null && playerClass.CompareTo("Cleric")==0){
            totalBoost += cspellboost;
            if (equipSlot.CompareTo(cversitile)==0) totalBoost += cvspellboost;
        }
        if (playerClass != null && playerClass.CompareTo("Mage")==0) totalBoost += mspellboost;
        return totalBoost;
    }
    public int getSkillBoost(string playerClass, string equipSlot){
        int totalBoost = skillboost - skilldrop;
        if (versitile != null && equipSlot.CompareTo(versitile)==0) totalBoost += vskillboost;
        if (playerClass != null && playerClass.CompareTo("Cleric")==0){
            if (equipSlot.CompareTo(cversitile)==0) totalBoost -= cvskilldrop;
        }
        if (playerClass != null && playerClass.CompareTo("Warrior")==0) totalBoost += wskillboost;
        return totalBoost;
    }
    public int getAllBoost(string playerClass, string equipSlot, int enemyTier){
        int totalBoost = allboost - alldrop;
        if (versitile != null && equipSlot.CompareTo(versitile)==0) totalBoost += vallboost;
        if (playerClass != null && playerClass.CompareTo("Cleric")==0) totalBoost += callboost;
        if (unique != null && unique.CompareTo("tierboost")==0) totalBoost += enemyTier;
        return totalBoost;
    }
    public bool isHoming(){
        return homing;
    }
    public bool isPierce(){
        return pierce;
    }
    public bool isSkillHoming(string playerClass){
        if (playerClass != null && playerClass.CompareTo("Rogue")==0 && rskillhoming) return true;
        else return skillhoming;
    }
    public bool isSpellPierce(string playerClass){
        if (playerClass != null && playerClass.CompareTo("Mage")==0 && mspellpierce) return true;
        else return spellpierce;
    }
    public bool isSpellIgnore(){
        return spellsignore;
    }
    public bool isSkillIgnore(){
        return skillsignore;
    }
    public int getValue(){
        return itemvalue;
    }
    public void linkAbility(Ability a){
        tomeLink = a;
        itemvalue = a.getValue();
        cardImage = a.Image();
        name += ":"+a.getName();
    }
    public Ability getLinkedAbility(){
        return tomeLink;
    }
    public bool IsBasic(){
        return (source.CompareTo("Basic")==0)? true : false;
    }
    public string getVersitile(){
        return versitile;
    }
    public int[] getCurrentShieldValues(){
        return new int[2]{currentShields,currentPowerShields};
    }
    public void restoreShields(){
        currentPowerShields = powershield;
        currentShields = shield;
    }
    public void damageShields(int damage){
        currentShields -= damage;
        if (currentShields < 0) currentShields = 0;
    }
    public void damagePowerShields(int damage){
        currentPowerShields -= damage;
        if (currentPowerShields < 0) currentPowerShields = 0;
    }
    public int Regen(int tier){
        int totalRegen = regen;
        if (tier >= 3) totalRegen += t3regen;
        return totalRegen;
    }
    public int SharedRegen(){
        return regenshare;
    }
    public bool IsRogue(){
        return rogue;
    }
    public bool IsMage(){
        return mage;
    }
    public bool IsWarrior(){
        return warrior;
    }
    public bool IsCleric(){
        return cleric;
    }
    public bool HasArmor(){
        if (armor > 0) return true;
        if (marmor > 0) return true;
        if (t4armor > 0) return true;
        if (t5armor > 0) return true;
        return false;
    }
    public bool HasEvade(){
        if (evade > 0) return true;
        if (revade > 0) return true;
        if (t4evade > 0) return true;
        if (t5evade > 0) return true;
        return false;
    }
    public bool hasShieldBreak(){
        if (shieldbreak > 0) return true;
        if (cshieldbreak > 0) return true;
        return false;
    }
    public bool HasRegen(){
        if (regen > 0) return true;
        if (t3regen > 0) return true;
        return false;
    }
    public Equipment Clone(){
        Equipment temp = new Equipment();
        temp.cardImage = cardImage;
        temp.name = name;
        temp.source = source;
        temp.type = type;
        temp.subtype = subtype; 
        temp.itemvalue = itemvalue;
        temp.classrestricted = classrestricted;
        temp.heal = heal;
        temp.regenshare = regenshare;
        temp.daily = daily;
        temp.runboost = runboost;
        temp.skilldrop = skilldrop; 
        temp.spelldrop = spelldrop; 
        temp.alldrop = alldrop; 
        temp.skillboost = skillboost; 
        temp.spellboost = spellboost; 
        temp.allboost = allboost;
        temp.skillboostorpierce = skillboostorpierce;
        temp.shieldbreak = shieldbreak;
        temp.spellsignore = spellsignore; 
        temp.skillsignore = skillsignore; 
        temp.allignore = allignore;
        temp.consume = consume;
        temp.collateral = collateral;
        temp.pierce = pierce; 
        temp.homing = homing; 
        temp.spellpierce = spellpierce; 
        temp.skillhoming = skillhoming;
        temp.versitile = versitile;
        temp.vskillboost = vskillboost; 
        temp.vspellboost = vspellboost; 
        temp.vallboost = vallboost;
        temp.powershield = powershield; 
        temp.shield = shield;
        temp.armor = armor; 
        temp.evade = evade;
        temp.regen = regen;
        temp.cripple = cripple;
        temp.discardhand = discardhand;
        temp.unique = unique;
        temp.flee = flee;
        temp.skillattackcritical = skillattackcritical;
        temp.skacstun = skacstun;
        temp.rogue = rogue;
        temp.rluck = rluck; 
        temp.rskillhoming = rskillhoming; 
        temp.rrerollenemy = rrerollenemy; 
        temp.ravoid = ravoid;
        temp.revade = revade; 
        temp.rshieldbreakorskillignore = rshieldbreakorskillignore; 
        temp.rcounter = rcounter;
        temp.rversitile = rversitile;
        temp.rvselfslow = rvselfslow;
        temp.rskillattackcritical = rskillattackcritical;
        temp.rskacenergy = rskacenergy;
        temp.cleric = cleric;
        temp.cshield = cshield; 
        temp.cpowershield = cpowershield; 
        temp.cshieldcounter = cshieldcounter; 
        temp.cshieldbreak = cshieldbreak; 
        temp.callboost = callboost; 
        temp.cspellboost = cspellboost;
        temp.cshieldother = cshieldother; 
        temp.cshieldheal = cshieldheal;
        temp.cversitile = cversitile;
        temp.cvskilldrop = cvskilldrop; 
        temp.cvspellboost = cvspellboost;
        temp.ccritical = ccritical;
        temp.cspacspellboost = cspacspellboost; 
        temp.cspdcheal = cspdcheal; 
        temp.csptcenergy = csptcenergy;
        temp.mage = mage;
        temp.mspellboost = mspellboost; 
        temp.mscry = mscry; 
        temp.marmor = marmor; 
        temp.menergy = menergy;
        temp.mspellpierce = mspellpierce; 
        temp.msktospattack = msktospattack; 
        temp.mplaybottomofdeck = mplaybottomofdeck;
        temp.mspacritical = mspacritical;
        temp.mspacdraw = mspacdraw;
        temp.warrior = warrior;
        temp.wwarcry = wwarcry; 
        temp.warcryactive = warcryactive;
        temp.wheal = wheal; 
        temp.wpowershield = wpowershield; 
        temp.wskillboost = wskillboost; 
        temp.wskillattackdraw = wskillattackdraw;
        temp.wskillattackcritical = wskillattackcritical;
        temp.wskacpierceskillhoming = wskacpierceskillhoming;
        temp.wversitile = wversitile;
        temp.wtwohandbreakall = wtwohandbreakall;
        temp.rhalf = rhalf; 
        temp.mhalf = mhalf; 
        temp.whalf = whalf; 
        temp.chalf = chalf; 
        temp.rwhalf = rwhalf; 
        temp.cmhalf = cmhalf; 
        temp.mrhalf = mrhalf;
        temp.t1shield = t1shield; 
        temp.t2shield = t2shield; 
        temp.t3allboost = t3allboost;  
        temp.t3regen = t3regen; 
        temp.t4armor = t4armor; 
        temp.t4evade = t4evade; 
        temp.t5armor = t5armor; 
        temp.t5evade = t5evade;


        return temp;
    }
}
