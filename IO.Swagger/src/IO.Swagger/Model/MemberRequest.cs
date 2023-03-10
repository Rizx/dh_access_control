/* 
 * WeatherForecast
 *
 * No description provided (generated by Swagger Codegen https://github.com/swagger-api/swagger-codegen)
 *
 * OpenAPI spec version: v1.0
 * 
 * Generated by: https://github.com/swagger-api/swagger-codegen.git
 */
using System;
using System.Linq;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Runtime.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.ComponentModel.DataAnnotations;
using SwaggerDateConverter = IO.Swagger.Client.SwaggerDateConverter;

namespace IO.Swagger.Model
{
    /// <summary>
    /// MemberRequest
    /// </summary>
    [DataContract]
        public partial class MemberRequest :  IEquatable<MemberRequest>, IValidatableObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MemberRequest" /> class.
        /// </summary>
        /// <param name="id">id.</param>
        /// <param name="username">username.</param>
        /// <param name="password">password.</param>
        /// <param name="fullname">fullname.</param>
        /// <param name="address">address.</param>
        /// <param name="cardid">cardid.</param>
        /// <param name="fotoProfile">fotoProfile.</param>
        /// <param name="active">active.</param>
        public MemberRequest(long? id = default(long?), string username = default(string), string password = default(string), string fullname = default(string), string address = default(string), string cardid = default(string), string fotoProfile = default(string), bool? active = default(bool?))
        {
            this.Id = id;
            this.Username = username;
            this.Password = password;
            this.Fullname = fullname;
            this.Address = address;
            this.Cardid = cardid;
            this.FotoProfile = fotoProfile;
            this.Active = active;
        }
        
        /// <summary>
        /// Gets or Sets Id
        /// </summary>
        [DataMember(Name="id", EmitDefaultValue=false)]
        public long? Id { get; set; }

        /// <summary>
        /// Gets or Sets Username
        /// </summary>
        [DataMember(Name="username", EmitDefaultValue=false)]
        public string Username { get; set; }

        /// <summary>
        /// Gets or Sets Password
        /// </summary>
        [DataMember(Name="password", EmitDefaultValue=false)]
        public string Password { get; set; }

        /// <summary>
        /// Gets or Sets Fullname
        /// </summary>
        [DataMember(Name="fullname", EmitDefaultValue=false)]
        public string Fullname { get; set; }

        /// <summary>
        /// Gets or Sets Address
        /// </summary>
        [DataMember(Name="address", EmitDefaultValue=false)]
        public string Address { get; set; }

        /// <summary>
        /// Gets or Sets Cardid
        /// </summary>
        [DataMember(Name="cardid", EmitDefaultValue=false)]
        public string Cardid { get; set; }

        /// <summary>
        /// Gets or Sets FotoProfile
        /// </summary>
        [DataMember(Name="fotoProfile", EmitDefaultValue=false)]
        public string FotoProfile { get; set; }

        /// <summary>
        /// Gets or Sets Active
        /// </summary>
        [DataMember(Name="active", EmitDefaultValue=false)]
        public bool? Active { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class MemberRequest {\n");
            sb.Append("  Id: ").Append(Id).Append("\n");
            sb.Append("  Username: ").Append(Username).Append("\n");
            sb.Append("  Password: ").Append(Password).Append("\n");
            sb.Append("  Fullname: ").Append(Fullname).Append("\n");
            sb.Append("  Address: ").Append(Address).Append("\n");
            sb.Append("  Cardid: ").Append(Cardid).Append("\n");
            sb.Append("  FotoProfile: ").Append(FotoProfile).Append("\n");
            sb.Append("  Active: ").Append(Active).Append("\n");
            sb.Append("}\n");
            return sb.ToString();
        }
  
        /// <summary>
        /// Returns the JSON string presentation of the object
        /// </summary>
        /// <returns>JSON string presentation of the object</returns>
        public virtual string ToJson()
        {
            return JsonConvert.SerializeObject(this, Formatting.Indented);
        }

        /// <summary>
        /// Returns true if objects are equal
        /// </summary>
        /// <param name="input">Object to be compared</param>
        /// <returns>Boolean</returns>
        public override bool Equals(object input)
        {
            return this.Equals(input as MemberRequest);
        }

        /// <summary>
        /// Returns true if MemberRequest instances are equal
        /// </summary>
        /// <param name="input">Instance of MemberRequest to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(MemberRequest input)
        {
            if (input == null)
                return false;

            return 
                (
                    this.Id == input.Id ||
                    (this.Id != null &&
                    this.Id.Equals(input.Id))
                ) && 
                (
                    this.Username == input.Username ||
                    (this.Username != null &&
                    this.Username.Equals(input.Username))
                ) && 
                (
                    this.Password == input.Password ||
                    (this.Password != null &&
                    this.Password.Equals(input.Password))
                ) && 
                (
                    this.Fullname == input.Fullname ||
                    (this.Fullname != null &&
                    this.Fullname.Equals(input.Fullname))
                ) && 
                (
                    this.Address == input.Address ||
                    (this.Address != null &&
                    this.Address.Equals(input.Address))
                ) && 
                (
                    this.Cardid == input.Cardid ||
                    (this.Cardid != null &&
                    this.Cardid.Equals(input.Cardid))
                ) && 
                (
                    this.FotoProfile == input.FotoProfile ||
                    (this.FotoProfile != null &&
                    this.FotoProfile.Equals(input.FotoProfile))
                ) && 
                (
                    this.Active == input.Active ||
                    (this.Active != null &&
                    this.Active.Equals(input.Active))
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
                int hashCode = 41;
                if (this.Id != null)
                    hashCode = hashCode * 59 + this.Id.GetHashCode();
                if (this.Username != null)
                    hashCode = hashCode * 59 + this.Username.GetHashCode();
                if (this.Password != null)
                    hashCode = hashCode * 59 + this.Password.GetHashCode();
                if (this.Fullname != null)
                    hashCode = hashCode * 59 + this.Fullname.GetHashCode();
                if (this.Address != null)
                    hashCode = hashCode * 59 + this.Address.GetHashCode();
                if (this.Cardid != null)
                    hashCode = hashCode * 59 + this.Cardid.GetHashCode();
                if (this.FotoProfile != null)
                    hashCode = hashCode * 59 + this.FotoProfile.GetHashCode();
                if (this.Active != null)
                    hashCode = hashCode * 59 + this.Active.GetHashCode();
                return hashCode;
            }
        }

        /// <summary>
        /// To validate all properties of the instance
        /// </summary>
        /// <param name="validationContext">Validation context</param>
        /// <returns>Validation Result</returns>
        IEnumerable<System.ComponentModel.DataAnnotations.ValidationResult> IValidatableObject.Validate(ValidationContext validationContext)
        {
            yield break;
        }
    }
}
