using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class HppinessCount : MonoBehaviour
{
    //max to 28
    public float happiness;

    public int turnCount;

    public GameObject[] levelEndMenu;
    public TMP_Text wynik;

    public Touch1 touch1;
    
    void Start()
    {
        foreach (var obj in levelEndMenu) 
        {
            obj.SetActive(false);
        }
        happiness = 0;   
    }

    
    void Update()
    {
        if(turnCount == 14)
        {
            EndLevel1();
        }
    }

    public void EndLevel1()
    {
        
            Debug.Log("end level");
            touch1.checkForTouch();
            foreach (var obj in levelEndMenu)
            {
                obj.SetActive(true);
            }
            wynik.text = "WYNIK: " + ((happiness / 28) * 100).ToString("0") + "%";
        
    }
}
