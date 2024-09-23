using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Zenject;
using System.Linq;

namespace DungeonRaider.UI
{
    public class ItemDescriptionUI : MonoBehaviour
    {
        [Inject] protected GameConfig _gameConfig;

        [SerializeField] protected TMP_Text _itemName;
        [SerializeField] protected ItemIconUI _itemIcon;
        [SerializeField] protected TMP_Text _level;
        [SerializeField] protected TMP_Text[] _stats;
        [SerializeField] protected TMP_Text _enchantment;
        
        protected Item _item;

        public virtual void SetItem(Item item)
        {
            _item = item;
            _enchantment.text = "";
            _itemName.text = $"[{_gameConfig.TierConfig.GetTier(item.Tier).Name}] {_gameConfig.ItemsConfig.GetItemName(item)}";
            _itemName.color = _gameConfig.TierConfig.GetTier(item.Tier).Color;
            _itemIcon.SetItem(item);
            SetLevel(item.Level);
            foreach (var stat in Stats.AllStats)
                SetStat(stat, item.Stats.Get(stat));
        }

        public virtual void SetStat(Stat stat, float value)
        {
            if (Stats.BaseStats.Contains(stat))
            {
                TMP_Text statText = _stats[Stats.BaseStats.IndexOf(stat)];
                statText.text = value.ToString("0.0");
            }
            else
            {
                if(value > 0)
                    _enchantment.text += $"{stat}: {(value * 100f).ToString("0.00")}%\n";
            }
        }

        public virtual void SetLevel(int level)
        {
            if (_level == null)
                return;
            _level.text = "LVL " + level.ToString();
        }
    }
}