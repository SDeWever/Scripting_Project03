using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Shelb.CharacterStat;

public class Stats : MonoBehaviour
{
    [SerializeField] Text PointBuyTotal;
    public float _pointBuyTotal = 27;
    [SerializeField] GameObject AllButtons;
    [SerializeField] AudioSource ClickSound;
    //---------------------------------------------------------------------------------------------------------
    public CharacterStat Strength;
    public float _strengthMod;
    [SerializeField] Text StrengthMod;
    [SerializeField] Text StrengthScore;
    [SerializeField] Button StrengthPlus;
    [SerializeField] Button StrengthMinus;
    //---------------------------------------------------------------------------------------------------------
    public CharacterStat Dexterity;
    public float _dexterityMod;
    [SerializeField] Text DexterityMod;
    [SerializeField] Text DexterityScore;
    [SerializeField] Button DexterityPlus;
    [SerializeField] Button DexterityMinus;
    //---------------------------------------------------------------------------------------------------------
    public CharacterStat Constitution;
    public float _constitutionMod;
    [SerializeField] Text ConstitutionMod;
    [SerializeField] Text ConstitutionScore;
    [SerializeField] Button ConstitutionPlus;
    [SerializeField] Button ConstitutionMinus;
    //---------------------------------------------------------------------------------------------------------
    public CharacterStat Intelligence;
    public float _intelligenceMod;
    [SerializeField] Text IntelligenceMod;
    [SerializeField] Text IntelligenceScore;
    [SerializeField] Button IntelligencePlus;
    [SerializeField] Button IntelligenceMinus;
    //---------------------------------------------------------------------------------------------------------
    public CharacterStat Wisdom;
    public float _wisdomMod;
    [SerializeField] Text WisdomMod;
    [SerializeField] Text WisdomScore;
    [SerializeField] Button WisdomPlus;
    [SerializeField] Button WisdomMinus;
    //---------------------------------------------------------------------------------------------------------
    public CharacterStat Charisma;
    public float _charismaMod;
    [SerializeField] Text CharismaMod;
    [SerializeField] Text CharismaScore;
    [SerializeField] Button CharismaPlus;
    [SerializeField] Button CharismaMinus;
    //---------------------------------------------------------------------------------------------------------

    private void Start()
    {
        StrengthPlus.onClick.AddListener(AddStrength);
        StrengthMinus.onClick.AddListener(MinusStrength);

        DexterityPlus.onClick.AddListener(AddDexterity);
        DexterityMinus.onClick.AddListener(MinusDexterity);

        ConstitutionPlus.onClick.AddListener(AddConstitution);
        ConstitutionMinus.onClick.AddListener(MinusConstitution);

        IntelligencePlus.onClick.AddListener(AddIntelligence);
        IntelligenceMinus.onClick.AddListener(MinusIntelligence);

        WisdomPlus.onClick.AddListener(AddWisdom);
        WisdomMinus.onClick.AddListener(MinusWisdom);

        CharismaPlus.onClick.AddListener(AddCharisma);
        CharismaMinus.onClick.AddListener(MinusCharisma);
    }

