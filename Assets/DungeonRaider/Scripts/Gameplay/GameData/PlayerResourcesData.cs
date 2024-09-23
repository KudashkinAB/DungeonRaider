using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerResourcesData
{
    private Dictionary<Resource, int> _resources = new Dictionary<Resource, int>()
    {
        { Resource.Money, 0 },
        { Resource.Keys, 100 }
    };

    public PlayerResourcesData()
    {
        _resources = new Dictionary<Resource, int>()
    {
        { Resource.Money, 0 },
        { Resource.Keys, 100 }
    };
    }

    public int GetResource(Resource resource)
    {
        return _resources[resource];
    }

    public int SetResource(Resource resource, int value)
    {
        return _resources[resource] = value;
    }

    public List<Resource> GetResourcesList()
    {
        return new List<Resource>() { Resource.Money, Resource.Keys };
    }
}
