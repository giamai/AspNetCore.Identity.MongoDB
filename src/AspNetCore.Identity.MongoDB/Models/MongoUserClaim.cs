﻿using System;
using System.Diagnostics.CodeAnalysis;
using System.Security.Claims;

namespace AspNetCore.Identity.MongoDB.Models
{
    [SuppressMessage("ReSharper", "AutoPropertyCanBeMadeGetOnly.Local", Justification = "MongoDB serialization needs private setters")]
    public class MongoUserClaim : IEquatable<MongoUserClaim>, IEquatable<Claim>
    {
        public MongoUserClaim(Claim claim)
        {
            ClaimType = claim?.Type ?? throw new ArgumentNullException(nameof(claim));
            ClaimValue = claim.Value;
        }

        public MongoUserClaim(string claimType, string claimValue)
        {
            ClaimType = claimType ?? throw new ArgumentNullException(nameof(claimType));
            ClaimValue = claimValue ?? throw new ArgumentNullException(nameof(claimValue));
        }

        public string ClaimType { get; private set; }
        public string ClaimValue { get; private set; }

        public bool Equals(MongoUserClaim other)
        {
            return other.ClaimType.Equals(ClaimType)
                && other.ClaimValue.Equals(ClaimValue);
        }

        public bool Equals(Claim other)
        {
            return other.Type.Equals(ClaimType)
                && other.Value.Equals(ClaimValue);
        }
    }
}
