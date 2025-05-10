using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class NpcManager : MonoBehaviour
{
    public HppinessCount happyCount;
    public SpriteRenderer spriteRenderer;
    

    //odbłusga npc
    public bool selected;
    public GameObject selectedNpc;
    public Sprite[] sprites;
    public GameObject[] portret;
    Collider2D collider;

    public AudioSource footSound;
    public AudioSource voiceSound;
    public AudioSource woodSound;

 

    void Start()
    {

        selected = false;
        collider = gameObject.GetComponent<Collider2D>();
        foreach (var obj in portret)
        {
            obj.SetActive(false);
        }
    }

    
    void Update()
    {
      
        if (selected)
        {
            spriteRenderer.sprite = sprites[1];
            choosingSeat();
            foreach (var obj in portret)
            {
                obj.SetActive(true);
            }
        }
        else
        {
            spriteRenderer.sprite = sprites[0];
            foreach (var obj in portret)
            {
                obj.SetActive(false);
            }
        }
  
        
        
    }

    //wyczuwa co zostało kliknięte i mówi co zrobić w związku z tym
    private void OnMouseDown()
    {
            RaycastHit2D rayHit = Physics2D.GetRayIntersection(Camera.main.ScreenPointToRay(Input.mousePosition));
            
            //kliknięcie na npc, wybranie go
            if (rayHit.transform.CompareTag("NPC") && selected == false)
            {
                Debug.Log("selected npc");
                selected = true;
                selectedNpc = gameObject;
                voiceSound.Play();
                
            }
            //to nie działa lol 
            //else if (selected == true)
            //{
            //    selected = false;

            //}

        

    }

    private void choosingSeat()
    {
        RaycastHit2D rayHit = Physics2D.GetRayIntersection(Camera.main.ScreenPointToRay(Input.mousePosition));

        //przenosi npc na miejsce
        if (Input.GetMouseButtonDown(0) && rayHit.transform.CompareTag("SEAT")) 
        {
            happyCount.turnCount++;
            Debug.Log("chose seat");
            selectedNpc.transform.position = rayHit.transform.position + new Vector3(0, 0, 1);
            footSound.Play();
            //liczy punkty

                //FULL PUNKTY
                if (selectedNpc.name == "WindowFar" && rayHit.transform.name == "WindowFar")
                {
                    happyCount.happiness = happyCount.happiness + 2;
                    selectedNpc = null;
                    selected = false;
                    woodSound.Play();
                }
                else if (selectedNpc.name == "IsleFar" && rayHit.transform.name == "IsleFar")
                {
                    happyCount.happiness = happyCount.happiness +2;
                    selectedNpc = null;
                    woodSound.Play();
            }
                else if (selectedNpc.name == "WindowNear" && rayHit.transform.name == "WindowNear")
                {
                    happyCount.happiness = happyCount.happiness +2;
                    selectedNpc = null;
                    woodSound.Play();
                }
                else if (selectedNpc.name == "IsleNear" && rayHit.transform.name == "IsleNear")
                {
                    happyCount.happiness = happyCount.happiness +2;
                    selectedNpc = null;
                     woodSound.Play();
                }

                //PUNKTY CZĘŚCIOWE
                else if (selectedNpc.name == "Far" || selectedNpc.name == "Isle" || selectedNpc.name == "IsleNear" 
                || selectedNpc.name == "WindowFar" && rayHit.transform.name == "IsleFar")
                {
                    happyCount.happiness = happyCount.happiness +1;
                    selectedNpc = null;
                    selected = false;
                     woodSound.Play();
                }

                else if (selectedNpc.name == "Far" || selectedNpc.name == "Window" || selectedNpc.name == "IsleFar" 
                || selectedNpc.name == "WindowNear" && rayHit.transform.name == "WindowFar")
                {
                    happyCount.happiness = happyCount.happiness +1;
                    selectedNpc = null;
                    selected = false;
                     woodSound.Play();
                }

                else if (selectedNpc.name == "Near" || selectedNpc.name == "Isle" || selectedNpc.name == "IsleFar" 
                || selectedNpc.name == "WindowNear" && rayHit.transform.name == "IsleNear")
                {
                    happyCount.happiness = happyCount.happiness +1;
                    selectedNpc = null;
                    selected = false;
                    woodSound.Play();
                }

                else if (selectedNpc.name == "Near" || selectedNpc.name == "Window" || selectedNpc.name == "IsleNear" 
                || selectedNpc.name == "WindowFar" && rayHit.transform.name == "WindowNear")
                {
                    happyCount.happiness = happyCount.happiness +1;
                    selectedNpc = null;
                    selected = false;
                     woodSound.Play();
                }
                

            selected = false;
            selectedNpc = null;
        }
   
    }


}
