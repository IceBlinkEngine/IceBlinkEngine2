﻿ using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.ComponentModel;
using System.Drawing;
using Newtonsoft.Json;
//using IceBlink;

namespace IB2Toolset
{
    public class Module
    {
        #region Fields

        [JsonIgnore]
        public bool copiedWPInsertModeOn = false;

        [JsonIgnore]
        public bool copiedPropInsertModeOn = false;

        [JsonIgnore]
        public bool copiedTriggerInsertModeOn = false;

        [JsonIgnore]
        public WayPoint copiedWayPoint = new WayPoint();

        public string areaFilename = "none";
        [JsonIgnore]
        public Prop wp_selectedProp = new Prop();
        [JsonIgnore]
        public Prop nonWp_selectedProp = new Prop();

        [JsonIgnore]
        public Trigger selectedTriggerCopy = new Trigger();

        public int currentlySelectedWayPointIndex = 0;

        //todo
        private bool _useLayers4And5AsNormalLayers = false;

        private int _overrideVisibilityRange = 2;
        private bool _useScrollingSystem = true;
        private float _scrollingSpeed = 4f;//default 4f, lower is faster

        private float _nightTimeDarknessOpacity = 0.6f;
        private bool _useHybridRollPointDistribution = false;
        private bool _useManualPointDistribution = true;
        private int _attributeBaseValue = 10;
        private int _attributeMinValue = 6;
        private int _attributeMaxValue = 18;
        private int _pointPoolSize = 15;
        private int _twoPointThreshold = 14;
        private int _threePointThreshold = 16;
        private int _fourPointThreshold = 18;
        private int _numberOfMentalAtttributesBelowBaseAllowed = 2;
        private int _numberOfPhysicalAtttributesBelowBaseAllowed = 2;

        private bool _heightBlocksSight = true;
        private bool _allEffectsUseFullSizeIcons = false;
        //_thisEffectUsesFullSizeIcon

        private bool _playFootstepSound = true;
        private float _nightTimeDarkness = 0.65f;
        private string _tagOfStealthMainTrait = "shadow";
        private string _tagOfMovementSpeedTrait = "traveller";
        private string _tagOfSpotEnemyTrait = "lookout";
        private string _tagOfStealthCombatTrait = "stealth";
        private string _tagOfDisarmTrapCombatTrait = "disabledevice";

        private bool _useFlatFootedSystem = true;

        private bool _useLightSystem = false;
        private bool _useComplexCoordinateSystem = true;
        
        private int _nightFightModifier = -4;
        private int _darkFightModifier = -8;
        private bool _useAlternativeSpeechBubbleSystem = true;

        private bool _noRimLights = false;
        private bool _blendOutTooHighAndTooDeepTiles = false;

        private bool _activeSearchDoneThisMove = false;
        private bool _activeSearchSPCostPaidByByLeaderOnly = true;
        private int _activeSearchSPCost = 1;

        private bool _encounterSingleImageAutoScale = true;
        public string formerDirection = "none";
        private bool _usePredefinedTileCategories = true; 
        public List<string> masterAreasList = new List<string>(); 
        //private string moduleFolderName = "";
        private string _moduleName = "";
        private string _moduleLabelName = "";
        private int _moduleVersion = 1;
        public string saveName = "empty";
        private string _defaultPlayerFilename = "drin.json";
        private bool _hideRoster = false;
        private bool _mustUsePreMadePC = false;
        private int _numberOfPlayerMadePcsAllowed = 1;
        private int _numberOfPlayerMadePcsRequired = 1;
        private int maxPartySize = 6;

        private bool _showType = true;
        private bool _showHitBy = true;
        private bool _showRegen = true;
        private bool _showDeathScript = true;
        private bool _showAI = true;
        private bool _showSpells = true;

        private string _moduleDescription = "";
        private string _moduleCredits = "<big><b>Lanterna - The Exile</b></big><BR><BR>"
                        + "-Story, coding and some art by <b>slowdive_fan</b><BR><BR>"
                        + "-Portrait art by Bree Arts<BR><BR>"
                        + "<i>(an IceBlink Engine conversion to Android)</i><BR><BR>"
                        + "visit the forums for more info:<BR>"
                        + "www.iceblinkengine.com/forums";
        private int _nextIdNumber = 100;
        private int worldTime = 0;
        public int TimePerRound = 6;
        public bool debugMode = true;
        public float diagonalMoveCost = 1.5f;
        public bool useLuck = false;
        public bool use3d6 = false;
        private bool _allowIntraPartyConvos = false;
        //public int linkedAreasCounter = 0;
        public bool ArmorClassAscending = true;
        public List<Item> moduleItemsList = new List<Item>();
        public List<Encounter> moduleEncountersList = new List<Encounter>();
        public List<Container> moduleContainersList = new List<Container>();
        public List<Shop> moduleShopsList = new List<Shop>();
        public List<Creature> moduleCreaturesList = new List<Creature>();
        public List<JournalQuest> moduleJournal = new List<JournalQuest>();
        public List<PlayerClass> modulePlayerClassList = new List<PlayerClass>();
        public List<Race> moduleRacesList = new List<Race>();
        public List<Spell> moduleSpellsList = new List<Spell>();
        public List<Trait> moduleTraitsList = new List<Trait>();
        public List<Effect> moduleEffectsList = new List<Effect>();
        public List<string> moduleAreasList = new List<string>();
        public List<string> moduleConvosList = new List<string>();
        public List<string> moduleLogicTreesList = new List<string>();
        public List<string> moduleIBScriptsList = new List<string>();
        public List<Area> moduleAreasObjects = new List<Area>();
        public List<GlobalInt> moduleGlobalInts = new List<GlobalInt>();
        public List<GlobalString> moduleGlobalStrings = new List<GlobalString>();
        public List<ConvoSavedValues> moduleConvoSavedValuesList = new List<ConvoSavedValues>();
        public List<GlobalListItem> ModuleGlobalListItems = new List<GlobalListItem>();
        public List<LocalListItem> ModuleLocalListItems = new List<LocalListItem>();
        private string _startingArea = "";
        private int _startingPlayerPositionX = 0;
        private int _startingPlayerPositionY = 0;
        public int playerLocationX = 0;
        public int playerLocationY = 0;
        public int playerLastLocationX = 0;
        public int playerLastLocationY = 0;
        private int _partyGold = 0;
        public bool showPartyToken = false;
        private string _partyTokenFilename = "prp_party";
        public List<Player> playerList = new List<Player>();
        //public List<Item> partyInventoryList = new List<Item>();
        //public List<string> partyInventoryTagList = new List<string>();
        public List<ItemRefs> partyInventoryRefsList = new List<ItemRefs>();
        public List<JournalQuest> partyJournalQuests = new List<JournalQuest>();
        public List<JournalQuest> partyJournalCompleted = new List<JournalQuest>();
        public string partyJournalNotes = "";
        public int selectedPartyLeader = 0;
        public bool returnCheck = false;
        public bool addPCScriptFired = false;
        public bool uncheckConvo = false;
        public bool removeCreature = false;
        public bool deleteItemUsedScript = false;
        public int indexOfPCtoLastUseItem = 0;
        public bool com_showGrid = false;
        public bool playMusic = false;
        public bool playButtonSounds = false;
        public bool playButtonHaptic = false;
        public bool showTutorialParty = true;
        public bool showTutorialInventory = true;
        public bool showTutorialCombat = true;
        public bool showAutosaveMessage = true;
        public bool allowAutosave = true;
        public int combatAnimationSpeed = 25;
        private string onHeartBeatLogicTree = "none";
        private string onHeartBeatParms = "";
        private string onHeartBeatIBScript = "none";
        private string onHeartBeatIBScriptParms = "";
        //suggesting here to have realTime off as default, but smoothMove on by default
        //this stays true to 100% turn based, but adds some nice visual indication for the direction a prop comes from/moves to
        private bool _useRealTimeTimer = true;
        private bool _useSmoothMovement = true;
        private int _realTimeTimerLengthInMilliSeconds = 7000;
        public int attackFromBehindToHitModifier = 2;
        public int attackFromBehindDamageModifier = 0;
        private bool _useOrbitronFont = false;
        private bool _useUIBackground = true;
        private string _fontName = "Metamorphous";
        private string _fontFilename = "Metamorphous-Regular.ttf";
        private float _fontD2DScaleMultiplier = 1.0f;
        private int _logNumberOfLines = 20;
        //the spell labels might still be needed ocassionally, check later
        //private string _spellLabelSingular = "Spell";
        private string _spellLabelPlural = "Spells";
        private string _traitsLabelPlural = "Traits";
        private string _goldLabelSingular = "Gold";
        private string _goldLabelPlural = "Gold";
        private string _raceLabel = "Race";
        private int _borderAreaSize = 0;
        private bool _useAllTileSystem = true;
        private bool _useAdjacentAcBonusSystem = false;
        private bool _useAdvancedCasterAI = false;
        private bool _useMinimalisticUI = true;
        private bool _useManualCombatCam = true;
        private bool _useCombatSmoothMovement = true;
        private string _partyLightColor = "yellow";
        private float _partyRingHaloIntensity = 1f;
        private float _partyFocalHaloIntensity = 1f;
        private bool _useMathGridFade = false;
        private int _durationInStepsOfPartyLightItems = 250;
        private int _resistanceMaxValue = 85;

