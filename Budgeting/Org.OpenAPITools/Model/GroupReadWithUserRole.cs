/*
 * Budgeting Server
 *
 * No description provided (generated by Openapi Generator https://github.com/openapitools/openapi-generator)
 *
 * The version of the OpenAPI document: 0.1.1
 * Generated by: https://github.com/openapitools/openapi-generator.git
 */


using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.IO;
using System.Runtime.Serialization;
using System.Text;
using System.Text.RegularExpressions;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Linq;
using System.ComponentModel.DataAnnotations;
using OpenAPIDateConverter = Org.OpenAPITools.Client.OpenAPIDateConverter;

namespace Org.OpenAPITools.Model
{
    /// <summary>
    /// GroupReadWithUserRole
    /// </summary>
    [DataContract(Name = "GroupReadWithUserRole")]
    public partial class GroupReadWithUserRole : IValidatableObject
    {

        /// <summary>
        /// User role.
        /// </summary>
        /// <value>User role.</value>
        [DataMember(Name = "user_role", IsRequired = true, EmitDefaultValue = true)]
        public UserRole UserRole { get; set; }
        /// <summary>
        /// Initializes a new instance of the <see cref="GroupReadWithUserRole" /> class.
        /// </summary>
        [JsonConstructorAttribute]
        protected GroupReadWithUserRole() { }
        /// <summary>
        /// Initializes a new instance of the <see cref="GroupReadWithUserRole" /> class.
        /// </summary>
        /// <param name="name">The name of the group (required).</param>
        /// <param name="uuid">uuid (required).</param>
        /// <param name="userRole">User role. (required).</param>
        public GroupReadWithUserRole(string name = default(string), Guid uuid = default(Guid), UserRole userRole = default(UserRole))
        {
            // to ensure "name" is required (not null)
            if (name == null)
            {
                throw new ArgumentNullException("name is a required property for GroupReadWithUserRole and cannot be null");
            }
            this.Name = name;
            this.Uuid = uuid;
            this.UserRole = userRole;
        }

        /// <summary>
        /// The name of the group
        /// </summary>
        /// <value>The name of the group</value>
        [DataMember(Name = "name", IsRequired = true, EmitDefaultValue = true)]
        public string Name { get; set; }

        /// <summary>
        /// Gets or Sets Uuid
        /// </summary>
        [DataMember(Name = "uuid", IsRequired = true, EmitDefaultValue = true)]
        public Guid Uuid { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("class GroupReadWithUserRole {\n");
            sb.Append("  Name: ").Append(Name).Append("\n");
            sb.Append("  Uuid: ").Append(Uuid).Append("\n");
            sb.Append("  UserRole: ").Append(UserRole).Append("\n");
            sb.Append("}\n");
            return sb.ToString();
        }

        /// <summary>
        /// Returns the JSON string presentation of the object
        /// </summary>
        /// <returns>JSON string presentation of the object</returns>
        public virtual string ToJson()
        {
            return Newtonsoft.Json.JsonConvert.SerializeObject(this, Newtonsoft.Json.Formatting.Indented);
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
