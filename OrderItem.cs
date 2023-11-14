using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UIElements;

public class OrderItem : MonoBehaviour
{
    //Script References
    public InitiativeManager init;
    //Numeric Variables
    public int iniciativa;
    //UI Variables
    public TMP_Text enemytext;
    public TMP_Text initext;
    public Toggle enemycheck;


    public void Awake()
    {
        init = GameObject.Find("GameManager").GetComponent<InitiativeManager>();
    }

    public void Start()
    {
        enemytext = this.transform.Find("Ini_Text").GetComponent<TMP_Text>();
        initext = this.transform.Find("Ini_Number").GetComponent<TMP_Text>();
        EditorValues();
    }

    void EditorValues()
    {
        
        if (init.isEnemy)
        {
            enemytext.text = "Enemy" + " " + init.enemid.ToString();
            int dice;
            dice = Random.Range(1, 21);
            iniciativa = dice + init.dexdrop.value;
            initext.text = (dice + init.dexdrop.value).ToString();
        }
        else
        {
            enemytext.text = "Player" + " " + init.playerid.ToString(); ;
            iniciativa = int.Parse(init.t_iniplayer.text);
            initext.text = init.t_iniplayer.text;
        }
    }

}
