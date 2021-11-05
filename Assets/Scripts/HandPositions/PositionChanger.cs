using System.Collections.Generic;
using UnityEngine;

public class PositionChanger : MonoBehaviour
{
    [SerializeField] private List<Position> positions;

    private int currentPosition = -1;

    /*private void Start()
    {
        currentPosition = 0;
        Debug.Log($"currentPosition: {currentPosition}");
        for (int i = 0; i < positions.Count; i++)
            positions[i].ChangeActive(i == currentPosition);
    }

    private void Update()
    {
        if(positions[currentPosition].IsWellDone())
        {
            positions[currentPosition].ChangeActive(false);

            currentPosition = (currentPosition + 1) % positions.Count;
            //first position does not enter into the loop
            if (currentPosition == 0)
                currentPosition = 1;
            Debug.Log($"currentPosition: {currentPosition}");

            positions[currentPosition].ChangeActive(true);
        }
    }*/

    private void Update()
    {
        if (currentPosition != -1)
            positions[currentPosition].IsWellDone();
    }

    public void ShowPosition(string position)
    {
        Debug.Log($"llegue ShowPosition {position}");
        int positionInt = int.Parse(position);

        if (currentPosition != -1)
            positions[currentPosition].ChangeActive(false);

        positions[positionInt].ChangeActive(true);
        currentPosition = positionInt;
    }

    public void DisablePositions()
    {
        foreach (Position position in positions)
            position.ChangeActive(false);
    }
}
