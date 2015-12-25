﻿using System;
using CacheManager.Web;

namespace CacheManager.Core
{
    /// <summary>
    /// Extensions for the configuration builder specific to System.Runtime.Caching cache handle.
    /// </summary>
    public static class ConfigurationBuilderExtensions
    {
#pragma warning disable SA1625
        /// <summary>
        /// Adds a <see cref="SystemWebCacheHandle{TCacheValue}" /> using a <see cref="System.Web.Caching.Cache"/>.
        /// </summary>
        /// <param name="part">The builder part.</param>
        /// <returns>The builder part.</returns>
        public static ConfigurationBuilderCacheHandlePart WithSystemWebCacheHandle(this ConfigurationBuilderCachePart part)
            => WithSystemWebCacheHandle(part, Guid.NewGuid().ToString("N"));

        /// <summary>
        /// Adds a <see cref="SystemWebCacheHandle{TCacheValue}" /> using a <see cref="System.Web.Caching.Cache"/> instance with the given <paramref name="instanceName"/>.
        /// The named cache instance can be configured via <c>app/web.config</c> <c>system.runtime.caching</c> section.
        /// </summary>
        /// <param name="part">The builder part.</param>
        /// <param name="instanceName">The name to be used for the <see cref="System.Web.Caching.Cache"/> instance.</param>
        /// <returns>The builder part.</returns>
        /// <exception cref="ArgumentNullException">Thrown if handleName is null.</exception>
        public static ConfigurationBuilderCacheHandlePart WithSystemWebCacheHandle(this ConfigurationBuilderCachePart part, string instanceName)
            => WithSystemWebCacheHandle(part, instanceName, false);

        /// <summary>
        /// Adds a <see cref="SystemWebCacheHandle{TCacheValue}" /> using a <see cref="System.Web.Caching.Cache"/> instance with the given <paramref name="instanceName"/>.
        /// The named cache instance can be configured via <c>app/web.config</c> <c>system.runtime.caching</c> section.
        /// </summary>
        /// <param name="part">The builder part.</param>
        /// <param name="instanceName">The name to be used for the cache instance.</param>
        /// <param name="isBackPlateSource">Set this to true if this cache handle should be the source of the back plate.
        /// This setting will be ignored if no back plate is configured.</param>
        /// <returns>
        /// The builder part.
        /// </returns>
        /// <exception cref="System.ArgumentNullException">If part is null.</exception>
        /// <exception cref="ArgumentNullException">Thrown if <paramref name="instanceName"/> is null.</exception>
        public static ConfigurationBuilderCacheHandlePart WithSystemWebCacheHandle(this ConfigurationBuilderCachePart part, string instanceName, bool isBackPlateSource)
            => part?.WithHandle(typeof(SystemWebCacheHandle<>), instanceName, isBackPlateSource);
#pragma warning restore SA1625
    }
}