        private string _nameOfFirstDayOfTheWeek = "Monday";
        private string _nameOfSecondDayOfTheWeek = "Tuesday";
        private string _nameOfThirdDayOfTheWeek = "Wednesday";
        private string _nameOfFourthDayOfTheWeek = "Thursday";
        private string _nameOfFifthDayOfTheWeek = "Friday";
        private string _nameOfSixthDayOfTheWeek = "Saturday";
        private string _nameOfSeventhDayOfTheWeek = "Sunday";

        private string _nameOfFirstMonth = "January";
        private string _nameOfSecondMonth = "February";
        private string _nameOfThirdMonth = "March";
        private string _nameOfFourthMonth = "April";
        private string _nameOfFifthMonth = "May";
        private string _nameOfSixthMonth = "June";
        private string _nameOfSeventhMonth = "July";
        private string _nameOfEighthMonth = "August";
        private string _nameOfNinthMonth = "September";
        private string _nameOfTenthMonth = "October";
        private string _nameOfEleventhMonth = "November";
        private string _nameOfTwelfthMonth = "December";

        private int _maxNumberOfRationsAllowed = 7;
        private int _maxNumberOfLightSourcesAllowed = 7;

        private bool _useRationSystem = true;

        private float _fogOfWarOpacity = 0.9525f;
        private bool _spritesUnderOverlays = true;

        private bool _hungerIsLethal = true;
        private float _maxHPandSPPercentageLostOnHunger = 20;
        private bool _showRestMessagesInLog = true;
        private bool _showRestMessagesInBox = true;
        private string _messageOnRest = "Party safely rests until completely healed.";
        private string _messageOnRestAndRaise = "Party safely rests until completely healed (bringing back the - at least presumedly - dead as well).";

        private bool _hideZeroPowerTraits = false;

        #endregion

        #region Properties
        [CategoryAttribute("01 - Main"), DescriptionAttribute("FileName of the Module and the Folder name as well (no spaces allowed)")]
        public string moduleName
        {
            get { return _moduleName; }
            set { _moduleName = value; }
        }

        //private bool _useScrollingSystem = true;
        //private float _scrollingSpeed = 4f;//default 4f, lower is faster

        //private int overrideVisibilityRange = 2;
        //private bool _useLayers4And5AsNormalLayers = false;
        [CategoryAttribute("01 - Main"), DescriptionAttribute("If set to true, the layers for overgrowth(4) and the dynamic layer for objects above party(5) just act as normal layers, like layer 1 to 3, ie always drawn underneath the party.")]
        public bool useLayers4And5AsNormalLayers
        {
            get { return _useLayers4And5AsNormalLayers; }
            set { _useLayers4And5AsNormalLayers = value; }
        }


        [CategoryAttribute("01 - Main"), DescriptionAttribute("This overrides the visibilty settings of the individual areas, unless you set it to -1. 2 is a good value for campaigns with smaller maps, 3 for larger maps.")]
        public int overrideVisibilityRange
        {
            get { return _overrideVisibilityRange; }
            set { _overrideVisibilityRange = value; }
        }

        [CategoryAttribute("01 - Main"), DescriptionAttribute("If true, each move of the party on main map is happening fluidly, scrolling the map a tiny bit.")]
        public bool useScrollingSystem
        {
            get { return _useScrollingSystem; }
            set { _useScrollingSystem = value; }
        }

        [CategoryAttribute("01 - Main"), DescriptionAttribute("Thr scrolling speed on main map; defaults to 4.0; lower is faster")]
        public float scrollingSpeed
        {
            get { return _scrollingSpeed; }
            set { _scrollingSpeed = value; }
        }

        [CategoryAttribute("01 - Main"), DescriptionAttribute("The darkness of the night time (usually between 0.1 and 1, free to try more extreme, lower means a more transparent, ie lighter, night graphic). 0.6 is what I am currently using, try 1.0 for night time tint used before beta 1.38")]
        public float nightTimeDarknessOpacity
        {
            get { return _nightTimeDarknessOpacity; }
            set { _nightTimeDarknessOpacity = value; }
        }

