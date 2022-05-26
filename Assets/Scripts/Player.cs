using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Net.Sockets;
using System.Text;

public class Player : MonoBehaviour
{
    string username;
    TcpClient client;
    NetworkStream stream;
    bool ready = false;
    bool inCombat = false;
    bool isTurn = false;
    bool isLead = false;
    int maxHP = 8;
    int currentHP = 8;
    int gold = 77;
    int victoryPoints = 0;
    int AP = 0;
    List<Equipment> arsenal = new List<Equipment>();
    Deck<Ability> deck = new Deck<Ability>();
    List<Monster> trophies = new List<Monster>();
    List<Aspiration> aspirations = new List<Aspiration>();
    Equipment equipArmor = null;
    Equipment equipMain = null;
    Equipment equipOff = null;
    Equipment equipExtra = null;
    Equipment equipTwoHand = null;
    Equipment aux1 = null;
    Equipment aux2 = null;
    Equipment aux3 = null;


    public string GetName(){
        return username;
    }
    public void SetName(string _name){
        username = _name;
    }
    void Awake(){
        DontDestroyOnLoad(transform.gameObject);
    }
    public void SetClient(string ip, int port){
        client = new TcpClient(ip, port);
        stream = client.GetStream();
    }
    public TcpClient GetClient(){
        return client;
    }
    public NetworkStream GetNetStream(){
        return stream;
    }
    public void Write(string message){
            byte[] data = System.Text.Encoding.ASCII.GetBytes(message+"/");
            stream.Write(data,0,data.Length);
    }
    public string Read(){
        byte[] data = new byte[256];
        stream.Read(data,0,data.Length);
        return Encoding.ASCII.GetString(data).Trim();
    }
    public bool IsReady(){
        return ready;
    }
    public void IsReady(bool _ready){
        ready = _ready;
    }
    public int[] getHealth(){
        int[] hp = new int[2];
        hp[0] = currentHP; hp[1] = maxHP; 
        return hp;
    }
    public void setHealth(int amount){
        currentHP = amount;
    }
    public void takeDamage(int amount){
        currentHP -= amount;
        if (currentHP < 0) currentHP = 0;
    }
    public void Heal(int amount){
        currentHP += amount;
        if (currentHP > maxHP) currentHP = maxHP;
    }
    public void changeGold(int amount){
        gold += amount;
    }
    public int getGold(){
        return gold;
    }
    public void changeVP(int amount){
        victoryPoints += amount;
    }
    public int getVP(){
        return victoryPoints;
    }
    public bool InCombat(){
        return inCombat;
    }
    public void InCombat(bool _inCombat){
        inCombat = _inCombat;
    }
    public bool IsTurn(){
        return isTurn;
    }
    public void IsTurn(bool _isTurn){
        isTurn = _isTurn;
    }
    public bool IsLead(){
        return isLead;
    }
    public void IsLead(bool _isLead){
        isLead = _isLead;
    }
    public void SetAP(int amount){
        AP = amount;
    }
    public void changeAP(int amount){
        AP += amount;
    }
    public int getAP(){
        return AP;
    }
    void Start(){
        BuildBasicDeck();
    }
    void BuildBasicDeck(){
        string filepath = Path.Combine(Directory.GetParent(Directory.GetCurrentDirectory()).FullName,@"AspireAssets\Abilities\");
        string basiclist = Path.Combine(filepath,@"BasicAbilities.txt");
        var lines = File.ReadAllLines(basiclist);
        for (int i = 0; i < lines.Length; i++){
            string[] info = lines[i].Split(':');
            string cardName = info[0];
            int.TryParse(info[1], out int count);
            for (int j = 0; j < count; j++){
                Ability a = new Ability();
                a.loadCard(Path.Combine(filepath,@"Info\"+cardName+".txt"),Path.Combine(filepath,@"Images\"+cardName+".png"));
                deck.Add(a);
            }
        }
        filepath = Path.Combine(Directory.GetParent(Directory.GetCurrentDirectory()).FullName,@"AspireAssets\Equipment\");
        basiclist = Path.Combine(filepath,@"BasicEquipment.txt");
        lines = File.ReadAllLines(basiclist);
        for (int i = 0; i < lines.Length; i++){
            string[] info = lines[i].Split(':');
            string cardName = info[0];
            int.TryParse(info[1], out int count);
            for (int j = 0; j < count; j++){
                Equipment e = new Equipment();
                e.loadCard(Path.Combine(filepath,@"Info\"+cardName+".txt"),Path.Combine(filepath,@"Images\"+cardName+".png"));
                arsenal.Add(e);
            }
        }
        //Automatically equip basic equipment
        foreach (Equipment e in arsenal){
            if (e.GetEquipType()[0].CompareTo("Armor") == 0)
                Equip("Armor",e);
            if (e.GetEquipType()[0].CompareTo("Main") == 0)
                Equip("Main",e);
            if (e.GetEquipType()[0].CompareTo("Auxiliary") == 0)
                if (aux1 == null)
                    Equip("Aux1",e);
                else Equip("Aux2",e);
        }
    }
    public Deck<Ability> Deck(){
        return deck;
    } 
    public List<Equipment> Arsenal(){
        return arsenal;
    }
    //equipment slots are: a-Armor; m-Main; o-Off; t-Two; e-Extra; 1-Aux1; 2-Aux2; 3-Aux3;
    public void Equip(string slot, Equipment item){
        if (slot.CompareTo("Armor") == 0) equipArmor = item;
        if (slot.CompareTo("Two") == 0) {equipMain = null; equipOff = null; equipTwoHand = item;}
        if (slot.CompareTo("Main") == 0) {equipMain = item; equipTwoHand = null;}
        if (slot.CompareTo("Off") == 0) {equipOff = item; equipTwoHand = null;}
        if (slot.CompareTo("Extra") == 0) equipExtra = item;
        if (slot.CompareTo("Aux1") == 0) aux1 = item;
        if (slot.CompareTo("Aux2") == 0) aux2 = item;
        if (slot.CompareTo("Aux3") == 0) aux3 = item;
    }
    public void UnEquip(string slot){
        if (slot.CompareTo("Armor") == 0) equipArmor = null;
        if (slot.CompareTo("Two") == 0) equipTwoHand = null;
        if (slot.CompareTo("Main") == 0) {equipMain = null; equipTwoHand = null;}
        if (slot.CompareTo("Off") == 0) {equipOff = null; equipTwoHand = null;}
        if (slot.CompareTo("Extra") == 0) equipExtra = null;
        if (slot.CompareTo("Aux1") == 0) aux1 = null;
        if (slot.CompareTo("Aux2") == 0) aux2 = null;
        if (slot.CompareTo("Aux3") == 0) aux3 = null;
    }
    public Equipment[] GetEquipped(){
        //Order of equipment is as above. NOTE: NEED TO USE ARRAY TO PRESERVE NULL VALUES.
        // [armor, two, main, off, extra, aux1, aux2, aux3]
        return new Equipment[]{equipArmor,equipTwoHand,equipMain,equipOff,equipExtra,aux1,aux2,aux3};
    }
    public Equipment GetEquipped(string slot){
        if (slot.CompareTo("Armor") == 0) return equipArmor;
        if (slot.CompareTo("Main") == 0) return equipMain != null? equipMain: equipTwoHand;
        if (slot.CompareTo("Off") == 0) return equipOff != null? equipOff: equipTwoHand;
        if (slot.CompareTo("Extra") == 0) return equipExtra;
        if (slot.CompareTo("Aux1") == 0) return aux1;
        if (slot.CompareTo("Aux2") == 0) return aux2;
        if (slot.CompareTo("Aux3") == 0) return aux3;
        return null;
    }
    public string getSlot(Equipment e){
        if (e == equipMain) return "Main";
        if (e == equipArmor) return "Armor";
        if (e == equipExtra) return "Extra";
        if (e == equipOff) return "Off";
        if (e == equipTwoHand) return "Two";
        if (e == aux1) return "Aux1";
        if (e == aux2) return "Aux2";
        if (e == aux3) return "Aux3";
        return null;
    }
    public List<Equipment> getEquipmentBySlot(string equipSlot){ //Needs class specific versitiles
        List<Equipment> temp = new List<Equipment>();
        foreach (Equipment e in arsenal){
            if (e.getName().Contains("Tome")) continue;
            if (e.GetEquipType()[0].CompareTo(equipSlot)==0 || (e.getVersitile() != null && e.getVersitile().CompareTo(equipSlot)==0)){
                temp.Add(e);
                continue;
            }
            if (equipSlot.CompareTo("Main")==0)
                if (e.GetEquipType()[0].CompareTo("Two")==0 || (e.getVersitile() != null && e.getVersitile().CompareTo("Two")==0)){
                    temp.Add(e);
                    continue;
                }
            if (equipSlot.CompareTo("Extra")==0)
                if (e.GetEquipType()[0].CompareTo("Off")==0 || (e.getVersitile() != null && e.getVersitile().CompareTo("Off")==0)){
                    temp.Add(e);
                    continue;
                }
        }
        return temp;
    }
    public void AddTrophy(Monster m){
        trophies.Add(m);
    }
    public List<Monster> Trophies(){
        return trophies;
    }
    public void RemoveTrophy(Monster m){
        trophies.Remove(m);
    }
    public void AddAspiration(Aspiration a){
        aspirations.Add(a);
    }
    public List<Aspiration> Aspirations(){
        return aspirations;
    }
    public void RemoveAspiration(Aspiration a){
        aspirations.Remove(a);
    }
    public void RemoveItem(Equipment e){
        string slot = getSlot(e);
        if (slot != null) UnEquip(slot);
        Arsenal().Remove(e);
    }
}
