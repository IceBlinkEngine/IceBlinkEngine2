﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;
using System.Windows.Forms;
using System.IO;
using System.Drawing;
using System.ComponentModel;
using Newtonsoft.Json;
//using IceBlink;

namespace IB2Toolset
{
    public class Effect
    {
        #region Fields


        private bool _thisEffectUsesFullSizeIcon = false;

        private string _squareIndicatorFilename = "fx_webbed";
        private int _durationOnSquareInUnits = 0;
        private string _name = "newEffect";
        private string _tag = "newEffectTag";
        private string _tagOfSender = "senderTag";
        private int _classLevelOfSender = 0;
        private string _description = "";
        private string _spriteFilename = "held";
        private int _durationInUnits = 0;
        private int _currentDurationInUnits = 0;
        private int _startingTimeInUnits = 0;
        private int _babModifier = 0;

        private int _babModifierForRangedAttack = 0;
        private int _babModifierForMeleeAttack = 0;
        private int _damageModifierForMeleeAttack = 0;  
        private int _damageModifierForRangedAttack = 0;

        private int _acModifier = 0;
        private bool _isStackableEffect = false;
        private bool _isStackableDuration = false;
        private bool _usedForUpdateStats = false;
        private string _effectScript = "efGeneric";
        private List<LocalImmunityString> _affectNeverList = new List<LocalImmunityString>();
        private List<LocalImmunityString> _affectOnlyList = new List<LocalImmunityString>();
        private bool _endEffectWhenCarrierTakesDamage = false;
        private bool _saveOnlyHalvesDamage = false;
        private bool _repeatTerminalSaveEachRound = false;
        private bool _isPermanent = false;

        private string _saveCheckType = "none"; //none, reflex, will, fortitude
        private int _saveCheckDC = 10;
        
        //DAMAGE (hp)
        private bool _doDamage = false;
        private string _damType = "Normal"; //Normal,Acid,Cold,Electricity,Fire,Magic,Poison
        //(for reference) Attack: AdB+C for every D levels after level E up to F levels total
        private int _damNumOfDice = 0; //(A)how many dice to roll
        private int _damDie = 0; //(B)type of die to roll such as 4 sided or 10 sided, etc.
        private int _damAdder = 0; //(C)integer adder to total damage such as the "1" in 2d4+1
        private int _damAttacksEveryNLevels = 0; //(D)
        private int _damAttacksAfterLevelN = 0; //(E)
        private int _damAttacksUpToNLevelsTotal = 0; //(F)
        //(for reference) NumOfAttacks: A of these attacks for every B levels after level C up to D attacks total
        private int _damNumberOfAttacks = 0; //(A)
        private int _damNumberOfAttacksForEveryNLevels = 0; //(B)
        private int _damNumberOfAttacksAfterLevelN = 0; //(C)
        private int _damNumberOfAttacksUpToNAttacksTotal = 0; //(D)

        //HEAL (hp)
        private bool _doHeal = false;
        private bool _healHP = true; //if true, heals HP. If false, heals SP 
        private string _healType = "Organic"; //Organic (living things), NonOrganic (robots, constructs)
        //(for reference) HealActions: AdB+C for every D levels after level E up to F levels total
        private int _healNumOfDice = 0; //(A)how many dice to roll
        private int _healDie = 0; //(B)type of die to roll such as 4 sided or 10 sided, etc.
        private int _healAdder = 0; //(C)integer adder to total damage such as the "1" in 2d4+1
        private int _healActionsEveryNLevels = 0; //(D)
        private int _healActionsAfterLevelN = 0; //(E)
        private int _healActionsUpToNLevelsTotal = 0; //(F)

        //TRANSFER (hp/sp)
        private bool _doTransfer = false;
        private bool _transferHP = true; //if true, heals HP. If false, heals SP
        //(for reference) HealActions: AdB+C for every D levels after level E up to F levels total
        private int _transferNumOfDice = 0; //(A)how many dice to roll
        private int _transferDie = 0; //(B)type of die to roll such as 4 sided or 10 sided, etc.
        private int _transferAdder = 0; //(C)integer adder to total damage such as the "1" in 2d4+1
        private int _transferActionsEveryNLevels = 0; //(D)
        private int _transferActionsAfterLevelN = 0; //(E)
        private int _transferActionsUpToNLevelsTotal = 0; //(F)

        //BUFF and DEBUFF
        private bool _doBuff = false;
        private bool _doDeBuff = false;
        private string _statusType = "none"; //none, Held, Immobile, Invisible, Silenced, etc.
        private int _modifyFortitude = 0;
        private int _modifyWill = 0;
        private int _modifyReflex = 0;
        //For PC only
        private int _modifyStr = 0;
        private int _modifyDex = 0;
        private int _modifyInt = 0;
        private int _modifyCha = 0;
        private int _modifyCon = 0;
        private int _modifyWis = 0;
        private int _modifyLuk = 0;
        //end PC only
        private int _modifyMoveDistance = 0;
        private int _modifyHpMax = 0;
        private int _modifySpMax = 0;
        private int _modifySp = 0;

        private int _modifyHpInCombat = 0;  
        private int _modifySpInCombat = 0;