        [CategoryAttribute("01 - Main"), DescriptionAttribute("If true, the party makes a little walk sound on each step.")]
        public bool playFootstepSound
        {
            get { return _playFootstepSound; }
            set { _playFootstepSound = value; }
        }

        [CategoryAttribute("01 - Main"), DescriptionAttribute("If true, all tiles block sight that are higher than the tile the party is currnetly on. Note: this overrides all manual LoS settings, these get lost when you turn this setting to true. Best set to false for already existing modules that were build without this setting in mind.")]
        public bool heightBlocksSight
        {
            get { return _heightBlocksSight; }
            set { _heightBlocksSight = value; }
        }

        [CategoryAttribute("01 - Main"), DescriptionAttribute("If true, all effect icons are drawn at full suare size on top of actors.")]
        public bool allEffectsUseFullSizeIcons
        {
            get { return _allEffectsUseFullSizeIcons; }
            set { _allEffectsUseFullSizeIcons = value; }
        }
        [CategoryAttribute("01 - Main"), DescriptionAttribute("When set to true, the engine allows for chance that the party or the enemy in an encounter starts flat-footed in the first round of combat, skipping that round. The chances are based on stealth and spotEnemy trait tag rolls using the corresponding DC values of props (or encounters themselves if a an encounter is not carried by a prop with own values).")]
        public bool useFlatFootedSystem
        {
            get { return _useFlatFootedSystem; }
            set { _useFlatFootedSystem = value; }
        }

        //private string _tagOfStealthMainTrait = "shadow";
        //private string _tagOfMovementSpeedTrait = "traveller";
        //private string _tagOfSpotEnemyTrait = "lookout";
        //private string _tagOfStealthCombatTrait = "stealth";
        //private string _tagOfDisarmTrapCombatTrait = "disabledevice";

        [CategoryAttribute("01 - Main"), DescriptionAttribute("The module is using the trait with this tag, eg shadow, for all stralth related skill checks on the main map (avoid being detected by chasing creatures, catch the enemy/be yourself flat-footed in the first round of an encounter).")]
        public string tagOfStealthMainTrait
        {
            get { return _tagOfStealthMainTrait; }
            set { _tagOfStealthMainTrait = value; }
        }

        [CategoryAttribute("01 - Main"), DescriptionAttribute("The module is using the trait with this tag, eg traveller, to determine how much times passes per step on main map. This is also used to modify the chances for double or zero moves of cretaures (props) on main map, granting the party more relative speed.")]
        public string tagOfMovementSpeedTrait
        {
            get { return _tagOfMovementSpeedTrait; }
            set { _tagOfMovementSpeedTrait = value; }
        }

        [CategoryAttribute("01 - Main"), DescriptionAttribute("The module is using the trait with this tag, eg lookout, to determine whether the party can see a stealthy enemy (prop) on main map. Furthermore, this also influences the chances of the enemy/the party to be caught flat-footed in the first round of an encounter.)")]
        public string tagOfSpotEnemyTrait
        {
            get { return _tagOfSpotEnemyTrait; }
            set { _tagOfSpotEnemyTrait = value; }
        }

        [CategoryAttribute("01 - Main"), DescriptionAttribute("The module is using the trait with this tag, eg stealth, to handle chances of hiding in shadows during combat.")]
        public string tagOfStealthCombatTrait 
        {
            get { return _tagOfStealthCombatTrait; }
            set { _tagOfStealthCombatTrait = value; }
        }

        [CategoryAttribute("01 - Main"), DescriptionAttribute("The module is using the trait with this tag, eg disabledevice, to disarm trap props on comabt maps via a usebale trait.")]
        public string tagOfDisarmTrapCombatTrait
        {
            get { return _tagOfDisarmTrapCombatTrait; }
            set { _tagOfDisarmTrapCombatTrait = value; }
        }

        [CategoryAttribute("01 - Main"), DescriptionAttribute("Set to false to use the old way of showing speech bubbles (relative only to curently selected speaker). When true, different answer options on PCs are indicated by differnt bubble positions, indedendent from currently selected speaker.")]
        public bool useAlternativeSpeechBubbleSystem
        {
            get { return _useAlternativeSpeechBubbleSystem; }
            set { _useAlternativeSpeechBubbleSystem = value; }
        }

        [CategoryAttribute("01 - Main"), DescriptionAttribute("When true, the single image map for encounters is automatically scaled to the size of the encounter map; assumes a square shaped map and square shaped image")]
        public bool encounterSingleImageAutoScale
        {
            get { return _encounterSingleImageAutoScale; }
            set { _encounterSingleImageAutoScale = value; }
        }

        //public bool noRimLights = false;
        //public bool blendOutTooHighAndTooDeepTiles = false;
        [CategoryAttribute("01 - Main"), DescriptionAttribute("When true, the rim lights (highlighted lines at edges of tiles with height differences) are not drawn.")]
        public bool noRimLights
        {
            get { return _noRimLights; }
            set { _noRimLights = value; }
        }

        [CategoryAttribute("01 - Main"), DescriptionAttribute("When true, tiles with more than two levels higher or more than two levels lower than the party are blended out and covered with tooHigh.png and tooDeep.png. Turn rim ligths off to use this correctly.")]
        public bool blendOutTooHighAndTooDeepTiles
        {
            get { return _blendOutTooHighAndTooDeepTiles; }
            set { _blendOutTooHighAndTooDeepTiles = value; }
        }

        [CategoryAttribute("01 - Main"), DescriptionAttribute("When true, those traits that are set to be shown in corner of main map are blended out if their power is zero or less.")]
        public bool hideZeroPowerTraits
        {
            get { return _hideZeroPowerTraits; }
            set { _hideZeroPowerTraits = value; }
        }

        [CategoryAttribute("07 - Survival: Light and Rations"), DescriptionAttribute("When set to off, the troch icon in top left corner is not shown (even when using the complex coordinates system and its interface changes)")]
        public bool useLightSystem
        {
            get { return _useLightSystem; }
            set { _useLightSystem = value; }
        }

        [CategoryAttribute("07 - Survival: Light and Rations"), DescriptionAttribute("The debuff to AC, to hit and saves for night fighting without light source. Set to 0 to deactivate.")]
        public int nightFightModifier
        {
            get { return _nightFightModifier; }
            set { _nightFightModifier = value; }
        }

        [CategoryAttribute("07 - Survival: Light and Rations"), DescriptionAttribute("The debuff to AC, to hit and saves for fighting in utter blakckness (dungeon) without light source. Set to 0 to deactivate.")]
        public int darkFightModifier
        {
            get { return _darkFightModifier; }
            set { _darkFightModifier = value; }
        }


