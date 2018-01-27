using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Renderer))]
public class DepthSorting : MonoBehaviour
{
    Renderer rend;

    private void Start()
    {
        rend = GetComponent<Renderer>();
    }

    void Update()
    {
        rend.sortingOrder = GlobalMethods.GetSortingOrderFromPositionY(transform.position.y);
    }
}