        private int _modifyDamageTypeResistanceAcid = 0;
        private int _modifyDamageTypeResistanceCold = 0;
        private int _modifyDamageTypeResistanceNormal = 0;
        private int _modifyDamageTypeResistanceElectricity = 0;
        private int _modifyDamageTypeResistanceFire = 0;
        private int _modifyDamageTypeResistanceMagic = 0;
        private int _modifyDamageTypeResistancePoison = 0;
        private int _modifyNumberOfMeleeAttacks = 0;
        private int _modifyNumberOfRangedAttacks = 0;

        private int _modifyNumberOfEnemiesAttackedOnCleave = 0; //(melee only) cleave attacks are only made if previous attacked enemy goes down.  
        private int _modifyNumberOfEnemiesAttackedOnSweepAttack = 0; //(melee only) sweep attack simultaneously attacks multiple enemies in range  
        private bool _useDexterityForMeleeAttackModifierIfGreaterThanStrength = false;  
        private bool _useDexterityForMeleeDamageModifierIfGreaterThanStrength = false;  
        private bool _negateAttackPenaltyForAdjacentEnemyWithRangedAttack = false;  
        private bool _useEvasion = false; //if true, do half damage on failed DC check and no damage with successful DC check against spells/traits   
        private int _modifyShopBuyBackPrice = 0;  
        private int _modifyShopSellPrice = 0;
        private int _twoWeaponFightingMainHandModifier = 0;
        private int _twoWeaponFightingOffHandModifier = 0;
        private int _numberOfMirrorImagesLeft = 0;
        private int _numberOfHitPointDamageAbsorptionLeft = 0;


        private bool _allowCastingWithoutTriggeringAoO = false;
        private bool _allowCastingWithoutRiskOfInterruption = false;

        public List<LocalImmunityString> traitWorksOnlyWhen = new List<LocalImmunityString>();
        public List<LocalImmunityString> traitWorksNeverWhen = new List<LocalImmunityString>();
        #endregion

        #region Properties
        [CategoryAttribute("00 - Main"), DescriptionAttribute("Name of the Effect")]
        public string name
        {
            get
            {
                return _name;
            }
            set
            {
                _name = value;
            }
        }

        //private bool _thisEffectUsesFullSizeIcon = false;
        [CategoryAttribute("00 - Main"), DescriptionAttribute("This effect's icon is always ddrawn full size on top of an actor.")]
        public bool thisEffectUsesFullSizeIcon
        {
            get
            {
                return _thisEffectUsesFullSizeIcon;
            }
            set
            {
                _thisEffectUsesFullSizeIcon = value;
            }
        }

        [CategoryAttribute("00 - Main"), DescriptionAttribute("Name of the effect graphic shown on the square (without .png)")]
        public string squareIndicatorFilename
        {
            get
            {
                return _squareIndicatorFilename;
            }
            set
            {
                _squareIndicatorFilename = value;
            }
        }

        [CategoryAttribute("00 - Main"), DescriptionAttribute("Duration in seconds (usally a combat round has 6 seconds) indicating how long the effect lingers on a square. Current round is always added, so a duration 0 effect will stay till end of current round.")]
        public int durationOnSquareInUnits
        {
            get
            {
                return _durationOnSquareInUnits;
            }
            set
            {
                _durationOnSquareInUnits = value;
            }
        }

        [CategoryAttribute("05 - Modifiers (pc only)"), DescriptionAttribute("can be a positive or negative change in percent represented as integer. (example: to increase by 10%, enter 10. to decrease by 20%, enter -20)")]  
         public int modifyShopBuyBackPrice  
        {  
             get { return _modifyShopBuyBackPrice; }  
             set { _modifyShopBuyBackPrice = value; }  
         }  
         [CategoryAttribute("05 - Modifiers (pc only)"), DescriptionAttribute("can be a positive or negative change in percent represented as integer. (example: to increase by 10%, enter 10. to decrease by 20%, enter -20)")]  
         public int modifyShopSellPrice
         {  
             get { return _modifyShopSellPrice; }  
             set { _modifyShopSellPrice = value; }  
         }
       
        [CategoryAttribute("06 - Special effects (pc only)"), DescriptionAttribute("Allows casting without triggering attacks of opportunity when set to true.")]
        public bool allowCastingWithoutTriggeringAoO
        {
            get { return _allowCastingWithoutTriggeringAoO; }
            set { _allowCastingWithoutTriggeringAoO = value; }
        }

        [CategoryAttribute("06 - Special effects (pc only)"), DescriptionAttribute("Allow casting without risk (will save) of interruption due to damage taken in the meantime when set to true.")]
        public bool allowCastingWithoutRiskOfInterruption
        {
            get { return _allowCastingWithoutRiskOfInterruption; }
            set { _allowCastingWithoutRiskOfInterruption = value; }
        }
        
        [CategoryAttribute("01 - Applicability"), DescriptionAttribute("Entries added here mark pc (trait tags) and creatures (local string values) that are immune to this effect.")]
        public List<LocalImmunityString> affectNeverList
        {
            get { return _affectNeverList; }
            set { _affectNeverList = value; }
        }