        [CategoryAttribute("01 - Main"), DescriptionAttribute("Name of the Module displayed to the player")]
        public string moduleLabelName
        {
            get { return _moduleLabelName; }
            set { _moduleLabelName = value; }
        }
        [CategoryAttribute("01 - Main"), DescriptionAttribute("Version of module (must be an integer...1,2,3,4,etc.)")]
        public int moduleVersion
        {
            get { return _moduleVersion; }
            set { _moduleVersion = value; }
        }
        [CategoryAttribute("03 - Player and Party"), DescriptionAttribute("Filename of the Player to use as the default starting PC or the forced pre-made PC if that flag (mustUsePreMadePC) is true.")]
        public string defaultPlayerFilename
        {
            get { return _defaultPlayerFilename; }
            set { _defaultPlayerFilename = value; }
        }
        [CategoryAttribute("03 - Player and Party"), DescriptionAttribute("Hide roster form party screen; call it via script instead on fitting occassions.")]
        public bool hideRoster
        {
            get { return _hideRoster; }
            set { _hideRoster = value; }
        }
        [CategoryAttribute("03 - Player and Party"), DescriptionAttribute("Set this flag to true if you only want the player to use the pre-made PC identified in defaultPlayerFilename property. The player will not be given an option to create a character.")]
        public bool mustUsePreMadePC
        {
            get { return _mustUsePreMadePC; }
            set { _mustUsePreMadePC = value; }
        }


        /*
        private bool _useManualPointDistribution = true;
        private int _attributeBaseValue = 10;
        private int _attributeMinValue = 6;
        private int _attributeMaxValue = 18;
        private int _pointPoolSize = 15;
        private int _twoPointThreshold = 14;
        private int _threePointThreshold = 16;
        private int _fourPointThreshold = 18;
        private int _numberOfMentalAtttributesBelowBaseAllowed = 2;
        private int _numberOfPhysicalAtttributesBelowBaseAllowed = 2;
        */
        //private bool _useHybridRollPointDistribution = false;

        [CategoryAttribute("03a - Manual Attribute Point Distribution"), DescriptionAttribute("System for manually setting attribute values at pc creation AFTER rolling: min and max values are used, below mental and physical limits are not used, inital poolsize is always zero; set roll method in the rules editor.")]
        public bool useHybridRollPointDistribution
        {
            get { return _useHybridRollPointDistribution; }
            set { _useHybridRollPointDistribution = value; }
        }

        [CategoryAttribute("03a - Manual Attribute Point Distribution"), DescriptionAttribute("System for manually setting attribute values at pc creation INSTEAD of rolling")]
        public bool useManualPointDistribution
        {
            get { return _useManualPointDistribution; }
            set { _useManualPointDistribution = value; }
        }

        [CategoryAttribute("03a - Manual Attribute Point Distribution"), DescriptionAttribute("Hopefully self explanatory")]
        public int attributeBaseValue
        {
            get { return _attributeBaseValue; }
            set { _attributeBaseValue = value; }
        }

        [CategoryAttribute("03a - Manual Attribute Point Distribution"), DescriptionAttribute("Hopefully self explanatory")]
        public int attributeMinValue
        {
            get { return _attributeMinValue; }
            set { _attributeMinValue = value; }
        }

        [CategoryAttribute("03a - Manual Attribute Point Distribution"), DescriptionAttribute("Hopefully self explanatory")]
        public int attributeMaxValue
        {
            get { return _attributeMaxValue; }
            set { _attributeMaxValue = value; }
        }

        [CategoryAttribute("03a - Manual Attribute Point Distribution"), DescriptionAttribute("Hopefully self explanatory")]
        public int pointPoolSize
        {
            get { return _pointPoolSize; }
            set { _pointPoolSize = value; }
        }


        [CategoryAttribute("03a - Manual Attribute Point Distribution"), DescriptionAttribute("Hopefully self explanatory")]
        public int twoPointThreshold
        {
            get { return _twoPointThreshold; }
            set { _twoPointThreshold = value; }
        }

        [CategoryAttribute("03a - Manual Attribute Point Distribution"), DescriptionAttribute("Hopefully self explanatory")]
        public int threePointThreshold
        {
            get { return _threePointThreshold; }
            set { _threePointThreshold = value; }
        }

        [CategoryAttribute("03a - Manual Attribute Point Distribution"), DescriptionAttribute("Hopefully self explanatory")]
        public int fourPointThreshold
        {
            get { return _fourPointThreshold; }
            set { _fourPointThreshold = value; }
        }

        [CategoryAttribute("03a - Manual Attribute Point Distribution"), DescriptionAttribute("Hopefully self explanatory")]
        public int numberOfMentalAtttributesBelowBaseAllowed
        {
            get { return _numberOfMentalAtttributesBelowBaseAllowed; }
            set { _numberOfMentalAtttributesBelowBaseAllowed = value; }
        }

        [CategoryAttribute("03a - Manual Attribute Point Distribution"), DescriptionAttribute("Hopefully self explanatory")]
        public int numberOfPhysicalAtttributesBelowBaseAllowed
        {
            get { return _numberOfPhysicalAtttributesBelowBaseAllowed; }
            set { _numberOfPhysicalAtttributesBelowBaseAllowed = value; }
        }

        [CategoryAttribute("01 - Main"), DescriptionAttribute("This flag activates the realTime timer. It will make a new turn on main map happen after a number of realtime milliseconds defined in realTimeTimerLengthInMilliSecond. Its main purpose is to have moving NPC and creatures who even move when the party just stands idly. It does not affect combat which never has a real time component")]
        public bool useRealTimeTimer
        {
            get { return _useRealTimeTimer; }
            set { _useRealTimeTimer = value; }
        }

        [CategoryAttribute("01 - Main"), DescriptionAttribute("This flag activates using smooth movements of props (gliding).")]
        public bool useSmoothMovement
        {
            get { return _useSmoothMovement; }
            set { _useSmoothMovement = value; }
        }

        [CategoryAttribute("01 - Main"), DescriptionAttribute("This flag activates using smooth movements of props (gliding).")]
        public bool usePredefinedTileCategories
        {
            get { return _usePredefinedTileCategories; }
            set { _usePredefinedTileCategories = value; }
        }

        [CategoryAttribute("01 - Main"), DescriptionAttribute("This flag determines if the builder is using the new all tile system. If true, all single image background maps for areas will be converted into a folder of sliced tiles after loading (or reloading) an image for the area.")]
        public bool useAllTileSystem
        {
            get { return _useAllTileSystem; }
            set { _useAllTileSystem = value; }

        }

