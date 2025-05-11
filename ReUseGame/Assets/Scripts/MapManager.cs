using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapManager : MonoBehaviour
{
    public GameObject map;
    public Animator mapAnim;
    private bool mapOpen;
    public AudioSource mapAudio;
   
    void Start()
    {
        mapOpen = false;
        map.SetActive(false);
    }

    
    void Update()
    {
        
    }

    private void OnMouseOver()
    {
        mapAnim.Play("Map");
    }
    private void OnMouseExit()
    {
        mapAnim.Play("MapDown");
    }
    private void OnMouseDown()
    {
        if (mapOpen) 
        {
            map.SetActive(false);
            mapOpen = false;
            mapAudio.Play();
        }
        else if (!mapOpen)
        {
            map.SetActive(true);
            mapOpen = true;
            mapAudio.Play();
            
        }
    }
}
