﻿using System;
using System.Collections.Generic;
using System.Text;
using DotNetOpenId.RelyingParty;
using System.Diagnostics.CodeAnalysis;

namespace DotNetOpenId {
	/// <summary>
	/// An Identifier is either a "http" or "https" URI, or an XRI.
	/// </summary>
	public abstract class Identifier {
		/// <summary>
		/// Converts the string representation of an Identifier to its strong type.
		/// </summary>
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2225:OperatorOverloadsHaveNamedAlternates"), SuppressMessage("Microsoft.Design", "CA1057:StringUriOverloadsCallSystemUriOverloads")]
		public static implicit operator Identifier(string identifier) {
			if (identifier == null) return null;
			return Parse(identifier);
		}
		/// <summary>
		/// Returns a strongly-typed Identifier for a given Uri.
		/// </summary>
		[SuppressMessage("Microsoft.Usage", "CA2225:OperatorOverloadsHaveNamedAlternates")]
		public static implicit operator Identifier(Uri identifier) {
			if (identifier == null) return null;
			return new UriIdentifier(identifier);
		}
		/// <summary>
		/// Converts an Identifier to its string representation.
		/// </summary>
		[SuppressMessage("Microsoft.Usage", "CA2225:OperatorOverloadsHaveNamedAlternates")]
		public static implicit operator String(Identifier identifier) {
			if (identifier == null) return null;
			return identifier.ToString();
		}
		/// <summary>
		/// Parses an identifier string and automatically determines
		/// whether it is an XRI or URI.
		/// </summary>
		/// <param name="identifier">Either a URI or XRI identifier.</param>
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2234:PassSystemUriObjectsInsteadOfStrings")]
		public static Identifier Parse(string identifier) {
			if (string.IsNullOrEmpty(identifier)) throw new ArgumentNullException("identifier");
			return new UriIdentifier(identifier);
		}
		/// <summary>
		/// Gets whether a given string represents a valid Identifier format.
		/// </summary>
		[SuppressMessage("Microsoft.Usage", "CA2234:PassSystemUriObjectsInsteadOfStrings")]
		public static bool IsValid(string identifier) {
			return UriIdentifier.IsValidUri(identifier);
		}
	}
}