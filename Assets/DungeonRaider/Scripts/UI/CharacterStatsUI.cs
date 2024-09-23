using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using Zenject;

namespace DungeonRaider.UI
{
    public class CharacterStatsUI : MonoBehaviour
    {
        [Inject] private GameData _gameData;

        [SerializeField] private TMP_Text[] _baseStats;
        [SerializeField] private TMP_Text _enchantment;

        private void Start()
        {
            _gameData.PlayerCharacter.OnStatsChanged += UpdateCharacterStats;
            UpdateCharacterStats();
        }

        private void OnDestroy()
        {
            _gameData.PlayerCharacter.OnStatsChanged -= UpdateCharacterStats;
        }

        private void SetStats(Stats stats)
        {
            for (int i = 0; i < Stats.BaseStats.Count; i++)
            {
                _baseStats[i].text = stats.Get(Stats.BaseStats[i]).ToString("0.00");
            }
            _enchantment.text = "";
            foreach (var enchantment in Stats.Enchants)
            {
                float enchantmentValue = stats.Get(enchantment);
                _enchantment.text += $"{enchantment}:\n{(stats.Get(enchantment) * 100f).ToString("0.00")}%\n";
            }
        }

        private void UpdateCharacterStats()
        {
            SetStats(_gameData.PlayerCharacter.Stats);
        }
    }
}