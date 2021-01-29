using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class menu : MonoBehaviour
{
    public Animation anim;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void StartGame()
    {
        //go to game scene
    }

    public void Controls()
    {
        anim.Play("Controls");
    }

    public void ControlsBack()
    {
        anim.Play("Controls_Back");
    }

    public void QuitGame()
    {
        Application.Quit();
    }

}
