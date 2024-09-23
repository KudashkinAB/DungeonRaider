using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using Zenject;

namespace DungeonRaider.UI
{
    public class ResourceUI : MonoBehaviour, IResourceObserver
    {
        [Inject] private ResourceController _resourceController;

        [SerializeField] private TMP_Text _resourceText;
        [SerializeField] private Resource _resource;

        private void Start()
        {
            _resourceController.Subscribe(_resource, this);
            UpdateResourceText(_resourceController.GetResource(_resource));
        }

        private void OnDestroy()
        {
            _resourceController.Unsubscribe(_resource, this);
        }

        public void UpdateResourceText(int current)
        {
            _resourceText.text = current.ToString();
        }

        public void UpdateResource(int old, int current)
        {
            UpdateResourceText(current);
        }
    }
}