        [CategoryAttribute("01 - Main"), DescriptionAttribute("This flag determines if the builder is using the adjacent allies system. This system gives a PC or Creature +1 to AC for each adjacent ally.")]
        public bool useAdjacentAcBonusSystem
        {
            get { return _useAdjacentAcBonusSystem; }
            set { _useAdjacentAcBonusSystem = value; }

        }

        [CategoryAttribute("01 - Main"), DescriptionAttribute("This flag determines if the builder is using the new Advanced Cster AI (beta) or the old established Caster AI.")]
        public bool useAdvancedCasterAI
        {
            get { return _useAdvancedCasterAI; }
            set { _useAdvancedCasterAI = value; }

        }

        [CategoryAttribute("01 - Main"), DescriptionAttribute("This flag determines whether each party member or only the leader shall pay the sp cost of an active search (space key).")]
        public bool activeSearchSPCostPaidByByLeaderOnly
        {
            get { return _activeSearchSPCostPaidByByLeaderOnly; }
            set { _activeSearchSPCostPaidByByLeaderOnly = value; }

        }

        [CategoryAttribute("01 - Main"), DescriptionAttribute("The number of SP consumed (and required) by an active search action (space key).")]
        public int activeSearchSPCost
        {
            get { return _activeSearchSPCost; }
            set { _activeSearchSPCost = value; }

        }

        [CategoryAttribute("01 - Main"), DescriptionAttribute("Defines how transparent fog of war and darkness are, ranges from 0 to 1. When you set anything less than 1, lights will not dance/shift position anymore due to technical restrtaints.")]
        public float fogOfWarOpacity
        {
            get { return _fogOfWarOpacity; }
            set { _fogOfWarOpacity = value; }

        }

        [CategoryAttribute("01 - Main"), DescriptionAttribute("This flag determines whether sprites, espeically weather, are drawn underneath overlays as fog of war, tint of daytime or darkness. ")]
        public bool spritesUnderOverlays
        {
            get { return _spritesUnderOverlays; }
            set { _spritesUnderOverlays = value; }

        }

        [CategoryAttribute("07 - Survival: Light and Rations"), DescriptionAttribute("This turns on the ration system: consumes one ration every 24h, doing 20% of max hp/sp daamge to sp/hp once no needed ration is present; also resting requires and consumes one extra ration.")]
        public bool useRationSystem
        {
            get { return _useRationSystem; }
            set { _useRationSystem = value; }
        }

         [CategoryAttribute("05 - Labels"), DescriptionAttribute("Label used for calendar, displayed ingame")]
        public string nameOfFirstDayOfTheWeek
        {
            get { return _nameOfFirstDayOfTheWeek; }
            set { _nameOfFirstDayOfTheWeek = value; }
        }

        //private bool _useRationSystem = false;
        [CategoryAttribute("05 - Labels"), DescriptionAttribute("Label used for calendar, displayed ingame")]
        public string nameOfSecondDayOfTheWeek
        {
            get { return _nameOfSecondDayOfTheWeek; }
            set { _nameOfSecondDayOfTheWeek = value; }
        }
        [CategoryAttribute("05 - Labels"), DescriptionAttribute("Label used for calendar, displayed ingame")]
        public string nameOfThirdDayOfTheWeek
        {
            get { return _nameOfThirdDayOfTheWeek; }
            set { _nameOfThirdDayOfTheWeek = value; }
        }
       [CategoryAttribute("05 - Labels"), DescriptionAttribute("Label used for calendar, displayed ingame")]
        public string nameOfFourthDayOfTheWeek
        {
            get { return _nameOfFourthDayOfTheWeek; }
            set { _nameOfFourthDayOfTheWeek = value; }
        }
       [CategoryAttribute("05 - Labels"), DescriptionAttribute("Label used for calendar, displayed ingame")]
        public string nameOfFifthDayOfTheWeek
        {
            get { return _nameOfFifthDayOfTheWeek; }
            set { _nameOfFifthDayOfTheWeek = value; }
        }
      [CategoryAttribute("05 - Labels"), DescriptionAttribute("Label used for calendar, displayed ingame")]
        public string nameOfSixthDayOfTheWeek
        {
            get { return _nameOfSixthDayOfTheWeek; }
            set { _nameOfSixthDayOfTheWeek = value; }
        }
       [CategoryAttribute("05 - Labels"), DescriptionAttribute("Label used for calendar, displayed ingame")]
        public string nameOfSeventhDayOfTheWeek
        {
            get { return _nameOfSeventhDayOfTheWeek; }
            set { _nameOfSeventhDayOfTheWeek = value; }
        }
 [CategoryAttribute("05 - Labels"), DescriptionAttribute("Label used for calendar, displayed ingame")]
        public string nameOfFirstMonth
        {
            get { return _nameOfFirstMonth; }
            set { _nameOfFirstMonth = value; }
        }
       [CategoryAttribute("05 - Labels"), DescriptionAttribute("Label used for calendar, displayed ingame")]
        public string nameOfSecondMonth
        {
            get { return _nameOfSecondMonth; }
            set { _nameOfSecondMonth = value; }
        }
     [CategoryAttribute("05 - Labels"), DescriptionAttribute("Label used for calendar, displayed ingame")]
        public string nameOfThirdMonth
        {
            get { return _nameOfThirdMonth; }
            set { _nameOfThirdMonth = value; }
        }
      [CategoryAttribute("05 - Labels"), DescriptionAttribute("Label used for calendar, displayed ingame")]
        public string nameOfFourthMonth
        {
            get { return _nameOfFourthMonth; }
            set { _nameOfFourthMonth = value; }
        }
       [CategoryAttribute("05 - Labels"), DescriptionAttribute("Label used for calendar, displayed ingame")]
        public string nameOfFifthMonth
        {
            get { return _nameOfFifthMonth; }
            set { _nameOfFifthMonth = value; }
        }
    [CategoryAttribute("05 - Labels"), DescriptionAttribute("Label used for calendar, displayed ingame")]
        public string nameOfSixthMonth
        {
            get { return _nameOfSixthMonth; }
            set { _nameOfSixthMonth = value; }
        }
  [CategoryAttribute("05 - Labels"), DescriptionAttribute("Label used for calendar, displayed ingame")]
        public string nameOfSeventhMonth
        {
            get { return _nameOfSeventhMonth; }
            set { _nameOfSeventhMonth = value; }
        }
   [CategoryAttribute("05 - Labels"), DescriptionAttribute("Label used for calendar, displayed ingame")]
        public string nameOfEighthMonth
        {
            get { return _nameOfEighthMonth; }
            set { _nameOfEighthMonth = value; }
        }
     [CategoryAttribute("05 - Labels"), DescriptionAttribute("Label used for calendar, displayed ingame")]
        public string nameOfNinthMonth
        {
            get { return _nameOfNinthMonth; }
            set { _nameOfNinthMonth = value; }
        }
     [CategoryAttribute("05 - Labels"), DescriptionAttribute("Label used for calendar, displayed ingame")]
        public string nameOfTenthMonth
        {
            get { return _nameOfTenthMonth; }
            set { _nameOfTenthMonth = value; }
        }
     [CategoryAttribute("05 - Labels"), DescriptionAttribute("Label used for calendar, displayed ingame")]
        public string nameOfEleventhMonth
        {
            get { return _nameOfEleventhMonth; }
            set { _nameOfEleventhMonth = value; }
        }
       [CategoryAttribute("05 - Labels"), DescriptionAttribute("Label used for calendar, displayed ingame")]
        public string nameOfTwelfthMonth
        {
            get { return _nameOfTwelfthMonth; }
            set { _nameOfTwelfthMonth = value; }
        }

