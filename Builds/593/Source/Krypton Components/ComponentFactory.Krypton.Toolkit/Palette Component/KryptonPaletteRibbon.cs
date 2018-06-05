﻿// *****************************************************************************
// BSD 3-Clause License (https://github.com/ComponentFactory/Krypton/blob/master/LICENSE)
//  © Component Factory Pty Ltd, 2006-2018, All rights reserved.
// The software and associated documentation supplied hereunder are the 
//  proprietary information of Component Factory Pty Ltd, 13 Swallows Close, 
//  Mornington, Vic 3931, Australia and are supplied subject to licence terms.
// 
//  Modifications by Peter Wagner(aka Wagnerp) & Simon Coghlan(aka Smurf-IV) 2017 - 2018. All rights reserved. (https://github.com/Wagnerp/Krypton-NET-4.7)
//  Version 4.7.0.0  www.ComponentFactory.com
// *****************************************************************************

using System.ComponentModel;
using System.Diagnostics;

namespace ComponentFactory.Krypton.Toolkit
{
    /// <summary>
    /// Settings associated with ribbon control.
    /// </summary>
    public class KryptonPaletteRibbon : Storage
    {
        #region Instance Fields
        private PaletteRedirect _redirect;
        private readonly PaletteRibbonBackInheritRedirect _ribbonAppMenuOuterInherit;
        private readonly PaletteRibbonBackInheritRedirect _ribbonAppMenuInnerInherit;
        private readonly PaletteRibbonBackInheritRedirect _ribbonAppMenuDocsInherit;
        private readonly PaletteRibbonTextInheritRedirect _ribbonAppMenuDocsTitleInherit;
        private readonly PaletteRibbonTextInheritRedirect _ribbonAppMenuDocsEntryInherit;
        private readonly PaletteRibbonGeneralInheritRedirect _ribbonGeneralRedirect;
        private readonly PaletteRibbonBackInheritRedirect _ribbonQATFullRedirect;
        private readonly PaletteRibbonBackInheritRedirect _ribbonQATOverRedirect;
        private readonly PaletteRibbonBackInheritRedirect _ribbonGalleryBackRedirect;
        private readonly PaletteRibbonBackInheritRedirect _ribbonGalleryBorderRedirect;

        private readonly PaletteRibbonBack _ribbonAppMenuInner;
        private readonly PaletteRibbonBack _ribbonAppMenuOuter;
        private readonly PaletteRibbonBack _ribbonAppMenuDocs;
        private readonly PaletteRibbonText _ribbonAppMenuDocsTitle;
        private readonly PaletteRibbonText _ribbonAppMenuDocsEntry;
        private readonly PaletteRibbonBack _ribbonGalleryBack;
        private readonly PaletteRibbonBack _ribbonGalleryBorder;
        #endregion

