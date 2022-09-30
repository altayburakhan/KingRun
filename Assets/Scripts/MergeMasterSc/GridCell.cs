using UnityEngine;

public class GridCell : MonoBehaviour
{
    public bool isOccupied;
    public Unit occupiedUnit;

    

    public GridCell ()
    {
        isOccupied = false;
    }
}