    public void Update()
    {
        PointBuyTotal.text = "Points to Spend:  " + _pointBuyTotal.ToString();

        if (_pointBuyTotal >= 75)
        {
            StrengthMinus.interactable = false;
            DexterityMinus.interactable = false;
            ConstitutionMinus.interactable = false;
            IntelligenceMinus.interactable = false;
            WisdomMinus.interactable = false;
            CharismaMinus.interactable = false;
        } else if (_pointBuyTotal < 75)
        {
            StrengthMinus.interactable = true;
            DexterityMinus.interactable = true;
            ConstitutionMinus.interactable = true;
            IntelligenceMinus.interactable = true;
            WisdomMinus.interactable = true;
            CharismaMinus.interactable = true;
        }

        if (_pointBuyTotal <= 0)
        {
            StrengthPlus.interactable = false;
            DexterityPlus.interactable = false;
            ConstitutionPlus.interactable = false;
            IntelligencePlus.interactable = false;
            WisdomPlus.interactable = false;
            CharismaPlus.interactable = false;
        }
        else if (_pointBuyTotal > 0)
        {
            StrengthPlus.interactable = true;
            DexterityPlus.interactable = true;
            ConstitutionPlus.interactable = true;
            IntelligencePlus.interactable = true;
            WisdomPlus.interactable = true;
            CharismaPlus.interactable = true;
        }
        //--------------------------------------------------------------------------------------------------------- Strength UI
        StrengthScore.text = Strength.BaseValue.ToString();
        _strengthMod = Mathf.Floor(((Strength.BaseValue - 10) / 2));

        if (_strengthMod >= 0)
        {
            StrengthMod.text = "+" + _strengthMod.ToString();
        } else
        {
            StrengthMod.text = _strengthMod.ToString();
        }

        if (Strength.BaseValue >= 20 || _pointBuyTotal <= 0)
        {
            StrengthPlus.interactable = false;
        }
        else
        {
            StrengthPlus.interactable = true;
        }

        if (Strength.BaseValue <= 0)
        {
            StrengthMinus.interactable = false;
        }
        else
        {
            StrengthMinus.interactable = true;
        }
        //--------------------------------------------------------------------------------------------------------- Dexterity UI
        DexterityScore.text = Dexterity.BaseValue.ToString();
        _dexterityMod = Mathf.Floor(((Dexterity.BaseValue - 10) / 2));

        if (_dexterityMod >= 0)
        {
            DexterityMod.text = "+" + _dexterityMod.ToString();
        }
        else
        {
            DexterityMod.text = _dexterityMod.ToString();
        }

        if (Dexterity.BaseValue >= 20 || _pointBuyTotal <= 0)
        {
            DexterityPlus.interactable = false;
        }
        else
        {
            DexterityPlus.interactable = true;
        }

        if (Dexterity.BaseValue <= 0)
        {
            DexterityMinus.interactable = false;
        }
        else
        {
            DexterityMinus.interactable = true;
        }
        //--------------------------------------------------------------------------------------------------------- Constitution UI
        ConstitutionScore.text = Constitution.BaseValue.ToString();
        _constitutionMod = Mathf.Floor(((Constitution.BaseValue - 10) / 2));

        if (_constitutionMod >= 0)
        {
            ConstitutionMod.text = "+" + _constitutionMod.ToString();
        }
        else
        {
            ConstitutionMod.text = _constitutionMod.ToString();
        }

        if (Constitution.BaseValue >= 20 || _pointBuyTotal <= 0)
        {
            ConstitutionPlus.interactable = false;
        }
        else
        {
            ConstitutionPlus.interactable = true;
        }

        if (Constitution.BaseValue <= 0)
        {
            ConstitutionMinus.interactable = false;
        }
        else
        {
            ConstitutionMinus.interactable = true;
        }
        //--------------------------------------------------------------------------------------------------------- Intelligence UI
        IntelligenceScore.text = Intelligence.BaseValue.ToString();
        _intelligenceMod = Mathf.Floor(((Intelligence.BaseValue - 10) / 2));

        if (_intelligenceMod >= 0)
        {
            IntelligenceMod.text = "+" + _intelligenceMod.ToString();
        }
        else
        {
            IntelligenceMod.text = _intelligenceMod.ToString();
        }

        if (Intelligence.BaseValue >= 20 || _pointBuyTotal <= 0)
        {
            IntelligencePlus.interactable = false;
        }
        else
        {
            IntelligencePlus.interactable = true;
        }

        if (Intelligence.BaseValue <= 0)
        {
            IntelligenceMinus.interactable = false;
        }
        else
        {
            IntelligenceMinus.interactable = true;
        }
        //--------------------------------------------------------------------------------------------------------- Wisdom UI
        WisdomScore.text = Wisdom.BaseValue.ToString();
        _wisdomMod = Mathf.Floor(((Wisdom.BaseValue - 10) / 2));

        if (_wisdomMod >= 0)
        {
            WisdomMod.text = "+" + _wisdomMod.ToString();
        }
        else
        {
            WisdomMod.text = _wisdomMod.ToString();
        }

        if (Wisdom.BaseValue >= 20 || _pointBuyTotal <= 0)
        {
            WisdomPlus.interactable = false;
        }
        else
        {
            WisdomPlus.interactable = true;
        }

        if (Wisdom.BaseValue <= 0)
        {
            WisdomMinus.interactable = false;
        }
        else
        {
            WisdomMinus.interactable = true;
        }
        //--------------------------------------------------------------------------------------------------------- Charisma UI
        CharismaScore.text = Charisma.BaseValue.ToString();
        _charismaMod = Mathf.Floor(((Charisma.BaseValue - 10) / 2));

        if (_charismaMod >= 0)
        {
            CharismaMod.text = "+" + _charismaMod.ToString();
        }
        else
        {
            CharismaMod.text = _charismaMod.ToString();
        }

        if (Charisma.BaseValue >= 20 || _pointBuyTotal <= 0)
        {
            CharismaPlus.interactable = false;
        }
        else
        {
            CharismaPlus.interactable = true;
        }

        if (Charisma.BaseValue <= 0)
        {
            CharismaMinus.interactable = false;
        }
        else
        {
            CharismaMinus.interactable = true;
        }
    }

    //--------------------------------------------------------------------------------------------------------- Strength Add/Sub
    void AddStrength()
    {
        Strength.BaseValue++;
        _pointBuyTotal--;
        ClickSound.Play();
    }

    void MinusStrength()
    {
        Strength.BaseValue--;
        _pointBuyTotal++;
        ClickSound.Play();
    }
    //--------------------------------------------------------------------------------------------------------- Dexterity Add/Sub
    void AddDexterity()
    {
        Dexterity.BaseValue++;
        _pointBuyTotal--;
        ClickSound.Play();
    }

    void MinusDexterity()
    {
        Dexterity.BaseValue--;
        _pointBuyTotal++;
        ClickSound.Play();
    }
    //--------------------------------------------------------------------------------------------------------- Constitution Add/Sub
    void AddConstitution()
    {
        Constitution.BaseValue++;
        _pointBuyTotal--;
        ClickSound.Play();
    }

    void MinusConstitution()
    {
        Constitution.BaseValue--;
        _pointBuyTotal++;
        ClickSound.Play();
    }
    //--------------------------------------------------------------------------------------------------------- Intelligence Add/Sub
    void AddIntelligence()
    {
        Intelligence.BaseValue++;
        _pointBuyTotal--;
        ClickSound.Play();
    }

    void MinusIntelligence()
    {
        Intelligence.BaseValue--;
        _pointBuyTotal++;
        ClickSound.Play();
    }
    //--------------------------------------------------------------------------------------------------------- Wisdom Add/Sub
    void AddWisdom()
    {
        Wisdom.BaseValue++;
        _pointBuyTotal--;
        ClickSound.Play();
    }

    void MinusWisdom()
    {
        Wisdom.BaseValue--;
        _pointBuyTotal++;
        ClickSound.Play();
    }
    //--------------------------------------------------------------------------------------------------------- Charisma Add/Sub
    void AddCharisma()
    {
        Charisma.BaseValue++;
        _pointBuyTotal--;
        ClickSound.Play();
    }

    void MinusCharisma()
    {
        Charisma.BaseValue--;
        _pointBuyTotal++;
        ClickSound.Play();
    }
    //---------------------------------------------------------------------------------------------------------

}
