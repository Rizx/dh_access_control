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
    /// HistoryRequest
    /// </summary>
    [DataContract]
        public partial class HistoryRequest :  IEquatable<HistoryRequest>, IValidatableObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="HistoryRequest" /> class.
        /// </summary>
        /// <param name="activity">activity.</param>
        /// <param name="cardid">cardid.</param>
        /// <param name="state">state.</param>
        public HistoryRequest(string activity = default(string), string cardid = default(string), string state = default(string))
        {
            this.Activity = activity;
            this.Cardid = cardid;
            this.State = state;
        }
        
        /// <summary>
        /// Gets or Sets Activity
        /// </summary>
        [DataMember(Name="activity", EmitDefaultValue=false)]
        public string Activity { get; set; }

        /// <summary>
        /// Gets or Sets Cardid
        /// </summary>
        [DataMember(Name="cardid", EmitDefaultValue=false)]
        public string Cardid { get; set; }

        /// <summary>
        /// Gets or Sets State
        /// </summary>
        [DataMember(Name="state", EmitDefaultValue=false)]
        public string State { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class HistoryRequest {\n");
            sb.Append("  Activity: ").Append(Activity).Append("\n");
            sb.Append("  Cardid: ").Append(Cardid).Append("\n");
            sb.Append("  State: ").Append(State).Append("\n");
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
            return this.Equals(input as HistoryRequest);
        }

        /// <summary>
        /// Returns true if HistoryRequest instances are equal
        /// </summary>
        /// <param name="input">Instance of HistoryRequest to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(HistoryRequest input)
        {
            if (input == null)
                return false;

            return 
                (
                    this.Activity == input.Activity ||
                    (this.Activity != null &&
                    this.Activity.Equals(input.Activity))
                ) && 
                (
                    this.Cardid == input.Cardid ||
                    (this.Cardid != null &&
                    this.Cardid.Equals(input.Cardid))
                ) && 
                (
                    this.State == input.State ||
                    (this.State != null &&
                    this.State.Equals(input.State))
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
                if (this.Activity != null)
                    hashCode = hashCode * 59 + this.Activity.GetHashCode();
                if (this.Cardid != null)
                    hashCode = hashCode * 59 + this.Cardid.GetHashCode();
                if (this.State != null)
                    hashCode = hashCode * 59 + this.State.GetHashCode();
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