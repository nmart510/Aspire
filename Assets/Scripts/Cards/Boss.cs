using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class Boss : Monster {
    string type = null;
    string counter = null;
    int health = 0;
    int consumeminionondeathheal = 0;
    bool replacestartingmod = false;
    int minion = 0;
    int damagereducedperminion = 0;
    int eachshieldgem = 0;
    string eachshieldattack = null;
    int defensehealpergem = 0;
    int defenseforcediscard = 0;
    int defenseminion = 0;
    int defensehealperminion = 0;
    int defenseremoveminion = 0;
    int balancedgem = 0;
    string balancedattack = null;
    int balancedshield = 0;
    string balancedcounterattack = null;
    int balancedminion = 0;
    int balancedboostperminion = 0;
    int balancedpowershield = 0;
    int eachswordminion = 0;
    string eachswordattack = null;
    int offensedelayedgem = 0;
    int offenseboostpergem = 0;
    int offenseminion = 0;
    int offenseboostperminion = 0;
    int offenseremoveminion = 0;
    bool offenseskillhoming = false;
    string specialgem1attack = null;
    string specialgem2attack = null;
    string specialgem3attack = null;
    int specialgem3heal = 0;
    string specialgem4attack = null;
    string specialgem5attack = null;
    int specialgem5heal = 0;
    string specialgem6attack = null;
    int specialgem6energy = 0;
    bool specialremoveallgems = false;
    int specialdefensebonusmod = 0;
    int specialdefenseminion = 0;
    bool specialdefenseusedefense = false;
    int specialdefenseboostperminion = 0;
    int specialdefensegem = 0;
    int specialdefenseenergy = 0;
    int specialoffense1gemskillboost = 0;
    int specialoffense2gemskillboost = 0;
    bool specialoffense3gempierce = false;
    int specialoffense4gemheal = 0;
    int specialoffense5gemskillboost = 0;
    int specialoffense6gemskillboost = 0;
    string specialoffenseattack = null;
    bool specialoffenseremoveallgems = false;
    bool specialoffenseuseoffense = false;
    int specialoffensebostperminion = 0;
    bool specialoffenseremoveallminions = false;
    //mod specific
    int enragedhealth = 0;
    int gem = 0;
    int bonusturn = 0;
    bool bonusturnsignoremods = false;
    int playenergyforvp = 0;
    bool doublehealthgain = false;
    int playattackforvp = 0;
    int activedefenseforvp = 0;
    int playattackanddefenseforvp = 0;
    int dealdamagetohpforvp = 0;
    int nullifying = 0;
    int paylifetoignorenullifying = 0;
    int lowdamageforvp = 0;

    Boss starterMod;
    Boss enragedMod;
    Boss extraMod;
    bool extraThisTurn = false;
    int minionCount = 0;

    new public void loadCard(string filepath, string imagepath, bool _isMod){
        
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
            if (value[0].CompareTo("type")==0)
                type = value[1];
            if (value[0].CompareTo("counter")==0)
                counter = value[1];
            if (value[0].CompareTo("health")==0) 
                int.TryParse(value[1], out health);
            if (value[0].CompareTo("consumeminionondeathheal")==0) 
                int.TryParse(value[1], out consumeminionondeathheal);
            if (value[0].CompareTo("damagereduce")==0) 
                int.TryParse(value[1], out alldamagereduced);
            if (value[0].CompareTo("powershield")==0) 
                int.TryParse(value[1], out powershield);
            if (value[0].CompareTo("replacestartingmod")==0) 
                bool.TryParse(value[1], out replacestartingmod);
            if (value[0].CompareTo("armor")==0) 
                int.TryParse(value[1], out armor);
            if (value[0].CompareTo("regen")==0) 
                int.TryParse(value[1], out regen);
            if (value[0].CompareTo("minion")==0) 
                int.TryParse(value[1], out minion);
            if (value[0].CompareTo("damagereducedperminion")==0) 
                int.TryParse(value[1], out damagereducedperminion);
            if (value[0].CompareTo("eachshieldgem")==0) 
                int.TryParse(value[1], out eachshieldgem);
            if (value[0].CompareTo("eachshieldattack")==0)
                eachshieldattack = value[1];
            if (value[0].CompareTo("defense")==0)
                defense = value[1];
            if (value[0].CompareTo("defenseshield")==0) 
                int.TryParse(value[1], out defenseshield);
            if (value[0].CompareTo("defenseshieldrestore")==0) 
                bool.TryParse(value[1], out defenseshieldrestore);
            if (value[0].CompareTo("defensegem")==0) 
                int.TryParse(value[1], out defensegem);
            if (value[0].CompareTo("defensehealpergem")==0) 
                int.TryParse(value[1], out defensehealpergem);
            if (value[0].CompareTo("defenseforcediscard")==0) 
                int.TryParse(value[1], out defenseforcediscard);
            if (value[0].CompareTo("defenseminion")==0) 
                int.TryParse(value[1], out defenseminion);
            if (value[0].CompareTo("defensehealperminion")==0) 
                int.TryParse(value[1], out defensehealperminion);
            if (value[0].CompareTo("defenseremoveminion")==0) 
                int.TryParse(value[1], out defenseremoveminion);
            if (value[0].CompareTo("defenseheal")==0) 
                int.TryParse(value[1], out defenseheal);
            if (value[0].CompareTo("balanced")==0)
                balanced = value[1];
            if (value[0].CompareTo("balancedgem")==0) 
                int.TryParse(value[1], out balancedgem);
            if (value[0].CompareTo("balancedattack")==0)
                balancedattack = value[1];
            if (value[0].CompareTo("balancedshield")==0) 
                int.TryParse(value[1], out balancedshield);
            if (value[0].CompareTo("balancedcounterattack")==0)
                balancedcounterattack = value[1];
            if (value[0].CompareTo("balancedminion")==0) 
                int.TryParse(value[1], out balancedminion);
            if (value[0].CompareTo("balancedboostperminion")==0) 
                int.TryParse(value[1], out balancedboostperminion);
            if (value[0].CompareTo("balancedpowershield")==0) 
                int.TryParse(value[1], out balancedpowershield);
            if (value[0].CompareTo("eachswordminion")==0) 
                int.TryParse(value[1], out eachswordminion);
            if (value[0].CompareTo("eachswordattack")==0)
                eachswordattack = value[1];
            if (value[0].CompareTo("offense")==0)
                offense = value[1];
            if (value[0].CompareTo("offensegem")==0) 
                int.TryParse(value[1], out offensegem);
            if (value[0].CompareTo("offenseattack")==0)
                offenseattack = value[1];
            if (value[0].CompareTo("offensedelayedgem")==0) 
                int.TryParse(value[1], out offensedelayedgem);
            if (value[0].CompareTo("offenseboostpergem")==0) 
                int.TryParse(value[1], out offenseboostpergem);
            if (value[0].CompareTo("offenseminion")==0) 
                int.TryParse(value[1], out offenseminion);
            if (value[0].CompareTo("offenseboostperminion")==0) 
                int.TryParse(value[1], out offenseboostperminion);
            if (value[0].CompareTo("offenseremoveminion")==0) 
                int.TryParse(value[1], out offenseremoveminion);
            if (value[0].CompareTo("offenseskillhoming")==0) 
                bool.TryParse(value[1], out offenseskillhoming);
            if (value[0].CompareTo("special")==0)
                special = value[1];
            if (value[0].CompareTo("specialgem1attack")==0)
                specialgem1attack = value[1];
            if (value[0].CompareTo("specialgem2attack")==0)
                specialgem2attack = value[1];
            if (value[0].CompareTo("specialgem3attack")==0)
                specialgem3attack = value[1];
            if (value[0].CompareTo("specialgem3heal")==0) 
                int.TryParse(value[1], out specialgem3heal);
            if (value[0].CompareTo("specialgem4attack")==0)
                specialgem4attack = value[1];
            if (value[0].CompareTo("specialgem5attack")==0)
                specialgem5attack = value[1];
            if (value[0].CompareTo("specialgem5heal")==0) 
                int.TryParse(value[1], out specialgem5heal);
            if (value[0].CompareTo("specialgem6attack")==0)
                specialgem6attack = value[1];
            if (value[0].CompareTo("specialgem6energy")==0) 
                int.TryParse(value[1], out specialgem6energy);
            if (value[0].CompareTo("specialremoveallgems")==0) 
                bool.TryParse(value[1], out specialremoveallgems);
            if (value[0].CompareTo("specialdefense")==0)
                specialdefense = value[1];
            if (value[0].CompareTo("specialdefensebonusmod")==0) 
                int.TryParse(value[1], out specialdefensebonusmod);
            if (value[0].CompareTo("specialdefenseminion")==0) 
                int.TryParse(value[1], out specialdefenseminion);
            if (value[0].CompareTo("specialdefenseusedefense")==0) 
                bool.TryParse(value[1], out specialdefenseusedefense);
            if (value[0].CompareTo("specialdefenseboostperminion")==0) 
                int.TryParse(value[1], out specialdefenseboostperminion);
            if (value[0].CompareTo("specialdefenseattack")==0)
                specialdefenseattack = value[1];
            if (value[0].CompareTo("specialdefensegem")==0) 
                int.TryParse(value[1], out specialdefensegem);
            if (value[0].CompareTo("specialdefenseenergy")==0) 
                int.TryParse(value[1], out specialdefenseenergy);
            if (value[0].CompareTo("specialoffense")==0)
                specialoffense = value[1];
            if (value[0].CompareTo("specialoffense1gemskillboost")==0) 
                int.TryParse(value[1], out specialoffense1gemskillboost);
            if (value[0].CompareTo("specialoffense2gemskillboost")==0) 
                int.TryParse(value[1], out specialoffense2gemskillboost);
            if (value[0].CompareTo("specialoffense3gempierce")==0) 
                bool.TryParse(value[1], out specialoffense3gempierce);
            if (value[0].CompareTo("specialoffense4gemheal")==0) 
                int.TryParse(value[1], out specialoffense4gemheal);
            if (value[0].CompareTo("specialoffense5gemskillboost")==0) 
                int.TryParse(value[1], out specialoffense5gemskillboost);
            if (value[0].CompareTo("specialoffense6gemskillboost")==0) 
                int.TryParse(value[1], out specialoffense6gemskillboost);
            if (value[0].CompareTo("specialoffenseattack")==0)
                specialoffenseattack = value[1];
            if (value[0].CompareTo("specialoffenseremoveallgems")==0) 
                bool.TryParse(value[1], out specialoffenseremoveallgems);
            if (value[0].CompareTo("specialoffensegem")==0) 
                int.TryParse(value[1], out specialoffensegem);
            if (value[0].CompareTo("specialoffenseuseoffense")==0) 
                bool.TryParse(value[1], out specialoffenseuseoffense);
            if (value[0].CompareTo("specialoffensebostperminion")==0) 
                int.TryParse(value[1], out specialoffensebostperminion);
            if (value[0].CompareTo("specialoffenseremoveallminions")==0) 
                bool.TryParse(value[1], out specialoffenseremoveallminions);
                //mod specific
            if (value[0].CompareTo("maxhealth")==0) 
                int.TryParse(value[1], out enragedhealth);
            if (value[0].CompareTo("gem")==0) 
                int.TryParse(value[1], out gem);
            if (value[0].CompareTo("bonusturn")==0) 
                int.TryParse(value[1], out bonusturn);
            if (value[0].CompareTo("bonusturnsignoremods")==0) 
                bool.TryParse(value[1], out bonusturnsignoremods);
            if (value[0].CompareTo("playenergyforvp")==0) 
                int.TryParse(value[1], out playenergyforvp);
            if (value[0].CompareTo("doublehealthgain")==0) 
                bool.TryParse(value[1], out doublehealthgain);
            if (value[0].CompareTo("playattackforvp")==0) 
                int.TryParse(value[1], out playattackforvp);
            if (value[0].CompareTo("playattackforvp")==0) 
                int.TryParse(value[1], out activedefenseforvp);
            if (value[0].CompareTo("playattackforvp")==0) 
                int.TryParse(value[1], out playattackanddefenseforvp);
            if (value[0].CompareTo("playattackforvp")==0) 
                int.TryParse(value[1], out dealdamagetohpforvp);
            if (value[0].CompareTo("playattackforvp")==0) 
                bool.TryParse(value[1], out doublehealthgain);
            if (value[0].CompareTo("playattackforvp")==0) 
                int.TryParse(value[1], out playattackforvp);
            if (value[0].CompareTo("playattackforvp")==0) 
                int.TryParse(value[1], out nullifying);
            if (value[0].CompareTo("playattackforvp")==0) 
                int.TryParse(value[1], out paylifetoignorenullifying);
            if (value[0].CompareTo("playattackforvp")==0) 
                int.TryParse(value[1], out lowdamageforvp);
        }
    }
    public void setStarterMod(Boss mod){
        starterMod = mod;
        armor += mod.armor;
        evade += mod.evade;
        allboost += mod.allboost;
        activedefenseforvp += mod.activedefenseforvp;
        playattackanddefenseforvp += mod.playattackanddefenseforvp;
        dealdamagetohpforvp += mod.dealdamagetohpforvp;
        maxhealth += mod.maxhealth;
        gem += mod.gem;
        bonusturn += mod.bonusturn;
        bonusturnsignoremods = bonusturnsignoremods || mod.bonusturnsignoremods;
        playenergyforvp += mod.playenergyforvp;
        doublehealthgain = doublehealthgain || doublehealthgain;
        regen += mod.regen;
        playattackforvp += mod.playattackforvp;
        nullifying += mod.nullifying;
        paylifetoignorenullifying += mod.paylifetoignorenullifying;
        lowdamageforvp += mod.lowdamageforvp;
    }
    public void setEnragedMod(Boss mod){
        enragedMod = mod;
        armor += mod.armor;
        evade += mod.evade;
        allboost += mod.allboost;
        activedefenseforvp += mod.activedefenseforvp;
        playattackanddefenseforvp += mod.playattackanddefenseforvp;
        dealdamagetohpforvp += mod.dealdamagetohpforvp;
        maxhealth += mod.maxhealth;
        gem += mod.gem;
        bonusturn += mod.bonusturn;
        bonusturnsignoremods = bonusturnsignoremods || mod.bonusturnsignoremods;
        playenergyforvp += mod.playenergyforvp;
        doublehealthgain = doublehealthgain || mod.doublehealthgain;
        regen += mod.regen;
        playattackforvp += mod.playattackforvp;
        nullifying += mod.nullifying;
        paylifetoignorenullifying += mod.paylifetoignorenullifying;
        lowdamageforvp += mod.lowdamageforvp;
    }
    public void setExtraMod(Boss mod){
        extraMod = mod;
        extraThisTurn = true;

        armor += mod.armor;
        evade += mod.evade;
        allboost += mod.allboost;
        activedefenseforvp += mod.activedefenseforvp;
        playattackanddefenseforvp += mod.playattackanddefenseforvp;
        dealdamagetohpforvp += mod.dealdamagetohpforvp;
        maxhealth += mod.maxhealth;
        gem += mod.gem;
        bonusturn += mod.bonusturn;
        bonusturnsignoremods = bonusturnsignoremods || mod.bonusturnsignoremods;
        playenergyforvp += mod.playenergyforvp;
        doublehealthgain = doublehealthgain || mod.doublehealthgain;
        regen += mod.regen;
        playattackforvp += mod.playattackforvp;
        nullifying += mod.nullifying;
        paylifetoignorenullifying += mod.paylifetoignorenullifying;
        lowdamageforvp += mod.lowdamageforvp;
    }
    public Boss switchStarterMod(Boss mod){
        Boss temp = starterMod;
        starterMod = mod;

        armor += mod.armor - temp.armor;
        evade += mod.evade - temp.evade;
        allboost += mod.allboost - temp.allboost;
        activedefenseforvp += mod.activedefenseforvp - temp.activedefenseforvp;
        playattackanddefenseforvp += mod.playattackanddefenseforvp - temp.playattackanddefenseforvp;
        dealdamagetohpforvp += mod.dealdamagetohpforvp - temp.dealdamagetohpforvp;
        gem += mod.gem - temp.gem;
        bonusturn += mod.bonusturn - temp.bonusturn;
        if (temp.bonusturnsignoremods) bonusturnsignoremods = mod.bonusturnsignoremods;
        playenergyforvp += mod.playenergyforvp - temp.playenergyforvp;
        if (temp.doublehealthgain) doublehealthgain = mod.doublehealthgain;
        regen += mod.regen - temp.regen;
        playattackforvp += mod.playattackforvp - temp.playattackforvp;
        nullifying += mod.nullifying - temp.nullifying;
        paylifetoignorenullifying += mod.paylifetoignorenullifying - temp.paylifetoignorenullifying;
        lowdamageforvp += mod.lowdamageforvp - temp.lowdamageforvp;

        return temp;
    }
    public Boss removeExtraMod(){
        if (extraThisTurn) {
            extraThisTurn = false;
            return null;
        }
        else {
            Boss temp = extraMod;

            armor -= temp.armor;
            evade -= temp.evade;
            allboost -= temp.allboost;
            activedefenseforvp -= temp.activedefenseforvp;
            playattackanddefenseforvp -= temp.playattackanddefenseforvp;
            dealdamagetohpforvp -= temp.dealdamagetohpforvp;
            maxhealth -= temp.maxhealth;
            gem -= temp.gem;
            bonusturn -= temp.bonusturn;
            if (temp.bonusturnsignoremods) bonusturnsignoremods = false;
            playenergyforvp -= temp.playenergyforvp;
            if (temp.doublehealthgain) doublehealthgain = false;
            regen -= temp.regen;
            playattackforvp -= temp.playattackforvp;
            nullifying -= temp.nullifying;
            paylifetoignorenullifying -= temp.paylifetoignorenullifying;
            lowdamageforvp -= temp.lowdamageforvp;

            extraMod = null;
            return temp;
        } 
    }
    public Boss getStarterMod(){
        return starterMod;
    }
    public Boss getEnragedMod(){
        return enragedMod;
    }
    public Boss getExtraMod(){
        return extraMod;
    }
    public override int[] Health(){
        int[] hp = base.Health();
        hp[1] = health;
        return hp;
    }
    public bool usesMinions(){
        if (counter.CompareTo("Minion")==0)return true;
        else return false;
    }
    public int getGems(){
        return gemCount; 
    }
    public int getMinions(){
        return minionCount;
    }
    public void setGem(int count){
        gemCount = count;
    }
    public void setMinion(int count){
        minionCount = count;
    }
}
