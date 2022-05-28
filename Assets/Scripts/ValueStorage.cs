using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ValueStorage : MonoBehaviour
{
    Player localPlayer;
    List<Player> playerList;
    List<PlayerClass> availableClasses;
    List<Ability> shopAbilities;
    List<Ability> reserveAbilities;
    List<Equipment> commonEquipment;
    List<Equipment> qualityEquipment;
    List<Equipment> specialEquipment;
    List<Equipment> reserveEquipment;
    List<Monster> monsterList;
    List<Aspiration> Aspirations;
    List<Aspiration>[] currentAspirations = new List<Aspiration>[]{new List<Aspiration>(),new List<Aspiration>(),new List<Aspiration>(),new List<Aspiration>()};
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
    public void SetAspirations(List<Aspiration> aspirations){
        Aspirations = aspirations;
    }
    public List<Aspiration> GetAspirations(){
        return Aspirations;
    }
    public void SetCurrentAspirations(List<Aspiration>[] aspirations){
        currentAspirations = aspirations;
    }
    public List<Aspiration>[] GetCurrentAspirations(){
        return currentAspirations;
    }
    public Aspiration PeekAspiration(int row, int depth){
        return currentAspirations[row][depth];
    }
    public void PushAspiration(int row, Aspiration a){
        currentAspirations[row].Insert(0,a);
    }
    public Aspiration PopAspiration(int row){
        Aspiration temp = currentAspirations[row][0];
        currentAspirations[row].RemoveAt(0);
        return temp;
    }
    public int AspirationCount(int row){
        return currentAspirations[row].Count;
    }
    public void setClasses(List<PlayerClass> classes){
        availableClasses = classes;
    }
    public List<PlayerClass> getAvailableClasses(){
        return availableClasses;
    }
    public void RemoveClass(PlayerClass p){
        availableClasses.Remove(p);
    }

}
