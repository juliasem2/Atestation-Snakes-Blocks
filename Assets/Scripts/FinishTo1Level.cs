using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinishTo1Level : MonoBehaviour
{
    public GameObject HeadSnake;
    public GameObject WonPanel;
    public GameObject GamePanel;
    public AudioClip Won;
    private AudioSource _audio;
    public ParticleSystem ParticleSystem;

    // Start is called before the first frame update
    void Start()
    {

    }
    private void Awake()
    {
        _audio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("You WON!!!");
        HeadSnake.GetComponent<Control>().enabled = false;
        HeadSnake.GetComponent<Rigidbody>().isKinematic = true;
        _audio.PlayOneShot(Won);
        GamePanel.SetActive(false);
        WonPanel.SetActive(true);
        ParticleSystem.Play();
        //ReloadLevel();
        //HeadSnake.GetComponent<Control>().enabled = false;
        Debug.Log(HeadSnake.GetComponent<Control>().enabled = false);
        //HeadSnake.transform.position = new Vector3(0, 1, -75);
        //HeadSnake.GetComponent<Control>().enabled = true;
        //HeadSnake.GetComponent<Snake>().Level = "Level 1";
    }
    public void ReloadLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
