using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class Boss : Monster {
    string type = null;
    string counter = null;
    int health = 0;
    int consumeminionondeathheal = 0;
    int damagereduce = 0;
    int powershield = 0;
    bool replacestartingmod = false;
    int armor = 0;
    int regen = 0;
    int minion = 0;
    int damagereducedperminion = 0;
    int eachshieldgem = 0;
    string eachshieldattack = null;
    string defense = null;
    int defenseshield = 0;
    bool defenseshieldrestore = false;
    int defensegem = 0;
    int defensehealpergem = 0;
    int defenseforcediscard = 0;
    int defenseminion = 0;
    int defensehealperminion = 0;
    int defenseremoveminion = 0;
    int defenseheal = 0;
    string balanced = null;
    int balancedgem = 0;
    string balancedattack = null;
    int balancedshield = 0;
    string balancedcounterattack = null;
    int balancedminion = 0;
    int balancedboostperminion = 0;
    int balancedpowershield = 0;
    int eachswordminion = 0;
    string eachswordattack = null;
    string offense = null;
    int offensegem = 0;
    string offenseattack = null;
    int offensedelayedgem = 0;
    int offenseboostpergem = 0;
    int offenseminion = 0;
    int offenseboostperminion = 0;
    int offenseremoveminion = 0;
    bool offenseskillhoming = false;
    string special = null;
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
    string specialdefense = null;
    int specialdefensebonusmod = 0;
    int specialdefenseminion = 0;
    bool specialdefenseusedefense = false;
    int specialdefenseboostperminion = 0;
    string specialdefenseattack = null;
    int specialdefensegem = 0;
    int specialdefenseenergy = 0;
    string specialoffense = null;
    int specialoffense1gemskillboost = 0;
    int specialoffense2gemskillboost = 0;
    bool specialoffense3gempierce = false;
    int specialoffense4gemheal = 0;
    int specialoffense5gemskillboost = 0;
    int specialoffense6gemskillboost = 0;
    string specialoffenseattack = null;
    bool specialoffenseremoveallgems = false;
    int specialoffensegem = 0;
    bool specialoffenseuseoffense = false;
    int specialoffensebostperminion = 0;
    bool specialoffenseremoveallminions = false;
    //mod specific
    int maxhealth = 0;
    int gem = 0;
    int bonusturn = 0;
    bool bonusturnsignoremods = false;
    int playenergyforvp = 0;
    bool doublehealthgain = false;
    int playattackforvp = 0;

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
            if (value[0].CompareTo("bonusaction")==0) 
                int.TryParse(value[1], out health);
            if (value[0].CompareTo("bonusaction")==0) 
                int.TryParse(value[1], out consumeminionondeathheal);
            if (value[0].CompareTo("bonusaction")==0) 
                int.TryParse(value[1], out damagereduce);
            if (value[0].CompareTo("bonusaction")==0) 
                int.TryParse(value[1], out powershield);
            if (value[0].CompareTo("bn")==0) 
                bool.TryParse(value[1], out replacestartingmod);
            if (value[0].CompareTo("bonusaction")==0) 
                int.TryParse(value[1], out armor);
            if (value[0].CompareTo("bonusaction")==0) 
                int.TryParse(value[1], out regen);
            if (value[0].CompareTo("bonusaction")==0) 
                int.TryParse(value[1], out minion);
            if (value[0].CompareTo("bonusaction")==0) 
                int.TryParse(value[1], out damagereducedperminion);
            if (value[0].CompareTo("bonusaction")==0) 
                int.TryParse(value[1], out eachshieldgem);
            if (value[0].CompareTo("eachshieldattack")==0)
                eachshieldattack = value[1];
            if (value[0].CompareTo("defense")==0)
                defense = value[1];
            if (value[0].CompareTo("bonusaction")==0) 
                int.TryParse(value[1], out defenseshield);
            if (value[0].CompareTo("bn")==0) 
                bool.TryParse(value[1], out defenseshieldrestore);
            if (value[0].CompareTo("bonusaction")==0) 
                int.TryParse(value[1], out defensegem);
            if (value[0].CompareTo("bonusaction")==0) 
                int.TryParse(value[1], out defensehealpergem);
            if (value[0].CompareTo("bonusaction")==0) 
                int.TryParse(value[1], out defenseforcediscard);
            if (value[0].CompareTo("bonusaction")==0) 
                int.TryParse(value[1], out defenseminion);
            if (value[0].CompareTo("bonusaction")==0) 
                int.TryParse(value[1], out defensehealperminion);
            if (value[0].CompareTo("bonusaction")==0) 
                int.TryParse(value[1], out defenseremoveminion);
            if (value[0].CompareTo("bonusaction")==0) 
                int.TryParse(value[1], out defenseheal);
            if (value[0].CompareTo("balanced")==0)
                balanced = value[1];
            if (value[0].CompareTo("bonusaction")==0) 
                int.TryParse(value[1], out balancedgem);
            if (value[0].CompareTo("balancedattack")==0)
                balancedattack = value[1];
            if (value[0].CompareTo("bonusaction")==0) 
                int.TryParse(value[1], out balancedshield);
            if (value[0].CompareTo("balancedcounterattack")==0)
                balancedcounterattack = value[1];
            if (value[0].CompareTo("bonusaction")==0) 
                int.TryParse(value[1], out balancedminion);
            if (value[0].CompareTo("bonusaction")==0) 
                int.TryParse(value[1], out balancedboostperminion);
            if (value[0].CompareTo("bonusaction")==0) 
                int.TryParse(value[1], out balancedpowershield);
            if (value[0].CompareTo("bonusaction")==0) 
                int.TryParse(value[1], out eachswordminion);
            if (value[0].CompareTo("eachswordattack")==0)
                eachswordattack = value[1];
            if (value[0].CompareTo("offense")==0)
                offense = value[1];
            if (value[0].CompareTo("bonusaction")==0) 
                int.TryParse(value[1], out offensegem);
            if (value[0].CompareTo("offenseattack")==0)
                offenseattack = value[1];
            if (value[0].CompareTo("bonusaction")==0) 
                int.TryParse(value[1], out offensedelayedgem);
            if (value[0].CompareTo("bonusaction")==0) 
                int.TryParse(value[1], out offenseboostpergem);
            if (value[0].CompareTo("bonusaction")==0) 
                int.TryParse(value[1], out offenseminion);
            if (value[0].CompareTo("bonusaction")==0) 
                int.TryParse(value[1], out offenseboostperminion);
            if (value[0].CompareTo("bonusaction")==0) 
                int.TryParse(value[1], out offenseremoveminion);
            if (value[0].CompareTo("bn")==0) 
                bool.TryParse(value[1], out offenseskillhoming);
            if (value[0].CompareTo("name")==0)
                special = value[1];
            if (value[0].CompareTo("name")==0)
                specialgem1attack = value[1];
            if (value[0].CompareTo("name")==0)
                specialgem2attack = value[1];
            if (value[0].CompareTo("name")==0)
                specialgem3attack = value[1];
            if (value[0].CompareTo("bonusaction")==0) 
                int.TryParse(value[1], out specialgem3heal);
            if (value[0].CompareTo("name")==0)
                specialgem4attack = value[1];
            if (value[0].CompareTo("name")==0)
                specialgem5attack = value[1];
            if (value[0].CompareTo("bonusaction")==0) 
                int.TryParse(value[1], out specialgem5heal);
            if (value[0].CompareTo("name")==0)
                specialgem6attack = value[1];
            if (value[0].CompareTo("bonusaction")==0) 
                int.TryParse(value[1], out specialgem6energy);
            if (value[0].CompareTo("bn")==0) 
                bool.TryParse(value[1], out specialremoveallgems);
            if (value[0].CompareTo("name")==0)
                specialdefense = value[1];
            if (value[0].CompareTo("bonusaction")==0) 
                int.TryParse(value[1], out specialdefensebonusmod);
            if (value[0].CompareTo("bonusaction")==0) 
                int.TryParse(value[1], out specialdefenseminion);
            if (value[0].CompareTo("bn")==0) 
                bool.TryParse(value[1], out specialdefenseusedefense);
            if (value[0].CompareTo("bonusaction")==0) 
                int.TryParse(value[1], out specialdefenseboostperminion);
            if (value[0].CompareTo("name")==0)
                specialdefenseattack = value[1];
            if (value[0].CompareTo("bonusaction")==0) 
                int.TryParse(value[1], out specialdefensegem);
            if (value[0].CompareTo("bonusaction")==0) 
                int.TryParse(value[1], out specialdefenseenergy);
            if (value[0].CompareTo("name")==0)
                specialoffense = value[1];
            if (value[0].CompareTo("bonusaction")==0) 
                int.TryParse(value[1], out specialoffense1gemskillboost);
            if (value[0].CompareTo("bonusaction")==0) 
                int.TryParse(value[1], out specialoffense2gemskillboost);
            if (value[0].CompareTo("bn")==0) 
                bool.TryParse(value[1], out specialoffense3gempierce);
            if (value[0].CompareTo("bonusaction")==0) 
                int.TryParse(value[1], out specialoffense4gemheal);
            if (value[0].CompareTo("bonusaction")==0) 
                int.TryParse(value[1], out specialoffense5gemskillboost);
            if (value[0].CompareTo("bonusaction")==0) 
                int.TryParse(value[1], out specialoffense6gemskillboost);
            if (value[0].CompareTo("name")==0)
                specialoffenseattack = value[1];
            if (value[0].CompareTo("bn")==0) 
                bool.TryParse(value[1], out specialoffenseremoveallgems);
            if (value[0].CompareTo("bonusaction")==0) 
                int.TryParse(value[1], out specialoffensegem);
            if (value[0].CompareTo("bn")==0) 
                bool.TryParse(value[1], out specialoffenseuseoffense);
            if (value[0].CompareTo("bonusaction")==0) 
                int.TryParse(value[1], out specialoffensebostperminion);
            if (value[0].CompareTo("bn")==0) 
                bool.TryParse(value[1], out specialoffenseremoveallminions);
                //mod specific
            if (value[0].CompareTo("bonusaction")==0) 
                int.TryParse(value[1], out maxhealth);
            if (value[0].CompareTo("bonusaction")==0) 
                int.TryParse(value[1], out gem);
            if (value[0].CompareTo("bonusaction")==0) 
                int.TryParse(value[1], out bonusturn);
            if (value[0].CompareTo("bn")==0) 
                bool.TryParse(value[1], out bonusturnsignoremods);
            if (value[0].CompareTo("bonusaction")==0) 
                int.TryParse(value[1], out playenergyforvp);
            if (value[0].CompareTo("bn")==0) 
                bool.TryParse(value[1], out doublehealthgain);
            if (value[0].CompareTo("bonusaction")==0) 
                int.TryParse(value[1], out playattackforvp);

        }
    }

}
