using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NumberLevel : MonoBehaviour
{
    public GameObject HeadSnake;
    public Text Text;
    // Start is called before the first frame update
    void Start()
    {
        //Text.text = "QQQQQQQQQ";
    }
    private void Update()
    {
        Text.text = HeadSnake.GetComponent<Snake>().Level;
        //Text.text = "QQQQQQQQQ";

    }

}
