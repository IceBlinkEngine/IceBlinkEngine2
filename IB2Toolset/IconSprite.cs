﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using WeifenLuo.WinFormsUI.Docking;
//using IceBlinkCore;

namespace IB2Toolset
{
    public partial class IconSprite : DockContent
    {
        public ParentForm prntForm;
        public bool refreshingList = false;

        public IconSprite(ParentForm pf)
        {
            InitializeComponent();
            prntForm = pf;
        }

        private void btnSelectIcon_Click(object sender, EventArgs e)
        {
            try
            {
                if (prntForm.frmBlueprints.tabCreatureItem.SelectedIndex == 0) //creature
                {
                    prntForm.LoadCreatureSprite();
                }
                else if (prntForm.frmBlueprints.tabCreatureItem.SelectedIndex == 1) //item
                {
                    prntForm.LoadItemIcon();
                }
                else //prop
                {
                    prntForm.LoadPropSprite();
                }
            }
            catch
            {
                MessageBox.Show("failed to load sprite...make sure to select a creature, item, or prop just before clicking this button.");
            }
        }

        private void cbxKnownSpells_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            //A nice trick to deal with events that you cannot process when they are raised is to delay 
            //the processing. Which you can do with the Control.BeginInvoke() method, it runs as soon 
            //as all events are dispatched, side-effects are complete and the UI thread goes idle again.
            //http://stackoverflow.com/questions/4454058/no-itemchecked-event-in-a-checkedlistbox/4454594#4454594
            //
            this.BeginInvoke((MethodInvoker)delegate
            {
                if (!refreshingList)
                {
                    string _nodeTag = prntForm.lastSelectedCreatureNodeName;
                    int index = prntForm.frmBlueprints.GetCreatureIndex(_nodeTag);
                    if (index >= 0)
                    {
                        Creature crt = prntForm.creaturesList[index];
                        crt.knownSpellsTags.Clear();
                        foreach (object itemChecked in cbxKnownSpells.CheckedItems)
                        {
                            Spell chkdSpell = (Spell)itemChecked;
                            crt.knownSpellsTags.Add(chkdSpell.tag);

                            //set up castChances (list of LoacalInt)
                            //TODO handle situation if spells are removed
                            bool foundSpellAlready = false;
                            foreach (LocalInt lint in crt.castChances)
                            {
                             
                                if (lint.Key == chkdSpell.tag)
                                {
                                    foundSpellAlready = true;
                                    break;
                                } 
                            }

                            if (!foundSpellAlready)
                            {
                                LocalInt castChanceItem = new LocalInt();
                                castChanceItem.Key = chkdSpell.tag;
                                castChanceItem.Value = 0;
                                crt.castChances.Add(castChanceItem);
                            }
                        }
                        //remove cast canches from list if their key is not contained in list with knwon spell tags
                        for (int i = crt.castChances.Count - 1; i >= 0; i--)
                        {
                            bool spellIsKnown = false;
                            foreach (string s in crt.knownSpellsTags)
                            {
                                if (crt.castChances[i].Key == s)
                                {
                                    spellIsKnown = true;
                                    break;
                                }
                            }
                            if (!spellIsKnown)
                            {
                                crt.castChances.RemoveAt(i);
                            }
                        }
                    }
                }
            });            
        }
        
        public void refreshSpellsKnown()
        {
            cbxKnownSpells.BeginUpdate();
            cbxKnownSpells.DataSource = null;
            cbxKnownSpells.DataSource = prntForm.spellsList;
            cbxKnownSpells.DisplayMember = "name";
            cbxKnownSpells.EndUpdate();

            //uncheck all first
            for (int i = 0; i < cbxKnownSpells.Items.Count; i++)
            {
                cbxKnownSpells.SetItemChecked(i, false);
            }
            //iterate and check ones in list
            if (prntForm.frmBlueprints != null)
            {
                if (prntForm.frmBlueprints.tabCreatureItem.SelectedIndex == 0) //creature
                {
                    if (prntForm.lastSelectedCreatureNodeName != "")
                    {
                        string _nodeTag = prntForm.lastSelectedCreatureNodeName;
                        Creature crt = prntForm.creaturesList[prntForm.frmBlueprints.GetCreatureIndex(_nodeTag)];
                        refreshingList = true;
                        for (int i = 0; i < cbxKnownSpells.Items.Count; i++)
                        {
                            Spell thisSpell = (Spell)cbxKnownSpells.Items[i];
                            if (crt.knownSpellsTags.Contains((string)thisSpell.tag))
                            {
                                cbxKnownSpells.SetItemChecked(i, true);
                            }
                        }
                        refreshingList = false;
                    }
                }
            }
        }
    }
}
