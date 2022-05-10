using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ValueStorage : MonoBehaviour
{
    Player localPlayer;
    List<Player> playerList;
    List<Ability> shopAbilities;
    List<Ability> reserveAbilities;
    List<Equipment> commonEquipment;
    List<Equipment> qualityEquipment;
    List<Equipment> specialEquipment;
    List<Equipment> reserveEquipment;
    List<Monster> monsterList;
    bool initialShop = true;
    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(this.gameObject);
        playerList = new List<Player>();
    }
    string username;
    public void SetUsername(string _username){
        username = _username;
    }
    public string GetUsername(){
        return username;
    }
    public Player getLocalPlayer(){
        return localPlayer;
    }
    public void setLocalPlayer(Player p){
        localPlayer = p;
    }
    public List<Player> GetPlayers(){
        return playerList;
    }
    public void RecordPlayers(List<Player> pl){
        playerList = pl;
    }
    public void SetShopAbilities(List<Ability> ablts){
        shopAbilities = ablts;
    }
    public List<Ability> GetShopAbilities(){
        return shopAbilities;
    }
    public void setEquipmentDecks(List<Equipment> common, List<Equipment> quality, List<Equipment> special){
        commonEquipment = common;
        qualityEquipment = quality;
        specialEquipment = special;
    }
    public List<Equipment> GetCommonEquipment(){
        return commonEquipment;
    }
    public List<Equipment> GetQualityEquipment(){
        return qualityEquipment;
    }
    public List<Equipment> GetSpecialEquipment(){
        return specialEquipment;
    }
    public bool isInitialShop(){
        return initialShop;
    }
    public void isInitialShop(bool init){
        initialShop = init;
    }
    public void setMonList(List<Monster> ms){
        monsterList = ms;
    }
    public List<Monster> getMonList(){
        return monsterList;
    }
}
