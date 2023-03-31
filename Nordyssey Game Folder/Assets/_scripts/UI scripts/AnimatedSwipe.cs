using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatedSwipe : MonoBehaviour
{
    public bool hasMoved;

    public Animator groupAnimator;
    public GameObject qrCodeScanButton;

    // Start is called before the first frame update
    void Start()
    {
        groupAnimator = gameObject.GetComponent<Animator>();
    }

    public void MoveCanvas()
    {
        hasMoved = !hasMoved;
        groupAnimator.SetBool("move", hasMoved);
        qrCodeScanButton.SetActive(!hasMoved);
    }
}