        [CategoryAttribute("07 - Survival: Light and Rations"), DescriptionAttribute("Max number of rations allowed in party inventory.")]
        public int maxNumberOfRationsAllowed
        {
            get { return _maxNumberOfRationsAllowed; }
            set { _maxNumberOfRationsAllowed = value; }
        }

        [CategoryAttribute("07 - Survival: Light and Rations"), DescriptionAttribute("When false, hunger cannot reduce hp below 1.")]
        public bool hungerIsLethal
        {
            get { return _hungerIsLethal; }
            set { _hungerIsLethal = value; }
        }

        [CategoryAttribute("07 - Survival: Light and Rations"), DescriptionAttribute("The hpMAx and spMAx percentage lost every 24h without rations.")]
        public float maxHPandSPPercentageLostOnHunger
        {
            get { return _maxHPandSPPercentageLostOnHunger; }
            set { _maxHPandSPPercentageLostOnHunger = value; }
        }

        [CategoryAttribute("07 - Survival: Light and Rations"), DescriptionAttribute("When false, rest messages in log are not shown.")]
        public bool showRestMessagesInLog
        {
            get { return _showRestMessagesInLog; }
            set { _showRestMessagesInLog = value; }
        }

        [CategoryAttribute("07 - Survival: Light and Rations"), DescriptionAttribute("When false, rest messages in extra message box are not shown.")]
        public bool showRestMessagesInBox
        {
            get { return _showRestMessagesInBox; }
            set { _showRestMessagesInBox = value; }
        }

        [CategoryAttribute("07 - Survival: Light and Rations"), DescriptionAttribute("You can enter a customized message shown on normal resting here (in log and/or message box).")]
        public string messageOnRest
        {
            get { return _messageOnRest; }
            set { _messageOnRest = value; }
        }

        [CategoryAttribute("07 - Survival: Light and Rations"), DescriptionAttribute("You can enter a customized message shown on rest & raise here (in log and/or message box).")]
        public string messageOnRestAndRaise
        {
            get { return _messageOnRestAndRaise; }
            set { _messageOnRestAndRaise = value; }
        }

        [CategoryAttribute("07 - Survival: Light and Rations"), DescriptionAttribute("Max number of light source items allowed in party inventory")]
        public int maxNumberOfLightSourcesAllowed
        {
            get { return _maxNumberOfLightSourcesAllowed; }
            set { _maxNumberOfLightSourcesAllowed = value; }
        }

        [CategoryAttribute("04 - Fonts and UI"), DescriptionAttribute("when true the whoel hierachy of zones and mother areas is diplayed for an area in the clock info text. Also, remaining rations, torches and the current zoom level (with steps per minute) are shown as icons in the top left corner of the ui.")]
        public bool useComplexCoordinateSystem
        {
            get { return _useComplexCoordinateSystem; }
            set { _useComplexCoordinateSystem = value; }
        }

        [CategoryAttribute("04 - Fonts and UI"), DescriptionAttribute("This flag activates using the scifi Orbitron font (light).")]
        public bool useOrbitronFont
        {
            get { return _useOrbitronFont; }
            set { _useOrbitronFont = value; }
        }

        [CategoryAttribute("04 - Fonts and UI"), DescriptionAttribute("This flag activates using UI background graphics.")]
        public bool useUIBackground
        {
            get { return _useUIBackground; }
            set { _useUIBackground = value; }
        }
        [CategoryAttribute("04 - Fonts and UI"), DescriptionAttribute("The file name of the font including extension (ex. Metamorphous-Regular.ttf)")]
        public string fontFilename
        {
            get { return _fontFilename; }
            set { _fontFilename = value; }
        }
        [CategoryAttribute("04 - Fonts and UI"), DescriptionAttribute("The font name. Often is different from the file name. To find out your font's name: find the font file in your modules 'fonts' folder (assuming you already placed the font there), right click on it and select 'preview', the font name is under 'Font name:' (ex. Metamorphous)")]
        public string fontName
        {
            get { return _fontName; }
            set { _fontName = value; }
        }
        [CategoryAttribute("04 - Fonts and UI"), DescriptionAttribute("A multiplier used to adjust the font size so that your custom font will fit well with the UI...keep trying different values until everything works well. This is a float value type so you can use a decimal value. (ex: 1.015 or 0.97 or 0.8 etc.)")]
        public float fontD2DScaleMultiplier
        {
            get { return _fontD2DScaleMultiplier; }
            set { _fontD2DScaleMultiplier = value; }
        }
        [CategoryAttribute("04 - Fonts and UI"), DescriptionAttribute("This sets the number of lines of text that will be shown in the main map and combat log box. Best way to determine the appropriate vaule is to first pick the font size multipler (see fontD2DScaleMultiplier) and then run the game and click on some of the toggle buttons until you fill the log box and then count the number of lines that are displayed. Use that number for this property.")]
        public int logNumberOfLines
        {
            get { return _logNumberOfLines; }
            set { _logNumberOfLines = value; }
        }
        /*
        [CategoryAttribute("05 - Labels"), DescriptionAttribute("Label used for Spell singular form (ex. Spell, Power, etc.)")]
        public string spellLabelSingular
        {
            get { return _spellLabelSingular; }
            set { _spellLabelSingular = value; }
        }
        */
        [CategoryAttribute("05 - Labels"), DescriptionAttribute("Label used for Spell plural form (ex. Spells, Powers, etc.)")]
        public string spellLabelPlural
        {
            get { return _spellLabelPlural; }
            set { _spellLabelPlural = value; }
        }

        [CategoryAttribute("05 - Labels"), DescriptionAttribute("Label used for Trait plural form")]
        public string traitsLabelPlural
        {
            get { return _traitsLabelPlural; }
            set { _traitsLabelPlural = value; }
        }

        [CategoryAttribute("05 - Labels"), DescriptionAttribute("Label used for Race")]
        public string raceLabel
        {
            get { return _raceLabel; }
            set { _raceLabel = value; }
        }

