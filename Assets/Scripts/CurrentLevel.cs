using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CurrentLevel : MonoBehaviour
{
    public GameObject HeadSnake;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnCollisionEnter(UnityEngine.Collision collision)
    {
        if (!collision.collider.TryGetComponent(out Snake snake)) return;
        HeadSnake.GetComponent<Snake>().Level = this.name;
        Debug.Log(this.name);
    }

}
