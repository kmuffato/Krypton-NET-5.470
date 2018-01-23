﻿// *****************************************************************************
// 
//  © Component Factory Pty Ltd, 2006-2018. Then modifications by Peter Wagner (aka Wagnerp) & Simon Coghlan (aka Smurf-IV) 2017-2018. All rights reserved.
//	The software and associated documentation supplied hereunder are the 
//  proprietary information of Component Factory Pty Ltd, 13 Swallows Close, 
//  Mornington, Vic 3931, Australia and are supplied subject to licence terms.
// 
//  Version 4.5.0.0 	www.ComponentFactory.com
// *****************************************************************************

using System.Xml;
using ComponentFactory.Krypton.Navigator;

namespace ComponentFactory.Krypton.Workspace
{
	/// <summary>
	/// Event data for persisting extra data for a workspace cell page.
	/// </summary>
	public class PageSavingEventArgs : XmlSavingEventArgs
	{
		#region Instance Fields

	    #endregion

		#region Identity
		/// <summary>
        /// Initialize a new instance of the PageSavingEventArgs class.
		/// </summary>
        /// <param name="workspace">Reference to owning workspace control.</param>
        /// <param name="page">Reference to owning workspace cell page.</param>
        /// <param name="xmlWriter">Xml writer for persisting custom data.</param>
        public PageSavingEventArgs(KryptonWorkspace workspace,
                                   KryptonPage page,
                                   XmlWriter xmlWriter)
            : base(workspace, xmlWriter)
		{
            Page = page;
		}
		#endregion

		#region Public
		/// <summary>
        /// Gets the workspace cell page reference.
		/// </summary>
        public KryptonPage Page { get; }

	    #endregion
	}
}
