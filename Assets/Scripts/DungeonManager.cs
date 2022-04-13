using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class DungeonManager : MonoBehaviour
{
    //Loading in the very numerous UI elements that'll need to dynamically change

    //Monster elements
    public GameObject pnlMonster, pnlMMods, pnlTrade, pnlLobby, pnlHand,
            pnlAuxiliary, pnlPlayZone, pnlDefenses, pnlAspirations,
            pnlDiscard, pnlDiscardZone, pnlInventory, pnlEquipment,
            pnlClass, pnlCombatLog, pnlPartyHealth;

    public Image imgMonster;
    public Image imgMonsterHealth;
    public Text txtMonsterHealth;
    public Image imgMonsterShields;
    public Text txtMonsterShields;
    public Image imgMonsterAbilityShields;
    public Text txtMonsterAbilityShields;
    //MonsterMods
    public Button btnMMod1, btnMMod2, btnMMod3;
    public Button btnMModLeft;
    public Button btnMModRight;

    //Trade elements
    public Button btnTradeWithP2, btnTradeWithP3, btnTradeWithP4;

    //Lobby Elements
    public Button btnLobbyReady, btnLobbyLoot;
    public Button btnP2GL, btnP2GR, btnP2TrL, btnP2TrR, btnP2TpL, 
            btnP2TpR, btnP2RL, btnP2RR, btnP2VL, btnP2VR;
    public Button btnP3GL, btnP3GR, btnP3TrL, btnP3TrR, btnP3TpL, 
            btnP3TpR, btnP3RL, btnP3RR, btnP3VL, btnP3VR;
    public Button btnP4GL, btnP4GR, btnP4TrL, btnP4TrR, btnP4TpL, 
            btnP4TpR, btnP4RL, btnP4RR, btnP4VL, btnP4VR;
    public Text txtP1G, txtP1Tr, txtP1Tp, txtP1R, txtP1V;
    public Text txtP2G, txtP2Tr, txtP2Tp, txtP2R, txtP2V;
    public Text txtP3G, txtP3Tr, txtP3Tp, txtP3R, txtP3V;
    public Text txtP4G, txtP4Tr, txtP4Tp, txtP4R, txtP4V;
    public Text txtLobbyP1, txtLobbyP2, txtLobbyP3, txtLobbyP4;
    public Toggle tglP2, tglP3, tglP4;
    public GameObject pnlParticipating, objP3Rewards, objP4Rewards;

    //Hand Elements
    public Button btnCard1, btnCard2, btnCard3, btnCard4, btnCard5, btnCard6;
    public Button btnHandLeft, btnHandRight;
    
    //Auxiliary Elements
    public Button btnAux1, btnAux2, btnAux3;
    public Image imgAuxShield1, imgAuxShield2, imgAuxShield3;
    public Text txtAuxShield1, txtAuxShield2, txtAuxShield3;
    
    //Equipment Elements
    public Button btnEquipBody, btnEquipMainHand, btnEquipOffHand, btnEquipExtra;
    public Image imgEquipBodyShield, imgEquipMainHandShield, imgEquipOffHandShield, imgEquipExtraShield;
    public Text txtEquipBodyShield, txtEquipMainHandShield, txtEquipOffHandShield, txtEquipExtraShield;

    //Party Health Elements
    public Image imgP1Health, imgP2Health, imgP3Health, imgP4Health;
    public Text txtP1Health, txtP2Health, txtP3Health, txtP4Health,
                txtP1Name, txtP2Name, txtP3Name, txtP4Name;
    
    //Play Zone Elements
    public Button btnPlay1, btnPlay2, btnPlay3, btnPlay4, btnPlayLeftScroll, btnPlayRightScroll;
    public Text txtActionPoints;

    //Combat Log Elements
    public Text txtLog;
    public Button btnSubmit;
    public InputField infMessage;

    //Defenses Elements
    public Button btnDefense1, btnDefense2, btnDefense3, btnDefense4, btnDefense5, btnDefense6;
    public Button btnDefensesLeft, btnDefensesRight;
    public Image imgDefenseShield1, imgDefenseShield2, imgDefenseShield3, imgDefenseShield4, 
            imgDefenseShield5, imgDefenseShield6;
    public Text txtDefenseShield1, txtDefenseShield2, txtDefenseShield3, txtDefenseShield4, 
            txtDefenseShield5, txtDefenseShield6;

    //Aspirations Elements
    public Button btnAspiration1, btnAspiration2, btnAspiration3, btnAspiration4;

    //Discard/Deck Zone Elements
    public Button btnDiscardTop, btnDeck;
    public Text txtDeckCount, txtDiscardCount;

    //Discard Elements
    public Button btnDiscard1, btnDiscard2, btnDiscard3, btnDiscard4, btnDiscard5, btnDiscard6,
            btnDiscardLeftScroll, btnDiscardRightScroll, btnDiscardClose;

    //Class Elements and Done Button
    public Button btnClassAbility, btnTurnComplete;

    //Collected Aspirations, Bounties, and Arsenal
    public Button btnAspirationsCollected, btnTrophies, btnArsenal;

    //VP and Gold
    public Text txtGold, txtVP;

    //Rewards Panel
    public GameObject pnlRewards;
    public Button btnAccept;

    public Sprite empty;

    //Non-UI variables declared below
    ValueStorage storage;
    List<Player> players;
    Player localUser;
    List<Player> combatants;
    //Monster specific variables here
    public GameObject monPrefab;
    Monster monster = null;
    MonsterMod[] mods = null;
    int monAbilityShieldMax = 0;
    int monAbilityShield = 0;
    int monShieldMax = 0;
    int monShield = 0;
    int monHealthMax = 0;
    int monHealth = 0;

    //boolean values for the different steps
    bool lobbyStep = false;
    bool combatStep = false;
    bool rewardStep = false;

    // Start is called before the first frame update
    void Start()
    {
        storage = GameObject.Find("NetworkManager").GetComponent<ValueStorage>();
        players = storage.GetPlayers();
        localUser = storage.getLocalPlayer();
        combatants = new List<Player>();

        //Add listeners to ALL necessary fields here.
        tglP2.onValueChanged.AddListener(delegate{PlayerParticipationToggle(1);});
        tglP3.onValueChanged.AddListener(delegate{PlayerParticipationToggle(2);});
        tglP4.onValueChanged.AddListener(delegate{PlayerParticipationToggle(3);});
        btnSubmit.onClick.AddListener(delegate{SendChat(infMessage.text);});
        btnLobbyReady.onClick.AddListener(ReadyUp);
        btnTurnComplete.onClick.AddListener(TurnComplete);
        btnLobbyLoot.onClick.AddListener(LootNRun);
        btnAccept.onClick.AddListener(AcceptRewards);


        //Set starting player names
        txtP1Name.text = players[0].GetName();
        txtLobbyP1.text = players[0].GetName();
        txtP2Name.text = players[1].GetName();
        txtLobbyP2.text = players[1].GetName();
        btnTradeWithP2.GetComponentInChildren<Text>().text = players[1].GetName();
        if (players.Count > 2){
            txtP3Name.text = players[2].GetName();
            txtLobbyP3.text = players[2].GetName();
            btnTradeWithP3.GetComponentInChildren<Text>().text = players[2].GetName();
        } else {txtP3Name.transform.parent.gameObject.SetActive(false);
            btnTradeWithP3.gameObject.SetActive(false);
            txtLobbyP3.gameObject.SetActive(false);
            objP3Rewards.SetActive(false);
        }
        if (players.Count > 3){
            txtP4Name.text = players[3].GetName();
            txtLobbyP4.text = players[3].GetName();
            btnTradeWithP4.GetComponentInChildren<Text>().text = players[3].GetName();
        } else {txtP4Name.transform.parent.gameObject.SetActive(false);
            btnTradeWithP4.gameObject.SetActive(false);
            txtLobbyP4.gameObject.SetActive(false);
            objP4Rewards.SetActive(false);
        }
        localUser.Write("*SETUP");

    }

    // Update is called once per frame
    void Update()
    {
        //Display updated party HP
        txtP1Health.text = players[0].getHealth()[0] + "/" + players[0].getHealth()[1];
        imgP1Health.transform.localScale = new Vector3(players[0].getHealth()[0]/(float)players[0].getHealth()[1],1,1);
        txtP2Health.text = players[1].getHealth()[0] + "/" + players[1].getHealth()[1];
        imgP2Health.transform.localScale = new Vector3(players[1].getHealth()[0]/(float)players[1].getHealth()[1],1,1);
        if (players.Count > 2){
                txtP3Health.text = players[2].getHealth()[0] + "/" + players[2].getHealth()[1];
                imgP3Health.transform.localScale = new Vector3(players[2].getHealth()[0]/(float)players[2].getHealth()[1],1,1);
        } if (players.Count > 3){
                txtP4Health.text = players[3].getHealth()[0] + "/" + players[3].getHealth()[1];
                imgP4Health.transform.localScale = new Vector3(players[3].getHealth()[0]/(float)players[3].getHealth()[1],1,1);
        } //Display player gold and VP
        txtGold.text = localUser.getGold().ToString();
        txtVP.text = localUser.getVP().ToString();

        //Display updated Monster stats
        if (monster == null){
            txtMonsterHealth.text = "NA";
            txtMonsterAbilityShields.text = "NA";
            txtMonsterShields.text = "NA";
            imgMonsterHealth.transform.localScale = new Vector3(0,1,1);
            imgMonsterAbilityShields.transform.localScale = new Vector3(0,1,1);
            imgMonsterShields.transform.localScale = new Vector3(0,1,1);
        } else {
            txtMonsterHealth.text = monHealth+"/"+monHealthMax;
            txtMonsterAbilityShields.text =  monAbilityShield+"/"+monAbilityShieldMax;
            txtMonsterShields.text =  monShield+"/"+monShieldMax;
            imgMonsterHealth.transform.localScale = new Vector3(monHealth/(float)monHealthMax,1,1);
            if (monAbilityShieldMax > 0)
                imgMonsterAbilityShields.transform.localScale = new Vector3(monAbilityShield/(float)monAbilityShieldMax,1,1);
            else imgMonsterAbilityShields.transform.localScale = new Vector3(0,1,1);
            if (monShieldMax > 0)
                imgMonsterShields.transform.localScale = new Vector3(monShield/(float)monShieldMax,1,1);
            else imgMonsterShields.transform.localScale = new Vector3(0,1,1);
        }
        //Sets color of names in lobby based on status
        if (combatants.Contains(players[0])){
            if (players[0].IsReady()) txtLobbyP1.color = Color.green;
            else txtLobbyP1.color = Color.black;
        } else txtLobbyP1.color = new Color(.4f,.4f,.4f,1);
        if (combatants.Contains(players[1])){
            if (players[1].IsReady()) txtLobbyP2.color = Color.green;
            else txtLobbyP2.color = Color.black;
        } else txtLobbyP2.color = new Color(.4f,.4f,.4f,1);
        if (players.Count > 2 && combatants.Contains(players[2])){
            if (players[2].IsReady()) txtLobbyP3.color = Color.green;
            else txtLobbyP3.color = Color.black;
        } else txtLobbyP3.color = new Color(.4f,.4f,.4f,1);
        if (players.Count > 3 && combatants.Contains(players[3])){
            if (players[3].IsReady()) txtLobbyP4.color = Color.green;
            else txtLobbyP4.color = Color.black;
        } else txtLobbyP4.color = new Color(.4f,.4f,.4f,1);

        //Handles the ready button for the dungeon lobby
        if (combatants.Contains(localUser)){
            btnLobbyReady.gameObject.SetActive(true);
            if (localUser.IsReady()) btnLobbyReady.GetComponentInChildren<Text>().text = "Unready";
            else btnLobbyReady.GetComponentInChildren<Text>().text = "Ready";
        } else btnLobbyReady.gameObject.SetActive(false);

        //Check for messages from server
        if(localUser.GetNetStream().DataAvailable){
            //By using a loop for received, any messages that arrive too close 
            //      together are broken up to be processed separately.
            string received;
            received = localUser.Read();
            Debug.Log(received);
            string[] result = received.Split('/');
            for (int r = 0; r < result.Length; r++){
                if (result[r].CompareTo("")==0) break;
                Debug.Log(result[r]);
                string[] message = result[r].Split(',');
                //Receive a message to be displayed in the log
                if (message[0].CompareTo("*CHAT")==0){
                    result[r] = result[r].Remove(0,6);
                    txtLog.text = result[r] + "\n" + txtLog.text;
                }//Receive message to start the lobby, as well as who the lobby leader is and the monster to be fought.
                if(message[0].CompareTo("*LOBBY") == 0){
                    //Turns off combat and reward panels and turns on lobby and non-combat ones.
                    while (combatants.Count > 0)
                        combatants.RemoveAt(0);
                    SwitchToLobby();
                    combatStep = false;
                    rewardStep = false;
                    lobbyStep = true;
                    if (localUser.GetName().CompareTo(message[1]) == 0){
                        pnlParticipating.SetActive(true);
                    } else pnlParticipating.SetActive(false);
                    //Adds the lobby leader to the combatants list
                    for(int i = 0; i < players.Count; i++){
                        players[i].IsReady(false);
                        if (players[i].GetName().CompareTo(message[1])==0){
                            combatants.Add(players[i]);
                            players[i].IsLead(true);
                        } else players[i].IsLead(false);
                    }
                    txtLog.text = "A wild "+ message[2]+" has appeared!\n" + txtLog.text;
                    string[] mods = new string[message.Length-3];
                    for (int i = 0; i < mods.Length; i++)
                        mods[i] = message[i+3];
                    LoadMonster(message[2], mods);
                    txtLog.text = message[1]+" is the leader for this combat.\n" + txtLog.text;
                }//Recieves message to switch to rewards step
                if (message[0].CompareTo("*REWARDS") == 0){
                    lobbyStep = false;
                    combatStep = false;
                    rewardStep = true;
                    SwitchToRewards();
                }
                if (message[0].CompareTo("*UPDATE") == 0){
                    for (int i = 1; i < message.Length; i++){
                        string[] pair = message[i].Split(':');
                        for (int j = 0; j < players.Count; j++){
                            if (pair[0].CompareTo(players[j].GetName())==0){
                                int.TryParse(pair[1], out int hp);
                                players[j].setHealth(hp);
                            }
                        }
                    }
                }
                if (lobbyStep){
                    //Receive list of players participating
                    if (message[0].CompareTo("*LIST") == 0){
                        //Removes all players from the lobby first then adds them back in if on list
                        while (combatants.Count > 0)
                            combatants.RemoveAt(0);
                        for (int i = 1; i < message.Length; i++){
                            for (int j = 0; j < players.Count; j++)
                                if (message[i].CompareTo(players[j].GetName()) == 0)
                                    combatants.Add(players[j]);
                        }
                        //Unreadies everybody due to change in lobby
                        for (int i = 0; i < players.Count; i++){
                            players[i].IsReady(false);
                        }
                    }//Recieves a list of ready users
                    if (message[0].CompareTo("*READY") == 0){
                        for (int i = 0; i < players.Count; i++){
                            players[i].IsReady(false);
                            for (int j = 1; j < message.Length; j++){
                                if (players[i].GetName().CompareTo(message[j])==0)
                                    players[i].IsReady(true);
                            }
                        }
                    }//Recieves message to start combat as well as who is first
                    if (message[0].CompareTo("*START") == 0){
                        StartCombat();
                        if (localUser.GetName().CompareTo(message[1]) == 0){
                            localUser.IsTurn(true);
                            localUser.SetAP(1);
                            pnlPlayZone.SetActive(true);
                            btnTurnComplete.gameObject.SetActive(true);
                        }
                        txtLog.text = "It is "+ message[1]+"'s turn\n" + txtLog.text;
                    }
                }
                if (combatStep){
                    //If the user is recieving an attack
                    if (message[0].CompareTo("*ATTACK") == 0){
                        //NOT YET IMPLEMENTED!
                        int.TryParse(message[1], out int damage);
                        localUser.takeDamage(damage);
                        txtLog.text = monster.GetName()+" attacks for "+ damage+"damage\n" + txtLog.text;
                        localUser.Write("*RESULT,"+localUser.getHealth()[0]);
                    }//Receives the results of an attack made by a player
                    if (message[0].CompareTo("*RESULT") == 0){
                        int.TryParse(message[1],out monHealth);
                    }//Receives a message of which player it is now the turn of
                    if (message[0].CompareTo("*NEXT") == 0){
                        if(localUser.GetName().CompareTo(message[1]) == 0) {
                            localUser.IsTurn(true);
                            localUser.SetAP(1);
                            pnlPlayZone.SetActive(true);
                            btnTurnComplete.gameObject.SetActive(true);
                        }
                        else {
                            localUser.IsTurn(false);
                            pnlPlayZone.SetActive(false);
                            btnTurnComplete.gameObject.SetActive(false);
                        }
                    }
                }
                if (rewardStep){
                    //Recieves message to switch to display loot
                    if (message[0].CompareTo("*DISPLAY") == 0){
                        //NOT YET IMPLEMENTED
                    }
                }
                if (message[0].CompareTo("*SHOP") == 0){
                    SceneManager.LoadScene("Shop");
                }
            }
        }
    }
    //Global Functions
    void SendChat(string chat){
        if (chat.CompareTo("") != 0) localUser.Write("*CHAT,"+localUser.GetName()+": "+chat);
    }
    void SwitchToRewards(){//Sets up the Rewards UI
        //Removes "in combat" status from all players

        //Close all combat and lobby panels and reopen non-combat ones.
        pnlTrade.SetActive(true);
        pnlHand.SetActive(false);
        pnlDefenses.SetActive(false);
        pnlPlayZone.SetActive(false);
        pnlDiscard.SetActive(false);
        pnlDiscardZone.SetActive(false);
        txtDeckCount.gameObject.SetActive(false);
        txtDiscardCount.gameObject.SetActive(false);
        pnlLobby.SetActive(false);
        btnTurnComplete.gameObject.SetActive(false);
        pnlInventory.SetActive(true);

        if (combatants.Contains(localUser))
            pnlRewards.SetActive(true);

        //Open Rewards distribution panel. Activate Accept button for lead;
        if (localUser.IsLead()) btnAccept.gameObject.SetActive(true);
        else btnAccept.gameObject.SetActive(false);
        while(combatants.Count > 0)
            combatants.RemoveAt(0);
    }
    void SwitchToLobby(){ //Sets up the Lobby UI
        pnlTrade.SetActive(true);
        pnlHand.SetActive(false);
        pnlDefenses.SetActive(false);
        pnlPlayZone.SetActive(false);
        pnlDiscard.SetActive(false);
        pnlDiscardZone.SetActive(false);
        txtDeckCount.gameObject.SetActive(false);
        txtDiscardCount.gameObject.SetActive(false);
        pnlLobby.SetActive(true);
        btnTurnComplete.gameObject.SetActive(false);
        pnlInventory.SetActive(true);
        pnlRewards.SetActive(false);
    }

    //Lobby Functions
    void LoadMonster(string name, string[] mods){
        //Loads in monster based on name.
        //For now, default training dummy
        monster = Instantiate(monPrefab).GetComponent<Monster>();
        monHealth = monster.getStats()[0];
        monHealthMax = monster.getStats()[0];
        monAbilityShield = monster.getStats()[2];
        monAbilityShieldMax = monster.getStats()[2];
        monShield = monster.getStats()[1];
        monShieldMax = monster.getStats()[1];
    }
    void clearMonster(){
        Destroy(monster.gameObject);
        monster = null;
    }
    void LootNRun(){
        while (combatants.Count > 0)
            combatants.RemoveAt(0);
        combatants.Add(localUser);
        localUser.Write("*LOOT");
    }
    void PlayerParticipationToggle(int pIndex){
        localUser.Write("*PARTICIPANT,"+players[pIndex].GetName());
    }
    void ReadyUp(){
        localUser.Write("*READY");
    }
    void StartCombat(){ //Sets up the Combat UI
        //First, unready all players
        for (int j = 0; j < players.Count; j++){
            players[j].IsReady(false);
        } //Second, close the lobby screen.
        pnlLobby.SetActive(false);
        //Third, if participating in combat opens the combat panels and closes non-combat panels.
        if(combatants.Contains(localUser)){
            pnlTrade.SetActive(false);
            pnlHand.SetActive(true);
            pnlDefenses.SetActive(true);
            pnlPlayZone.SetActive(false);
            pnlDiscard.SetActive(false);
            pnlDiscardZone.SetActive(true);
            txtDeckCount.gameObject.SetActive(true);
            txtDiscardCount.gameObject.SetActive(true);
            pnlLobby.SetActive(false);
            btnTurnComplete.gameObject.SetActive(false);
            pnlInventory.SetActive(false);
            pnlRewards.SetActive(false);
        }
        rewardStep = false;
        lobbyStep = false;
        combatStep = true;
    }

    //Combat Functions
    void TurnComplete(){
        //following code is for testing until ability decks are implemented
        if (localUser.IsTurn()){
            localUser.Write("*ATTACK,0,2,false,false,false");
            localUser.changeAP(-1);
        }
        //End of test code
        if (localUser.IsTurn()  && localUser.getAP() <= 0) {
            localUser.IsTurn(false);
            localUser.Write("*DONE");
        }
    }

    //Rewards Functions
    void AcceptRewards(){
        //handling to ensure loot is divided as planned
        //NOT IMPLEMENTED AS NO LOOT TO DIVIDE
        localUser.Write("*ACCEPT");
    }
}
