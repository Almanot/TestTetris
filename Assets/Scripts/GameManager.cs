using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    #region singleton
    public static GameManager instance;
    private void Awake()
    {
        if (instance == null) instance = this;
    }
    #endregion

    [SerializeField]private GameObject gameOver;
    int CounterForDefeat = 0;

    private void Start()
    {
        FillNewShapes();
    }

    [SerializeField] private GameObject[] shapePrefabs;
    [SerializeField] private List<GameObject> spawns;

    public void FillNewShapes()
    {
        foreach (GameObject obj in spawns)
        {
            if (obj.GetComponent<SpawnPosition>().shape != null)
            {
                return;
            }
        }
        foreach (GameObject objct in spawns)
        {
            objct.GetComponent<SpawnPosition>().shape = Instantiate(GenerateNewShape(), objct.transform);
            objct.GetComponent<SpawnPosition>().shape.GetComponent<Shape>().myStartPosition = objct; //this need for exclude "missing(Game Object)" problem 
            objct.GetComponent<SpawnPosition>().shape.transform.localScale = new Vector3(0.75f, 0.75f, 1);
        }
        CheckForLoose();
    }

    public void CheckForLoose() // check whole plane if there no space to place the remaining figures - player loose
    {
        foreach (GameObject obj in spawns)
        {
            if (obj.GetComponent<SpawnPosition>().shape != null)
            {
                if (!GameFieldController.instance.CheckWholeSpace(obj.GetComponent<SpawnPosition>().shape.GetComponent<Shape>()))
                {
                    CounterForDefeat++;
                }
            }
            else CounterForDefeat++;
        }
        if(CounterForDefeat == 3)
        {
            gameOver.SetActive(true);
        }
        CounterForDefeat = 0;
    }

    GameObject GenerateNewShape()
    {
        int random = Random.Range(0, shapePrefabs.Length);
        return shapePrefabs[random];
    }
}