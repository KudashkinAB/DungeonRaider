using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace DungeonRaider.UI
{
    public class SlotUI : MonoBehaviour
    {
        [Inject] private GameData _gameData;

        [SerializeField] private ItemViewUI _itemViewUI;
        [SerializeField] private ItemType _itemType;
        [SerializeField] private ItemIconUI _itemIcon;
        [SerializeField] private Button _button;

        [Inject]
        private void Construct(GameData gameData)
        {
            gameData.PlayerCharacter.Inventory.OnItemChanged += ItemChangeHandler;
        }

        private void Start()
        {
            _button.onClick.AddListener(ClickHandler);
            UpdateItem();
        }

        private void OnDestroy()
        {
            _button.onClick.RemoveListener(ClickHandler);
            _gameData.PlayerCharacter.Inventory.OnItemChanged -= ItemChangeHandler;
        }

        public void SetItem(Item item)
        {
            _itemIcon.SetItem(item);
        }

        public void UpdateItem()
        {
            if (_gameData.PlayerCharacter.Inventory.TryGetItem(_itemType, out Item item))
            {
                SetItem(item);
            }
            else
            {
                _itemIcon.Clear();
            }
        }

        private void ClickHandler()
        {
            _itemViewUI.TryOpen(_itemType);
        }

        private void ItemChangeHandler(ItemType itemType) 
        {
            if(itemType == _itemType)
                UpdateItem();
        }
    }
}