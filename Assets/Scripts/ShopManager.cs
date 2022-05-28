using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ShopManager : MonoBehaviour
{
    public Button finished;
    public Image rdy1;
    public Image rdy2;
    public Image rdy3;
    public Image rdy4;
    Player localUser;
    List<Player> players;
    //Initial shop
    public GameObject pnlInitialShop;
    public Button btnCommon1, btnCommon2, btnCommon3, btnCommon4, btnCommon5, btnCommon6, btnCommon7, btnCommon8;
    //Special shop
    public GameObject pnlSpecial;
    public Button btnExplodePot, btnHealthPot;
    //Default shop
    public GameObject pnlShop;
    public Button btnEquip1, btnEquip2, btnEquip3, btnEquip4, btnAbility1, btnAbility2, 
        btnAbility3, btnAbility4, btnAbility5, btnAbility6, btnAbility7, btnAbility8;
    // Gold and VP
    public Text txtGold, txtVP;
    ValueStorage vs;
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
    //Viewers
    //Deck
    public GameObject pnlDeckView;
    public Button btnDeckView, btnDeckCancel, btnDeckLeftScroll, btnDeckRightScroll,
            btnDeck1, btnDeck2, btnDeck3, btnDeck4, btnDeck5, btnDeck6;
    int DeckOffset = 0;
    //Arsenal
    public GameObject pnlArsenalView;
    public Button btnArsenalView, btnArsenalCancel, btnArsenalLeftScroll, btnArsenalRightScroll,
            btnArsenal1, btnArsenal2, btnArsenal3, btnArsenal4, btnArsenal5, btnArsenal6;
    int ArsenalOffset = 0;
    //Aspiration Viewer
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
                btnAspiration4, btnAsp4ScrollUp, btnAsp4ScrollDown;
    int[] aspirationOffset = new int[]{0,0,0,0};
    //SellWindow
    public GameObject pnlSeller, pnlAdder;
    public Button btnSellConfirm, btnSellCancel, btnAddToDeck;
    public Text txtSellMessage;
    public GameObject pnlPurchase;
    public Button btnPurchaseConfirm, btnPurchaseCancel, btnPurchaseReserve;
    public Image imgPurchasePreview;
    //class elements
    public Button btnWarriorClass, btnMageClass, btnClericClass, btnRogueClass;
    public GameObject pnlClasses;
    //Class Aquisition
    public GameObject pnlClassAquisition;
    public Button btnCAAspiration1, btnCAAspiration2, btnCAConfirm, btnCACancel,
            btnCAItem1, btnCAItem2, btnCAItem3, btnCAItem4,
            btnCATrophy1, btnCATrophy2, btnCATrophy3, btnCATrophy4;
    public Text txtWarriorGemCount, txtClericGemCount, txtRogueGemCount, txtMageGemCount;
    //Gem Offer panels
    public GameObject pnlClassItem, pnlClassAspiration, pnlClassTrophy;
    public Button btnClassItem1, btnClassItem2, btnClassItem3, btnClassItem4,
            btnClassItemCancel, btnClassItemRemove, btnClassItemLeft, btnClassItemRight,
            btnClassTrophy1, btnClassTrophy2, btnClassTrophy3,
            btnClassTrophyCancel, btnClassTrophyRemove, btnClassTrophyLeft, btnClassTrophyRight,
            btnClassAspiration1, btnClassAspiration2, btnClassAspiration3,
            btnClassAspirationCancel, btnClassAspirationRemove, btnClassAspirationLeft, btnClassAspirationRight;

    //Other Variables

    List<Equipment> initShop = new List<Equipment>();
    List<Equipment> ShopEquipment = new List<Equipment>();
    List<Ability> ShopAbilities = new List<Ability>();
    List<Ability> viewDeck = new List<Ability>();
    List<Equipment> viewArsenal = new List<Equipment>();
    List<Monster> viewTrophy = new List<Monster>();
    List<Aspiration> viewAspirations = new List<Aspiration>();
    List<Equipment> viewClassItem = new List<Equipment>();
    List<Monster> viewClassTrophy = new List<Monster>();
    List<Aspiration> viewClassAspiration = new List<Aspiration>();
    List<Equipment> selectedClassItem = new List<Equipment>();
    List<Monster> selectedClassTrophy = new List<Monster>();
    List<Aspiration> selectedClassAspiration = new List<Aspiration>();
    string TargetClass = null;
    int ClassAspirationOffset = 0;
    int ClassItemOffset = 0;
    int ClassTrophyOffset = 0;
    Equipment HealthPot;
    Equipment ExplodingPot;
    public Sprite empty;
    Equipment EquipmentBeingSold = null;
    Ability AbilityBeingSold = null;
    Monster TrophyBeingSold = null;
    Equipment EquipmentBeingPurchased = null;
    Ability AbilityBeingPurchased = null;
    Equipment EquipmentInReserve = null;
    Ability AbilityInReserve = null;
    List<Equipment> AllReserved = new List<Equipment>();
    List<Ability> AllReservedAbilities = new List<Ability>();
    int pendingSlot = 0;
    PlayerClass warrior = null;
    PlayerClass cleric = null;
    PlayerClass rogue = null;
    PlayerClass mage = null;

    

    // Start is called before the first frame update
    void Start()
    {
        //Instantiating variables
        vs = GameObject.Find("NetworkManager").GetComponent<ValueStorage>();
        localUser = vs.getLocalPlayer();
        players = vs.GetPlayers();
        finished.onClick.AddListener(ReadyPlayer);
        for (int i = 0; i < players.Count; i++)
            players[i].IsReady(false);
        if (players.Count < 4)
            rdy4.enabled = false;
        if (players.Count < 3)
            rdy3.enabled = false;
        if (vs.isInitialShop()){
            pnlInitialShop.SetActive(true);
            pnlShop.SetActive(false);
        } else {
            pnlInitialShop.SetActive(false);
            pnlShop.SetActive(true);
        }
        //Loads in listeners for all buttons

        //Initial shop
        btnCommon1.onClick.AddListener(delegate{EquipmentBeingPurchased = initShop[0]; pnlPurchase.SetActive(true); imgPurchasePreview.sprite = EquipmentBeingPurchased.Image();});
        btnCommon2.onClick.AddListener(delegate{EquipmentBeingPurchased = initShop[1]; pnlPurchase.SetActive(true); imgPurchasePreview.sprite = EquipmentBeingPurchased.Image();});
        btnCommon3.onClick.AddListener(delegate{EquipmentBeingPurchased = initShop[2]; pnlPurchase.SetActive(true); imgPurchasePreview.sprite = EquipmentBeingPurchased.Image();});
        btnCommon4.onClick.AddListener(delegate{EquipmentBeingPurchased = initShop[3]; pnlPurchase.SetActive(true); imgPurchasePreview.sprite = EquipmentBeingPurchased.Image();});
        btnCommon5.onClick.AddListener(delegate{EquipmentBeingPurchased = initShop[4]; pnlPurchase.SetActive(true); imgPurchasePreview.sprite = EquipmentBeingPurchased.Image();});
        btnCommon6.onClick.AddListener(delegate{EquipmentBeingPurchased = initShop[5]; pnlPurchase.SetActive(true); imgPurchasePreview.sprite = EquipmentBeingPurchased.Image();});
        btnCommon7.onClick.AddListener(delegate{EquipmentBeingPurchased = initShop[6]; pnlPurchase.SetActive(true); imgPurchasePreview.sprite = EquipmentBeingPurchased.Image();});
        btnCommon8.onClick.AddListener(delegate{EquipmentBeingPurchased = initShop[7]; pnlPurchase.SetActive(true); imgPurchasePreview.sprite = EquipmentBeingPurchased.Image();});
        btnPurchaseCancel.onClick.AddListener(delegate{EquipmentBeingPurchased = null; AbilityBeingPurchased = null; pnlPurchase.SetActive(false); imgPurchasePreview.sprite = empty;});
        btnPurchaseConfirm.onClick.AddListener(delegate{
            if (EquipmentBeingPurchased != null) PurchaseEquipment(EquipmentBeingPurchased);
            if (AbilityBeingPurchased != null) PurchaseAbility(AbilityBeingPurchased);});
        btnPurchaseReserve.onClick.AddListener(delegate{Reserve(EquipmentBeingPurchased, AbilityBeingPurchased);});
        //Special shop, including loading the items
        foreach (Equipment e in vs.GetSpecialEquipment()){
            if (e.getName().CompareTo("Exploding Potion")==0){
                ExplodingPot = e;
            } else HealthPot = e;
        }
        btnHealthPot.onClick.AddListener(delegate{PurchaseSpecial(HealthPot);});
        btnExplodePot.onClick.AddListener(delegate{PurchaseSpecial(ExplodingPot);});
        btnHealthPot.image.sprite = HealthPot.Image();
        btnExplodePot.image.sprite = ExplodingPot.Image();
        //Main Shop
        btnEquip1.onClick.AddListener(delegate{EquipmentBeingPurchased = ShopEquipment[0]; pnlPurchase.SetActive(true); imgPurchasePreview.sprite = EquipmentBeingPurchased.Image();});
        btnEquip2.onClick.AddListener(delegate{EquipmentBeingPurchased = ShopEquipment[1]; pnlPurchase.SetActive(true); imgPurchasePreview.sprite = EquipmentBeingPurchased.Image();});
        btnEquip3.onClick.AddListener(delegate{EquipmentBeingPurchased = ShopEquipment[2]; pnlPurchase.SetActive(true); imgPurchasePreview.sprite = EquipmentBeingPurchased.Image();});
        btnEquip4.onClick.AddListener(delegate{EquipmentBeingPurchased = ShopEquipment[3]; pnlPurchase.SetActive(true); imgPurchasePreview.sprite = EquipmentBeingPurchased.Image();});
        btnAbility1.onClick.AddListener(delegate{AbilityBeingPurchased = ShopAbilities[0]; pnlPurchase.SetActive(true); imgPurchasePreview.sprite = AbilityBeingPurchased.Image();});
        btnAbility2.onClick.AddListener(delegate{AbilityBeingPurchased = ShopAbilities[1]; pnlPurchase.SetActive(true); imgPurchasePreview.sprite = AbilityBeingPurchased.Image();});
        btnAbility3.onClick.AddListener(delegate{AbilityBeingPurchased = ShopAbilities[2]; pnlPurchase.SetActive(true); imgPurchasePreview.sprite = AbilityBeingPurchased.Image();});
        btnAbility4.onClick.AddListener(delegate{AbilityBeingPurchased = ShopAbilities[3]; pnlPurchase.SetActive(true); imgPurchasePreview.sprite = AbilityBeingPurchased.Image();});
        btnAbility5.onClick.AddListener(delegate{AbilityBeingPurchased = ShopAbilities[4]; pnlPurchase.SetActive(true); imgPurchasePreview.sprite = AbilityBeingPurchased.Image();});
        btnAbility6.onClick.AddListener(delegate{AbilityBeingPurchased = ShopAbilities[5]; pnlPurchase.SetActive(true); imgPurchasePreview.sprite = AbilityBeingPurchased.Image();});
        btnAbility7.onClick.AddListener(delegate{AbilityBeingPurchased = ShopAbilities[6]; pnlPurchase.SetActive(true); imgPurchasePreview.sprite = AbilityBeingPurchased.Image();});
        btnAbility8.onClick.AddListener(delegate{AbilityBeingPurchased = ShopAbilities[7]; pnlPurchase.SetActive(true); imgPurchasePreview.sprite = AbilityBeingPurchased.Image();});
        //Trade
        btnTradeP2.onClick.AddListener(delegate{tradePartner = players[1]; 
            pnlTradeOffer.SetActive(true);
            btnTradeOfferAccept.gameObject.SetActive(false);
            btnTradeOfferReject.gameObject.SetActive(false);
            btnTradeOfferCancel.gameObject.SetActive(true);
            txtTradeOfferMessage.text = "Trade Request sent to "+tradePartner.GetName();
            localUser.Write("*TRADEREQUEST,"+tradePartner.GetName()+","+localUser.GetName());
        });
        btnTradeP2.onClick.AddListener(delegate{tradePartner = players[2]; 
            pnlTradeOffer.SetActive(true);
            btnTradeOfferAccept.gameObject.SetActive(false);
            btnTradeOfferReject.gameObject.SetActive(false);
            btnTradeOfferCancel.gameObject.SetActive(true);
            txtTradeOfferMessage.text = "Trade Request sent to "+tradePartner.GetName();
            localUser.Write("*TRADEREQUEST,"+tradePartner.GetName()+","+localUser.GetName());
        });
        btnTradeP2.onClick.AddListener(delegate{tradePartner = players[3]; 
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
        //Browse and sell from Deck
        btnDeckView.onClick.AddListener(delegate{pnlDeckView.SetActive(true);ReloadDeckView();});
        btnDeckCancel.onClick.AddListener(delegate{pnlDeckView.SetActive(false);DeckOffset=0;});
        btnDeckLeftScroll.onClick.AddListener(delegate{DeckOffset--;ReloadDeckView();});
        btnDeckRightScroll.onClick.AddListener(delegate{DeckOffset++;ReloadDeckView();});
        btnDeck1.onClick.AddListener(delegate{SellAbility(viewDeck[DeckOffset]);});
        btnDeck2.onClick.AddListener(delegate{SellAbility(viewDeck[1+DeckOffset]);});
        btnDeck3.onClick.AddListener(delegate{SellAbility(viewDeck[2+DeckOffset]);});
        btnDeck4.onClick.AddListener(delegate{SellAbility(viewDeck[3+DeckOffset]);});
        btnDeck5.onClick.AddListener(delegate{SellAbility(viewDeck[4+DeckOffset]);});
        btnDeck6.onClick.AddListener(delegate{SellAbility(viewDeck[5+DeckOffset]);});
        //Browse and sell from Arsenal
        btnArsenalView.onClick.AddListener(delegate{pnlArsenalView.SetActive(true);ReloadArsenalView();});
        btnArsenalCancel.onClick.AddListener(delegate{pnlArsenalView.SetActive(false);ArsenalOffset=0;});
        btnArsenalLeftScroll.onClick.AddListener(delegate{ArsenalOffset--;ReloadArsenalView();});
        btnArsenalRightScroll.onClick.AddListener(delegate{ArsenalOffset++;ReloadArsenalView();});
        btnArsenal1.onClick.AddListener(delegate{SellEquipment(viewArsenal[ArsenalOffset]);});
        btnArsenal2.onClick.AddListener(delegate{SellEquipment(viewArsenal[1+ArsenalOffset]);});
        btnArsenal3.onClick.AddListener(delegate{SellEquipment(viewArsenal[2+ArsenalOffset]);});
        btnArsenal4.onClick.AddListener(delegate{SellEquipment(viewArsenal[3+ArsenalOffset]);});
        btnArsenal5.onClick.AddListener(delegate{SellEquipment(viewArsenal[4+ArsenalOffset]);});
        btnArsenal6.onClick.AddListener(delegate{SellEquipment(viewArsenal[5+ArsenalOffset]);});
        //Browse and sell from Trophies
        btnTrophyView.onClick.AddListener(delegate{pnlTrophyView.SetActive(true);ReloadTrophyView();});
        btnTrophyCancel.onClick.AddListener(delegate{pnlTrophyView.SetActive(false);TrophyOffset=0;});
        btnTrophyLeftScroll.onClick.AddListener(delegate{TrophyOffset--;ReloadTrophyView();});
        btnTrophyRightScroll.onClick.AddListener(delegate{TrophyOffset++;ReloadTrophyView();});
        btnTrophy1.onClick.AddListener(delegate{SellTrophy(viewTrophy[TrophyOffset]);});
        btnTrophy2.onClick.AddListener(delegate{SellTrophy(viewTrophy[1+TrophyOffset]);});
        btnTrophy3.onClick.AddListener(delegate{SellTrophy(viewTrophy[2+TrophyOffset]);});
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
        //Claiming a class
        btnWarriorClass.onClick.AddListener(delegate{TargetClass = "Warrior";pnlClassAquisition.SetActive(true);ReloadClassAquisition();});
        btnClericClass.onClick.AddListener(delegate{TargetClass = "Cleric";pnlClassAquisition.SetActive(true);ReloadClassAquisition();});
        btnRogueClass.onClick.AddListener(delegate{TargetClass = "Rogue";pnlClassAquisition.SetActive(true);ReloadClassAquisition();});
        btnMageClass.onClick.AddListener(delegate{TargetClass = "Mage";pnlClassAquisition.SetActive(true);ReloadClassAquisition();});
        btnCAAspiration1.onClick.AddListener(delegate{pendingSlot = 1;pnlClassAspiration.SetActive(true);ClassAspirationOffset = 0;ReloadClassAspirations();});
        btnCAAspiration2.onClick.AddListener(delegate{pendingSlot = 2;pnlClassAspiration.SetActive(true);ClassAspirationOffset = 0;ReloadClassAspirations();});
        btnCATrophy1.onClick.AddListener(delegate{pendingSlot = 1;pnlClassTrophy.SetActive(true);ClassTrophyOffset = 0;ReloadClassTrophies();});
        btnCATrophy2.onClick.AddListener(delegate{pendingSlot = 2;pnlClassTrophy.SetActive(true);ClassTrophyOffset = 0;ReloadClassTrophies();});
        btnCATrophy3.onClick.AddListener(delegate{pendingSlot = 3;pnlClassTrophy.SetActive(true);ClassTrophyOffset = 0;ReloadClassTrophies();});
        btnCATrophy4.onClick.AddListener(delegate{pendingSlot = 4;pnlClassTrophy.SetActive(true);ClassTrophyOffset = 0;ReloadClassTrophies();});
        btnCAItem1.onClick.AddListener(delegate{pendingSlot = 1;pnlClassItem.SetActive(true);ClassItemOffset = 0;ReloadClassItems();});
        btnCAItem2.onClick.AddListener(delegate{pendingSlot = 2;pnlClassItem.SetActive(true);ClassItemOffset = 0;ReloadClassItems();});
        btnCAItem3.onClick.AddListener(delegate{pendingSlot = 3;pnlClassItem.SetActive(true);ClassItemOffset = 0;ReloadClassItems();});
        btnCAItem4.onClick.AddListener(delegate{pendingSlot = 4;pnlClassItem.SetActive(true);ClassItemOffset = 0;ReloadClassItems();});
        btnCAConfirm.onClick.AddListener(delegate{TradeForClass();});
        btnCACancel.onClick.AddListener(delegate{TargetClass = null; pnlClassAquisition.SetActive(false);
            selectedClassAspiration = null; selectedClassItem = null; selectedClassTrophy = null;});
        btnClassAspiration1.onClick.AddListener(delegate{
            if (selectedClassAspiration.Count >= pendingSlot) selectedClassAspiration.RemoveAt(pendingSlot-1);
            selectedClassAspiration.Add(viewClassAspiration[0+ClassAspirationOffset]);
            pnlClassAspiration.SetActive(false);
            ClassAspirationOffset = 0;
            pendingSlot = 0;
            ReloadClassAquisition();
        });
        btnClassAspiration2.onClick.AddListener(delegate{
            if (selectedClassAspiration.Count >= pendingSlot) selectedClassAspiration.RemoveAt(pendingSlot-1);
            selectedClassAspiration.Add(viewClassAspiration[1+ClassAspirationOffset]);
            pnlClassAspiration.SetActive(false);
            ClassAspirationOffset = 0;
            pendingSlot = 0;
            ReloadClassAquisition();
        });
        btnClassAspiration3.onClick.AddListener(delegate{
            if (selectedClassAspiration.Count >= pendingSlot) selectedClassAspiration.RemoveAt(pendingSlot-1);
            selectedClassAspiration.Add(viewClassAspiration[2+ClassAspirationOffset]);
            pnlClassAspiration.SetActive(false);
            ClassAspirationOffset = 0;
            pendingSlot = 0;
            ReloadClassAquisition();
        });
        btnClassAspirationLeft.onClick.AddListener(delegate{ClassAspirationOffset--;ReloadClassAspirations();});
        btnClassAspirationRight.onClick.AddListener(delegate{ClassAspirationOffset++;ReloadClassAspirations();});
        btnClassAspirationRemove.onClick.AddListener(delegate{
            if (selectedClassAspiration.Count >= pendingSlot) selectedClassAspiration.RemoveAt(pendingSlot-1);
            pnlClassAspiration.SetActive(false);
            pendingSlot = 0;
            ReloadClassAquisition();
        });
        btnClassAspirationCancel.onClick.AddListener(delegate{
            pnlClassAspiration.SetActive(false);
            ClassAspirationOffset = 0;
            pendingSlot = 0;
        });
        btnClassItem1.onClick.AddListener(delegate{
            if (selectedClassItem.Count >= pendingSlot) selectedClassItem.RemoveAt(pendingSlot-1);
            selectedClassItem.Add(viewClassItem[0+ClassItemOffset]);
            pnlClassItem.SetActive(false);
            ClassItemOffset = 0;
            pendingSlot = 0;
            ReloadClassAquisition();
        });
        btnClassItem2.onClick.AddListener(delegate{
            if (selectedClassItem.Count >= pendingSlot) selectedClassItem.RemoveAt(pendingSlot-1);
            selectedClassItem.Add(viewClassItem[1+ClassItemOffset]);
            pnlClassItem.SetActive(false);
            ClassItemOffset = 0;
            pendingSlot = 0;
            ReloadClassAquisition();
        });
        btnClassItem3.onClick.AddListener(delegate{
            if (selectedClassItem.Count >= pendingSlot) selectedClassItem.RemoveAt(pendingSlot-1);
            selectedClassItem.Add(viewClassItem[2+ClassItemOffset]);
            pnlClassItem.SetActive(false);
            ClassItemOffset = 0;
            pendingSlot = 0;
            ReloadClassAquisition();
        });
        btnClassItem4.onClick.AddListener(delegate{
            if (selectedClassItem.Count >= pendingSlot) selectedClassItem.RemoveAt(pendingSlot-1);
            selectedClassItem.Add(viewClassItem[3+ClassItemOffset]);
            pnlClassItem.SetActive(false);
            ClassItemOffset = 0;
            pendingSlot = 0;
            ReloadClassAquisition();
        });
        btnClassItemLeft.onClick.AddListener(delegate{ClassItemOffset--;ReloadClassItems();});
        btnClassItemRight.onClick.AddListener(delegate{ClassItemOffset++;ReloadClassItems();});
        btnClassItemRemove.onClick.AddListener(delegate{
            if (selectedClassItem.Count >= pendingSlot) selectedClassItem.RemoveAt(pendingSlot-1);
            pnlClassItem.SetActive(false);
            ClassItemOffset = 0;
            pendingSlot = 0;
            ReloadClassAquisition();
        });
        btnClassItemCancel.onClick.AddListener(delegate{
            pnlClassItem.SetActive(false);
            ClassItemOffset = 0;
            pendingSlot = 0;
        });
        btnClassTrophy1.onClick.AddListener(delegate{
            if (selectedClassTrophy.Count >= pendingSlot) selectedClassTrophy.RemoveAt(pendingSlot-1);
            selectedClassTrophy.Add(viewClassTrophy[0+ClassTrophyOffset]);
            pnlClassTrophy.SetActive(false);
            ClassTrophyOffset = 0;
            pendingSlot = 0;
            ReloadClassAquisition();
        });
        btnClassTrophy2.onClick.AddListener(delegate{
            if (selectedClassTrophy.Count >= pendingSlot) selectedClassTrophy.RemoveAt(pendingSlot-1);
            selectedClassTrophy.Add(viewClassTrophy[0+ClassTrophyOffset]);
            pnlClassTrophy.SetActive(false);
            ClassTrophyOffset = 0;
            pendingSlot = 0;
            ReloadClassAquisition();
        });
        btnClassTrophy3.onClick.AddListener(delegate{
            if (selectedClassTrophy.Count >= pendingSlot) selectedClassTrophy.RemoveAt(pendingSlot-1);
            selectedClassTrophy.Add(viewClassTrophy[0+ClassTrophyOffset]);
            pnlClassTrophy.SetActive(false);
            ClassTrophyOffset = 0;
            pendingSlot = 0;
            ReloadClassAquisition();
        });
        btnClassTrophyLeft.onClick.AddListener(delegate{ClassTrophyOffset--;ReloadClassTrophies();});
        btnClassTrophyRight.onClick.AddListener(delegate{ClassTrophyOffset++;ReloadClassTrophies();});
        btnClassTrophyRemove.onClick.AddListener(delegate{
            if (selectedClassTrophy.Count >= pendingSlot) selectedClassTrophy.RemoveAt(pendingSlot-1);
            pnlClassTrophy.SetActive(false);
            ClassTrophyOffset = 0;
            pendingSlot = 0;
            ReloadClassAquisition();
        });
        btnClassTrophyCancel.onClick.AddListener(delegate{
            pnlClassTrophy.SetActive(false);
            ClassTrophyOffset = 0;
            pendingSlot = 0;
        });
        //Seller
        btnSellConfirm.onClick.AddListener(delegate{ 
            if (EquipmentBeingSold != null){
                localUser.changeGold(EquipmentBeingSold.getValue()/2);
                localUser.Arsenal().Remove(EquipmentBeingSold);
                ReloadArsenalView();
            } else if (AbilityBeingSold != null){
                localUser.changeGold(AbilityBeingSold.getValue()/2);
                localUser.Deck().Remove(AbilityBeingSold);
                ReloadDeckView();
            } else if (TrophyBeingSold != null){
                localUser.changeGold(TrophyBeingSold.GetSellValue()/2);
                localUser.Trophies().Remove(TrophyBeingSold);
                ReloadTrophyView();
            } pnlSeller.SetActive(false); pnlAdder.SetActive(false); TrophyBeingSold = null; EquipmentBeingSold = null; AbilityBeingSold = null;});
        btnSellCancel.onClick.AddListener(delegate{ pnlSeller.SetActive(false); pnlAdder.SetActive(false);
            EquipmentBeingSold = null; TrophyBeingSold = null; AbilityBeingSold = null;});
        btnAddToDeck.onClick.AddListener(delegate{pnlSeller.SetActive(false); pnlAdder.SetActive(false);
            localUser.Deck().Add(EquipmentBeingSold.getLinkedAbility()); 
            localUser.Arsenal().Remove(EquipmentBeingSold); viewArsenal.Remove(EquipmentBeingSold);
            EquipmentBeingSold = null; ReloadArsenalView();});
        localUser.Write("*SETUP");
    }

    // Update is called once per frame
    void Update()
    {
        //Displays checks for cennected players and makes them green when ready
        if (players[0].IsReady())
            rdy1.color = Color.green; else rdy1.color = Color.black;
        if (players[1].IsReady())
            rdy2.color = Color.green; else rdy2.color = Color.black;
        if (players.Count > 2 && players[2].IsReady())
            rdy3.color = Color.green; else rdy3.color = Color.black;
        if (players.Count > 3 && players[3].IsReady())
            rdy4.color = Color.green; else rdy4.color = Color.black;

        txtGold.text = ""+localUser.getGold();
        txtVP.text = ""+localUser.getVP();

        //Checks for receipt of message
        if(localUser.GetNetStream().DataAvailable){
            //By using a loop for received, any messages that arrive too close 
            //      together are broken up to be processed separately.
            string received = localUser.Read();
            Debug.Log(received);
            string[] result = received.Split('/');
            for (int r = 0; r < result.Length; r++){
                if (result[r].CompareTo("")==0) break;
                string[] message = result[r].Split(',');

                //For recieving the ready call, meaning a player is finished shopping.
                if (message[0].CompareTo("*READY") == 0) {
                    for (int i = 0; i < players.Count; i++){
                        if (players[i] != null){
                            players[i].IsReady(false);
                            for (int j = 1; j < message.Length; j++){
                                if (players[i].GetName().CompareTo(message[j])==0)
                                    players[i].IsReady(true);
                            }
                        }
                    }
                }
                if (message[0].CompareTo("*ASPIRATIONLIST") == 0){
                    for (int i = 1; i < message.Length; i++){
                        foreach (Aspiration a in vs.GetAspirations()){
                            if (a.GetName().CompareTo(message[i])==0){
                                vs.PushAspiration(i-1,a.Clone()); break;
                            }
                        }
                    }
                    ReloadAspirations();
                }
                if (message[0].CompareTo("*CLAIMCLASS") == 0){
                    if (TargetClass != null && message[1].CompareTo(TargetClass)==0){
                        pnlClassAquisition.SetActive(false);
                        pnlClassAspiration.SetActive(false);
                        pnlClassItem.SetActive(false);
                        pnlClassTrophy.SetActive(false);
                        selectedClassAspiration = null;
                        selectedClassItem = null;
                        selectedClassTrophy = null;
                    }
                    foreach (PlayerClass pc in vs.getAvailableClasses()){
                        if (pc.getName().CompareTo(message[1])==0){
                            vs.getAvailableClasses().Remove(pc);
                        }
                    }
                    ReloadClasses();
                }
                if (message[0].CompareTo("*TRADEREQUEST") == 0){
                    if (tradePartner != null){
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
                if (message[0].CompareTo("*LIST") == 0){
                    if (vs.isInitialShop()){ //initial shop has 8 common equipment.
                        string ablt = null;
                        for (int i = 1; i < message.Length; i++){
                            ablt = null;
                            foreach (Equipment e in vs.GetCommonEquipment()){
                                if (message[i].Contains(":")){
                                    ablt = message[i].Split(':')[1];
                                    message[i] = message[i].Split(':')[0];
                                }
                                if (e.getName().CompareTo(message[i])==0){
                                    Equipment temp = e.Clone();
                                    initShop.Add(temp);
                                    if (ablt != null){
                                        foreach(Ability a in vs.GetShopAbilities())
                                            if (a.getName().CompareTo(ablt)==0){
                                                Ability tempA = a.Clone();
                                                temp.linkAbility(tempA);
                                                break;
                                            }
                                    }            
                                    break;
                                }
                            }
                        }
                        ReloadInitShop();
                    } else {
                        string ablt = null;
                        for (int i = 1; i < message.Length; i++){
                            ablt = null;
                            if (i<5) {
                                foreach (Equipment e in vs.GetCommonEquipment()){
                                    if (message[i].Contains(":")){
                                        ablt = message[i].Split(':')[1];
                                        message[i] = message[i].Split(':')[0];
                                    }
                                    if (e.getName().CompareTo(message[i])==0){
                                        Equipment temp = e.Clone();
                                        ShopEquipment.Add(temp);
                                        if (ablt != null){
                                            foreach(Ability a in vs.GetShopAbilities())
                                                if (a.getName().CompareTo(ablt)==0){
                                                    Ability tempA = a.Clone();
                                                    temp.linkAbility(tempA);
                                                    break;
                                                }
                                        }            
                                        break;
                                    }
                                }
                                foreach (Equipment e in vs.GetQualityEquipment())
                                if (e.getName().CompareTo(message[i])==0){
                                        Equipment temp = e.Clone();
                                        ShopEquipment.Add(temp);break;}
                            } else {
                                foreach (Ability a in vs.GetShopAbilities())
                                if (a.getName().CompareTo(message[i])==0){
                                    Ability tempA = a.Clone();
                                    ShopAbilities.Add(tempA);break;}
                            }
                        }
                        ReloadShop();
                    }
                } 
                if (message[0].CompareTo("*REMOVE") == 0) {
                    if (vs.isInitialShop()){
                    foreach (Equipment e in initShop) 
                        if (e.getName().CompareTo(message[1])==0) {
                            if (EquipmentBeingPurchased != null && e.getName().CompareTo(EquipmentBeingPurchased.getName())==0) pnlPurchase.SetActive(false);
                            if (EquipmentInReserve != null && e.getName().CompareTo(EquipmentInReserve.getName())==0) {EquipmentInReserve = null; localUser.changeGold(1);}
                                if (AllReserved.Contains(e)) AllReserved.Remove(e);
                                initShop.Remove(e); ReloadInitShop(); break;}
                    } else{
                    foreach (Equipment e in ShopEquipment) 
                        if (e.getName().CompareTo(message[1])==0){
                            if (EquipmentBeingPurchased != null && e.getName().CompareTo(EquipmentBeingPurchased.getName())==0) pnlPurchase.SetActive(false);
                            if (EquipmentInReserve != null && e.getName().CompareTo(EquipmentInReserve.getName())==0) {EquipmentInReserve = null; localUser.changeGold(1);}
                                if (AllReserved.Contains(e)) AllReserved.Remove(e);
                            ShopEquipment.Remove(e); break;}
                    foreach (Ability a in ShopAbilities) 
                        if (a.getName().CompareTo(message[1])==0){
                            if (AbilityBeingPurchased != null && a.getName().CompareTo(AbilityBeingPurchased.getName())==0) pnlPurchase.SetActive(false);
                            if (AbilityInReserve != null && a.getName().CompareTo(AbilityInReserve.getName())==0) {AbilityInReserve = null; localUser.changeGold(1);}
                                if (AllReservedAbilities.Contains(a)) AllReservedAbilities.Remove(a);
                            ShopAbilities.Remove(a); break;}
                    ReloadShop();
                    }
                }
                if (message[0].CompareTo("*RESERVE") == 0) {
                    foreach (Equipment e in initShop) 
                        if (e.getName().CompareTo(message[1])==0 && AllReserved.Contains(e)==false)
                            {AllReserved.Add(e); break;}
                    foreach (Equipment e in ShopEquipment) 
                        if (e.getName().CompareTo(message[1])==0 && AllReserved.Contains(e)==false)
                            {AllReserved.Add(e); break;}
                    foreach (Ability a in ShopAbilities) 
                        if (a.getName().CompareTo(message[1])==0 && AllReservedAbilities.Contains(a)==false)
                            {AllReservedAbilities.Add(a); break;}
                    ReloadInitShop();
                    ReloadShop();
                }
                if (message[0].CompareTo("*START") == 0) {
                    vs.isInitialShop(false);
                    Debug.Log("Proceed to dungeon!");
                    SceneManager.LoadScene("Dungeon");
                }
                if (message[0].CompareTo("*BOSS") == 0) {
                    Debug.Log("Proceed to boss!");
                    SceneManager.LoadScene("Boss");
                }
            }
        }
    }
    void ReadyPlayer(){
        localUser.Write("*READY");
    }
    void PurchaseSpecial(Equipment e){
        if (localUser.getGold() >= e.getValue()){
            localUser.Arsenal().Add(e);
            localUser.changeGold(e.getValue()*-1);
        }
    }
    void PurchaseEquipment(Equipment e){
        if (localUser.getGold() >= e.getValue()){
            localUser.Arsenal().Add(e);
            localUser.changeGold(e.getValue()*-1);
            localUser.Write("*PURCHASE,"+e.getName());
            EquipmentBeingPurchased = null;
            pnlPurchase.SetActive(false);
            ReloadArsenalView();
        }
    }
    void PurchaseAbility(Ability a){
        if (localUser.getGold() >= a.getValue()){
            localUser.Deck().Add(a);
            localUser.changeGold(a.getValue()*-1);
            localUser.Write("*PURCHASE,"+a.getName());
            AbilityBeingPurchased = null;
            pnlPurchase.SetActive(false);
            ReloadDeckView();
        }
    }
    void SellEquipment(Equipment e){
        if (e.IsBasic() == false){
            EquipmentBeingSold = e;
            pnlSeller.SetActive(true);
            txtSellMessage.text = "Sell "+ e.getName() +" for "+ e.getValue()/2 +" Gold?";
            if (e.GetEquipType()[1].CompareTo("Tome")==0){
                pnlAdder.SetActive(true);
            }
        }
    }
    void SellAbility(Ability a){
        if (a.IsBasicOrClass() == false){
            AbilityBeingSold = a;
            pnlSeller.SetActive(true);
            txtSellMessage.text = "Sell "+ a.getName() +" for "+ a.getValue()/2 +" Gold?";
        }
    }
    void SellTrophy(Monster t){
        TrophyBeingSold = t;
        pnlSeller.SetActive(true);
        txtSellMessage.text = "Sell "+ t.GetName() +" for "+ t.GetSellValue()/2 +" Gold?";
    }
    void ReloadInitShop(){
        if (initShop.Count > 0) {
            btnCommon1.gameObject.SetActive(true);
            btnCommon1.image.sprite = initShop[0].Image();
            if (AllReserved.Contains(initShop[0])) btnCommon1.image.color = Color.cyan;
            else btnCommon1.image.color = Color.white;
        } else {
            btnCommon1.image.sprite = empty;
            btnCommon1.gameObject.SetActive(false);
        }
        if (initShop.Count > 1) {
            btnCommon2.gameObject.SetActive(true);
            btnCommon2.image.sprite = initShop[1].Image();
            if (AllReserved.Contains(initShop[1])) btnCommon2.image.color = Color.cyan;
            else btnCommon2.image.color = Color.white;
        } else {
            btnCommon2.image.sprite = empty;
            btnCommon2.gameObject.SetActive(false);
        }
        if (initShop.Count > 2) {
            btnCommon3.gameObject.SetActive(true);
            btnCommon3.image.sprite = initShop[2].Image();
            if (AllReserved.Contains(initShop[2])) btnCommon3.image.color = Color.cyan;
            else btnCommon3.image.color = Color.white;
        } else {
            btnCommon3.image.sprite = empty;
            btnCommon3.gameObject.SetActive(false);
        }
        if (initShop.Count > 3) {
            btnCommon4.gameObject.SetActive(true);
            btnCommon4.image.sprite = initShop[3].Image();
            if (AllReserved.Contains(initShop[3])) btnCommon4.image.color = Color.cyan;
            else btnCommon4.image.color = Color.white;
        } else {
            btnCommon4.image.sprite = empty;
            btnCommon4.gameObject.SetActive(false);
        }
        if (initShop.Count > 4) {
            btnCommon5.gameObject.SetActive(true);
            btnCommon5.image.sprite = initShop[4].Image();
            if (AllReserved.Contains(initShop[4])) btnCommon5.image.color = Color.cyan;
            else btnCommon5.image.color = Color.white;
        } else {
            btnCommon5.image.sprite = empty;
            btnCommon5.gameObject.SetActive(false);
        }
        if (initShop.Count > 5) {
            btnCommon6.gameObject.SetActive(true);
            btnCommon6.image.sprite = initShop[5].Image();
            if (AllReserved.Contains(initShop[5])) btnCommon6.image.color = Color.cyan;
            else btnCommon6.image.color = Color.white;
        } else {
            btnCommon6.image.sprite = empty;
            btnCommon6.gameObject.SetActive(false);
        }
        if (initShop.Count > 6) {
            btnCommon7.gameObject.SetActive(true);
            btnCommon7.image.sprite = initShop[6].Image();
            if (AllReserved.Contains(initShop[6])) btnCommon7.image.color = Color.cyan;
            else btnCommon7.image.color = Color.white;
        } else {
            btnCommon7.image.sprite = empty;
            btnCommon7.gameObject.SetActive(false);
        }
        if (initShop.Count > 7) {
            btnCommon8.gameObject.SetActive(true);
            btnCommon8.image.sprite = initShop[7].Image();
            if (AllReserved.Contains(initShop[7])) btnCommon8.image.color = Color.cyan;
            else btnCommon8.image.color = Color.white;
        } else {
            btnCommon8.image.sprite = empty;
            btnCommon8.gameObject.SetActive(false);
        }
    }
    void ReloadShop(){
        if (ShopEquipment.Count > 0) {
            btnEquip1.gameObject.SetActive(true);
            btnEquip1.image.sprite = ShopEquipment[0].Image();
            if (AllReserved.Contains(ShopEquipment[0])) btnEquip1.image.color = Color.cyan;
            else btnEquip1.image.color = Color.white;
        } else {
            btnEquip1.image.sprite = empty;
            btnEquip1.gameObject.SetActive(false);
        }
        if (ShopEquipment.Count > 1) {
            btnEquip2.gameObject.SetActive(true);
            btnEquip2.image.sprite = ShopEquipment[1].Image();
            if (AllReserved.Contains(ShopEquipment[1])) btnEquip2.image.color = Color.cyan;
            else btnEquip2.image.color = Color.white;
        } else {
            btnEquip2.image.sprite = empty;
            btnEquip2.gameObject.SetActive(false);
        }
        if (ShopEquipment.Count > 2) {
            btnEquip3.gameObject.SetActive(true);
            btnEquip3.image.sprite = ShopEquipment[2].Image();
            if (AllReserved.Contains(ShopEquipment[2])) btnEquip3.image.color = Color.cyan;
            else btnEquip3.image.color = Color.white;
        } else {
            btnEquip3.image.sprite = empty;
            btnEquip3.gameObject.SetActive(false);
        }
        if (ShopEquipment.Count > 3) {
            btnEquip4.gameObject.SetActive(true);
            btnEquip4.image.sprite = ShopEquipment[3].Image();
            if (AllReserved.Contains(ShopEquipment[3])) btnEquip4.image.color = Color.cyan;
            else btnEquip4.image.color = Color.white;
        } else {
            btnEquip4.image.sprite = empty;
            btnEquip4.gameObject.SetActive(false);
        }
        if (ShopAbilities.Count > 0) {
            btnAbility1.gameObject.SetActive(true);
            btnAbility1.image.sprite = ShopAbilities[0].Image();
            if (AllReservedAbilities.Contains(ShopAbilities[0])) btnAbility1.image.color = Color.cyan;
            else btnAbility1.image.color = Color.white;
        } else {
            btnAbility1.image.sprite = empty;
            btnAbility1.gameObject.SetActive(false);
        }
        if (ShopAbilities.Count > 1) {
            btnAbility2.gameObject.SetActive(true);
            btnAbility2.image.sprite = ShopAbilities[1].Image();
            if (AllReservedAbilities.Contains(ShopAbilities[1])) btnAbility2.image.color = Color.cyan;
            else btnAbility2.image.color = Color.white;
        } else {
            btnAbility2.image.sprite = empty;
            btnAbility2.gameObject.SetActive(false);
        }
        if (ShopAbilities.Count > 2) {
            btnAbility3.gameObject.SetActive(true);
            btnAbility3.image.sprite = ShopAbilities[2].Image();
            if (AllReservedAbilities.Contains(ShopAbilities[2])) btnAbility3.image.color = Color.cyan;
            else btnAbility3.image.color = Color.white;
        } else {
            btnAbility3.image.sprite = empty;
            btnAbility3.gameObject.SetActive(false);
        }
        if (ShopAbilities.Count > 3) {
            btnAbility4.gameObject.SetActive(true);
            btnAbility4.image.sprite = ShopAbilities[3].Image();
            if (AllReservedAbilities.Contains(ShopAbilities[3])) btnAbility4.image.color = Color.cyan;
            else btnAbility4.image.color = Color.white;
        } else {
            btnAbility4.image.sprite = empty;
            btnAbility4.gameObject.SetActive(false);
        }
        if (ShopAbilities.Count > 4) {
            btnAbility5.gameObject.SetActive(true);
            btnAbility5.image.sprite = ShopAbilities[4].Image();
            if (AllReservedAbilities.Contains(ShopAbilities[4])) btnAbility5.image.color = Color.cyan;
            else btnAbility5.image.color = Color.white;
        } else {
            btnAbility5.image.sprite = empty;
            btnAbility5.gameObject.SetActive(false);
        }
        if (ShopAbilities.Count > 5) {
            btnAbility6.gameObject.SetActive(true);
            btnAbility6.image.sprite = ShopAbilities[5].Image();
            if (AllReservedAbilities.Contains(ShopAbilities[5])) btnAbility6.image.color = Color.cyan;
            else btnAbility6.image.color = Color.white;
        } else {
            btnAbility6.image.sprite = empty;
            btnAbility6.gameObject.SetActive(false);
        }
        if (ShopAbilities.Count > 6) {
            btnAbility7.gameObject.SetActive(true);
            btnAbility7.image.sprite = ShopAbilities[6].Image();
            if (AllReservedAbilities.Contains(ShopAbilities[6])) btnAbility7.image.color = Color.cyan;
            else btnAbility7.image.color = Color.white;
        } else {
            btnAbility7.image.sprite = empty;
            btnAbility7.gameObject.SetActive(false);
        }
        if (ShopAbilities.Count > 7) {
            btnAbility8.gameObject.SetActive(true);
            btnAbility8.image.sprite = ShopAbilities[7].Image();
            if (AllReservedAbilities.Contains(ShopAbilities[7])) btnAbility8.image.color = Color.cyan;
            else btnAbility8.image.color = Color.white;
        } else {
            btnAbility8.image.sprite = empty;
            btnAbility8.gameObject.SetActive(false);
        }
    }
    void ReloadDeckView(){
        viewDeck = localUser.Deck().InspectDeck();
        if (viewDeck.Count > 0){
            btnDeck1.gameObject.SetActive(true);
            btnDeck1.image.sprite =  viewDeck[0+DeckOffset].Image();
        } else {
            btnDeck1.gameObject.SetActive(false);
            btnDeck1.image.sprite = empty;
        }
        if ( viewDeck.Count > 1){
            btnDeck2.gameObject.SetActive(true);
            btnDeck2.image.sprite =  viewDeck[1+DeckOffset].Image();
        } else {
            btnDeck2.gameObject.SetActive(false);
            btnDeck2.image.sprite = empty;
        }
        if ( viewDeck.Count > 2){
            btnDeck3.gameObject.SetActive(true);
            btnDeck3.image.sprite =  viewDeck[2+DeckOffset].Image();
        } else {
            btnDeck3.gameObject.SetActive(false);
            btnDeck3.image.sprite = empty;
        }
        if ( viewDeck.Count > 3){
            btnDeck4.gameObject.SetActive(true);
            btnDeck4.image.sprite =  viewDeck[3+DeckOffset].Image();
        } else {
            btnDeck4.gameObject.SetActive(false);
            btnDeck4.image.sprite = empty;
        }
        if ( viewDeck.Count > 4){
            btnDeck5.gameObject.SetActive(true);
            btnDeck5.image.sprite =  viewDeck[4+DeckOffset].Image();
        } else {
            btnDeck5.gameObject.SetActive(false);
            btnDeck5.image.sprite = empty;
        }
        if ( viewDeck.Count > 5){
            btnDeck6.gameObject.SetActive(true);
            btnDeck6.image.sprite =  viewDeck[5+DeckOffset].Image();
        } else {
            btnDeck6.gameObject.SetActive(false);
            btnDeck6.image.sprite = empty;
        }
        if ( viewDeck.Count > 6){
            if (DeckOffset > 0) btnDeckLeftScroll.gameObject.SetActive(true);
            else btnDeckLeftScroll.gameObject.SetActive(false);
            if (DeckOffset < viewDeck.Count-6) btnDeckRightScroll.gameObject.SetActive(true);
            else btnDeckRightScroll.gameObject.SetActive(false);
        } else {
            btnDeckLeftScroll.gameObject.SetActive(false);
            btnDeckRightScroll.gameObject.SetActive(false);
        }
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
    void Reserve(Equipment e, Ability a){
        if (EquipmentInReserve == null && AbilityInReserve == null && localUser.getGold()>0){
            localUser.changeGold(-1);
            EquipmentInReserve = e; AbilityInReserve = a;
            localUser.Write("*RESERVE,"+(e!=null?e.getName():"")+(a!=null?a.getName():""));
        }
        pnlPurchase.SetActive(false);
        EquipmentBeingPurchased = null;
        AbilityBeingPurchased = null;
    }
    void ReloadAspirations(){
        btnAspiration1.image.sprite = vs.PeekAspiration(0,aspirationOffset[0]).Image();
        btnAspiration2.image.sprite = vs.PeekAspiration(1,aspirationOffset[1]).Image();
        btnAspiration3.image.sprite = vs.PeekAspiration(2,aspirationOffset[2]).Image();
        btnAspiration4.image.sprite = vs.PeekAspiration(3,aspirationOffset[3]).Image();
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
    }
    void ReloadTrophyView(){
        viewTrophy = localUser.Trophies();
        if (viewTrophy.Count > 0){
            btnTrophy1.gameObject.SetActive(true);
            btnTrophy1.image.sprite =  viewTrophy[0+TrophyOffset].Image();
        } else {
            btnTrophy1.gameObject.SetActive(false);
            btnTrophy1.image.sprite = empty;
        }
        if ( viewTrophy.Count > 1){
            btnTrophy2.gameObject.SetActive(true);
            btnTrophy2.image.sprite =  viewTrophy[1+TrophyOffset].Image();
        } else {
            btnTrophy2.gameObject.SetActive(false);
            btnTrophy2.image.sprite = empty;
        }
        if ( viewTrophy.Count > 2){
            btnTrophy3.gameObject.SetActive(true);
            btnTrophy3.image.sprite =  viewTrophy[2+TrophyOffset].Image();
        } else {
            btnTrophy3.gameObject.SetActive(false);
            btnTrophy3.image.sprite = empty;
        }
        if ( viewTrophy.Count > 3){
            if (TrophyOffset > 0) btnTrophyLeftScroll.gameObject.SetActive(true);
            else btnTrophyLeftScroll.gameObject.SetActive(false);
            if (TrophyOffset <  viewTrophy.Count-3) btnTrophyRightScroll.gameObject.SetActive(true);
            else btnTrophyRightScroll.gameObject.SetActive(false);
        } else {
            btnTrophyLeftScroll.gameObject.SetActive(false);
            btnTrophyRightScroll.gameObject.SetActive(false);
        }
    }
    void ReloadAspirationView(){
        viewAspirations = localUser.Aspirations();
        if (viewAspirations.Count > 0){
            btnAspirationView1.gameObject.SetActive(true);
            btnAspirationView1.image.sprite =  viewAspirations[0+AspirationViewOffset].Image();
        } else {
            btnAspirationView1.gameObject.SetActive(false);
            btnAspirationView1.image.sprite = empty;
        }
        if ( viewAspirations.Count > 1){
            btnAspirationView2.gameObject.SetActive(true);
            btnAspirationView2.image.sprite =  viewAspirations[1+AspirationViewOffset].Image();
        } else {
            btnAspirationView2.gameObject.SetActive(false);
            btnAspirationView2.image.sprite = empty;
        }
        if ( viewAspirations.Count > 2){
            btnAspirationView3.gameObject.SetActive(true);
            btnAspirationView3.image.sprite =  viewAspirations[2+AspirationViewOffset].Image();
        } else {
            btnAspirationView3.gameObject.SetActive(false);
            btnAspirationView3.image.sprite = empty;
        }
        if ( viewAspirations.Count > 3){
            btnAspirationView4.gameObject.SetActive(true);
            btnAspirationView4.image.sprite =  viewAspirations[3+AspirationViewOffset].Image();
        } else {
            btnAspirationView4.gameObject.SetActive(false);
            btnAspirationView4.image.sprite = empty;
        }
        if ( viewAspirations.Count > 4){
            if (AspirationViewOffset > 0) btnAspirationLeftScroll.gameObject.SetActive(true);
            else btnAspirationLeftScroll.gameObject.SetActive(false);
            if (AspirationViewOffset < viewAspirations.Count-4) btnAspirationRightScroll.gameObject.SetActive(true);
            else btnAspirationRightScroll.gameObject.SetActive(false);
        } else {
            btnAspirationLeftScroll.gameObject.SetActive(false);
            btnAspirationRightScroll.gameObject.SetActive(false);
        }
    }
    void ReloadTradeMenu(){
        txtTradeLocalName.text = localUser.GetName();
        txtTradeOtherName.text = tradePartner.GetName();
        txtTradeGoldLocal.text = ""+tradeGoldPlayer;
        txtTradeGoldOther.text = ""+tradeGoldOther;
        txtTradeVPLocal.text = ""+tradeVPPlayer;
        txtTradeVPOther.text = ""+tradeVPOther;
        if (tradeAcceptedOther) btnTradeActiveAccept.GetComponent<Text>().color = Color.green;
        else btnTradeActiveAccept.GetComponent<Text>().color = Color.black;
        if (tradeAbility1Player != null) btnTradeAbility1.GetComponent<Text>().text = tradeAbility1Player.getName();
        else  btnTradeAbility1.GetComponent<Text>().text = "";
        if (tradeAbility2Player != null) btnTradeAbility2.GetComponent<Text>().text = tradeAbility2Player.getName();
        else  btnTradeAbility2.GetComponent<Text>().text = "";
        if (tradeAspiration1Player != null) btnTradeAspiration1.GetComponent<Text>().text = tradeAspiration1Player.GetName();
        else  btnTradeAspiration1.GetComponent<Text>().text = "";
        if (tradeAspiration2Player != null) btnTradeAspiration2.GetComponent<Text>().text = tradeAspiration2Player.GetName();
        else  btnTradeAspiration2.GetComponent<Text>().text = "";
        if (tradeItem1Player != null) btnTradeItem1.GetComponent<Text>().text = tradeItem1Player.getName();
        else  btnTradeItem1.GetComponent<Text>().text = "";
        if (tradeItem2Player != null) btnTradeItem2.GetComponent<Text>().text = tradeItem2Player.getName();
        else  btnTradeItem2.GetComponent<Text>().text = "";
        if (tradeTrophy1Player != null) btnTradeTrophy1.GetComponent<Text>().text = tradeTrophy1Player.GetName();
        else  btnTradeTrophy1.GetComponent<Text>().text = "";
        if (tradeTrophy2Player != null) btnTradeTrophy2.GetComponent<Text>().text = tradeTrophy2Player.GetName();
        else  btnTradeTrophy2.GetComponent<Text>().text = "";
        if (tradeAbility1Other != null) btnTradeAbility1.GetComponent<Text>().text = tradeAbility1Other;
        else  btnTradeAbility1.GetComponent<Text>().text = "";
        if (tradeAbility2Other != null) btnTradeAbility2.GetComponent<Text>().text = tradeAbility2Other;
        else  btnTradeAbility2.GetComponent<Text>().text = "";
        if (tradeAspiration1Other != null) btnTradeAspiration1.GetComponent<Text>().text = tradeAspiration1Other;
        else  btnTradeAspiration1.GetComponent<Text>().text = "";
        if (tradeAspiration2Other != null) btnTradeAspiration2.GetComponent<Text>().text = tradeAspiration2Other;
        else  btnTradeAspiration2.GetComponent<Text>().text = "";
        if (tradeItem1Other != null) btnTradeItem1.GetComponent<Text>().text = tradeItem1Other;
        else  btnTradeItem1.GetComponent<Text>().text = "";
        if (tradeItem2Other != null) btnTradeItem2.GetComponent<Text>().text = tradeItem2Other;
        else  btnTradeItem2.GetComponent<Text>().text = "";
        if (tradeTrophy1Other != null) btnTradeTrophy1.GetComponent<Text>().text = tradeTrophy1Other;
        else  btnTradeTrophy1.GetComponent<Text>().text = "";
        if (tradeTrophy2Other != null) btnTradeTrophy2.GetComponent<Text>().text = tradeTrophy2Other;
        else  btnTradeTrophy2.GetComponent<Text>().text = "";
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
    void ReloadClasses(){
        List<PlayerClass> temp = vs.getAvailableClasses();
        if (temp.Count == 0  || localUser.GetPlayerClass() != null) pnlClasses.SetActive(false);
        else {
            warrior = null;
            cleric = null;
            rogue = null;
            mage = null;
            foreach (PlayerClass pc in vs.getAvailableClasses()){
                if (pc.getName().CompareTo("Warrior")==0) warrior = pc;
                if (pc.getName().CompareTo("Cleric")==0) cleric = pc;
                if (pc.getName().CompareTo("Rogue")==0) rogue = pc;
                if (pc.getName().CompareTo("mage")==0) mage = pc;
            }
            if (warrior != null) {
                btnWarriorClass.gameObject.SetActive(true);
                btnWarriorClass.image.sprite = warrior.Image();
            } else {
                btnWarriorClass.gameObject.SetActive(false);
                btnWarriorClass.image.sprite = empty;
            }
            if (cleric != null) {
                btnClericClass.gameObject.SetActive(true);
                btnClericClass.image.sprite = cleric.Image();
            } else {
                btnClericClass.gameObject.SetActive(false);
                btnClericClass.image.sprite = empty;
            }
            if (rogue != null) {
                btnRogueClass.gameObject.SetActive(true);
                btnRogueClass.image.sprite = rogue.Image();
            } else {
                btnRogueClass.gameObject.SetActive(false);
                btnRogueClass.image.sprite = empty;
            }
            if (mage != null) {
                btnMageClass.gameObject.SetActive(true);
                btnMageClass.image.sprite = mage.Image();
            } else {
                btnMageClass.gameObject.SetActive(false);
                btnMageClass.image.sprite = empty;
            }
        }
    }
    void ReloadClassAspirations(){
        viewClassAspiration = new List<Aspiration>();
        foreach (Aspiration a in localUser.Aspirations()){
            float sum = 0;
            foreach (float f in a.GetGem())
                sum+=f;
            if (sum > 0)
                viewClassAspiration.Add(a);
        }
        if (viewClassAspiration.Count > 0){
            btnClassAspiration1.gameObject.SetActive(true);
            btnClassAspiration1.image.sprite =  viewClassAspiration[0+ClassAspirationOffset].Image();
        } else {
            btnClassAspiration1.gameObject.SetActive(false);
            btnClassAspiration1.image.sprite = empty;
        }
        if ( viewClassAspiration.Count > 1){
            btnClassAspiration2.gameObject.SetActive(true);
            btnClassAspiration2.image.sprite =  viewClassAspiration[1+ClassAspirationOffset].Image();
        } else {
            btnClassAspiration2.gameObject.SetActive(false);
            btnClassAspiration2.image.sprite = empty;
        }
        if ( viewClassAspiration.Count > 2){
            btnClassAspiration3.gameObject.SetActive(true);
            btnClassAspiration3.image.sprite =  viewClassAspiration[2+ClassAspirationOffset].Image();
        } else {
            btnClassAspiration3.gameObject.SetActive(false);
            btnClassAspiration3.image.sprite = empty;
        }
        if ( viewClassAspiration.Count > 3){
            if (ClassAspirationOffset > 0) btnClassAspirationLeft.gameObject.SetActive(true);
            else btnClassAspirationLeft.gameObject.SetActive(false);
            if (ClassAspirationOffset < viewClassAspiration.Count-3) btnClassAspirationRight.gameObject.SetActive(true);
            else btnClassAspirationRight.gameObject.SetActive(false);
        } else {
            btnClassAspirationLeft.gameObject.SetActive(false);
            btnClassAspirationRight.gameObject.SetActive(false);
        }
    }
    void ReloadClassTrophies(){
        viewClassTrophy = new List<Monster>();
        foreach (Monster a in localUser.Trophies()){
            float sum = 0;
            foreach (float f in a.GetGem())
                sum+=f;
            if (sum > 0)
                viewClassTrophy.Add(a);
        }
        if (viewClassTrophy.Count > 0){
            btnClassTrophy1.gameObject.SetActive(true);
            btnClassTrophy1.image.sprite =  viewClassTrophy[0+ClassTrophyOffset].Image();
        } else {
            btnClassTrophy1.gameObject.SetActive(false);
            btnClassTrophy1.image.sprite = empty;
        }
        if ( viewClassTrophy.Count > 1){
            btnClassTrophy2.gameObject.SetActive(true);
            btnClassTrophy2.image.sprite =  viewClassTrophy[1+ClassTrophyOffset].Image();
        } else {
            btnClassTrophy2.gameObject.SetActive(false);
            btnClassTrophy2.image.sprite = empty;
        }
        if ( viewClassTrophy.Count > 2){
            btnClassTrophy3.gameObject.SetActive(true);
            btnClassTrophy3.image.sprite =  viewClassTrophy[2+ClassTrophyOffset].Image();
        } else {
            btnClassTrophy3.gameObject.SetActive(false);
            btnClassTrophy3.image.sprite = empty;
        }
        if ( viewClassTrophy.Count > 3){
            if (ClassTrophyOffset > 0) btnClassTrophyLeft.gameObject.SetActive(true);
            else btnClassTrophyLeft.gameObject.SetActive(false);
            if (ClassTrophyOffset <  viewClassTrophy.Count-3) btnClassTrophyRight.gameObject.SetActive(true);
            else btnClassTrophyRight.gameObject.SetActive(false);
        } else {
            btnClassTrophyLeft.gameObject.SetActive(false);
            btnClassTrophyRight.gameObject.SetActive(false);
        }
    }
    void ReloadClassItems(){
        viewClassItem = new List<Equipment>();
        foreach (Equipment a in localUser.Arsenal()){
            float sum = 0;
            foreach (float f in a.GetGem(""))
                sum+=f;
            if (sum > 0)
                viewClassItem.Add(a);
        }
        foreach (Equipment e in localUser.Arsenal()) {
            if (e.GetSource().CompareTo("Basic")!=0) viewClassItem.Add(e);
        }
        if (viewClassItem.Count > 0){
            btnClassItem1.gameObject.SetActive(true);
            btnClassItem1.image.sprite =  viewClassItem[0+ClassItemOffset].Image();
        } else {
            btnClassItem1.gameObject.SetActive(false);
            btnClassItem1.image.sprite = empty;
        }
        if ( viewClassItem.Count > 1){
            btnClassItem2.gameObject.SetActive(true);
            btnClassItem2.image.sprite =  viewClassItem[1+ClassItemOffset].Image();
        } else {
            btnClassItem2.gameObject.SetActive(false);
            btnClassItem2.image.sprite = empty;
        }
        if ( viewClassItem.Count > 2){
            btnClassItem3.gameObject.SetActive(true);
            btnClassItem3.image.sprite =  viewClassItem[2+ClassItemOffset].Image();
        } else {
            btnClassItem3.gameObject.SetActive(false);
            btnClassItem3.image.sprite = empty;
        }
        if ( viewClassItem.Count > 3){
            btnClassItem4.gameObject.SetActive(true);
            btnClassItem4.image.sprite =  viewClassItem[3+ClassItemOffset].Image();
        } else {
            btnClassItem4.gameObject.SetActive(false);
            btnClassItem4.image.sprite = empty;
        }
        if ( viewClassItem.Count > 4){
            if (ClassItemOffset > 0) btnClassItemLeft.gameObject.SetActive(true);
            else btnClassItemLeft.gameObject.SetActive(false);
            if (ClassItemOffset <  viewClassItem.Count-4) btnClassItemRight.gameObject.SetActive(true);
            else btnClassItemRight.gameObject.SetActive(false);
        } else {
            btnClassItemLeft.gameObject.SetActive(false);
            btnClassItemRight.gameObject.SetActive(false);
        }
    }
    void ReloadClassAquisition(){ 
        if (selectedClassAspiration == null) selectedClassAspiration = new List<Aspiration>();
        if (selectedClassItem == null) selectedClassItem = new List<Equipment>();
        if (selectedClassTrophy == null) selectedClassTrophy = new List<Monster>();
        txtWarriorGemCount.color = Color.black;
        txtClericGemCount.color = Color.black;
        txtRogueGemCount.color = Color.black;
        txtMageGemCount.color = Color.black;
        float warriorgem = 0;
        float clericgem = 0;
        float roguegem = 0;
        float magegem = 0;
        if (selectedClassAspiration.Count > 0){
            float[] temp = selectedClassAspiration[0].GetGem();
            warriorgem += temp[0];
            clericgem += temp[1];
            roguegem += temp[2];
            magegem += temp[3];
            btnCAAspiration1.image.sprite = selectedClassAspiration[0].Image();
        } else btnCAAspiration1.image.sprite = empty;
        if (selectedClassAspiration.Count > 1){
            float[] temp = selectedClassAspiration[1].GetGem();
            warriorgem += temp[0];
            clericgem += temp[1];
            roguegem += temp[2];
            magegem += temp[3];
            btnCAAspiration2.image.sprite = selectedClassAspiration[1].Image();
        } else btnCAAspiration2.image.sprite = empty;
        if (selectedClassTrophy.Count > 0){
            float[] temp = selectedClassTrophy[0].GetGem();
            warriorgem += temp[0];
            clericgem += temp[1];
            roguegem += temp[2];
            magegem += temp[3];
            btnCATrophy1.image.sprite = selectedClassTrophy[0].Image();
        } else btnCATrophy1.image.sprite = empty;
        if (selectedClassTrophy.Count > 1){
            float[] temp = selectedClassTrophy[1].GetGem();
            warriorgem += temp[0];
            clericgem += temp[1];
            roguegem += temp[2];
            magegem += temp[3];
            btnCATrophy2.image.sprite = selectedClassTrophy[1].Image();
        } else btnCATrophy2.image.sprite = empty;
        if (selectedClassTrophy.Count > 2){
            float[] temp = selectedClassTrophy[2].GetGem();
            warriorgem += temp[0];
            clericgem += temp[1];
            roguegem += temp[2];
            magegem += temp[3];
            btnCATrophy3.image.sprite = selectedClassTrophy[2].Image();
        } else btnCATrophy3.image.sprite = empty;
        if (selectedClassTrophy.Count > 3){
            float[] temp = selectedClassTrophy[3].GetGem();
            warriorgem += temp[0];
            clericgem += temp[1];
            roguegem += temp[2];
            magegem += temp[3];
            btnCATrophy4.image.sprite = selectedClassTrophy[3].Image();
        } else btnCATrophy4.image.sprite = empty;
        if (selectedClassItem.Count > 0){
            float[] temp = selectedClassItem[0].GetGem(TargetClass);
            warriorgem += temp[0];
            clericgem += temp[1];
            roguegem += temp[2];
            magegem += temp[3];
            btnCAItem1.image.sprite = selectedClassItem[0].Image();
        } else btnCAItem1.image.sprite = empty;
        if (selectedClassItem.Count > 1){
            float[] temp = selectedClassItem[1].GetGem(TargetClass);
            warriorgem += temp[0];
            clericgem += temp[1];
            roguegem += temp[2];
            magegem += temp[3];
            btnCAItem2.image.sprite = selectedClassItem[1].Image();
        } else btnCAItem2.image.sprite = empty;
        if (selectedClassItem.Count > 2){
            float[] temp = selectedClassItem[2].GetGem(TargetClass);
            warriorgem += temp[0];
            clericgem += temp[1];
            roguegem += temp[2];
            magegem += temp[3];
            btnCAItem3.image.sprite = selectedClassItem[2].Image();
        } else btnCAItem3.image.sprite = empty;
        if (selectedClassItem.Count > 3){
            float[] temp = selectedClassItem[3].GetGem(TargetClass);
            warriorgem += temp[0];
            clericgem += temp[1];
            roguegem += temp[2];
            magegem += temp[3];
            btnCAItem4.image.sprite = selectedClassItem[3].Image();
        } else btnCAItem4.image.sprite = empty;
        txtWarriorGemCount.text = ""+warriorgem;
        txtClericGemCount.text = ""+clericgem;
        txtRogueGemCount.text = ""+roguegem;
        txtMageGemCount.text = ""+magegem;
        bool classspecificfulfilled = false;
        if (TargetClass.CompareTo("Warrior")==0){
            if (warriorgem >= 1) classspecificfulfilled = true;
            txtWarriorGemCount.color = classspecificfulfilled?Color.blue:Color.red;
        }
        if (TargetClass.CompareTo("Cleric")==0){
            if (clericgem >= 1) classspecificfulfilled = true;
            txtClericGemCount.color = classspecificfulfilled?Color.blue:Color.red;
        }
        if (TargetClass.CompareTo("Rogue")==0){
            if (roguegem >= 1) classspecificfulfilled = true;
            txtRogueGemCount.color = classspecificfulfilled?Color.blue:Color.red;
        }
        if (TargetClass.CompareTo("Mage")==0){
            if (magegem >= 1) classspecificfulfilled = true;
            txtMageGemCount.color = classspecificfulfilled?Color.blue:Color.red;
        }
        if (warriorgem + clericgem + roguegem + magegem == 2 && classspecificfulfilled)
            btnCAConfirm.gameObject.SetActive(true);
        else btnCAConfirm.gameObject.SetActive(false);
    }
    void TradeForClass(){
        foreach (Aspiration a in selectedClassAspiration){
            localUser.RemoveAspiration(a);
        } selectedClassAspiration = null;
        foreach (Monster t in selectedClassTrophy){
            localUser.RemoveTrophy(t);
        } selectedClassTrophy = null;
        foreach (Equipment i in selectedClassItem){
            localUser.RemoveItem(i);
        } selectedClassItem = null;
        pnlClassAquisition.SetActive(false);
        foreach (PlayerClass pc in vs.getAvailableClasses()){
            if (pc.getName().CompareTo(TargetClass)==0)
                localUser.SetClass(pc);
        }//Swap out Strikes for the class version
        for( int c = localUser.Deck().DeckCount()-1; c >= 0; c++){
            Ability temp = localUser.Deck().InspectDeck()[c];
            if (temp.getName().CompareTo("Strike")==0) localUser.Deck().Remove(temp);
        }
        foreach(Ability a in vs.GetShopAbilities()){
            if (a.getName().CompareTo(localUser.GetPlayerClass().getStrikeReplacement())==0){
                localUser.Deck().Add(a); localUser.Deck().Add(a); localUser.Deck().Add(a); 
            }
        }
        localUser.Write("*CLAIMCLASS,"+TargetClass); //Server will rebroadcast this, then each client will remove it appropriately.
        ReloadClasses();
    }
}
