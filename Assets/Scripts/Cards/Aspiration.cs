using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class Aspiration{
    Sprite cardImage = null;
    string name = null;
    float magegem = 0;
    float warriorgem = 0;
    float clericgem = 0;
    float roguegem = 0;
    int victorypoint = 0;
    int tradeability = 0;
    int tradeitem = 0;
    int tradetrophy = 0;
    int tradegold = 0;
    bool mageequipped = false;
    bool warriorequipped = false;
    bool clericequipped = false;
    bool rogueequipped = false;
    bool hashoming = false;
    bool haspierce = false;
    bool hasshieldbreak = false;
    bool hasregen = false;
    bool hasarmor = false;
    bool hasevade = false;
    bool hasshield = false;
    bool haspowershield = false;
    int hasspells = 0;
    int playcards = 0;
    int playspells = 0;
    int defeatfast = 0;
    int dealdamage = 0;
    int preventdamage = 0;
    int drawextra = 0;
    bool defeathumanoid = false;
    bool defeatelemental = false;
    bool defeatbeast = false;
    bool defeatundead = false;
    int playdefense = 0;
    int playtechnique = 0;
    int playattack = 0;
    int playdifferent = 0;
    int vporclaim = 0;
    public void loadCard(string filepath, string imagepath){
        //Loading image
        byte[] imageData = System.IO.File.ReadAllBytes(imagepath);
        int width = 1125;
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
            if (value[0].CompareTo("magegem")==0)
                float.TryParse(value[1], out magegem);
            if (value[0].CompareTo("warriorgem")==0)
                float.TryParse(value[1], out warriorgem);
            if (value[0].CompareTo("clericgem")==0)
                float.TryParse(value[1], out clericgem);
            if (value[0].CompareTo("roguegem")==0)
                float.TryParse(value[1], out roguegem);
            if (value[0].CompareTo("victorypoint")==0)
                int.TryParse(value[1], out victorypoint);
            if (value[0].CompareTo("tradeability")==0)
                int.TryParse(value[1], out tradeability);
            if (value[0].CompareTo("tradeitem")==0)
                int.TryParse(value[1], out tradeitem);
            if (value[0].CompareTo("tradetrophy")==0)
                int.TryParse(value[1], out tradetrophy);
            if (value[0].CompareTo("tradegold")==0)
                int.TryParse(value[1], out tradegold);
            if (value[0].CompareTo("mageequipped")==0)
                bool.TryParse(value[1], out mageequipped);
            if (value[0].CompareTo("warriorequipped")==0)
                bool.TryParse(value[1], out warriorequipped);
            if (value[0].CompareTo("clericequipped")==0)
                bool.TryParse(value[1], out clericequipped);
            if (value[0].CompareTo("rogueequipped")==0)
                bool.TryParse(value[1], out rogueequipped);
            if (value[0].CompareTo("hashoming")==0)
                bool.TryParse(value[1], out hashoming);
            if (value[0].CompareTo("haspierce")==0)
                bool.TryParse(value[1], out haspierce);
            if (value[0].CompareTo("hasshieldbreak")==0)
                bool.TryParse(value[1], out hasshieldbreak);
            if (value[0].CompareTo("hasregen")==0)
                bool.TryParse(value[1], out hasregen);
            if (value[0].CompareTo("hasarmor")==0)
                bool.TryParse(value[1], out hasarmor);
            if (value[0].CompareTo("hasevade")==0)
                bool.TryParse(value[1], out hasevade);
            if (value[0].CompareTo("hasshield")==0)
                bool.TryParse(value[1], out hasshield);
            if (value[0].CompareTo("haspowershield")==0)
                bool.TryParse(value[1], out haspowershield);
            if (value[0].CompareTo("hasspells")==0)
                int.TryParse(value[1], out hasspells);
            if (value[0].CompareTo("playcards")==0)
                int.TryParse(value[1], out playcards);
            if (value[0].CompareTo("playspells")==0)
                int.TryParse(value[1], out playspells);
            if (value[0].CompareTo("defeatfast")==0)
                int.TryParse(value[1], out defeatfast);
            if (value[0].CompareTo("dealdamage")==0)
                int.TryParse(value[1], out dealdamage);
            if (value[0].CompareTo("preventdamage")==0)
                int.TryParse(value[1], out preventdamage);
            if (value[0].CompareTo("drawextra")==0)
                int.TryParse(value[1], out drawextra);
            if (value[0].CompareTo("defeathumanoid")==0)
                bool.TryParse(value[1], out defeathumanoid);
            if (value[0].CompareTo("defeatelemental")==0)
                bool.TryParse(value[1], out defeatelemental);
            if (value[0].CompareTo("defeatbeast")==0)
                bool.TryParse(value[1], out defeatbeast);
            if (value[0].CompareTo("defeatundead")==0)
                bool.TryParse(value[1], out defeatundead);
            if (value[0].CompareTo("playdefense")==0)
                int.TryParse(value[1], out playdefense);
            if (value[0].CompareTo("playtechnique")==0)
                int.TryParse(value[1], out playtechnique);
            if (value[0].CompareTo("play = falseattack")==0)
                int.TryParse(value[1], out playattack);
            if (value[0].CompareTo("playdifferent")==0)
                int.TryParse(value[1], out playdifferent);
            if (value[0].CompareTo("vporclaim")==0)
                int.TryParse(value[1], out vporclaim);
        }
    }
    public Aspiration Clone(){
        Aspiration temp = new Aspiration();
        temp.cardImage = cardImage;
        temp.name = name;
        temp.magegem = magegem;
        temp.warriorgem = warriorgem;
        temp.clericgem = clericgem;
        temp.roguegem = roguegem;
        temp.victorypoint = victorypoint;
        temp.tradeability = tradeability;
        temp.tradeitem = tradeitem;
        temp.tradetrophy = tradetrophy;
        temp.tradegold = tradegold;
        temp.mageequipped = mageequipped;
        temp.warriorequipped = warriorequipped;
        temp.clericequipped = clericequipped;
        temp.rogueequipped = rogueequipped;
        temp.hashoming = hashoming;
        temp.haspierce = haspierce;
        temp.hasshieldbreak = hasshieldbreak;
        temp.hasregen = hasregen;
        temp.hasarmor = hasarmor;
        temp.hasevade = hasevade;
        temp.hasshield = hasshield;
        temp.haspowershield = haspowershield;
        temp.hasspells = hasspells;
        temp.playcards = playcards;
        temp.playspells = playspells;
        temp.defeatfast = defeatfast;
        temp.dealdamage = dealdamage;
        temp.preventdamage = preventdamage;
        temp.drawextra = drawextra;
        temp.defeathumanoid = defeathumanoid;
        temp.defeatelemental = defeatelemental;
        temp.defeatbeast = defeatbeast;
        temp.defeatundead = defeatundead;
        temp.playdefense = playdefense;
        temp.playtechnique = playtechnique;
        temp.playattack = playattack;
        temp.playdifferent = playdifferent;
        temp.vporclaim = vporclaim;
        return temp;
    }
    public string GetName(){
        return name;
    }
    public Sprite Image(){
        return cardImage;
    }
    public int ScoreAmount(){
        return vporclaim;
    }
    public string IsTribute(){
        if (tradeability > 0) return "Ability";
        else if (tradetrophy > 0) return "Trophy";
        else if (tradeitem > 0) return "Item";
        else if (tradegold > 0) return "Gold";
        else return null;
    }
    public int GoldTribute(){
        return tradegold;
    }
    public bool HasRogueEquipped(){
        return rogueequipped;
    }
    public bool HasMageEquipped(){
        return mageequipped;
    }
    public bool HasWarriorEquipped(){
        return warriorequipped;
    }
    public bool HasClericEquipped(){
        return clericequipped;
    }
    public int ExtraCardsToDraw(){
        return drawextra;
    }
    public int PreventDamage(){
        return preventdamage;
    }
    public int DealDamage(){
        return dealdamage;
    }
    public int PlayCards(){
        return playcards;
    }
    public string DefeatMonster(){
        if (defeatbeast) return "Beast";
        if (defeatundead) return "Undead";
        if (defeatelemental) return "Elemental";
        if (defeathumanoid) return "Humanoid";
        return null;
    }
    public int PlayDefense(){
        return playdefense;
    }
    public int PlayAttack(){
        return playattack;
    }
    public int PlayTechnique(){
        return playtechnique;
    }
    public int PlayDifferent(){
        return playdifferent;
    }
    public int PlaySpells(){
        return playspells;
    }
    public int HaveSpells(){
        return hasspells;
    }
    public int DefeatFastTier(){
        return defeatfast;
    }
    public bool HaveArmor(){
        return hasarmor;
    }
    public bool HaveEvade(){
        return hasevade;
    }
    public bool HaveShields(){
        return hasshield;
    }
    public bool HavePowerShields(){
        return haspowershield;
    }
    public bool HaveRegen(){
        return hasregen;
    }
    public bool HaveShieldBreak(){
        return hasshieldbreak;
    }
    public bool HaveHoming(){
        return hashoming;
    }
    public bool HavePierce(){
        return haspierce;
    }
    public float[] GetGem(){
        return new float[]{warriorgem,clericgem,roguegem,magegem};
    }

}
