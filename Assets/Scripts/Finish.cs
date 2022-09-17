using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Finish : MonoBehaviour
{
    public GameObject HeadSnake;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("You WON!!!");
        HeadSnake.GetComponent<Control>().enabled = false;
        HeadSnake.transform.position = new Vector3(-1, 1, 158);
        HeadSnake.GetComponent<Control>().enabled = true;
        HeadSnake.GetComponent<Snake>().Level = "Level 2";
    }
}
