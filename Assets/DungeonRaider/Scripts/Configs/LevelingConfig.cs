using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "DR/Leveling")]
public class LevelingConfig : ScriptableObject
{
    [SerializeField] private List<int> _xpReqiredforLvlUp;

    public int GetXpReqirement(int level)
    {
        if(level >= _xpReqiredforLvlUp.Count)
            return _xpReqiredforLvlUp[_xpReqiredforLvlUp.Count - 1];
        return _xpReqiredforLvlUp[level];
    }
}
