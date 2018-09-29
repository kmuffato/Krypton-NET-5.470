﻿// *****************************************************************************
// BSD 3-Clause License (https://github.com/ComponentFactory/Krypton/blob/master/LICENSE)
//  © Component Factory Pty Ltd, 2006-2018, All rights reserved.
// The software and associated documentation supplied hereunder are the 
//  proprietary information of Component Factory Pty Ltd, 13 Swallows Close, 
//  Mornington, Vic 3931, Australia and are supplied subject to licence terms.
// 
//  Modifications by Peter Wagner(aka Wagnerp) & Simon Coghlan(aka Smurf-IV) 2017 - 2018. All rights reserved. (https://github.com/Wagnerp/Krypton-NET-5.470)
//  Version 4.7.0.0  www.ComponentFactory.com
// *****************************************************************************

using System.ComponentModel;
using ComponentFactory.Krypton.Toolkit;

namespace ComponentFactory.Krypton.Navigator
{
	/// <summary>
	/// Storage and mapping for primary header.
	/// </summary>
	public class HeaderGroupMappingPrimary : HeaderGroupMappingBase
    {
        #region Static Fields
        private const string _defaultHeading = "(Empty)";
		#endregion

        #region Identity
        /// <summary>
        /// Initialize a new instance of the HeaderGroupMappingPrimary class.
        /// </summary>
        /// <param name="navigator">Reference to owning navogator instance.</param>
        /// <param name="needPaint">Delegate for notifying paint requests.</param>
        public HeaderGroupMappingPrimary(KryptonNavigator navigator,
                                         NeedPaintHandler needPaint)
            : base(navigator, needPaint)
        {
        }
        #endregion

		#region Default Values
		/// <summary>
		/// Gets the default heading value.
		/// </summary>
		/// <returns>String reference.</returns>
		protected override string GetHeadingDefault()
		{
			return _defaultHeading;
		}

		/// <summary>
		/// Gets the default description value.
		/// </summary>
		/// <returns>String reference.</returns>
		protected override string GetDescriptionDefault()
		{
			return string.Empty;
		}

        /// <summary>
        /// Gets the default image mapping value.
        /// </summary>
        /// <returns>Image mapping enumeration.</returns>
        protected override MapKryptonPageImage GetMapImageDefault()
        {
            return MapKryptonPageImage.SmallMedium;
        }

        /// <summary>
        /// Gets the default heading mapping value.
        /// </summary>
        /// <returns>Text mapping enumeration.</returns>
        protected override MapKryptonPageText GetMapHeadingDefault()
        {
            return MapKryptonPageText.TitleText;
        }

        /// <summary>
        /// Gets the default description mapping value.
        /// </summary>
        /// <returns>Text mapping enumeration.</returns>
        protected override MapKryptonPageText GetMapDescriptionDefault()
        {
            return MapKryptonPageText.None;
        }
        #endregion

        #region MapImage
        /// <summary>
        /// Gets and sets the mapping used for the Image property.
        /// </summary>
        [DefaultValue(typeof(MapKryptonPageImage), "Small - Medium")]
        public override MapKryptonPageImage MapImage
        {
            get => base.MapImage;
            set => base.MapImage = value;
        }
        #endregion

        #region MapHeading
        /// <summary>
        /// Gets and sets the mapping used for the Heading property.
        /// </summary>
        [DefaultValue(typeof(MapKryptonPageText), "Title - Text")]
        public override MapKryptonPageText MapHeading
        {
            get => base.MapHeading;
            set => base.MapHeading = value;
        }
        #endregion

        #region MapDescription
        /// <summary>
        /// Gets and sets the mapping used for the Description property.
        /// </summary>
        [DefaultValue(typeof(MapKryptonPageText), "None (Empty string)")]
        public override MapKryptonPageText MapDescription
        {
            get => base.MapDescription;
            set => base.MapDescription = value;
        }
        #endregion
    }
}