        [CategoryAttribute("01 - Applicability"), DescriptionAttribute("Entries added here mark the ONLY pc(trait tags) and creatures(local string values) that can be affected by this effect.")]
        public List<LocalImmunityString> affectOnlyList
        {
            get { return _affectOnlyList; }
            set { _affectOnlyList = value; }
        }

        [CategoryAttribute("00 - Main"), DescriptionAttribute("Tag of the Effect (Must be unique)")]
        public string tag
        {
            get
            {
                return _tag;
            }
            set
            {
                _tag = value;
            }
        }
        [CategoryAttribute("08 - Read only"), DescriptionAttribute("Tag of the Effect sender, the one who created the effect (Must be unique)"), ReadOnly(true)]
        public string tagOfSender
        {
            get
            {
                return _tagOfSender;
            }
            set
            {
                _tagOfSender = value;
            }
        }
        [CategoryAttribute("08 - Read only"), DescriptionAttribute("Level of Effect sender, the one (Creature, Player, Item, etc.) who created the effect"), ReadOnly(true)]
        public int classLevelOfSender
        {
            get
            {
                return _classLevelOfSender;
            }
            set
            {
                _classLevelOfSender = value;
            }
        }
        [Editor(typeof(MultilineStringEditor), typeof(System.Drawing.Design.UITypeEditor))]
        [CategoryAttribute("00 - Main"), DescriptionAttribute("Detailed description of effect with some stats")]
        public string description
        {
            get
            {
                return _description;
            }
            set
            {
                _description = value;
            }
        }
        //[Browsable(true), TypeConverter(typeof(SpriteConverter))]
        [CategoryAttribute("00 - Main"), DescriptionAttribute("Sprite to use for the effect (Sprite Filename with extension)")]
        public string spriteFilename
        {
            get
            {
                return _spriteFilename;
            }
            set
            {
                _spriteFilename = value;
            }
        }
        [CategoryAttribute("00 - Main"), DescriptionAttribute("How long the effect lasts in seconds (usally a combat round has 6 seconds, step on main map 300 seconds). For instantaneous effects like fireball or mage bolt, set this to = 0")]
        public int durationInUnits
        {
            get
            {
                return _durationInUnits;
            }
            set
            {
                _durationInUnits = value;
            }
        }
        [CategoryAttribute("08 - Read only"), DescriptionAttribute("(no longer used)How long the Effect has been going on so far in units of time"), ReadOnly(true)]
        public int currentDurationInUnits
        {
            get
            {
                return _currentDurationInUnits;
            }
            set
            {
                _currentDurationInUnits = value;
            }
        }
        [CategoryAttribute("08 - Read only"), DescriptionAttribute("(no longer used)At what time did the Effect begin, in units of time"), ReadOnly(true)]
        public int startingTimeInUnits
        {
            get
            {
                return _startingTimeInUnits;
            }
            set
            {
                _startingTimeInUnits = value;
            }
        }
        [CategoryAttribute("04 - Modifiers (pc and creature)"), DescriptionAttribute("adds or subtracts from BAB for all attacks (ranged and melee)")]
        public int babModifier
        {
            get { return _babModifier; }
            set { _babModifier = value; }
        }

        [CategoryAttribute("05 - Modifiers (pc only)"), DescriptionAttribute("adds or subtracts from BAB for ranged attacks only")]  
        public int babModifierForRangedAttack  
        {  
             get { return _babModifierForRangedAttack; }  
             set { _babModifierForRangedAttack = value; }  
        }
        [CategoryAttribute("05 - Modifiers (pc only)"), DescriptionAttribute("adds or subtracts from BAB for melee attacks only")]
        public int babModifierForMeleeAttack
        {
            get { return _babModifierForMeleeAttack; }
            set { _babModifierForMeleeAttack = value; }
        }
        [CategoryAttribute("05 - Modifiers (pc only)"), DescriptionAttribute("grants a bonus to the main hand when using two weapon fighting. Example: set to 2 for two-weapon fighting L1 and 4 for two-weapon fighting L2")]
        public int twoWeaponFightingMainHandModifier
        {
            get { return _twoWeaponFightingMainHandModifier; }
            set { _twoWeaponFightingMainHandModifier = value; }
        }
        [CategoryAttribute("05 - Modifiers (pc only)"), DescriptionAttribute("grants a bonus to the off-hand when using two weapon fighting. Example: set to 6 for two-weapon fighting L1 and 8 for two-weapon fighting L2")]
        public int twoWeaponFightingOffHandModifier
        {
            get { return _twoWeaponFightingOffHandModifier; }
            set { _twoWeaponFightingOffHandModifier = value; }
        }
        [CategoryAttribute("05 - Modifiers (pc only)"), DescriptionAttribute("number of mirror images left. Set to greater than zero if this is a mirror image type effect.")]
        public int numberOfMirrorImagesLeft
        {
            get { return _numberOfMirrorImagesLeft; }
            set { _numberOfMirrorImagesLeft = value; }
        }
        [CategoryAttribute("05 - Modifiers (pc only)"), DescriptionAttribute("number of hit point damage that will be absorbed by this effect.")]
        public int numberOfHitPointDamageAbsorptionLeft
        {
            get { return _numberOfHitPointDamageAbsorptionLeft; }
            set { _numberOfHitPointDamageAbsorptionLeft = value; }
        }
        [CategoryAttribute("04 - Modifiers (pc and creature)"), DescriptionAttribute("adds or subtracts from damage for melee attacks")]  
        public int damageModifierForMeleeAttack
        {  
             get { return _damageModifierForMeleeAttack; }  
             set { _damageModifierForMeleeAttack = value; }  
        }  
        [CategoryAttribute("04 - Modifiers (pc and creature)"), DescriptionAttribute("adds or subtracts from damage for ranged attacks")]  
        public int damageModifierForRangedAttack
        {  
             get { return _damageModifierForRangedAttack; }  
             set { _damageModifierForRangedAttack = value; }  
         }  