        #region Identity
        /// <summary>
        /// Initialize a new instance of the KryptonPaletteRibbon class.
        /// </summary>
        /// <param name="redirect">Redirector to inherit values from.</param>
        /// <param name="needPaint">Delegate for notifying paint requests.</param>
        internal KryptonPaletteRibbon(PaletteRedirect redirect,
                                      NeedPaintHandler needPaint)
        {
            Debug.Assert(redirect != null);

            // Store incoming reference
            _redirect = redirect;

            // Create redirectors
            _ribbonGeneralRedirect = new PaletteRibbonGeneralInheritRedirect(redirect);
            _ribbonAppMenuInnerInherit = new PaletteRibbonBackInheritRedirect(redirect, PaletteRibbonBackStyle.RibbonAppMenuInner);
            _ribbonAppMenuOuterInherit = new PaletteRibbonBackInheritRedirect(redirect, PaletteRibbonBackStyle.RibbonAppMenuOuter);
            _ribbonAppMenuDocsInherit = new PaletteRibbonBackInheritRedirect(redirect, PaletteRibbonBackStyle.RibbonAppMenuDocs);
            _ribbonAppMenuDocsTitleInherit = new PaletteRibbonTextInheritRedirect(redirect, PaletteRibbonTextStyle.RibbonAppMenuDocsTitle);
            _ribbonAppMenuDocsEntryInherit = new PaletteRibbonTextInheritRedirect(redirect, PaletteRibbonTextStyle.RibbonAppMenuDocsEntry);
            _ribbonQATFullRedirect = new PaletteRibbonBackInheritRedirect(redirect, PaletteRibbonBackStyle.RibbonQATFullbar);
            _ribbonQATOverRedirect = new PaletteRibbonBackInheritRedirect(redirect, PaletteRibbonBackStyle.RibbonQATOverflow);
            _ribbonGalleryBackRedirect = new PaletteRibbonBackInheritRedirect(redirect, PaletteRibbonBackStyle.RibbonGalleryBack);
            _ribbonGalleryBorderRedirect = new PaletteRibbonBackInheritRedirect(redirect, PaletteRibbonBackStyle.RibbonGalleryBorder);

            // Create palettes
            RibbonGeneral = new PaletteRibbonGeneral(_ribbonGeneralRedirect, needPaint);
            RibbonAppButton = new KryptonPaletteRibbonAppButton(redirect, needPaint);
            _ribbonAppMenuInner = new PaletteRibbonBack(_ribbonAppMenuInnerInherit, needPaint);
            _ribbonAppMenuOuter = new PaletteRibbonBack(_ribbonAppMenuOuterInherit, needPaint);
            _ribbonAppMenuDocs = new PaletteRibbonBack(_ribbonAppMenuDocsInherit, needPaint);
            _ribbonAppMenuDocsTitle = new PaletteRibbonText(_ribbonAppMenuDocsTitleInherit, needPaint);
            _ribbonAppMenuDocsEntry = new PaletteRibbonText(_ribbonAppMenuDocsEntryInherit, needPaint);
            RibbonGroupArea = new KryptonPaletteRibbonGroupArea(redirect, needPaint);
            RibbonGroupButtonText = new KryptonPaletteRibbonGroupButtonText(redirect, needPaint);
            RibbonGroupCheckBoxText = new KryptonPaletteRibbonGroupCheckBoxText(redirect, needPaint);
            RibbonGroupNormalBorder = new KryptonPaletteRibbonGroupNormalBorder(redirect, needPaint);
            RibbonGroupNormalTitle = new KryptonPaletteRibbonGroupNormalTitle(redirect, needPaint);
            RibbonGroupCollapsedBorder = new KryptonPaletteRibbonGroupCollapsedBorder(redirect, needPaint);
            RibbonGroupCollapsedBack = new KryptonPaletteRibbonGroupCollapsedBack(redirect, needPaint);
            RibbonGroupCollapsedFrameBorder = new KryptonPaletteRibbonGroupCollapsedFrameBorder(redirect, needPaint);
            RibbonGroupCollapsedFrameBack = new KryptonPaletteRibbonGroupCollapsedFrameBack(redirect, needPaint);
            RibbonGroupCollapsedText = new KryptonPaletteRibbonGroupCollapsedText(redirect, needPaint);
            RibbonGroupRadioButtonText = new KryptonPaletteRibbonGroupRadioButtonText(redirect, needPaint);
            RibbonGroupLabelText = new KryptonPaletteRibbonGroupLabelText(redirect, needPaint);
            RibbonQATFullbar = new PaletteRibbonBack(_ribbonQATFullRedirect, needPaint);
            RibbonQATMinibar = new KryptonPaletteRibbonQATMinibar(redirect, needPaint);
            RibbonQATOverflow = new PaletteRibbonBack(_ribbonQATOverRedirect, needPaint);
            RibbonTab = new KryptonPaletteRibbonTab(redirect, needPaint);
            _ribbonGalleryBack = new PaletteRibbonBack(_ribbonGalleryBackRedirect, needPaint);
            _ribbonGalleryBorder = new PaletteRibbonBack(_ribbonGalleryBorderRedirect, needPaint);
        }

