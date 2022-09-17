using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class SetColor : MonoBehaviour
{
    public float GradientPosition;
    private Shader shader;
    Renderer rend;

    // Start is called before the first frame update
    void Start()
    {
        //SetColorOnCube();
        rend = GetComponent<Renderer>();
        rend.material.shader = Shader.Find("Shader1");
    }
    private void Update()
    {
        float GradientPosition = 1f;
        rend.material.SetFloat("_SetPositionOnGradient", GradientPosition);
    }

    //void SetColorOnCube()
    //{
    //    Debug.Log("!!!!!!!!!!!!!!!!!");
        
    //    if (int.TryParse(this.GetComponentInChildren<TextMeshPro>().text, out int _memory))
    //    {
    //        GradientPosition = _memory / 25;
    //        Debug.Log("GradientPosition: "+GradientPosition);
    //    }

    //    this.GetComponent<Renderer>().sharedMaterial.SetFloat("SetPositionOnGradient", GradientPosition);
    //}
}
    
