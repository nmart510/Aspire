using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DungeonManager : MonoBehaviour
{
    //Loading in the very numerous UI elements that'll need to dynamically change

    //Monster elements
    public GameObject pnlMonster, pnlMMods, pnlTrade, pnlLobby, pnlHand,
            pnlAuxiliary, pnlPlayZone, pnlDefenses, pnlAspirations,
            pnlDiscard, pnlDiscardZone, pnlDeckZone, pnlEquipment,
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
    public Button btnLobbyReady;
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
    public GameObject pnlParticipating;

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


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
