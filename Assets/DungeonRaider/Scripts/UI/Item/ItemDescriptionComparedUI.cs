using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace DungeonRaider.UI
{
    public class ItemDescriptionComparedUI : ItemDescriptionUI
    {
        [SerializeField] private Color _baseColor;
        [SerializeField] private Color _positiveColor;
        [SerializeField] private Color _negativeColor;

        private Item _comparedItem;

        public void SetComparedItem(Item item, Item comparedItem)
        {
            _comparedItem = comparedItem;
            SetItem(item);
        }

        public override void SetStat(Stat stat, float value)
        {
            if (Stats.BaseStats.Contains(stat))
            {
                TMP_Text statText = _stats[Stats.BaseStats.IndexOf(stat)];
                statText.text = value.ToString("0.00");
                if (_comparedItem != null)
                {
                    if(_item.Stats.Get(stat) > _comparedItem.Stats.Get(stat))
                    {
                        statText.color = _positiveColor;
                    }
                    else
                    {
                        statText.color = _item.Stats.Get(stat) == 0 ? _baseColor : _negativeColor;
                    }
                }
                else
                {
                    statText.color = _baseColor;
                }
            }
            else
            {
                if(value > 0)
                    _enchantment.text += $"{stat}: {(value * 100f).ToString("0.00")}%\n";
            }
        }
    }
}