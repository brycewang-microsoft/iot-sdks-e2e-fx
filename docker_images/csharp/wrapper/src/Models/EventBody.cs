/*
 * Azure IOT End-to-End Test Wrapper Rest Api
 *
 * No description provided (generated by Swagger Codegen https://github.com/swagger-api/swagger-codegen)
 *
 * OpenAPI spec version: 1.0.0
 * 
 * Generated by: https://github.com/swagger-api/swagger-codegen.git
 */

using System;
using System.Linq;
using System.IO;
using System.Text;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using Newtonsoft.Json;

namespace IO.Swagger.Models
{ 
    /// <summary>
    /// body for an invoming or outgoing event or message
    /// </summary>
    [DataContract]
    public partial class EventBody : IEquatable<EventBody>
    { 
        /// <summary>
        /// payload to send to the method
        /// </summary>
        /// <value>payload to send to the method</value>

        [DataMember(Name="body")]
        public Object Body { get; set; }

        /// <summary>
        /// flags used by horton
        /// </summary>
        /// <value>flags used by horton</value>

        [DataMember(Name="horton_flags")]
        public Object HortonFlags { get; set; }

        /// <summary>
        /// Message attributes
        /// </summary>
        /// <value>Message attributes</value>

        [DataMember(Name="attributes")]
        public Object Attributes { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class EventBody {\n");
            sb.Append("  Body: ").Append(Body).Append("\n");
            sb.Append("  HortonFlags: ").Append(HortonFlags).Append("\n");
            sb.Append("  Attributes: ").Append(Attributes).Append("\n");
            sb.Append("}\n");
            return sb.ToString();
        }

        /// <summary>
        /// Returns the JSON string presentation of the object
        /// </summary>
        /// <returns>JSON string presentation of the object</returns>
        public string ToJson()
        {
            return JsonConvert.SerializeObject(this, Formatting.Indented);
        }

        /// <summary>
        /// Returns true if objects are equal
        /// </summary>
        /// <param name="obj">Object to be compared</param>
        /// <returns>Boolean</returns>
        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            return obj.GetType() == GetType() && Equals((EventBody)obj);
        }

        /// <summary>
        /// Returns true if EventBody instances are equal
        /// </summary>
        /// <param name="other">Instance of EventBody to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(EventBody other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;

            return 
                (
                    Body == other.Body ||
                    Body != null &&
                    Body.Equals(other.Body)
                ) && 
                (
                    HortonFlags == other.HortonFlags ||
                    HortonFlags != null &&
                    HortonFlags.Equals(other.HortonFlags)
                ) && 
                (
                    Attributes == other.Attributes ||
                    Attributes != null &&
                    Attributes.Equals(other.Attributes)
                );
        }

        /// <summary>
        /// Gets the hash code
        /// </summary>
        /// <returns>Hash code</returns>
        public override int GetHashCode()
        {
            unchecked // Overflow is fine, just wrap
            {
                var hashCode = 41;
                // Suitable nullity checks etc, of course :)
                    if (Body != null)
                    hashCode = hashCode * 59 + Body.GetHashCode();
                    if (HortonFlags != null)
                    hashCode = hashCode * 59 + HortonFlags.GetHashCode();
                    if (Attributes != null)
                    hashCode = hashCode * 59 + Attributes.GetHashCode();
                return hashCode;
            }
        }

        #region Operators
        #pragma warning disable 1591

        public static bool operator ==(EventBody left, EventBody right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(EventBody left, EventBody right)
        {
            return !Equals(left, right);
        }

        #pragma warning restore 1591
        #endregion Operators
    }
}
