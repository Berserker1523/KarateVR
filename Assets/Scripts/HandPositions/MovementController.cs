using UnityEngine;
using System;
using System.Collections.Generic;

public class MovementController : MonoBehaviour
{
    [SerializeField] private List<Movement> movements;

    public void EmpezarEntrenamiento(string movementName)
    {
        GameObject movement = GetMovement(movementName);
        movement.SetActive(true);
    }

    public void TerminarEntrenamiento(string movementName)
    {
        GameObject movement = GetMovement(movementName);
        movement.SetActive(false);
    }

    private GameObject GetMovement(string name)
    {
        foreach(Movement movement in movements)
        {
            if (movement.name.Equals(name))
                return movement.gameObject;
        }
        return null;
    }

    [Serializable]
    public class Movement
    {
        public string name;
        public GameObject gameObject;
    }
}
