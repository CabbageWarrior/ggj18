using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class GlobalMethods
{
    public static int GetSortingOrderFromPositionY(float positionY) {
        return (int)((positionY * -1 * 100) + 1000);
    }
}
