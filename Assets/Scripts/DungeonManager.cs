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
    public Image imgModShield3,imgModShield2,imgModShield1;
    public Text txtModShield3,txtModShield2,txtModShield1;
    public Button btnMModLeft;
    public Button btnMModRight;
    //Damage confirmation elements
    public GameObject pnlConfirmDamage;
    public Button btnConfirmDamage;
    public Text txtDamageInfo;
    //Trade elements
    public Button btnTradeWithP2, btnTradeWithP3, btnTradeWithP4;
    //Boss Lobby
    public GameObject pnlBossLobby;
    public Text txtBLP1Name, txtBLP2Name, txtBLP3Name, txtBLP4Name;
    public Button btnBLJoin, btnBLPass, btnBLReady;
    // Boss Minions/Gems
    public GameObject pnlMinions, pnlGems;
    public Image imgMinions, imgGems;
    public Text txtMinions, txtGems;
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
    //Claimed Aspiration Viewer
    public GameObject pnlAspirationView;
    public Button btnAspirationView, btnAspirationCancel, btnAspirationLeftScroll, btnAspirationRightScroll,
            btnAspirationView1, btnAspirationView2, btnAspirationView3, btnAspirationView4;
    int AspirationViewOffset = 0;
    //Trophy Viewer
    public GameObject pnlTrophyView;
    public Button btnTrophyView, btnTrophyCancel, btnTrophyLeftScroll, btnTrophyRightScroll,
            btnTrophy1, btnTrophy2, btnTrophy3;
    int TrophyOffset = 0;
    //Aspirations
    public Button btnAspiration1, btnAsp1ScrollUp, btnAsp1ScrollDown,
                btnAspiration2, btnAsp2ScrollUp, btnAsp2ScrollDown,
                btnAspiration3, btnAsp3ScrollUp, btnAsp3ScrollDown,
                btnAspiration4, btnAsp4ScrollUp, btnAsp4ScrollDown,
                btnAspirationClaim, btnAspirationScore, btnCancelClaimScore,
                btnAspirationClaimSkip;
    public GameObject pnlAspirationOptions;
    public Text txtSelectedAspiration;
    int[] aspirationOffset = new int[]{0,0,0,0};
    string[] aspirationClaimed = new string[]{"","","",""};
    bool claimTurn = false;
    int aspirationChoice = -1;
    bool[] conditionsMet = new bool[]{false,false,false,false};

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
    public GameObject pnlClassDiscard;
    public Button btnCD1, btnCD2, btnCD3, btnCD4, 
            btnCDLeft, btnCDRight, btnCDExit;
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

    //Prevent Panel elements
    public GameObject pnlPrevent;
    public Text txtPreventP1, txtPreventP2, txtPreventP3, txtPreventP4, txtPreventAvailable,
            txtPreventAmountP1, txtPreventAmountP2, txtPreventAmountP3, txtPreventAmountP4;
    public Button btnPreventConfirm, btnP1L, btnP1R, btnP2L, btnP2R,
             btnP3L, btnP3R, btnP4L, btnP4R;
    int[] assignedPrevention = new int[]{0,0,0,0};

    //Flee panel elements
    public GameObject pnlFlee;
    public Button btnFlee, btnDiscardFlee;

    //Versitile Panel
    public GameObject pnlVersitile;
    public Button btnChooseMainHand, btnChooseTwoHand;
    //Tribute Panels
    public GameObject pnlTributeGold, pnlTributeTrophy, pnlTributeAbility, pnlTributeEquipment; 
    //Gold
    public Button btnTributeGoldConfirm, btnTributeGoldCancel;
    public Text txtTributeMessage;
    //Trophy
    public Button btnTributeTrophyCancel,
            btnTributeTrophy1, btnTributeTrophy2, btnTributeTrophy3,
             btnTributeTrophyLeftScroll, btnTributeTrophyRightScroll;
    //Equipment
    public Button btnTributeEquipmentCancel,
            btnTributeEquipment1, btnTributeEquipment2, btnTributeEquipment3, btnTributeEquipment4,
             btnTributeEquipmentLeftScroll, btnTributeEquipmentRightScroll;
    //Ability
    public Button btnTributeAbilityCancel,
            btnTributeAbility1, btnTributeAbility2, btnTributeAbility3, btnTributeAbility4,
             btnTributeAbilityLeftScroll, btnTributeAbilityRightScroll;
    //Trade Menus
    public GameObject pnlTradeOffer, pnlTradeActive;
    public Button btnTradeP2, btnTradeP3, btnTradeP4,
            btnTradeOfferAccept, btnTradeOfferReject, btnTradeOfferCancel,
            btnTradeActiveOffer, btnTradeActiveAccept, btnTradeActiveCancel, 
            btnTradeAspiration1, btnTradeAspiration2, btnTradeAbility1, btnTradeAbility2, 
            btnTradeItem1, btnTradeItem2, btnTradeTrophy1, btnTradeTrophy2, 
            btnTradeGoldIncrement, btnTradeGoldDecrement, btnTradeVPIncrement, btnTradeVPDecrement;
    public Text txtTradeOfferMessage, txtTradeLocalName, txtTradeOtherName,
            txtTradeAspiration1, txtTradeAspiration2, txtTradeAbility1, txtTradeAbility2, 
            txtTradeItem1, txtTradeItem2, txtTradeTrophy1, txtTradeTrophy2, 
            txtTradeGoldLocal, txtTradeGoldOther, txtTradeVPLocal, txtTradeVPOther;
    //Trade Variables
    int tradeGoldPlayer = 0, tradeGoldOther = 0, tradeVPPlayer = 0, tradeVPOther = 0;
    Aspiration tradeAspiration1Player = null, tradeAspiration2Player = null;
    Ability tradeAbility1Player = null, tradeAbility2Player = null;
    Monster tradeTrophy1Player = null, tradeTrophy2Player = null;
    Equipment tradeItem1Player = null, tradeItem2Player = null;
    string tradeAspiration1Other = null, tradeAspiration2Other = null,
            tradeAbility1Other = null, tradeAbility2Other = null,
            tradeTrophy1Other = null, tradeTrophy2Other = null,
            tradeItem1Other = null, tradeItem2Other = null;
    Player tradePartner = null;
    bool tradeAcceptedPlayer = false, tradeAcceptedOther = false;
    //TradeAbilitySelect
    public GameObject pnlTradeAbilitySelectView;
    public Button btnTradeAbilitySelectCancel, btnTradeAbilitySelectLeftScroll, btnTradeAbilitySelectRightScroll,
            btnTradeAbilitySelect1, btnTradeAbilitySelect2, btnTradeAbilitySelect3, btnTradeAbilitySelect4, btnTradeAbilitySelect5, btnTradeAbilitySelect6;
    int TradeAbilitySelectOffset = 0;
    List<Ability> viewTradeAbilitySelect;
    //TradeItemSelect
    public GameObject pnlTradeItemSelectView;
    public Button btnTradeItemSelectCancel, btnTradeItemSelectLeftScroll, btnTradeItemSelectRightScroll,
            btnTradeItemSelect1, btnTradeItemSelect2, btnTradeItemSelect3, btnTradeItemSelect4, btnTradeItemSelect5, btnTradeItemSelect6;
    int TradeItemSelectOffset = 0;
    List<Equipment> viewTradeItemSelect;
    //TradeAspirationSelect Viewer
    public GameObject pnlTradeAspirationSelectView;
    public Button btnTradeAspirationSelectCancel, btnTradeAspirationSelectLeftScroll, btnTradeAspirationSelectRightScroll,
            btnTradeAspirationSelectView1, btnTradeAspirationSelectView2, btnTradeAspirationSelectView3, btnTradeAspirationSelectView4;
    int TradeAspirationSelectViewOffset = 0;
    List<Aspiration> viewTradeAspirationSelect;
    //TradeTrophySelect Viewer
    public GameObject pnlTradeTrophySelectView;
    public Button btnTradeTrophySelectCancel, btnTradeTrophySelectLeftScroll, btnTradeTrophySelectRightScroll,
            btnTradeTrophySelect1, btnTradeTrophySelect2, btnTradeTrophySelect3;
    int TradeTrophySelectOffset = 0;
    List<Monster> viewTradeTrophySelect;

    //Rewards panel
    public Button btnRewardCard1, btnRewardCard2, btnRewardCard3, btnRewardCard4, 
            btnRewardCard5, btnRewardCard6, btnRewardCard7;
    public Toggle tglP1C1, tglP1C2, tglP1C3, tglP1C4, tglP1C5, tglP1C6, tglP1C7,
            tglP2C1, tglP2C2, tglP2C3, tglP2C4, tglP2C5, tglP2C6, tglP2C7,
            tglP3C1, tglP3C2, tglP3C3, tglP3C4, tglP3C5, tglP3C6, tglP3C7,
            tglP4C1, tglP4C2, tglP4C3, tglP4C4, tglP4C5, tglP4C6, tglP4C7;
    public GameObject pnlRewardsDistro, pnlRewardTgl1, pnlRewardTgl2, pnlRewardTgl3, 
            pnlRewardTgl4, pnlRewardTgl5, pnlRewardTgl6, pnlRewardTgl7;
    public Text txtRewardP1Name, txtRewardP2Name, txtRewardP3Name, txtRewardP4Name, 
            txtRewardP1Total, txtRewardP2Total, txtRewardP3Total, txtRewardP4Total;
    List<Equipment> RewardDrops = new List<Equipment>();
    int[] rewardCount = new int[4];
    string[] rewardsAssignment = new string[]{"","","","","","",""}; //for writing to server/non-lead players.
    //Non-UI variables
    ValueStorage vs;
    List<Player> players;
    Player localUser;
    List<Player> combatants;
    //Monster specific variables here
    Monster monster = null;
    int MModOffset = 0;

    //boolean values for the different steps
    bool lobbyStep = false;
    bool combatStep = false;
    bool rewardStep = false;
    int tributeAbilityOffset = 0;
    int tributeEquipmentOffset = 0;
    int tributeTrophyOffset = 0;

    //Lists for abilities in play
    List<Ability> inPlay = new List<Ability>();
    List<Ability> CDCards = new List<Ability>();
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
    //Vs for pending attacks
    int pendingShieldBreak = 0;
    int pendingDamage = 0;
    bool pendingHoming = false;
    bool pendingPierce = false;
    bool pendingIgnore = false;
    string pendingType = null;
    string pendingTag = null;
    //Vs for rewards
    int[] rewardGold = new int[4];
    int[] rewardTreasure = new int[4];
    int[] rewardVP = new int[4];
    int[] rewardTrophy = new int[4];
    int[] rewardRoll = new int[4];
    //Vs for tribute
    Monster trophyTribute = null;
    Equipment itemTribute = null;
    Ability abilityTribute = null;
    List<Monster> tributeTrophies = null;
    List<Equipment> tributeItems = null;
    List<Ability> tributeAbilities = null;
    //cards played conditions
    int cardsPlayed = 0;
    int spellsPlayed = 0;
    int attacksPlayed = 0;
    int defensesPlayed = 0;
    int techniquesPlayed = 0;
    int cardsPlayedHigh = 0;
    int spellsPlayedHigh = 0;
    int attacksPlayedHigh = 0;
    int defensesPlayedHigh = 0;
    int techniquesPlayedHigh = 0;
    int typesPlayedHigh = 0;
    List<string> typesPlayed = new List<string>();
    int damageDealt = 0;
    int extraDrawn = 0;
    int damagePrevented = 0;
    int damageDealtHigh = 0;
    int extraDrawnHigh = 0;
    int damagePreventedHigh = 0;
    int remainingShields = 0;
    int remainingPowerShields = 0;
    int remainingEvade = 0;
    bool noTurnForMonster = true;
    string monsterType = null;
    int monsterTier = 0;
    bool localAttack = false;
    bool aspirationsPending = false;
    bool readyToShop = false;
    int pendingSlot = 0;
    bool monsterAttacking = false;
    int CDOffset = 0;
    int[] damageBeingDealt = new int[]{0,0,0,0};
    int clericDamagePrevent = 0;
    bool[] joiningBoss = new bool[]{false,false,false,false};
    bool[] passingBoss = new bool[]{false,false,false,false};
    bool bossPhase = false;

    // Start is called before the first frame update
    void Start()
    {
        vs = GameObject.Find("NetworkManager").GetComponent<ValueStorage>();
        players = vs.GetPlayers();
        localUser = vs.getLocalPlayer();
        combatants = new List<Player>();
        if (localUser.GetPlayerClass() != null)
            playerClass = localUser.GetPlayerClass().getName();
        if (playerClass != null){
            pnlClass.SetActive(true);
            btnClassAbility.image.sprite = localUser.GetPlayerClass().Image();
        }

        //Add listeners to ALL necessary fields here.
        //Listeners for lobby
        tglP2.onValueChanged.AddListener(delegate{PlayerParticipationToggle(1, tglP2.isOn);});
        tglP3.onValueChanged.AddListener(delegate{PlayerParticipationToggle(2, tglP3.isOn);});
        tglP4.onValueChanged.AddListener(delegate{PlayerParticipationToggle(3, tglP4.isOn);});
        btnSubmit.onClick.AddListener(delegate{SendChat(infMessage.text);});
        btnLobbyReady.onClick.AddListener(ReadyUp);
        btnTurnComplete.onClick.AddListener(TurnComplete);
        btnLobbyLoot.onClick.AddListener(LootNRun);
        btnRunAway.onClick.AddListener(RunAway);
        //Listeners for rewards portion of Lobby
        btnP2GL.onClick.AddListener(delegate{if (tglP2.isOn && rewardGold[1] > 0){rewardGold[1]--;rewardGold[0]++;sendRewardsDistro();}});
        btnP2GR.onClick.AddListener(delegate{if (tglP2.isOn && rewardGold[0] > 0){rewardGold[0]--;rewardGold[1]++;sendRewardsDistro();}});
        btnP2TrL.onClick.AddListener(delegate{if (tglP2.isOn && rewardTreasure[1] > 0){rewardTreasure[1]--;rewardTreasure[0]++;sendRewardsDistro();}});
        btnP2TrR.onClick.AddListener(delegate{if (tglP2.isOn && rewardTreasure[0] > 0){rewardTreasure[0]--;rewardTreasure[1]++;sendRewardsDistro();}});
        btnP2TpL.onClick.AddListener(delegate{if (tglP2.isOn && rewardTrophy[1] > 0){rewardTrophy[1]--;rewardTrophy[0]++;sendRewardsDistro();}});
        btnP2TpR.onClick.AddListener(delegate{if (tglP2.isOn && rewardTrophy[0] > 0){rewardTrophy[0]--;rewardTrophy[1]++;sendRewardsDistro();}});
        btnP2RL.onClick.AddListener(delegate{if (tglP2.isOn && rewardRoll[1] > 0){rewardRoll[1]--;rewardRoll[0]++;sendRewardsDistro();}});
        btnP2RR.onClick.AddListener(delegate{if (tglP2.isOn && rewardRoll[0] > 0){rewardRoll[0]--;rewardRoll[1]++;sendRewardsDistro();}});
        btnP2VL.onClick.AddListener(delegate{if (tglP2.isOn && rewardVP[1] > 0){rewardVP[1]--;rewardVP[0]++;sendRewardsDistro();}});
        btnP2VR.onClick.AddListener(delegate{if (tglP2.isOn && rewardVP[0] > 0){rewardVP[0]--;rewardVP[1]++;sendRewardsDistro();}});
        btnP3GL.onClick.AddListener(delegate{if (tglP3.isOn && rewardGold[2] > 0){rewardGold[2]--;rewardGold[0]++;sendRewardsDistro();}});
        btnP3GR.onClick.AddListener(delegate{if (tglP3.isOn && rewardGold[0] > 0){rewardGold[0]--;rewardGold[2]++;sendRewardsDistro();}});
        btnP3TrL.onClick.AddListener(delegate{if (tglP3.isOn && rewardTreasure[2] > 0){rewardTreasure[2]--;rewardTreasure[0]++;sendRewardsDistro();}});
        btnP3TrR.onClick.AddListener(delegate{if (tglP3.isOn && rewardTreasure[0] > 0){rewardTreasure[0]--;rewardTreasure[2]++;sendRewardsDistro();}});
        btnP3TpL.onClick.AddListener(delegate{if (tglP3.isOn && rewardTrophy[2] > 0){rewardTrophy[2]--;rewardTrophy[0]++;sendRewardsDistro();}});
        btnP3TpR.onClick.AddListener(delegate{if (tglP3.isOn && rewardTrophy[0] > 0){rewardTrophy[0]--;rewardTrophy[2]++;sendRewardsDistro();}});
        btnP3RL.onClick.AddListener(delegate{if (tglP3.isOn && rewardRoll[2] > 0){rewardRoll[2]--;rewardRoll[0]++;sendRewardsDistro();}});
        btnP3RR.onClick.AddListener(delegate{if (tglP3.isOn && rewardRoll[0] > 0){rewardRoll[0]--;rewardRoll[2]++;sendRewardsDistro();}});
        btnP3VL.onClick.AddListener(delegate{if (tglP3.isOn && rewardVP[2] > 0){rewardVP[2]--;rewardVP[0]++;sendRewardsDistro();}});
        btnP3VR.onClick.AddListener(delegate{if (tglP3.isOn && rewardVP[0] > 0){rewardVP[0]--;rewardVP[2]++;sendRewardsDistro();}});
        btnP4GL.onClick.AddListener(delegate{if (tglP4.isOn && rewardGold[3] > 0){rewardGold[3]--;rewardGold[0]++;sendRewardsDistro();}});
        btnP4GR.onClick.AddListener(delegate{if (tglP4.isOn && rewardGold[0] > 0){rewardGold[0]--;rewardGold[3]++;sendRewardsDistro();}});
        btnP4TrL.onClick.AddListener(delegate{if (tglP4.isOn && rewardTreasure[3] > 0){rewardTreasure[3]--;rewardTreasure[0]++;sendRewardsDistro();}});
        btnP4TrR.onClick.AddListener(delegate{if (tglP4.isOn && rewardTreasure[0] > 0){rewardTreasure[0]--;rewardTreasure[3]++;sendRewardsDistro();}});
        btnP4TpL.onClick.AddListener(delegate{if (tglP4.isOn && rewardTrophy[3] > 0){rewardTrophy[3]--;rewardTrophy[0]++;sendRewardsDistro();}});
        btnP4TpR.onClick.AddListener(delegate{if (tglP4.isOn && rewardTrophy[0] > 0){rewardTrophy[0]--;rewardTrophy[3]++;sendRewardsDistro();}});
        btnP4RL.onClick.AddListener(delegate{if (tglP4.isOn && rewardRoll[3] > 0){rewardRoll[3]--;rewardRoll[0]++;sendRewardsDistro();}});
        btnP4RR.onClick.AddListener(delegate{if (tglP4.isOn && rewardRoll[0] > 0){rewardRoll[0]--;rewardRoll[3]++;sendRewardsDistro();}});
        btnP4VL.onClick.AddListener(delegate{if (tglP4.isOn && rewardVP[3] > 0){rewardVP[3]--;rewardVP[0]++;sendRewardsDistro();}});
        btnP4VR.onClick.AddListener(delegate{if (tglP4.isOn && rewardVP[0] > 0){rewardVP[0]--;rewardVP[3]++;sendRewardsDistro();}});
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
        //Trade
        btnTradeP2.onClick.AddListener(delegate{tradePartner = players[1]; 
            pnlTradeOffer.SetActive(true);
            btnTradeOfferAccept.gameObject.SetActive(false);
            btnTradeOfferReject.gameObject.SetActive(false);
            btnTradeOfferCancel.gameObject.SetActive(true);
            txtTradeOfferMessage.text = "Trade Request sent to "+tradePartner.GetName();
            localUser.Write("*TRADEREQUEST,"+tradePartner.GetName()+","+localUser.GetName());
        });
        btnTradeP3.onClick.AddListener(delegate{tradePartner = players[2]; 
            pnlTradeOffer.SetActive(true);
            btnTradeOfferAccept.gameObject.SetActive(false);
            btnTradeOfferReject.gameObject.SetActive(false);
            btnTradeOfferCancel.gameObject.SetActive(true);
            txtTradeOfferMessage.text = "Trade Request sent to "+tradePartner.GetName();
            localUser.Write("*TRADEREQUEST,"+tradePartner.GetName()+","+localUser.GetName());
        });
        btnTradeP4.onClick.AddListener(delegate{tradePartner = players[3]; 
            pnlTradeOffer.SetActive(true);
            btnTradeOfferAccept.gameObject.SetActive(false);
            btnTradeOfferReject.gameObject.SetActive(false);
            btnTradeOfferCancel.gameObject.SetActive(true);
            txtTradeOfferMessage.text = "Trade Request sent to "+tradePartner.GetName();
            localUser.Write("*TRADEREQUEST,"+tradePartner.GetName()+","+localUser.GetName());
        });
        btnTradeOfferCancel.onClick.AddListener(delegate{
            localUser.Write("*TRADECANCEL,"+tradePartner.GetName());
            tradePartner = null; 
            pnlTradeOffer.SetActive(false);
        });
        btnTradeOfferReject.onClick.AddListener(delegate{
            localUser.Write("*TRADECANCEL,"+tradePartner.GetName());
            tradePartner = null; 
            pnlTradeOffer.SetActive(false);
        });
        btnTradeOfferAccept.onClick.AddListener(delegate{
            localUser.Write("*ACCEPTTRADEREQUEST,"+tradePartner.GetName());
            pnlTradeOffer.SetActive(false);
            pnlTradeActive.SetActive(true);
            ReloadTradeMenu();
        });
        btnTradeActiveAccept.onClick.AddListener(delegate{
            localUser.Write("*TRADEACCEPT,"+tradePartner.GetName());
            tradeAcceptedPlayer = true;
            if (tradeAcceptedOther){
                CompleteTrade();
            }
        });
        btnTradeActiveOffer.onClick.AddListener(delegate{
            tradeAcceptedPlayer = false;
            localUser.Write("*TRADEUNACCEPT,"+tradePartner.GetName());
            //Gold,vp,ability,item,aspiration,trophy
            localUser.Write("*TRADEOFFER,"+tradePartner.GetName()+","+tradeGoldPlayer+","+tradeVPPlayer+","+
                (tradeAbility1Player!=null?tradeAbility1Player.getName():"") +","+
                (tradeAbility2Player!=null?tradeAbility2Player.getName():"") +","+
                (tradeItem1Player!=null?tradeItem1Player.getName():"") +","+
                (tradeItem2Player!=null?tradeItem2Player.getName():"") +","+
                (tradeAspiration1Player!=null?tradeAspiration1Player.GetName():"") +","+
                (tradeAspiration2Player!=null?tradeAspiration2Player.GetName():"") +","+
                (tradeTrophy1Player!=null?tradeTrophy1Player.GetName():"") +","+
                (tradeTrophy2Player!=null?tradeTrophy2Player.GetName():""));
        });
        btnTradeActiveCancel.onClick.AddListener(delegate{
            localUser.Write("*TRADECANCEL,"+tradePartner.GetName());
            tradeAcceptedPlayer = false;
            tradePartner = null; 
            pnlTradeActive.SetActive(false);
            ResetTrade();
        });
        btnTradeGoldIncrement.onClick.AddListener(delegate{tradeGoldPlayer++;
            tradeAcceptedPlayer = false;
            localUser.Write("*TRADEUNACCEPT,"+tradePartner.GetName());ReloadTradeMenu();});
        btnTradeGoldDecrement.onClick.AddListener(delegate{tradeGoldPlayer--;
            tradeAcceptedPlayer = false;
            localUser.Write("*TRADEUNACCEPT,"+tradePartner.GetName());ReloadTradeMenu();});
        btnTradeVPIncrement.onClick.AddListener(delegate{tradeVPPlayer++;
            tradeAcceptedPlayer = false;
            localUser.Write("*TRADEUNACCEPT,"+tradePartner.GetName());ReloadTradeMenu();});
        btnTradeVPDecrement.onClick.AddListener(delegate{tradeVPPlayer--;
            tradeAcceptedPlayer = false;
            localUser.Write("*TRADEUNACCEPT,"+tradePartner.GetName());ReloadTradeMenu();});
        btnTradeAbility1.onClick.AddListener(delegate{
            tradeAcceptedPlayer = false;
            localUser.Write("*TRADEUNACCEPT,"+tradePartner.GetName());
            pendingSlot = 1;
            TradeAbilitySelectOffset = 0;
            pnlTradeAbilitySelectView.SetActive(true);
            ReloadTradeAbilities();
        });
        btnTradeAbility2.onClick.AddListener(delegate{
            tradeAcceptedPlayer = false;
            localUser.Write("*TRADEUNACCEPT,"+tradePartner.GetName());
            localUser.Write("*TRADEUNACCEPT,"+tradePartner.GetName());
            pendingSlot = 2;
            TradeAbilitySelectOffset = 0;
            pnlTradeAbilitySelectView.SetActive(true);
            ReloadTradeAbilities();
        });
        btnTradeItem1.onClick.AddListener(delegate{
            tradeAcceptedPlayer = false;
            localUser.Write("*TRADEUNACCEPT,"+tradePartner.GetName());
            pendingSlot = 1;
            TradeItemSelectOffset = 0;
            pnlTradeItemSelectView.SetActive(true);
            ReloadTradeItems();
        });
        btnTradeItem2.onClick.AddListener(delegate{
            tradeAcceptedPlayer = false;
            localUser.Write("*TRADEUNACCEPT,"+tradePartner.GetName());
            pendingSlot = 2;
            TradeItemSelectOffset = 0;
            pnlTradeItemSelectView.SetActive(true);
            ReloadTradeItems();
        });
        btnTradeTrophy1.onClick.AddListener(delegate{
            tradeAcceptedPlayer = false;
            localUser.Write("*TRADEUNACCEPT,"+tradePartner.GetName());
            pendingSlot = 1;
            TradeTrophySelectOffset = 0;
            pnlTradeTrophySelectView.SetActive(true);
            ReloadTradeTrophies();
        });
        btnTradeTrophy2.onClick.AddListener(delegate{
            tradeAcceptedPlayer = false;
            localUser.Write("*TRADEUNACCEPT,"+tradePartner.GetName());
            pendingSlot = 2;
            TradeTrophySelectOffset = 0;
            pnlTradeTrophySelectView.SetActive(true);
            ReloadTradeTrophies();
        });
        btnTradeAspiration1.onClick.AddListener(delegate{
            tradeAcceptedPlayer = false;
            localUser.Write("*TRADEUNACCEPT,"+tradePartner.GetName());
            pendingSlot = 1;
            TradeAspirationSelectViewOffset = 0;
            pnlTradeAspirationSelectView.SetActive(true);
            ReloadTradeAspirations();
        });
        btnTradeAspiration2.onClick.AddListener(delegate{
            tradeAcceptedPlayer = false;
            localUser.Write("*TRADEUNACCEPT,"+tradePartner.GetName());
            pendingSlot = 2;
            TradeAspirationSelectViewOffset = 0;
            pnlTradeAspirationSelectView.SetActive(true);
            ReloadTradeAspirations();
        });
        btnTradeAbilitySelect1.onClick.AddListener(delegate{
            if (pendingSlot == 1) tradeAbility1Player = viewTradeAbilitySelect[0+TradeAbilitySelectOffset];
            if (pendingSlot == 2) tradeAbility2Player = viewTradeAbilitySelect[0+TradeAbilitySelectOffset];
            pendingSlot = 0;
            pnlTradeAbilitySelectView.SetActive(false);
            ReloadTradeMenu();
        });
        btnTradeAbilitySelect2.onClick.AddListener(delegate{
            if (pendingSlot == 1) tradeAbility1Player = viewTradeAbilitySelect[1+TradeAbilitySelectOffset];
            if (pendingSlot == 2) tradeAbility2Player = viewTradeAbilitySelect[1+TradeAbilitySelectOffset];
            pendingSlot = 0;
            pnlTradeAbilitySelectView.SetActive(false);
            ReloadTradeMenu();
        });
        btnTradeAbilitySelect3.onClick.AddListener(delegate{
            if (pendingSlot == 1) tradeAbility1Player = viewTradeAbilitySelect[2+TradeAbilitySelectOffset];
            if (pendingSlot == 2) tradeAbility2Player = viewTradeAbilitySelect[2+TradeAbilitySelectOffset];
            pendingSlot = 0;
            pnlTradeAbilitySelectView.SetActive(false);
            ReloadTradeMenu();
        });
        btnTradeAbilitySelect4.onClick.AddListener(delegate{
            if (pendingSlot == 1) tradeAbility1Player = viewTradeAbilitySelect[3+TradeAbilitySelectOffset];
            if (pendingSlot == 2) tradeAbility2Player = viewTradeAbilitySelect[3+TradeAbilitySelectOffset];
            pendingSlot = 0;
            pnlTradeAbilitySelectView.SetActive(false);
            ReloadTradeMenu();
        });
        btnTradeAbilitySelect5.onClick.AddListener(delegate{
            if (pendingSlot == 1) tradeAbility1Player = viewTradeAbilitySelect[4+TradeAbilitySelectOffset];
            if (pendingSlot == 2) tradeAbility2Player = viewTradeAbilitySelect[4+TradeAbilitySelectOffset];
            pendingSlot = 0;
            pnlTradeAbilitySelectView.SetActive(false);
            ReloadTradeMenu();
        });
        btnTradeAbilitySelect6.onClick.AddListener(delegate{
            if (pendingSlot == 1) tradeAbility1Player = viewTradeAbilitySelect[5+TradeAbilitySelectOffset];
            if (pendingSlot == 2) tradeAbility2Player = viewTradeAbilitySelect[5+TradeAbilitySelectOffset];
            pendingSlot = 0;
            pnlTradeAbilitySelectView.SetActive(false);
            ReloadTradeMenu();
        });
        btnTradeAbilitySelectLeftScroll.onClick.AddListener(delegate{TradeAbilitySelectOffset--;ReloadTradeAbilities();});
        btnTradeAbilitySelectRightScroll.onClick.AddListener(delegate{TradeAbilitySelectOffset++;ReloadTradeAbilities();});
        btnTradeAbilitySelectCancel.onClick.AddListener(delegate{
            pendingSlot = 0;
            pnlTradeAbilitySelectView.SetActive(false);
            ReloadTradeMenu();
        });
        btnTradeItemSelect1.onClick.AddListener(delegate{
            if (pendingSlot == 1) tradeItem1Player = viewTradeItemSelect[0+TradeItemSelectOffset];
            if (pendingSlot == 2) tradeItem2Player = viewTradeItemSelect[0+TradeItemSelectOffset];
            pendingSlot = 0;
            pnlTradeItemSelectView.SetActive(false);
            ReloadTradeMenu();
        });
        btnTradeItemSelect2.onClick.AddListener(delegate{
            if (pendingSlot == 1) tradeItem1Player = viewTradeItemSelect[1+TradeItemSelectOffset];
            if (pendingSlot == 2) tradeItem2Player = viewTradeItemSelect[1+TradeItemSelectOffset];
            pendingSlot = 0;
            pnlTradeItemSelectView.SetActive(false);
            ReloadTradeMenu();
        });
        btnTradeItemSelect3.onClick.AddListener(delegate{
            if (pendingSlot == 1) tradeItem1Player = viewTradeItemSelect[2+TradeItemSelectOffset];
            if (pendingSlot == 2) tradeItem2Player = viewTradeItemSelect[2+TradeItemSelectOffset];
            pendingSlot = 0;
            pnlTradeItemSelectView.SetActive(false);
            ReloadTradeMenu();
        });
        btnTradeItemSelect4.onClick.AddListener(delegate{
            if (pendingSlot == 1) tradeItem1Player = viewTradeItemSelect[3+TradeItemSelectOffset];
            if (pendingSlot == 2) tradeItem2Player = viewTradeItemSelect[3+TradeItemSelectOffset];
            pendingSlot = 0;
            pnlTradeItemSelectView.SetActive(false);
            ReloadTradeMenu();
        });
        btnTradeItemSelect5.onClick.AddListener(delegate{
            if (pendingSlot == 1) tradeItem1Player = viewTradeItemSelect[4+TradeItemSelectOffset];
            if (pendingSlot == 2) tradeItem2Player = viewTradeItemSelect[4+TradeItemSelectOffset];
            pendingSlot = 0;
            pnlTradeItemSelectView.SetActive(false);
            ReloadTradeMenu();
        });
        btnTradeItemSelect6.onClick.AddListener(delegate{
            if (pendingSlot == 1) tradeItem1Player = viewTradeItemSelect[5+TradeItemSelectOffset];
            if (pendingSlot == 2) tradeItem2Player = viewTradeItemSelect[5+TradeItemSelectOffset];
            pendingSlot = 0;
            pnlTradeItemSelectView.SetActive(false);
            ReloadTradeMenu();
        });
        btnTradeItemSelectLeftScroll.onClick.AddListener(delegate{TradeItemSelectOffset--;ReloadTradeItems();});
        btnTradeItemSelectRightScroll.onClick.AddListener(delegate{TradeItemSelectOffset++;ReloadTradeItems();});
        btnTradeItemSelectCancel.onClick.AddListener(delegate{
            pendingSlot = 0;
            pnlTradeItemSelectView.SetActive(false);
            ReloadTradeMenu();
        });
        btnTradeAspirationSelectView1.onClick.AddListener(delegate{
            if (pendingSlot == 1) tradeAspiration1Player = viewTradeAspirationSelect[0+TradeAspirationSelectViewOffset];
            if (pendingSlot == 2) tradeAspiration2Player = viewTradeAspirationSelect[0+TradeAspirationSelectViewOffset];
            pendingSlot = 0;
            pnlTradeAspirationSelectView.SetActive(false);
            ReloadTradeMenu();
        });
        btnTradeAspirationSelectView2.onClick.AddListener(delegate{
            if (pendingSlot == 1) tradeAspiration1Player = viewTradeAspirationSelect[1+TradeAspirationSelectViewOffset];
            if (pendingSlot == 2) tradeAspiration2Player = viewTradeAspirationSelect[1+TradeAspirationSelectViewOffset];
            pendingSlot = 0;
            pnlTradeAspirationSelectView.SetActive(false);
            ReloadTradeMenu();
        });
        btnTradeAspirationSelectView3.onClick.AddListener(delegate{
            if (pendingSlot == 1) tradeAspiration1Player = viewTradeAspirationSelect[2+TradeAspirationSelectViewOffset];
            if (pendingSlot == 2) tradeAspiration2Player = viewTradeAspirationSelect[2+TradeAspirationSelectViewOffset];
            pendingSlot = 0;
            pnlTradeAspirationSelectView.SetActive(false);
            ReloadTradeMenu();
        });
        btnTradeAspirationSelectView4.onClick.AddListener(delegate{
            if (pendingSlot == 1) tradeAspiration1Player = viewTradeAspirationSelect[3+TradeAspirationSelectViewOffset];
            if (pendingSlot == 2) tradeAspiration2Player = viewTradeAspirationSelect[3+TradeAspirationSelectViewOffset];
            pendingSlot = 0;
            pnlTradeAspirationSelectView.SetActive(false);
            ReloadTradeMenu();
        });
        btnTradeAspirationSelectLeftScroll.onClick.AddListener(delegate{TradeAspirationSelectViewOffset--;ReloadTradeAspirations();});
        btnTradeAspirationSelectRightScroll.onClick.AddListener(delegate{TradeAspirationSelectViewOffset++;ReloadTradeAspirations();});
        btnTradeAspirationSelectCancel.onClick.AddListener(delegate{
            pendingSlot = 0;
            pnlTradeAspirationSelectView.SetActive(false);
            ReloadTradeMenu();
        });
        btnTradeTrophySelect1.onClick.AddListener(delegate{
            if (pendingSlot == 1) tradeTrophy1Player = viewTradeTrophySelect[0+TradeTrophySelectOffset];
            if (pendingSlot == 2) tradeTrophy2Player = viewTradeTrophySelect[0+TradeTrophySelectOffset];
            pendingSlot = 0;
            pnlTradeTrophySelectView.SetActive(false);
            ReloadTradeMenu();
        });
        btnTradeTrophySelect2.onClick.AddListener(delegate{
            if (pendingSlot == 1) tradeTrophy1Player = viewTradeTrophySelect[1+TradeTrophySelectOffset];
            if (pendingSlot == 2) tradeTrophy2Player = viewTradeTrophySelect[1+TradeTrophySelectOffset];
            pendingSlot = 0;
            pnlTradeTrophySelectView.SetActive(false);
            ReloadTradeMenu();
        });
        btnTradeTrophySelect3.onClick.AddListener(delegate{
            if (pendingSlot == 1) tradeTrophy1Player = viewTradeTrophySelect[2+TradeTrophySelectOffset];
            if (pendingSlot == 2) tradeTrophy2Player = viewTradeTrophySelect[2+TradeTrophySelectOffset];
            pendingSlot = 0;
            pnlTradeTrophySelectView.SetActive(false);
            ReloadTradeMenu();
        });
        btnTradeTrophySelectLeftScroll.onClick.AddListener(delegate{TradeTrophySelectOffset--;ReloadTradeTrophies();});
        btnTradeTrophySelectRightScroll.onClick.AddListener(delegate{TradeTrophySelectOffset++;ReloadTradeTrophies();});
        btnTradeTrophySelectCancel.onClick.AddListener(delegate{
            pendingSlot = 0;
            pnlTradeTrophySelectView.SetActive(false);
            ReloadTradeMenu();
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
            if (localUser.Arsenal().Count - 6 == ArsenalOffset && ArsenalOffset > 0) ArsenalOffset--;
            localUser.Arsenal().Remove(activeTome);
            pnlTomeUse.SetActive(false); activeTome = null;
            ReloadArsenalView();
        });
        btnCancelAdd.onClick.AddListener(delegate{pnlTomeUse.SetActive(false); activeTome = null;});
        //Listeners for equipment swapping when not in combat, and equipment abilities when in combat
        //NOTE Equipment abilities not scheduled for implementation until week 8
        btnAux1.onClick.AddListener(delegate{
            if (combatStep == true && combatants.Contains(localUser))
                useEquipmentAbility("Aux1");
            else displayEquipItemMenu("Aux1");});
        btnAux2.onClick.AddListener(delegate{
            if (combatStep == true && combatants.Contains(localUser))
                useEquipmentAbility("Aux2");
            else displayEquipItemMenu("Aux2");});
        btnAux3.onClick.AddListener(delegate{
            if (combatStep == true && combatants.Contains(localUser))
                useEquipmentAbility("Aux3");
            else displayEquipItemMenu("Aux3");});
        btnEquipBody.onClick.AddListener(delegate{
            if (combatStep == true && combatants.Contains(localUser))
                useEquipmentAbility("Armor");
            else displayEquipItemMenu("Armor");});
        btnEquipMainHand.onClick.AddListener(delegate{
            if (combatStep == true && combatants.Contains(localUser))
                useEquipmentAbility("Main");
            else displayEquipItemMenu("Main");});
        btnEquipOffHand.onClick.AddListener(delegate{
            if (combatStep == true && combatants.Contains(localUser))
                useEquipmentAbility("Off");
            else displayEquipItemMenu("Off");});
        btnEquipExtra.onClick.AddListener(delegate{
            if (combatStep == true && combatants.Contains(localUser))
                useEquipmentAbility("Extra");
            else displayEquipItemMenu("Extra");});
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
        //Listener for confirming damage
        btnConfirmDamage.onClick.AddListener(delegate{localUser.Write("*CONFIRMDAMAGE");});
        //Listener for Mod left/right scrolling
        btnMModLeft.onClick.AddListener(delegate{MModOffset++;});
        btnMModRight.onClick.AddListener(delegate{MModOffset--;});
        //Listener for rewards distribution
        btnAccept.onClick.AddListener(AcceptRewards);
        tglP1C1.onValueChanged.AddListener(delegate{
            if (tglP1C1.isOn){if (localUser.IsLead())rewardChange(1,1,true);}
            else{if (localUser.IsLead())rewardChange(1,1,false);}});
        tglP1C2.onValueChanged.AddListener(delegate{
            if (tglP1C2.isOn){if (localUser.IsLead())rewardChange(1,2,true);}
            else{if (localUser.IsLead())rewardChange(1,2,false);}});
        tglP1C3.onValueChanged.AddListener(delegate{
            if (tglP1C3.isOn){if (localUser.IsLead())rewardChange(1,3,true);}
            else{if (localUser.IsLead())rewardChange(1,3,false);}});
        tglP1C4.onValueChanged.AddListener(delegate{
            if (tglP1C4.isOn){if (localUser.IsLead())rewardChange(1,4,true);}
            else{if (localUser.IsLead())rewardChange(1,4,false);}});
        tglP1C5.onValueChanged.AddListener(delegate{
            if (tglP1C5.isOn){if (localUser.IsLead())rewardChange(1,5,true);}
            else{if (localUser.IsLead())rewardChange(1,5,false);}});
        tglP1C6.onValueChanged.AddListener(delegate{
            if (tglP1C6.isOn){if (localUser.IsLead())rewardChange(1,6,true);}
            else{if (localUser.IsLead())rewardChange(1,6,false);}});
        tglP1C7.onValueChanged.AddListener(delegate{
            if (tglP1C7.isOn){if (localUser.IsLead())rewardChange(1,7,true);}
            else{if (localUser.IsLead())rewardChange(1,7,false);}});
        tglP2C1.onValueChanged.AddListener(delegate{
            if (tglP2C1.isOn){if (localUser.IsLead())rewardChange(2,1,true);}
            else{if (localUser.IsLead())rewardChange(2,1,false);}});
        tglP2C2.onValueChanged.AddListener(delegate{
            if (tglP2C2.isOn){if (localUser.IsLead())rewardChange(2,2,true);}
            else{if (localUser.IsLead())rewardChange(2,2,false);}});
        tglP2C3.onValueChanged.AddListener(delegate{
            if (tglP2C3.isOn){if (localUser.IsLead())rewardChange(2,3,true);}
            else{if (localUser.IsLead())rewardChange(2,3,false);}});
        tglP2C4.onValueChanged.AddListener(delegate{
            if (tglP2C4.isOn){if (localUser.IsLead())rewardChange(2,4,true);}
            else{if (localUser.IsLead())rewardChange(2,4,false);}});
        tglP2C5.onValueChanged.AddListener(delegate{
            if (tglP2C5.isOn){if (localUser.IsLead())rewardChange(2,5,true);}
            else{if (localUser.IsLead())rewardChange(2,5,false);}});
        tglP2C6.onValueChanged.AddListener(delegate{
            if (tglP2C6.isOn){if (localUser.IsLead())rewardChange(2,6,true);}
            else{if (localUser.IsLead())rewardChange(2,6,false);}});
        tglP2C7.onValueChanged.AddListener(delegate{
            if (tglP2C7.isOn){if (localUser.IsLead())rewardChange(2,7,true);}
            else{if (localUser.IsLead())rewardChange(2,7,false);}});
        tglP3C1.onValueChanged.AddListener(delegate{
            if (tglP3C1.isOn){if (localUser.IsLead())rewardChange(3,1,true);}
            else{if (localUser.IsLead())rewardChange(3,1,false);}});
        tglP3C2.onValueChanged.AddListener(delegate{
            if (tglP3C2.isOn){if (localUser.IsLead())rewardChange(3,2,true);}
            else{if (localUser.IsLead())rewardChange(3,2,false);}});
        tglP3C3.onValueChanged.AddListener(delegate{
            if (tglP3C3.isOn){if (localUser.IsLead())rewardChange(3,3,true);}
            else{if (localUser.IsLead())rewardChange(3,3,false);}});
        tglP3C4.onValueChanged.AddListener(delegate{
            if (tglP3C4.isOn){if (localUser.IsLead())rewardChange(3,4,true);}
            else{if (localUser.IsLead())rewardChange(3,4,false);}});
        tglP3C5.onValueChanged.AddListener(delegate{
            if (tglP3C5.isOn){if (localUser.IsLead())rewardChange(3,5,true);}
            else{if (localUser.IsLead())rewardChange(3,5,false);}});
        tglP3C6.onValueChanged.AddListener(delegate{
            if (tglP3C6.isOn){if (localUser.IsLead())rewardChange(3,6,true);}
            else{if (localUser.IsLead())rewardChange(3,6,false);}});
        tglP3C7.onValueChanged.AddListener(delegate{
            if (tglP3C7.isOn){if (localUser.IsLead())rewardChange(3,7,true);}
            else{if (localUser.IsLead())rewardChange(3,7,false);}});
        tglP4C1.onValueChanged.AddListener(delegate{
            if (tglP4C1.isOn){if (localUser.IsLead())rewardChange(4,1,true);}
            else{if (localUser.IsLead())rewardChange(4,1,false);}});
        tglP4C2.onValueChanged.AddListener(delegate{
            if (tglP4C2.isOn){if (localUser.IsLead())rewardChange(4,2,true);}
            else{if (localUser.IsLead())rewardChange(4,2,false);}});
        tglP4C3.onValueChanged.AddListener(delegate{
            if (tglP4C3.isOn){if (localUser.IsLead())rewardChange(4,3,true);}
            else{if (localUser.IsLead())rewardChange(4,3,false);}});
        tglP4C4.onValueChanged.AddListener(delegate{
            if (tglP4C4.isOn){if (localUser.IsLead())rewardChange(4,4,true);}
            else{if (localUser.IsLead())rewardChange(4,4,false);}});
        tglP4C5.onValueChanged.AddListener(delegate{
            if (tglP4C5.isOn){if (localUser.IsLead())rewardChange(4,5,true);}
            else{if (localUser.IsLead())rewardChange(4,5,false);}});
        tglP4C6.onValueChanged.AddListener(delegate{
            if (tglP4C6.isOn){if (localUser.IsLead())rewardChange(4,6,true);}
            else{if (localUser.IsLead())rewardChange(4,6,false);}});
        tglP4C7.onValueChanged.AddListener(delegate{
            if (tglP4C7.isOn){if (localUser.IsLead())rewardChange(4,7,true);}
            else{if (localUser.IsLead())rewardChange(4,7,false);}});
        //Browse Trophies
        btnTrophyView.onClick.AddListener(delegate{pnlTrophyView.SetActive(true);ReloadTrophyView();});
        btnTrophyCancel.onClick.AddListener(delegate{pnlTrophyView.SetActive(false);TrophyOffset=0;});
        btnTrophyLeftScroll.onClick.AddListener(delegate{TrophyOffset--;ReloadTrophyView();});
        btnTrophyRightScroll.onClick.AddListener(delegate{TrophyOffset++;ReloadTrophyView();});
        //Browse Aspirations
        btnAspirationView.onClick.AddListener(delegate{pnlAspirationView.SetActive(true);ReloadAspirationView();});
        btnAspirationCancel.onClick.AddListener(delegate{pnlAspirationView.SetActive(false);AspirationViewOffset=0;});
        btnAspirationLeftScroll.onClick.AddListener(delegate{AspirationViewOffset--;ReloadAspirationView();});
        btnAspirationRightScroll.onClick.AddListener(delegate{AspirationViewOffset++;ReloadAspirationView();});
        //Aspirations
        btnAsp1ScrollDown.onClick.AddListener(delegate{aspirationOffset[0]--;ReloadAspirations();});
        btnAsp1ScrollUp.onClick.AddListener(delegate{aspirationOffset[0]++;ReloadAspirations();});
        btnAsp2ScrollDown.onClick.AddListener(delegate{aspirationOffset[1]--;ReloadAspirations();});
        btnAsp2ScrollUp.onClick.AddListener(delegate{aspirationOffset[1]++;ReloadAspirations();});
        btnAsp3ScrollDown.onClick.AddListener(delegate{aspirationOffset[2]--;ReloadAspirations();});
        btnAsp3ScrollUp.onClick.AddListener(delegate{aspirationOffset[2]++;ReloadAspirations();});
        btnAsp4ScrollDown.onClick.AddListener(delegate{aspirationOffset[3]--;ReloadAspirations();});
        btnAsp4ScrollUp.onClick.AddListener(delegate{aspirationOffset[3]++;ReloadAspirations();});
        btnAspiration1.onClick.AddListener(delegate{if(claimTurn && conditionsMet[0]){
            pnlAspirationOptions.SetActive(true);
            if (vs.PeekAspiration(0,0).ScoreAmount() > 0) btnAspirationScore.gameObject.SetActive(true);
            else btnAspirationScore.gameObject.SetActive(false);
            if (aspirationClaimed[0].CompareTo("")==0) btnAspirationClaim.gameObject.SetActive(true);
            else btnAspirationClaim.gameObject.SetActive(false);
            txtSelectedAspiration.text = vs.PeekAspiration(0,0).GetName();
            aspirationChoice = 0;
        }});
        btnAspiration2.onClick.AddListener(delegate{if(claimTurn && conditionsMet[1]){
            pnlAspirationOptions.SetActive(true);
            if (vs.PeekAspiration(1,0).ScoreAmount() > 0) btnAspirationScore.gameObject.SetActive(true);
            else btnAspirationScore.gameObject.SetActive(false);
            if (aspirationClaimed[1].CompareTo("")==0) btnAspirationClaim.gameObject.SetActive(true);
            else btnAspirationClaim.gameObject.SetActive(false);
            txtSelectedAspiration.text = vs.PeekAspiration(1,0).GetName();
            aspirationChoice = 1;
        }});
        btnAspiration3.onClick.AddListener(delegate{if(claimTurn && conditionsMet[2]){
            pnlAspirationOptions.SetActive(true);
            if (vs.PeekAspiration(2,0).ScoreAmount() > 0) btnAspirationScore.gameObject.SetActive(true);
            else btnAspirationScore.gameObject.SetActive(false);
            if (aspirationClaimed[2].CompareTo("")==0) btnAspirationClaim.gameObject.SetActive(true);
            else btnAspirationClaim.gameObject.SetActive(false);
            txtSelectedAspiration.text = vs.PeekAspiration(2,0).GetName();
            aspirationChoice = 2;
        }});
        btnAspiration4.onClick.AddListener(delegate{if(claimTurn && conditionsMet[3]){
            pnlAspirationOptions.SetActive(true);
            if (vs.PeekAspiration(3,0).ScoreAmount() > 0) btnAspirationScore.gameObject.SetActive(true);
            else btnAspirationScore.gameObject.SetActive(false);
            if (aspirationClaimed[3].CompareTo("")==0) btnAspirationClaim.gameObject.SetActive(true);
            else btnAspirationClaim.gameObject.SetActive(false);
            txtSelectedAspiration.text = vs.PeekAspiration(3,0).GetName();
            aspirationChoice = 3;
        }});
        btnAspirationClaimSkip.onClick.AddListener(delegate{
            //Close menus and pass selection to next player
            btnAspirationClaimSkip.gameObject.SetActive(false);
            pnlAspirationOptions.SetActive(false);
            localUser.Write("*SKIP");
            claimTurn = false;
            aspirationChoice = -1;
        });
        btnAspirationClaim.onClick.AddListener(delegate{
            //If tribute, open menu for option to trade in, otherwise messages server of what you picked
            if (vs.PeekAspiration(aspirationChoice,0).IsTribute() != null){
                if (vs.PeekAspiration(aspirationChoice,0).IsTribute().CompareTo("Ability")==0){
                    pnlTributeAbility.SetActive(true);
                    tributeAbilityOffset = 0;
                    ReloadTributeAbility();
                } else 
                if (vs.PeekAspiration(aspirationChoice,0).IsTribute().CompareTo("Item")==0){
                    pnlTributeEquipment.SetActive(true);
                    tributeEquipmentOffset = 0;
                    ReloadTributeItem();
                } else 
                if (vs.PeekAspiration(aspirationChoice,0).IsTribute().CompareTo("Trophy")==0){
                    pnlTributeTrophy.SetActive(true);
                    tributeTrophyOffset = 0;
                    ReloadTributeTrophy();
                } else {
                    pnlTributeGold.SetActive(true);
                    txtTributeMessage.text = "Turn in "+vs.PeekAspiration(aspirationChoice,0).GoldTribute()+" Gold as Tribute for Aspiration?";
                }
            } else {
                btnAspirationClaimSkip.gameObject.SetActive(false);
                pnlAspirationOptions.SetActive(false);
                localUser.Write("*CLAIM,"+vs.PeekAspiration(aspirationChoice,0).GetName());
                claimTurn = false;
                aspirationChoice = -1;
            }
        });
        btnTributeAbilityCancel.onClick.AddListener(delegate{
            pnlTributeAbility.SetActive(false);
            pnlAspirationOptions.SetActive(false);
            aspirationChoice = -1;});
        btnTributeTrophyCancel.onClick.AddListener(delegate{
            pnlTributeTrophy.SetActive(false);
            pnlAspirationOptions.SetActive(false);
            aspirationChoice = -1;});
        btnTributeEquipmentCancel.onClick.AddListener(delegate{
            pnlTributeEquipment.SetActive(false);
            pnlAspirationOptions.SetActive(false);
            aspirationChoice = -1;});
        btnTributeGoldCancel.onClick.AddListener(delegate{
            pnlTributeGold.SetActive(false);
            if (itemTribute == null && abilityTribute == null && trophyTribute == null){
                pnlAspirationOptions.SetActive(false);
                aspirationChoice = -1;
            } else {
                itemTribute = null; 
                abilityTribute = null;
                trophyTribute = null;
            }
        });
        btnTributeGoldConfirm.onClick.AddListener(delegate{
            bool tributePaid = false;
            if(itemTribute != null){
                localUser.RemoveItem(itemTribute);
                pnlTributeEquipment.SetActive(false);
                pnlTributeGold.SetActive(false);
                tributePaid = true;
            } else if (abilityTribute != null){
                localUser.Deck().Remove(abilityTribute);
                pnlTributeAbility.SetActive(false);
                pnlTributeGold.SetActive(false);
                tributePaid = true;
            } else if (trophyTribute != null) {
                localUser.Trophies().Remove(trophyTribute);
                pnlTributeTrophy.SetActive(false);
                pnlTributeGold.SetActive(false);
                tributePaid = true;
            } else {
                if (localUser.getGold() >= vs.PeekAspiration(aspirationChoice,0).GoldTribute()){
                    localUser.changeGold(-vs.PeekAspiration(aspirationChoice,0).GoldTribute());
                    pnlTributeGold.SetActive(false);
                    tributePaid = true;
                } else {
                    txtTributeMessage.text = "Insufficient gold for tribute";
                }
            }
            if (tributePaid) {
                localUser.Write("*CLAIM,"+vs.PeekAspiration(aspirationChoice,0).GetName());
                btnAspirationClaimSkip.gameObject.SetActive(false);
                pnlAspirationOptions.SetActive(false);
                pnlTributeGold.SetActive(false);
            }
        });
        btnTributeAbility1.onClick.AddListener(delegate{
            pnlTributeGold.SetActive(true);
            abilityTribute = tributeAbilities[0+tributeAbilityOffset];
            txtTributeMessage.text = "Turn in "+tributeAbilities[0+tributeAbilityOffset].getName()+" as Tribute for Aspiration?";
        });
        btnTributeAbility2.onClick.AddListener(delegate{
            pnlTributeGold.SetActive(true);
            abilityTribute = tributeAbilities[1+tributeAbilityOffset];
            txtTributeMessage.text = "Turn in "+tributeAbilities[1+tributeAbilityOffset].getName()+" as Tribute for Aspiration?";
        });
        btnTributeAbility3.onClick.AddListener(delegate{
            pnlTributeGold.SetActive(true);
            abilityTribute = tributeAbilities[2+tributeAbilityOffset];
            txtTributeMessage.text = "Turn in "+tributeAbilities[2+tributeAbilityOffset].getName()+" as Tribute for Aspiration?";
        });
        btnTributeAbility4.onClick.AddListener(delegate{
            pnlTributeGold.SetActive(true);
            abilityTribute = tributeAbilities[3+tributeAbilityOffset];
            txtTributeMessage.text = "Turn in "+tributeAbilities[3+tributeAbilityOffset].getName()+" as Tribute for Aspiration?";
        });
        btnTributeEquipment1.onClick.AddListener(delegate{
            pnlTributeGold.SetActive(true);
            itemTribute = tributeItems[0+tributeEquipmentOffset];
            txtTributeMessage.text = "Turn in "+tributeItems[0+tributeEquipmentOffset].getName()+" as Tribute for Aspiration?";
        });
        btnTributeEquipment2.onClick.AddListener(delegate{
            pnlTributeGold.SetActive(true);
            itemTribute = tributeItems[1+tributeEquipmentOffset];
            txtTributeMessage.text = "Turn in "+tributeItems[1+tributeEquipmentOffset].getName()+" as Tribute for Aspiration?";
        });
        btnTributeEquipment3.onClick.AddListener(delegate{
            pnlTributeGold.SetActive(true);
            itemTribute = tributeItems[2+tributeEquipmentOffset];
            txtTributeMessage.text = "Turn in "+tributeItems[2+tributeEquipmentOffset].getName()+" as Tribute for Aspiration?";
        });
        btnTributeEquipment4.onClick.AddListener(delegate{
            pnlTributeGold.SetActive(true);
            itemTribute = tributeItems[3+tributeEquipmentOffset];
            txtTributeMessage.text = "Turn in "+tributeItems[3+tributeEquipmentOffset].getName()+" as Tribute for Aspiration?";
        });
        btnTributeTrophy1.onClick.AddListener(delegate{
            pnlTributeGold.SetActive(true);
            trophyTribute = tributeTrophies[0+tributeTrophyOffset];
            txtTributeMessage.text = "Turn in "+tributeTrophies[0+tributeTrophyOffset].GetName()+" as Tribute for Aspiration?";
        });
        btnTributeTrophy2.onClick.AddListener(delegate{
            pnlTributeGold.SetActive(true);
            trophyTribute = tributeTrophies[1+tributeTrophyOffset];
            txtTributeMessage.text = "Turn in "+tributeTrophies[1+tributeTrophyOffset].GetName()+" as Tribute for Aspiration?";
        });
        btnTributeTrophy3.onClick.AddListener(delegate{
            pnlTributeGold.SetActive(true);
            trophyTribute = tributeTrophies[2+tributeTrophyOffset];
            txtTributeMessage.text = "Turn in "+tributeTrophies[2+tributeTrophyOffset].GetName()+" as Tribute for Aspiration?";
        });
        btnTributeAbilityLeftScroll.onClick.AddListener(delegate{tributeAbilityOffset--;ReloadTributeAbility();});
        btnTributeAbilityRightScroll.onClick.AddListener(delegate{tributeAbilityOffset++;ReloadTributeAbility();});
        btnTributeEquipmentLeftScroll.onClick.AddListener(delegate{tributeEquipmentOffset--;ReloadTributeItem();});
        btnTributeEquipmentRightScroll.onClick.AddListener(delegate{tributeEquipmentOffset++;ReloadTributeItem();});
        btnTributeTrophyLeftScroll.onClick.AddListener(delegate{tributeTrophyOffset--;ReloadTributeTrophy();});
        btnTributeTrophyRightScroll.onClick.AddListener(delegate{tributeTrophyOffset++;ReloadTributeTrophy();});
        btnAspirationScore.onClick.AddListener(delegate{
            //Score, close menus, then pass selection
            localUser.changeVP(vs.PeekAspiration(aspirationChoice,0).ScoreAmount());
            btnAspirationClaimSkip.gameObject.SetActive(false);
            pnlAspirationOptions.SetActive(false);
            localUser.Write("*SKIP");
            claimTurn = false;
            aspirationChoice = -1;
        });
        btnCancelClaimScore.onClick.AddListener(delegate{
            pnlAspirationOptions.SetActive(false);
            aspirationChoice = -1;
        });
        btnClassAbility.onClick.AddListener(delegate{ClassAbility();});
        //Listeners for Class Abilities
        btnCD1.onClick.AddListener(delegate{PerformClassAbility(0);});
        btnCD2.onClick.AddListener(delegate{PerformClassAbility(1);});
        btnCD3.onClick.AddListener(delegate{PerformClassAbility(2);});
        btnCD4.onClick.AddListener(delegate{PerformClassAbility(3);});
        btnCDLeft.onClick.AddListener(delegate{CDOffset--;ReloadClassDiscard();});
        btnCDRight.onClick.AddListener(delegate{CDOffset++;ReloadClassDiscard();});
        btnCDExit.onClick.AddListener(delegate{pnlClassDiscard.SetActive(false);});
        //Listeners for Cleric Damage Prevention
        btnPreventConfirm.onClick.AddListener(delegate{
            pnlPrevent.SetActive(false);
            damagePrevented += assignedPrevention[0] + assignedPrevention[1] + assignedPrevention[2] + assignedPrevention[3];
            if (damagePrevented > damagePreventedHigh) damagePreventedHigh = damagePrevented;
            string preventList = "*PREVENT";
            for (int p = 0; p < players.Count; p++){
                preventList += ","+players[p].GetName()+":"+assignedPrevention[p];
            }
            localUser.Write(preventList);
            assignedPrevention = new int[]{0,0,0,0};
        });
        btnP1L.onClick.AddListener(delegate{clericDamagePrevent++;assignedPrevention[0]--;ReloadPrevent();});
        btnP1R.onClick.AddListener(delegate{clericDamagePrevent--;assignedPrevention[0]++;ReloadPrevent();});
        btnP2L.onClick.AddListener(delegate{clericDamagePrevent++;assignedPrevention[1]--;ReloadPrevent();});
        btnP2R.onClick.AddListener(delegate{clericDamagePrevent--;assignedPrevention[1]++;ReloadPrevent();});
        btnP3L.onClick.AddListener(delegate{clericDamagePrevent++;assignedPrevention[2]--;ReloadPrevent();});
        btnP3R.onClick.AddListener(delegate{clericDamagePrevent--;assignedPrevention[2]++;ReloadPrevent();});
        btnP4L.onClick.AddListener(delegate{clericDamagePrevent++;assignedPrevention[3]--;ReloadPrevent();});
        btnP4R.onClick.AddListener(delegate{clericDamagePrevent--;assignedPrevention[3]++;ReloadPrevent();});
        //Boss Lobby
        btnBLJoin.onClick.AddListener(delegate{localUser.Write("*JOINBOSS,"+localUser.GetName());});
        btnBLPass.onClick.AddListener(delegate{localUser.Write("*PASSBOSS,"+localUser.GetName());});
        btnBLReady.onClick.AddListener(delegate{localUser.Write("*STARTBOSS");});
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
            extraDrawn += 2;
            if (extraDrawn > extraDrawnHigh) extraDrawnHigh = extraDrawn;
            ReloadHand();
            CheckClaimConditions();
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
                if (message[0].CompareTo("*TRADEREQUEST") == 0){
                    if (tradePartner != null || (combatants.Contains(localUser) && combatStep)){
                        localUser.Write("*TRADECANCEL,"+message[2]);
                    }
                    else {
                        foreach (Player p in players){
                            if (p.GetName().CompareTo(message[2])==0){
                                tradePartner = p;
                            }
                        }
                        pnlTradeOffer.SetActive(true);
                        btnTradeOfferAccept.gameObject.SetActive(true);
                        btnTradeOfferReject.gameObject.SetActive(true);
                        btnTradeOfferCancel.gameObject.SetActive(false);
                    }
                }
                if (message[0].CompareTo("*GEMCOUNT") == 0){
                    int.TryParse(message[1], out int count);
                    ((Boss) monster).setGem(count);
                }
                if (message[0].CompareTo("*MINONCOUNT") == 0){
                    int.TryParse(message[1], out int count);
                    ((Boss) monster).setMinion(count);
                }
                if (message[0].CompareTo("*TRADECANCEL") == 0){
                    ResetTrade();
                }
                if (message[0].CompareTo("*ACCEPTTRADEREQUEST") == 0){
                    pnlTradeOffer.SetActive(false);
                    pnlTradeActive.SetActive(true);
                    ReloadTradeMenu();                    
                }
                if (message[0].CompareTo("*TRADEACCEPT") == 0){
                    tradeAcceptedOther = true;
                    ReloadTradeMenu();
                    if (tradeAcceptedPlayer == true){
                        CompleteTrade();
                    }
                }
                if (message[0].CompareTo("*TRADEUNACCEPT") == 0){
                    tradeAcceptedOther = false;
                    ReloadTradeMenu();
                }
                if (message[0].CompareTo("*TRADEOFFER") == 0){
                    //Gold,vp,ability,item,aspiration,trophy
                    int.TryParse(message[2], out tradeGoldOther);
                    int.TryParse(message[3], out tradeVPOther);
                    tradeAbility1Other = message[4];
                    tradeAbility2Other = message[5];
                    tradeItem1Other = message[6];
                    tradeItem2Other = message[7];
                    tradeAspiration1Other = message[8];
                    tradeAspiration2Other = message[9];
                    tradeTrophy1Other = message[10];
                    tradeTrophy2Other = message[11];
                    ReloadTradeMenu();
                }
                if (message[0].CompareTo("*REQUESTASPIRATION")==0){
                    int.TryParse(message[1], out int i);
                    foreach (Aspiration a in vs.GetAspirations()) {
                        if (a.GetName().CompareTo(message[2])==0){
                            vs.PushAspiration(i,a.Clone());
                            break;
                        }
                    }
                    aspirationsPending = false;
                    for (int row = 0; row < 4; row++){
                        if (vs.AspirationCount(row)==0)
                            aspirationsPending = true;
                    }
                    ReloadAspirations();
                }
                if (message[0].CompareTo("*BOSS") == 0){
                    if (vs.getBoss() == null) {
                        foreach(Boss b in vs.getBossList()) if (b.GetName().CompareTo(message[1])==0){
                            b.setStats(b.Health()[1],b.Shields()[1],b.PowerShields()[1],0,0,0);
                            vs.setBoss(b);
                        }
                        foreach(Boss b in vs.getBossMods()) if (b.GetName().CompareTo(message[2])==0){
                            vs.getBoss().setStarterMod(b);
                        }
                    }
                    bossPhase = true;
                    monster = vs.getBoss();
                    monsterTier = 5;
                    if (((Boss)monster).usesMinions()) pnlMinions.SetActive(true);
                    else pnlGems.SetActive(true);
                    ReloadMonster();
                }
                if (message[0].CompareTo("*BOSSLOBBY") == 0){
                    if (localUser.GetName().CompareTo(message[1])==0) localUser.IsLead(true);
                    else localUser.IsLead(false);
                    pnlBossLobby.SetActive(true);
                    lobbyStep = true;
                    ReloadBossLobby();
                }
                if (message[0].CompareTo("*ENDOFGAME") == 0){
                    SceneManager.LoadScene("Score");
                }
                if (message[0].CompareTo("*ENDOFDAY") == 0){
                    foreach (Player p in players){
                        p.setHealth(p.getHealth()[1]);
                        foreach (Equipment e in localUser.Arsenal())
                            e.ResetDaily();
                    }
                    localUser.Write("*SETUP");
                }
                if (message[0].CompareTo("*DUNGEON") == 0){
                    localUser.Write("*SETUP");
                }
                if (message[0].CompareTo("*REWARD") == 0){
                    int.TryParse(message[1], out int gold);
                    bool.TryParse(message[2], out bool trophy);
                    int.TryParse(message[3], out int vp);
                    localUser.changeGold(gold);
                    if (trophy) localUser.AddTrophy(monster);
                    localUser.changeVP(vp);
                    if (message.Length > 4) {
                        string[] loot = message[4].Split(';');
                        foreach (string l in loot){
                            foreach(Equipment e in vs.GetCommonEquipment()){
                                if (e.getName().CompareTo(l.Split(':')[0])==0){
                                    Equipment temp = e.Clone();
                                    if (l.Split(':')[0].CompareTo("Tome")==0)
                                    foreach(Ability a in vs.GetShopAbilities()){
                                        if (a.getName().CompareTo(l.Split(':')[1])==0){
                                            temp.linkAbility(a.Clone()); break;}
                                    }
                                    localUser.Arsenal().Add(temp); break;
                                }
                            }
                            foreach(Equipment e in vs.GetQualityEquipment()){
                                if (e.getName().CompareTo(l)==0){
                                    Equipment temp = e.Clone();
                                    localUser.Arsenal().Add(temp); break;
                                }
                            }
                        }
                    }
                }
                //Receive message to start the lobby, as well as who the lobby leader is and the monster to be fought.
                if(message[0].CompareTo("*LOBBY") == 0){
                    //Turns off combat and reward panels and turns on lobby and non-combat ones.
                    while (combatants.Count > 0)
                        combatants.RemoveAt(0);
                    monster = null;
                    RewardDrops = null;
                    rewardCount = new int[]{0,0,0,0};
                    rewardGold = new int[]{0,0,0,0};
                    rewardRoll = new int[]{0,0,0,0};
                    rewardTreasure = new int[]{0,0,0,0};
                    rewardVP = new int[]{0,0,0,0};
                    rewardsAssignment = new string[]{"","","","","","",""};
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
                    if (RewardDrops == null) RewardDrops = new List<Equipment>();
                    lobbyStep = false;
                    combatStep = false;
                    rewardStep = true;
                    for (int m = 1; m < message.Length; m++){
                        Equipment temp = null;
                        foreach(Equipment e in vs.GetCommonEquipment()){
                            if (e.getName().CompareTo(message[m].Split(':')[0])==0){
                                temp = e.Clone();
                                if (message[m].Split(':')[0].CompareTo("Tome")==0)
                                foreach(Ability a in vs.GetShopAbilities()){
                                    if (a.getName().CompareTo(message[m].Split(':')[1])==0){
                                        temp.linkAbility(a.Clone()); break;}
                                }
                                Debug.Log("Adding to drops: "+temp.getName());
                                RewardDrops.Add(temp); 
                                break;
                            }
                        }
                        foreach(Equipment e in vs.GetQualityEquipment()){
                            if (e.getName().CompareTo(message[m])==0){
                                temp = e.Clone();
                                RewardDrops.Add(temp); break;
                            }
                        }
                    }
                    SwitchToRewards();
                }
                if (message[0].CompareTo("*JOINBOSS") == 0){
                    for (int p = 0; p < players.Count; p++){
                        if (players[p].GetName().CompareTo(message[1])==0){
                            joiningBoss[p] = true;
                            passingBoss[p] = false;
                            combatants.Add(players[p]);
                        }
                    }
                    ReloadBossLobby();
                }
                if (message[0].CompareTo("*PASSBOSS") == 0){
                    for (int p = 0; p < players.Count; p++){
                        if (players[p].GetName().CompareTo(message[1])==0){
                            joiningBoss[p] = false;
                            passingBoss[p] = true;
                            combatants.Remove(players[p]);
                        }
                    }
                    ReloadBossLobby();
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
                    }
                    if (message[0].CompareTo("*LOBBYREWARDS") == 0){
                        for (int m = 1; m < message.Length; m++)
                            for (int i = 0; i < players.Count; i++){
                                if (message[m].Split(':')[0].CompareTo(players[i].GetName())==0){
                                    int.TryParse(message[m].Split(':')[1], out rewardGold[i]);
                                    int.TryParse(message[m].Split(':')[2], out rewardTreasure[i]);
                                    int.TryParse(message[m].Split(':')[3], out rewardTrophy[i]);
                                    int.TryParse(message[m].Split(':')[4], out rewardRoll[i]);
                                    int.TryParse(message[m].Split(':')[5], out rewardVP[i]);
                                }
                            }
                        ReloadLobby();
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
                            ReloadDiscard();
                            ReloadHand();
                            CheckClaimConditions();
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
                        monsterAttacking = true;
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
                    }
                    if (message[0].CompareTo("*DAMAGEUPDATE") == 0){
                        Debug.Log("Recieved damage update");
                        string damageInfo = monster.GetName() + " is attacking for the following damage amounts:\n";
                        for (int i = 1; i < message.Length; i++) {
                            damageInfo += message[i] + "\n";
                            for (int p = 0; p < players.Count; p++){
                                if (players[p].GetName().CompareTo(message[i].Split(':')[0])==0)
                                    int.TryParse(message[i].Split(':')[1].Trim(), out damageBeingDealt[p]);
                            }
                        }
                        damageInfo += "You can still use potions and abilities at this time.";
                        txtDamageInfo.text = damageInfo;
                    }
                    if (message[0].CompareTo("*MONSTERACTION") == 0){
                        noTurnForMonster = false;
                    }
                    if (message[0].CompareTo("*PREVENT") == 0){//I don't think this is even being used
                        int.TryParse(message[1], out int prevented);
                        pendingDamage -= prevented;
                        localUser.Write("*DAMAGE,"+pendingDamage);
                    }
                    if (message[0].CompareTo("*ATTACKCONFIRMED") == 0){
                        Debug.Log("Attack Confirmed");
                        int finalDamage = attackResult();
                        damagePrevented += pendingDamage - finalDamage;
                        if (damagePrevented > damagePreventedHigh) damagePreventedHigh = damagePrevented;
                        Debug.Log("Final Damage returned");
                        localUser.takeDamage(finalDamage);
                        Debug.Log("Damage deducted from health");
                        string finalResult = ("*RESULT,"+finalDamage);
                        if (pendingTag != null && pendingTag.CompareTo("DRAIN")==0 && finalDamage > 0) finalResult+=",DRAIN";
                        localUser.Write(finalResult);
                        pendingShieldBreak = 0;
                        pendingDamage = 0;
                        pendingHoming = false;
                        pendingPierce = false;
                        pendingIgnore = false;
                        pendingType = "";
                        pendingTag = "";
                        pnlConfirmDamage.SetActive(false);
                        monsterAttacking = false;
                        CheckClaimConditions();
                        damageBeingDealt = new int[]{0,0,0,0};
                    }
                    if (message[0].CompareTo("*MILL") == 0){
                        Ability temp = localUser.Deck().Draw();
                        localUser.Write("*MILL,"+temp.GetCardType());
                        localUser.Deck().Discard(temp);
                        ReloadDiscard();
                    
                    
                    }//Receives the results of an attack made by a player
                    if (message[0].CompareTo("*RESULT") == 0){
                        int.TryParse(message[1],out int h);
                        int.TryParse(message[2],out int s);
                        int.TryParse(message[3],out int ps);
                        int.TryParse(message[4],out int ash);
                        int.TryParse(message[5],out int aps);
                        int.TryParse(message[6],out int ts);
                        if (localAttack) damageDealt += monster.Health()[0]-h;
                        if (damageDealt > damageDealtHigh) damageDealtHigh = damageDealt;
                        monster.setStats(h,s,ps,ash,aps,ts);
                        CheckClaimConditions();
                        ReloadMonster();
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
                    if (message[0].CompareTo("*REWARDSDISTRO") == 0){
                        string[] distro = message[1].Split(':');
                        for (int d = 0; d < distro.Length; d++){
                            rewardsAssignment[d] = distro[d];
                        }
                        ReloadRewards();
                    }
                    if (message[0].CompareTo("*ASPIRATIONS") == 0){
                        if (localUser.GetName().CompareTo(message[1])==0){
                            claimTurn = true;
                            btnAspirationClaimSkip.gameObject.SetActive(true);
                        }
                        pnlRewardsDistro.SetActive(false);
                        CheckClaimConditions();
                    }
                    if (message[0].CompareTo("*NEXTCHOICE") == 0){
                        if (localUser.GetName().CompareTo(message[1])==0){
                            claimTurn = true;
                            btnAspirationClaimSkip.gameObject.SetActive(true);
                        }
                        ReloadAspirations();
                    }
                    if (message[0].CompareTo("*CLAIM") == 0){
                        for (int row = 0; row < 4; row++){
                            if (vs.PeekAspiration(row,0).GetName().CompareTo(message[1])==0){
                                if (aspirationClaimed[row].CompareTo("")!=0) continue;
                                else {aspirationClaimed[row] = message[2]; break;}
                            }
                        }
                        pnlAspirationOptions.SetActive(false);
                        ReloadAspirations();
                    }
                    if (message[0].CompareTo("*ALLCLAIMED") == 0){
                        Debug.Log("Aspirations Claimed by: "+aspirationClaimed[0]+" , "+aspirationClaimed[1]+" , "+aspirationClaimed[2]+" , "+aspirationClaimed[3]);
                        for (int row = 0; row < 4; row++){
                            if (aspirationClaimed[row].CompareTo(localUser.GetName())==0) {
                                localUser.AddAspiration(vs.PopAspiration(row));
                                continue;
                            }
                            if(aspirationClaimed[row].CompareTo("")!=0){
                                vs.PopAspiration(row);
                                continue;
                            }
                        }
                        aspirationClaimed = new string[]{"","","",""};
                        ReloadAspirations();
                        if (localUser.IsLead()){
                            for (int row = 0; row < 4; row++){
                                if (vs.AspirationCount(row)==0)
                                    localUser.Write("*REQUESTASPIRATION,"+row);
                            }
                        }
                            for (int row = 0; row < 4; row++){
                                if (vs.AspirationCount(row)==0)
                                    aspirationsPending = true;
                            }
                        ReloadAspirations();
                    }
                }
                if (message[0].CompareTo("*SHOP") == 0){
                    readyToShop = true;
                }
            }
        }
        if (readyToShop && aspirationsPending == false)
            SceneManager.LoadScene("Shop");
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
        if (localUser.IsLead() == false)
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
        ReloadRewards();
        CheckClaimConditions();
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
        ReloadLobby();
    }

    //Lobby Functions
    void LoadMonster(string name, string[] _mods){
        List<string> mods = new();
        mods.AddRange(_mods);
        List<Monster> monsterMods = new List<Monster>();
        foreach (Monster m in vs.getMonList()){
            if (m.GetName().CompareTo(name)==0) monster = m.Clone();
            foreach (string s in mods) if (m.GetName().CompareTo(s)==0) monsterMods.Add(m.Clone());
        }
        monster.setMods(monsterMods);
        monster.setStats(monster.Health()[1], monster.Shields()[1], monster.PowerShields()[1], 0, 0, 0);
        enemyTier = monster.Tier();
        if (localUser.IsLead()){
            //rewards[0] = gold; rewards[1] = commontreasure + qualitytreasure; rewards[2] = victorypoints; rewards[3] = 1 + treasurerolls;
            rewardGold[0] = monster.getRewards()[0]; rewardGold[1] = 0; rewardGold[2] = 0; rewardGold[3] = 0;
            rewardTreasure[0] = monster.getRewards()[1]; rewardTreasure[1] = 0; rewardTreasure[2] = 0; rewardTreasure[3] = 0;
            rewardTrophy[0] = 1; rewardTrophy[1] = 0; rewardTrophy[2] = 0; rewardTrophy[3] = 0;
            rewardRoll[0] = monster.getRewards()[3]; rewardRoll[1] = 0; rewardRoll[2] = 0;  rewardRoll[3] = 0; 
            rewardVP[0] = monster.getRewards()[2]; rewardVP[1] = monster.getRewards()[2]; rewardVP[2] = monster.getRewards()[2]; rewardVP[3] = monster.getRewards()[2];
            if (monster.getAllRewarded()){
                rewardGold[1] = monster.getRewards()[0];rewardGold[2] = monster.getRewards()[0];rewardGold[3] = monster.getRewards()[0];
                rewardTreasure[1] = monster.getRewards()[1];rewardTreasure[2] = monster.getRewards()[1];rewardTreasure[3] = monster.getRewards()[1];
                rewardRoll[1] = monster.getRewards()[3];rewardRoll[2] = monster.getRewards()[3];rewardRoll[3] = monster.getRewards()[3];
                rewardVP[1] = monster.getRewards()[2];rewardVP[2] = monster.getRewards()[2];rewardVP[3] = monster.getRewards()[2];
            }
            sendRewardsDistro();
        }
        conditionsMet = new bool[]{false,false,false,false};
        cardsPlayed = 0;
        spellsPlayed = 0;
        attacksPlayed = 0;
        defensesPlayed = 0;
        techniquesPlayed = 0;
        List<string> typesPlayed = new List<string>();
        damageDealt = 0;
        extraDrawn = 0;
        damagePrevented = 0;
        remainingShields = 0;
        remainingPowerShields = 0;
        remainingEvade = 0;
        noTurnForMonster = true;
        monsterType = monster.GetMonType();
        monsterTier = monster.Tier();
        cardsPlayedHigh = 0;
        spellsPlayedHigh = 0;
        attacksPlayedHigh = 0;
        defensesPlayedHigh = 0;
        techniquesPlayedHigh = 0;
        typesPlayedHigh = 0;
        damageDealtHigh = 0;
        extraDrawnHigh = 0;
        damagePreventedHigh = 0;
        ReloadMonster();
        CheckClaimConditions();
    }
    void clearMonster(){
        //Destroy(monster.gameObject);
        monster = null;
    }
    void LootNRun(){
            rewardGold[0] = 0; rewardGold[1] = 0; rewardGold[2] = 0; rewardGold[3] = 0;
            rewardTreasure[0] = 0; rewardTreasure[1] = 0; rewardTreasure[2] = 0; rewardTreasure[3] = 0;
            rewardTrophy[0] = 0; rewardTrophy[1] = 0; rewardTrophy[2] = 0; rewardTrophy[3] = 0;
            rewardRoll[0] = 1; rewardRoll[1] = 0; rewardRoll[2] = 0;  rewardRoll[3] = 0; 
            rewardVP[0] = 0; rewardVP[1] = 0; rewardVP[2] = 0; rewardVP[3] =0;
        while (combatants.Count > 0)
            combatants.RemoveAt(0);
        combatants.Add(localUser);
        localUser.Write("*LOOT");
    }
    void PlayerParticipationToggle(int pIndex, bool isOn){
        if (monster.getAllRewarded()){
            
        } else if(isOn == false){
            rewardGold[0] += rewardGold[pIndex]; rewardGold[pIndex] = 0;
            rewardTreasure[0] += rewardTreasure[pIndex]; rewardTreasure[pIndex] = 0;
            rewardTrophy[0] += rewardTrophy[pIndex]; rewardTrophy[pIndex] = 0;
            rewardRoll[0] += rewardRoll[pIndex]; rewardRoll[pIndex] = 0;
            rewardVP[0] += rewardVP[pIndex]-monster.getRewards()[2]; rewardVP[pIndex] = monster.getRewards()[2];
            ReloadLobby();
        }
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
        localUser.SetAP(0);
        pnlLobby.SetActive(false);
        pnlBossLobby.SetActive(false);
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
                        e.restoreShields();
                    }
                }
            }
        }
        rewardStep = false;
        lobbyStep = false;
        combatStep = true;
        ReloadEquipped();
        ReloadMonster();
        ReloadDefenses();
        ReloadDiscard();
        ReloadHand();
        ReloadPlay();
        CheckClaimConditions();
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
        CheckClaimConditions();
    }
    void AcceptRewards(){
        //handling to ensure loot is divided as planned
        if(rewardCount[0] == rewardTreasure[0] && rewardCount[1] == rewardTreasure[1] && 
                rewardCount[2] == rewardTreasure[2] && rewardCount[3] == rewardTreasure[3]){
            string lootList = "*ACCEPT";
            for (int i = 0; i < players.Count; i++){
                lootList += ","+players[i].GetName()+";"+rewardGold[i]+";"+rewardTrophy[i]+";"+rewardRoll[i]+";"+rewardVP[i];
                for (int j = 0; j < RewardDrops.Count;j++){
                    if (rewardsAssignment[j].CompareTo(players[i].GetName())==0)
                        lootList += ";"+RewardDrops[j].getName();
                }
            }
            localUser.Write(lootList);
            while(combatants.Count > 0)
                combatants.RemoveAt(0);
            CheckClaimConditions();
        }
    }
    void rewardChange(int _player, int _reward, bool _assigned ){
        string temp = rewardsAssignment[_reward-1];
        if (_assigned){
            rewardsAssignment[_reward-1] = players[_player-1].GetName();
            rewardCount[_player-1]++;
        } else {
            rewardCount[_player-1]--;
            if (temp.CompareTo(players[_player-1].GetName()) == 0) rewardsAssignment[_reward-1] = "";
        }
        string rewardsList = "*REWARDSDISTRO,";
        foreach (string s in rewardsAssignment) rewardsList += s+":";
        rewardsList = rewardsList.Remove(rewardsList.Length-1);//Removes the extra colon at the end
        localUser.Write(rewardsList);
        ReloadRewards();
    }
    void StartTurn(){
        localUser.SetAP(1);
        pnlPlayZone.SetActive(true);
        btnTurnComplete.gameObject.SetActive(true);
        btnRunAway.gameObject.SetActive(true);
        inHand.Add(localUser.Deck().Draw());
        txtActionPoints.text = "AP: "+localUser.getAP();
        foreach (Equipment e in localUser.GetEquipped()){
            if (e != null)
                if (e.Regen(enemyTier) > 0) localUser.Write("*HEAL,"+localUser.GetName()+":"+e.Regen(enemyTier));
        }
        ReloadHand();
        cardsPlayed = 0;
        spellsPlayed = 0;
        attacksPlayed = 0;
        defensesPlayed = 0;
        techniquesPlayed = 0;
        List<string> typesPlayed = new List<string>();
        damageDealt = 0;
        extraDrawn = 0;
        damagePrevented = 0;
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
            int[] defs = defenses[1+defOffset].getCurrentDefenses();
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
            int[] defs = defenses[2+defOffset].getCurrentDefenses();
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
            int[] defs = defenses[3+defOffset].getCurrentDefenses();
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
            int[] defs = defenses[4+defOffset].getCurrentDefenses();
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
            int[] defs = defenses[5+defOffset].getCurrentDefenses();
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
            cardsPlayed++;
            if (cardsPlayed > cardsPlayedHigh) cardsPlayedHigh = cardsPlayed;
            Ability card = inHand[num + handOffset];
            localUser.Write("*CHAT,"+localUser.GetName()+" used "+card.getName()+"!");
            if (card.GetSPSK().CompareTo("Spell")==0){
                spellsPlayed++;
                if (spellsPlayed > spellsPlayedHigh) spellsPlayedHigh = spellsPlayed;
            }
            if (card.isAttack()) {
                attacksPlayed++;
                if (typesPlayed.Contains("Attack")==false)typesPlayed.Add("Attack");
                if (attacksPlayed > attacksPlayedHigh) attacksPlayedHigh = attacksPlayed;
            }
            if (card.isDefense()) {
                defensesPlayed++;
                if (typesPlayed.Contains("Defense")==false)typesPlayed.Add("Defense");
                if (defensesPlayed > defensesPlayedHigh) defensesPlayedHigh = defensesPlayed;
            }
            if (card.isTechnique()) {
                techniquesPlayed++;
                if (typesPlayed.Contains("Technique")==false)typesPlayed.Add("Technique");
                if (techniquesPlayed > techniquesPlayedHigh) techniquesPlayedHigh = techniquesPlayed;
            }
            if (typesPlayed.Count > typesPlayedHigh) typesPlayedHigh = typesPlayed.Count;
            //First, checks if is Critical card and rolls if it is.
            int result = card.RollSuccess();
            if (result > 0) {
                localUser.Write("*CHAT,"+localUser.GetName()+" rolled a "+result+" on critical attempt.");
            }
            //If is type attack, will make an attack call on the enemy.
            //ShieldBreak,Damage,IsHoming,IsPierce,IsCollateral
            if (card.isAttack()&&card.getName().CompareTo("Counter")!=0){
                Attack(card);
            } else {
                //condintions for cards that add pierce or homing to NEXT attack.
                nextHoming = card.GetDamageType()[0];
                nextPierce = card.GetDamageType()[1];
            }
            if (card.RestoresShields()) RestoreEquipment();
            for (int i = 0; i < card.getDraw(); i++){
                inHand.Add(localUser.Deck().Draw());
                extraDrawn++;
                if (extraDrawn > extraDrawnHigh) extraDrawnHigh = extraDrawn;
            }
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
            CheckClaimConditions();
            txtActionPoints.text = "AP: "+localUser.getAP();
        }
    }
    void Attack(Ability card){
        int[] damages = card.GetDamage();
        bool[] types = card.GetDamageType();
        string SPorSK = card.GetSPSK();
        string attackType = SPorSK;
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
            if (types[2]) attackType = "Collateral";
        }
        localUser.Write("*ATTACK,"+card.getName()+","+damages[0]+","+damages[1]+","+types[0]+","+types[1]+","+ignore+","+attackType);
        localAttack = true;
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
        Ability counter = null;
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
        if (pendingTag != null && pendingTag.CompareTo("HANDCOUNTREDUCE")==0) pendingDamage -= inHand.Count;
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
        ReloadEquipped();
        ReloadDiscard();
        //Calculate evade
        if (pendingHoming == false && pendingType.CompareTo("collateral")!=0){
            
            pendingDamage -= evade;
        } if (pendingDamage <= 0) return 0;
        if (pendingIgnore == false){
            for (int d = 0; d < defenses.Count; d++){
                if (defenses[d].getCurrentDefenses()[1] >= pendingDamage){
                    defenses[d].DamageSheilds(pendingDamage);
                    if (defenses[d].getCurrentDefenses()[1] == 0 && defenses[d].getName().CompareTo("Counter")==0) counter = defenses[d];
                    pendingDamage = 0;
                } else {
                    pendingDamage -= defenses[d].getCurrentDefenses()[1];
                    defenses[d].DamageSheilds(defenses[d].getCurrentDefenses()[1]);
                    if (defenses[d].getName().CompareTo("Counter")==0) counter = defenses[d];
                }
                
            }
            ReloadDefenses();
            ReloadDiscard();
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
        if (pendingDamage <= 0)  {if (counter != null)Attack(counter);return 0;}
        //Armor
        if (pendingPierce == false && pendingType.CompareTo("collateral")!=0){
            pendingDamage -= armor;
        }
        if (pendingDamage <= 0)  {if (counter != null)Attack(counter);return 0;}
        if (pendingDamage < localUser.getHealth()[0] && counter != null) Attack(counter);
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
            if (localUser.GetEquipped("Armor").getPowerShield(playerClass) == 0 && localUser.GetEquipped("Armor").getShield(playerClass, enemyTier) == 0)
                imgEquipBodyShield.transform.parent.gameObject.SetActive(false);
        } else {btnEquipBody.image.sprite = empty;imgEquipBodyShield.transform.parent.gameObject.SetActive(false);}
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
        } else {btnEquipMainHand.image.sprite = empty;imgEquipMainHandShield.transform.parent.gameObject.SetActive(false);}
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
        } else {btnEquipOffHand.image.sprite = empty;imgEquipOffHandShield.transform.parent.gameObject.SetActive(false);}
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
        } else {btnEquipExtra.image.sprite = empty;imgEquipExtraShield.transform.parent.gameObject.SetActive(false);}
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
        } else {btnAux1.image.sprite = empty;imgAuxShield1.transform.parent.gameObject.SetActive(false);}
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
        } else {btnAux2.image.sprite = empty;imgAuxShield2.transform.parent.gameObject.SetActive(false);}
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
        } else {btnAux3.image.sprite = empty;imgAuxShield3.transform.parent.gameObject.SetActive(false);}
    }    
    void ReloadMonster(){        
        if (monster == null){
            imgMonster.sprite = empty;
            txtMonsterHealth.text = "NA";
            txtMonsterAbilityShields.text = "NA";
            txtMonsterShields.text = "NA";
            imgMonsterHealth.transform.localScale = new Vector3(0,1,1);
            imgMonsterAbilityShields.transform.localScale = new Vector3(0,1,1);
            imgMonsterShields.transform.localScale = new Vector3(0,1,1);
        } else {
            imgMonster.sprite = monster.Image();
            txtMonsterHealth.text = monster.Health()[0]+"/"+monster.Health()[1];
            imgMonsterHealth.transform.localScale = new Vector3((float)monster.Health()[0]/monster.Health()[1],1,1);
            if (monster.AbilityShields()[1] > 0 || monster.AbilityPowerShields()[1] > 0){
                if (monster.AbilityShields()[1] > 0){
                    txtMonsterAbilityShields.text = monster.AbilityShields()[0]+"/"+monster.AbilityShields()[1];
                    imgMonsterAbilityShields.transform.localScale = new Vector3((float)monster.AbilityShields()[0]/monster.AbilityShields()[1],1,1);
                    imgMonsterAbilityShields.color = Color.cyan;
                } else {
                    txtMonsterAbilityShields.text = monster.AbilityPowerShields()[0]+"/"+monster.AbilityPowerShields()[1];
                    imgMonsterAbilityShields.transform.localScale = new Vector3((float)monster.AbilityPowerShields()[0]/monster.AbilityPowerShields()[1],1,1);
                    imgMonsterAbilityShields.color = new Color(.7f,.7f,.7f,1);
                }
            } else {
                txtMonsterAbilityShields.text = "NA";
                imgMonsterAbilityShields.transform.localScale = new Vector3(0,1,1);
            }
            if (monster.Shields()[1] > 0 || monster.PowerShields()[1] > 0){
                if (monster.Shields()[1] > 0){
                    txtMonsterShields.text = monster.Shields()[0]+"/"+monster.Shields()[1];
                    imgMonsterShields.transform.localScale = new Vector3((float)monster.Shields()[0]/monster.Shields()[1],1,1);
                    imgMonsterShields.color = Color.cyan;
                } else {
                    txtMonsterShields.text = monster.PowerShields()[0]+"/"+monster.PowerShields()[1];
                    imgMonsterShields.transform.localScale = new Vector3((float)monster.PowerShields()[0]/monster.PowerShields()[1],1,1);
                    imgMonsterShields.color = new Color(.7f,.7f,.7f,1);
                }
            } else {
                txtMonsterShields.text = "NA";
                imgMonsterShields.transform.localScale = new Vector3(0,1,1);
            }
            if (monster.getMods().Count == 0 && bossPhase == false) pnlMMods.SetActive(false);
            else{
                if (monster.getMods().Count >= 1){
                    btnMMod1.gameObject.SetActive(true);
                    btnMMod1.image.sprite = monster.getMods()[0+MModOffset].Image();
                    if (monster.getMods()[0+MModOffset].GetName().CompareTo("Trained") == 0){
                        imgModShield1.gameObject.transform.parent.gameObject.SetActive(true);
                        imgModShield1.color = Color.cyan;
                        imgModShield1.transform.localScale = new Vector3((float)monster.TrainedShields()[0]/monster.TrainedShields()[1],0,0);
                        txtModShield1.text = monster.TrainedShields()[0]+"/"+monster.TrainedShields()[1];
                    } else {imgModShield1.gameObject.transform.parent.gameObject.SetActive(false);}
                } else {
                    btnMMod1.gameObject.SetActive(false);
                }
                if (monster.getMods().Count >= 2){
                    btnMMod2.gameObject.SetActive(true);
                    btnMMod2.image.sprite = monster.getMods()[1+MModOffset].Image();
                    if (monster.getMods()[1+MModOffset].GetName().CompareTo("Trained") == 0){
                        imgModShield2.gameObject.transform.parent.gameObject.SetActive(true);
                        imgModShield2.color = Color.cyan;
                        imgModShield2.transform.localScale = new Vector3((float)monster.TrainedShields()[0]/monster.TrainedShields()[1],0,0);
                        txtModShield2.text = monster.TrainedShields()[0]+"/"+monster.TrainedShields()[1];
                    } else {imgModShield2.gameObject.transform.parent.gameObject.SetActive(false);}
                } else {
                    btnMMod2.gameObject.SetActive(false);
                }
                if (monster.getMods().Count >= 3){
                    btnMMod3.gameObject.SetActive(true);
                    btnMMod3.image.sprite = monster.getMods()[2+MModOffset].Image();
                    if (monster.getMods()[2+MModOffset].GetName().CompareTo("Trained") == 0){
                        imgModShield3.gameObject.transform.parent.gameObject.SetActive(true);
                        imgModShield3.color = Color.cyan;
                        imgModShield3.transform.localScale = new Vector3((float)monster.TrainedShields()[0]/monster.TrainedShields()[1],0,0);
                        txtModShield3.text = monster.TrainedShields()[0]+"/"+monster.TrainedShields()[1];
                    } else {imgModShield3.gameObject.transform.parent.gameObject.SetActive(false);}
                } else {
                    btnMMod3.gameObject.SetActive(false);
                }
                if (monster.getMods().Count > 3){
                    if (MModOffset < monster.getMods().Count -3) btnMModLeft.gameObject.SetActive(true);
                    else btnMModLeft.gameObject.SetActive(false);
                    if (MModOffset > 0) btnMModRight.gameObject.SetActive(true);
                    else btnMModRight.gameObject.SetActive(false);
                } else {
                    btnMModLeft.gameObject.SetActive(false);
                    btnMModRight.gameObject.SetActive(false);
                }
                if (bossPhase){
                    imgModShield1.gameObject.transform.parent.gameObject.SetActive(false);
                    imgModShield2.gameObject.transform.parent.gameObject.SetActive(false);
                    imgModShield3.gameObject.transform.parent.gameObject.SetActive(false);
                    btnMMod1.gameObject.SetActive(true);
                    btnMMod1.image.sprite = ((Boss) monster).getStarterMod().Image();
                    if (((Boss) monster).getEnragedMod() != null){
                        btnMMod2.gameObject.SetActive(true);
                        btnMMod2.image.sprite = ((Boss) monster).getEnragedMod().Image();
                    }
                    if (((Boss) monster).getExtraMod() != null){
                        btnMMod2.gameObject.SetActive(true);
                        btnMMod2.image.sprite = ((Boss) monster).getExtraMod().Image();
                    }
                    imgGems.gameObject.transform.localScale = new Vector3((float)((Boss)monster).getGems()/6,1f,1f);
                    txtGems.text = (float)((Boss)monster).getGems()+"/"+6;
                    imgMinions.gameObject.transform.localScale = new Vector3((float)((Boss)monster).getMinions()/(1+players.Count),1f,1f);
                    txtMinions.text = (float)((Boss)monster).getMinions()+"/"+(1+players.Count);
                }
            }
        
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
        itemToEquip.restoreShields();
        equippingSlot = null;
        itemToEquip = null;
        pnlEquipOptionView.SetActive(false);
        ReloadEquipped();
        CheckClaimConditions();
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
        if (pendingTag != null && pendingTag.CompareTo("HANDCOUNTREDUCE")==0) tempdmg -= inHand.Count;
        shld -= tempsb; if (shld < 0) shld = 0;
        if (pendingHoming == false && pendingType.CompareTo("collateral")!=0){
            tempdmg -= evade;
        }
        if (pendingIgnore == false){
            tempdmg -= shld;
            tempdmg -= pshld;
        }
        if (pendingPierce == false && pendingType.CompareTo("collateral")!=0){
            tempdmg -= armor;
        }
        if (tempdmg < 0) tempdmg = 0;
        return tempdmg;
    }
    void useEquipmentAbility(string slot){
        //Will complete after classes are implemented
    }
    void ReloadLobby(){
        txtP1G.text = ""+rewardGold[0]; txtP1Tr.text = ""+rewardTreasure[0]; txtP1Tp.text = ""+rewardTrophy[0]; 
        txtP1R.text = ""+rewardRoll[0]; txtP1V.text = ""+rewardVP[0];
        txtP2G.text = ""+rewardGold[1]; txtP2Tr.text = ""+rewardTreasure[1]; txtP2Tp.text = ""+rewardTrophy[1]; 
        txtP2R.text = ""+rewardRoll[1]; txtP2V.text = ""+rewardVP[1];
        txtP3G.text = ""+rewardGold[2]; txtP3Tr.text = ""+rewardTreasure[2]; txtP3Tp.text = ""+rewardTrophy[2]; 
        txtP3R.text = ""+rewardRoll[2]; txtP3V.text = ""+rewardVP[2];
        txtP4G.text = ""+rewardGold[3]; txtP4Tr.text = ""+rewardTreasure[3]; txtP4Tp.text = ""+rewardTrophy[3]; 
        txtP4R.text = ""+rewardRoll[3]; txtP4V.text = ""+rewardVP[3];
    }
    void sendRewardsDistro(){
        string rewardsList = "*LOBBYREWARDS";
        rewardsList += "," + players[0].GetName() +":"+ rewardGold[0] +":"+ rewardTreasure[0] +":"+ rewardTrophy[0] +":"+ rewardRoll[0] +":"+ rewardVP[0];
        rewardsList += "," + players[1].GetName() +":"+ rewardGold[1] +":"+ rewardTreasure[1] +":"+ rewardTrophy[1] +":"+ rewardRoll[1] +":"+ rewardVP[1];
        if (players.Count > 2) rewardsList += "," + players[2].GetName() +":"+ rewardGold[2] +":"+ rewardTreasure[2] +":"+ rewardTrophy[2] +":"+ rewardRoll[2] +":"+ rewardVP[2];
        if (players.Count > 3) rewardsList += "," + players[3].GetName() +":"+ rewardGold[3] +":"+ rewardTreasure[3] +":"+ rewardTrophy[3] +":"+ rewardRoll[3] +":"+ rewardVP[3];
        localUser.Write(rewardsList);
    }
    void ReloadRewards(){
        //Rewards 1, 2, and 3 are guaranteed.
        btnRewardCard1.image.sprite = RewardDrops[0].Image();
        if (rewardsAssignment[0].CompareTo(localUser.GetName())==0) btnRewardCard1.image.color = Color.white;
        else btnRewardCard1.image.color = new Color(.7f,.7f,.7f,1);
        btnRewardCard2.image.sprite = RewardDrops[1].Image();
        if (rewardsAssignment[1].CompareTo(localUser.GetName())==0) btnRewardCard2.image.color = Color.white;
        else btnRewardCard2.image.color = new Color(.7f,.7f,.7f,1);
        btnRewardCard3.image.sprite = RewardDrops[2].Image();
        if (rewardsAssignment[2].CompareTo(localUser.GetName())==0) btnRewardCard3.image.color = Color.white;
        else btnRewardCard3.image.color = new Color(.7f,.7f,.7f,1);
        if (RewardDrops.Count > 3){
            btnRewardCard4.gameObject.SetActive(true);
            btnRewardCard4.image.sprite = RewardDrops[3].Image();
            if (rewardsAssignment[3].CompareTo(localUser.GetName())==0) btnRewardCard4.image.color = Color.white;
            else btnRewardCard4.image.color = new Color(.7f,.7f,.7f,1);
        } else btnRewardCard4.gameObject.SetActive(false);
        if (RewardDrops.Count > 4){
            btnRewardCard5.gameObject.SetActive(true);
            btnRewardCard5.image.sprite = RewardDrops[4].Image();
            if (rewardsAssignment[4].CompareTo(localUser.GetName())==0) btnRewardCard5.image.color = Color.white;
            else btnRewardCard5.image.color = new Color(.7f,.7f,.7f,1);
        } else btnRewardCard5.gameObject.SetActive(false);
        if (RewardDrops.Count > 5){
            btnRewardCard6.gameObject.SetActive(true);
            btnRewardCard6.image.sprite = RewardDrops[5].Image();
            if (rewardsAssignment[5].CompareTo(localUser.GetName())==0) btnRewardCard6.image.color = Color.white;
            else btnRewardCard6.image.color = new Color(.7f,.7f,.7f,1);
        } else btnRewardCard6.gameObject.SetActive(false);
        if (RewardDrops.Count > 6){
            btnRewardCard7.gameObject.SetActive(true);
            btnRewardCard7.image.sprite = RewardDrops[6].Image();
            if (rewardsAssignment[6].CompareTo(localUser.GetName())==0) btnRewardCard7.image.color = Color.white;
            else btnRewardCard7.image.color = new Color(.7f,.7f,.7f,1);
        } else btnRewardCard7.gameObject.SetActive(false);
        if (localUser.IsLead()){
            pnlRewardTgl1.SetActive(true);
            pnlRewardTgl2.SetActive(true);
            pnlRewardTgl3.SetActive(true);
            if (RewardDrops.Count > 3){
                pnlRewardTgl4.SetActive(true);
            } else pnlRewardTgl4.SetActive(false);
            if (RewardDrops.Count > 4){
                pnlRewardTgl5.SetActive(true);
            } else pnlRewardTgl5.SetActive(false);
            if (RewardDrops.Count > 5){
                pnlRewardTgl6.SetActive(true);
            } else pnlRewardTgl6.SetActive(false);
            if (RewardDrops.Count > 6){
                pnlRewardTgl7.SetActive(true);
            } else pnlRewardTgl7.SetActive(false);
            txtRewardP1Name.text = players[0].GetName();
            txtRewardP1Total.text = rewardCount[0] + "/" + rewardTreasure[0];
            if (combatants.Contains(players[1])){
                txtRewardP2Name.text = players[1].GetName();
                txtRewardP2Total.text = rewardCount[1] + "/" + rewardTreasure[1];
                tglP2C1.gameObject.SetActive(true);
                tglP2C2.gameObject.SetActive(true);
                tglP2C3.gameObject.SetActive(true);
                tglP2C4.gameObject.SetActive(true);
                tglP2C5.gameObject.SetActive(true);
                tglP2C6.gameObject.SetActive(true);
                tglP2C7.gameObject.SetActive(true);
            } else {
                txtRewardP2Name.text = "";
                txtRewardP2Total.text = "";
                tglP2C1.gameObject.SetActive(false);
                tglP2C2.gameObject.SetActive(false);
                tglP2C3.gameObject.SetActive(false);
                tglP2C4.gameObject.SetActive(false);
                tglP2C5.gameObject.SetActive(false);
                tglP2C6.gameObject.SetActive(false);
                tglP2C7.gameObject.SetActive(false);
            }
            if (players.Count > 2 && combatants.Contains(players[2])){
                txtRewardP3Name.text = players[2].GetName();
                txtRewardP3Total.text = rewardCount[2] + "/" + rewardTreasure[2];
                tglP3C1.gameObject.SetActive(true);
                tglP3C2.gameObject.SetActive(true);
                tglP3C3.gameObject.SetActive(true);
                tglP3C4.gameObject.SetActive(true);
                tglP3C5.gameObject.SetActive(true);
                tglP3C6.gameObject.SetActive(true);
                tglP3C7.gameObject.SetActive(true);
            } else {
                txtRewardP3Name.text = "";
                txtRewardP3Total.text = "";
                tglP3C1.gameObject.SetActive(false);
                tglP3C2.gameObject.SetActive(false);
                tglP3C3.gameObject.SetActive(false);
                tglP3C4.gameObject.SetActive(false);
                tglP3C5.gameObject.SetActive(false);
                tglP3C6.gameObject.SetActive(false);
                tglP3C7.gameObject.SetActive(false);
            }
            if (players.Count > 3 && combatants.Contains(players[3])){
                txtRewardP4Name.text = players[3].GetName();
                txtRewardP4Total.text = rewardCount[3] + "/" + rewardTreasure[3];
                tglP4C1.gameObject.SetActive(true);
                tglP4C2.gameObject.SetActive(true);
                tglP4C3.gameObject.SetActive(true);
                tglP4C4.gameObject.SetActive(true);
                tglP4C5.gameObject.SetActive(true);
                tglP4C6.gameObject.SetActive(true);
                tglP4C7.gameObject.SetActive(true);
            } else {
                txtRewardP4Name.text = "";
                txtRewardP4Total.text = "";
                tglP4C1.gameObject.SetActive(false);
                tglP4C2.gameObject.SetActive(false);
                tglP4C3.gameObject.SetActive(false);
                tglP4C4.gameObject.SetActive(false);
                tglP4C5.gameObject.SetActive(false);
                tglP4C6.gameObject.SetActive(false);
                tglP4C7.gameObject.SetActive(false);
            }
        } else {
            txtRewardP1Name.text = "";
            txtRewardP2Name.text = "";
            txtRewardP3Name.text = "";
            txtRewardP4Name.text = "";
            txtRewardP1Total.text = "";
            txtRewardP2Total.text = "";
            txtRewardP3Total.text = "";
            txtRewardP4Total.text = "";
            pnlRewardTgl1.SetActive(false);
            pnlRewardTgl2.SetActive(false);
            pnlRewardTgl3.SetActive(false);
            pnlRewardTgl4.SetActive(false);
            pnlRewardTgl5.SetActive(false);
            pnlRewardTgl6.SetActive(false);
            pnlRewardTgl7.SetActive(false);
        }
    }
    void ReloadAspirations(){
        if (vs.AspirationCount(0) > 0)
        btnAspiration1.image.sprite = vs.PeekAspiration(0,aspirationOffset[0]).Image();
        else btnAspiration1.image.sprite = empty;
        if (vs.AspirationCount(1) > 0)
        btnAspiration2.image.sprite = vs.PeekAspiration(1,aspirationOffset[1]).Image();
        else btnAspiration2.image.sprite = empty;
        if (vs.AspirationCount(2) > 0)
        btnAspiration3.image.sprite = vs.PeekAspiration(2,aspirationOffset[2]).Image();
        else btnAspiration3.image.sprite = empty;
        if (vs.AspirationCount(3) > 0)
        btnAspiration4.image.sprite = vs.PeekAspiration(3,aspirationOffset[3]).Image();
        else btnAspiration4.image.sprite = empty;
        if (vs.AspirationCount(0) > 1){
            if (aspirationOffset[0] > 0) btnAsp1ScrollDown.gameObject.SetActive(true);
            else btnAsp1ScrollDown.gameObject.SetActive(false);
            if (aspirationOffset[0] < vs.AspirationCount(0)-1) btnAsp1ScrollUp.gameObject.SetActive(true);
            else btnAsp1ScrollUp.gameObject.SetActive(false);
        } else {
            btnAsp1ScrollDown.gameObject.SetActive(false);
            btnAsp1ScrollUp.gameObject.SetActive(false);
        }
        if (vs.AspirationCount(1) > 1){
            if (aspirationOffset[1] > 0) btnAsp2ScrollDown.gameObject.SetActive(true);
            else btnAsp2ScrollDown.gameObject.SetActive(false);
            if (aspirationOffset[1] < vs.AspirationCount(1)-1) btnAsp2ScrollUp.gameObject.SetActive(true);
            else btnAsp2ScrollUp.gameObject.SetActive(false);
        } else {
            btnAsp2ScrollDown.gameObject.SetActive(false);
            btnAsp2ScrollUp.gameObject.SetActive(false);
        }
        if (vs.AspirationCount(2) > 1){
            if (aspirationOffset[2] > 0) btnAsp3ScrollDown.gameObject.SetActive(true);
            else btnAsp3ScrollDown.gameObject.SetActive(false);
            if (aspirationOffset[2] < vs.AspirationCount(2)-1) btnAsp3ScrollUp.gameObject.SetActive(true);
            else btnAsp3ScrollUp.gameObject.SetActive(false);
        } else {
            btnAsp3ScrollDown.gameObject.SetActive(false);
            btnAsp3ScrollUp.gameObject.SetActive(false);
        }
        if (vs.AspirationCount(3) > 1){
            if (aspirationOffset[3] > 0) btnAsp4ScrollDown.gameObject.SetActive(true);
            else btnAsp4ScrollDown.gameObject.SetActive(false);
            if (aspirationOffset[3] < vs.AspirationCount(3)-1) btnAsp4ScrollUp.gameObject.SetActive(true);
            else btnAsp4ScrollUp.gameObject.SetActive(false);
        } else {
            btnAsp4ScrollDown.gameObject.SetActive(false);
            btnAsp4ScrollUp.gameObject.SetActive(false);
        }
        if (aspirationClaimed[0].CompareTo(localUser.GetName())==0) btnAspiration1.image.color = Color.cyan;
        else if (aspirationClaimed[0].CompareTo("")!=0) btnAspiration1.image.color = Color.magenta;
        else if (conditionsMet[0]) btnAspiration1.image.color = Color.white;
        else btnAspiration1.image.color = Color.gray;
        if (aspirationClaimed[1].CompareTo(localUser.GetName())==0) btnAspiration2.image.color = Color.cyan;
        else if (aspirationClaimed[1].CompareTo("")!=0) btnAspiration2.image.color = Color.magenta;
        else if (conditionsMet[1]) btnAspiration2.image.color = Color.white;
        else btnAspiration2.image.color = Color.gray;
        if (aspirationClaimed[2].CompareTo(localUser.GetName())==0) btnAspiration3.image.color = Color.cyan;
        else if (aspirationClaimed[2].CompareTo("")!=0) btnAspiration3.image.color = Color.magenta;
        else if (conditionsMet[2]) btnAspiration3.image.color = Color.white;
        else btnAspiration3.image.color = Color.gray;
        if (aspirationClaimed[3].CompareTo(localUser.GetName())==0) btnAspiration4.image.color = Color.cyan;
        else if (aspirationClaimed[3].CompareTo("")!=0) btnAspiration4.image.color = Color.magenta;
        else if (conditionsMet[3]) btnAspiration4.image.color = Color.white;
        else btnAspiration4.image.color = Color.gray;
    }
    void CheckClaimConditions(){
        for (int i = 0; i < conditionsMet.Length; i++){
            Aspiration a = vs.PeekAspiration(i,0);
            if (a != null){
                if (a.IsTribute() != null) {conditionsMet[i] = true; continue;}//tributes;
                if (a.HasRogueEquipped()){//Battle-Ready
                    foreach (Equipment e in localUser.GetEquipped()){
                        if (e != null && e.IsRogue()) {conditionsMet[i] = true; break;}
                    } if (conditionsMet[i] == true) continue;
                }
                if (a.HasMageEquipped()){//Battle-Ready
                    foreach (Equipment e in localUser.GetEquipped()){
                        if (e != null && e.IsMage()) {conditionsMet[i] = true; break;}
                    } if (conditionsMet[i] == true) continue;
                }
                if (a.HasWarriorEquipped()){//Battle-Ready
                    foreach (Equipment e in localUser.GetEquipped()){
                        if (e != null && e.IsWarrior()) {conditionsMet[i] = true; break;}
                    } if (conditionsMet[i] == true) continue;
                }
                if (a.HasClericEquipped()){//Battle-Ready
                    foreach (Equipment e in localUser.GetEquipped()){
                        if (e != null && e.IsCleric()) {conditionsMet[i] = true; break;}
                    } if (conditionsMet[i] == true) continue;
                }//Test/Display
                if (a.ExtraCardsToDraw() > 0 && extraDrawnHigh >= a.ExtraCardsToDraw()){
                    conditionsMet[i] = true; continue;
                }//Test/Display
                if (a.PreventDamage() > 0 && damagePreventedHigh >= a.PreventDamage()){
                    conditionsMet[i] = true; continue;
                }//Test/Display
                if (a.DealDamage() > 0 && damageDealtHigh >= a.DealDamage()){
                    conditionsMet[i] = true; continue;
                }//Test/Display
                if (a.PlayCards() > 0 && cardsPlayedHigh >= a.PlayCards()){
                    conditionsMet[i] = true; continue;
                }//Eliminate bounties
                if (a.DefeatMonster() != null && a.DefeatMonster().CompareTo(monsterType)==0){
                    conditionsMet[i] = true; continue;
                }//Path of
                if (a.PlayDefense() > 0 && defensesPlayedHigh >= a.PlayDefense()){
                    conditionsMet[i] = true; continue;
                }//Path of
                if (a.PlayAttack() > 0 && attacksPlayedHigh >= a.PlayAttack()){
                    conditionsMet[i] = true; continue;
                }//Path of
                if (a.PlayTechnique() > 0 && techniquesPlayedHigh >= a.PlayTechnique()){
                    conditionsMet[i] = true; continue;
                }//Path of
                if (a.PlayDifferent() > 0 && typesPlayedHigh >= a.PlayDifferent()){
                    conditionsMet[i] = true; continue;
                }//Spell Slinger
                if (a.PlaySpells() > 0 && a.HaveSpells() > 0 && spellsPlayedHigh >= a.PlaySpells()){
                    int spellCount = 0;
                    foreach (Ability s in localUser.Deck().InspectDeck()) {
                        if (s.GetCardType().CompareTo("Spell") == 0 && s.GetSource().CompareTo("Shop")==0){
                            spellCount++;
                        }
                    }
                    if (spellCount >= a.HaveSpells()){
                        conditionsMet[i] = true; continue;
                    }
                }//Deadly Force
                if (a.DefeatFastTier() > 0 && monsterTier >= a.DefeatFastTier() && noTurnForMonster){
                    conditionsMet[i] = true; continue;
                }//Stalwart
                if (a.HaveArmor() && a.HaveEvade() && a.HaveShields() && a.HavePowerShields()){
                    bool hasArmor = false;
                    bool hasEvade = remainingEvade > 0;
                    bool hasShields = remainingShields > 0;
                    bool hasPowerShields = remainingPowerShields > 0;
                    foreach (Equipment e in localUser.GetEquipped()){
                        if (e != null){
                            hasArmor = hasArmor || e.HasArmor();
                            hasEvade = hasEvade || e.HasEvade();
                            hasShields = hasShields || e.getCurrentShieldValues()[0] > 0;
                            hasPowerShields = hasPowerShields || e.getCurrentShieldValues()[1] > 0;
                        }
                    }
                    if (hasArmor && hasEvade && hasShields && hasPowerShields){
                        conditionsMet[i] = true; continue;
                    }
                }//Contingent
                if (a.HaveRegen() && a.HavePierce() && a.HaveHoming() && a.HaveShieldBreak()){
                    bool hasRegen = false;
                    bool hasHoming = false;
                    bool hasPierce = false;
                    bool hasShieldBreak = false;
                    foreach (Equipment e in localUser.GetEquipped()){
                        if (e != null){
                            hasRegen = hasRegen || e.HasRegen();
                            hasHoming = hasHoming || e.isHoming();
                            hasPierce = hasPierce || e.isPierce();
                            hasShieldBreak = hasShieldBreak || e.hasShieldBreak();
                        }
                    }
                    if (hasRegen && hasHoming && hasPierce && hasShieldBreak){
                        conditionsMet[i] = true; continue;
                    }
                }
            }
        }
        ReloadAspirations();
    }
    void ClaimAspiration(int index){ 
        if (claimTurn){
            //if()
        } 
    }
    void ReloadTrophyView(){
        if (localUser.Trophies().Count > 0){
            btnTrophy1.gameObject.SetActive(true);
            btnTrophy1.image.sprite =  localUser.Trophies()[0+TrophyOffset].Image();
        } else {
            btnTrophy1.gameObject.SetActive(false);
            btnTrophy1.image.sprite = empty;
        }
        if ( localUser.Trophies().Count > 1){
            btnTrophy2.gameObject.SetActive(true);
            btnTrophy2.image.sprite =  localUser.Trophies()[1+TrophyOffset].Image();
        } else {
            btnTrophy2.gameObject.SetActive(false);
            btnTrophy2.image.sprite = empty;
        }
        if ( localUser.Trophies().Count > 2){
            btnTrophy3.gameObject.SetActive(true);
            btnTrophy3.image.sprite =  localUser.Trophies()[2+TrophyOffset].Image();
        } else {
            btnTrophy3.gameObject.SetActive(false);
            btnTrophy3.image.sprite = empty;
        }
        if ( localUser.Trophies().Count > 3){
            if (TrophyOffset > 0) btnTrophyLeftScroll.gameObject.SetActive(true);
            else btnTrophyLeftScroll.gameObject.SetActive(false);
            if (TrophyOffset <  localUser.Trophies().Count-3) btnTrophyRightScroll.gameObject.SetActive(true);
            else btnTrophyRightScroll.gameObject.SetActive(false);
        } else {
            btnTrophyLeftScroll.gameObject.SetActive(false);
            btnTrophyRightScroll.gameObject.SetActive(false);
        }
    }
    void ReloadAspirationView(){
        if (localUser.Aspirations().Count > 0){
            btnAspirationView1.gameObject.SetActive(true);
            btnAspirationView1.image.sprite =  localUser.Aspirations()[0+AspirationViewOffset].Image();
        } else {
            btnAspirationView1.gameObject.SetActive(false);
            btnAspirationView1.image.sprite = empty;
        }
        if ( localUser.Aspirations().Count > 1){
            btnAspirationView2.gameObject.SetActive(true);
            btnAspirationView2.image.sprite =  localUser.Aspirations()[1+AspirationViewOffset].Image();
        } else {
            btnAspirationView2.gameObject.SetActive(false);
            btnAspirationView2.image.sprite = empty;
        }
        if ( localUser.Aspirations().Count > 2){
            btnAspirationView3.gameObject.SetActive(true);
            btnAspirationView3.image.sprite =  localUser.Aspirations()[2+AspirationViewOffset].Image();
        } else {
            btnAspirationView3.gameObject.SetActive(false);
            btnAspirationView3.image.sprite = empty;
        }
        if ( localUser.Aspirations().Count > 3){
            btnAspirationView4.gameObject.SetActive(true);
            btnAspirationView4.image.sprite =  localUser.Aspirations()[3+AspirationViewOffset].Image();
        } else {
            btnAspirationView4.gameObject.SetActive(false);
            btnAspirationView4.image.sprite = empty;
        }
        if ( localUser.Aspirations().Count > 4){
            if (AspirationViewOffset > 0) btnAspirationLeftScroll.gameObject.SetActive(true);
            else btnAspirationLeftScroll.gameObject.SetActive(false);
            if (AspirationViewOffset < localUser.Aspirations().Count-4) btnAspirationRightScroll.gameObject.SetActive(true);
            else btnAspirationRightScroll.gameObject.SetActive(false);
        } else {
            btnAspirationLeftScroll.gameObject.SetActive(false);
            btnAspirationRightScroll.gameObject.SetActive(false);
        }
    }
    void ReloadTributeAbility(){
        tributeAbilities = new List<Ability>();
        foreach (Ability a in localUser.Deck().InspectDeck())
            if (a.GetSource().CompareTo("Shop")==0) tributeAbilities.Add(a);
        if (tributeAbilities.Count >= 1){
            btnTributeAbility1.gameObject.SetActive(true);
            btnTributeAbility1.image.sprite = tributeAbilities[0+tributeAbilityOffset].Image();
        } else {
            btnTributeAbility1.gameObject.SetActive(false);
            btnTributeAbility1.image.sprite = empty;
        }
        if (tributeAbilities.Count >= 2){
            btnTributeAbility2.gameObject.SetActive(true);
            btnTributeAbility2.image.sprite = tributeAbilities[1+tributeAbilityOffset].Image();
        } else {
            btnTributeAbility2.gameObject.SetActive(false);
            btnTributeAbility2.image.sprite = empty;
        }
        if (tributeAbilities.Count >= 3){
            btnTributeAbility3.gameObject.SetActive(true);
            btnTributeAbility3.image.sprite = tributeAbilities[2+tributeAbilityOffset].Image();
        } else {
            btnTributeAbility3.gameObject.SetActive(false);
            btnTributeAbility3.image.sprite = empty;
        }
        if (tributeAbilities.Count >= 4){
            btnTributeAbility4.gameObject.SetActive(true);
            btnTributeAbility4.image.sprite = tributeAbilities[3+tributeAbilityOffset].Image();
        } else {
            btnTributeAbility4.gameObject.SetActive(false);
            btnTributeAbility4.image.sprite = empty;
        }
        if (tributeAbilities.Count > 4){
            if (tributeAbilityOffset > 0) btnTributeAbilityLeftScroll.gameObject.SetActive(true);
            else btnTributeAbilityLeftScroll.gameObject.SetActive(false);
            if (tributeAbilityOffset < tributeAbilities.Count-4) btnTributeAbilityRightScroll.gameObject.SetActive(true);
            else btnTributeAbilityRightScroll.gameObject.SetActive(false);
        } else {
            btnTributeAbilityLeftScroll.gameObject.SetActive(false);
            btnTributeAbilityRightScroll.gameObject.SetActive(false);
        }
    }
    void ReloadTributeItem(){
        tributeItems = new List<Equipment>();
        foreach (Equipment e in localUser.Arsenal())
            if (e.GetSource().CompareTo("Basic")!=0) tributeItems.Add(e);
        if (tributeItems.Count >= 1){
            btnTributeEquipment1.gameObject.SetActive(true);
            btnTributeEquipment1.image.sprite = tributeItems[0+tributeEquipmentOffset].Image();
        } else {
            btnTributeEquipment1.gameObject.SetActive(false);
            btnTributeEquipment1.image.sprite = empty;
        }
        if (tributeItems.Count >= 2){
            btnTributeEquipment2.gameObject.SetActive(true);
            btnTributeEquipment2.image.sprite = tributeItems[1+tributeEquipmentOffset].Image();
        } else {
            btnTributeEquipment2.gameObject.SetActive(false);
            btnTributeEquipment2.image.sprite = empty;
        }
        if (tributeItems.Count >= 3){
            btnTributeEquipment3.gameObject.SetActive(true);
            btnTributeEquipment3.image.sprite = tributeItems[2+tributeEquipmentOffset].Image();
        } else {
            btnTributeEquipment3.gameObject.SetActive(false);
            btnTributeEquipment3.image.sprite = empty;
        }
        if (tributeItems.Count >= 4){
            btnTributeEquipment4.gameObject.SetActive(true);
            btnTributeEquipment4.image.sprite = tributeItems[3+tributeEquipmentOffset].Image();
        } else {
            btnTributeEquipment4.gameObject.SetActive(false);
            btnTributeEquipment4.image.sprite = empty;
        }
        if (tributeItems.Count > 4){
            if (tributeEquipmentOffset > 0) btnTributeEquipmentLeftScroll.gameObject.SetActive(true);
            else btnTributeEquipmentLeftScroll.gameObject.SetActive(false);
            if (tributeEquipmentOffset < tributeItems.Count-4) btnTributeEquipmentRightScroll.gameObject.SetActive(true);
            else btnTributeEquipmentRightScroll.gameObject.SetActive(false);
        } else {
            btnTributeEquipmentLeftScroll.gameObject.SetActive(false);
            btnTributeEquipmentRightScroll.gameObject.SetActive(false);
        }
    }
    void ReloadTributeTrophy(){
        tributeTrophies = localUser.Trophies();
        if (tributeTrophies.Count >= 1){
            btnTributeTrophy1.gameObject.SetActive(true);
            btnTributeTrophy1.image.sprite = tributeTrophies[0+tributeTrophyOffset].Image();
        } else {
            btnTributeTrophy1.gameObject.SetActive(false);
            btnTributeTrophy1.image.sprite = empty;
        }
        if (tributeTrophies.Count >= 2){
            btnTributeTrophy2.gameObject.SetActive(true);
            btnTributeTrophy2.image.sprite = tributeTrophies[1+tributeTrophyOffset].Image();
        } else {
            btnTributeTrophy2.gameObject.SetActive(false);
            btnTributeTrophy2.image.sprite = empty;
        }
        if (tributeTrophies.Count >= 3){
            btnTributeTrophy3.gameObject.SetActive(true);
            btnTributeTrophy3.image.sprite = tributeTrophies[2+tributeTrophyOffset].Image();
        } else {
            btnTributeTrophy3.gameObject.SetActive(false);
            btnTributeTrophy3.image.sprite = empty;
        }
        if (tributeTrophies.Count > 3){
            if (tributeTrophyOffset > 0) btnTributeTrophyLeftScroll.gameObject.SetActive(true);
            else btnTributeTrophyLeftScroll.gameObject.SetActive(false);
            if (tributeTrophyOffset < tributeTrophies.Count-3) btnTributeTrophyRightScroll.gameObject.SetActive(true);
            else btnTributeTrophyRightScroll.gameObject.SetActive(false);
        } else {
            btnTributeTrophyLeftScroll.gameObject.SetActive(false);
            btnTributeTrophyRightScroll.gameObject.SetActive(false);
        }
    }
    void ReloadTradeMenu(){
        txtTradeLocalName.text = localUser.GetName();
        txtTradeOtherName.text = tradePartner.GetName();
        txtTradeGoldLocal.text = ""+tradeGoldPlayer;
        txtTradeGoldOther.text = ""+tradeGoldOther;
        txtTradeVPLocal.text = ""+tradeVPPlayer;
        txtTradeVPOther.text = ""+tradeVPOther;
        if (tradeAcceptedOther) btnTradeActiveAccept.GetComponentInChildren<Text>().color = Color.green;
        else btnTradeActiveAccept.GetComponentInChildren<Text>().color = Color.black;
        if (tradeAbility1Player != null) btnTradeAbility1.GetComponentInChildren<Text>().text = tradeAbility1Player.getName();
        else  btnTradeAbility1.GetComponentInChildren<Text>().text = "";
        if (tradeAbility2Player != null) btnTradeAbility2.GetComponentInChildren<Text>().text = tradeAbility2Player.getName();
        else  btnTradeAbility2.GetComponentInChildren<Text>().text = "";
        if (tradeAspiration1Player != null) btnTradeAspiration1.GetComponentInChildren<Text>().text = tradeAspiration1Player.GetName();
        else  btnTradeAspiration1.GetComponentInChildren<Text>().text = "";
        if (tradeAspiration2Player != null) btnTradeAspiration2.GetComponentInChildren<Text>().text = tradeAspiration2Player.GetName();
        else  btnTradeAspiration2.GetComponentInChildren<Text>().text = "";
        if (tradeItem1Player != null) btnTradeItem1.GetComponentInChildren<Text>().text = tradeItem1Player.getName();
        else  btnTradeItem1.GetComponentInChildren<Text>().text = "";
        if (tradeItem2Player != null) btnTradeItem2.GetComponentInChildren<Text>().text = tradeItem2Player.getName();
        else  btnTradeItem2.GetComponentInChildren<Text>().text = "";
        if (tradeTrophy1Player != null) btnTradeTrophy1.GetComponentInChildren<Text>().text = tradeTrophy1Player.GetName();
        else  btnTradeTrophy1.GetComponentInChildren<Text>().text = "";
        if (tradeTrophy2Player != null) btnTradeTrophy2.GetComponentInChildren<Text>().text = tradeTrophy2Player.GetName();
        else  btnTradeTrophy2.GetComponentInChildren<Text>().text = "";
        if (tradeAbility1Other != null) txtTradeAbility1.text = tradeAbility1Other;
        else  txtTradeAbility1.text = "";
        if (tradeAbility2Other != null) txtTradeAbility2.text = tradeAbility2Other;
        else  txtTradeAbility2.text = "";
        if (tradeAspiration1Other != null) txtTradeAspiration1.text = tradeAspiration1Other;
        else  txtTradeAspiration1.text = "";
        if (tradeAspiration2Other != null) txtTradeAspiration2.text = tradeAspiration2Other;
        else  txtTradeAspiration2.text = "";
        if (tradeItem1Other != null) txtTradeItem1.text = tradeItem1Other;
        else  txtTradeItem1.text = "";
        if (tradeItem2Other != null) txtTradeItem2.text = tradeItem2Other;
        else  txtTradeItem2.text = "";
        if (tradeTrophy1Other != null) txtTradeTrophy1.text = tradeTrophy1Other;
        else  txtTradeTrophy1.text = "";
        if (tradeTrophy2Other != null) txtTradeTrophy2.text = tradeTrophy2Other;
        else  txtTradeTrophy2.text = "";
        if (tradeGoldPlayer > 0) btnTradeGoldDecrement.gameObject.SetActive(true);
        else btnTradeGoldDecrement.gameObject.SetActive(false);
        if (tradeGoldPlayer < localUser.getGold()) btnTradeGoldIncrement.gameObject.SetActive(true);
        else btnTradeGoldIncrement.gameObject.SetActive(false);
        if (tradeVPPlayer > 0) btnTradeVPDecrement.gameObject.SetActive(true);
        else btnTradeVPDecrement.gameObject.SetActive(false);
        if (tradeVPPlayer < localUser.getVP()) btnTradeVPIncrement.gameObject.SetActive(true);
        else btnTradeVPIncrement.gameObject.SetActive(false);
    }
    void ReloadTradeAspirations(){
        viewTradeAspirationSelect = localUser.Aspirations();
        if (viewTradeAspirationSelect.Count > 0){
            btnTradeAspirationSelectView1.gameObject.SetActive(true);
            btnTradeAspirationSelectView1.image.sprite =  viewTradeAspirationSelect[0+TradeAspirationSelectViewOffset].Image();
        } else {
            btnTradeAspirationSelectView1.gameObject.SetActive(false);
            btnTradeAspirationSelectView1.image.sprite = empty;
        }
        if ( viewTradeAspirationSelect.Count > 1){
            btnTradeAspirationSelectView2.gameObject.SetActive(true);
            btnTradeAspirationSelectView2.image.sprite =  viewTradeAspirationSelect[1+TradeAspirationSelectViewOffset].Image();
        } else {
            btnTradeAspirationSelectView2.gameObject.SetActive(false);
            btnTradeAspirationSelectView2.image.sprite = empty;
        }
        if ( viewTradeAspirationSelect.Count > 2){
            btnTradeAspirationSelectView3.gameObject.SetActive(true);
            btnTradeAspirationSelectView3.image.sprite =  viewTradeAspirationSelect[2+TradeAspirationSelectViewOffset].Image();
        } else {
            btnTradeAspirationSelectView3.gameObject.SetActive(false);
            btnTradeAspirationSelectView3.image.sprite = empty;
        }
        if ( viewTradeAspirationSelect.Count > 3){
            btnTradeAspirationSelectView4.gameObject.SetActive(true);
            btnTradeAspirationSelectView4.image.sprite =  viewTradeAspirationSelect[3+TradeAspirationSelectViewOffset].Image();
        } else {
            btnTradeAspirationSelectView4.gameObject.SetActive(false);
            btnTradeAspirationSelectView4.image.sprite = empty;
        }
        if ( viewTradeAspirationSelect.Count > 4){
            if (TradeAspirationSelectViewOffset > 0) btnTradeAspirationSelectLeftScroll.gameObject.SetActive(true);
            else btnTradeAspirationSelectLeftScroll.gameObject.SetActive(false);
            if (TradeAspirationSelectViewOffset < viewTradeAspirationSelect.Count-4) btnTradeAspirationSelectRightScroll.gameObject.SetActive(true);
            else btnTradeAspirationSelectRightScroll.gameObject.SetActive(false);
        } else {
            btnTradeAspirationSelectLeftScroll.gameObject.SetActive(false);
            btnTradeAspirationSelectRightScroll.gameObject.SetActive(false);
        }
    }
    void ReloadTradeTrophies(){
        viewTradeTrophySelect = localUser.Trophies();
        if (viewTradeTrophySelect.Count > 0){
            btnTradeTrophySelect1.gameObject.SetActive(true);
            btnTradeTrophySelect1.image.sprite =  viewTradeTrophySelect[0+TradeTrophySelectOffset].Image();
        } else {
            btnTradeTrophySelect1.gameObject.SetActive(false);
            btnTradeTrophySelect1.image.sprite = empty;
        }
        if ( viewTradeTrophySelect.Count > 1){
            btnTradeTrophySelect2.gameObject.SetActive(true);
            btnTradeTrophySelect2.image.sprite =  viewTradeTrophySelect[1+TradeTrophySelectOffset].Image();
        } else {
            btnTradeTrophySelect2.gameObject.SetActive(false);
            btnTradeTrophySelect2.image.sprite = empty;
        }
        if ( viewTradeTrophySelect.Count > 2){
            btnTradeTrophySelect3.gameObject.SetActive(true);
            btnTradeTrophySelect3.image.sprite =  viewTradeTrophySelect[2+TradeTrophySelectOffset].Image();
        } else {
            btnTradeTrophySelect3.gameObject.SetActive(false);
            btnTradeTrophySelect3.image.sprite = empty;
        }
        if ( viewTradeTrophySelect.Count > 3){
            if (TradeTrophySelectOffset > 0) btnTradeTrophySelectLeftScroll.gameObject.SetActive(true);
            else btnTradeTrophySelectLeftScroll.gameObject.SetActive(false);
            if (TradeTrophySelectOffset <  viewTradeTrophySelect.Count-3) btnTradeTrophySelectRightScroll.gameObject.SetActive(true);
            else btnTradeTrophySelectRightScroll.gameObject.SetActive(false);
        } else {
            btnTradeTrophySelectLeftScroll.gameObject.SetActive(false);
            btnTradeTrophySelectRightScroll.gameObject.SetActive(false);
        }
    }
    void ReloadTradeItems(){
        viewTradeItemSelect = new List<Equipment>();
        foreach (Equipment e in localUser.Arsenal()) {
            if (e.GetSource().CompareTo("Basic")!=0) viewTradeItemSelect.Add(e);
        }
        if (viewTradeItemSelect.Count > 0){
            btnTradeItemSelect1.gameObject.SetActive(true);
            btnTradeItemSelect1.image.sprite =  viewTradeItemSelect[0+TradeItemSelectOffset].Image();
        } else {
            btnTradeItemSelect1.gameObject.SetActive(false);
            btnTradeItemSelect1.image.sprite = empty;
        }
        if ( viewTradeItemSelect.Count > 1){
            btnTradeItemSelect2.gameObject.SetActive(true);
            btnTradeItemSelect2.image.sprite =  viewTradeItemSelect[1+TradeItemSelectOffset].Image();
        } else {
            btnTradeItemSelect2.gameObject.SetActive(false);
            btnTradeItemSelect2.image.sprite = empty;
        }
        if ( viewTradeItemSelect.Count > 2){
            btnTradeItemSelect3.gameObject.SetActive(true);
            btnTradeItemSelect3.image.sprite =  viewTradeItemSelect[2+TradeItemSelectOffset].Image();
        } else {
            btnTradeItemSelect3.gameObject.SetActive(false);
            btnTradeItemSelect3.image.sprite = empty;
        }
        if ( viewTradeItemSelect.Count > 3){
            btnTradeItemSelect4.gameObject.SetActive(true);
            btnTradeItemSelect4.image.sprite =  viewTradeItemSelect[3+TradeItemSelectOffset].Image();
        } else {
            btnTradeItemSelect4.gameObject.SetActive(false);
            btnTradeItemSelect4.image.sprite = empty;
        }
        if ( viewTradeItemSelect.Count > 4){
            btnTradeItemSelect5.gameObject.SetActive(true);
            btnTradeItemSelect5.image.sprite =  viewTradeItemSelect[4+TradeItemSelectOffset].Image();
        } else {
            btnTradeItemSelect5.gameObject.SetActive(false);
            btnTradeItemSelect5.image.sprite = empty;
        }
        if ( viewTradeItemSelect.Count > 5){
            btnTradeItemSelect6.gameObject.SetActive(true);
            btnTradeItemSelect6.image.sprite =  viewTradeItemSelect[5+TradeItemSelectOffset].Image();
        } else {
            btnTradeItemSelect6.gameObject.SetActive(false);
            btnTradeItemSelect6.image.sprite = empty;
        }
        if ( viewTradeItemSelect.Count > 6){
            if (TradeItemSelectOffset > 0) btnTradeItemSelectLeftScroll.gameObject.SetActive(true);
            else btnTradeItemSelectLeftScroll.gameObject.SetActive(false);
            if (TradeItemSelectOffset <  viewTradeItemSelect.Count-6) btnTradeItemSelectRightScroll.gameObject.SetActive(true);
            else btnTradeItemSelectRightScroll.gameObject.SetActive(false);
        } else {
            btnTradeItemSelectLeftScroll.gameObject.SetActive(false);
            btnTradeItemSelectRightScroll.gameObject.SetActive(false);
        }
    }
    void ReloadTradeAbilities(){
        viewTradeAbilitySelect = new List<Ability>();
        foreach (Ability a in localUser.Deck().InspectDeck()){
            if (a.GetSource().CompareTo("Shop")==0) viewTradeAbilitySelect.Add(a);
        }
        if (viewTradeAbilitySelect.Count > 0){
            btnTradeAbilitySelect1.gameObject.SetActive(true);
            btnTradeAbilitySelect1.image.sprite =  viewTradeAbilitySelect[0+TradeAbilitySelectOffset].Image();
        } else {
            btnTradeAbilitySelect1.gameObject.SetActive(false);
            btnTradeAbilitySelect1.image.sprite = empty;
        }
        if ( viewTradeAbilitySelect.Count > 1){
            btnTradeAbilitySelect2.gameObject.SetActive(true);
            btnTradeAbilitySelect2.image.sprite =  viewTradeAbilitySelect[1+TradeAbilitySelectOffset].Image();
        } else {
            btnTradeAbilitySelect2.gameObject.SetActive(false);
            btnTradeAbilitySelect2.image.sprite = empty;
        }
        if ( viewTradeAbilitySelect.Count > 2){
            btnTradeAbilitySelect3.gameObject.SetActive(true);
            btnTradeAbilitySelect3.image.sprite =  viewTradeAbilitySelect[2+TradeAbilitySelectOffset].Image();
        } else {
            btnTradeAbilitySelect3.gameObject.SetActive(false);
            btnTradeAbilitySelect3.image.sprite = empty;
        }
        if ( viewTradeAbilitySelect.Count > 3){
            btnTradeAbilitySelect4.gameObject.SetActive(true);
            btnTradeAbilitySelect4.image.sprite =  viewTradeAbilitySelect[3+TradeAbilitySelectOffset].Image();
        } else {
            btnTradeAbilitySelect4.gameObject.SetActive(false);
            btnTradeAbilitySelect4.image.sprite = empty;
        }
        if ( viewTradeAbilitySelect.Count > 4){
            btnTradeAbilitySelect5.gameObject.SetActive(true);
            btnTradeAbilitySelect5.image.sprite =  viewTradeAbilitySelect[4+TradeAbilitySelectOffset].Image();
        } else {
            btnTradeAbilitySelect5.gameObject.SetActive(false);
            btnTradeAbilitySelect5.image.sprite = empty;
        }
        if ( viewTradeAbilitySelect.Count > 5){
            btnTradeAbilitySelect6.gameObject.SetActive(true);
            btnTradeAbilitySelect6.image.sprite =  viewTradeAbilitySelect[5+TradeAbilitySelectOffset].Image();
        } else {
            btnTradeAbilitySelect6.gameObject.SetActive(false);
            btnTradeAbilitySelect6.image.sprite = empty;
        }
        if ( viewTradeAbilitySelect.Count > 6){
            if (TradeAbilitySelectOffset > 0) btnTradeAbilitySelectLeftScroll.gameObject.SetActive(true);
            else btnTradeAbilitySelectLeftScroll.gameObject.SetActive(false);
            if (TradeAbilitySelectOffset < viewTradeAbilitySelect.Count-6) btnTradeAbilitySelectRightScroll.gameObject.SetActive(true);
            else btnTradeAbilitySelectRightScroll.gameObject.SetActive(false);
        } else {
            btnTradeAbilitySelectLeftScroll.gameObject.SetActive(false);
            btnTradeAbilitySelectRightScroll.gameObject.SetActive(false);
        }
    }
    void ResetTrade(){
        tradeGoldPlayer = 0; 
        tradeGoldOther = 0; 
        tradeVPPlayer = 0; 
        tradeVPOther = 0;
        tradeAspiration1Player = null; 
        tradeAspiration2Player = null;
        tradeAbility1Player = null; 
        tradeAbility2Player = null;
        tradeTrophy1Player = null;
        tradeTrophy2Player = null;
        tradeItem1Player = null; 
        tradeItem2Player = null;
        tradeAspiration1Other = null; 
        tradeAspiration2Other = null;
        tradeAbility1Other = null; 
        tradeAbility2Other = null;
        tradeTrophy1Other = null; 
        tradeTrophy2Other = null;
        tradeItem1Other = null; 
        tradeItem2Other = null;
        tradePartner = null;
        tradeAcceptedPlayer = false; 
        tradeAcceptedOther = false;
        pnlTradeAbilitySelectView.SetActive(false);
        pnlTradeActive.SetActive(false);
        pnlTradeAspirationSelectView.SetActive(false);
        pnlTradeItemSelectView.SetActive(false);
        pnlTradeOffer.SetActive(false);
        pnlTradeTrophySelectView.SetActive(false);
    }
    void CompleteTrade(){
        localUser.changeGold(tradeGoldOther - tradeGoldPlayer);
        localUser.changeVP(tradeVPOther - tradeVPPlayer);
        if (tradeAspiration1Player!= null) localUser.RemoveAspiration(tradeAspiration1Player);
        if (tradeAspiration2Player!= null) localUser.RemoveAspiration(tradeAspiration2Player);
        if (tradeAbility1Player!= null) localUser.Deck().Remove(tradeAbility1Player);
        if (tradeAbility2Player!= null) localUser.Deck().Remove(tradeAbility2Player);
        if (tradeItem1Player!= null) localUser.RemoveItem(tradeItem1Player);
        if (tradeItem2Player!= null) localUser.RemoveItem(tradeItem2Player);
        if (tradeTrophy1Player!= null) localUser.Trophies().Remove(tradeTrophy1Player);
        if (tradeTrophy2Player!= null) localUser.Trophies().Remove(tradeTrophy2Player);
        if (tradeAspiration1Other!= null || tradeAspiration2Other!= null ) {
            foreach (Aspiration a in vs.GetAspirations()){
                if (tradeAspiration1Other!= null)
                    if (a.GetName().CompareTo(tradeAspiration1Other)==0) localUser.AddAspiration(a.Clone());
                if (tradeAspiration2Other!= null)
                    if (a.GetName().CompareTo(tradeAspiration2Other)==0) localUser.AddAspiration(a.Clone());
            }
        }
        if (tradeAbility1Other!= null || tradeAbility2Other!= null){
            foreach (Ability a in vs.GetShopAbilities()){
                if (tradeAbility1Other!= null)
                    if (a.getName().CompareTo(tradeAbility1Other)==0) localUser.Deck().Add(a.Clone());
                if (tradeAbility2Other!= null)
                    if (a.getName().CompareTo(tradeAbility2Other)==0) localUser.Deck().Add(a.Clone());
            }
        }
        if (tradeTrophy1Other!= null || tradeTrophy2Other!= null){
            foreach (Monster t in vs.getMonList()){
                if (tradeAbility1Other!= null)
                    if (t.GetName().CompareTo(tradeTrophy1Other)==0) localUser.Trophies().Add(t.Clone());
                if (tradeAbility2Other!= null)
                    if (t.GetName().CompareTo(tradeTrophy2Other)==0) localUser.Trophies().Add(t.Clone());
            }
        }
        if (tradeItem1Other!= null || tradeItem2Other!= null) {
            foreach (Equipment e in vs.GetCommonEquipment()){
                if (tradeItem1Other!= null) {
                    if (e.getName().CompareTo(tradeItem1Other.Split(':')[0])==0){ 
                        if (tradeItem1Other.Split(':')[0].CompareTo("Tome")==0){
                            Equipment temp = e.Clone();
                            foreach (Ability a in vs.GetShopAbilities()){
                                if (a.getName().CompareTo(tradeItem1Other.Split(':')[1])==0) {
                                    temp.linkAbility(a.Clone());
                                    localUser.Arsenal().Add(temp);
                                }
                            }
                        } else localUser.Arsenal().Add(e.Clone());
                    }
                }
                if (tradeItem2Other!= null) {
                    if (e.getName().CompareTo(tradeItem2Other.Split(':')[0])==0){ 
                        if (tradeItem2Other.Split(':')[0].CompareTo("Tome")==0){
                            Equipment temp = e.Clone();
                            foreach (Ability a in vs.GetShopAbilities()){
                                if (a.getName().CompareTo(tradeItem2Other.Split(':')[1])==0) {
                                    temp.linkAbility(a.Clone());
                                    localUser.Arsenal().Add(temp);
                                }
                            }
                        } else localUser.Arsenal().Add(e.Clone());
                    }
                }
            }
            foreach (Equipment e in vs.GetQualityEquipment()){
                if (tradeItem1Other!= null)
                    if (e.getName().CompareTo(tradeItem1Other)==0) localUser.Arsenal().Add(e.Clone());
                if (tradeItem2Other!= null)
                    if (e.getName().CompareTo(tradeItem2Other)==0) localUser.Arsenal().Add(e.Clone());
            }
        }
        ResetTrade();
    }
    void ClassAbility(){
        // Cleric limited to during the damage prevention portion of monster attack
        //Everyone else, limited to their turn, and once per turn.
        if (localUser.GetPlayerClass().AbilityUsed() == false){
            if ((localUser.IsTurn()&& playerClass.CompareTo("Cleric")!=0)|| (playerClass.CompareTo("Cleric")==0 && monsterAttacking)){
                pnlClassDiscard.SetActive(true);
                CDOffset = 0;
                ReloadClassDiscard();
            }
        }
    }
    void ReloadClassDiscard(){
        CDCards = new List<Ability>();
        if (playerClass.CompareTo("Warrior")==0)
            foreach (Ability a in inHand){
                if (a.isDefense()) CDCards.Add(a);
            }
        if (playerClass.CompareTo("Cleric")==0)
            foreach (Ability a in inHand){
                if (a.isAttack()) CDCards.Add(a);
            }
        if (playerClass.CompareTo("Rogue")==0)
            foreach (Ability a in inHand){
                if (a.isTechnique()) CDCards.Add(a);
            }
        if (playerClass.CompareTo("Mage")==0)
            CDCards = inHand;
        if (CDCards.Count > 0){
            btnCD1.gameObject.SetActive(true);
            btnCD1.image.sprite = CDCards[0+CDOffset].Image();
        } else {
            btnCD1.gameObject.SetActive(false);
            btnCD1.image.sprite = empty;
        }
        if (CDCards.Count > 1){
            btnCD2.gameObject.SetActive(true);
            btnCD2.image.sprite = CDCards[1+CDOffset].Image();
        } else {
            btnCD2.gameObject.SetActive(false);
            btnCD2.image.sprite = empty;
        }
        if (CDCards.Count > 2){
            btnCD3.gameObject.SetActive(true);
            btnCD3.image.sprite = CDCards[2+CDOffset].Image();
        } else {
            btnCD3.gameObject.SetActive(false);
            btnCD3.image.sprite = empty;
        }
        if (CDCards.Count > 3){
            btnCD4.gameObject.SetActive(true);
            btnCD4.image.sprite = CDCards[3+CDOffset].Image();
        } else {
            btnCD4.gameObject.SetActive(false);
            btnCD4.image.sprite = empty;
        }
        if (CDCards.Count > 4){
            if (CDOffset > 0) btnCDLeft.gameObject.SetActive(true);
            else btnCDLeft.gameObject.SetActive(false);
            if (CDOffset < CDCards.Count-4) btnCDRight.gameObject.SetActive(true);
            else btnCDRight.gameObject.SetActive(false);
        } else {
            btnCDLeft.gameObject.SetActive(false);
            btnCDRight.gameObject.SetActive(false);
        }
    }
    void PerformClassAbility(int index){
        pnlClassDiscard.SetActive(false);
        Ability temp = CDCards[index + CDOffset];
        inHand.Remove(temp);
        ReloadHand();
        localUser.Deck().Discard(temp);
        ReloadDiscard();
        localUser.Write("*CHAT,"+localUser.GetName()+" used "+localUser.GetPlayerClass().getAbilityName());
        if (playerClass.CompareTo("Mage")==0){
            inHand.Add(localUser.Deck().Draw());
            extraDrawn++;
            if (extraDrawn > extraDrawnHigh) extraDrawnHigh = extraDrawn;
        } else if (playerClass.CompareTo("Rogue")==0){
            localUser.changeAP(1);
        } else if (playerClass.CompareTo("Warrior")==0){
            skillBoost += temp.getSymbolsForWarrior();
        } else if (playerClass.CompareTo("Cleric")==0){
            clericDamagePrevent = temp.getSymbolsForCleric();
            pnlPrevent.SetActive(true);
        }
    }    
    void ReloadPrevent(){
        txtPreventP1.text = localUser.GetName();
        txtPreventAvailable.text = ""+clericDamagePrevent;
        txtPreventAmountP1.text = assignedPrevention[0]+"/"+damageBeingDealt[0];
        if (clericDamagePrevent == 0){
            btnP1R.gameObject.SetActive(false);
            btnP2R.gameObject.SetActive(false);
            btnP3R.gameObject.SetActive(false);
            btnP4R.gameObject.SetActive(false);
        } else {
            btnP1R.gameObject.SetActive(true);
            btnP2R.gameObject.SetActive(true);
            btnP3R.gameObject.SetActive(true);
            btnP4R.gameObject.SetActive(true);
        }
        if (assignedPrevention[0] == damageBeingDealt[0]) btnP1R.gameObject.SetActive(false);
        if (assignedPrevention[1] == damageBeingDealt[1]) btnP2R.gameObject.SetActive(false);
        if (assignedPrevention[2] == damageBeingDealt[2]) btnP3R.gameObject.SetActive(false);
        if (assignedPrevention[3] == damageBeingDealt[3]) btnP4R.gameObject.SetActive(false);
        if (assignedPrevention[0] == 0) btnP1L.gameObject.SetActive(false);
        else btnP1L.gameObject.SetActive(true);
        if (assignedPrevention[1] == 0) btnP2L.gameObject.SetActive(false);
        else btnP2L.gameObject.SetActive(true);
        if (assignedPrevention[2] == 0) btnP3L.gameObject.SetActive(false);
        else btnP3L.gameObject.SetActive(true);
        if (assignedPrevention[3] == 0) btnP4L.gameObject.SetActive(false);
        else btnP4L.gameObject.SetActive(true);
        if (combatants.Contains(players[1])) { 
            txtPreventP2.gameObject.SetActive(true);
            txtPreventP2.text = players[1].GetName();
            txtPreventAmountP2.text = assignedPrevention[1]+"/"+damageBeingDealt[1];
        } else txtPreventP2.gameObject.SetActive(false);
        if (combatants.Contains(players[2])) { 
            txtPreventP3.gameObject.SetActive(true);
            txtPreventP3.text = players[2].GetName();
            txtPreventAmountP3.text = assignedPrevention[2]+"/"+damageBeingDealt[2];
        } else txtPreventP3.gameObject.SetActive(false);
        if (combatants.Contains(players[3])) { 
            txtPreventP4.gameObject.SetActive(true);
            txtPreventP4.text = players[3].GetName();
            txtPreventAmountP4.text = assignedPrevention[3]+"/"+damageBeingDealt[3];
        } else txtPreventP4.gameObject.SetActive(false);
    }
    void ReloadBossLobby(){
        bool allReady = true;
        txtBLP1Name.text = players[0].GetName();
        if (joiningBoss[0]) txtBLP1Name.color = Color.green;
        else if (passingBoss[0]) txtBLP1Name.color = Color.red;
        else allReady = false;
        txtBLP2Name.text = players[1].GetName();
        if (joiningBoss[1]) txtBLP2Name.color = Color.green;
        else if (passingBoss[1]) txtBLP2Name.color = Color.red;
        else allReady = false;
        if (players.Count >= 3){
            txtBLP3Name.text = players[2].GetName();
            if (joiningBoss[2]) txtBLP3Name.color = Color.green;
            else if (passingBoss[2]) txtBLP3Name.color = Color.red;
            else allReady = false;
        } else txtBLP3Name.gameObject.SetActive(false);
        if (players.Count >= 4){
            txtBLP4Name.text = players[3].GetName();
            if (joiningBoss[3]) txtBLP4Name.color = Color.green;
            else if (passingBoss[3]) txtBLP4Name.color = Color.red;
            else allReady = false;
        } else txtBLP4Name.gameObject.SetActive(false);
        if (allReady && localUser.IsLead()) btnBLReady.gameObject.SetActive(true);
        else btnBLReady.gameObject.SetActive(false);
    }

}