        [CategoryAttribute("05 - Labels"), DescriptionAttribute("Label used for Gold singular form (ex. Gold, Credit, etc.)")]
        public string goldLabelSingular
        {
            get { return _goldLabelSingular; }
            set { _goldLabelSingular = value; }
        }
        [CategoryAttribute("05 - Labels"), DescriptionAttribute("Label used for Gold plural form (ex. Gold, Credits, etc.)")]
        public string goldLabelPlural
        {
            get { return _goldLabelPlural; }
            set { _goldLabelPlural = value; }
        }

        [CategoryAttribute("03 - Player and Party"), DescriptionAttribute("The total number of player made characters allowed in the party (default is 1, max PCs in a party is 6)")]
        public int numberOfPlayerMadePcsAllowed
        {
            get { return _numberOfPlayerMadePcsAllowed; }
            set
            {
                if (value > 6)
                {
                    _numberOfPlayerMadePcsAllowed = 6;
                }
                else if (value < 1)
                {
                    _numberOfPlayerMadePcsAllowed = 1;
                }
                else
                {
                    _numberOfPlayerMadePcsAllowed = value;
                }
            }
        }

        [CategoryAttribute("03 - Player and Party"), DescriptionAttribute(" Set to true to enable intra party convos. These are started by clicking the chat button in party screen. Characters with bubble icons on their portraits have been flagged for new chat entires available via script. You can set them up via a convo named chat in your module's dialogue folder.")]
        public bool allowIntraPartyConvos
        {
            get { return _allowIntraPartyConvos; }
            set { _allowIntraPartyConvos = value;}
        }

        //public bool allowIntraPartyConvos = false;

        [CategoryAttribute("03 - Player and Party"), DescriptionAttribute("The total number of player made characters required in the party (default is 1, max PCs in a party is 6)")]
        public int numberOfPlayerMadePcsRequired
        {
            get { return _numberOfPlayerMadePcsRequired; }
            set
            {
                if (value > 6)
                {
                    _numberOfPlayerMadePcsRequired = 6;
                }
                else if (value < 1)
                {
                    _numberOfPlayerMadePcsRequired = 1;
                }
                else
                {
                    _numberOfPlayerMadePcsRequired = value;
                }
            }
        }

        [CategoryAttribute("03 - Player and Party"), DescriptionAttribute("The maximum total number of players that can be in the party (only values of 1-6 accepted)")]
        public int MaxPartySize
        {
            get { return maxPartySize; }
            set
            {
                if (value > 6)
                {
                    maxPartySize = 6;
                }
                else if (value < 1)
                {
                    maxPartySize = 1;
                }
                else
                {
                    maxPartySize = value;
                }
            }
        }
        [Editor(typeof(MultilineStringEditor), typeof(System.Drawing.Design.UITypeEditor))]
        [CategoryAttribute("01 - Main"), DescriptionAttribute("Description of the Module")]
        public string moduleDescription
        {
            get { return _moduleDescription; }
            set { _moduleDescription = value; }
        }

        [Editor(typeof(MultilineStringEditor), typeof(System.Drawing.Design.UITypeEditor))]
        [CategoryAttribute("01 - Main"), DescriptionAttribute("Text to show up when the 'Credits' button is pressed (use html tags for formatting <b><i><u><br><big><small><tt><h1>…<h6><div><p><font>)")]
        public string moduleCredits
        {
            get { return _moduleCredits; }
            set { _moduleCredits = value; }
        }

        [CategoryAttribute("01 - Main"), DescriptionAttribute("Used for making unique Tags"), ReadOnly(true)]
        public int nextIdNumber
        {
            get
            {
                _nextIdNumber++;
                return _nextIdNumber;
            }
            set { _nextIdNumber = value; }
        }

        [CategoryAttribute("01 - Main"), DescriptionAttribute("The duration in real time milliseconds after which a new turn on main map takes place. Default is 1500, which 1.5 seconds.")]
        public int realTimeTimerLengthInMilliSeconds
        {
            get { return _realTimeTimerLengthInMilliSeconds; }
            set { _realTimeTimerLengthInMilliSeconds = value; }
        }

        [CategoryAttribute("01 - Main"), DescriptionAttribute("If you use an area border, like marble stone in Hearkenwold, set here how many squares broad that border is for the purpose of automatic transitions to neighbouring maps.")]
        public int borderAreaSize
        {
            get { return _borderAreaSize; }
            set { _borderAreaSize = value; }
        }

        [CategoryAttribute("02 - Starting Conditions"), DescriptionAttribute("Current value for World Time in generic units")]
        public int WorldTime
        {
            get { return worldTime; }
            set { worldTime = value; }
        }

        [CategoryAttribute("02 - Starting Conditions"), DescriptionAttribute("Filename of starting Area (DO NOT include \".lvl\" extension)")]
        public string startingArea
        {
            get { return _startingArea; }
            set { _startingArea = value; }
        }

        [CategoryAttribute("02 - Starting Conditions"), DescriptionAttribute("Starting X location in starting area")]
        public int startingPlayerPositionX
        {
            get { return _startingPlayerPositionX; }
            set { _startingPlayerPositionX = value; }
        }

        [CategoryAttribute("02 - Starting Conditions"), DescriptionAttribute("Starting Y location in starting area")]
        public int startingPlayerPositionY
        {
            get { return _startingPlayerPositionY; }
            set { _startingPlayerPositionY = value; }
        }

        [CategoryAttribute("02 - Starting Conditions"), DescriptionAttribute("Starting party gold")]
        public int partyGold
        {
            get { return _partyGold; }
            set { _partyGold = value; }
        }

        [CategoryAttribute("03 - Player and Party"), DescriptionAttribute("filename of the default party token image (minus the extension)")]
        public string partyTokenFilename
        {
            get { return _partyTokenFilename; }
            set { _partyTokenFilename = value; }
        }

        /*
        [Browsable(true), TypeConverter(typeof(LogicTreeConverter))]
        [CategoryAttribute("02 - LogicTree Hooks"), DescriptionAttribute("LogicTree name to be run at the end of each move on any area map (not combat)")]
        public string OnHeartBeatLogicTree
        {
            get { return onHeartBeatLogicTree; }
            set { onHeartBeatLogicTree = value; }
        }
        [CategoryAttribute("02 - LogicTree Hooks"), DescriptionAttribute("Parameters to be used for this LogicTree hook (as many parameters as needed, comma deliminated with no spaces)")]
        public string OnHeartBeatParms
        {
            get { return onHeartBeatParms; }
            set { onHeartBeatParms = value; }
        }
        */

