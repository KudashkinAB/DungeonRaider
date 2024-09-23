using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class ResourceController
{
    private PlayerResourcesData _resources;
    private Dictionary<Resource, List<IResourceObserver>> _observer;

    [Inject]
    private void Construct(GameData gameData)
    {
        Debug.Log("Init resourceC");
        _resources = gameData.PlayerResources;
        Initialize();
    }

    public void Initialize()
    {
        _observer = new Dictionary<Resource, List<IResourceObserver>>();
        foreach(var resource in _resources.GetResourcesList())
        {
            _observer.Add(resource, new List<IResourceObserver>());
        }
    }

    public int GetResource(Resource resource)
    {
        return _resources.GetResource(resource);
    }

    private void SetResourceForced(Resource resource, int value)
    {
        int oldValue = GetResource(resource);
        _resources.SetResource(resource, value);
        NotifyObservers(resource, oldValue, value);
        Debug.Log($"Set resource {resource}: {value}");
    }

    public void AddResource(Resource resource, int value)
    {
        if(value < 0)
            Debug.LogError($"Tryin to add negative {resource}");
        SetResourceForced(resource, _resources.GetResource(resource) + value);
    }

    public bool TrySpendResource(Resource resource, int value)
    {
        if(value <= _resources.GetResource(resource))
        {
            SetResourceForced(resource, GetResource(resource) - value);
            return true;
        }
        else
        {
            return false;
        }
    }

    public void NotifyObservers(Resource resource, int old, int current)
    {
        foreach(var observer in _observer[resource])
        {
            if(observer != null)
                observer.UpdateResource(old, current);
        }
    }

    public void Subscribe(Resource resource, IResourceObserver resourceObserver)
    {
        if (_observer[resource].Contains(resourceObserver) == false)
            _observer[resource].Add(resourceObserver);
    }

    public void Unsubscribe(Resource resource, IResourceObserver resourceObserver)
    {
        if (_observer[resource].Contains(resourceObserver) == true)
            _observer[resource].Remove(resourceObserver);
    }
}
