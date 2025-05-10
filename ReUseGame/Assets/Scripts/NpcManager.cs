using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class NpcManager : MonoBehaviour
{
    public HppinessCount happyCount;
    public SpriteRenderer spriteRenderer;

    //preferencje npc
    public int preference1;
    public int preference2;

    //odbłusga npc
    public bool selected;
    public GameObject selectedNpc;
    public Sprite[] sprites;
    Collider2D collider;

    void Start()
    {
        selected = false;
        collider = gameObject.GetComponent<Collider2D>();
    }

    
    void Update()
    {
      
        if (selected)
        {
            spriteRenderer.sprite = sprites[1];
            choosingSeat();
        }
        else
        {
            spriteRenderer.sprite = sprites[0];
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
 
            Debug.Log("chose seat");
            selectedNpc.transform.position = rayHit.transform.position + new Vector3(0, 0, 1);

                if (selectedNpc.name == "WindowFar" && rayHit.transform.name == "WindowFar")
                {
                    happyCount.happiness = +2;
                    selectedNpc = null;
                    selected = false;
                }

                else if (selectedNpc.name == "IsleFar" && rayHit.transform.name == "IsleFar")
                {
                    happyCount.happiness = +2;
                    selectedNpc = null;
                }
            selected = false;
            selectedNpc = null;
        }
        countHappiness();
    }

    void countHappiness()
    {
       
        //if(gameObject.name == "WindowFar" && collider  )
        //if (selectedNpc.name == "WindowFar" && rayHit.transform.name == "WindowFar")
        //{
        //    happyCount.happiness = +2;
        //    selectedNpc = null;
        //    selected = false;
        //}

        //else if (selectedNpc.name == "IsleFar" && rayHit.transform.name == "IsleFar")
        //{
        //    happyCount.happiness = +2;
        //    selectedNpc = null;
        //}
    }
    //void OnCollisionEnter(Collision collision)
    //{
    //    Debug.Log("touvh");
    //    if (gameObject.name == "WindowFar" && collision.gameObject.name == "WindowFar")
    //    {
    //        happyCount.happiness++;
    //    }
    //}

}
