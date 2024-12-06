using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using System;

public class OpenStatsPanel : MonoBehaviour
{
    //public Vector3 newPos;
    public Transform newPosition;
    public bool isClased = true;
    public Transform mainPosition;
    public void Start()
    {
      
    }
    public void OpenPanelStats()
    {
        if (isClased)
        {
            transform.DOMove(newPosition.position, 1f, false);
            isClased = !isClased;

        }
        else
        {
            transform.DOMove(mainPosition.position, 1f, false);
            isClased = !isClased;
            Debug.Log("3aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaasba");
        }
    }


}