        /// <summary>
        /// Gets a value indicating if all values are default.
        /// </summary>
        public override bool IsDefault => RibbonAppButton.IsDefault &&
                                          RibbonAppMenuOuter.IsDefault &&
                                          RibbonAppMenuInner.IsDefault &&
                                          RibbonAppMenuDocs.IsDefault &&
                                          RibbonAppMenuDocsTitle.IsDefault &&
                                          RibbonAppMenuDocsEntry.IsDefault &&
                                          RibbonGeneral.IsDefault &&
                                          RibbonGroupArea.IsDefault &&
                                          RibbonGroupButtonText.IsDefault &&
                                          RibbonGroupCheckBoxText.IsDefault &&
                                          RibbonGroupNormalBorder.IsDefault &&
                                          RibbonGroupNormalTitle.IsDefault &&
                                          RibbonGroupCollapsedBorder.IsDefault &&
                                          RibbonGroupCollapsedBack.IsDefault &&
                                          RibbonGroupCollapsedFrameBorder.IsDefault &&
                                          RibbonGroupCollapsedFrameBack.IsDefault &&
                                          RibbonGroupCollapsedText.IsDefault &&
                                          RibbonGroupLabelText.IsDefault &&
                                          RibbonGroupRadioButtonText.IsDefault &&
                                          RibbonQATFullbar.IsDefault &&
                                          RibbonQATMinibar.IsDefault &&
                                          RibbonTab.IsDefault &&
                                          RibbonGalleryBack.IsDefault &&
                                          RibbonGalleryBorder.IsDefault;

        #endregion

        #region PopulateFromBase
        /// <summary>
        /// Populate values from the base palette.
        /// </summary>
        public void PopulateFromBase()
        {
            RibbonAppButton.PopulateFromBase();
            RibbonAppMenuOuter.PopulateFromBase(PaletteState.Normal);
            RibbonAppMenuInner.PopulateFromBase(PaletteState.Normal);
            RibbonAppMenuDocs.PopulateFromBase(PaletteState.Normal);
            RibbonAppMenuDocsTitle.PopulateFromBase(PaletteState.Normal);
            RibbonAppMenuDocsEntry.PopulateFromBase(PaletteState.Normal);
            RibbonGeneral.PopulateFromBase();
            RibbonGroupArea.PopulateFromBase();
            RibbonGroupButtonText.PopulateFromBase();
            RibbonGroupCheckBoxText.PopulateFromBase();
            RibbonGroupNormalBorder.PopulateFromBase();
            RibbonGroupNormalTitle.PopulateFromBase();
            RibbonGroupCollapsedBack.PopulateFromBase();
            RibbonGroupCollapsedBorder.PopulateFromBase();
            RibbonGroupCollapsedFrameBorder.PopulateFromBase();
            RibbonGroupCollapsedFrameBack.PopulateFromBase();
            RibbonGroupCollapsedText.PopulateFromBase();
            RibbonGroupRadioButtonText.PopulateFromBase();
            RibbonGroupLabelText.PopulateFromBase();
            RibbonQATFullbar.PopulateFromBase(PaletteState.Normal);
            RibbonQATMinibar.PopulateFromBase();
            RibbonQATOverflow.PopulateFromBase(PaletteState.Normal);
            RibbonTab.PopulateFromBase();
            RibbonGalleryBack.PopulateFromBase(PaletteState.Normal);
            RibbonGalleryBorder.PopulateFromBase(PaletteState.Normal);
        }
        #endregion

