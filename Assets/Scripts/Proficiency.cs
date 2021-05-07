using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Proficiency : MonoBehaviour
{
    public Stats _statMods;

    //---------------------------------------------------------------------------------------------------------
    [SerializeField] Button StrengthProf;

    private void Start()
    {
        StrengthProf.onClick.AddListener(AddStrengthProf);
    }

    // Update is called once per frame
    void AddStrengthProf()
    {
        _statMods.Strength.AddModifier(new StatModifier(2, StatModType.Flat));
    }
}
