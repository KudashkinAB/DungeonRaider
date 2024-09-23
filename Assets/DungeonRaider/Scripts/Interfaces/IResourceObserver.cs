using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IResourceObserver
{
    public void UpdateResource(int old, int current);
}
