using System;
using TMPro;
using UnityEngine;

namespace Example.Game
{
  public class FollowCamera : MonoBehaviour
  {
    [SerializeField] private Transform _target;
    public void SetFollow(Transform t) => _target = t;

    private void LateUpdate()
    {
      if (!_target) return;

      var newPos = _target.position - new Vector3(0, 0, -1.5f) * -5;
      newPos.y = 10;
      
      transform.position = newPos;
      transform.LookAt(_target.position);
    }
  }
}