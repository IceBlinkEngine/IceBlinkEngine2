﻿namespace IB2Toolset
{
    partial class RulesEditor
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.gbMoveDiagonalCost = new System.Windows.Forms.GroupBox();
            this.rbtnOnePointFiveSquares = new System.Windows.Forms.RadioButton();
            this.rbtnOneSquare = new System.Windows.Forms.RadioButton();
            this.rtxtInfo = new System.Windows.Forms.RichTextBox();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.gbUseLuck = new System.Windows.Forms.GroupBox();
            this.rbtnUseLuck = new System.Windows.Forms.RadioButton();
            this.rbtnDoNotUseLuck = new System.Windows.Forms.RadioButton();
            this.gbRollingSystem = new System.Windows.Forms.GroupBox();
            this.rbtnUse3d6 = new System.Windows.Forms.RadioButton();
            this.rbtnUse6Plusd12 = new System.Windows.Forms.RadioButton();

            this.gbToHitBonusFromBehind = new System.Windows.Forms.GroupBox();
            this.rbtnPlusOneToHitFromBehind = new System.Windows.Forms.RadioButton();
            this.rbtnPlusTwoToHitFromBehind = new System.Windows.Forms.RadioButton();
            this.rbtnPlusThreeToHitFromBehind = new System.Windows.Forms.RadioButton();
            this.rbtnPlusFourToHitFromBehind = new System.Windows.Forms.RadioButton();
            this.gbArmorClassDisplay = new System.Windows.Forms.GroupBox();
            this.rbtnDescendingAC = new System.Windows.Forms.RadioButton();
            this.rbtnAscendingAC = new System.Windows.Forms.RadioButton();
            this.gbMoveDiagonalCost.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.gbToHitBonusFromBehind.SuspendLayout();
            this.gbArmorClassDisplay.SuspendLayout();
            this.gbUseLuck.SuspendLayout();
            this.gbRollingSystem.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbMoveDiagonalCost
            // 
            this.gbMoveDiagonalCost.Controls.Add(this.rbtnOnePointFiveSquares);
            this.gbMoveDiagonalCost.Controls.Add(this.rbtnOneSquare);
            this.gbMoveDiagonalCost.Location = new System.Drawing.Point(12, 12);
            this.gbMoveDiagonalCost.Name = "gbMoveDiagonalCost";
            this.gbMoveDiagonalCost.Size = new System.Drawing.Size(129, 64);
            this.gbMoveDiagonalCost.TabIndex = 0;
            this.gbMoveDiagonalCost.TabStop = false;
            this.gbMoveDiagonalCost.Text = "Diagonal Move Cost";
            this.gbMoveDiagonalCost.MouseHover += new System.EventHandler(this.gbMoveDiagonalCost_MouseHover);
            // 
            // rbtnOnePointFiveSquares
            // 
            this.rbtnOnePointFiveSquares.AutoSize = true;
            this.rbtnOnePointFiveSquares.Location = new System.Drawing.Point(11, 38);
            this.rbtnOnePointFiveSquares.Name = "rbtnOnePointFiveSquares";
            this.rbtnOnePointFiveSquares.Size = new System.Drawing.Size(88, 17);
            this.rbtnOnePointFiveSquares.TabIndex = 1;
            this.rbtnOnePointFiveSquares.TabStop = true;
            this.rbtnOnePointFiveSquares.Text = "1.5 per Move";
            this.rbtnOnePointFiveSquares.UseVisualStyleBackColor = true;
            this.rbtnOnePointFiveSquares.CheckedChanged += new System.EventHandler(this.rbtnOnePointFiveSquares_CheckedChanged);
            this.rbtnOnePointFiveSquares.MouseHover += new System.EventHandler(this.rbtnOnePointFiveSquares_MouseHover);
            // 
            // rbtnOneSquare
            // 
            this.rbtnOneSquare.AutoSize = true;
            this.rbtnOneSquare.Location = new System.Drawing.Point(11, 18);
            this.rbtnOneSquare.Name = "rbtnOneSquare";
            this.rbtnOneSquare.Size = new System.Drawing.Size(88, 17);
            this.rbtnOneSquare.TabIndex = 0;
            this.rbtnOneSquare.TabStop = true;
            this.rbtnOneSquare.Text = "1.0 per Move";
            this.rbtnOneSquare.UseVisualStyleBackColor = true;
            this.rbtnOneSquare.CheckedChanged += new System.EventHandler(this.rbtnOneSquare_CheckedChanged);
            this.rbtnOneSquare.MouseHover += new System.EventHandler(this.rbtnOneSquare_MouseHover);
            // 
            // rtxtInfo
            // 
            this.rtxtInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rtxtInfo.Location = new System.Drawing.Point(0, 0);
            this.rtxtInfo.Name = "rtxtInfo";
            this.rtxtInfo.Size = new System.Drawing.Size(270, 514);
            this.rtxtInfo.TabIndex = 1;
            this.rtxtInfo.Text = "";
            this.rtxtInfo.MouseHover += new System.EventHandler(this.rtxtInfo_MouseHover);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.gbToHitBonusFromBehind);
            this.splitContainer1.Panel1.Controls.Add(this.gbArmorClassDisplay);
            this.splitContainer1.Panel1.Controls.Add(this.gbMoveDiagonalCost);
            this.splitContainer1.Panel1.Controls.Add(this.gbUseLuck);
            this.splitContainer1.Panel1.Controls.Add(this.gbRollingSystem);
            this.splitContainer1.Panel1.MouseHover += new System.EventHandler(this.splitContainer1_Panel1_MouseHover);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.rtxtInfo);
            this.splitContainer1.Size = new System.Drawing.Size(825, 514);
            this.splitContainer1.SplitterDistance = 551;
            this.splitContainer1.TabIndex = 2;
            // 
            // gbToHitBonusFromBehind
            // 
            this.gbToHitBonusFromBehind.Controls.Add(this.rbtnPlusOneToHitFromBehind);
            this.gbToHitBonusFromBehind.Controls.Add(this.rbtnPlusTwoToHitFromBehind);
            this.gbToHitBonusFromBehind.Controls.Add(this.rbtnPlusThreeToHitFromBehind);
            this.gbToHitBonusFromBehind.Controls.Add(this.rbtnPlusFourToHitFromBehind);
            this.gbToHitBonusFromBehind.Location = new System.Drawing.Point(282, 12);
            this.gbToHitBonusFromBehind.Name = "gbToHitBonusFromBehind";
            this.gbToHitBonusFromBehind.Size = new System.Drawing.Size(158, 118);
            this.gbToHitBonusFromBehind.TabIndex = 2;
            this.gbToHitBonusFromBehind.TabStop = false;
            this.gbToHitBonusFromBehind.Text = "To Hit Bonus From Behind";
            this.gbToHitBonusFromBehind.MouseHover += new System.EventHandler(this.gbToHitBonusFromBehind_MouseHover);
            // 
            // rbtnPlusOneToHitFromBehind
            // 
            this.rbtnPlusOneToHitFromBehind.AutoSize = true;
            this.rbtnPlusOneToHitFromBehind.Location = new System.Drawing.Point(11, 19);
            this.rbtnPlusOneToHitFromBehind.Name = "rbtnPlusOneToHitFromBehind";
            this.rbtnPlusOneToHitFromBehind.Size = new System.Drawing.Size(121, 17);
            this.rbtnPlusOneToHitFromBehind.TabIndex = 0;
            this.rbtnPlusOneToHitFromBehind.TabStop = true;
            this.rbtnPlusOneToHitFromBehind.Text = "+1 to hit from behind";
            this.rbtnPlusOneToHitFromBehind.UseVisualStyleBackColor = true;
            this.rbtnPlusOneToHitFromBehind.CheckedChanged += new System.EventHandler(this.rbtnPlusOneToHitFromBehind_CheckedChanged);
            this.rbtnPlusOneToHitFromBehind.MouseHover += new System.EventHandler(this.rbtnPlusOneToHitFromBehind_MouseHover);
            // 
            // rbtnPlusTwoToHitFromBehind
            // 
            this.rbtnPlusTwoToHitFromBehind.AutoSize = true;
            this.rbtnPlusTwoToHitFromBehind.Location = new System.Drawing.Point(11, 42);
            this.rbtnPlusTwoToHitFromBehind.Name = "rbtnPlusTwoToHitFromBehind";
            this.rbtnPlusTwoToHitFromBehind.Size = new System.Drawing.Size(121, 17);
            this.rbtnPlusTwoToHitFromBehind.TabIndex = 1;
            this.rbtnPlusTwoToHitFromBehind.TabStop = true;
            this.rbtnPlusTwoToHitFromBehind.Text = "+2 to hit from behind";
            this.rbtnPlusTwoToHitFromBehind.UseVisualStyleBackColor = true;
            this.rbtnPlusTwoToHitFromBehind.CheckedChanged += new System.EventHandler(this.rbtnPlusTwoToHitFromBehind_CheckedChanged);
            this.rbtnPlusTwoToHitFromBehind.MouseHover += new System.EventHandler(this.rbtnPlusTwoToHitFromBehind_MouseHover);
            // 
            // rbtnPlusThreeToHitFromBehind
            // 
            this.rbtnPlusThreeToHitFromBehind.AutoSize = true;
            this.rbtnPlusThreeToHitFromBehind.Location = new System.Drawing.Point(11, 65);
            this.rbtnPlusThreeToHitFromBehind.Name = "rbtnPlusThreeToHitFromBehind";
            this.rbtnPlusThreeToHitFromBehind.Size = new System.Drawing.Size(121, 17);
            this.rbtnPlusThreeToHitFromBehind.TabIndex = 2;
            this.rbtnPlusThreeToHitFromBehind.TabStop = true;
            this.rbtnPlusThreeToHitFromBehind.Text = "+3 to hit from behind";
            this.rbtnPlusThreeToHitFromBehind.UseVisualStyleBackColor = true;
            this.rbtnPlusThreeToHitFromBehind.CheckedChanged += new System.EventHandler(this.rbtnPlusThreeToHitFromBehind_CheckedChanged);
            this.rbtnPlusThreeToHitFromBehind.MouseHover += new System.EventHandler(this.rbtnPlusThreeToHitFromBehind_MouseHover);
            // 
            // rbtnPlusFourToHitFromBehind
            // 
            this.rbtnPlusFourToHitFromBehind.AutoSize = true;
            this.rbtnPlusFourToHitFromBehind.Location = new System.Drawing.Point(11, 88);
            this.rbtnPlusFourToHitFromBehind.Name = "rbtnPlusFourToHitFromBehind";
            this.rbtnPlusFourToHitFromBehind.Size = new System.Drawing.Size(121, 17);
            this.rbtnPlusFourToHitFromBehind.TabIndex = 3;
            this.rbtnPlusFourToHitFromBehind.TabStop = true;
            this.rbtnPlusFourToHitFromBehind.Text = "+4 to hit from behind";
            this.rbtnPlusFourToHitFromBehind.UseVisualStyleBackColor = true;
            this.rbtnPlusFourToHitFromBehind.CheckedChanged += new System.EventHandler(this.rbtnPlusFourToHitFromBehind_CheckedChanged);
            this.rbtnPlusFourToHitFromBehind.MouseHover += new System.EventHandler(this.rbtnPlusFourToHitFromBehind_MouseHover);
            // 
            // gbArmorClassDisplay
            // 
            this.gbArmorClassDisplay.Controls.Add(this.rbtnDescendingAC);
            this.gbArmorClassDisplay.Controls.Add(this.rbtnAscendingAC);
            this.gbArmorClassDisplay.Location = new System.Drawing.Point(147, 12);
            this.gbArmorClassDisplay.Name = "gbArmorClassDisplay";
            this.gbArmorClassDisplay.Size = new System.Drawing.Size(129, 64);
            this.gbArmorClassDisplay.TabIndex = 1;
            this.gbArmorClassDisplay.TabStop = false;
            this.gbArmorClassDisplay.Text = "Armor Class Shown";
            this.gbArmorClassDisplay.MouseHover += new System.EventHandler(this.gbArmorClassDisplay_MouseHover);
            // 
            // rbtnDescendingAC
            // 
            this.rbtnDescendingAC.AutoSize = true;
            this.rbtnDescendingAC.Location = new System.Drawing.Point(11, 38);
            this.rbtnDescendingAC.Name = "rbtnDescendingAC";
            this.rbtnDescendingAC.Size = new System.Drawing.Size(82, 17);
            this.rbtnDescendingAC.TabIndex = 1;
            this.rbtnDescendingAC.TabStop = true;
            this.rbtnDescendingAC.Text = "Descending";
            this.rbtnDescendingAC.UseVisualStyleBackColor = true;
            this.rbtnDescendingAC.CheckedChanged += new System.EventHandler(this.rbtnDescendingAC_CheckedChanged);
            this.rbtnDescendingAC.MouseHover += new System.EventHandler(this.rbtnDescendingAC_MouseHover);
            // 
            // rbtnAscendingAC
            // 
            this.rbtnAscendingAC.AutoSize = true;
            this.rbtnAscendingAC.Location = new System.Drawing.Point(11, 18);
            this.rbtnAscendingAC.Name = "rbtnAscendingAC";
            this.rbtnAscendingAC.Size = new System.Drawing.Size(75, 17);
            this.rbtnAscendingAC.TabIndex = 0;
            this.rbtnAscendingAC.TabStop = true;
            this.rbtnAscendingAC.Text = "Ascending";
            this.rbtnAscendingAC.UseVisualStyleBackColor = true;
            this.rbtnAscendingAC.CheckedChanged += new System.EventHandler(this.rbtnAscendingAC_CheckedChanged);
            this.rbtnAscendingAC.MouseHover += new System.EventHandler(this.rbtnAscendingAC_MouseHover);

            // gbUseLuck
            // 
            this.gbUseLuck.Controls.Add(this.rbtnUseLuck);
            this.gbUseLuck.Controls.Add(this.rbtnDoNotUseLuck);
            this.gbUseLuck.Location = new System.Drawing.Point(12, 86);
            this.gbUseLuck.Name = "gbUseLuck";
            this.gbUseLuck.Size = new System.Drawing.Size(129, 64);
            this.gbUseLuck.TabIndex = 1;
            this.gbUseLuck.TabStop = false;
            this.gbUseLuck.Text = "Luck";
            this.gbUseLuck.MouseHover += new System.EventHandler(this.gbUseLuck_MouseHover);
            //

            // rbtnUseLuck
            // 
            this.rbtnUseLuck.AutoSize = true;
            this.rbtnUseLuck.Location = new System.Drawing.Point(11, 38);
            this.rbtnUseLuck.Name = "rbtnUseLuck";
            this.rbtnUseLuck.Size = new System.Drawing.Size(82, 17);
            this.rbtnUseLuck.TabIndex = 1;
            this.rbtnUseLuck.TabStop = true;
            this.rbtnUseLuck.Text = "Use Luck";
            this.rbtnUseLuck.UseVisualStyleBackColor = true;
            this.rbtnUseLuck.CheckedChanged += new System.EventHandler(this.rbtnUseLuck_CheckedChanged);
            this.rbtnUseLuck.MouseHover += new System.EventHandler(this.rbtnUseLuck_MouseHover);
            // 
            // rbtnDoNotUseLuck
            // 
            this.rbtnDoNotUseLuck.AutoSize = true;
            this.rbtnDoNotUseLuck.Location = new System.Drawing.Point(11, 18);
            this.rbtnDoNotUseLuck.Name = "rbtnDoNotUseLuck";
            this.rbtnDoNotUseLuck.Size = new System.Drawing.Size(75, 17);
            this.rbtnDoNotUseLuck.TabIndex = 0;
            this.rbtnDoNotUseLuck.TabStop = true;
            this.rbtnDoNotUseLuck.Text = "Do not use Luck";
            this.rbtnDoNotUseLuck.UseVisualStyleBackColor = true;
            this.rbtnDoNotUseLuck.CheckedChanged += new System.EventHandler(this.rbtnDoNotUseLuck_CheckedChanged);
            this.rbtnDoNotUseLuck.MouseHover += new System.EventHandler(this.rbtnDoNotUseLuck_MouseHover);

            // gbRollingSystem
            // 
            this.gbRollingSystem.Controls.Add(this.rbtnUse3d6);
            this.gbRollingSystem.Controls.Add(this.rbtnUse6Plusd12);
            this.gbRollingSystem.Location = new System.Drawing.Point(147, 86);
            this.gbRollingSystem.Name = "gbRollingSystem";
            this.gbRollingSystem.Size = new System.Drawing.Size(129, 64);
            this.gbRollingSystem.TabIndex = 1;
            this.gbRollingSystem.TabStop = false;
            this.gbRollingSystem.Text = "Attribute System";
            this.gbRollingSystem.MouseHover += new System.EventHandler(this.gbRollingSystem_MouseHover);
            //

            // rbtnUse3d6
            // 
            this.rbtnUse3d6.AutoSize = true;
            this.rbtnUse3d6.Location = new System.Drawing.Point(11, 38);
            this.rbtnUse3d6.Name = "rbtnUseLuck";
            this.rbtnUse3d6.Size = new System.Drawing.Size(82, 17);
            this.rbtnUse3d6.TabIndex = 1;
            this.rbtnUse3d6.TabStop = true;
            this.rbtnUse3d6.Text = "Use 3d6";
            this.rbtnUse3d6.UseVisualStyleBackColor = true;
            this.rbtnUse3d6.CheckedChanged += new System.EventHandler(this.rbtnUse3d6_CheckedChanged);
            this.rbtnUse3d6.MouseHover += new System.EventHandler(this.rbtnUse3d6_MouseHover);

            // rbtnUse6Plusd12
            this.rbtnUse6Plusd12.AutoSize = true;
            this.rbtnUse6Plusd12.Location = new System.Drawing.Point(11, 18);
            this.rbtnUse6Plusd12.Name = "rbtnUse6Plusd12";
            this.rbtnUse6Plusd12.Size = new System.Drawing.Size(75, 17);
            this.rbtnUse6Plusd12.TabIndex = 0;
            this.rbtnUse6Plusd12.TabStop = true;
            this.rbtnUse6Plusd12.Text = "Use 6 + d12";
            this.rbtnUse6Plusd12.UseVisualStyleBackColor = true;
            this.rbtnUse6Plusd12.CheckedChanged += new System.EventHandler(this.rbtnUse6Plusd12_CheckedChanged);
            this.rbtnUse6Plusd12.MouseHover += new System.EventHandler(this.rbtnUse6Plusd12_MouseHover);

            // 
            // RulesEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6f, 14f);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(825, 514);
            this.Controls.Add(this.splitContainer1);
            this.Name = "RulesEditor";
            this.Text = "RulesEditor";
            this.gbMoveDiagonalCost.ResumeLayout(false);
            this.gbMoveDiagonalCost.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.gbToHitBonusFromBehind.ResumeLayout(false);
            this.gbToHitBonusFromBehind.PerformLayout();
            this.gbArmorClassDisplay.ResumeLayout(false);
            this.gbArmorClassDisplay.PerformLayout();
            this.gbUseLuck.ResumeLayout(false);
            this.gbUseLuck.PerformLayout();
            this.gbRollingSystem.ResumeLayout(false);
            this.gbRollingSystem.PerformLayout();
            this.ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.GroupBox gbMoveDiagonalCost;
        private System.Windows.Forms.RadioButton rbtnOnePointFiveSquares;
        private System.Windows.Forms.RadioButton rbtnOneSquare;
        private System.Windows.Forms.RichTextBox rtxtInfo;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.GroupBox gbArmorClassDisplay;
        private System.Windows.Forms.RadioButton rbtnDescendingAC;
        private System.Windows.Forms.RadioButton rbtnAscendingAC;
        private System.Windows.Forms.GroupBox gbToHitBonusFromBehind;
        private System.Windows.Forms.RadioButton rbtnPlusOneToHitFromBehind;
        private System.Windows.Forms.RadioButton rbtnPlusTwoToHitFromBehind;
        private System.Windows.Forms.RadioButton rbtnPlusThreeToHitFromBehind;
        private System.Windows.Forms.RadioButton rbtnPlusFourToHitFromBehind;
        private System.Windows.Forms.GroupBox gbUseLuck;
        private System.Windows.Forms.RadioButton rbtnUseLuck;
        private System.Windows.Forms.RadioButton rbtnDoNotUseLuck;
        private System.Windows.Forms.GroupBox gbRollingSystem;
        private System.Windows.Forms.RadioButton rbtnUse3d6;
        private System.Windows.Forms.RadioButton rbtnUse6Plusd12;
    }
}