        [CategoryAttribute("04 - Modifiers (pc and creature)"), DescriptionAttribute("adds or subtracts from Armor Class")]
        public int acModifier
        {
            get { return _acModifier; }
            set { _acModifier = value; }
        }
        [CategoryAttribute("00 - Main"), DescriptionAttribute("Should the effect be stackable, true = stackable")]
        public bool isStackableEffect
        {
            get
            {
                return _isStackableEffect;
            }
            set
            {
                _isStackableEffect = value;
            }
        }
        [CategoryAttribute("00 - Main"), DescriptionAttribute("Should the effect duration be stackable, true = stackable")]
        public bool isStackableDuration
        {
            get
            {
                return _isStackableDuration;
            }
            set
            {
                _isStackableDuration = value;
            }
        }
        [CategoryAttribute("07 - Outdated properties"), DescriptionAttribute("Determines if this effect is used specifically for modifying PC stats only")]
        public bool usedForUpdateStats
        {
            get
            {
                return _usedForUpdateStats;
            }
            set
            {
                _usedForUpdateStats = value;
            }
        }

        [CategoryAttribute("01 - Applicability"), DescriptionAttribute("The saving throw is peated each roud - one success terminates the effect")]
        public bool repeatTerminalSaveEachRound
        {
            get
            {
                return _repeatTerminalSaveEachRound;
            }
            set
            {
                _repeatTerminalSaveEachRound = value;
            }
        }

        [CategoryAttribute("00 - Main"), DescriptionAttribute("This effect is used by a passive trait, it is permannetly added to the player charcter on acquisition of the trait (that in turn contains this effect's tag in its effects list)")]
        public bool isPermanent
        {
            get
            {
                return _isPermanent;
            }
            set
            {
               _isPermanent = value;
            }
        }

        [CategoryAttribute("01 - Applicability"), DescriptionAttribute("Determines whether the effect is removed once the cretaure or pc that has the effect takes damage")]
        public bool endEffectWhenCarrierTakesDamage
        {
            get
            {
                return _endEffectWhenCarrierTakesDamage;
            }
            set
            {
                _endEffectWhenCarrierTakesDamage = value;
            }
        }

        [CategoryAttribute("01 - Applicability"), DescriptionAttribute("Determines whether the effect is removed once the cretaure or pc that has the effect takes damage")]
        public bool saveOnlyHalvesDamage
        {
            get
            {
                return _saveOnlyHalvesDamage;
            }
            set
            {
                _saveOnlyHalvesDamage = value;
            }
        }


