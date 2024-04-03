using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataManager
{
    public Dictionary<int, StatData> stat = new Dictionary<int, StatData>();
    public HashSet<BulletController> Bullets = new HashSet<BulletController>();
    public StatData Setting(bool _isplayer, int _max, int _current, int _bulletDMG, int _bulletLV, int _moveSPD)
    {
        StatData _data = new StatData();
        _data.maxHP = _max;
        _data.currentHP = _bulletDMG;
        _data.bulletLevel = _bulletLV;
        _data.moveSpeed = _moveSPD;
        if (_isplayer)
        {
            Init(_data, 0);
        }
        else
        {
            Init(_data, stat.Count);
        }
        return _data;
    }

    public void Init(StatData _data, int CreatureNumber)
    {
        if (stat.ContainsKey(CreatureNumber))
        {
            if (stat[CreatureNumber] == _data) { }
            else
            {
                Debug.LogWarning($"�̹� ���� {CreatureNumber}�� ������ ���Ͱ� �����Ϳ� ������ ��ȣ�� �޶��");
                Init(_data, CreatureNumber +1);
            }
        }
        else
        {
            stat.Add(CreatureNumber, _data);
        }
    }
}

public class StatData
{
    public float maxHP;
    public float currentHP;
    public float bulletDMG;
    public float bulletLevel;
    public float moveSpeed;

}
