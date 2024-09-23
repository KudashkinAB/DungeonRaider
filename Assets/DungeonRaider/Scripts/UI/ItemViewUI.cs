using Doozy.Runtime.UIManager.Containers;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace DungeonRaider.UI
{
    public class ItemViewUI : MonoBehaviour
    {
        private Inventory _invetory;

        [SerializeField] private UIView _view;
        [SerializeField] private ItemDescriptionUI _itemDescription;
        [SerializeField] private Button _closeButton;

        [Inject]
        private void Construct(GameData gameData)
        {
            _invetory = gameData.PlayerCharacter.Inventory;
        }

        private void Start()
        {
            _closeButton.onClick.AddListener(Close);
        }

        public void TryOpen(ItemType itemType)
        {
            if(_invetory.TryGetItem(itemType, out Item item))
            {
                _itemDescription.SetItem(item);
                _view.Show();
            }
        }

        public void Close()
        {
            _view.Hide();
        }
    }
}