        /*[CategoryAttribute("02 - Scripts"), DescriptionAttribute("fires on each round or turn")]
        [Editor(typeof(ScriptSelectEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public ScriptSelectEditorReturnObject EffectScript
        {
            get { return effectScript; }
            set { effectScript = value; }
        }*/
        [CategoryAttribute("07 - Outdated properties"), DescriptionAttribute("Script assoiated with this effect (optional)")]
        public string effectScript
        {
            get { return _effectScript; }
            set { _effectScript = value; }
        }
        [CategoryAttribute("01 - Applicability"), DescriptionAttribute("Type of saving throw check made (none, reflex, will, fortitude)")]
        public string saveCheckType
        {
            get { return _saveCheckType; }
            set { _saveCheckType = value; }
        }
        [CategoryAttribute("01 - Applicability"), DescriptionAttribute("Difficulty Class for saving throw check (pass if 1d20 + reflex/will/fortitude >= DC)")]
        public int saveCheckDC
        {
            get { return _saveCheckDC; }
            set { _saveCheckDC = value; }
        }
        [CategoryAttribute("02 - Damage"), DescriptionAttribute("set to true if this Effect uses a Damage type Effect")]
        public bool doDamage
        {
            get { return _doDamage; }
            set { _doDamage = value; }
        }
        [CategoryAttribute("02 - Damage"), DescriptionAttribute("Type of damage (Normal,Acid,Cold,Electricity,Fire,Magic,Poison)")]
        public string damType
        {
            get { return _damType; }
            set { _damType = value; }
        }
        [CategoryAttribute("02 - Damage"), DescriptionAttribute("(A)how many dice to roll [Attack: AdB+C for every D levels after level E up to F levels total]"), ReadOnly(true), Browsable(false)]
        public int damNumOfDice
        {
            get { return _damNumOfDice; }
            set { _damNumOfDice = value; }
        }
        [CategoryAttribute("02 - Damage"), DescriptionAttribute("(B)number of sides on the die such as 4 sided or 10 sided, etc. [Attack: AdB+C for every D levels after level E up to F levels total]"), ReadOnly(true), Browsable(false)]
        public int damDie
        {
            get { return _damDie; }
            set { _damDie = value; }
        }
        [CategoryAttribute("02 - Damage"), DescriptionAttribute("(C)integer adder to total damage such as the '1' in 2d4+1 [Attack: AdB+C for every D levels after level E up to F levels total]"), ReadOnly(true), Browsable(false)]
        public int damAdder
        {
            get { return _damAdder; }
            set { _damAdder = value; }
        }
        [CategoryAttribute("02 - Damage"), DescriptionAttribute("(D) [Attack: AdB+C for every D levels after level E up to F levels total]"), ReadOnly(true), Browsable(false)]
        public int damAttacksEveryNLevels
        {
            get { return _damAttacksEveryNLevels; }
            set { _damAttacksEveryNLevels = value; }
        }
        [CategoryAttribute("02 - Damage"), DescriptionAttribute("(E) [Attack: AdB+C for every D levels after level E up to F levels total]"), ReadOnly(true), Browsable(false)]
        public int damAttacksAfterLevelN
        {
            get { return _damAttacksAfterLevelN; }
            set { _damAttacksAfterLevelN = value; }
        }
        [CategoryAttribute("02 - Damage"), DescriptionAttribute("(F) [Attack: AdB+C for every D levels after level E up to F levels total]"), ReadOnly(true), Browsable(false)]
        public int damAttacksUpToNLevelsTotal
        {
            get { return _damAttacksUpToNLevelsTotal; }
            set { _damAttacksUpToNLevelsTotal = value; }
        }
        [CategoryAttribute("02 - Damage"), DescriptionAttribute("(A) [NumOfAttacks: A of these attacks for every B levels after level C up to D attacks total]"), ReadOnly(true), Browsable(false)]
        public int damNumberOfAttacks
        {
            get { return _damNumberOfAttacks; }
            set { _damNumberOfAttacks = value; }
        }
        [CategoryAttribute("02 - Damage"), DescriptionAttribute("(B) [NumOfAttacks: A of these attacks for every B levels after level C up to D attacks total]"), ReadOnly(true), Browsable(false)]
        public int damNumberOfAttacksForEveryNLevels
        {
            get { return _damNumberOfAttacksForEveryNLevels; }
            set { _damNumberOfAttacksForEveryNLevels = value; }
        }
        [CategoryAttribute("02 - Damage"), DescriptionAttribute("(C) [NumOfAttacks: A of these attacks for every B levels after level C up to D attacks total]"), ReadOnly(true), Browsable(false)]
        public int damNumberOfAttacksAfterLevelN
        {
            get { return _damNumberOfAttacksAfterLevelN; }
            set { _damNumberOfAttacksAfterLevelN = value; }
        }
        [CategoryAttribute("02 - Damage"), DescriptionAttribute("(D) [NumOfAttacks: A of these attacks for every B levels after level C up to D attacks total]"), ReadOnly(true), Browsable(false)]
        public int damNumberOfAttacksUpToNAttacksTotal
        {
            get { return _damNumberOfAttacksUpToNAttacksTotal; }
            set { _damNumberOfAttacksUpToNAttacksTotal = value; }
        }
        [CategoryAttribute("03 - Heal"), DescriptionAttribute("set to true if this Effect uses a Heal type Effect")]
        public bool doHeal
        {
            get { return _doHeal; }
            set { _doHeal = value; }
        }
        [CategoryAttribute("03 - Heal"), DescriptionAttribute("set to true if this Effect will heal HPs, set to fasle to 'heal' SP instead (think rejuvenation type spells to recoupe SP).")]  
        public bool healHP  
        {  
            get { return _healHP; }  
            set { _healHP = value; }  
        }  

        [CategoryAttribute("03 - Heal"), DescriptionAttribute("Organic (living things), NonOrganic (robots, constructs)")]
        public string healType
        {
            get { return _healType; }
            set { _healType = value; }
        }
        [CategoryAttribute("03 - Heal"), DescriptionAttribute("(A) [HealActions: AdB+C for every D levels after level E up to F levels total]"), ReadOnly(true), Browsable(false)]
        public int healNumOfDice
        {
            get { return _healNumOfDice; }
            set { _healNumOfDice = value; }
        }
        [CategoryAttribute("03 - Heal"), DescriptionAttribute("(B) [HealActions: AdB+C for every D levels after level E up to F levels total]"), ReadOnly(true), Browsable(false)]
        public int healDie
        {
            get { return _healDie; }
            set { _healDie = value; }
        }
        [CategoryAttribute("03 - Heal"), DescriptionAttribute("(C) [HealActions: AdB+C for every D levels after level E up to F levels total]"), ReadOnly(true), Browsable(false)]
        public int healAdder
        {
            get { return _healAdder; }
            set { _healAdder = value; }
        }
        [CategoryAttribute("03 - Heal"), DescriptionAttribute("(D) [HealActions: AdB+C for every D levels after level E up to F levels total]"), ReadOnly(true), Browsable(false)]
        public int healActionsEveryNLevels
        {
            get { return _healActionsEveryNLevels; }
            set { _healActionsEveryNLevels = value; }
        }
        [CategoryAttribute("03 - Heal"), DescriptionAttribute("(E) [HealActions: AdB+C for every D levels after level E up to F levels total]"), ReadOnly(true), Browsable(false)]
        public int healActionsAfterLevelN
        {
            get { return _healActionsAfterLevelN; }
            set { _healActionsAfterLevelN = value; }
        }
        [CategoryAttribute("03 - Heal"), DescriptionAttribute("(F) [HealActions: AdB+C for every D levels after level E up to F levels total]"), ReadOnly(true), Browsable(false)]
        public int healActionsUpToNLevelsTotal
        {
            get { return _healActionsUpToNLevelsTotal; }
            set { _healActionsUpToNLevelsTotal = value; }
        }

