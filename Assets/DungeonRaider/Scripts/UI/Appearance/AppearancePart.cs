using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace DungeonRaider.Appearance
{
    public class AppearancePart : MonoBehaviour
    {
        [Inject] private GameData _gameData;
        [Inject] private GameConfig _gameConfig;

        [SerializeField] private List<Image> _icons;
        [SerializeField] private ItemType _itemType;
        [SerializeField] private Sprite _bodyPart;

        private void Start()
        {
            _gameData.PlayerCharacter.Inventory.OnItemChanged += ItemChangeHandler;
            ItemChangeHandler(_itemType);
        }

        private void OnDestroy()
        {
            _gameData.PlayerCharacter.Inventory.OnItemChanged -= ItemChangeHandler;
        }

        public void SetIcon(Sprite sprite)
        {
            foreach (var icon in _icons)
            {
                icon.sprite = sprite;
                icon.enabled = true;
            }
        }


        public void Clear()
        {
            if (_bodyPart != null)
            {
                foreach (var icon in _icons)
                {
                    icon.sprite = _bodyPart;
                }
            }
            else
            {
                foreach (var icon in _icons)
                {
                    icon.enabled = false;
                }
            }
        }

        private void ItemChangeHandler(ItemType type)
        {
            if (type != _itemType)
                return;
            if(_gameData.PlayerCharacter.Inventory.TryGetItem(type, out Item item))
            {
                SetIcon(_gameConfig.ItemsConfig.GetSprite(item));
            }
            else
            {
                Clear();
            }
        }
    }
}