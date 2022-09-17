using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = System.Random;

public class SetNumber : MonoBehaviour
{
    public GameObject gameObgect;
    public int Min;
    public int Max;
    // Start is called before the first frame update
    void Start()
    {
        Random random = new Random();
        gameObgect.GetComponent<TMPro.TextMeshPro>().text = random.Next(Min, Max).ToString();
    }

}
