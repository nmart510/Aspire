using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

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
    //Damage confirmation elements
    public GameObject pnlConfirmDamage;
    public Button btnConfirmDamage;
    public TextMeshProUGUI txtDamageInfo;
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
            
    //Deck Elements
    public GameObject pnlDeck;
    public Button btnDeck1, btnDeck2, btnDeck3, btnDeck4, btnDeck5, btnDeck6,
            btnDeckLeftScroll, btnDeckRightScroll, btnDeckClose;
    //Arsenal
    public GameObject pnlArsenalView, pnlTomeUse;
    public Button btnArsenalCancel, btnArsenalLeftScroll, btnArsenalRightScroll, btnAddToDeck, btnCancelAdd,
            btnArsenal1, btnArsenal2, btnArsenal3, btnArsenal4, btnArsenal5, btnArsenal6;
    int ArsenalOffset = 0;
    //Equip Options
    public GameObject pnlEquipOptionView;
    public Button btnEquipOptionCancel, btnEquipOptionLeftScroll, btnEquipOptionRightScroll, btnUnequip,
            btnEquipOption1, btnEquipOption2, btnEquipOption3, btnEquipOption4, btnEquipOption5, btnEquipOption6;
    int EquipOptionOffset = 0;
    //Class Elements and Done Button
    public Button btnClassAbility, btnTurnComplete, btnRunAway;

    //Collected Aspirations, Bounties, and Arsenal
    public Button btnAspirationsCollected, btnTrophies, btnArsenal;

    //VP and Gold
    public Text txtGold, txtVP;

    //Rewards Panel
    public GameObject pnlRewards;
    public Button btnAccept;

    public Sprite empty;

    //Healing Panel elements
    public GameObject pnlHeal;
    public Text txtHealP1, txtHealP2, txtHealP3, txtHealP4,
            txtHealAmountP1, txtHealAmountP2, txtHealAmountP3, txtHealAmountP4;
    public Button btnHealConfirm, btnHP2L, btnHP2R,
             btnHP3L, btnHP3R, btnHP4L, btnHP4R;
    int[] heals = new int[4];

    //Flee panel elements
    public GameObject pnlFlee;
    public Button btnFlee, btnDiscardFlee;

    //Versitile Panel
    public GameObject pnlVersitile;
    public Button btnChooseMainHand, btnChooseTwoHand;

    //Non-UI variables
    ValueStorage storage;
    List<Player> players;
    Player localUser;
    List<Player> combatants;
    //Monster specific variables here
    Monster monster = null;

    //boolean values for the different steps
    bool lobbyStep = false;
    bool combatStep = false;
    bool rewardStep = false;

    //Lists for abilities in play
    List<Ability> inPlay = new List<Ability>();
    List<Ability> inHand = new List<Ability>();
    List<Ability> defenses = new List<Ability>();
    List<Equipment> viewArsenal = new List<Equipment>();
    List<Equipment> viewEquipOption = new List<Equipment>();
    int handOffset = 0; int playOffset = 0; int defOffset = 0; int discardOffset = 0; int deckOffset = 0;
    int skillBoost = 0, spellboost = 0, allBoost = 0, EQshieldBreak = 0;
    int EQskillBoost = 0, EQspellboost = 0, EQallBoost = 0;
    bool nextHoming = false, EQHoming = false, EQSKHoming = false, EQSpellIgnore = false;
    bool nextPierce = false, EQPierce = false, EQSPPierce = false, EQSkillIgnore = false;
    int EQarmor = 0, EQevade = 0;
    string playerClass = null;
    int enemyTier = 0;
    string equippingSlot;
    Equipment itemToEquip;
    Equipment activeTome = null;
    //Storage for pending attacks
    int pendingShieldBreak = 0;
    int pendingDamage = 0;
    bool pendingHoming = false;
    bool pendingPierce = false;
    bool pendingIgnore = false;
    string pendingType = null;
    string pendingTag = null;
    

    // Start is called before the first frame update
    void Start()
    {
        storage = GameObject.Find("NetworkManager").GetComponent<ValueStorage>();
        players = storage.GetPlayers();
        localUser = storage.getLocalPlayer();
        combatants = new List<Player>();

        //Add listeners to ALL necessary fields here.
        //Listeners for lobby
        tglP2.onValueChanged.AddListener(delegate{PlayerParticipationToggle(1);});
        tglP3.onValueChanged.AddListener(delegate{PlayerParticipationToggle(2);});
        tglP4.onValueChanged.AddListener(delegate{PlayerParticipationToggle(3);});
        btnSubmit.onClick.AddListener(delegate{SendChat(infMessage.text);});
        btnLobbyReady.onClick.AddListener(ReadyUp);
        btnTurnComplete.onClick.AddListener(TurnComplete);
        btnLobbyLoot.onClick.AddListener(LootNRun);
        btnAccept.onClick.AddListener(AcceptRewards);
        btnRunAway.onClick.AddListener(RunAway);
        //Listeners for hand panel
        btnCard1.onClick.AddListener(delegate{PlayCard(0);});
        btnCard2.onClick.AddListener(delegate{PlayCard(1);});
        btnCard3.onClick.AddListener(delegate{PlayCard(2);});
        btnCard4.onClick.AddListener(delegate{PlayCard(3);});
        btnCard5.onClick.AddListener(delegate{PlayCard(4);});
        btnCard6.onClick.AddListener(delegate{PlayCard(5);});
        btnHandLeft.onClick.AddListener(delegate{
            if (handOffset > 0) handOffset--;
            ReloadHand();
        });
        btnHandRight.onClick.AddListener(delegate{
            if (handOffset < inHand.Count-6) handOffset++;
            ReloadHand();
        });
        //Listeners for Heal
        btnHealConfirm.onClick.AddListener(ConfirmHeal);
        btnHP2L.onClick.AddListener(delegate{if (heals[1] > 0){ heals[1]--; heals[0]++;ReloadHeal();}});
        btnHP2R.onClick.AddListener(delegate{if (heals[0] > 0){ heals[0]--; heals[1]++;ReloadHeal();}});
        btnHP3L.onClick.AddListener(delegate{if (heals[2] > 0){ heals[2]--; heals[0]++;ReloadHeal();}});
        btnHP3R.onClick.AddListener(delegate{if (heals[0] > 0){ heals[0]--; heals[2]++;ReloadHeal();}});
        btnHP4L.onClick.AddListener(delegate{if (heals[3] > 0){ heals[3]--; heals[0]++;ReloadHeal();}});
        btnHP4R.onClick.AddListener(delegate{if (heals[0] > 0){ heals[0]--; heals[3]++;ReloadHeal();}});
        //Listeners for Flee
        btnFlee.onClick.AddListener(FleeCombat);
        btnDiscardFlee.onClick.AddListener(DiscardFlee);
        //Listeners for Discard
        btnDiscardTop.onClick.AddListener(delegate{pnlDiscard.SetActive(true); ReloadDiscard();});
        btnDiscardLeftScroll.onClick.AddListener(delegate{if(discardOffset>0)discardOffset--;ReloadDiscard();});
        btnDiscardRightScroll.onClick.AddListener(delegate{if(discardOffset<localUser.Deck().DiscardCount()-6)discardOffset++;ReloadDiscard();});
        btnDiscardClose.onClick.AddListener(delegate{discardOffset = 0;pnlDiscard.SetActive(false); ReloadDiscard();});
        //Listeners for Deck
        btnDeck.onClick.AddListener(delegate{pnlDeck.SetActive(true); ReloadDeck();});
        btnDeckLeftScroll.onClick.AddListener(delegate{if(deckOffset>0)deckOffset--;ReloadDeck();});
        btnDeckRightScroll.onClick.AddListener(delegate{if(deckOffset<localUser.Deck().DeckCount()-6)deckOffset++;ReloadDeck();});
        btnDeckClose.onClick.AddListener(delegate{deckOffset = 0;pnlDeck.SetActive(false); ReloadDeck();});
        //Arsenal
        btnArsenal.onClick.AddListener(delegate{pnlArsenalView.SetActive(true);ReloadArsenalView();});
        btnArsenalCancel.onClick.AddListener(delegate{pnlArsenalView.SetActive(false);ArsenalOffset=0;});
        btnArsenalLeftScroll.onClick.AddListener(delegate{ArsenalOffset--;ReloadArsenalView();});
        btnArsenalRightScroll.onClick.AddListener(delegate{ArsenalOffset++;ReloadArsenalView();});
        btnArsenal1.onClick.AddListener(delegate{UseTome(ArsenalOffset);});
        btnArsenal2.onClick.AddListener(delegate{UseTome(1+ArsenalOffset);});
        btnArsenal3.onClick.AddListener(delegate{UseTome(2+ArsenalOffset);});
        btnArsenal4.onClick.AddListener(delegate{UseTome(3+ArsenalOffset);});
        btnArsenal5.onClick.AddListener(delegate{UseTome(4+ArsenalOffset);});
        btnArsenal6.onClick.AddListener(delegate{UseTome(5+ArsenalOffset);});
        btnAddToDeck.onClick.AddListener(delegate{
            localUser.Deck().Add(activeTome.getLinkedAbility());
            localUser.Arsenal().Remove(activeTome);
            pnlTomeUse.SetActive(false); activeTome = null;
            ReloadArsenalView();
        });
        btnCancelAdd.onClick.AddListener(delegate{pnlTomeUse.SetActive(false); activeTome = null;});
        //Listeners for equipment swapping when not in combat, and equipment abilities when in combat
        //NOTE Equipment abilities not scheduled for implementation until week 8
        btnAux1.onClick.AddListener(delegate{displayEquipItemMenu("Aux1");});
        btnAux2.onClick.AddListener(delegate{displayEquipItemMenu("Aux2");});
        btnAux3.onClick.AddListener(delegate{displayEquipItemMenu("Aux3");});
        btnEquipBody.onClick.AddListener(delegate{displayEquipItemMenu("Armor");});
        btnEquipMainHand.onClick.AddListener(delegate{displayEquipItemMenu("Main");});
        btnEquipOffHand.onClick.AddListener(delegate{displayEquipItemMenu("Off");});
        btnEquipExtra.onClick.AddListener(delegate{displayEquipItemMenu("Extra");});
        //EquipOption
        btnEquipOption1.onClick.AddListener(delegate{itemToEquip = viewEquipOption[EquipOptionOffset]; ChooseVersitile();});
        btnEquipOption2.onClick.AddListener(delegate{itemToEquip = viewEquipOption[EquipOptionOffset+1]; ChooseVersitile();});
        btnEquipOption3.onClick.AddListener(delegate{itemToEquip = viewEquipOption[EquipOptionOffset+2]; ChooseVersitile();});
        btnEquipOption4.onClick.AddListener(delegate{itemToEquip = viewEquipOption[EquipOptionOffset+3]; ChooseVersitile();});
        btnEquipOption5.onClick.AddListener(delegate{itemToEquip = viewEquipOption[EquipOptionOffset+4]; ChooseVersitile();});
        btnEquipOption6.onClick.AddListener(delegate{itemToEquip = viewEquipOption[EquipOptionOffset+5]; ChooseVersitile();});
        btnEquipOptionCancel.onClick.AddListener(delegate{pnlEquipOptionView.SetActive(false);EquipOptionOffset=0;equippingSlot = null;});
        btnEquipOptionLeftScroll.onClick.AddListener(delegate{EquipOptionOffset--;ReloadEquipOptionView();});
        btnEquipOptionRightScroll.onClick.AddListener(delegate{EquipOptionOffset++;ReloadEquipOptionView();});
        btnUnequip.onClick.AddListener(delegate{localUser.UnEquip(equippingSlot);pnlEquipOptionView.SetActive(false);
                EquipOptionOffset=0;equippingSlot = null;ReloadEquipped();});
        btnChooseMainHand.onClick.AddListener(delegate{pnlVersitile.SetActive(false); equippingSlot = "Main";EquipItem();});
        btnChooseTwoHand.onClick.AddListener(delegate{pnlVersitile.SetActive(false); equippingSlot = "Two";EquipItem();});
        //Listenner for confirming damage
        btnConfirmDamage.onClick.AddListener(delegate{localUser.Write("*CONFIRMDAMAGE");});
        
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
        ReloadEquipped();
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
        //Discard and deck counts
        txtDeckCount.text = "Deck: "+localUser.Deck().DeckCount();
        txtDiscardCount.text = "Discard: "+localUser.Deck().DiscardCount();

        //if in combat and out of cards in hand
        if (combatStep && combatants.Contains(localUser) && inHand.Count == 0){
            inHand = localUser.Deck().Draw(2);
            ReloadHand();
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
                }
                if (message[0].CompareTo("*ENDOFDAY") == 0){
                    foreach (Player p in players){
                        p.setHealth(p.getHealth()[1]);
                    }
                    localUser.Write("*SETUP");
                }
                if (message[0].CompareTo("*DUNGEON") == 0){
                    localUser.Write("*SETUP");
                }
                //Receive message to start the lobby, as well as who the lobby leader is and the monster to be fought.
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
                    if (localUser.GetName().CompareTo(message[1]) == 0 && localUser.getHealth()[0] <= 0){
                        //In case the local user died before their turn
                        localUser.Write("*DEAD");
                    } else {
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
                    }
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
                        }
                        //Setup for deck and hand if in combat
                        if (combatants.Contains(localUser)){
                            while (inHand.Count > 0){
                                localUser.Deck().Discard(inHand[0]);
                                inHand.RemoveAt(0);
                            }
                            while (inPlay.Count > 0){
                                localUser.Deck().Discard(inPlay[0]);
                                inPlay.RemoveAt(0);
                            }
                            while (defenses.Count > 0){
                                localUser.Deck().Discard(defenses[0]);
                                defenses.RemoveAt(0);
                            }
                            localUser.Deck().Shuffle();
                            inHand = localUser.Deck().Draw(3);
                            ReloadHand();
                        }
                        if (localUser.IsTurn())
                            StartTurn();
                        txtLog.text = "It is "+ message[1]+"'s turn\n" + txtLog.text;
                    }
                }
                if (combatStep){
                    //If the user is recieving an attack
                    //Attacks are in the order...
                    //      ShieldBreak,Damage,IsHoming,IsPierce,ShieldIgnore,Type,tag
                    if (message[0].CompareTo("*ATTACK") == 0){
                        // The attack does not take immediate effect, instead it will store the values
                        // and project a notice to the players. The players can still use abilities or 
                        // potions UNTIL they confirm the notice. Before that, a *PENDING message will 
                        // inform every player in said combat how much damage each player is expected to
                        // take. If any damage is reduced, this will update accordingly.
                        int.TryParse(message[1], out int shb);
                        int.TryParse(message[2], out int dmg);
                        bool.TryParse(message[3], out bool hmg);
                        bool.TryParse(message[4], out bool prc);
                        bool.TryParse(message[5], out bool ign);
                        pendingShieldBreak += shb;
                        pendingDamage += dmg;
                        pendingHoming = pendingHoming || hmg;
                        pendingPierce = pendingPierce || prc;
                        pendingIgnore = pendingIgnore || ign;
                        pendingType = message[6];
                        if (message.Length > 7)
                            pendingTag = message[7];
                        //Calculate damage to Health
                        int damage = CalculateDamage();
                        localUser.Write("*DAMAGE,"+damage);
                        pnlConfirmDamage.SetActive(true);
                    if (message[0].CompareTo("*DAMAGEUPDATE") == 0){
                        string damageInfo = monster.GetName() + " is attacking for the following damage amounts:\n";
                        for (int i = 1; i < message.Length; i++) damageInfo += message[i] + "\n";
                        damageInfo += "You can still use potions and abilities at this time.";
                        txtDamageInfo.text = damageInfo;
                    }
                    if (message[0].CompareTo("*PREVENT") == 0){
                        int.TryParse(message[1], out int prevented);
                        pendingDamage -= prevented;
                        localUser.Write("*DAMAGE,"+damage);
                    }
                    if (message[0].CompareTo("*ATTACKCONFIRMED") == 0){
                        int finalDamage = attackResult();
                        localUser.takeDamage(finalDamage);
                        string finalResult = ("*RESULT,"+finalDamage);
                        if (pendingTag.CompareTo("DRAIN")==0 && finalDamage > 0) finalResult+=",DRAIN";
                        localUser.Write(finalResult);
                        pendingShieldBreak = 0;
                        pendingDamage = 0;
                        pendingHoming = false;
                        pendingPierce = false;
                        pendingIgnore = false;
                        pendingType = "";
                        pendingTag = "";
                        pnlConfirmDamage.SetActive(false);
                    }
                    if (message[0].CompareTo("*MILL") == 0){
                        Ability temp = localUser.Deck().Draw();
                        localUser.Write("*MILL,"+temp.GetCardType());
                        localUser.Deck().Discard(temp);
                        ReloadDiscard();
                    }
                    
                    }//Receives the results of an attack made by a player
                    if (message[0].CompareTo("*RESULT") == 0){
                        //int.TryParse(message[1],out monHealth);
                    }//Receives a message of which player it is now the turn of
                    if (message[0].CompareTo("*NEXT") == 0){
                        if(localUser.GetName().CompareTo(message[1]) == 0) {
                            localUser.IsTurn(true);
                        }
                        else {
                            localUser.IsTurn(false);
                            pnlPlayZone.SetActive(false);
                            btnTurnComplete.gameObject.SetActive(false);
                            btnRunAway.gameObject.SetActive(false);
                        }
                        if (localUser.IsTurn() && localUser.getHealth()[0] > 0)
                            StartTurn();
                        else if (localUser.IsTurn()){
                            localUser.SetAP(0);
                            localUser.Write("*REMOVE");
                            TurnComplete();
                        }

                    }//Receives a message for how much to heal everyone
                    if (message[0].CompareTo("*HEAL") == 0){
                        for (int h = 1; h < message.Length; h++){
                            string[] value = message[h].Split(':');
                            for (int j = 0; j < players.Count; j++){
                                if (players[j].GetName().CompareTo(value[0])==0){
                                    int.TryParse(value[1],out int num);
                                    players[j].Heal(num);
                                }
                            }
                        }
                    }//Receives a message to remove a player from combatants list
                    if (message[0].CompareTo("*REMOVE") == 0){
                        for (int c = 0; c < combatants.Count; c++){
                            if( combatants[c].GetName().CompareTo(message[1]) == 0){
                                if (combatants[c] == localUser){
                                    SwitchToLobby();
                                    pnlLobby.SetActive(false);
                                }
                                combatants.RemoveAt(c);
                            }
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
        btnRunAway.gameObject.SetActive(false);
        pnlInventory.SetActive(true);

        if (combatants.Contains(localUser))
            pnlRewards.SetActive(true);

        //Open Rewards distribution panel. Activate Accept button for lead;
        if (localUser.IsLead()) btnAccept.gameObject.SetActive(true);
        else btnAccept.gameObject.SetActive(false);
        while(combatants.Count > 0)
            combatants.RemoveAt(0);
        while (inHand.Count > 0){
            localUser.Deck().Discard(inHand[0]);
            inHand.RemoveAt(0);
        }
        while (inPlay.Count > 0){
            localUser.Deck().Discard(inPlay[0]);
            inPlay.RemoveAt(0);
        }
        while (defenses.Count > 0){
            localUser.Deck().Discard(defenses[0]);
            defenses.RemoveAt(0);
        }
        localUser.Deck().Shuffle();
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
        btnRunAway.gameObject.SetActive(false);
        pnlInventory.SetActive(true);
        pnlRewards.SetActive(false);
        while (inHand.Count > 0){
            localUser.Deck().Discard(inHand[0]);
            inHand.RemoveAt(0);
        }
        while (inPlay.Count > 0){
            localUser.Deck().Discard(inPlay[0]);
            inPlay.RemoveAt(0);
        }
        while (defenses.Count > 0){
            localUser.Deck().Discard(defenses[0]);
            defenses.RemoveAt(0);
        }
        localUser.Deck().Shuffle();
    }

    //Lobby Functions
    void LoadMonster(string name, string[] mods){
        //Loads in monster based on name.
        //For now, default training dummy
        // foreach (Monster m in monster
        // monHealth = monster.getStats()[0];
        // monHealthMax = monster.getStats()[0];
        // monAbilityShield = monster.getStats()[2];
        // monAbilityShieldMax = monster.getStats()[2];
        // monShield = monster.getStats()[1];
        // monShieldMax = monster.getStats()[1];
    }
    void clearMonster(){
        //Destroy(monster.gameObject);
        monster = null;
    }
    void LootNRun(){
        while (combatants.Count > 0)
            combatants.RemoveAt(0);
        combatants.Add(localUser);
        localUser.Write("*LOOT");
    }
    void PlayerParticipationToggle(int pIndex){
        if (players[pIndex].getHealth()[0]>0)
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
            btnRunAway.gameObject.SetActive(false);
            pnlInventory.SetActive(false);
            pnlRewards.SetActive(false);
            //Forth, totals up basic combat stats of user to be utilized throughout battle;
            //Resets all equipment values
            EQshieldBreak = 0;
            EQskillBoost = 0;
            EQspellboost = 0; 
            EQallBoost = 0;
            EQarmor = 0;
            EQevade = 0;
            EQHoming = false; 
            EQSKHoming = false; 
            EQSpellIgnore = false;
            EQPierce = false; 
            EQSPPierce = false; 
            EQSkillIgnore = false;
            foreach (Equipment e in localUser.GetEquipped()){
                //Exclude any potions
                if (e!=null){
                    Debug.Log("Getting equipment stats from: "+e.getName());
                    if (e.GetEquipType()[1].CompareTo("Potion")!=0){
                        EQshieldBreak += e.getShieldBreak(playerClass);
                        EQskillBoost += e.getSkillBoost(playerClass, localUser.getSlot(e));
                        EQspellboost += e.getSpellBoost(playerClass, localUser.getSlot(e));
                        EQallBoost += e.getAllBoost(playerClass, localUser.getSlot(e), enemyTier);
                        EQarmor += e.getArmor(playerClass, enemyTier);
                        EQevade += e.getEvade(playerClass, enemyTier);
                        EQHoming = EQHoming || e.isHoming(); 
                        EQSKHoming = EQSKHoming || e.isSkillHoming(playerClass); 
                        EQSpellIgnore = EQSpellIgnore || e.isSpellIgnore();
                        EQPierce = EQPierce || e.isPierce(); 
                        EQSPPierce = EQSPPierce || e.isSpellPierce(playerClass); 
                        EQSkillIgnore = EQSkillIgnore || e.isSkillIgnore();
                    }
                }
            }
        }
        rewardStep = false;
        lobbyStep = false;
        combatStep = true;
        ReloadDefenses();
        ReloadDiscard();
        ReloadHand();
        ReloadPlay();
    }

    //Combat Functions
    void TurnComplete(){
        if (localUser.IsTurn()  && localUser.getAP() <= 0) {
            nextHoming = false;
            nextPierce = false;
            skillBoost = 0;
            spellboost = 0;
            allBoost = 0;
            while(inPlay.Count > 0) {
                inPlay[0].Reset();
                localUser.Deck().Discard(inPlay[0]);
                inPlay.RemoveAt(0);
            }
            localUser.IsTurn(false);
            localUser.Write("*DONE");
            ReloadPlay();
            ReloadDiscard();
        }
    }
    void AcceptRewards(){
        //handling to ensure loot is divided as planned
        //NOT IMPLEMENTED AS NO LOOT TO DIVIDE
        localUser.Write("*ACCEPT");
    }
    void StartTurn(){
        localUser.SetAP(1);
        pnlPlayZone.SetActive(true);
        btnTurnComplete.gameObject.SetActive(true);
        btnRunAway.gameObject.SetActive(true);
        inHand.Add(localUser.Deck().Draw());
        txtActionPoints.text = "AP: "+localUser.getAP();
        ReloadHand();
    }
    void ReloadHand(){ //Displays the cards in hand, toggles button active status.
        if (inHand.Count > 0){
            btnCard1.gameObject.SetActive(true);
            btnCard1.image.sprite = inHand[0+handOffset].Image();
        } else {
            btnCard1.gameObject.SetActive(false);
            btnCard1.image.sprite = empty;
        }
        if (inHand.Count > 1){
            btnCard2.gameObject.SetActive(true);
            btnCard2.image.sprite = inHand[1+handOffset].Image();
        } else {
            btnCard2.gameObject.SetActive(false);
            btnCard2.image.sprite = empty;
        }
        if (inHand.Count > 2){
            btnCard3.gameObject.SetActive(true);
            btnCard3.image.sprite = inHand[2+handOffset].Image();
        } else {
            btnCard3.gameObject.SetActive(false);
            btnCard3.image.sprite = empty;
        }
        if (inHand.Count > 3){
            btnCard4.gameObject.SetActive(true);
            btnCard4.image.sprite = inHand[3+handOffset].Image();
        } else {
            btnCard4.gameObject.SetActive(false);
            btnCard4.image.sprite = empty;
        }
        if (inHand.Count > 4){
            btnCard5.gameObject.SetActive(true);
            btnCard5.image.sprite = inHand[4+handOffset].Image();
        } else {
            btnCard5.gameObject.SetActive(false);
            btnCard5.image.sprite = empty;
        }
        if (inHand.Count > 5){
            btnCard6.gameObject.SetActive(true);
            btnCard6.image.sprite = inHand[5+handOffset].Image();
        } else {
            btnCard6.gameObject.SetActive(false);
            btnCard6.image.sprite = empty;
        }
        if (inHand.Count > 6){
            if (handOffset > 0) btnHandLeft.gameObject.SetActive(true);
            else btnHandLeft.gameObject.SetActive(false);
            if (handOffset < inHand.Count-6) btnHandRight.gameObject.SetActive(true);
            else btnHandRight.gameObject.SetActive(false);
        } else {
            btnHandLeft.gameObject.SetActive(false);
            btnHandRight.gameObject.SetActive(false);
        }
    }
    void ReloadDefenses(){ //Displays the cards in defenses, toggles button active status.
        for (int i = defenses.Count-1; i >= 0; i--){
            if (defenses[i].getCurrentDefenses()[1] <= 0){
                defenses[i].Reset();
                localUser.Deck().Discard(defenses[i]);
                defenses.RemoveAt(i);
            }
        }
        if (defenses.Count > 0){
            btnDefense1.gameObject.SetActive(true);
            btnDefense1.image.sprite = defenses[0+defOffset].Image();
            int[] defs = defenses[0+defOffset].getCurrentDefenses();
            imgDefenseShield1.transform.localScale = new Vector3((float)defs[1]/defs[2],1,1);
            imgDefenseShield1.color = defs[0] == 1? new Color(.7f,.7f,.7f,1) : Color.cyan;
            txtDefenseShield1.text = defs[1]+"/"+defs[2];
        } else {
            btnDefense1.gameObject.SetActive(false);
            btnDefense1.image.sprite = empty;
        }
        if (defenses.Count > 1){
            btnDefense2.gameObject.SetActive(true);
            btnDefense2.image.sprite = defenses[1+defOffset].Image();
            int[] defs = defenses[0+defOffset].getCurrentDefenses();
            imgDefenseShield2.transform.localScale = new Vector3((float)defs[1]/defs[2],1,1);
            imgDefenseShield2.color = defs[0] == 1? new Color(.7f,.7f,.7f,1) : Color.cyan;
            txtDefenseShield2.text = defs[1]+"/"+defs[2];
        } else {
            btnDefense2.gameObject.SetActive(false);
            btnDefense2.image.sprite = empty;
        }
        if (defenses.Count > 2){
            btnDefense3.gameObject.SetActive(true);
            btnDefense3.image.sprite = defenses[2+defOffset].Image();
            int[] defs = defenses[0+defOffset].getCurrentDefenses();
            imgDefenseShield3.transform.localScale = new Vector3((float)defs[1]/defs[2],1,1);
            imgDefenseShield3.color = defs[0] == 1? new Color(.7f,.7f,.7f,1) : Color.cyan;
            txtDefenseShield3.text = defs[1]+"/"+defs[2];
        } else {
            btnDefense3.gameObject.SetActive(false);
            btnDefense3.image.sprite = empty;
        }
        if (defenses.Count > 3){
            btnDefense4.gameObject.SetActive(true);
            btnDefense4.image.sprite = defenses[3+defOffset].Image();
            int[] defs = defenses[0+defOffset].getCurrentDefenses();
            imgDefenseShield4.transform.localScale = new Vector3((float)defs[1]/defs[2],1,1);
            imgDefenseShield4.color = defs[0] == 1? new Color(.7f,.7f,.7f,1) : Color.cyan;
            txtDefenseShield4.text = defs[1]+"/"+defs[2];
        } else {
            btnDefense4.gameObject.SetActive(false);
            btnDefense4.image.sprite = empty;
        }
        if (defenses.Count > 4){
            btnDefense5.gameObject.SetActive(true);
            btnDefense5.image.sprite = defenses[4+defOffset].Image();
            int[] defs = defenses[0+defOffset].getCurrentDefenses();
            imgDefenseShield5.transform.localScale = new Vector3((float)defs[1]/defs[2],1,1);
            imgDefenseShield5.color = defs[0] == 1? new Color(.7f,.7f,.7f,1) : Color.cyan;
            txtDefenseShield5.text = defs[1]+"/"+defs[2];
        } else {
            btnDefense5.gameObject.SetActive(false);
            btnDefense5.image.sprite = empty;
        }
        if (defenses.Count > 5){
            btnDefense6.gameObject.SetActive(true);
            btnDefense6.image.sprite = defenses[5+defOffset].Image();
            int[] defs = defenses[0+defOffset].getCurrentDefenses();
            imgDefenseShield6.transform.localScale = new Vector3((float)defs[1]/defs[2],1,1);
            imgDefenseShield6.color = defs[0] == 1? new Color(.7f,.7f,.7f,1) : Color.cyan;
            txtDefenseShield6.text = defs[1]+"/"+defs[2];
        } else {
            btnDefense6.gameObject.SetActive(false);
            btnDefense6.image.sprite = empty;
        }
        if (defenses.Count > 6){
            if (defOffset > 0) btnDefensesLeft.gameObject.SetActive(true);
            else btnDefensesLeft.gameObject.SetActive(false);
            if (defOffset < defenses.Count-6) btnDefensesRight.gameObject.SetActive(true);
            else btnDefensesRight.gameObject.SetActive(false);
        } else {
            btnDefensesLeft.gameObject.SetActive(false);
            btnDefensesRight.gameObject.SetActive(false);
        }
    }
    void ReloadPlay(){ //Displays the cards in play, toggles button active status.
        if (inPlay.Count > 0){
            btnPlay1.gameObject.SetActive(true);
            btnPlay1.image.sprite = inPlay[0+playOffset].Image();
        } else {
            btnPlay1.gameObject.SetActive(false);
            btnPlay1.image.sprite = empty;
        }
        if (inPlay.Count > 1){
            btnPlay2.gameObject.SetActive(true);
            btnPlay2.image.sprite = inPlay[1+playOffset].Image();
        } else {
            btnPlay2.gameObject.SetActive(false);
            btnPlay2.image.sprite = empty;
        }
        if (inPlay.Count > 2){
            btnPlay3.gameObject.SetActive(true);
            btnPlay3.image.sprite = inPlay[2+playOffset].Image();
        } else {
            btnPlay3.gameObject.SetActive(false);
            btnPlay3.image.sprite = empty;
        }
        if (inPlay.Count > 3){
            btnPlay4.gameObject.SetActive(true);
            btnPlay4.image.sprite = inPlay[3+playOffset].Image();
        } else {
            btnPlay4.gameObject.SetActive(false);
            btnPlay4.image.sprite = empty;
        }
        if (inPlay.Count > 4){
            if (playOffset > 0) btnPlayLeftScroll.gameObject.SetActive(true);
            else btnPlayLeftScroll.gameObject.SetActive(false);
            if (playOffset < inPlay.Count-4) btnPlayRightScroll.gameObject.SetActive(true);
            else btnPlayRightScroll.gameObject.SetActive(false);
        } else {
            btnPlayLeftScroll.gameObject.SetActive(false);
            btnPlayRightScroll.gameObject.SetActive(false);
        }
    }
    void ReloadDiscard(){ //Displays the cards in discard, toggles button active status.
        //Discard Zone top card
        if (localUser.Deck().peekDiscardTop() != null)
            btnDiscardTop.image.sprite = localUser.Deck().peekDiscardTop().Image();
            else btnDiscardTop.image.sprite = empty;
        //Discard Itself
        if (pnlDiscard.activeSelf){
            if (localUser.Deck().DiscardCount() > 0){
                btnDiscard1.gameObject.SetActive(true);
                btnDiscard1.image.sprite = localUser.Deck().InspectDiscard()[0+discardOffset].Image();
            } else {
                btnDiscard1.gameObject.SetActive(false);
                btnDiscard1.image.sprite = empty;
            }
            if (localUser.Deck().DiscardCount() > 1){
                btnDiscard2.gameObject.SetActive(true);
                btnDiscard2.image.sprite = localUser.Deck().InspectDiscard()[1+discardOffset].Image();
            } else {
                btnDiscard2.gameObject.SetActive(false);
                btnDiscard2.image.sprite = empty;
            }
            if (localUser.Deck().DiscardCount() > 2){
                btnDiscard3.gameObject.SetActive(true);
                btnDiscard3.image.sprite = localUser.Deck().InspectDiscard()[2+discardOffset].Image();
            } else {
                btnDiscard3.gameObject.SetActive(false);
                btnDiscard3.image.sprite = empty;
            }
            if (localUser.Deck().DiscardCount() > 3){
                btnDiscard4.gameObject.SetActive(true);
                btnDiscard4.image.sprite = localUser.Deck().InspectDiscard()[3+discardOffset].Image();
            } else {
                btnDiscard4.gameObject.SetActive(false);
                btnDiscard4.image.sprite = empty;
            }
            if (localUser.Deck().DiscardCount() > 4){
                btnDiscard5.gameObject.SetActive(true);
                btnDiscard5.image.sprite = localUser.Deck().InspectDiscard()[4+discardOffset].Image();
            } else {
                btnDiscard5.gameObject.SetActive(false);
                btnDiscard5.image.sprite = empty;
            }
            if (localUser.Deck().DiscardCount() > 5){
                btnDiscard6.gameObject.SetActive(true);
                btnDiscard6.image.sprite = localUser.Deck().InspectDiscard()[5+discardOffset].Image();
            } else {
                btnDiscard6.gameObject.SetActive(false);
                btnDiscard6.image.sprite = empty;
            }
            if (localUser.Deck().DiscardCount() > 6){
                if (discardOffset > 0) btnDiscardLeftScroll.gameObject.SetActive(true);
                else btnDiscardLeftScroll.gameObject.SetActive(false);
                if (discardOffset < localUser.Deck().DiscardCount()-6) btnDiscardRightScroll.gameObject.SetActive(true);
                else btnDiscardRightScroll.gameObject.SetActive(false);
            } else {
                btnDiscardLeftScroll.gameObject.SetActive(false);
                btnDiscardRightScroll.gameObject.SetActive(false);
            }
        }
    }
    void ReloadDeck(){ //Displays the cards in deck, toggles button active status.
        if (pnlDeck.activeSelf){
            if (localUser.Deck().DeckCount() > 0){
                btnDeck1.gameObject.SetActive(true);
                btnDeck1.image.sprite = localUser.Deck().InspectDeck()[0+deckOffset].Image();
            } else {
                btnDeck1.gameObject.SetActive(false);
                btnDeck1.image.sprite = empty;
            }
            if (localUser.Deck().DeckCount() > 1){
                btnDeck2.gameObject.SetActive(true);
                btnDeck2.image.sprite = localUser.Deck().InspectDeck()[1+deckOffset].Image();
            } else {
                btnDeck2.gameObject.SetActive(false);
                btnDeck2.image.sprite = empty;
            }
            if (localUser.Deck().DeckCount() > 2){
                btnDeck3.gameObject.SetActive(true);
                btnDeck3.image.sprite = localUser.Deck().InspectDeck()[2+deckOffset].Image();
            } else {
                btnDeck3.gameObject.SetActive(false);
                btnDeck3.image.sprite = empty;
            }
            if (localUser.Deck().DeckCount() > 3){
                btnDeck4.gameObject.SetActive(true);
                btnDeck4.image.sprite = localUser.Deck().InspectDeck()[3+deckOffset].Image();
            } else {
                btnDeck4.gameObject.SetActive(false);
                btnDeck4.image.sprite = empty;
            }
            if (localUser.Deck().DeckCount() > 4){
                btnDeck5.gameObject.SetActive(true);
                btnDeck5.image.sprite = localUser.Deck().InspectDeck()[4+deckOffset].Image();
            } else {
                btnDeck5.gameObject.SetActive(false);
                btnDeck5.image.sprite = empty;
            }
            if (localUser.Deck().DeckCount() > 5){
                btnDeck6.gameObject.SetActive(true);
                btnDeck6.image.sprite = localUser.Deck().InspectDeck()[5+deckOffset].Image();
            } else {
                btnDeck6.gameObject.SetActive(false);
                btnDeck6.image.sprite = empty;
            }
            if (localUser.Deck().DeckCount() > 6){
                if (deckOffset > 0) btnDeckLeftScroll.gameObject.SetActive(true);
                else btnDeckLeftScroll.gameObject.SetActive(false);
                if (deckOffset < localUser.Deck().DeckCount()-6) btnDeckRightScroll.gameObject.SetActive(true);
                else btnDeckRightScroll.gameObject.SetActive(false);
            } else {
                btnDeckLeftScroll.gameObject.SetActive(false);
                btnDeckRightScroll.gameObject.SetActive(false);
            }
        }
    }
    void PlayCard(int num){ //Plays a card based on attributes.
        if (localUser.IsTurn() && localUser.getAP() > 0){
            Ability card = inHand[num + handOffset];
            //First, checks if is Critical card and rolls if it is.
            int result = card.RollSuccess();
            if (result > 0) {
                localUser.Write("*CHAT,"+localUser.GetName()+" rolled a "+result+" on critical attempt.");
            }
            //If is type attack, will make an attack call on the enemy.
            //ShieldBreak,Damage,IsHoming,IsPierce,IsCollateral
            if (card.isAttack()&&card.getName().CompareTo("Counter")!=0){
                int[] damages = card.GetDamage();
                bool[] types = card.GetDamageType();
                string SPorSK = card.GetSPSK();
                bool ignore = false;
                if (types[2] == false){//Add equipment damages and bonuses
                    if (SPorSK.CompareTo("Spell") == 0){
                        damages[0] += EQshieldBreak;
                        damages[1] += spellboost + EQspellboost + allBoost + EQallBoost;
                        types[0] = types[0] || nextHoming || EQHoming;
                        types[1] = types[1] || EQSPPierce;
                        ignore = EQSpellIgnore; 
                        nextHoming = false;
                    } else {
                        damages[0] += EQshieldBreak;
                        damages[1] += skillBoost + EQskillBoost + allBoost + EQallBoost;
                        types[0] = types[0] || EQSKHoming;
                        types[1] = types[1] || nextPierce || EQPierce;
                        ignore = EQSkillIgnore;
                        nextPierce = false;
                    }
                    spellboost = 0;
                    skillBoost = 0;
                    allBoost = 0;
                }
                localUser.Write("*ATTACK,"+card.getName()+","+damages[0]+","+damages[1]+","+types[0]+","+types[1]+","+types[2]+","+ ignore);
            } else {
                //condintions for cards that add pierce or homing to NEXT attack.
                nextHoming = card.GetDamageType()[0];
                nextPierce = card.GetDamageType()[1];
            }
            if (card.RestoresShields()) RestoreEquipment();
            for (int i = 0; i < card.getDraw(); i++)
                inHand.Add(localUser.Deck().Draw());
            localUser.changeAP(card.getEnergy());
            Heal(card.getHeal());
            spellboost += card.getSPBoost();
            skillBoost += card.getSKBoost();
            if (card.RunsAway()) Flee(num + handOffset);
            //If greater than 0, it's a shield card. Goes into defense row AFTER all other effects complete.
            //Otherwise, goes into inPlay row.
            if (card.getShields() + card.getPowerShields() > 0){
                defenses.Add(card);
                card.SetShields();
            }
            else inPlay.Add(card);
            inHand.RemoveAt(num);
            //Finally, reduces player AP by one.
            localUser.changeAP(-1);
            //Reload respective fields
            ReloadHand();
            ReloadDefenses();
            ReloadPlay();
            ReloadDiscard();
            txtActionPoints.text = "AP: "+localUser.getAP();
        }
    }
    void RunAway(){
        if (localUser.IsTurn() && localUser.getAP() > 0){
            localUser.changeAP(-1);
            int result = Random.Range(1,7);
            if (result > 4){
                localUser.Write("*CHAT,"+localUser.GetName()+" successfully ran from combat!");
                combatants.Remove(localUser);
                localUser.SetAP(0);
                localUser.Write("*REMOVE");
                TurnComplete();
            } else localUser.Write("*CHAT,"+localUser.GetName()+" failed to run from combat!");
        }
    }
    void RestoreEquipment(){
        //Restores all broken shields to equipment
        foreach (Equipment e in localUser.GetEquipped()){
            if (e != null)
                e.restoreShields();
        }
    }
    void Heal(int amount){
        // Opens a panel to determine how healing should be distributed.
        if (amount > 0){
            pnlHeal.SetActive(true);
            for (int i = 0; i < heals.Length; i++)
                heals[i] = 0;
            heals[0] = amount;
            ReloadHeal();
        }
    }
    void ReloadHeal(){
        txtHealP1.text = localUser.GetName();
        txtHealAmountP1.text = ""+heals[0];
        if (combatants.Contains(players[1])) { 
            txtHealP2.gameObject.SetActive(true);
            txtHealP2.text = players[1].GetName();
            txtHealAmountP2.text = ""+heals[1];
        }
        else txtHealP2.gameObject.SetActive(false);
        if (players.Count > 2 && combatants.Contains(players[2])) { 
            txtHealP3.gameObject.SetActive(true);
            txtHealP3.text = players[2].GetName();
            txtHealAmountP3.text = ""+heals[2];
        }
        else txtHealP3.gameObject.SetActive(false);
        if (players.Count > 3 && combatants.Contains(players[3])) { 
            txtHealP4.gameObject.SetActive(true);
            txtHealP4.text = players[3].GetName();
            txtHealAmountP4.text = ""+heals[3];
        }
        else txtHealP4.gameObject.SetActive(false);
    }
    void ConfirmHeal(){
        string healList = "*HEAL";
        for (int i = 0; i < players.Count; i++){
            healList += ","+players[i].GetName()+":"+heals[i];
        }
        localUser.Write(healList);
        pnlHeal.SetActive(false);
    }
    void Flee(int index){
        //Gives option to run away or simply discard the card.
        pnlFlee.SetActive(true);
    }
    void FleeCombat(){
        combatants.Remove(localUser);
        localUser.SetAP(0);
        localUser.Write("*REMOVE");
        TurnComplete();
        pnlFlee.SetActive(false);
    }
    void DiscardFlee(){
        localUser.changeAP(1);
        pnlFlee.SetActive(false);
    }
    int attackResult(){
        //Calculate shield break
        if (pendingShieldBreak > 0){
            for (int d = 0; d < defenses.Count; d++){
                if (defenses[d].getCurrentDefenses()[0] == 0){ //regular shields, shield break is applied.
                    if (defenses[d].getCurrentDefenses()[1] >= pendingShieldBreak){
                        defenses[d].DamageSheilds(pendingShieldBreak);
                        pendingShieldBreak = 0;
                    } else {
                        pendingShieldBreak -= defenses[d].getCurrentDefenses()[1];
                        defenses[d].DamageSheilds(defenses[d].getCurrentDefenses()[1]);
                    }
                }
            }
            foreach (Equipment e in localUser.GetEquipped()){
                if (e != null){
                    if (e.getCurrentShieldValues()[0] > 0){
                        if (e.getCurrentShieldValues()[0] > pendingShieldBreak){
                            e.damageShields(pendingShieldBreak);
                            pendingShieldBreak = 0;
                        }else{
                            pendingShieldBreak -= e.getCurrentShieldValues()[0];
                            e.damageShields(e.getCurrentShieldValues()[0]);
                        }
                    }
                }
            }
        }
        if (pendingTag.CompareTo("HANDCOUNTREDUCE")==0) pendingDamage -= inHand.Count;
        int evade = 0;
        int armor = 0;
        foreach (Ability a in defenses){
            evade += a.getEvade();
        }
        foreach (Equipment e in localUser.GetEquipped()){
            if (e != null){
                armor += e.getArmor(playerClass,enemyTier);
                evade += e.getEvade(playerClass,enemyTier);
            }
        } ReloadDefenses();
        //Calculate evade
        if (pendingHoming == false && pendingType.CompareTo("Collateral")!=0){
            pendingDamage -= evade;
        } if (pendingDamage <= 0) return 0;
        if (pendingIgnore == false){
            for (int d = 0; d < defenses.Count; d++){
                if (defenses[d].getCurrentDefenses()[1] >= pendingDamage){
                    defenses[d].DamageSheilds(pendingDamage);
                    pendingDamage = 0;
                } else {
                    pendingDamage -= defenses[d].getCurrentDefenses()[1];
                    defenses[d].DamageSheilds(defenses[d].getCurrentDefenses()[1]);
                }
                
            }
            ReloadDefenses();
                foreach (Equipment e in localUser.GetEquipped()){// regular shields break from damage
                    if (e != null){
                        if (e.getCurrentShieldValues()[0] > 0){
                            if (e.getCurrentShieldValues()[0] > pendingDamage){
                                e.damageShields(pendingDamage);
                                pendingDamage = 0;
                            }else{
                                pendingDamage -= e.getCurrentShieldValues()[0];
                                e.damageShields(e.getCurrentShieldValues()[0]);
                            }
                        }
                    }
                }
                foreach (Equipment e in localUser.GetEquipped()){//power shields break from damage
                    if (e != null){
                        if (e.getCurrentShieldValues()[1] > 0){
                            if (e.getCurrentShieldValues()[1] > pendingDamage){
                                e.damagePowerShields(pendingDamage);
                                pendingDamage = 0;
                            }else{
                                pendingDamage -= e.getCurrentShieldValues()[1];
                                e.damagePowerShields(e.getCurrentShieldValues()[1]);
                            }
                        }
                    }
                }
        }
        ReloadEquipped();
        if (pendingDamage <= 0) return 0;
        //Armor
        if (pendingPierce == false && pendingType.CompareTo("Collateral")!=0){
            pendingDamage -= armor;
        }
        if (pendingDamage <= 0) return 0;

        return pendingDamage;
    }
    void ReloadArsenalView(){
        viewArsenal = localUser.Arsenal();
        if (viewArsenal.Count > 0){
            btnArsenal1.gameObject.SetActive(true);
            btnArsenal1.image.sprite =  viewArsenal[0+ArsenalOffset].Image();
        } else {
            btnArsenal1.gameObject.SetActive(false);
            btnArsenal1.image.sprite = empty;
        }
        if ( viewArsenal.Count > 1){
            btnArsenal2.gameObject.SetActive(true);
            btnArsenal2.image.sprite =  viewArsenal[1+ArsenalOffset].Image();
        } else {
            btnArsenal2.gameObject.SetActive(false);
            btnArsenal2.image.sprite = empty;
        }
        if ( viewArsenal.Count > 2){
            btnArsenal3.gameObject.SetActive(true);
            btnArsenal3.image.sprite =  viewArsenal[2+ArsenalOffset].Image();
        } else {
            btnArsenal3.gameObject.SetActive(false);
            btnArsenal3.image.sprite = empty;
        }
        if ( viewArsenal.Count > 3){
            btnArsenal4.gameObject.SetActive(true);
            btnArsenal4.image.sprite =  viewArsenal[3+ArsenalOffset].Image();
        } else {
            btnArsenal4.gameObject.SetActive(false);
            btnArsenal4.image.sprite = empty;
        }
        if ( viewArsenal.Count > 4){
            btnArsenal5.gameObject.SetActive(true);
            btnArsenal5.image.sprite =  viewArsenal[4+ArsenalOffset].Image();
        } else {
            btnArsenal5.gameObject.SetActive(false);
            btnArsenal5.image.sprite = empty;
        }
        if ( viewArsenal.Count > 5){
            btnArsenal6.gameObject.SetActive(true);
            btnArsenal6.image.sprite =  viewArsenal[5+ArsenalOffset].Image();
        } else {
            btnArsenal6.gameObject.SetActive(false);
            btnArsenal6.image.sprite = empty;
        }
        if ( viewArsenal.Count > 6){
            if (ArsenalOffset > 0) btnArsenalLeftScroll.gameObject.SetActive(true);
            else btnArsenalLeftScroll.gameObject.SetActive(false);
            if (ArsenalOffset <  viewArsenal.Count-6) btnArsenalRightScroll.gameObject.SetActive(true);
            else btnArsenalRightScroll.gameObject.SetActive(false);
        } else {
            btnArsenalLeftScroll.gameObject.SetActive(false);
            btnArsenalRightScroll.gameObject.SetActive(false);
        }
    }    
    void ReloadEquipOptionView(){
        if (viewEquipOption.Count > 0){
            btnEquipOption1.gameObject.SetActive(true);
            btnEquipOption1.image.sprite =  viewEquipOption[0+EquipOptionOffset].Image();
        } else {
            btnEquipOption1.gameObject.SetActive(false);
            btnEquipOption1.image.sprite = empty;
        }
        if ( viewEquipOption.Count > 1){
            btnEquipOption2.gameObject.SetActive(true);
            btnEquipOption2.image.sprite =  viewEquipOption[1+EquipOptionOffset].Image();
        } else {
            btnEquipOption2.gameObject.SetActive(false);
            btnEquipOption2.image.sprite = empty;
        }
        if ( viewEquipOption.Count > 2){
            btnEquipOption3.gameObject.SetActive(true);
            btnEquipOption3.image.sprite =  viewEquipOption[2+EquipOptionOffset].Image();
        } else {
            btnEquipOption3.gameObject.SetActive(false);
            btnEquipOption3.image.sprite = empty;
        }
        if ( viewEquipOption.Count > 3){
            btnEquipOption4.gameObject.SetActive(true);
            btnEquipOption4.image.sprite =  viewEquipOption[3+EquipOptionOffset].Image();
        } else {
            btnEquipOption4.gameObject.SetActive(false);
            btnEquipOption4.image.sprite = empty;
        }
        if ( viewEquipOption.Count > 4){
            btnEquipOption5.gameObject.SetActive(true);
            btnEquipOption5.image.sprite =  viewEquipOption[4+EquipOptionOffset].Image();
        } else {
            btnEquipOption5.gameObject.SetActive(false);
            btnEquipOption5.image.sprite = empty;
        }
        if ( viewEquipOption.Count > 5){
            btnEquipOption6.gameObject.SetActive(true);
            btnEquipOption6.image.sprite =  viewEquipOption[5+EquipOptionOffset].Image();
        } else {
            btnEquipOption6.gameObject.SetActive(false);
            btnEquipOption6.image.sprite = empty;
        }
        if ( viewEquipOption.Count > 6){
            if (EquipOptionOffset > 0) btnEquipOptionLeftScroll.gameObject.SetActive(true);
            else btnEquipOptionLeftScroll.gameObject.SetActive(false);
            if (EquipOptionOffset <  viewEquipOption.Count-6) btnEquipOptionRightScroll.gameObject.SetActive(true);
            else btnEquipOptionRightScroll.gameObject.SetActive(false);
        } else {
            btnEquipOptionLeftScroll.gameObject.SetActive(false);
            btnEquipOptionRightScroll.gameObject.SetActive(false);
        }
    }
    void ReloadEquipped(){
        if (localUser.GetEquipped("Armor") != null){ //armor
            btnEquipBody.image.sprite = localUser.GetEquipped("Armor").Image();
            if (localUser.GetEquipped("Armor").getShield(playerClass, enemyTier) > 0){
                imgEquipBodyShield.transform.parent.gameObject.SetActive(true);
                imgEquipBodyShield.transform.localScale = new Vector3((float)localUser.GetEquipped("Armor").getCurrentShieldValues()[0]/localUser.GetEquipped("Armor").getShield(playerClass, enemyTier),1,1);
                txtEquipBodyShield.text = localUser.GetEquipped("Armor").getCurrentShieldValues()[0]+"/"+localUser.GetEquipped("Armor").getShield(playerClass, enemyTier);
                imgEquipBodyShield.color = Color.cyan;
            }
            if (localUser.GetEquipped("Armor").getPowerShield(playerClass) > 0){
                imgEquipBodyShield.transform.parent.gameObject.SetActive(true);
                imgEquipBodyShield.transform.localScale = new Vector3((float)localUser.GetEquipped("Armor").getCurrentShieldValues()[1]/localUser.GetEquipped("Armor").getPowerShield(playerClass),1,1);
                txtEquipBodyShield.text = localUser.GetEquipped("Armor").getCurrentShieldValues()[1]+"/"+localUser.GetEquipped("Armor").getPowerShield(playerClass);
                imgEquipBodyShield.color = new Color(.7f,.7f,.7f,1);
            }
            if (localUser.GetEquipped("Armor").getPowerShield(playerClass) == 0 && localUser.GetEquipped("Armor").getShield(playerClass, 0) == 0)
                imgEquipBodyShield.transform.parent.gameObject.SetActive(false);
        } else btnEquipBody.image.sprite = empty;
        if (localUser.GetEquipped("Main") != null){
            btnEquipMainHand.image.sprite = localUser.GetEquipped("Main").Image();
            if (localUser.GetEquipped("Main").getShield(playerClass, enemyTier) > 0){
                imgEquipMainHandShield.transform.parent.gameObject.SetActive(true);
                imgEquipMainHandShield.transform.localScale = new Vector3((float)localUser.GetEquipped("Main").getCurrentShieldValues()[0]/localUser.GetEquipped("Main").getShield(playerClass, enemyTier),1,1);
                txtEquipMainHandShield.text = localUser.GetEquipped("Main").getCurrentShieldValues()[0]+"/"+localUser.GetEquipped("Main").getShield(playerClass, enemyTier);
                imgEquipMainHandShield.color = Color.cyan;
            }
            if (localUser.GetEquipped("Main").getPowerShield(playerClass) > 0){
                imgEquipMainHandShield.transform.parent.gameObject.SetActive(true);
                imgEquipMainHandShield.transform.localScale = new Vector3((float)localUser.GetEquipped("Main").getCurrentShieldValues()[1]/localUser.GetEquipped("Main").getPowerShield(playerClass),1,1);
                txtEquipMainHandShield.text = localUser.GetEquipped("Main").getCurrentShieldValues()[1]+"/"+localUser.GetEquipped("Main").getPowerShield(playerClass);
                imgEquipMainHandShield.color = new Color(.7f,.7f,.7f,1);
            }
            if (localUser.GetEquipped("Main").getPowerShield(playerClass) == 0 && localUser.GetEquipped("Main").getShield(playerClass, 0) == 0)
                imgEquipMainHandShield.transform.parent.gameObject.SetActive(false);
        } else btnEquipMainHand.image.sprite = empty;
        if (localUser.GetEquipped("Off") != null){
            btnEquipOffHand.image.sprite = localUser.GetEquipped("Off").Image();
            if (localUser.GetEquipped("Off").getShield(playerClass, enemyTier) > 0){
                imgEquipOffHandShield.transform.parent.gameObject.SetActive(true);
                imgEquipOffHandShield.transform.localScale = new Vector3((float)localUser.GetEquipped("Off").getCurrentShieldValues()[0]/localUser.GetEquipped("Off").getShield(playerClass, enemyTier),1,1);
                txtEquipOffHandShield.text = localUser.GetEquipped("Off").getCurrentShieldValues()[0]+"/"+localUser.GetEquipped("Off").getShield(playerClass, enemyTier);
                imgEquipOffHandShield.color = Color.cyan;
            }
            if (localUser.GetEquipped("Off").getPowerShield(playerClass) > 0){
                imgEquipOffHandShield.transform.parent.gameObject.SetActive(true);
                imgEquipOffHandShield.transform.localScale = new Vector3((float)localUser.GetEquipped("Off").getCurrentShieldValues()[1]/localUser.GetEquipped("Off").getPowerShield(playerClass),1,1);
                txtEquipOffHandShield.text = localUser.GetEquipped("Off").getCurrentShieldValues()[1]+"/"+localUser.GetEquipped("Off").getPowerShield(playerClass);
                imgEquipOffHandShield.color = new Color(.7f,.7f,.7f,1);
            }
            if (localUser.GetEquipped("Off").getPowerShield(playerClass) == 0 && localUser.GetEquipped("Off").getShield(playerClass, 0) == 0)
                imgEquipOffHandShield.transform.parent.gameObject.SetActive(false);
        } else btnEquipOffHand.image.sprite = empty;
        if (localUser.GetEquipped("Extra") != null){ 
            btnEquipExtra.image.sprite = localUser.GetEquipped("Extra").Image();
            if (localUser.GetEquipped("Extra").getShield(playerClass, enemyTier) > 0){
                imgEquipExtraShield.transform.parent.gameObject.SetActive(true);
                imgEquipExtraShield.transform.localScale = new Vector3((float)localUser.GetEquipped("Extra").getCurrentShieldValues()[0]/localUser.GetEquipped("Extra").getShield(playerClass, enemyTier),1,1);
                txtEquipExtraShield.text = localUser.GetEquipped("Extra").getCurrentShieldValues()[0]+"/"+localUser.GetEquipped("Extra").getShield(playerClass, enemyTier);
                imgEquipExtraShield.color = Color.cyan;
            }
            if (localUser.GetEquipped("Extra").getPowerShield(playerClass) > 0){
                imgEquipExtraShield.transform.parent.gameObject.SetActive(true);
                imgEquipExtraShield.transform.localScale = new Vector3((float)localUser.GetEquipped("Extra").getCurrentShieldValues()[1]/localUser.GetEquipped("Extra").getPowerShield(playerClass),1,1);
                txtEquipExtraShield.text = localUser.GetEquipped("Extra").getCurrentShieldValues()[1]+"/"+localUser.GetEquipped("Extra").getPowerShield(playerClass);
                imgEquipExtraShield.color = new Color(.7f,.7f,.7f,1);
            }
            if (localUser.GetEquipped("Extra").getPowerShield(playerClass) == 0 && localUser.GetEquipped("Extra").getShield(playerClass, 0) == 0)
                imgEquipExtraShield.transform.parent.gameObject.SetActive(false);
        } else btnEquipExtra.image.sprite = empty;
        if (localUser.GetEquipped("Aux1") != null){
            btnAux1.image.sprite = localUser.GetEquipped("Aux1").Image();
            if (localUser.GetEquipped("Aux1").getShield(playerClass, enemyTier) > 0){
                imgAuxShield1.transform.parent.gameObject.SetActive(true);
                imgAuxShield1.transform.localScale = new Vector3((float)localUser.GetEquipped("Aux1").getCurrentShieldValues()[0]/localUser.GetEquipped("Aux1").getShield(playerClass, enemyTier),1,1);
                txtAuxShield1.text = localUser.GetEquipped("Aux1").getCurrentShieldValues()[0]+"/"+localUser.GetEquipped("Aux1").getShield(playerClass, enemyTier);
                imgAuxShield1.color = Color.cyan;
            }
            if (localUser.GetEquipped("Aux1").getPowerShield(playerClass) > 0){
                imgAuxShield1.transform.parent.gameObject.SetActive(true);
                imgAuxShield1.transform.localScale = new Vector3((float)localUser.GetEquipped("Aux1").getCurrentShieldValues()[1]/localUser.GetEquipped("Aux1").getPowerShield(playerClass),1,1);
                txtAuxShield1.text = localUser.GetEquipped("Aux1").getCurrentShieldValues()[1]+"/"+localUser.GetEquipped("Aux1").getPowerShield(playerClass);
                imgAuxShield1.color = new Color(.7f,.7f,.7f,1);
            }
            if (localUser.GetEquipped("Aux1").getPowerShield(playerClass) == 0 && localUser.GetEquipped("Aux1").getShield(playerClass, 0) == 0)
                imgAuxShield1.transform.parent.gameObject.SetActive(false);
        } else btnAux1.image.sprite = empty;
        if (localUser.GetEquipped("Aux2") != null){
            btnAux2.image.sprite = localUser.GetEquipped("Aux2").Image();
            if (localUser.GetEquipped("Aux2").getShield(playerClass, enemyTier) > 0){
                imgAuxShield2.transform.parent.gameObject.SetActive(true);
                imgAuxShield2.transform.localScale = new Vector3((float)localUser.GetEquipped("Aux2").getCurrentShieldValues()[0]/localUser.GetEquipped("Aux2").getShield(playerClass, enemyTier),1,1);
                txtAuxShield2.text = localUser.GetEquipped("Aux2").getCurrentShieldValues()[0]+"/"+localUser.GetEquipped("Aux2").getShield(playerClass, enemyTier);
                imgAuxShield2.color = Color.cyan;
            }
            if (localUser.GetEquipped("Aux2").getPowerShield(playerClass) > 0){
                imgAuxShield2.transform.parent.gameObject.SetActive(true);
                imgAuxShield2.transform.localScale = new Vector3((float)localUser.GetEquipped("Aux2").getCurrentShieldValues()[1]/localUser.GetEquipped("Aux2").getPowerShield(playerClass),1,1);
                txtAuxShield2.text = localUser.GetEquipped("Aux2").getCurrentShieldValues()[1]+"/"+localUser.GetEquipped("Aux2").getPowerShield(playerClass);
                imgAuxShield2.color = new Color(.7f,.7f,.7f,1);
            }
            if (localUser.GetEquipped("Aux2").getPowerShield(playerClass) == 0 && localUser.GetEquipped("Aux2").getShield(playerClass, 0) == 0)
                imgAuxShield2.transform.parent.gameObject.SetActive(false);
        } else btnAux2.image.sprite = empty;
        if (localUser.GetEquipped("Aux3") != null){
            btnAux3.image.sprite = localUser.GetEquipped("Aux3").Image();
            if (localUser.GetEquipped("Aux3").getShield(playerClass, enemyTier) > 0){
                imgAuxShield3.transform.parent.gameObject.SetActive(true);
                imgAuxShield3.transform.localScale = new Vector3((float)localUser.GetEquipped("Aux3").getCurrentShieldValues()[0]/localUser.GetEquipped("Aux3").getShield(playerClass, enemyTier),1,1);
                txtAuxShield3.text = localUser.GetEquipped("Aux3").getCurrentShieldValues()[0]+"/"+localUser.GetEquipped("Aux3").getShield(playerClass, enemyTier);
                imgAuxShield3.color = Color.cyan;
            }
            if (localUser.GetEquipped("Aux3").getPowerShield(playerClass) > 0){
                imgAuxShield3.transform.parent.gameObject.SetActive(true);
                imgAuxShield3.transform.localScale = new Vector3((float)localUser.GetEquipped("Aux3").getCurrentShieldValues()[1]/localUser.GetEquipped("Aux3").getPowerShield(playerClass),1,1);
                txtAuxShield3.text = localUser.GetEquipped("Aux3").getCurrentShieldValues()[1]+"/"+localUser.GetEquipped("Aux3").getPowerShield(playerClass);
                imgAuxShield3.color = new Color(.7f,.7f,.7f,1);
            }
            if (localUser.GetEquipped("Aux3").getPowerShield(playerClass) == 0 && localUser.GetEquipped("Aux3").getShield(playerClass, 0) == 0)
                imgAuxShield3.transform.parent.gameObject.SetActive(false);
        } else btnAux3.image.sprite = empty;
    }    
    void ReloadMonster(){        
        if (monster == null){
            txtMonsterHealth.text = "NA";
            txtMonsterAbilityShields.text = "NA";
            txtMonsterShields.text = "NA";
            imgMonsterHealth.transform.localScale = new Vector3(0,1,1);
            imgMonsterAbilityShields.transform.localScale = new Vector3(0,1,1);
            imgMonsterShields.transform.localScale = new Vector3(0,1,1);
        } else {
            //txtMonsterHealth.text = 
        }

    }
    void displayEquipItemMenu(string equipSlot){
        equippingSlot = equipSlot;
        if (equipSlot.Contains("Aux")) equipSlot = "Auxiliary";
        viewEquipOption = localUser.getEquipmentBySlot(equipSlot);
        EquipOptionOffset = 0;
        pnlEquipOptionView.SetActive(true);
        ReloadEquipOptionView();
    }
    void ChooseVersitile(){
        //If slot is Main and weapon is two/main versitile, give option of which to use.
        if (itemToEquip.GetEquipType()[0].CompareTo("Main")==0 && 
            itemToEquip.getVersitile() != null &&
            itemToEquip.getVersitile().CompareTo("Two")==0){
            pnlVersitile.SetActive(true);
        } else {//otherwise, equip automatically based on selected/default slot.
            if (itemToEquip.GetEquipType()[0].CompareTo("Two")==0) equippingSlot = "Two";
            EquipItem();
        }
    }
    void EquipItem(){
        Debug.Log("Equipping "+itemToEquip.getName()+" to slot "+equippingSlot);
        //Prevent equipping the same equipment in multiple slots
        if (localUser.getSlot(itemToEquip) != null)
            localUser.UnEquip(localUser.getSlot(itemToEquip)); //
        localUser.Equip(equippingSlot, itemToEquip);
        equippingSlot = null;
        itemToEquip = null;
        pnlEquipOptionView.SetActive(false);
        ReloadEquipped();
    }
    void UseTome(int num){
        if (viewArsenal[num].getName().Contains("Tome")){
            activeTome = viewArsenal[num];
            pnlTomeUse.SetActive(true);
        }
    }
    int CalculateDamage(){
        int shld = 0;
        int pshld = 0;
        int evade = 0;
        int armor = 0;
        foreach (Ability a in defenses){
            if (a.getCurrentDefenses()[0] == 0){
                shld += a.getCurrentDefenses()[1];
            } else pshld += a.getCurrentDefenses()[1];
            evade += a.getEvade();
        }
        foreach (Equipment e in localUser.GetEquipped()){
            if (e != null){
                shld += e.getCurrentShieldValues()[0];
                pshld += e.getCurrentShieldValues()[1];
                armor += e.getArmor(playerClass,enemyTier);
                evade += e.getEvade(playerClass,enemyTier);
            }
        }
        int tempsb = pendingShieldBreak;
        int tempdmg = pendingDamage;
        if (pendingTag.CompareTo("HANDCOUNTREDUCE")==0) tempdmg -= inHand.Count;
        shld -= tempsb; if (shld < 0) shld = 0;
        if (pendingHoming == false && pendingType.CompareTo("Collateral")!=0){
            tempdmg -= evade;
        }
        if (pendingIgnore == false){
            tempdmg -= shld;
            tempdmg -= pshld;
        }
        if (pendingPierce == false && pendingType.CompareTo("Collateral")!=0){
            tempdmg -= armor;
        }
        if (tempdmg < 0) tempdmg = 0;
        return tempdmg;
    }
}
