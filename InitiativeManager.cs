using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.UIElements;
using System.Linq;

public class InitiativeManager : MonoBehaviour
{
    //GameObject Variables
    public GameObject panelToInsta;
    public GameObject go_enemy;
    public GameObject panelEnemy, panelPlayer;
    //Lists and Arrays
    public List<GameObject> listaEnePlay = new();
    //UI Variables
    public TMP_Dropdown dexdrop;
    public TMP_Text t_iniplayer;
    public UnityEngine.UI.Slider iniplayerslider;
    //Numeric Variables
    public int enemid, playerid;
    public int limiteobjetos;
    //Bools
    public bool isEnemy;

    public void OnToggleChange(bool tickOn)
    {
        isEnemy = tickOn;
        if (isEnemy)
        {
            panelEnemy.SetActive(true);
            panelPlayer.SetActive(false);
        }
        else
        {
            panelEnemy.SetActive(false);
            panelPlayer.SetActive(true);
        }
    }

    public void Crear()
    {
        
        if (limiteobjetos < 16)
        {
            limiteobjetos++;
            if (isEnemy) enemid++; if (!isEnemy) playerid++;
            listaEnePlay.Add(Instantiate(go_enemy, panelToInsta.transform));
            Invoke("OrderList", .1f);
        }
    }

    public void UpdateInit()
    {
        t_iniplayer.text = iniplayerslider.value.ToString();
    }

    public void OrderList()
    {
        {
            listaEnePlay = listaEnePlay.OrderByDescending(go => go.GetComponent<OrderItem>().iniciativa).ToList();

            for (int i = 0; i < listaEnePlay.Count; i++)
            {
                listaEnePlay[i].transform.SetSiblingIndex(i);
            }
        }
    }
}
