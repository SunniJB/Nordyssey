using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatedSwipe : MonoBehaviour
{
    public bool hasMoved;

    public Animator groupAnimator;
    // Start is called before the first frame update
    void Start()
    {
        gameObject.GetComponent<Animator>();
    }

    public void MoveCanvas()
    {
        hasMoved = !hasMoved;
        groupAnimator.SetBool("move", hasMoved);
    }
}
