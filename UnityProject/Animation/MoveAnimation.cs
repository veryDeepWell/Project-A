using UnityEngine;

public class MoveAnimation : MonoBehaviour
{

    static public void Revers(Transform _obj,bool right)
    {
        if (right)
            _obj.localScale = new Vector3(Mathf.Abs(_obj.localScale.x) * -1, _obj.localScale.y, _obj.localScale.z);
        else
        {
            _obj.localScale = new Vector3(Mathf.Abs(_obj.localScale.x), _obj.localScale.y, _obj.localScale.z);
        }
    }
    static public void OnMoving(Animator _animator)
    {
        _animator.SetBool("Moving", true);
    }
    static public void OnStand(Animator _animator)
    {
        _animator.SetBool("Moving", false);
    }
}
