using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameFieldController : MonoBehaviour
{
    #region Singleton
    public static GameFieldController instance;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else Debug.Log("More than one instance");

        InstantiateField();
    }
    #endregion

    [SerializeField] private GameObject cellPrefab;
    [Space]
    [SerializeField] private int VerticalSpace;
    [SerializeField] private int HorizontalSpace;


    public GameObject[,] GameField;

    void InstantiateField()
    {
        GameField = new GameObject[VerticalSpace, HorizontalSpace];
        for (int i = 0; i < VerticalSpace; i++)
        {
            for (int j = 0; j < HorizontalSpace; j++)
            {
                GameField[i, j] = Instantiate(cellPrefab, new Vector3(i, j, 0), transform.rotation, transform);
                if (GameField[i, j])
                {
                    GameField[i, j].GetComponent<CellController>().SaveCoords(i, j);
                }

            }
        }
    }

    public bool CheckTheSpace(Vector3 cords, Shape shape) // check the current cell and his neighbors for possibility place the current figure
    {
        foreach (GameObject i in shape.blocks)
        {
            int X = Mathf.RoundToInt(cords.x) + i.GetComponent<CellController>().myXposition;
            int Y = Mathf.RoundToInt(cords.y) + i.GetComponent<CellController>().myYposition;

            //Check if the dragged shape is in the field
            if ((X >= 0 && X < GameField.GetLength(0)) && (Y >= 0 && Y < GameField.GetLength(1)))
            {
                //if in the field, check the free space for current shape;
                if (GameField[X, Y].GetComponent<CellController>().CheckBusy())
                {
                    return false;
                }
            }
            else return false;
        }
        return true;
    }

    public void PlaceShape(Vector3 cords, Shape shape)
    {
        foreach (GameObject i in shape.blocks)
        {
            int X = Mathf.RoundToInt(cords.x) + i.GetComponent<CellController>().myXposition;
            int Y = Mathf.RoundToInt(cords.y) + i.GetComponent<CellController>().myYposition;

            GameField[X, Y].GetComponent<CellController>().SetBusy();
            CheckLine(Y);
        }
    }

    public bool CheckWholeSpace(Shape shape) //check whole game field for possible to placespecified figure
    {
        foreach (GameObject cell in GameField)
        {
            Vector3 cords = new Vector3();
            cords.x = cell.GetComponent<CellController>().myXposition;
            cords.y = cell.GetComponent<CellController>().myYposition;
            if (!cell.GetComponent<CellController>().CheckBusy())
            {
                if(CheckTheSpace(cords, shape))
                {
                    return true;
                }
            }
        }
        return false;
    }

    public void CheckLine(int lineNumber)//check the line for fullness
    {
        for (int i = 0; i < GameField.GetLength(0); i++)
        {
            if (!GameField[i, lineNumber].GetComponent<CellController>().CheckBusy())
            {
                return;
            }
        }
        ClearLine(lineNumber);
    }

    void ClearLine(int lineNumber)
    {
        for (int i = 0; i < GameField.GetLength(0); i++)
        {
            GameField[i, lineNumber].GetComponent<CellController>().Clear();
        }
    }
}
