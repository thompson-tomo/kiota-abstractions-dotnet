// ------------------------------------------------------------------------------
//  Copyright (c) Microsoft Corporation.  All Rights Reserved.  Licensed under the MIT License.  See License in the project root for license information.
// ------------------------------------------------------------------------------

using System.Collections.Generic;
using System.IO;
#if NET5_0_OR_GREATER
using System.Diagnostics.CodeAnalysis;
#endif

namespace Microsoft.Kiota.Abstractions.Serialization;

/// <summary>
/// Set of helper methods for JSON serialization
/// </summary>
public static class JsonSerializationHelpers
{
    private const string _jsonContentType = "application/json";
    /// <summary>
    /// Serializes the given object into a string based on the content type.
    /// </summary>
    /// <typeparam name="T">Type of the object to serialize</typeparam>
    /// <param name="value">The object to serialize.</param>
    /// <returns>The serialized representation as a stream.</returns>
    public static Stream SerializeAsStream<T>(T value) where T : IParsable
    => SerializationHelpers.SerializeAsStream(_jsonContentType, value);

    /// <summary>
    /// Serializes the given object into a string based on the content type.
    /// </summary>
    /// <typeparam name="T">Type of the object to serialize</typeparam>
    /// <param name="value">The object to serialize.</param>
    /// <returns>The serialized representation as a string.</returns>
    public static string SerializeAsString<T>(T value) where T : IParsable
    => SerializationHelpers.SerializeAsString(_jsonContentType, value);

    /// <summary>
    /// Serializes the given object into a string based on the content type.
    /// </summary>
    /// <typeparam name="T">Type of the object to serialize</typeparam>
    /// <param name="value">The object to serialize.</param>
    /// <returns>The serialized representation as a stream.</returns>
    public static Stream SerializeAsStream<T>(IEnumerable<T> value) where T : IParsable
    => SerializationHelpers.SerializeAsStream(_jsonContentType, value);

    /// <summary>
    /// Serializes the given object into a string based on the content type.
    /// </summary>
    /// <typeparam name="T">Type of the object to serialize</typeparam>
    /// <param name="value">The object to serialize.</param>
    /// <returns>The serialized representation as a string.</returns>
    public static string SerializeAsString<T>(IEnumerable<T> value) where T : IParsable
    => SerializationHelpers.SerializeAsString(_jsonContentType, value);

}