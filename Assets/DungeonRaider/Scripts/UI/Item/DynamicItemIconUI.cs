using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.U2D;
using UnityEngine.UI;

namespace DungeonRaider.UI
{
    public class DynamicItemIconUI : ItemIconUI
    {
        [SerializeField] private Image _weaponIcon;
        [SerializeField] private Image _bootsIcon;
        [SerializeField] private Image[] _glovesIcons;
        [SerializeField] private Image[] _shoulderIcons;

        public override void SetItem(Item item)
        {
            Clear();
            Sprite sprite = _gameConfig.ItemsConfig.GetSprite(item);
            switch (item.ItemType)
            {
                case ItemType.Weapon:
                    SetSprite(_weaponIcon, sprite);
                    break;
                case ItemType.Shoulder:
                    foreach (var icon in _shoulderIcons)
                    {
                        SetSprite(icon, sprite);
                    }
                    break;
                case ItemType.Hands:
                    foreach (var icon in _glovesIcons)
                    {
                        SetSprite(icon, sprite);
                    }
                    break;
                case ItemType.Legs:
                    SetSprite(_bootsIcon, sprite);
                    break;
                default:
                    foreach (var icon in _icons)
                    {
                        SetSprite(icon, sprite);
                    }
                    break;
            }
            SetLevel(item.Level, item.Tier);
        }

        public override void Clear()
        {
            base.Clear();
            ClearSprite(_weaponIcon);
            ClearSprite(_bootsIcon);
            foreach (var icon in _shoulderIcons)
            {
                ClearSprite(icon);
            }
            foreach (var icon in _glovesIcons)
            {
                ClearSprite(icon);
            }
        }

        private void SetSprite(Image image, Sprite sprite)
        {
            image.enabled = true;
            image.sprite = sprite;
        }

        private void ClearSprite(Image image)
        {
            if(_placeHolder != null)
            {
                image.sprite = _placeHolder; 
            }
            else
            {
                image.enabled = false;
            }
        }
    }
}