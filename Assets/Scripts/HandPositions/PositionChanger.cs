using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PositionChanger : MonoBehaviour
{
    [SerializeField] private List<Position> positions;
    private int currentPosition;

    private void Start()
    {
        currentPosition = 0;
        Debug.Log($"currentPosition: {currentPosition}");
        for (int i = 1; i < positions.Count; i++)
        {
            positions[i].positionLeft.transform.parent.gameObject.SetActive(false);
            positions[i].positionRight.transform.parent.gameObject.SetActive(false);
            positions[i].positionLeft.GetComponentInChildren<HandTrigger>().ChangeColor(false);
            positions[i].positionRight.GetComponentInChildren<HandTrigger>().ChangeColor(false);
        }
    }

    private void Update()
    {
        if(positions[currentPosition].positionLeft.GetComponentInChildren<HandTrigger>().IsGreen && positions[currentPosition].positionRight.GetComponentInChildren<HandTrigger>().IsGreen)
        {
            positions[currentPosition].positionLeft.GetComponentInChildren<HandTrigger>().ChangeColor(false);
            positions[currentPosition].positionRight.GetComponentInChildren<HandTrigger>().ChangeColor(false);
            positions[currentPosition].positionLeft.transform.parent.gameObject.SetActive(false);
            positions[currentPosition].positionRight.transform.parent.gameObject.SetActive(false);

            currentPosition = (currentPosition + 1) % positions.Count;
            Debug.Log($"currentPosition: {currentPosition}");

            positions[currentPosition].positionLeft.transform.parent.gameObject.SetActive(true);
            positions[currentPosition].positionRight.transform.parent.gameObject.SetActive(true);
            positions[currentPosition].positionLeft.GetComponentInChildren<HandTrigger>().ChangeColor(false);
            positions[currentPosition].positionRight.GetComponentInChildren<HandTrigger>().ChangeColor(false);
        }
    }

    [Serializable]
    private class Position
    {
        public GameObject positionLeft;
        public GameObject positionRight;
    }


}
