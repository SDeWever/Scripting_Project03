using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Abilities : MonoBehaviour
{
    public Stats _statMods;
    [SerializeField] AudioSource ClickSound;
    //---------------------------------------------------------------------------------------------------------
    [SerializeField] Text MeleeTotal;
    [SerializeField] Text MeleeMod;
    [SerializeField] Text MeleeRoll;
    [SerializeField] Button MeleeButton;
    public float _meleeRoll;
    public int _meleeRollMax;
    public float _meleeTotal;
    //---------------------------------------------------------------------------------------------------------
    [SerializeField] Text ACTotal;
    public float _armorTotal;
    public float _baseAC;
    //---------------------------------------------------------------------------------------------------------
    [SerializeField] Text HealthTotal;
    [SerializeField] Text HealthMod;
    [SerializeField] Text HealthRoll;
    [SerializeField] Button HealthButton;
    public float _healthRoll;
    public int _healthRollMax;
    public float _healthTotal;
    //---------------------------------------------------------------------------------------------------------
    [SerializeField] Text SpellAtckTotal;
    [SerializeField] Text SpellAtckMod;
    [SerializeField] Text SpellAtckRoll;
    [SerializeField] Button SpellAtckButton;
    public float _spellRoll;
    public float _spellTotal;
    //---------------------------------------------------------------------------------------------------------
    [SerializeField] Text SpellSaveTotal;
    public float _saveTotal;
    public float _baseSave;
    //---------------------------------------------------------------------------------------------------------
    [SerializeField] Text SpeechCheckTotal;    
    [SerializeField] Text SpeechCheckMod;
    [SerializeField] Text SpeechCheckRoll;
    [SerializeField] Button SpeechCheckButton;
    public float _speechRoll;
    public float _speechTotal;

    private void Start()
    {
        MeleeButton.onClick.AddListener(RollMelee);
        HealthButton.onClick.AddListener(RollHealth);
        SpellAtckButton.onClick.AddListener(RollSpell);
        SpeechCheckButton.onClick.AddListener(RollSpeech);
    }

    private void Update()
    {
        //---------------------------------------------------------------------------------------------------------
        _meleeTotal = _meleeRoll + _statMods._strengthMod;
        MeleeTotal.text = _meleeTotal.ToString();
        MeleeRoll.text = "(" + _meleeRoll.ToString() + ")";
        if (_statMods._strengthMod >= 0)
        {
            MeleeMod.text = "+" + _statMods._strengthMod.ToString();
        }
        else
        {
            MeleeMod.text = _statMods._strengthMod.ToString();
        }
        //---------------------------------------------------------------------------------------------------------
        _armorTotal = _baseAC + _statMods._dexterityMod;
        ACTotal.text = _armorTotal.ToString();
        //---------------------------------------------------------------------------------------------------------
        _healthTotal = _healthRoll + _statMods._constitutionMod;
        HealthTotal.text = _healthTotal.ToString();
        HealthRoll.text = "(" + _healthRoll.ToString() + ")";
        if (_statMods._constitutionMod >= 0)
        {
            HealthMod.text = "+" + _statMods._constitutionMod.ToString();
        }
        else
        {
            HealthMod.text = _statMods._constitutionMod.ToString();
        }
        //---------------------------------------------------------------------------------------------------------
        _spellTotal = _spellRoll + _statMods._intelligenceMod;
        SpellAtckTotal.text = _spellTotal.ToString();
        SpellAtckRoll.text = "(" + _spellRoll.ToString() + ")";
        if (_statMods._intelligenceMod >= 0)
        {
            SpellAtckMod.text = "+" + _statMods._intelligenceMod.ToString();
        }
        else
        {
            SpellAtckMod.text = _statMods._intelligenceMod.ToString();
        }
        //---------------------------------------------------------------------------------------------------------
        _saveTotal = _baseSave + _statMods._wisdomMod;
        SpellSaveTotal.text = _saveTotal.ToString();
        //---------------------------------------------------------------------------------------------------------
        _speechTotal = _speechRoll + _statMods._charismaMod;
        SpeechCheckTotal.text = _speechTotal.ToString();
        SpeechCheckRoll.text = "(" + _speechRoll.ToString() + ")";
        if (_statMods._charismaMod >= 0)
        {
            SpeechCheckMod.text = "+" + _statMods._charismaMod.ToString();
        }
        else
        {
            SpeechCheckMod.text = _statMods._charismaMod.ToString();
        }
        //---------------------------------------------------------------------------------------------------------
    }

    void RollMelee()
    {
        _meleeRoll = Random.Range(1, _meleeRollMax);
        ClickSound.Play();
    }

    void RollHealth()
    {
        _healthRoll = Random.Range(1, _healthRollMax);
        ClickSound.Play();
    }

    void RollSpell()
    {
        _spellRoll = Random.Range(1, 20);
        ClickSound.Play();
    }

    void RollSpeech()
    {
        _speechRoll = Random.Range(1, 20);
        ClickSound.Play();
    }
}
