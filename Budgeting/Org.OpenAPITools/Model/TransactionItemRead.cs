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
    /// TransactionItemRead
    /// </summary>
    [DataContract(Name = "TransactionItemRead")]
    public partial class TransactionItemRead : IValidatableObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="TransactionItemRead" /> class.
        /// </summary>
        [JsonConstructorAttribute]
        protected TransactionItemRead() { }
        /// <summary>
        /// Initializes a new instance of the <see cref="TransactionItemRead" /> class.
        /// </summary>
        /// <param name="amount">Value of the transaction. (required).</param>
        /// <param name="name">name (required).</param>
        /// <param name="description">description (required).</param>
        /// <param name="purchaseCategoryUuid">Purchase category UUID must be a valid UUIDv4. (required).</param>
        /// <param name="uuid">uuid (required).</param>
        /// <param name="categoryName">Name of the purchase category. (required).</param>
        /// <param name="categoryDescription">categoryDescription.</param>
        /// <param name="tagNames">List of tags associated with the item..</param>
        public TransactionItemRead(decimal amount = default(decimal), string name = default(string), string description = default(string), Guid purchaseCategoryUuid = default(Guid), Guid uuid = default(Guid), string categoryName = default(string), string categoryDescription = default(string), List<string> tagNames = default(List<string>))
        {
            this.Amount = amount;
            // to ensure "name" is required (not null)
            if (name == null)
            {
                throw new ArgumentNullException("name is a required property for TransactionItemRead and cannot be null");
            }
            this.Name = name;
            // to ensure "description" is required (not null)
            if (description == null)
            {
                throw new ArgumentNullException("description is a required property for TransactionItemRead and cannot be null");
            }
            this.Description = description;
            this.PurchaseCategoryUuid = purchaseCategoryUuid;
            this.Uuid = uuid;
            // to ensure "categoryName" is required (not null)
            if (categoryName == null)
            {
                throw new ArgumentNullException("categoryName is a required property for TransactionItemRead and cannot be null");
            }
            this.CategoryName = categoryName;
            this.CategoryDescription = categoryDescription;
            this.TagNames = tagNames;
        }

        /// <summary>
        /// Value of the transaction.
        /// </summary>
        /// <value>Value of the transaction.</value>
        [DataMember(Name = "amount", IsRequired = true, EmitDefaultValue = true)]
        public decimal Amount { get; set; }

        /// <summary>
        /// Gets or Sets Name
        /// </summary>
        [DataMember(Name = "name", IsRequired = true, EmitDefaultValue = true)]
        public string Name { get; set; }

        /// <summary>
        /// Gets or Sets Description
        /// </summary>
        [DataMember(Name = "description", IsRequired = true, EmitDefaultValue = true)]
        public string Description { get; set; }

        /// <summary>
        /// Purchase category UUID must be a valid UUIDv4.
        /// </summary>
        /// <value>Purchase category UUID must be a valid UUIDv4.</value>
        [DataMember(Name = "purchase_category_uuid", IsRequired = true, EmitDefaultValue = true)]
        public Guid PurchaseCategoryUuid { get; set; }

        /// <summary>
        /// Gets or Sets Uuid
        /// </summary>
        [DataMember(Name = "uuid", IsRequired = true, EmitDefaultValue = true)]
        public Guid Uuid { get; set; }

        /// <summary>
        /// Name of the purchase category.
        /// </summary>
        /// <value>Name of the purchase category.</value>
        [DataMember(Name = "category_name", IsRequired = true, EmitDefaultValue = true)]
        public string CategoryName { get; set; }

        /// <summary>
        /// Gets or Sets CategoryDescription
        /// </summary>
        [DataMember(Name = "category_description", EmitDefaultValue = true)]
        public string CategoryDescription { get; set; }

        /// <summary>
        /// List of tags associated with the item.
        /// </summary>
        /// <value>List of tags associated with the item.</value>
        [DataMember(Name = "tag_names", EmitDefaultValue = false)]
        public List<string> TagNames { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("class TransactionItemRead {\n");
            sb.Append("  Amount: ").Append(Amount).Append("\n");
            sb.Append("  Name: ").Append(Name).Append("\n");
            sb.Append("  Description: ").Append(Description).Append("\n");
            sb.Append("  PurchaseCategoryUuid: ").Append(PurchaseCategoryUuid).Append("\n");
            sb.Append("  Uuid: ").Append(Uuid).Append("\n");
            sb.Append("  CategoryName: ").Append(CategoryName).Append("\n");
            sb.Append("  CategoryDescription: ").Append(CategoryDescription).Append("\n");
            sb.Append("  TagNames: ").Append(TagNames).Append("\n");
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
            // Amount (decimal) minimum
            if (this.Amount < (decimal)0)
            {
                yield return new System.ComponentModel.DataAnnotations.ValidationResult("Invalid value for Amount, must be a value greater than or equal to 0.", new [] { "Amount" });
            }

            // Name (string) maxLength
            if (this.Name != null && this.Name.Length > 100)
            {
                yield return new System.ComponentModel.DataAnnotations.ValidationResult("Invalid value for Name, length must be less than 100.", new [] { "Name" });
            }

            // Description (string) maxLength
            if (this.Description != null && this.Description.Length > 500)
            {
                yield return new System.ComponentModel.DataAnnotations.ValidationResult("Invalid value for Description, length must be less than 500.", new [] { "Description" });
            }

            // CategoryDescription (string) maxLength
            if (this.CategoryDescription != null && this.CategoryDescription.Length > 500)
            {
                yield return new System.ComponentModel.DataAnnotations.ValidationResult("Invalid value for CategoryDescription, length must be less than 500.", new [] { "CategoryDescription" });
            }

            yield break;
        }
    }

}