        [CategoryAttribute("02 - Transfer"), DescriptionAttribute("set to true if this Effect uses a Transfer type Effect")]
        public bool doTransfer
        {
            get { return _doTransfer; }
            set { _doTransfer = value; }
        }
        [CategoryAttribute("02 - Transfer"), DescriptionAttribute("set to true if this Effect will transfer HPs, set to fasle to 'transfer' SP instead (think rejuvenation type spells to recoupe SP).")]
        public bool transferHP
        {
            get { return _transferHP; }
            set { _transferHP = value; }
        }
        [CategoryAttribute("02 - Transfer"), DescriptionAttribute("(A) [transferActions: AdB+C for every D levels after level E up to F levels total]"), ReadOnly(true), Browsable(false)]
        public int transferNumOfDice
        {
            get { return _transferNumOfDice; }
            set { _transferNumOfDice = value; }
        }
        [CategoryAttribute("02 - Transfer"), DescriptionAttribute("(B) [transferActions: AdB+C for every D levels after level E up to F levels total]"), ReadOnly(true), Browsable(false)]
        public int transferDie
        {
            get { return _transferDie; }
            set { _transferDie = value; }
        }
        [CategoryAttribute("02 - Transfer"), DescriptionAttribute("(C) [transferActions: AdB+C for every D levels after level E up to F levels total]"), ReadOnly(true), Browsable(false)]
        public int transferAdder
        {
            get { return _transferAdder; }
            set { _transferAdder = value; }
        }
        [CategoryAttribute("02 - Transfer"), DescriptionAttribute("(D) [transferActions: AdB+C for every D levels after level E up to F levels total]"), ReadOnly(true), Browsable(false)]
        public int transferActionsEveryNLevels
        {
            get { return _transferActionsEveryNLevels; }
            set { _transferActionsEveryNLevels = value; }
        }
        [CategoryAttribute("02 - Transfer"), DescriptionAttribute("(E) [transferActions: AdB+C for every D levels after level E up to F levels total]"), ReadOnly(true), Browsable(false)]
        public int transferActionsAfterLevelN
        {
            get { return _transferActionsAfterLevelN; }
            set { _transferActionsAfterLevelN = value; }
        }
        [CategoryAttribute("02 - Transfer"), DescriptionAttribute("(F) [transferActions: AdB+C for every D levels after level E up to F levels total]"), ReadOnly(true), Browsable(false)]
        public int transferActionsUpToNLevelsTotal
        {
            get { return _transferActionsUpToNLevelsTotal; }
            set { _transferActionsUpToNLevelsTotal = value; }
        }



