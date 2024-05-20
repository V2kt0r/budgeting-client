/*
 * Budgeting Server
 *
 * No description provided (generated by Openapi Generator https://github.com/openapitools/openapi-generator)
 *
 * The version of the OpenAPI document: 0.1.3
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
    /// UserReadWithUserRole
    /// </summary>
    [DataContract(Name = "UserReadWithUserRole")]
    public partial class UserReadWithUserRole : IValidatableObject
    {

        /// <summary>
        /// User role.
        /// </summary>
        /// <value>User role.</value>
        [DataMember(Name = "user_role", IsRequired = true, EmitDefaultValue = true)]
        public UserRole UserRole { get; set; }
        /// <summary>
        /// Initializes a new instance of the <see cref="UserReadWithUserRole" /> class.
        /// </summary>
        [JsonConstructorAttribute]
        protected UserReadWithUserRole() { }
        /// <summary>
        /// Initializes a new instance of the <see cref="UserReadWithUserRole" /> class.
        /// </summary>
        /// <param name="username">Username must be unique and between 2 and 30 characters long. (required).</param>
        /// <param name="email">Email must be unique and less than 50 characters long. (required).</param>
        /// <param name="tierUuid">tierUuid.</param>
        /// <param name="uuid">uuid (required).</param>
        /// <param name="profileImageUrl">profileImageUrl.</param>
        /// <param name="userRole">User role. (required).</param>
        public UserReadWithUserRole(string username = default(string), string email = default(string), Guid? tierUuid = default(Guid?), Guid uuid = default(Guid), string profileImageUrl = default(string), UserRole userRole = default(UserRole))
        {
            // to ensure "username" is required (not null)
            if (username == null)
            {
                throw new ArgumentNullException("username is a required property for UserReadWithUserRole and cannot be null");
            }
            this.Username = username;
            // to ensure "email" is required (not null)
            if (email == null)
            {
                throw new ArgumentNullException("email is a required property for UserReadWithUserRole and cannot be null");
            }
            this.Email = email;
            this.Uuid = uuid;
            this.UserRole = userRole;
            this.TierUuid = tierUuid;
            this.ProfileImageUrl = profileImageUrl;
        }

        /// <summary>
        /// Username must be unique and between 2 and 30 characters long.
        /// </summary>
        /// <value>Username must be unique and between 2 and 30 characters long.</value>
        [DataMember(Name = "username", IsRequired = true, EmitDefaultValue = true)]
        public string Username { get; set; }

        /// <summary>
        /// Email must be unique and less than 50 characters long.
        /// </summary>
        /// <value>Email must be unique and less than 50 characters long.</value>
        [DataMember(Name = "email", IsRequired = true, EmitDefaultValue = true)]
        public string Email { get; set; }

        /// <summary>
        /// Gets or Sets TierUuid
        /// </summary>
        [DataMember(Name = "tier_uuid", EmitDefaultValue = true)]
        public Guid? TierUuid { get; set; }

        /// <summary>
        /// Gets or Sets Uuid
        /// </summary>
        [DataMember(Name = "uuid", IsRequired = true, EmitDefaultValue = true)]
        public Guid Uuid { get; set; }

        /// <summary>
        /// Gets or Sets ProfileImageUrl
        /// </summary>
        [DataMember(Name = "profile_image_url", EmitDefaultValue = true)]
        public string ProfileImageUrl { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("class UserReadWithUserRole {\n");
            sb.Append("  Username: ").Append(Username).Append("\n");
            sb.Append("  Email: ").Append(Email).Append("\n");
            sb.Append("  TierUuid: ").Append(TierUuid).Append("\n");
            sb.Append("  Uuid: ").Append(Uuid).Append("\n");
            sb.Append("  ProfileImageUrl: ").Append(ProfileImageUrl).Append("\n");
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
            // Username (string) maxLength
            if (this.Username != null && this.Username.Length > 30)
            {
                yield return new System.ComponentModel.DataAnnotations.ValidationResult("Invalid value for Username, length must be less than 30.", new [] { "Username" });
            }

            // Username (string) minLength
            if (this.Username != null && this.Username.Length < 2)
            {
                yield return new System.ComponentModel.DataAnnotations.ValidationResult("Invalid value for Username, length must be greater than 2.", new [] { "Username" });
            }

            // Email (string) maxLength
            if (this.Email != null && this.Email.Length > 50)
            {
                yield return new System.ComponentModel.DataAnnotations.ValidationResult("Invalid value for Email, length must be less than 50.", new [] { "Email" });
            }

            if (this.ProfileImageUrl != null) {
                // ProfileImageUrl (string) pattern
                Regex regexProfileImageUrl = new Regex(@"^(https?|ftp)://[^\s/$.?#].[^\s]*$", RegexOptions.CultureInvariant);
                if (!regexProfileImageUrl.Match(this.ProfileImageUrl).Success)
                {
                    yield return new System.ComponentModel.DataAnnotations.ValidationResult("Invalid value for ProfileImageUrl, must match a pattern of " + regexProfileImageUrl, new [] { "ProfileImageUrl" });
                }
            }

            yield break;
        }
    }

}