        #region RibbonAppButton
        /// <summary>
        /// Get access to the application button tab settings.
        /// </summary>
        [KryptonPersist]
        [Category("Visuals")]
        [Description("Ribbon application button specific settings.")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public KryptonPaletteRibbonAppButton RibbonAppButton { get; }

        private bool ShouldSerializeRibbonAppButton()
        {
            return !RibbonAppButton.IsDefault;
        }
        #endregion

        #region RibbonAppMenuOuter
        /// <summary>
        /// Gets access to the application button menu outer palette details.
        /// </summary>
        [KryptonPersist]
        [Category("Visuals")]
        [Description("Overrides for defining application button menu outer appearance.")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public virtual PaletteRibbonBack RibbonAppMenuOuter => _ribbonAppMenuOuter;

        private bool ShouldSerializeRibbonAppMenuOuter()
        {
            return !_ribbonAppMenuOuter.IsDefault;
        }
        #endregion

        #region RibbonAppMenuInner
        /// <summary>
        /// Gets access to the application button menu inner palette details.
        /// </summary>
        [KryptonPersist]
        [Category("Visuals")]
        [Description("Overrides for defining application button menu inner appearance.")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public virtual PaletteRibbonBack RibbonAppMenuInner => _ribbonAppMenuInner;

        private bool ShouldSerializeRibbonAppMenuInner()
        {
            return !_ribbonAppMenuInner.IsDefault;
        }
        #endregion

        #region RibbonAppMenuDocs
        /// <summary>
        /// Gets access to the application button menu recent docs palette details.
        /// </summary>
        [KryptonPersist]
        [Category("Visuals")]
        [Description("Overrides for defining application button menu recent docs appearance.")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public virtual PaletteRibbonBack RibbonAppMenuDocs => _ribbonAppMenuDocs;

        private bool ShouldSerializeRibbonAppMenuDocs()
        {
            return !_ribbonAppMenuDocs.IsDefault;
        }
        #endregion

        #region RibbonAppMenuDocsTitle
        /// <summary>
        /// Gets access to the application button menu recent documents title.
        /// </summary>
        [KryptonPersist]
        [Category("Visuals")]
        [Description("Overrides for defining application button menu recent documents title.")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public virtual PaletteRibbonText RibbonAppMenuDocsTitle => _ribbonAppMenuDocsTitle;

        private bool ShouldSerializeRibbonAppMenuDocsTitle()
        {
            return !_ribbonAppMenuDocsTitle.IsDefault;
        }
        #endregion

        #region RibbonAppMenuDocsEntry
        /// <summary>
        /// Gets access to the application button menu recent documents entry.
        /// </summary>
        [KryptonPersist]
        [Category("Visuals")]
        [Description("Overrides for defining application button menu recent documents entry.")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public virtual PaletteRibbonText RibbonAppMenuDocsEntry => _ribbonAppMenuDocsEntry;

        private bool ShouldSerializeRibbonAppMenuDocsEntry()
        {
            return !_ribbonAppMenuDocsEntry.IsDefault;
        }
        #endregion

        #region RibbonGeneral
        /// <summary>
        /// Get access to the general ribbon settings.
        /// </summary>
        [KryptonPersist]
        [Category("Visuals")]
        [Description("Ribbon general settings.")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public PaletteRibbonGeneral RibbonGeneral { get; }

        private bool ShouldSerializeRibbonGeneral()
        {
            return !RibbonGeneral.IsDefault;
        }
        #endregion

        #region RibbonGroupArea
        /// <summary>
        /// Get access to the ribbon group area settings.
        /// </summary>
        [KryptonPersist]
        [Category("Visuals")]
        [Description("Ribbon group area specific settings.")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public KryptonPaletteRibbonGroupArea RibbonGroupArea { get; }

        private bool ShouldSerializeRibbonGroupArea()
        {
            return !RibbonGroupArea.IsDefault;
        }
        #endregion

        #region RibbonGroupButtonText
        /// <summary>
        /// Get access to the ribbon group button text settings.
        /// </summary>
        [KryptonPersist]
        [Category("Visuals")]
        [Description("Ribbon group button text specific settings.")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public KryptonPaletteRibbonGroupButtonText RibbonGroupButtonText { get; }

        private bool ShouldSerializeRibbonGroupButtonText()
        {
            return !RibbonGroupButtonText.IsDefault;
        }
        #endregion

        #region RibbonGroupCheckBoxText
        /// <summary>
        /// Get access to the ribbon group check box text settings.
        /// </summary>
        [KryptonPersist]
        [Category("Visuals")]
        [Description("Ribbon group check box text specific settings.")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public KryptonPaletteRibbonGroupCheckBoxText RibbonGroupCheckBoxText { get; }

        private bool ShouldSerializeRibbonGroupCheckBoxText()
        {
            return !RibbonGroupCheckBoxText.IsDefault;
        }
        #endregion

        #region RibbonGroupNormalBorder
        /// <summary>
        /// Get access to the ribbon group normal border settings.
        /// </summary>
        [KryptonPersist]
        [Category("Visuals")]
        [Description("Ribbon group normal border specific settings.")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public KryptonPaletteRibbonGroupNormalBorder RibbonGroupNormalBorder { get; }

        private bool ShouldSerializeRibbonGroupNormalBorder()
        {
            return !RibbonGroupNormalBorder.IsDefault;
        }
        #endregion

        #region RibbonGroupNormalTitle
        /// <summary>
        /// Get access to the ribbon group normal title settings.
        /// </summary>
        [KryptonPersist]
        [Category("Visuals")]
        [Description("Ribbon group normal title specific settings.")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public KryptonPaletteRibbonGroupNormalTitle RibbonGroupNormalTitle { get; }

        private bool ShouldSerializeRibbonGroupNormalTitle()
        {
            return !RibbonGroupNormalTitle.IsDefault;
        }
        #endregion

        #region RibbonGroupCollapsedBorder
        /// <summary>
        /// Get access to the ribbon group collapsed border settings.
        /// </summary>
        [KryptonPersist]
        [Category("Visuals")]
        [Description("Ribbon group collapsed border specific settings.")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public KryptonPaletteRibbonGroupCollapsedBorder RibbonGroupCollapsedBorder { get; }

        private bool ShouldSerializeRibbonGroupCollapsedBorder()
        {
            return !RibbonGroupCollapsedBorder.IsDefault;
        }
        #endregion

        #region RibbonGroupCollapsedBack
        /// <summary>
        /// Get access to the ribbon group collapsed background settings.
        /// </summary>
        [KryptonPersist]
        [Category("Visuals")]
        [Description("Ribbon group collapsed background specific settings.")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public KryptonPaletteRibbonGroupCollapsedBack RibbonGroupCollapsedBack { get; }

        private bool ShouldSerializeRibbonGroupCollapsedBack()
        {
            return !RibbonGroupCollapsedBack.IsDefault;
        }
        #endregion

        #region RibbonGroupCollapsedFrameBorder
        /// <summary>
        /// Get access to the ribbon group collapsed frame border settings.
        /// </summary>
        [KryptonPersist]
        [Category("Visuals")]
        [Description("Ribbon group collapsed frame border specific settings.")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public KryptonPaletteRibbonGroupCollapsedFrameBorder RibbonGroupCollapsedFrameBorder { get; }

        private bool ShouldSerializeRibbonGroupCollapsedFrameBorder()
        {
            return !RibbonGroupCollapsedFrameBorder.IsDefault;
        }
        #endregion

        #region RibbonGroupCollapsedFrameBack
        /// <summary>
        /// Get access to the ribbon group collapsed frame background settings.
        /// </summary>
        [KryptonPersist]
        [Category("Visuals")]
        [Description("Ribbon group collapsed frame background specific settings.")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public KryptonPaletteRibbonGroupCollapsedFrameBack RibbonGroupCollapsedFrameBack { get; }

        private bool ShouldSerializeRibbonGroupCollapsedFrameBack()
        {
            return !RibbonGroupCollapsedFrameBack.IsDefault;
        }
        #endregion

        #region RibbonGroupCollapsedText
        /// <summary>
        /// Get access to the ribbon group collapsed text settings.
        /// </summary>
        [KryptonPersist]
        [Category("Visuals")]
        [Description("Ribbon group collapsed text specific settings.")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public KryptonPaletteRibbonGroupCollapsedText RibbonGroupCollapsedText { get; }

        private bool ShouldSerializeRibbonGroupCollapsedText()
        {
            return !RibbonGroupCollapsedText.IsDefault;
        }
        #endregion

        #region RibbonGroupLabelText
        /// <summary>
        /// Get access to the ribbon group label text settings.
        /// </summary>
        [KryptonPersist]
        [Category("Visuals")]
        [Description("Ribbon group label text specific settings.")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public KryptonPaletteRibbonGroupLabelText RibbonGroupLabelText { get; }

        private bool ShouldSerializeRibbonGroupLabelText()
        {
            return !RibbonGroupLabelText.IsDefault;
        }
        #endregion

        #region RibbonGroupRadioButtonText
        /// <summary>
        /// Get access to the ribbon radio button box text settings.
        /// </summary>
        [KryptonPersist]
        [Category("Visuals")]
        [Description("Ribbon group radio button text specific settings.")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public KryptonPaletteRibbonGroupRadioButtonText RibbonGroupRadioButtonText { get; }

        private bool ShouldSerializeRibbonGroupRadioButtonText()
        {
            return !RibbonGroupRadioButtonText.IsDefault;
        }
        #endregion

        #region RibbonQATFullbar
        /// <summary>
        /// Get access to the quick access toolbar full settings.
        /// </summary>
        [KryptonPersist]
        [Category("Visuals")]
        [Description("Ribbon quick access toolbar full settings.")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public PaletteRibbonBack RibbonQATFullbar { get; }

        private bool ShouldSerializeRibbonQATFullbar()
        {
            return !RibbonQATFullbar.IsDefault;
        }
        #endregion

        #region RibbonQATMinibar
        /// <summary>
        /// Get access to the quick access toolbar mini settings.
        /// </summary>
        [KryptonPersist]
        [Category("Visuals")]
        [Description("Ribbon quick access toolbar mini settings.")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public KryptonPaletteRibbonQATMinibar RibbonQATMinibar { get; }

        private bool ShouldSerializeRibbonQATMinibar()
        {
            return !RibbonQATMinibar.IsDefault;
        }
        #endregion

        #region RibbonQATOverflow
        /// <summary>
        /// Get access to the quick access toolbar overflow settings.
        /// </summary>
        [KryptonPersist]
        [Category("Visuals")]
        [Description("Ribbon quick access toolbar overflow settings.")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public PaletteRibbonBack RibbonQATOverflow { get; }

        private bool ShouldSerializeRibbonQATOverflow()
        {
            return !RibbonQATOverflow.IsDefault;
        }
        #endregion

        #region RibbonTab
        /// <summary>
        /// Get access to the ribbon tab settings.
        /// </summary>
        [KryptonPersist]
        [Category("Visuals")]
        [Description("Ribbon tab specific settings.")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public KryptonPaletteRibbonTab RibbonTab { get; }

        private bool ShouldSerializeRibbonTab()
        {
            return !RibbonTab.IsDefault;
        }
        #endregion

        #region RibbonGalleryBack
        /// <summary>
        /// Gets access to the ribbon gallery background palette details.
        /// </summary>
        [KryptonPersist]
        [Category("Visuals")]
        [Description("Overrides for defining ribbon gallery background appearance.")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public virtual PaletteRibbonBack RibbonGalleryBack => _ribbonGalleryBack;

        private bool ShouldSerializeRibbonGalleryBack()
        {
            return !_ribbonGalleryBack.IsDefault;
        }
        #endregion

        #region RibbonGalleryBorder
        /// <summary>
        /// Gets access to the ribbon gallery border palette details.
        /// </summary>
        [KryptonPersist]
        [Category("Visuals")]
        [Description("Overrides for defining ribbon gallery border appearance.")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public virtual PaletteRibbonBack RibbonGalleryBorder => _ribbonGalleryBorder;

        private bool ShouldSerializeRibbonGalleryBorder()
        {
            return !_ribbonGalleryBorder.IsDefault;
        }
        #endregion
    }
}
