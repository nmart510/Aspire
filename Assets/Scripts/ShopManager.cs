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
    //Trophy
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

    public List<Equipment> initShop = new List<Equipment>();
    public List<Equipment> ShopEquipment = new List<Equipment>();
    public List<Ability> ShopAbilities = new List<Ability>();
    public List<Ability> viewDeck = new List<Ability>();
    public List<Equipment> viewArsenal = new List<Equipment>();
    public Equipment HealthPot;
    public Equipment ExplodingPot;
    public Sprite empty;
    Equipment EquipmentBeingSold = null;
    Ability AbilityBeingSold = null;
    Equipment EquipmentBeingPurchased = null;
    Ability AbilityBeingPurchased = null;
    Equipment EquipmentInReserve = null;
    Ability AbilityInReserve = null;
    List<Equipment> AllReserved = new List<Equipment>();
    List<Ability> AllReservedAbilities = new List<Ability>();

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
        //Aspirations
        btnAsp1ScrollDown.onClick.AddListener(delegate{aspirationOffset[0]--;ReloadAspirations();});
        btnAsp1ScrollUp.onClick.AddListener(delegate{aspirationOffset[0]++;ReloadAspirations();});
        btnAsp2ScrollDown.onClick.AddListener(delegate{aspirationOffset[1]--;ReloadAspirations();});
        btnAsp2ScrollUp.onClick.AddListener(delegate{aspirationOffset[1]++;ReloadAspirations();});
        btnAsp3ScrollDown.onClick.AddListener(delegate{aspirationOffset[2]--;ReloadAspirations();});
        btnAsp3ScrollUp.onClick.AddListener(delegate{aspirationOffset[2]++;ReloadAspirations();});
        btnAsp4ScrollDown.onClick.AddListener(delegate{aspirationOffset[3]--;ReloadAspirations();});
        btnAsp4ScrollUp.onClick.AddListener(delegate{aspirationOffset[3]++;ReloadAspirations();});
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
            } pnlSeller.SetActive(false); pnlAdder.SetActive(false); EquipmentBeingSold = null; AbilityBeingSold = null;});
        btnSellCancel.onClick.AddListener(delegate{ pnlSeller.SetActive(false); pnlAdder.SetActive(false);
            EquipmentBeingSold = null; AbilityBeingSold = null;});
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

}
