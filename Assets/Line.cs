using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using System.Linq;

public class Line : MonoBehaviour
{

    public GameObject[] obj = {};
    public float shift;
    private Vector3[] path;
    private int c = 0;
    private int i = 0;

    void Start()
    {
        path = obj.Select(x => x.transform.position).ToArray();
        //ShiftArray(shift);
        print(obj[0].ToString() + "\n");
        transform.DOLocalPath(path, 2.0f, PathType.CatmullRom).SetEase(Ease.Linear).SetLookAt(0.01f, Vector3.forward).SetOptions(false, AxisConstraint.Y).SetLoops(-1).SetDelay(shift);
    }

    void Update()
    {
    }

    /*
    void ShiftArray(int count)
    {
        Vector3 tmp;
        for (c = 0; c < count; c++)
        {
            tmp = path[0];
            for (i = 0; i < path.Length-1; i++)
            {
                path[i] = path[i + 1];
            }
            path[path.Length-1] = tmp;
        }
    }
    */
}
