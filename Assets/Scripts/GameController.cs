using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public AudioSource[] audioData;

    private string state;
    private int audioIndex;

    private bool firstTimeChangestate;

    // Start is called before the first frame update
    void Start()
    {
        state = "StateStart";
        audioIndex = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (state == "StateStart")
        {
            StateStart();
        }

        if (state == "StateIntro")
        {
            StateIntro();
        }

        if (state == "StateDirectionInput")
        {
            StateDirectionInput();
        }

        if (state == "StateResult")
        {
            StateResult();
        }
    }

    void StateStart() {
        if (firstTimeChangestate) {
            firstTimeChangestate = false;
            StartCoroutine(WaitForStart());
        }
    }

    IEnumerator WaitForStart()
    {
        yield return new WaitForSeconds(3);
        state = "StateIntro";
        firstTimeChangestate = true;
    }

    void StateIntro() {
        if (firstTimeChangestate) {
            firstTimeChangestate = false;
            StartCoroutine(WaitForIntro());
        }
    }

    IEnumerator WaitForIntro()
    {
        yield return new WaitForSeconds(5);
        state = "StateIntro";
        firstTimeChangestate = true;
    }

    void StateListen() {
        audioData[audioIndex].Play(0);
        Debug.Log("started play audio");

        if (audioData[audioIndex].isPlaying) {
            state = "StateDirectionInput";
        }
    }

    void StateDirectionInput() {
        
    }

    void StateResult() {

    }
}
