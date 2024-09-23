using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;
using UnityEngine.UI;
using TMPro;

namespace DungeonRaider.UI
{
    public class ItemIconUI : MonoBehaviour
    {
        [Inject] protected GameConfig _gameConfig;

        [SerializeField] protected Image[] _icons;
        [SerializeField] protected TMP_Text _level;
        [SerializeField] protected Sprite _placeHolder;

        public virtual void SetItem(Item item)
        {
            foreach(var icon in _icons)
            {
                icon.enabled = true;
                icon.sprite = _gameConfig.ItemsConfig.GetSprite(item);
            }
            SetLevel(item.Level, item.Tier);
        }

        public virtual void Clear()
        {
            foreach(var icon in _icons)
            {
                if(_placeHolder != null)
                    icon.sprite = _placeHolder;
                else
                    icon.enabled = false;
            }
            if (_level != null)
                _level.text = "";
        }

        public virtual void SetLevel(int level, int tier)
        {
            if (_level == null)
                return;
            _level.text = "LVL " + level.ToString();
            _level.color = _gameConfig.TierConfig.GetTier(tier).Color;
        }
    }
}
