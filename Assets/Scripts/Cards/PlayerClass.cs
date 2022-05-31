using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class PlayerClass{
    Sprite cardImage;
    string name;
    List<string> classes = new List<string>();
    int health = 0;
    int victorypoints = 0;
    string strikes = null;
    int clericgems = 0;
    int warriorgems = 0;
    int roguegems = 0;
    int magegems = 0;
    int anygems = 0;
    string ability = null;
    bool abilityUsed = false;

    public void loadCard(string filepath, string imagepath){
        //Loading image
        byte[] imageData = System.IO.File.ReadAllBytes(imagepath);
        int width = 975;
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
            if (value[0].CompareTo("classes")==0)
                classes.AddRange(value[1].Split(','));
            if (value[0].CompareTo("health")==0)
                int.TryParse(value[1],out int health);
            if (value[0].CompareTo("victorypoints")==0)
                int.TryParse(value[1],out int victorypoints);
            if (value[0].CompareTo("strikes")==0)
                name = value[1];
            if (value[0].CompareTo("clericgem")==0)
                int.TryParse(value[1],out int clericgems);
            if (value[0].CompareTo("warriorgem")==0)
                int.TryParse(value[1],out int warriorgems);
            if (value[0].CompareTo("roguegem")==0)
                int.TryParse(value[1],out int roguegems);
            if (value[0].CompareTo("magegem")==0)
                int.TryParse(value[1],out int magegems);
            if (value[0].CompareTo("anygem")==0)
                int.TryParse(value[1],out int anygem);
            if (value[0].CompareTo("ability")==0)
                ability = value[1];
        }
    }
    public string getName(){
        return name;
    }
    public Sprite Image(){
        return cardImage;
    }
    public int getHealth(){
        return health;
    }
    public int getVP(){
        return victorypoints;
    }
    public int[] gemRequirements(){
        return new int[]{warriorgems, clericgems, roguegems, magegems, anygems};
    }
    public string getStrikeReplacement(){
        return strikes;
    }
    public string getAbilityName(){
        return ability;
    }
    public void MarkAbilityUsed(){
        abilityUsed = true;
    }
    public bool AbilityUsed(){
        return abilityUsed;
    }
    public void ResetAbility(){
        abilityUsed = false;
    }

}
