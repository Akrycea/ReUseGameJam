using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Touch2 : MonoBehaviour
{
    public Collider2D colliderSelf;
    public Collider2D[] colliderNPC;
    public Collider2D[] colliderWoman;
    public Happiness2Count happinesCount;
    void Start()
    {
        colliderSelf = GetComponent<Collider2D>();
    }


    void Update()
    {

    }

    public void checkForTouch()
    {
        foreach (var collider in colliderNPC)
        {
            if (colliderSelf.IsTouching(collider))
            { 
                happinesCount.happiness--;
            }

        }
    }
}
