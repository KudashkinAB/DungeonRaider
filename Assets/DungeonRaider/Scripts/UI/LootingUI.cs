using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;
using UnityEngine.UI;
using Doozy;
using Doozy.Runtime.UIManager.Containers;

namespace DungeonRaider.UI {
    public class LootingUI : MonoBehaviour
    {
        [Inject] private LootingSystem _lootingSystem;
        [Inject] private GameData _gameData;

        [SerializeField] private UIView _view;
        [SerializeField] private ItemDescriptionComparedUI _itemDescriptionCompared, _comparedDescription;
        [SerializeField] private Button _lootButton;
        [SerializeField] private Button _closeButton, _sellButton, _useButton;

        private void Start()
        {
            _lootButton.onClick.AddListener(Loot);
            _useButton.onClick.AddListener(Use);
            _sellButton.onClick.AddListener(Sell);
            _closeButton.onClick.AddListener(Close);
        }

        public void Loot()
        {
            if (_lootingSystem.HasItems)
            {
                Compare();
            }
            else
            {
                if (_lootingSystem.TryToLoot())
                {
                    Compare();
                }
            }
        }
    
        public void Compare()
        {
            _view.Show();
            Item lootItem = _lootingSystem.CurrentItem;
            _gameData.PlayerCharacter.Inventory.TryGetItem(lootItem.ItemType, out Item currentItem);
            if(currentItem != null)
            {
                _comparedDescription.SetItem(currentItem);
                _itemDescriptionCompared.SetComparedItem(lootItem, currentItem);
                _itemDescriptionCompared.gameObject.SetActive(true);
            }
            else
            {
                _comparedDescription.SetItem(lootItem);
                _itemDescriptionCompared.gameObject.SetActive(false);
            }
        }

        public void Close()
        {
            _view.Hide();
        }

        public void Sell()
        {
            _lootingSystem.SellCurrent();
            Close();
        }

        public void Use()
        {
            _lootingSystem.EqipCurrent();
            Close();
        }
    }
}