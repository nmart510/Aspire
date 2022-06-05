using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.IO;

public class LobbyManager : MonoBehaviour
{
    int port = 11011;
    public InputField IPField;
    public Text player1;
    public Text ph1;
    public Text player2;
    public Text ph2;
    public Text player3;
    public Text ph3;
    public Text player4;
    public Text ph4;
    public Button join;
    public Button back;
    public Button ready;
    public GameObject playerPrefab;
    bool connected = false;
    bool acceptingInput = true;
    List<Player> players;
    Player localUser;
    // Start is called before the first frame update
    void Start()
    {
        //Instantiating variables
        players = new List<Player>();
        ValueStorage vs = GameObject.Find("NetworkManager").GetComponent<ValueStorage>();
        GameObject g = Instantiate(playerPrefab);
        localUser = g.GetComponent<Player>();
        localUser.SetName(vs.GetUsername());
        vs.setLocalPlayer(localUser);
        g.name = vs.GetUsername();
        players.Add(localUser);
        //Set listenners for the buttons
        join.onClick.AddListener(joinServer);
        back.onClick.AddListener(goBack);
        ready.onClick.AddListener(readyUp);
    }

    // Update is called once per frame
    void Update()
    {
        //Updates the lobby UI
        if (players.Count > 0){
            player1.text = players[0].GetName();
            if (players[0].IsReady())
                player1.color = Color.green;
            else if (connected == false) player1.color = new Color(.4f,.4f,.4f,1);
            else player1.color = Color.black;
            ph1.enabled = false;
        } else { player1.text = ""; ph1.enabled = true; }
        if (players.Count > 1){
            player2.text = players[1].GetName();
            if (players[1].IsReady())
                player2.color = Color.green;
            else player2.color = Color.black;
            ph2.enabled = false;
        } else { player2.text = ""; ph2.enabled = true; }
        if (players.Count > 2){
            player3.text = players[2].GetName();
            if (players[2].IsReady())
                player3.color = Color.green;
            else player3.color = Color.black;
            ph3.enabled = false;
        } else { player3.text = ""; ph3.enabled = true; }
        if (players.Count > 3){
            player4.text = players[3].GetName();
            if (players[3].IsReady())
                player4.color = Color.green;
            else player4.color = Color.black;
            ph4.enabled = false;
        } else { player4.text = ""; ph4.enabled = true; }
        //Instead of using a while loop, taking advantage of Unity's built in Update function.
        //This does, however, mean I need to include a timeout for if no message is sent.
        //Essentially, this portion is to listen for more people joining the lobby, and whether or
        //not they are ready to start. READY NOT YET IMPLEMENTED
        if(connected && acceptingInput){
            if(localUser.GetNetStream().DataAvailable){
                //By using a loop for received, any messages that arrive too close 
                //      together are broken up to be processed separately.
                string received;
                received = localUser.Read();
                Debug.Log(received);
                string[] result = received.Split('/');
                for (int r = 0; r < result.Length; r++){
                    if (result[r].CompareTo("")==0) break;
                    string[] message = result[r].Split(',');

                    //Will be sent whenever a player joins the lobby
                    if (message[0].CompareTo("*LIST") == 0){
                        for (int i = 1; i < message.Length; i++){
                            bool match = false;
                            for (int j = 0; j < players.Count; j++){
                                if (players[j].GetName().CompareTo(message[i])==0){
                                    match = true;
                                    break;
                                }
                            }
                            if (match == false){
                                GameObject temp = Instantiate(playerPrefab);
                                players.Add(temp.GetComponent<Player>());
                                temp.name = message[i];
                                players[players.Count-1].SetName(message[i]);
                            }
                        }
                        for (int i = 0; i < players.Count; i++){
                            players[i].IsReady(false);
                        }

                    //Will be sent whenever a player leaves the lobby
                    } else if (message[0].CompareTo("*REMOVE") == 0) {
                        for (int i = 0; i < players.Count; i++){
                            if (players[i].GetName().CompareTo(message[1]) == 0){
                                Destroy(players[i].gameObject);
                                players.RemoveAt(i);
                            }
                        }
                        for (int i = 0; i < players.Count; i++){
                            players[i].IsReady(false);
                        }

                    //Will be sent whenever a player joins, leaves or readies up
                    } else if (message[0].CompareTo("*READY") == 0) {
                        for (int i = 0; i < players.Count; i++){
                            players[i].IsReady(false);
                            for (int j = 1; j < message.Length; j++){
                                if (players[i].GetName().CompareTo(message[j])==0)
                                    players[i].IsReady(true);
                            }
                        }

                    //Will be sent to start the game
                    } else if (message[0].CompareTo("*START") == 0) {
                        acceptingInput = false;
                        Debug.Log("Loading Abilities");
                        List<Ability> abilities = LoadAbilities();
                        Debug.Log("Loading Common Equipment");
                        List<Equipment> commonEquipment = LoadEquipment('c');
                        Debug.Log("Loading Quality Equipment");
                        List<Equipment> qualityEquipment = LoadEquipment('q');
                        Debug.Log("Loading Special Equipment");
                        List<Equipment> specialEquipment = LoadEquipment('s');
                        Debug.Log("Loading Monsters");
                        List<Monster> monsterList = LoadMonsters();
                        Debug.Log("Loading Aspirations");
                        List<Aspiration> aspirationList = LoadAspirations();
                        ValueStorage vs = GameObject.Find("NetworkManager").GetComponent<ValueStorage>();
                        vs.RecordPlayers(players);
                        vs.SetShopAbilities(abilities);
                        vs.setEquipmentDecks(commonEquipment,qualityEquipment,specialEquipment);
                        vs.setMonList(monsterList);
                        vs.SetAspirations(aspirationList);
                        vs.setClasses(LoadClasses());
                        vs.setBossList(LoadBosses());
                        vs.setBossMods(LoadBossMods());
                        SceneManager.LoadScene("Shop");
                    }
                }
            }
        }
    }
    void goBack(){
        if (connected){
            localUser.Write("*EXIT");
            localUser.GetClient().Close();
        }
        GameObject[] temp = Object.FindObjectsOfType<GameObject>();
        for (int i = 0; i < temp.Length; i++){
            Destroy(temp[i]);
        }
        SceneManager.LoadScene("Main");
    }
    void joinServer(){
        if (connected == false){
            Debug.Log("Attempting connection: " + IPField.text);
            localUser.SetClient(IPField.text, port);
            localUser.GetClient().ReceiveTimeout = 100;
            localUser.Write(players[0].GetName());
            Debug.Log("Sent name to server");
            connected = true;
        }
    }
    void readyUp(){
        if (connected){
            localUser.Write("*READY");
        }
    }
    List<Ability> LoadAbilities(){ //Loads the list of abilities. NOTE: client side doesn't need to track quantity
        List<Ability> temp = new List<Ability>();
        string filepath = Path.Combine(Directory.GetParent(Directory.GetCurrentDirectory()).FullName,@"AspireAssets\Abilities\");
        string shopAblList = Path.Combine(filepath,@"ShopAbilities.txt");
        var lines = File.ReadAllLines(shopAblList);
        for (int i = 0; i < lines.Length; i++){
            string cardName = lines[i];
            Ability a = new Ability();
            a.loadCard(Path.Combine(filepath,@"Info\"+cardName+".txt"),Path.Combine(filepath,@"Images\"+cardName+".png"));
            temp.Add(a);
        }
        string classAblList = Path.Combine(filepath,@"ClassAbilities.txt");
        lines = File.ReadAllLines(classAblList);
        for (int i = 0; i < lines.Length; i++){
            string cardName = lines[i].Split(':')[0];
            Ability a = new Ability();
            a.loadCard(Path.Combine(filepath,@"Info\"+cardName+".txt"),Path.Combine(filepath,@"Images\"+cardName+".png"));
            temp.Add(a);
        }
        
        return temp;
    }
    List<Aspiration> LoadAspirations(){ //Loads the list of abilities. NOTE: client side doesn't need to track quantity
        List<Aspiration> temp = new List<Aspiration>();
        string filepath = Path.Combine(Directory.GetParent(Directory.GetCurrentDirectory()).FullName,@"AspireAssets\Aspirations\");
        string shopAblList = Path.Combine(filepath,@"AspirationsList.txt");
        var lines = File.ReadAllLines(shopAblList);
        for (int i = 0; i < lines.Length; i++){
            string cardName = lines[i].Split(':')[0];
            Aspiration a = new Aspiration();
            a.loadCard(Path.Combine(filepath,@"Info\"+cardName+".txt"),Path.Combine(filepath,@"Images\"+cardName+".png"));
            temp.Add(a);
        }
        return temp;
    }
    List<Equipment> LoadEquipment(char x){
        List<Equipment> temp = new List<Equipment>();
        string filepath = Path.Combine(Directory.GetParent(Directory.GetCurrentDirectory()).FullName,@"AspireAssets\Equipment\");
        string shopEqList = "";
        if (x == 'c') shopEqList = Path.Combine(filepath,@"CommonEquipment.txt");
        if (x == 'q') shopEqList = Path.Combine(filepath,@"QualityEquipment.txt");
        if (x == 's') shopEqList = Path.Combine(filepath,@"SpecialEquipment.txt");
        var lines = File.ReadAllLines(shopEqList);
        for (int i = 0; i < lines.Length; i++){
            string cardName = lines[i];
            if (cardName.Contains(":"))
                cardName = cardName.Split(':')[0];
            Equipment e = new Equipment();
            e.loadCard(Path.Combine(filepath,@"Info\"+cardName+".txt"),Path.Combine(filepath,@"Images\"+cardName+".png"));
            temp.Add(e);
        }
        return temp;
    }
    List<Monster> LoadMonsters(){
        List<Monster> temp = new List<Monster>();
        string filepath = Path.Combine(Directory.GetParent(Directory.GetCurrentDirectory()).FullName,@"AspireAssets\Monsters\");
        string MonsterList = Path.Combine(filepath,@"MonsterList.txt");
        var lines = File.ReadAllLines(MonsterList);
        for (int i = 0; i < lines.Length; i++){
            string cardName = lines[i].Split(':')[0];
            Monster a = new Monster();
            a.loadCard(Path.Combine(filepath,@"Info\"+cardName+".txt"),Path.Combine(filepath,@"Images\"+cardName+".png"),false);
            temp.Add(a);
        }
        string MonsterModList = Path.Combine(filepath,@"MonsterModList.txt");
        var modlines = File.ReadAllLines(MonsterModList);
        for (int i = 0; i < modlines.Length; i++){
            string cardName = modlines[i].Split(':')[0];
            Monster a = new Monster();
            a.loadCard(Path.Combine(filepath,@"Info\"+cardName+".txt"),Path.Combine(filepath,@"Images\"+cardName+".png"),true);
            temp.Add(a);
        }
        return temp;
    }
    List<PlayerClass> LoadClasses(){
        List<PlayerClass> temp = new List<PlayerClass>();
        string filepath = Path.Combine(Directory.GetParent(Directory.GetCurrentDirectory()).FullName,@"AspireAssets\Classes\");
        string classList = Path.Combine(filepath,@"ClassList.txt");
        var lines = File.ReadAllLines(classList);
        for (int i = 0; i < lines.Length; i++){
            string cardName = lines[i];
            PlayerClass a = new PlayerClass();
            a.loadCard(Path.Combine(filepath,@"Info\"+cardName+".txt"),Path.Combine(filepath,@"Images\"+cardName+".png"));
            temp.Add(a);
        }
        return temp;
    }
    List<Boss> LoadBosses(){
        List<Boss> temp = new List<Boss>();
        string filepath = Path.Combine(Directory.GetParent(Directory.GetCurrentDirectory()).FullName,@"AspireAssets\Bosses\");
        string bossList = Path.Combine(filepath,@"BossList.txt");
        var lines = File.ReadAllLines(bossList);
        for (int i = 0; i < lines.Length; i++){
            Boss b = new Boss();
            b.loadCard(Path.Combine(filepath,@"Info\"+lines[i]+".txt"),Path.Combine(filepath,@"Images\"+lines[i]+".png"),false);
            temp.Add(b);
        }
        return temp;
    }
    List<Boss> LoadBossMods(){
        List<Boss> temp = new List<Boss>();
        string filepath = Path.Combine(Directory.GetParent(Directory.GetCurrentDirectory()).FullName,@"AspireAssets\BossMods\");
        string bossList = Path.Combine(filepath,@"BossModList.txt");
        var lines = File.ReadAllLines(bossList);
        for (int i = 0; i < lines.Length; i++){
            int.TryParse(lines[i].Split(':')[1], out int num);
            if(num == 1 || num == players.Count){
                string cardName = lines[i].Split(':')[0];
                Boss b = new Boss();
                b.loadCard(Path.Combine(filepath,@"Info\"+cardName+".txt"),Path.Combine(filepath,@"Images\"+cardName+".png"),true);
                temp.Add(b);
            }
        }
        return temp;
    }
}
