using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

namespace DungeonRaider.UI
{
    public class ProgressorUI : MonoBehaviour
    {
        [SerializeField] private RectTransform _progressor;
        [SerializeField] private float _speed = 0.4f;

        private Sequence _sequence;

        public void SetValue(float value)
        {
            float current = _progressor.localScale.x;
            _sequence.Kill();
            _sequence.Append(DOTween.To(() => current, x => x = current = x, value, _speed).OnUpdate(
                () =>
                {
                    _progressor.localScale = new Vector3(current, 1, 1);
                }
                ));
        }
    }
}
