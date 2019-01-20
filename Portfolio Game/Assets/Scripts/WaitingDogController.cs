using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaitingDogController : MonoBehaviour {

    public GameObject exploreScreenButton;

    private void OnMouseDown()
    {
        exploreScreenButton.SetActive(true);
    }
}
