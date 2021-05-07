using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using UnityEngine;


namespace Shelb.CharacterStat {
    [Serializable]
    public class CharacterStat
    {
        public float BaseValue;

        public virtual float Value
        {
            get
            {
                if (_isDirty || BaseValue != _lastBaseValue)
                {
                    _lastBaseValue = BaseValue;
                    _value = CalculateFinalValue();
                    _isDirty = false;
                }
                return _value;
            }
        }

        protected bool _isDirty = true;
        protected float _value;
        protected float _lastBaseValue = float.MinValue;

        protected readonly List<StatModifier> _statModifiers;
        public readonly ReadOnlyCollection<StatModifier> StatModifiers;

        public CharacterStat()
        {
            _statModifiers = new List<StatModifier>();
            StatModifiers = _statModifiers.AsReadOnly();
        }

        public CharacterStat(float baseValue) : this()
        {
            BaseValue = baseValue;
        }

        public virtual void AddModifier(StatModifier mod)
        {
            _isDirty = true;
            _statModifiers.Add(mod);
            _statModifiers.Sort(CompareModifierOrder);
        }

        protected virtual int CompareModifierOrder(StatModifier a, StatModifier b)
        {
            if (a.Order < b.Order)
                return -1;
            else if (a.Order > b.Order)
                return 1;
            return 0;
        }

        public virtual bool RemoveModifier(StatModifier mod)
        {
            if (_statModifiers.Remove(mod))
            {
                _isDirty = true;
                return true;
            }
            return false;
        }

        public virtual bool RemoveAllModifiersFromSource(object source)
        {
            bool _didRemove = false;

            for (int i = _statModifiers.Count - 1; i >= 0; i--)
            {
                if (_statModifiers[1].Source == source)
                {
                    _isDirty = true;
                    _didRemove = true;
                    _statModifiers.RemoveAt(i);
                }
            }

            return _didRemove;
        }

        protected virtual float CalculateFinalValue()
        {
            float _finalValue = BaseValue;
            float _sumPercentAdd = 0;

            for (int i = 0; i < _statModifiers.Count; i++)
            {
                StatModifier mod = _statModifiers[i];

                if (mod.Type == StatModType.Flat)
                {
                    _finalValue += mod.Value;
                }
                else if (mod.Type == StatModType.PercentAdd)
                {
                    _sumPercentAdd += mod.Value;

                    if (i + 1 >= _statModifiers.Count || _statModifiers[i + 1].Type != StatModType.PercentAdd)
                    {
                        _finalValue *= 1 + _sumPercentAdd;
                        _sumPercentAdd = 0;
                    }
                }
                else if (mod.Type == StatModType.PercentMult)
                {
                    _finalValue *= 1 + mod.Value;
                }
            }

            return (float)Math.Round(_finalValue, 4);
        }
    }
}
