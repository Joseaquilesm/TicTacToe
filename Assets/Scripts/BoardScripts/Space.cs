using System.Collections;
using System.Collections.Generic;
using Scripts.Models;
using UnityEngine;

public class Space : MonoBehaviour
{

    public ushort spaceClicked;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnMouseDown()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if(transform.parent != null)
            {
                Board board = transform.parent.gameObject.GetComponent<Board>();
                if (board != null)
                {

                    Debug.Log("The space I've clicked is: " + spaceClicked);
                    Debug.Log("The match I am in is: " + Match.currentMatch.id);

                }
            }
        }
    }
}
