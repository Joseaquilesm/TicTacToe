using System.Collections;
using System.Collections.Generic;
using Scripts.Models;
using UnityEngine;

public class Board : MonoBehaviour
{
    [SerializeField]
    private GameObject space;
    // Start is called before the first frame update
    void Start()
    {
        Vector3[] boardMap = new Vector3[]
        {
            new Vector3(-2.0f, 2.0f),
            new Vector3(0f, 2.0f),
            new Vector3(2.0f, 2.0f),

            new Vector3(-2.0f, 0f),
            new Vector3(0f, 0f),
            new Vector3(2.0f, 0f),

            new Vector3(-2.0f, -2.0f),
            new Vector3(0f, -2.0f),
            new Vector3(2.0f, -2.0f),

    };
        for (int i = 0; i < 9; i++)
        {
            GameObject boardSpace = Instantiate(space);
            boardSpace.transform.parent = gameObject.transform;
            boardSpace.transform.position = boardMap[i];

            Space spaceCheck = boardSpace.GetComponent<Space>();
            if(spaceCheck != null)
            {
                spaceCheck.spaceClicked = (ushort) i;
            }


        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Click(ushort spaceClicked)
    {
        Debug.Log("clicked: " + spaceClicked);
    }
    public void SpaceClicked(ushort space)
    {
      
        Match.currentMatch.SendSpaceClicked(space);
    }
}
