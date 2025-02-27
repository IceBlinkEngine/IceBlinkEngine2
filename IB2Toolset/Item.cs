﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;
using System.Windows.Forms;
using System.IO;
using System.Drawing;
using System.ComponentModel;
//using IceBlink;
using System.Drawing.Design;
//using System.Design;
using System.ComponentModel.Design;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace IB2Toolset
{
    public class Item : INotifyPropertyChanged
    {
                        
        public event PropertyChangedEventHandler PropertyChanged;

        #region Fields
        [JsonIgnore]
        public Bitmap itemIconBitmap;
        //private useableinsituation useableInSituation = useableinsituation.Always;
        //private category p_category = category.Armor; //catergory type (armor, weapon, ammo, etc.)
        private string _armorWeightType = "Light"; //Light, Medium, Heavy           
        //private ScriptSelectEditorReturnObject onScoringHit = new ScriptSelectEditorReturnObject();
        //private ScriptSelectEditorReturnObject onUseItem = new ScriptSelectEditorReturnObject();
        //private ScriptSelectEditorReturnObject onWhileEquipped = new ScriptSelectEditorReturnObject();
        //private DamageType typeOfDamage = DamageType.Slashing;
        private string _itemImage = "blank";
        private string _name = "none"; //item name
        private string _labelForTheCastAction = "casts";
        private string _tag = "none"; //item unique tag name    
        private string _resref = "none"; //item resref name
        private string _desc = "enter item's description here"; //item detailed description
        private string _itemCategoryName = "newCategory";
        private string _useableInSituation = "Always"; //InCombat, OutOfCombat, Always, Passive
        private string _projectileSpriteFilename = "none"; //sprite to use for projectiles
        private string _spriteEndingFilename = "none"; //sprite to use for end effect of projectiles
        private string _itemOnUseSound = "none";
        private string _category = "Armor"; //catergory type (Armor, Ranged, Melee, General, Ring, Shield, Ammo)
        private bool _plotItem = false;
        private bool _canNotBeChangedInCombat = false;
        private int _value = 0; //cost in credits
        private int _quantity = 1; //useful for stacking and ammo
        private int _groupSizeForSellingStackableItems = 1;
        private int _charges = 0; //useful for items like wands
        private string _ammoType = "none";
        private bool _twoHanded = false; //requires the use of two hands
        private int _threatRange = 20;
        private int _criticalMultiplier = 2;
        private bool _isLightWeapon = false; //true if it is a light weapon
        private bool _isFinesseWeapon = false; //if true, use dex modifier for attack roll, else use strength modifier
        private bool _canNotBeUnequipped = false; //set to true for cursed items or summon creature items
        private bool _onlyUseableWhenEquipped = false;
        private bool _endTurnAfterEquipping = true;
        private bool _isStackable = false;
        private bool _automaticallyHitsTarget = false; //does not require a successful to hit roll, always hits target (ex. mage bolt wand)
        private int _attackBonus = 0; //attack bonus
        private int _attackRange = 1; //attack range
        private int _AreaOfEffect = 0; //AoE
        private AreaOfEffectShape _aoeShape = AreaOfEffectShape.Circle;
        private int _damageNumDice = 1; //number of dice to roll for damage
        private int _damageDie = 2; //type of dice to roll for damage
        private int _damageAdder = 0; //the adder like 2d4+1 where "1" is the adder
        private int _armorBonus = 0; //armor bonus
        private int _maxDexBonus = 99; //maximum Dexterity bonus allowed with this armor
        private int _attributeBonusModifierStr = 0;
        private int _attributeBonusModifierDex = 0;
        private int _attributeBonusModifierInt = 0;
        private int _attributeBonusModifierCha = 0;
        private int _attributeBonusModifierCon = 0;
        private int _attributeBonusModifierWis = 0;
        private int _additionalAttacks = 0;
        private int _requiredLevel = 0;
        private int _modifierMaxHP = 0;
        private int _modifierMaxSP = 0;
        private int _savingThrowModifierReflex = 0;
        private int _savingThrowModifierFortitude = 0;
        private int _savingThrowModifierWill = 0;
        private int movementPointModifier = 0;
        private int _spRegenPerRoundInCombat = 0;
        private int _minutesPerSpRegenOutsideCombat = 0;
        //minutesPerSpRegenOutsideCombat
        private int _hpRegenPerRoundInCombat = 0;
        private int _minutesPerHpRegenOutsideCombat = 0;
        private string _onScoringHit = "none";
        private string _onScoringHitParms = "none";
        private string _onUseItem = "none";
        private string _onUseItemLogicTree = "none";
        private string _onUseItemLogicTreeParms = "";
        private bool _destroyItemAfterOnUseItemLogicTree = false;
        private string _onUseItemIBScript = "none";
        private string _onUseItemIBScriptParms = "";
        private bool _destroyItemAfterOnUseItemIBScript = false;
        private string _onWhileEquipped = "none";
        private string _onScoringHitCastSpellTag = "none";
        private string _onUseItemCastSpellTag = "none";
        private bool _destroyItemAfterOnUseItemCastSpell = false;
        private int _levelOfItemForCastSpell = 1;
        private bool _usePlayerClassLevelForOnUseItemCastSpell = false;
        private int _damageTypeResistanceValueAcid = 0;
        private int _damageTypeResistanceValueCold = 0;
        private int _damageTypeResistanceValueNormal = 0;
        private int _damageTypeResistanceValueElectricity = 0;
        private int _damageTypeResistanceValueFire = 0;
        private int _damageTypeResistanceValueMagic = 0;
        private int _damageTypeResistanceValuePoison = 0;
        private string _typeOfDamage = "Normal"; //Normal,Acid,Cold,Electricity,Fire,Magic,Poison

        private int _maxStrengthBonusAllowedForWeapon = 100;
        private int _spCostPerAttack = 0;
        private int _hpCostPerAttack = 0;

        private int _requiredSTR = 0;
        private int _requiredDEX = 0;
        private int _requiredCON = 0;
        private int _requiredINT = 0;
        private int _requiredWIS = 0;
        private int _requiredCHA = 0;

        private string _requiredRace = "none";
        private string _restrictedRace = "none";
        private string _requiredTrait = "none";


        private bool _isRation = false;
        private bool _isLightSource = false;

        private List<LocalImmunityString> _entriesForPcTags = new List<LocalImmunityString>();

        private bool _onScoringHitCastOnSelf = false;
        //copy.onScoringHitCastOnSelf = this.onScoringHitCastOnSelf;

        private string _tagOfTraitInfluenced = "none";
        private int _traitSkillRollModifier = 0;

        #endregion

        /*
        categories:
        x01 - Requirements and Costs
        x02 - Resistances and Saves 
        x03 - Attributes
        x04 - Attack and Damage
        x05 - Protection and Regeneration
        x06 - Graphics and Sounds
        x07 - Handling and Moves
        x08 - Basics
        09 - Spells
        10 - Premade Scripts
        11 - IB Scripts
        12 - Not used anymore

       Sorting:
       01 - Basics
       02 - Graphics and Sounds
       03 - Requirements and Costs
       04 - Handling and Moves
       05 - Attack and Damage
       06 - Protection and Regeneration
       07 - Resistances and Saves
       08 - Attributes
       09 - Hooks: Spells
       10 - Hooks: Premade Scripts
       11 - Hooks: IB Scripts
       12 - Not used anymore

        */
        #region Properties        
        [CategoryAttribute("01 - Names and Descriptions"), DescriptionAttribute("Name of the Item")]
        public string name
        {
            get
            {
                return _name;
            }
            set
            {
                _name = value;
                this.NotifyPropertyChanged("name");
            }
        }
        //[Browsable(true), TypeConverter(typeof(EffectTagTypeConverter))]
        [CategoryAttribute("02 - Essentials and Perks"), DescriptionAttribute("List of tags added to pc's pcTags list upon equipping this item; when unequiping this item, the entry is removed again from pc's pcTags list. For mainhand weapon, ammo and offhand weapon/shield the entries are checked against a creature's harmed by list. When using incremental systems, like magic+1, magic+2, etc. make sure to have the the single digit number at the end and to have the first entry of such type start with +1 at the end.")]
        public List<LocalImmunityString> entriesForPcTags
        {
            get { return _entriesForPcTags; }
            set { _entriesForPcTags = value; }
        }
        [CategoryAttribute("01 - Names and Descriptions"), DescriptionAttribute("label for the cast action when using this item in log")]
        public string labelForTheCastAction
        {
            get
            {
                return _labelForTheCastAction;
            }
            set
            {
                _labelForTheCastAction = value;
                this.NotifyPropertyChanged("labelForTheCastAction");
            }
        }
        [CategoryAttribute("02 - Essentials and Perks"), DescriptionAttribute("Tag of the Item (will be given an unique tag for each placed instance of an item)")]
        public string tag
        {
            get
            {
                return _tag;
            }
            set
            {
                _tag = value;
                this.NotifyPropertyChanged("tag");
            }
        }
        [CategoryAttribute("02 - Essentials and Perks"), DescriptionAttribute("Resref of the Item (Must be unique from other item blueprints). All placed items will be linked to this blueprint via this resref tag so that updates here will be reflected on all placed items (unless a specific item property uses the saved game data like item charges.")]
        public string resref
        {
            get
            {
                return _resref;
            }
            set
            {
                _resref = value;
                this.NotifyPropertyChanged("resref");
            }
        }
        [CategoryAttribute("07 - Handling and Moves"), DescriptionAttribute("ARMOR only: Armor Weight Type (used when the item is an armor)")]
        public string ArmorWeightType
        {
            get
            {
                return _armorWeightType;
            }
            set
            {
                _armorWeightType = value;
            }

        }
        [CategoryAttribute("01 - Names and Descriptions"), DescriptionAttribute("grouping purposes in toolset")]
        public string ItemCategoryName
        {
            get
            {
                return _itemCategoryName;
            }
            set
            {
                _itemCategoryName = value;
                this.NotifyPropertyChanged("ItemCategoryName");
            }
        }

        //private string _tagOfTraitInfluenced = "none";
        //private int _traitSkillRollModifier = 0;
        [Browsable(true), TypeConverter(typeof(TraitTagTypeConverter))]
        [CategoryAttribute("11 - Attributes and Skills"), DescriptionAttribute("Tag of the skill to influence")]
        public string tagOfTraitInfluenced
        {
            get
            {
                return _tagOfTraitInfluenced;
            }
            set
            {
                _tagOfTraitInfluenced = value;
                //this.NotifyPropertyChanged("category");
            }
        }

        [CategoryAttribute("11 - Attributes and Skills"), DescriptionAttribute("Skill roll modifier for the associated trait")]
        public int traitSkillRollModifier
        {
            get
            {
                return _traitSkillRollModifier;
            }
            set
            {
                _traitSkillRollModifier = value;
                //this.NotifyPropertyChanged("category");
            }
        }

        [Browsable(true), TypeConverter(typeof(ItemTypeConverter))]
        [CategoryAttribute("02 - Essentials and Perks"), DescriptionAttribute("Category that this Item belongs to")]
        public string category
        {
            get
            {
                return _category;
            }
            set
            {
                _category = value;
                this.NotifyPropertyChanged("category");
            }
        }
        [Editor(typeof(MultilineStringEditor), typeof(UITypeEditor))]
        [CategoryAttribute("01 - Names and Descriptions"), DescriptionAttribute("Description of the Item")]
        public string desc
        {
            get
            {
                return _desc;
            }
            set
            {
                _desc = value;
                this.NotifyPropertyChanged("desc");
            }
        }
        /*[CategoryAttribute("99 - Not Implemented Yet"), DescriptionAttribute("When can this be used: Always means that it can be used in combat and on the main maps, Passive means that it is always on and doesn't need to be activated.")]
        public useableinsituation UseableInSituation
        {
            get { return useableInSituation; }
            set { useableInSituation = value; }
        }*/
        [Browsable(true), TypeConverter(typeof(UseableWhenConverter))]
        [CategoryAttribute("07 - Handling and Moves"), DescriptionAttribute("When can this be used: Always means that it can be used in combat and on the main maps, Passive means that it is always on and doesn't need to be activated.")]
        public string useableInSituation
        {
            get { return _useableInSituation; }
            set { _useableInSituation = value; }
        }
        [Browsable(true), TypeConverter(typeof(SpriteConverter))]
        [CategoryAttribute("05 - Graphics and Sounds"), DescriptionAttribute("AMMO only: Sprite to use for the projectile (Sprite Filename with extension)")]
        public string projectileSpriteFilename
        {
            get
            {
                return _projectileSpriteFilename;
            }
            set
            {
                _projectileSpriteFilename = value;
            }
        }        
        [Browsable(true), TypeConverter(typeof(SpriteConverter))]
        [CategoryAttribute("15 - Not used anymore"), DescriptionAttribute("Sprite to use for the projectile ending effect (Sprite Filename with extension)")]
        public string spriteEndingFilename
        {
            get
            {
                return _spriteEndingFilename;
            }
            set
            {
                _spriteEndingFilename = value;
            }
        }
        [Browsable(true), TypeConverter(typeof(SoundConverter))]
        [CategoryAttribute("05 - Graphics and Sounds"), DescriptionAttribute("MELEE/RANGED only: Filename of sound to play when the item is used (no extension)")]
        public string itemOnUseSound
        {
            get { return _itemOnUseSound; }
            set { _itemOnUseSound = value; }
        }
        [CategoryAttribute("05 - Graphics and Sounds"), DescriptionAttribute("Icon Filename of the Item"), ReadOnly(true)]
        public string itemImage
        {
            get
            {
                return _itemImage;
            }
            set
            {
                _itemImage = value;
            }
        }
        /*[CategoryAttribute("01 - Main"), DescriptionAttribute("Item Category Type")]
        public category ItemCategory
        {
            get
            {
                return p_category;
            }
            set
            {
                p_category = value;
            }
        }*/
        [CategoryAttribute("04 - Utility and Plot"), DescriptionAttribute("Plot items cannot be dropped or sold.")]
        public bool plotItem
        {
            get
            {
                return _plotItem;
            }
            set
            {
                _plotItem = value;
            }
        }


        [CategoryAttribute("07 - Handling and Moves"), DescriptionAttribute("When set to true, this item can neither be equipped or unequipped during battle.")]
        public bool canNotBeChangedInCombat
        {
            get
            {
                return _canNotBeChangedInCombat;
            }
            set
            {
                _canNotBeChangedInCombat = value;
            }
        }

        [CategoryAttribute("03 - Quantity and Price"), DescriptionAttribute("Cost of the Item or Item group (see groupSizeForSellingStackableItems) in Gold Pieces")]
        public int value
        {
            get
            {
                return _value;
            }
            set
            {
                _value = value;
                this.NotifyPropertyChanged("value");
            }
        }

        /*
        1. The Charges property is not used anymore, use Quantity instead to define the number of charges
        2. Quantity 1 indicates an item that does not contain any on use charges (spell/script/ibscript), it's the default setting
        3. When assiging a spell/script/ib script to one of the on use hooks and setting quantity to higher 1, the item will consume charges on use
        4. Please make the Quantity one number higher than the intended number of charges (eg for a five charges item set Quantity to 6, please)
        5. Ammunition type itmes will not work correctly as useableitems (please assign no scripts/spells/ibscripts their on use hooks)
        6. Plese make sure that useable items are non-stackable (must double check if this is really neccessary, but for starter lets keep to this rule) 
        */

        [CategoryAttribute("03 - Quantity and Price"), DescriptionAttribute("If on-use-hooks not utilized: number is quantity; If on-use-hook utilized, entry is charges: 1 means no charges consumed, otherwise charges are entered number - 1. Note: AMMO is not allowed to have on-use-hooks utilized.")]
        public int quantity
        {
            get { return _quantity; }
            set { _quantity = value; }
        }
        [CategoryAttribute("03 - Quantity and Price"), DescriptionAttribute("When selling items that are stackable, this number represents the quantity of this item that will be sold in one transactionn and the value in the 'value' property represents the cost for this group size.")]
        public int groupSizeForSellingStackableItems
        {
            get { return _groupSizeForSellingStackableItems; }
            set { _groupSizeForSellingStackableItems = value; }
        }
        [CategoryAttribute("15 - Not used anymore"), DescriptionAttribute("Number of charges the item has (useful for items like wands.")]
        public int charges
        {
            get { return _charges; }
            set { _charges = value; }
        }
        [CategoryAttribute("02 - Essentials and Perks"), DescriptionAttribute("RANGED and AMMO only: tag of ammo type that links ranged weapon launchers with ammo (the ammoType tag for RANGED and its AMMO must match exactly).")]
        public string ammoType
        {
            get { return _ammoType; }
            set { _ammoType = value; }
        }
        [CategoryAttribute("07 - Handling and Moves"), DescriptionAttribute("MELEE, RANGED: True if item requires the use of two hands.")]
        public bool twoHanded
        {
            get
            {
                return _twoHanded;
            }
            set
            {
                _twoHanded = value;
            }
        }

        [CategoryAttribute("08 - Attack and Damage"), DescriptionAttribute("Enter the threat range for a critical hit roll. 18 means a roll of 18+ is successful.")]
        public int threatRange
        {
            get
            {
                return _threatRange;
            }
            set
            {
                _threatRange = value;
            }
        }
        [CategoryAttribute("08 - Attack and Damage"), DescriptionAttribute("Enter the critical damage multiplier for a successful critical hit. 2 means that the damage is double and 3 is three times the damage, etc.")]
        public int criticalMultiplier
        {
            get
            {
                return _criticalMultiplier;
            }
            set
            {
                _criticalMultiplier = value;
            }
        }
        [CategoryAttribute("07 - Handling and Moves"), DescriptionAttribute("MELEE: True if item is a light weapon. Used for two-weapon fighting modifiers.")]
        public bool isLightWeapon
        {
            get
            {
                return _isLightWeapon;
            }
            set
            {
                _isLightWeapon = value;
            }
        }
        [CategoryAttribute("07 - Handling and Moves"), DescriptionAttribute("MELEE: True if item is a finesse weapon. Uses Dexterity modifier for attack rolls.")]
        public bool isFinesseWeapon
        {
            get
            {
                return _isFinesseWeapon;
            }
            set
            {
                _isFinesseWeapon = value;
            }
        }
        [CategoryAttribute("07 - Handling and Moves"), DescriptionAttribute("When true, equipping such item in combat immediately ends the current player character's turn.")]
        public bool endTurnAfterEquipping
        {
            get
            {
                return _endTurnAfterEquipping;
            }
            set
            {
                _endTurnAfterEquipping = value;
            }
        }

        [CategoryAttribute("07 - Handling and Moves"), DescriptionAttribute("When true, the item can only be used while equipped.")]
        public bool onlyUseableWhenEquipped
        {
            get
            {
                return _onlyUseableWhenEquipped;
            }
            set
            {
                _onlyUseableWhenEquipped = value;
            }
        }

        [CategoryAttribute("07 - Handling and Moves"), DescriptionAttribute("Set True if item can NOT be unequipped. Useful for temporary companion's specific items and cursed items.")]
        public bool canNotBeUnequipped
        {
            get
            {
                return _canNotBeUnequipped;
            }
            set
            {
                _canNotBeUnequipped = value;
            }
        }
        [CategoryAttribute("03 - Quantity and Price"), DescriptionAttribute("Set True if item can be stacked, false for non stackable items. Set to false for charged items.")]
        public bool isStackable
        {
            get
            {
                return _isStackable;
            }
            set
            {
                _isStackable = value;
            }
        }
        [CategoryAttribute("04 - Utility and Plot"), DescriptionAttribute("GENERAL: This item will add to ration counter in the clock line and be consumed as ration each 24h or on rest.")]
        public bool isRation
        {
            get
            {
                return _isRation;
            }
            set
            {
                _isRation = value;
            }
        }

        [CategoryAttribute("12 - Hooks: Spells"), DescriptionAttribute("MELEE, RANGED: the spell on this weapon will center the weapon wielder on a successful hit.")]
        public bool onScoringHitCastOnSelf
        {
            get
            {
                return _onScoringHitCastOnSelf;
            }
            set
            {
                _onScoringHitCastOnSelf = value;
            }
        }

        [CategoryAttribute("04 - Utility and Plot"), DescriptionAttribute("GENERAL: This item is a light source - you must also correctly set up IBScript on useItemIBScriptHook adn its paarmerts (see torch example item).")]
        public bool isLightSource 
        {
            get
            {
                return _isLightSource;
            }
            set
            {
                _isLightSource = value;
            }
        }

        [CategoryAttribute("08 - Attack and Damage"), DescriptionAttribute("MELEE, RANGED: Does not require a successful 'to hit' roll, always hits target.")]
        public bool automaticallyHitsTarget
        {
            get
            {
                return _automaticallyHitsTarget;
            }
            set
            {
                _automaticallyHitsTarget = value;
            }
        }

        [CategoryAttribute("08 - Attack and Damage"), DescriptionAttribute("MELEE, RANGED, AMMO: Item Attack Bonus... Can be used to account for enchantments as well.")]
        public int attackBonus
        {
            get
            {
                return _attackBonus;
            }
            set
            {
                _attackBonus = value;
            }
        }
        [CategoryAttribute("08 - Attack and Damage"), DescriptionAttribute("MELEE, RANGED: Item Attack Range measured in squares (ex 5 = 5 squares)")]
        public int attackRange
        {
            get
            {
                return _attackRange;
            }
            set
            {
                _attackRange = value;
            }
        }
        [CategoryAttribute("15 - Not used anymore"), DescriptionAttribute("Item's Area of Effect radius measured in squares for Spell/Effect properties of item when attacking with the item (for weapons, 0 = 1 square, 1 = 9 squares, etc.)")]
        public int AreaOfEffect
        {
            get
            {
                return _AreaOfEffect;
            }
            set
            {
                _AreaOfEffect = value;
            }
        }
        [CategoryAttribute("15 - Not used anymore"), DescriptionAttribute("the shape of the AoE when attacking with this item (for weapons).")]
        [JsonConverter(typeof(StringEnumConverter))]
        public AreaOfEffectShape aoeShape
        {
            get
            {
                return _aoeShape;
            }
            set
            {
                _aoeShape = value;
            }
        }
        [CategoryAttribute("08 - Attack and Damage"), DescriptionAttribute("MELEE, RANGED: number of dice to roll for damage")]
        public int damageNumDice
        {
            get
            {
                return _damageNumDice;
            }
            set
            {
                _damageNumDice = value;
            }
        }
        [CategoryAttribute("08 - Attack and Damage"), DescriptionAttribute("MELEE, RANGED: number of sided die to roll for damage")]
        public int damageDie
        {
            get
            {
                return _damageDie;
            }
            set
            {
                _damageDie = value;
            }
        }
        [CategoryAttribute("08 - Attack and Damage"), DescriptionAttribute("MELEE, RANGED, AMMO: The damage adder...for example with 2d4+1, the '1' is the adder. Can be used to account for enchantments as well.")]
        public int damageAdder
        {
            get
            {
                return _damageAdder;
            }
            set
            {
                _damageAdder = value;
            }
        }
        [CategoryAttribute("09 - Protection and Regeneration"), DescriptionAttribute("Item's armor bonus")]
        public int armorBonus
        {
            get
            {
                return _armorBonus;
            }
            set
            {
                _armorBonus = value;
            }
        }
        [CategoryAttribute("09 - Protection and Regeneration"), DescriptionAttribute("Maximum Dexterity Bonus allowed with this Item")]
        public int maxDexBonus
        {
            get
            {
                return _maxDexBonus;
            }
            set
            {
                _maxDexBonus = value;
            }
        }
        [CategoryAttribute("10 - Resistances and Saves"), DescriptionAttribute("Damage resistance value (default is to use -100 to 100 as a percentage of immunity, damage multiplied by percentage so 0 = full damage, 100 = no damage, -100 = double damage)")]
        public int damageTypeResistanceValuePoison
        {
            get { return _damageTypeResistanceValuePoison; }
            set { _damageTypeResistanceValuePoison = value; }
        }
        [CategoryAttribute("10 - Resistances and Saves"), DescriptionAttribute("Damage resistance value (default is to use -100 to 100 as a percentage of immunity, damage multiplied by percentage so 0 = full damage, 100 = no damage, -100 = double damage)")]
        public int damageTypeResistanceValueMagic
        {
            get { return _damageTypeResistanceValueMagic; }
            set { _damageTypeResistanceValueMagic = value; }
        }
        [CategoryAttribute("10 - Resistances and Saves"), DescriptionAttribute("Damage resistance value (default is to use -100 to 100 as a percentage of immunity, damage multiplied by percentage so 0 = full damage, 100 = no damage, -100 = double damage)")]
        public int damageTypeResistanceValueNormal
        {
            get { return _damageTypeResistanceValueNormal; }
            set { _damageTypeResistanceValueNormal = value; }
        }
        [CategoryAttribute("10 - Resistances and Saves"), DescriptionAttribute("Damage resistance value (default is to use -100 to 100 as a percentage of immunity, damage multiplied by percentage so 0 = full damage, 100 = no damage, -100 = double damage)")]
        public int damageTypeResistanceValueAcid
        {
            get { return _damageTypeResistanceValueAcid; }
            set { _damageTypeResistanceValueAcid = value; }
        }
        [CategoryAttribute("10 - Resistances and Saves"), DescriptionAttribute("Damage resistance value (default is to use -100 to 100 as a percentage of immunity, damage multiplied by percentage so 0 = full damage, 100 = no damage, -100 = double damage)")]
        public int damageTypeResistanceValueCold
        {
            get { return _damageTypeResistanceValueCold; }
            set { _damageTypeResistanceValueCold = value; }
        }
        [CategoryAttribute("10 - Resistances and Saves"), DescriptionAttribute("Damage resistance value (default is to use -100 to 100 as a percentage of immunity, damage multiplied by percentage so 0 = full damage, 100 = no damage, -100 = double damage)")]
        public int damageTypeResistanceValueElectricity
        {
            get { return _damageTypeResistanceValueElectricity; }
            set { _damageTypeResistanceValueElectricity = value; }
        }
        [CategoryAttribute("10 - Resistances and Saves"), DescriptionAttribute("Damage resistance value (default is to use -100 to 100 as a percentage of immunity, damage multiplied by percentage so 0 = full damage, 100 = no damage, -100 = double damage)")]
        public int damageTypeResistanceValueFire
        {
            get { return _damageTypeResistanceValueFire; }
            set { _damageTypeResistanceValueFire = value; }
        }
        /*[CategoryAttribute("01 - Main"), DescriptionAttribute("The Type of Damage (useful with immunity checks)")]
        public DamageType typeOfDamage
        {
            get { return _typeOfDamage; }
            set { _typeOfDamage = value; }
        }*/
        [CategoryAttribute("08 - Attack and Damage"), DescriptionAttribute("MELEE, RANGED, AMMO: The Type of Damage (useful with immunity checks)")]
        [Browsable(true), TypeConverter(typeof(DamageTypeConverter))]
        public string typeOfDamage
        {
            get { return _typeOfDamage; }
            set { _typeOfDamage = value; }
        }

        [CategoryAttribute("06 - Requirements and Costs"), DescriptionAttribute("Tag of Race required to equip/use")]
        [Browsable(true), TypeConverter(typeof(RaceTagTypeConverter))]
        public string requiredRace
        {
            get { return _requiredRace; }
            set { _requiredRace = value; }
        }

        [CategoryAttribute("06 - Requirements and Costs"), DescriptionAttribute("Tag of Trait required to equip/use")]
        [Browsable(true), TypeConverter(typeof(TraitTagTypeConverter))]
        public string requiredTrait
        {
            get { return _requiredTrait; }
            set { _requiredTrait = value; }
        }

        [CategoryAttribute("06 - Requirements and Costs"), DescriptionAttribute("Tag of Race restricted from equipping/using")]
        [Browsable(true), TypeConverter(typeof(RaceTagTypeConverter))]
        public string restrictedRace
        {
            get { return _restrictedRace; }
            set { _restrictedRace = value; }
        }

        //private int _maxStrengthBonusAllowedForWeapon = 100;
        //private int _spCostPerAttack = 0;
        //private int _hpCostPerAttack = 0;

        [CategoryAttribute("08 - Attack and Damage"), DescriptionAttribute("MELEE: The max damage bonus this weapon can receive from strength attribute, to hit bonus is unaffected")]
        public int maxStrengthBonusAllowedForWeapon
        {
            get { return _maxStrengthBonusAllowedForWeapon; }
            set { _maxStrengthBonusAllowedForWeapon = value; }
        }

        [CategoryAttribute("06 - Requirements and Costs"), DescriptionAttribute("MELEE, RANGED: The cost in hp for each attack; if it cannot be paid anymore, a -10 to hit penalty is applied; cannot kill the user")]
        public int hpCostPerAttack
        {
            get { return _hpCostPerAttack; }
            set { _hpCostPerAttack = value; }
        }

        [CategoryAttribute("06 - Requirements and Costs"), DescriptionAttribute("MELEE, RANGED: The cost in sp for each attack; if it cannot be paid anymore, a -10 to hit penalty is applied")]
        public int spCostPerAttack
        {
            get { return _spCostPerAttack; }
            set { _spCostPerAttack = value; }
        }

        [CategoryAttribute("06 - Requirements and Costs"), DescriptionAttribute("STR required to equip/use")]
        public int requiredSTR
        {
            get { return _requiredSTR; }
            set { _requiredSTR = value; }
        }

        [CategoryAttribute("06 - Requirements and Costs"), DescriptionAttribute("DEX required to equip/use")]
        public int requiredDEX
        {
            get { return _requiredDEX; }
            set { _requiredDEX = value; }
        }

        [CategoryAttribute("06 - Requirements and Costs"), DescriptionAttribute("CON required to equip/use")]
        public int requiredCON
        {
            get { return _requiredCON; }
            set { _requiredCON = value; }
        }

        [CategoryAttribute("06 - Requirements and Costs"), DescriptionAttribute("INT required to equip/use")]
        public int requiredINT
        {
            get { return _requiredINT; }
            set { _requiredINT = value; }
        }

        [CategoryAttribute("06 - Requirements and Costs"), DescriptionAttribute("WIS required to equip/use")]
        public int requiredWIS
        {
            get { return _requiredWIS; }
            set { _requiredWIS = value; }
        }

        [CategoryAttribute("06 - Requirements and Costs"), DescriptionAttribute("CHA required to equip/use")]
        public int requiredCHA
        {
            get { return _requiredCHA; }
            set { _requiredCHA = value; }
        }

        [CategoryAttribute("11 - Attributes and Skills"), DescriptionAttribute("The modifier amount for the Attribute")]
        public int attributeBonusModifierStr
        {
            get { return _attributeBonusModifierStr; }
            set { _attributeBonusModifierStr = value; }
        }
        [CategoryAttribute("11 - Attributes and Skills"), DescriptionAttribute("The modifier amount for the Attribute")]
        public int attributeBonusModifierDex
        {
            get { return _attributeBonusModifierDex; }
            set { _attributeBonusModifierDex = value; }
        }
        [CategoryAttribute("11 - Attributes and Skills"), DescriptionAttribute("The modifier amount for the Attribute")]
        public int attributeBonusModifierInt
        {
            get { return _attributeBonusModifierInt; }
            set { _attributeBonusModifierInt = value; }
        }
        [CategoryAttribute("11 - Attributes and Skills"), DescriptionAttribute("The modifier amount for the Attribute")]
        public int attributeBonusModifierCha
        {
            get { return _attributeBonusModifierCha; }
            set { _attributeBonusModifierCha = value; }
        }
        [CategoryAttribute("11 - Attributes and Skills"), DescriptionAttribute("The modifier amount for the Attribute")]
        public int attributeBonusModifierCon
        {
            get { return _attributeBonusModifierCon; }
            set { _attributeBonusModifierCon = value; }
        }
        [CategoryAttribute("11 - Attributes and Skills"), DescriptionAttribute("The modifier amount for the Attribute")]
        public int attributeBonusModifierWis
        {
            get { return _attributeBonusModifierWis; }
            set { _attributeBonusModifierWis = value; }
        }
        [CategoryAttribute("08 - Attack and Damage"), DescriptionAttribute("Number of additional attacks granted")]
        public int additionalAttacks
        {
            get { return _additionalAttacks; }
            set { _additionalAttacks = value; }
        }
        [CategoryAttribute("06 - Requirements and Costs"), DescriptionAttribute("The modifier for maximum HP")]
        public int requiredLevel
        {
            get { return _requiredLevel; }
            set { _requiredLevel = value; }
        }
        [CategoryAttribute("11 - Attributes and Skills"), DescriptionAttribute("The modifier for maximum HP")]
        public int modifierMaxHP
        {
            get { return _modifierMaxHP; }
            set { _modifierMaxHP = value; }
        }
        [CategoryAttribute("11 - Attributes and Skills"), DescriptionAttribute("The modifier for maximum SP")]
        public int modifierMaxSP
        {
            get { return _modifierMaxSP; }
            set { _modifierMaxSP = value; }
        }
        [CategoryAttribute("10 - Resistances and Saves"), DescriptionAttribute("The modifier amount for the Reflex Saving Throw")]
        public int savingThrowModifierReflex
        {
            get { return _savingThrowModifierReflex; }
            set { _savingThrowModifierReflex = value; }
        }
        [CategoryAttribute("10 - Resistances and Saves"), DescriptionAttribute("The modifier amount for the Will Saving Throw")]
        public int savingThrowModifierWill
        {
            get { return _savingThrowModifierWill; }
            set { _savingThrowModifierWill = value; }
        }
        [CategoryAttribute("10 - Resistances and Saves"), DescriptionAttribute("The modifier amount for the Fortitude Saving Throw")]
        public int savingThrowModifierFortitude
        {
            get { return _savingThrowModifierFortitude; }
            set { _savingThrowModifierFortitude = value; }
        }
        [CategoryAttribute("07 - Handling and Moves"), DescriptionAttribute("Modifier to movement")]
        public int MovementPointModifier
        {
            get { return movementPointModifier; }
            set { movementPointModifier = value; }
        }
        [CategoryAttribute("09 - Protection and Regeneration"), DescriptionAttribute("The number of SP to regenerate per round of combat (regen happens at start of new combat round)")]
        public int spRegenPerRoundInCombat
        {
            get { return _spRegenPerRoundInCombat; }
            set { _spRegenPerRoundInCombat = value; }
        }
        [CategoryAttribute("09 - Protection and Regeneration"), DescriptionAttribute("The number of HP to regenerate per round of combat (regen happens at start of new combat round)")]
        public int hpRegenPerRoundInCombat
        {
            get { return _hpRegenPerRoundInCombat; }
            set { _hpRegenPerRoundInCombat = value; }
        }
        [CategoryAttribute("09 - Protection and Regeneration"), DescriptionAttribute("The number of minutes that need to pass in order for 1 SP to regenerate when outside of combat.")]
        public int minutesPerSpRegenOutsideCombat
        {
            get { return _minutesPerSpRegenOutsideCombat; }
            set { _minutesPerSpRegenOutsideCombat = value; }
        }
        [CategoryAttribute("09 - Protection and Regeneration"), DescriptionAttribute("The number of minutes that need to pass in order for 1 HP to regenerate when outside of combat.")]
        public int minutesPerHpRegenOutsideCombat
        {
            get { return _minutesPerHpRegenOutsideCombat; }
            set { _minutesPerHpRegenOutsideCombat = value; }
        }
        /*[CategoryAttribute("03 - Scripts"), DescriptionAttribute("fires when the item makes a successful hit on a target")]
        [Editor(typeof(ScriptSelectEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public ScriptSelectEditorReturnObject OnScoringHit
        {
            get { return onScoringHit; }
            set { onScoringHit = value; }
        }*/
        [CategoryAttribute("13 - Hooks: Premade Scripts"), DescriptionAttribute("fires when the item makes a successful hit on a target")]
        public string onScoringHit
        {
            get { return _onScoringHit; }
            set { _onScoringHit = value; }
        }
        [CategoryAttribute("13 - Hooks: Premade Scripts"), DescriptionAttribute("(not used yet)optional input parameters if using a LogicTree...comma separated parameters")]
        public string onScoringHitParms
        {
            get { return _onScoringHitParms; }
            set { _onScoringHitParms = value; }
        }
        [Browsable(true), TypeConverter(typeof(LogicTreeConverter))]
        [CategoryAttribute("15 - Not used anymore"), DescriptionAttribute("LogicTree name to be run upon using an item (onUseItem must be set to 'none' for this to work properly)")]
        public string onUseItemLogicTree
        {
            get { return _onUseItemLogicTree; }
            set { _onUseItemLogicTree = value; }
        }
        [CategoryAttribute("15 - Not used anymore"), DescriptionAttribute("Parameters to be used for this LogicTree hook (as many parameters as needed, comma deliminated with no spaces)")]
        public string onUseItemLogicTreeParms
        {
            get { return _onUseItemLogicTreeParms; }
            set { _onUseItemLogicTreeParms = value; }
        }
        [CategoryAttribute("15 - Not used anymore"), DescriptionAttribute("If set to true, the item will be destroyed (or decremented by one if stacked) after the Logic Tree is completed.")]
        public bool destroyItemAfterOnUseItemLogicTree
        {
            get { return _destroyItemAfterOnUseItemLogicTree; }
            set { _destroyItemAfterOnUseItemLogicTree = value; }
        }

        [Browsable(true), TypeConverter(typeof(IBScriptConverter))]
        [CategoryAttribute("14 - Hooks: IB Scripts"), DescriptionAttribute("IBScript name to be run upon using an item (onUseItem must be set to 'none' for this to work properly)")]
        public string onUseItemIBScript
        {
            get { return _onUseItemIBScript; }
            set { _onUseItemIBScript = value; }
        }
        [CategoryAttribute("14 - Hooks: IB Scripts"), DescriptionAttribute("Parameters to be used for this IBScript hook (as many parameters as needed, comma deliminated with no spaces)")]
        public string onUseItemIBScriptParms
        {
            get { return _onUseItemIBScriptParms; }
            set { _onUseItemIBScriptParms = value; }
        }
        [CategoryAttribute("14 - Hooks: IB Scripts"), DescriptionAttribute("If set to true, the item will be destroyed (or decremented by one if stacked) after the IBScript is completed.")]
        public bool destroyItemAfterOnUseItemIBScript
        {
            get { return _destroyItemAfterOnUseItemIBScript; }
            set { _destroyItemAfterOnUseItemIBScript = value; }
        }
        /*[CategoryAttribute("03 - Scripts"), DescriptionAttribute("fires when the item is used")]
        [Editor(typeof(ScriptSelectEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public ScriptSelectEditorReturnObject OnUseItem
        {
            get { return onUseItem; }
            set { onUseItem = value; }
        }*/
        [CategoryAttribute("13 - Hooks: Premade Scripts"), DescriptionAttribute("fires when the item is used (onUseItemLogicTree must be set to 'none' for this to work properly)")]
        public string onUseItem
        {
            get { return _onUseItem; }
            set { _onUseItem = value; }
        } 
        /*[CategoryAttribute("03 - Scripts"), DescriptionAttribute("fires every time the UpdateStats() function is called. Useful for modifying PC's stats.")]
        [Editor(typeof(ScriptSelectEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public ScriptSelectEditorReturnObject OnWhileEquipped
        {
            get { return onWhileEquipped; }
            set { onWhileEquipped = value; }
        }*/
        [CategoryAttribute("13 - Hooks: Premade Scripts"), DescriptionAttribute("fires every time the UpdateStats() function is called. Useful for modifying PC's stats.")]
        public string onWhileEquipped
        {
            get { return _onWhileEquipped; }
            set { _onWhileEquipped = value; }
        }
        [Browsable(true), TypeConverter(typeof(SpellTagTypeConverter))]
        [CategoryAttribute("12 - Hooks: Spells"), DescriptionAttribute("MELEE, RANGED, AMMO: Cast this spell upon the target after making a successful attack (melee/ranged) hit on the target")]
        public string onScoringHitCastSpellTag
        {
            get { return _onScoringHitCastSpellTag; }
            set { _onScoringHitCastSpellTag = value; }
        }
        [Browsable(true), TypeConverter(typeof(SpellTagTypeConverter))]
        [CategoryAttribute("12 - Hooks: Spells"), DescriptionAttribute("Cast this spell upon using the item")]
        public string onUseItemCastSpellTag
        {
            get { return _onUseItemCastSpellTag; }
            set { _onUseItemCastSpellTag = value; }
        }
        [CategoryAttribute("12 - Hooks: Spells"), DescriptionAttribute("If set to true, the item will be destroyed (or decremented by one if stacked/charged) after the spell on th on-use hook is completed.")]
        public bool destroyItemAfterOnUseItemCastSpell
        {
            get { return _destroyItemAfterOnUseItemCastSpell; }
            set { _destroyItemAfterOnUseItemCastSpell = value; }
        }
        [CategoryAttribute("12 - Hooks: Spells"), DescriptionAttribute("Effective level of item used in Effect calculations that are based on level adjustments.")]
        public int levelOfItemForCastSpell
        {
            get { return _levelOfItemForCastSpell; }
            set { _levelOfItemForCastSpell = value; }
        }
        [CategoryAttribute("12 - Hooks: Spells"), DescriptionAttribute("If set to true, the item will use the Player's class level instead of the item's effective level used in Effect calculations that are based on level adjustments.")]
        public bool usePlayerClassLevelForOnUseItemCastSpell
        {
            get { return _usePlayerClassLevelForOnUseItemCastSpell; }
            set { _usePlayerClassLevelForOnUseItemCastSpell = value; }
        }
        #endregion

        public Item()
        {
        }
        private void NotifyPropertyChanged(string name)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(name));
        }
        public void LoadItemBitmap(ParentForm prntForm)
        {
            if (File.Exists(prntForm._mainDirectory + "\\modules\\" + prntForm.mod.moduleName + "\\graphics\\" + this.itemImage + ".png"))
            {
                this.itemIconBitmap = new Bitmap(prntForm._mainDirectory + "\\modules\\" + prntForm.mod.moduleName + "\\graphics\\" + this.itemImage + ".png");
            }
            else if (File.Exists(prntForm._mainDirectory + "\\default\\NewModule\\graphics\\" + this.itemImage + ".png"))
            {
                this.itemIconBitmap = new Bitmap(prntForm._mainDirectory + "\\default\\NewModule\\graphics\\" + this.itemImage + ".png");
            }
            else
            {
                this.itemIconBitmap = new Bitmap(prntForm._mainDirectory + "\\default\\NewModule\\graphics\\" + "missingtexture.png");
            }
        }
        public override string ToString()
        {
            return name;
        }
        public Bitmap LoadItemIconBitmap(string filename)
        {
            // Sets up an image object to be displayed.
            if (itemIconBitmap != null)
            {
                itemIconBitmap.Dispose();
            }
            itemIconBitmap = new Bitmap(filename);
            return itemIconBitmap;
        }
        public Item ShallowCopy()
        {
            return (Item)this.MemberwiseClone();
        }
        public Item DeepCopy()
        {
            Item other = (Item)this.MemberwiseClone();
            return other;
        }
    }

    public class ItemRefs
    {
        private string _resref = "none";
        private string _tag = "none";
        private string _name = "none";
        private bool _canNotBeUnequipped = false;
        private int _quantity = 1; //useful for stacking and ammo
        private bool _isLightSource = false;
        private bool _isRation = false;

        [CategoryAttribute("01 - Main"), DescriptionAttribute("ResRef of the item reference (must be left the same as the blueprint item's resref)")]
        public string resref
        {
            get { return _resref; }
            set { _resref = value; }
        }
        [CategoryAttribute("01 - Main"), DescriptionAttribute("Tag of the item (Must be unique from all other placed item tags)")]
        public string tag
        {
            get { return _tag; }
            set { _tag = value; }
        }
        [CategoryAttribute("01 - Main"), DescriptionAttribute("Name of the item as show in inventory and other places.")]
        public string name
        {
            get { return _name; }
            set { _name = value; }
        }
        [CategoryAttribute("01 - Main"), DescriptionAttribute("Set True if item can NOT be unequipped. Useful for temporary companion's specific items and cursed items.")]
        public bool canNotBeUnequipped
        {
            get { return _canNotBeUnequipped; }
            set { _canNotBeUnequipped = value; }
        }
        [CategoryAttribute("01 - Main"), DescriptionAttribute("isLightSource")]
        public bool isLightSource
        {
            get { return _isLightSource; }
            set { _isLightSource = value; }
        }
        [CategoryAttribute("01 - Main"), DescriptionAttribute("isRation")]
        public bool isRation
        {
            get { return _isRation; }
            set { _isRation = value; }
        }
        [CategoryAttribute("01 - Main"), DescriptionAttribute("Number quantity of this item (useful for stacking items and ammo.")]
        public int quantity
        {
            get { return _quantity; }
            set { _quantity = value; }
        }
        
        public ItemRefs()
        {
        }
        public override string ToString()
        {
            return name;
        }
        public ItemRefs DeepCopy()
        {
            ItemRefs other = (ItemRefs)this.MemberwiseClone();
            return other;
        }
    }
}
