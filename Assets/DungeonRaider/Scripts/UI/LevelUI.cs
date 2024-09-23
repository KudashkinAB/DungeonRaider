using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using Zenject;

namespace DungeonRaider.UI
{
    public class LevelUI : MonoBehaviour
    {
        [Inject] private LevelingController _leveling;

        [SerializeField] private TMP_Text _level;
        [SerializeField] private TMP_Text _exp;
        [SerializeField] private ProgressorUI _progressor;

        private void Start()
        {
            _leveling.OnXpChanged += ExpUpdateHandler;
            UpdateLeveling();
        }

        private void OnDestroy()
        {
            _leveling.OnXpChanged -= ExpUpdateHandler;
        }

        public void UpdateLeveling()
        {
            _level.text = $"LEVEL {_leveling.CurrentLevel}";
            _exp.text = $"{_leveling.CurrentXp} / {_leveling.ReqiredXp}";
            _progressor.SetValue((float)_leveling.CurrentXp / (float)_leveling.ReqiredXp);
        }

        private void ExpUpdateHandler(int xp)
        {
            UpdateLeveling();
        }
    }
}