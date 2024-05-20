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
    /// PaginatedListResponseGroupReadWithUserRole
    /// </summary>
    [DataContract(Name = "PaginatedListResponse_GroupReadWithUserRole_")]
    public partial class PaginatedListResponseGroupReadWithUserRole : IValidatableObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PaginatedListResponseGroupReadWithUserRole" /> class.
        /// </summary>
        [JsonConstructorAttribute]
        protected PaginatedListResponseGroupReadWithUserRole() { }
        /// <summary>
        /// Initializes a new instance of the <see cref="PaginatedListResponseGroupReadWithUserRole" /> class.
        /// </summary>
        /// <param name="data">data (required).</param>
        /// <param name="totalCount">totalCount (required).</param>
        /// <param name="hasMore">hasMore (required).</param>
        /// <param name="page">page.</param>
        /// <param name="itemsPerPage">itemsPerPage.</param>
        public PaginatedListResponseGroupReadWithUserRole(List<GroupReadWithUserRole> data = default(List<GroupReadWithUserRole>), int totalCount = default(int), bool hasMore = default(bool), int? page = default(int?), int? itemsPerPage = default(int?))
        {
            // to ensure "data" is required (not null)
            if (data == null)
            {
                throw new ArgumentNullException("data is a required property for PaginatedListResponseGroupReadWithUserRole and cannot be null");
            }
            this.Data = data;
            this.TotalCount = totalCount;
            this.HasMore = hasMore;
            this.Page = page;
            this.ItemsPerPage = itemsPerPage;
        }

        /// <summary>
        /// Gets or Sets Data
        /// </summary>
        [DataMember(Name = "data", IsRequired = true, EmitDefaultValue = true)]
        public List<GroupReadWithUserRole> Data { get; set; }

        /// <summary>
        /// Gets or Sets TotalCount
        /// </summary>
        [DataMember(Name = "total_count", IsRequired = true, EmitDefaultValue = true)]
        public int TotalCount { get; set; }

        /// <summary>
        /// Gets or Sets HasMore
        /// </summary>
        [DataMember(Name = "has_more", IsRequired = true, EmitDefaultValue = true)]
        public bool HasMore { get; set; }

        /// <summary>
        /// Gets or Sets Page
        /// </summary>
        [DataMember(Name = "page", EmitDefaultValue = true)]
        public int? Page { get; set; }

        /// <summary>
        /// Gets or Sets ItemsPerPage
        /// </summary>
        [DataMember(Name = "items_per_page", EmitDefaultValue = true)]
        public int? ItemsPerPage { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("class PaginatedListResponseGroupReadWithUserRole {\n");
            sb.Append("  Data: ").Append(Data).Append("\n");
            sb.Append("  TotalCount: ").Append(TotalCount).Append("\n");
            sb.Append("  HasMore: ").Append(HasMore).Append("\n");
            sb.Append("  Page: ").Append(Page).Append("\n");
            sb.Append("  ItemsPerPage: ").Append(ItemsPerPage).Append("\n");
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
