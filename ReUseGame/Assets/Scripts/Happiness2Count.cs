using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Happiness2Count : MonoBehaviour
{//max to 33
    public float happiness;

    public int turnCount;

    public GameObject[] levelEndMenu;
    public TMP_Text wynik;

    public Touch2 touch2;

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
        if (turnCount == 20)
        {
            EndLevel1();
        }
    }

    public void EndLevel1()
    {

        Debug.Log("end level");
        touch2.checkForTouch();
        foreach (var obj in levelEndMenu)
        {
            obj.SetActive(true);
        }
        wynik.text = "WYNIK: " + ((happiness / 33) * 100).ToString("0") + "%";

    }
}
