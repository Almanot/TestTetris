using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shape : MonoBehaviour
{
    [Tooltip("Count of blocks in the current shape")]
    public List<GameObject> blocks;
    public GameObject myStartPosition;

    private void Start()
    {
        SetPosition();
    }

    public void SetPosition()
    {
        if (GetComponentInParent<Transform>())
        {
            transform.position = myStartPosition.transform.position;
        }
    }

    public void Destroy()
    {
        myStartPosition.GetComponent<SpawnPosition>().shape = null;
        Destroy(gameObject);
    }

    private void OnDestroy()
    {
        GameManager.instance.FillNewShapes();
        GameManager.instance.CheckForLoose();
    }
}