        [Browsable(true), TypeConverter(typeof(IBScriptConverter))]
        [CategoryAttribute("06 - IBScript Hooks"), DescriptionAttribute("IBScript name to be run at the end of each move on any area map (not combat)")]
        public string OnHeartBeatIBScript
        {
            get { return onHeartBeatIBScript; }
            set { onHeartBeatIBScript = value; }
        }
        [CategoryAttribute("06 - IBScript Hooks"), DescriptionAttribute("Parameters to be used for this IBScript hook (as many parameters as needed, comma deliminated with no spaces)")]
        public string OnHeartBeatIBScriptParms
        {
            get { return onHeartBeatIBScriptParms; }
            set { onHeartBeatIBScriptParms = value; }
        }

        [CategoryAttribute("04 - Fonts and UI"), DescriptionAttribute("This activates a less space occupying UI, mainly removing some of the UI backgrounds")]
        public bool useMinimalisticUI
        {
            get { return _useMinimalisticUI; }
            set { _useMinimalisticUI = value; }
        }
        /*
        public bool showType = true;
        public bool showHitBy = true;
        public bool showRegen = true;
        public bool showDeathScript = true;
        public bool showAI = true;
        public bool showSpells = true;
        */
        [CategoryAttribute("04 - Fonts and UI"), DescriptionAttribute("Show type of creature on mouse over during encounters")]
        public bool showType
        {
            get { return _showType; }
            set { _showType = value; }
        }

        [CategoryAttribute("04 - Fonts and UI"), DescriptionAttribute("Show hit by info for creature on mouse over during encounters")]
        public bool showHitBy
        {
            get { return _showHitBy; }
            set { _showHitBy = value; }
        }

        [CategoryAttribute("04 - Fonts and UI"), DescriptionAttribute("Show regeneration info for creature on mouse over during encounters")]
        public bool showRegen
        {
            get { return _showRegen; }
            set { _showRegen = value; }
        }

        [CategoryAttribute("04 - Fonts and UI"), DescriptionAttribute("Show death script for creature on mouse over during encounters")]
        public bool showDeathScript
        {
            get { return _showDeathScript; }
            set { _showDeathScript = value; }
        }

        [CategoryAttribute("04 - Fonts and UI"), DescriptionAttribute("Show AI type of creature on mouse over during encounters")]
        public bool showAI
        {
            get { return _showAI; }
            set { _showAI = value; }
        }

        [CategoryAttribute("04 - Fonts and UI"), DescriptionAttribute("Show spells known by creature on mouse over during encounters")]
        public bool showSpells
        {
            get { return _showSpells; }
            set { _showSpells = value; }
        }


        [CategoryAttribute("04 - Fonts and UI"), DescriptionAttribute("This grants manual control over combat camera, even during cretaure moves. Once a pc is damaged or attacked though, the camera focuses on the pc")]
        public bool useManualCombatCam
        {
            get { return _useManualCombatCam; }
            set { _useManualCombatCam = value; }
        }

        [CategoryAttribute("01 - Main"), DescriptionAttribute("This activates idle glide anmiations as well as move glide animations for creatures in combat")]
        public bool useCombatSmoothMovement
        {
            get { return _useCombatSmoothMovement; }
            set { _useCombatSmoothMovement = value; }
        }

        [CategoryAttribute("04 - Fonts and UI"), DescriptionAttribute("This activates an alternative way for displaying fog of war (which is utter black by default): it will be shown as some kind of grid paper, clearly recognizable from darkness. By replacing (but keepign the name) the .pngs offScreen, offScreen5, offScreen6 and offScreen7 in your module's UI folder you can use even customized graphics for fog of war.")]
        public bool useMathGridFade
        {
            get { return _useMathGridFade; }
            set { _useMathGridFade = value; }
        }
        /*
        [CategoryAttribute("07 - Light"), DescriptionAttribute("Light related: yellow, red, orange, green, blue an purple are possible. Yellow is less intense and rather default.")]
        public string partyLightColor
        {
            get { return _partyLightColor; }
            set { _partyLightColor = value; }
        }
         */

        [CategoryAttribute("07 - Survival: Light and Rations"), DescriptionAttribute("Define here how many steps on map an activated party light source lasts, defaults to 250. Please note that light energy is only consume din darkenss or at night.")]
        public int durationInStepsOfPartyLightItems
        {
            get { return _durationInStepsOfPartyLightItems; }
            set { _durationInStepsOfPartyLightItems = value; }
        }

        [CategoryAttribute("01 - Main"), DescriptionAttribute("The maximum percentage any resistance value can ever reach, a hard cap.")]
        public int resistanceMaxValue
        {
            get { return _resistanceMaxValue; }
            set { _resistanceMaxValue = value; }
        }

        /*
        [CategoryAttribute("07 - Light"), DescriptionAttribute("Light related: defaults to 1.0f. The higher, the more colorful the ring around the light center becomes. Keep between 0.1f and 1.9f as suggestion.")]
        public float partyRingHaloIntensity
        {
            get { return _partyRingHaloIntensity; }
            set { _partyRingHaloIntensity = value; }
        }
         */

        /*
        [CategoryAttribute("07 - Light"), DescriptionAttribute("Light related: defaults to 1.0f. The higher, the more colorful the center of the light becomes. Keep between 0.1f and 1.9f as suggestion.")]
        public float partyFocalHaloIntensity
        {
            get { return _partyFocalHaloIntensity; }
            set { _partyFocalHaloIntensity = value; }
        }
        */



        #endregion

        public Module()
        {
        }
        public void saveModuleFile(string filename)
        {
            string json = JsonConvert.SerializeObject(this, Newtonsoft.Json.Formatting.Indented);
            using (StreamWriter sw = new StreamWriter(filename))
            {
                sw.Write(json.ToString());
            }
        }
        public Module loadModuleFile(string filename)
        {
            Module toReturn = null;

            // deserialize JSON directly from a file
            using (StreamReader file = File.OpenText(filename))
            {
                JsonSerializer serializer = new JsonSerializer();
                toReturn = (Module)serializer.Deserialize(file, typeof(Module));
            }
            return toReturn;
        }
        public void loadAreas(string path, Area area)
        {
            Area newArea = new Area();
            foreach (string areaName in moduleAreasList)
            {
                if (areaName == area.northernNeighbourArea || areaName == area.southernNeighbourArea || areaName == area.easternNeighbourArea || areaName == area.westernNeighbourArea)
                {
                    try
                    {
                        newArea = newArea.loadAreaFile(path + areaName + ".lvl");
                        if (newArea == null)
                        {
                            MessageBox.Show("returned a null area filling areaList");
                        }
                        moduleAreasObjects.Add(newArea);
                        //MessageBox.Show("open file success");
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("failed to open all files: " + ex.ToString() + ex.Message);
                    }
                }
            }
        }
    }
}