        [CategoryAttribute("00 - Main"), DescriptionAttribute("set to true if this Effect uses a Buff (excluding heal) type Effect. Note: with duration 0 a buff lasts til start of next turn of the recipient")]
        public bool doBuff
        {
            get { return _doBuff; }
            set { _doBuff = value; }
        }
        [CategoryAttribute("00 - Main"), DescriptionAttribute("set to true if this Effect uses a DeBuff (excluding damage) type Effect, including Held or Immobile type; Note: with duration 0 a buff lasts til start of next turn of the recipient")]
        public bool doDeBuff
        {
            get { return _doDeBuff; }
            set { _doDeBuff = value; }
        }
        [CategoryAttribute("04 - Modifiers (pc and creature)"), DescriptionAttribute("none, Held (for creature and player), Immobile (for creature and player), Invisible (for player only), Silenced(not implemented)")]
        public string statusType
        {
            get { return _statusType; }
            set { _statusType = value; }
        }
        [CategoryAttribute("04 - Modifiers (pc and creature)"), DescriptionAttribute("can be a positive or negative amount")]
        public int modifyFortitude
        {
            get { return _modifyFortitude; }
            set { _modifyFortitude = value; }
        }
        [CategoryAttribute("04 - Modifiers (pc and creature)"), DescriptionAttribute("can be a positive or negative amount")]
        public int modifyWill
        {
            get { return _modifyWill; }
            set { _modifyWill = value; }
        }
        [CategoryAttribute("04 - Modifiers (pc and creature)"), DescriptionAttribute("can be a positive or negative amount")]
        public int modifyReflex
        {
            get { return _modifyReflex; }
            set { _modifyReflex = value; }
        }
        [CategoryAttribute("05 - Modifiers (pc only)"), DescriptionAttribute("[applies to PCs Only] can be a positive or negative amount")]
        public int modifyStr
        {
            get { return _modifyStr; }
            set { _modifyStr = value; }
        }
        [CategoryAttribute("05 - Modifiers (pc only)"), DescriptionAttribute("[applies to PCs Only] can be a positive or negative amount")]
        public int modifyDex
        {
            get { return _modifyDex; }
            set { _modifyDex = value; }
        }
        [CategoryAttribute("05 - Modifiers (pc only)"), DescriptionAttribute("[applies to PCs Only] can be a positive or negative amount")]
        public int modifyInt
        {
            get { return _modifyInt; }
            set { _modifyInt = value; }
        }
        [CategoryAttribute("05 - Modifiers (pc only)"), DescriptionAttribute("[applies to PCs Only] can be a positive or negative amount")]
        public int modifyCha
        {
            get { return _modifyCha; }
            set { _modifyCha = value; }
        }
        [CategoryAttribute("05 - Modifiers (pc only)"), DescriptionAttribute("[applies to PCs Only] can be a positive or negative amount")]
        public int modifyCon
        {
            get { return _modifyCon; }
            set { _modifyCon = value; }
        }
        [CategoryAttribute("05 - Modifiers (pc only)"), DescriptionAttribute("[applies to PCs Only] can be a positive or negative amount")]
        public int modifyWis
        {
            get { return _modifyWis; }
            set { _modifyWis = value; }
        }
        [CategoryAttribute("05 - Modifiers (pc only)"), DescriptionAttribute("[applies to PCs Only] can be a positive or negative amount")]
        public int modifyLuk
        {
            get { return _modifyLuk; }
            set { _modifyLuk = value; }
        }
        [CategoryAttribute("04 - Modifiers (pc and creature)"), DescriptionAttribute("can be a positive or negative amount")]
        public int modifyMoveDistance
        {
            get { return _modifyMoveDistance; }
            set { _modifyMoveDistance = value; }
        }
        [CategoryAttribute("04 - Modifiers (pc and creature)"), DescriptionAttribute("can be a positive or negative amount")]
        public int modifyHpMax
        {
            get { return _modifyHpMax; }
            set { _modifyHpMax = value; }
        }
        [CategoryAttribute("05 - Modifiers (pc only)"), DescriptionAttribute("can be a positive or negative amount")]
        public int modifySpMax
        {
            get { return _modifySpMax; }
            set { _modifySpMax = value; }
        }
        [CategoryAttribute("04 - Modifiers (pc and creature)"), DescriptionAttribute("can be a positive or negative amount")]
        public int modifySp
        {
            get { return _modifySp; }
            set { _modifySp = value; }
        }

        [CategoryAttribute("04 - Modifiers (pc and creature)"), DescriptionAttribute("can be a positive or negative amount. Is used for combat hp regeneration type trait effects on each round. For Passive type traits only.")]  
        public int modifyHpInCombat  
        {  
             get { return _modifyHpInCombat; }  
             set { _modifyHpInCombat = value; }  
        }  
         [CategoryAttribute("04 - Modifiers (pc and creature)"), DescriptionAttribute("can be a positive or negative amount. Is used for combat sp regeneration type trait effects on each round. For Passive type traits only.")]  
         public int modifySpInCombat
         {  
             get { return _modifySpInCombat; }  
             set { _modifySpInCombat = value; }  
         }  

        [CategoryAttribute("04 - Modifiers (pc and creature)"), DescriptionAttribute("can be a positive or negative amount")]
        public int modifyDamageTypeResistanceAcid
        {
            get { return _modifyDamageTypeResistanceAcid; }
            set { _modifyDamageTypeResistanceAcid = value; }
        }
        [CategoryAttribute("04 - Modifiers (pc and creature)"), DescriptionAttribute("can be a positive or negative amount")]
        public int modifyDamageTypeResistanceCold
        {
            get { return _modifyDamageTypeResistanceCold; }
            set { _modifyDamageTypeResistanceCold = value; }
        }
        [CategoryAttribute("04 - Modifiers (pc and creature)"), DescriptionAttribute("can be a positive or negative amount")]
        public int modifyDamageTypeResistanceNormal
        {
            get { return _modifyDamageTypeResistanceNormal; }
            set { _modifyDamageTypeResistanceNormal = value; }
        }
        [CategoryAttribute("04 - Modifiers (pc and creature)"), DescriptionAttribute("can be a positive or negative amount")]
        public int modifyDamageTypeResistanceElectricity
        {
            get { return _modifyDamageTypeResistanceElectricity; }
            set { _modifyDamageTypeResistanceElectricity = value; }
        }
        [CategoryAttribute("04 - Modifiers (pc and creature)"), DescriptionAttribute("can be a positive or negative amount")]
        public int modifyDamageTypeResistanceFire
        {
            get { return _modifyDamageTypeResistanceFire; }
            set { _modifyDamageTypeResistanceFire = value; }
        }
        [CategoryAttribute("04 - Modifiers (pc and creature)"), DescriptionAttribute("can be a positive or negative amount")]
        public int modifyDamageTypeResistanceMagic
        {
            get { return _modifyDamageTypeResistanceMagic; }
            set { _modifyDamageTypeResistanceMagic = value; }
        }
        [CategoryAttribute("04 - Modifiers (pc and creature)"), DescriptionAttribute("can be a positive or negative amount")]
        public int modifyDamageTypeResistancePoison
        {
            get { return _modifyDamageTypeResistancePoison; }
            set { _modifyDamageTypeResistancePoison = value; }
        }
        [CategoryAttribute("04 - Modifiers (pc and creature)"), DescriptionAttribute("can be a positive or negative amount")]
        public int modifyNumberOfMeleeAttacks
        {
            get { return _modifyNumberOfMeleeAttacks; }
            set { _modifyNumberOfMeleeAttacks = value; }
        }
        [CategoryAttribute("04 - Modifiers (pc and creature)"), DescriptionAttribute("can be a positive or negative amount")]
        public int modifyNumberOfRangedAttacks
        {
            get { return _modifyNumberOfRangedAttacks; }
            set { _modifyNumberOfRangedAttacks = value; }
        }

