using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CellController : MonoBehaviour
{
    [SerializeField] private SpriteRenderer icon;
    public int myXposition;
    public int myYposition;
    [SerializeField] private bool isBusy = false;

    private void Start()
    {
        icon = GetComponent<SpriteRenderer>();
    }
    public void SetBusy()
    {
        icon.enabled = true;
        isBusy = true;
    }
    public void Clear()
    {
        icon.enabled = false;
        isBusy = false;
    }

    public void SaveCoords(float x, float y)
    {
        myXposition = Mathf.RoundToInt(x);
        myYposition = Mathf.RoundToInt(y);
    }

    public bool CheckBusy()
    {
        return isBusy;
    }
}
