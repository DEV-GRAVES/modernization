﻿using Microsoft.SharePoint.Client;
using OfficeDevPnP.Core.Pages;
using System;
using System.Collections.Generic;

namespace SharePointPnP.Modernization.Framework.Transform
{
    /// <summary>
    /// Information used to configure the page transformation process which applies to all types of page transformations
    /// </summary>
    public abstract class BaseTransformationInformation
    {

        #region Page Properties
        /// <summary>
        /// Source wiki/webpart page we want to transform
        /// </summary>
        public ListItem SourcePage { get; set; }

        /// <summary>
        /// Folder where the page to transform lives in
        /// </summary>
        public string Folder { get; set; }

        /// <summary>
        /// Overwrite the target page if it already exists?
        /// </summary>
        public bool Overwrite { get; set; }

        /// <summary>
        /// Configuration of the page header to apply
        /// </summary>
        public ClientSidePageHeader PageHeader { get; set; }

        /// <summary>
        /// Apply the item level page permissions on to the target page, defaults to true
        /// </summary>
        public bool KeepPageSpecificPermissions { get; set; }

        /// <summary>
        /// Copy the page metadata (if any) to the created modern client side page. Defaults to false
        /// </summary>
        public bool CopyPageMetadata { get; set; }

        /// <summary>
        /// Removes empty sections and columns to optimize screen real estate
        /// </summary>
        public bool RemoveEmptySectionsAndColumns { get; set; }
        #endregion

        #region Webpart replacement configuration
        /// <summary>
        /// If true images and videos embedded in wiki text will be transformed to actual image/video web parts, 
        /// else they'll get a placeholder and will be added as separate web parts at the end of the page
        /// </summary>
        public bool HandleWikiImagesAndVideos { get; set; }

        /// <summary>
        /// Property bag for adding properties that will be exposed to the functions and selectors in the web part mapping file.
        /// These properties are used to condition the transformation process.
        /// </summary>
        public Dictionary<string, string> MappingProperties { get; set; }
        #endregion

        #region Override properties
        /// <summary>
        /// Custom function callout that can be triggered to provide a tailored page title
        /// </summary>
        public Func<string, string> PageTitleOverride { get; set; }
        /// <summary>
        /// Custom layout transformator to be used for this page
        /// </summary>
        public Func<ClientSidePage, ILayoutTransformator> LayoutTransformatorOverride { get; set; }
        /// <summary>
        /// Custom content transformator to be used for this page
        /// </summary>
        public Func<ClientSidePage, PageTransformation, IContentTransformator> ContentTransformatorOverride { get; set; }
        #endregion

        #region General properties
        /// <summary>
        /// Disable telemetry: we use telemetry to make this tool better by sending anonymous data, but you're free to disable this
        /// </summary>
        public bool SkipTelemetry { get; set; }
        #endregion


    }
}
