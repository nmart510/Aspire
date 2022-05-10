using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class Ability
{
    Sprite cardImage;
    string name;
    string source;
    string type;
    List<string> attributes = new List<string>();
    int damage=0;
    bool homing=false;
    bool pierce=false;
    bool collateral=false;
    int shieldbreak=0;
    int shield=0;
    int powershield=0;
    bool shieldrestore=false;
    int draw=0;
    int energy=0;
    int heal=0;
    int spellboost=0;
    int strikeboost=0;
    bool flee=false;
    int evade=0;
    bool critical=false;
    int critdamage=0;
    bool crithoming=false;
    bool critpierce=false;
    bool critcollateral=false;
    int critshieldbreak=0;
    int critshield=0;
    int critpowershield=0;
    bool critshieldrestore=false;
    int critdraw=0;
    int critenergy=0;
    int critheal=0;
    int critspellboost=0;
    int critstrikeboost=0;
    //Values below change and need to be handled.
    bool critSuccess = false;
    int currentShields = 0;
    int cardvalue = 0;

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
            if (value[0].CompareTo("value")==0){
                int.TryParse(value[1], out int num);
                cardvalue = num;
            }
            if (value[0].CompareTo("attributes")==0){
                string[] atts = value[1].Split(',');
                for (int i = 0; i < atts.Length; i++)
                    attributes.Add(atts[i]);
            }
            if (value[0].CompareTo("damage")==0){
                int.TryParse(value[1], out int num);
                damage = num;
            }
            if (value[0].CompareTo("homing")==0){
                bool.TryParse(value[1], out bool val);
                homing = val;
            }
            if (value[0].CompareTo("pierce")==0){
                bool.TryParse(value[1], out bool val);
                pierce = val;
            }
            if (value[0].CompareTo("collateral")==0){
                bool.TryParse(value[1], out bool val);
                collateral = val;
            }
            if (value[0].CompareTo("shieldbreak")==0){
                int.TryParse(value[1], out int num);
                shieldbreak = num;
            }
            if (value[0].CompareTo("shield")==0){
                int.TryParse(value[1], out int num);
                shield = num;
            }
            if (value[0].CompareTo("powershield")==0){
                int.TryParse(value[1], out int num);
                powershield = num;
            }
            if (value[0].CompareTo("shieldrestore")==0){
                bool.TryParse(value[1], out bool val);
                shieldrestore = val;
            }
            if (value[0].CompareTo("energy")==0){
                int.TryParse(value[1], out int num);
                energy = num;
            }
            if (value[0].CompareTo("draw")==0){
                int.TryParse(value[1], out int num);
                draw = num;
            }
            if (value[0].CompareTo("heal")==0){
                int.TryParse(value[1], out int num);
                heal = num;
            }
            if (value[0].CompareTo("spellboost")==0){
                int.TryParse(value[1], out int num);
                spellboost = num;
            }
            if (value[0].CompareTo("strikeboost")==0){
                int.TryParse(value[1], out int num);
                strikeboost = num;
            }
            if (value[0].CompareTo("flee")==0){
                bool.TryParse(value[1], out bool val);
                flee = val;
            }
            if (value[0].CompareTo("evade")==0){
                int.TryParse(value[1], out int num);
                evade = num;
            }
            if (value[0].CompareTo("critical")==0){
                bool.TryParse(value[1], out bool val);
                critical = val;
            }
            if (value[0].CompareTo("critdamage")==0){
                int.TryParse(value[1], out int num);
                critdamage = num;
            }
            if (value[0].CompareTo("crithoming")==0){
                bool.TryParse(value[1], out bool val);
                crithoming = val;
            }
            if (value[0].CompareTo("critpierce")==0){
                bool.TryParse(value[1], out bool val);
                critpierce = val;
            }
            if (value[0].CompareTo("critcollateral")==0){
                bool.TryParse(value[1], out bool val);
                critcollateral = val;
            }
            if (value[0].CompareTo("critshieldbreak")==0){
                int.TryParse(value[1], out int num);
                critshieldbreak = num;
            }
            if (value[0].CompareTo("critshield")==0){
                int.TryParse(value[1], out int num);
                critshield = num;
            }
            if (value[0].CompareTo("critpowershield")==0){
                int.TryParse(value[1], out int num);
                critpowershield = num;
            }
            if (value[0].CompareTo("critshieldrestore")==0){
                bool.TryParse(value[1], out bool val);
                critshieldrestore = val;
            }
            if (value[0].CompareTo("critenergy")==0){
                int.TryParse(value[1], out int num);
                critenergy = num;
            }
            if (value[0].CompareTo("critdraw")==0){
                int.TryParse(value[1], out int num);
                critdraw = num;
            }
            if (value[0].CompareTo("critheal")==0){
                int.TryParse(value[1], out int num);
                critheal = num;
            }
            if (value[0].CompareTo("critspellboost")==0){
                int.TryParse(value[1], out int num);
                critspellboost = num;
            }
            if (value[0].CompareTo("critstrikeboost")==0){
                int.TryParse(value[1], out int num);
                critstrikeboost = num;
            }
        }
    }
    public Sprite Image(){
        return cardImage;
    }
    public int getShields(){
        if (critSuccess)
            return shield + critshield;
        return shield;
    }
    public int getPowerShields(){
        if (critSuccess)
            return powershield + critpowershield;
        return powershield;
    }
    public int RollSuccess(){
        if (critical){
            int roll = Random.Range(1,7);
            if (roll == 6) critSuccess = true;
            else critSuccess = false;
            return roll;
        } return 0;
    }
    public bool isAttack(){
        for (int a = 0; a < attributes.Count; a++)
            if(attributes[a].CompareTo("Attack")==0) return true;
        return false;
    }
    public int[] GetDamage(){
        int[] damages = new int[2];
        damages[0] = shieldbreak;
        damages[1] = damage;
        if (critSuccess){
            damages[0]+=critshieldbreak;
            damages[1]+=critdamage;
        }
        return damages;
    }
    public bool[] GetDamageType(){
        bool[] types = new bool[3];
        //homing, pierce, collateral
        types[0] = homing;
        types[1] = pierce;
        types[2] = collateral;
        if (critSuccess){
            types[0] = homing || crithoming;
            types[1] = pierce || critpierce;
            types[2] = collateral || critcollateral;
        }
        return types;
    }
    public string GetSPSK(){
        return type;
    }
    public string getName(){
        return name;
    }
    public bool RestoresShields(){
        if (critSuccess) return shieldrestore || critshieldrestore;
        return shieldrestore;
    }
    public int getDraw(){
        if (critSuccess)
            return draw + critdraw;
        return draw;
    }
    public int getEnergy(){
        if (critSuccess)
            return energy + critenergy;
        return energy;
    }
    public int getHeal(){
        if (critSuccess)
            return heal + critheal;
        return heal;
    }
    public int getSPBoost(){
        if (critSuccess)
            return spellboost + critspellboost;
        return spellboost;
    }
    public int getSKBoost(){
        if (critSuccess)
            return strikeboost + critstrikeboost;
        return strikeboost;
    }
    public int getEvade(){
        return evade;
    }
    public bool RunsAway(){
        return flee;
    }
    public void Reset(){
        critSuccess = false;
        currentShields = 0;
    }
    public void SetShields(){
        if (critSuccess)
            currentShields = shield + critshield + powershield + critpowershield;
        else currentShields = shield + powershield;
    }
    public void DamageSheilds(int num){
        currentShields -= num;
        if (currentShields < 0) currentShields = 0;
    }
    public int[] getCurrentDefenses(){
        //[0] Type (0 = regular, 1 = power)
        //[1] current
        //[2] max
        int[] defenses = new int[3];
        if (shield > 0){
            defenses[0] = 0;
            defenses[1] = currentShields;
            defenses[2] = critSuccess? shield + critshield : shield;
        } else {
            defenses[0] = 1;
            defenses[1] = currentShields;
            defenses[2] = critSuccess? powershield + critpowershield : powershield;
        }
        return defenses;
    }
    public int getValue(){
        return cardvalue;
    }
    public bool IsBasicOrClass(){
        return (source.CompareTo("Basic")==0 || source.CompareTo("Class")==0)? true: false;
    }
    public Ability Clone(){
        Ability temp = new Ability();
        temp.cardImage = cardImage;
        temp.name = name;
        temp.source = source;
        temp.type = type;
        temp.cardvalue = cardvalue;
        temp.attributes = attributes;
        temp.damage=damage;
        temp.homing=homing;
        temp.pierce=pierce;
        temp.collateral=collateral;
        temp.shieldbreak=shieldbreak;
        temp.shield=shield;
        temp.powershield=powershield;
        temp.shieldrestore=shieldrestore;
        temp.draw=draw;
        temp.energy=energy;
        temp.heal=heal;
        temp.spellboost=spellboost;
        temp.strikeboost=strikeboost;
        temp.flee=flee;
        temp.evade=evade;
        temp.critical=critical;
        temp.critdamage=critdamage;
        temp.crithoming=crithoming;
        temp.critpierce=critpierce;
        temp.critcollateral=critcollateral;
        temp.critshieldbreak=critshieldbreak;
        temp.critshield=critshield;
        temp.critpowershield=critpowershield;
        temp.critshieldrestore=critshieldrestore;
        temp.critdraw=critdraw;
        temp.critenergy=critenergy;
        temp.critheal=critheal;
        temp.critspellboost=critspellboost;
        temp.critstrikeboost=critstrikeboost;
        return temp;
    }
}