        [CategoryAttribute("05 - Modifiers (pc only)"), DescriptionAttribute("number of enemies that can be targeted in one round upon succesive cleave atacks (melee only). Cleave attacks are only made if previous attacked enemy goes down")]  
        public int modifyNumberOfEnemiesAttackedOnCleave
        {  
             get { return _modifyNumberOfEnemiesAttackedOnCleave; }  
             set { _modifyNumberOfEnemiesAttackedOnCleave = value; }  
        }  
        [CategoryAttribute("05 - Modifiers (pc only)"), DescriptionAttribute("number of adjacent enemies that will be attacked in one round. This will not make multiple attacks on one target (like two attack trait), only one attack per target.")]  
        public int modifyNumberOfEnemiesAttackedOnSweepAttack
        {  
             get { return _modifyNumberOfEnemiesAttackedOnSweepAttack; }  
             set { _modifyNumberOfEnemiesAttackedOnSweepAttack = value; }  
        }  
        [CategoryAttribute("06 - Special effects (pc only)"), DescriptionAttribute("if true, will use dexterity for melee attack modifier instead of strength if dexterity is greater than strength.")]  
        public bool useDexterityForMeleeAttackModifierIfGreaterThanStrength
        {  
             get { return _useDexterityForMeleeAttackModifierIfGreaterThanStrength; }  
             set { _useDexterityForMeleeAttackModifierIfGreaterThanStrength = value; }  
         }  
         [CategoryAttribute("06 - Special effects (pc only)"), DescriptionAttribute("if true, will use dexterity for melee damage modifier instead of strength if dexterity is greater than strength.")]  
         public bool useDexterityForMeleeDamageModifierIfGreaterThanStrength
         {  
             get { return _useDexterityForMeleeDamageModifierIfGreaterThanStrength; }  
             set { _useDexterityForMeleeDamageModifierIfGreaterThanStrength = value; }  
         }  
         [CategoryAttribute("06 - Special effects (pc only)"), DescriptionAttribute("if true, will ignore any attack penalty for using ranged attack with an enemy in an adjacent square (think point blank shot trait).")]  
         public bool negateAttackPenaltyForAdjacentEnemyWithRangedAttack
         {  
             get { return _negateAttackPenaltyForAdjacentEnemyWithRangedAttack; }  
             set { _negateAttackPenaltyForAdjacentEnemyWithRangedAttack = value; }  
         }  
         [CategoryAttribute("07 - Outdated properties"), DescriptionAttribute("if true, will do half damage for failed DC checks against damage effects and no damage for successful DC checks (think evasion trait).")]  
         public bool useEvasion
         {  
             get { return _useEvasion; }  
             set { _useEvasion = value; }  
         }  

        #endregion

        public Effect()
        {            
        }
        public override string ToString()
        {
            return name;
        }
        public Effect ShallowCopy()
        {
            return (Effect)this.MemberwiseClone();
        }
        public Effect DeepCopy()
        {
            Effect other = (Effect)this.MemberwiseClone();
            other.traitWorksNeverWhen = new List<LocalImmunityString>();
            foreach (LocalImmunityString s in this.traitWorksNeverWhen)
            {
                other.traitWorksNeverWhen.Add(s);
            }
            other.traitWorksOnlyWhen = new List<LocalImmunityString>();
            foreach (LocalImmunityString s in this.traitWorksOnlyWhen)
            {
                other.traitWorksOnlyWhen.Add(s);
            }
            other.affectOnlyList = new List<LocalImmunityString>();
            foreach (LocalImmunityString s in this.affectOnlyList)
            {
                other.affectOnlyList.Add(s);
            }
            other.affectNeverList = new List<LocalImmunityString>();
            foreach (LocalImmunityString s in this.affectNeverList)
            {
                other.affectNeverList.Add(s);
            }
            return other;
        }
    }
}
