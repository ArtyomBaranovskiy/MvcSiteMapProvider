﻿using System;
using System.Reflection;

namespace MvcSiteMapProvider.Core.Reflection
{
    /// <summary>
    /// MvcSiteMapNodeAttributeDefinition for Action
    /// </summary>
    public class MvcSiteMapNodeAttributeDefinitionForAction
        : IMvcSiteMapNodeAttributeDefinition
    {
        /// <summary>
        /// Gets or sets the site map node attribute.
        /// </summary>
        /// <value>The site map node attribute.</value>
        public IMvcSiteMapNodeAttribute SiteMapNodeAttribute { get; set; }

        /// <summary>
        /// Gets or sets the type of the controller.
        /// </summary>
        /// <value>The type of the controller.</value>
        public Type ControllerType { get; set; }

        /// <summary>
        /// Gets or sets the action method info.
        /// </summary>
        /// <value>The action method info.</value>
        public MethodInfo ActionMethodInfo { get; set; }
    }
}