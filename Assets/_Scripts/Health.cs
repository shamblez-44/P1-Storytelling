using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;



public class Health : MonoBehaviour
{
    [SerializeField]
    private int _maxHp = 100;
    [SerializeField]
    private int _hp;
    
    public bool isMinion = false;
    public bool isGangster = false;
    public int MaxHp => _maxHp;
    public bool isBoss = false;

    public int Hp
    {
        get => _hp;
        private set
        {
            var isDamage = value < _hp;
            _hp = Mathf.Clamp(value, 0, _maxHp);
            if (isDamage)
            {
                Damaged?.Invoke(_hp);
            }
            else
            {
                Healed?.Invoke(_hp);
            }
            if (isBoss && _hp < 25)
            {
                AudioManager.Instance.StartEndSound();
            }
            if (_hp <= 0)
            {
                if (isMinion) { 
                    GameObject.FindFirstObjectByType<CultBossVulnerability>().LostMinion();
                }

                if (isGangster)
                {
                    GameObject.FindFirstObjectByType<ToEndScene>().LostGangster();
                }

                Died?.Invoke();
            }
        }
    }

    public UnityEvent<int> Healed;
    public UnityEvent<int> Damaged;
    public UnityEvent Died;

    private void Awake()
    {
        _hp = _maxHp;
    }

    public void Damage(int amount) => Hp -= amount;

    public void Heal(int amount) => Hp += amount;

    public void HealFull() => Hp = _maxHp;
    public void Kill() => Hp = 0;
    public void Adjust(int value) => Hp = value;

}